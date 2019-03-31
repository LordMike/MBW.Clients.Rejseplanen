using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Dawn;
using MBW.Clients.Rejseplanen.Enums;
using MBW.Clients.Rejseplanen.Internal;
using MBW.Clients.Rejseplanen.Objects;
using MBW.Clients.Rejseplanen.Schema.RestArrivalBoard;
using MBW.Clients.Rejseplanen.Schema.RestDepartureBoard;
using MBW.Clients.Rejseplanen.Schema.RestJourneyDetail;
using MBW.Clients.Rejseplanen.Schema.RestLocation;
using MBW.Clients.Rejseplanen.Schema.RestMultiDepartureBoard;
using MBW.Clients.Rejseplanen.Schema.RestTrip;

namespace MBW.Clients.Rejseplanen
{
    public class RejseplanenClient
    {
        private readonly string dateFormat = "dd.MM.yy";
        private readonly string timeFormat = "HH:mm";

        private readonly TimeZoneInfo serviceTimeZone = TimeZoneInfo.FromSerializedString("Romance Standard Time;60;(UTC+01:00) Brussels, Copenhagen, Madrid, Paris;Romance Standard Time;Romance Daylight Time;[01:01:0001;12:31:9999;60;[0;02:00:00;3;5;0;];[0;03:00:00;10;5;0;];];");
        private readonly HttpClient httpClient;
        private readonly Uri baseUri = new Uri("http://xmlopen.rejseplanen.dk/bin/rest.exe/");
        private readonly XmlSerializerFactory serializerFactory = new XmlSerializerFactory();
        private TimeSpan requestTimeout = TimeSpan.FromMinutes(10);

        /// <summary>
        /// Timeout for all requests, defaults to 10 minutes.
        /// Accepted values are 10 ms..1 hour
        /// </summary>
        public TimeSpan RequestTimeout
        {
            get => requestTimeout;
            set
            {
                Guard.Argument(value, nameof(value)).InRange(TimeSpan.FromMilliseconds(10), TimeSpan.FromHours(1));

                requestTimeout = value;
            }
        }

        public RejseplanenClient(HttpClient httpClient)
        {
            Guard.Argument(httpClient, nameof(httpClient)).NotNull();

            this.httpClient = httpClient;
        }

        private async Task<T> PerformGetAsync<T>(Uri uri, CancellationToken callerCancellationToken) where T : class, new()
        {
            using (CancellationTokenSource timedSource = new CancellationTokenSource(RequestTimeout))
            using (CancellationTokenSource combinedCancelSource = CancellationTokenSource.CreateLinkedTokenSource(timedSource.Token, callerCancellationToken))
            {
                CancellationToken cancelToken = combinedCancelSource.Token;

                using (HttpResponseMessage response = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancelToken).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();

                    // Read data
                    // Note: We read to a temporary memory stream, as the Deserialize call in XmlSerializer does not support Async. This could lead to blocking network traffic if used directly.
                    using (MemoryStream memory = new MemoryStream((int)(response.Content.Headers.ContentLength ?? 10240)))
                    {
                        using (Stream network = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                            await network.CopyToAsync(memory, 4096, cancelToken).ConfigureAwait(false);

                        memory.Seek(0, SeekOrigin.Begin);

                        XmlSerializer serializer = serializerFactory.CreateSerializer(typeof(T));

                        using (StreamReader sr = new StreamReader(memory, Encoding.UTF8))
                        {
                            T obj = (T)serializer.Deserialize(sr);

                            // TODO: Check errors ?

                            return obj;
                        }
                    }
                }
            }
        }

        private Task<T> PerformGetAsync<T>(string service, NameValueCollection query, CancellationToken cancellationToken) where T : class, new()
        {
            Uri uri = new Uri(baseUri, $"{service}?{query}");

            return PerformGetAsync<T>(uri, cancellationToken);
        }

        public async Task<LocationList> GetLocationAsync(string input, CancellationToken cancellationToken = default)
        {
            Guard.Argument(input, nameof(input)).NotEmpty().NotNull();

            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["input"] = input;

            LocationList res = await PerformGetAsync<LocationList>(RejseplanenServices.Location, query, cancellationToken);

            // TODO: Check errors ?

            return res;
        }

        public async Task<Schema.RestStopsNearby.LocationList> GetStopsNearbyAsync(WGS84Coordinate coordinate, int? maxRadius = null, int? maxNumber = null, CancellationToken cancellationToken = default)
        {
            // TODO: Coordinates can be anything, really, but for DK, they have to be positive
            Guard.Argument(coordinate, nameof(coordinate))
                .Member(x => x.XInteger, _ => _.Positive())
                .Member(x => x.YInteger, _ => _.Positive());
            //Guard.Argument(maxRadius, nameof(maxRadius)).InRange(1,10000);  // TODO
            //Guard.Argument(maxNumber, nameof(maxNumber)).InRange(1, 1000);  // TODO

            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["coordX"] = coordinate.XInteger.ToString();
            query["coordY"] = coordinate.YInteger.ToString();

            if (maxRadius.HasValue)
                query["maxRadius"] = maxRadius.ToString();
            if (maxNumber.HasValue)
                query["maxNumber"] = maxNumber.ToString();

            Schema.RestStopsNearby.LocationList res = await PerformGetAsync<Schema.RestStopsNearby.LocationList>(RejseplanenServices.StopsNearby, query, cancellationToken);

            // TODO: Check errors ?

            return res;
        }

        private async Task<T> GetBoardAsync<T>(string service, NameValueCollection query, DateTime? dateTime, MeansOfTransport meansOfTransport, CancellationToken cancellationToken) where T : class, new()
        {
            DateTime time = dateTime ?? DateTime.UtcNow;

            if (time.Kind == DateTimeKind.Utc)
                time = TimeZoneInfo.ConvertTime(time, serviceTimeZone);

            query["date"] = time.ToString(dateFormat);
            query["time"] = time.ToString(timeFormat);

            if (!meansOfTransport.HasFlag(MeansOfTransport.Bus))
                query["useBus"] = "0";

            if (!meansOfTransport.HasFlag(MeansOfTransport.Train))
                query["useTog"] = "0";

            if (!meansOfTransport.HasFlag(MeansOfTransport.Metro))
                query["useMetro"] = "0";

            T res = await PerformGetAsync<T>(service, query, cancellationToken);

            return res;
        }

        public async Task<ArrivalBoard> GetArrivalBoardAsync(int stopId, DateTime? dateTime = null, MeansOfTransport meansOfTransport = MeansOfTransport.All, CancellationToken cancellationToken = default)
        {
            Guard.Argument(stopId, nameof(stopId)).Positive();
            Guard.Argument(dateTime, nameof(dateTime)).Min(new DateTime(2000, 1, 1));
            Guard.Argument(meansOfTransport, nameof(meansOfTransport)).Defined();

            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["id"] = stopId.ToString();

            ArrivalBoard res = await GetBoardAsync<ArrivalBoard>(RejseplanenServices.ArrivalBoard, query, dateTime, meansOfTransport, cancellationToken);

            if (!string.IsNullOrEmpty(res.Error))
                throw new Exception($"Error in service: {res.Error}");

            return res;
        }

        public async Task<DepartureBoard> GetDepartureBoardAsync(int stopId, DateTime? dateTime = null, MeansOfTransport meansOfTransport = MeansOfTransport.All, CancellationToken cancellationToken = default)
        {
            Guard.Argument(stopId, nameof(stopId)).Positive();
            Guard.Argument(dateTime, nameof(dateTime)).Min(new DateTime(2000, 1, 1));
            Guard.Argument(meansOfTransport, nameof(meansOfTransport)).Defined();

            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["id"] = stopId.ToString();

            DepartureBoard res = await GetBoardAsync<DepartureBoard>(RejseplanenServices.DepartureBoard, query, dateTime, meansOfTransport, cancellationToken);

            if (!string.IsNullOrEmpty(res.Error))
                throw new Exception($"Error in service: {res.Error}");

            return res;
        }

        public async Task<MultiDepartureBoard> GetMultiDepartureBoardAsync(int[] stopIds, DateTime? dateTime = null, MeansOfTransport meansOfTransport = MeansOfTransport.All, CancellationToken cancellationToken = default)
        {
            Guard.Argument(stopIds, nameof(stopIds)).NotNull().CountInRange(1, 10).Require(s => s.All(x => x > 0));
            Guard.Argument(dateTime, nameof(dateTime)).Min(new DateTime(2000, 1, 1));
            Guard.Argument(meansOfTransport, nameof(meansOfTransport)).Defined();

            if (stopIds.Length > 10)
                throw new ArgumentException("Cannot provide more than 10 stop ids", nameof(stopIds));

            NameValueCollection query = HttpUtility.ParseQueryString("");
            for (int i = 0; i < stopIds.Length; i++)
                query["id" + (i + 1)] = stopIds[i].ToString();

            MultiDepartureBoard res = await GetBoardAsync<MultiDepartureBoard>(RejseplanenServices.MultiDepartureBoard, query, dateTime, meansOfTransport, cancellationToken);

            if (!string.IsNullOrEmpty(res.Error))
                throw new Exception($"Error in service: {res.Error}");

            return res;
        }

        public async Task<JourneyDetail> GetJourneyDetailAsync(Schema.RestArrivalBoard.JourneyDetailRef @ref, CancellationToken cancellationToken = default)
        {
            Guard.Argument(@ref, nameof(@ref)).NotNull().Member(s => s.Ref, _ => _.NotNull().NotEmpty());

            JourneyDetail res = await PerformGetAsync<JourneyDetail>(new Uri(@ref.Ref), cancellationToken);

            return res;
        }

        public async Task<JourneyDetail> GetJourneyDetailAsync(Schema.RestDepartureBoard.JourneyDetailRef @ref, CancellationToken cancellationToken = default)
        {
            Guard.Argument(@ref, nameof(@ref)).NotNull().Member(s => s.Ref, _ => _.NotNull().NotEmpty());

            JourneyDetail res = await PerformGetAsync<JourneyDetail>(new Uri(@ref.Ref), cancellationToken);

            return res;
        }

        public async Task<JourneyDetail> GetJourneyDetailAsync(Schema.RestMultiDepartureBoard.JourneyDetailRef @ref, CancellationToken cancellationToken = default)
        {
            Guard.Argument(@ref, nameof(@ref)).NotNull().Member(s => s.Ref, _ => _.NotNull().NotEmpty());

            JourneyDetail res = await PerformGetAsync<JourneyDetail>(new Uri(@ref.Ref), cancellationToken);

            return res;
        }

        public async Task<JourneyDetail> GetJourneyDetailAsync(Schema.RestTrip.JourneyDetailRef @ref, CancellationToken cancellationToken = default)
        {
            Guard.Argument(@ref, nameof(@ref)).NotNull().Member(s => s.Ref, _ => _.NotNull().NotEmpty());

            JourneyDetail res = await PerformGetAsync<JourneyDetail>(new Uri(@ref.Ref), cancellationToken);

            return res;
        }

        public async Task<Trip> GetTripAsync(GetTripRequest request, CancellationToken cancellationToken = default)
        {
            Guard.Argument(request, nameof(request)).NotNull()
                .Require(s => s.OriginStopId.HasValue || s.OriginCoordinate.HasValue || !string.IsNullOrEmpty(s.OriginName))
                .Require(s => s.DestinationStopId.HasValue || s.DestinationCoordinate.HasValue || !string.IsNullOrEmpty(s.DestinationName))
                .Member(s => s.TimeKind, _ => _.Defined())
                .Member(s => s.MeansOfTransport, _ => _.Defined());

            NameValueCollection query = HttpUtility.ParseQueryString("");

            if (request.OriginStopId.HasValue)
                query["originId"] = request.OriginStopId.ToString();
            else if (request.OriginCoordinate.HasValue)
            {
                query["originCoordX"] = request.OriginCoordinate.Value.XInteger.ToString();
                query["originCoordY"] = request.OriginCoordinate.Value.YInteger.ToString();
            }
            else if (!string.IsNullOrEmpty(request.OriginName))
                query["originCoordName"] = request.OriginName;
            else
                throw new ArgumentException("Missing origin", nameof(request));

            if (request.DestinationStopId.HasValue)
                query["destId"] = request.DestinationStopId.ToString();
            else if (request.DestinationCoordinate.HasValue)
            {
                query["destCoordX"] = request.DestinationCoordinate.Value.XInteger.ToString();
                query["destCoordY"] = request.DestinationCoordinate.Value.YInteger.ToString();
            }
            else if (!string.IsNullOrEmpty(request.DestinationName))
                query["destCoordName"] = request.DestinationName;
            else
                throw new ArgumentException("Missing destination", nameof(request));

            if (request.Time.HasValue)
            {
                query["date"] = request.Time.Value.ToString(dateFormat);
                query["time"] = request.Time.Value.ToString(timeFormat);

                if (request.TimeKind == TripTimeKind.ArrivalTime)
                    query["searchForArrival"] = "1";
            }

            if (!request.MeansOfTransport.HasFlag(MeansOfTransport.Bus))
                query["useBus"] = "0";

            if (!request.MeansOfTransport.HasFlag(MeansOfTransport.Train))
                query["useTog"] = "0";

            if (!request.MeansOfTransport.HasFlag(MeansOfTransport.Metro))
                query["useMetro"] = "0";

            if (request.RequireBicycle)
                query["useBicycle"] = "1";

            if (request.MaxWalkingDistanceDeparture.HasValue)
                query["maxWalkingDistanceDep"] = request.MaxWalkingDistanceDeparture.ToString();

            if (request.MaxWalkingDistanceDestination.HasValue)
                query["maxWalkingDistanceDest"] = request.MaxWalkingDistanceDestination.ToString();

            if (request.MaxCyclingDistanceDeparture.HasValue)
                query["maxCyclingDistanceDep"] = request.MaxCyclingDistanceDeparture.ToString();

            if (request.MaxCyclingDistanceDestination.HasValue)
                query["maxCyclingDistanceDest"] = request.MaxCyclingDistanceDestination.ToString();

            Trip res = await PerformGetAsync<Trip>(RejseplanenServices.Trip, query, cancellationToken);

            // TODO: Check errors ?

            return res;
        }
    }
}
