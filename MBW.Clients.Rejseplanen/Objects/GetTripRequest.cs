using System;
using Dawn;
using MBW.Clients.Rejseplanen.Enums;

namespace MBW.Clients.Rejseplanen.Objects
{
    public class GetTripRequest
    {
        internal int? OriginStopId { get; private set; }
        internal string OriginName { get; private set; }
        internal WGS84Coordinate? OriginCoordinate { get; private set; }

        internal int? DestinationStopId { get; private set; }
        internal string DestinationName { get; private set; }
        internal WGS84Coordinate? DestinationCoordinate { get; private set; }

        internal int? ViaStopId { get; private set; }

        internal bool RequireBicycle { get; private set; }

        internal int? MaxWalkingDistanceDeparture { get; private set; }
        internal int? MaxWalkingDistanceDestination { get; private set; }
        internal int? MaxCyclingDistanceDeparture { get; private set; }
        internal int? MaxCyclingDistanceDestination { get; private set; }

        internal DateTime? Time { get; private set; }
        internal TripTimeKind TimeKind { get; private set; } = TripTimeKind.DepartureTime;
        internal MeansOfTransport MeansOfTransport { get; private set; } = MeansOfTransport.All;

        public GetTripRequest WithOrigin(string name)
        {
            Guard.Argument(name, nameof(name)).NotNull().NotEmpty();

            OriginName = name;
            OriginStopId = null;
            OriginCoordinate = null;
            return this;
        }

        public GetTripRequest WithOrigin(WGS84Coordinate coordinate)
        {
            Guard.Argument(coordinate, nameof(coordinate)).Member(s => s.XInteger, _ => _.Positive());
            Guard.Argument(coordinate, nameof(coordinate)).Member(s => s.YInteger, _ => _.Positive());

            OriginName = null;
            OriginStopId = null;
            OriginCoordinate = coordinate;
            return this;
        }

        public GetTripRequest WithOrigin(int stopId)
        {
            Guard.Argument(stopId, nameof(stopId)).Positive();

            OriginName = null;
            OriginStopId = stopId;
            OriginCoordinate = null;
            return this;
        }

        public GetTripRequest WithDestination(string name)
        {
            Guard.Argument(name, nameof(name)).NotNull().NotEmpty();

            DestinationName = name;
            DestinationStopId = null;
            DestinationCoordinate = null;
            return this;
        }

        public GetTripRequest WithDestination(WGS84Coordinate coordinate)
        {
            Guard.Argument(coordinate, nameof(coordinate)).Member(s => s.XInteger, _ => _.Positive());
            Guard.Argument(coordinate, nameof(coordinate)).Member(s => s.YInteger, _ => _.Positive());

            DestinationName = null;
            DestinationStopId = null;
            DestinationCoordinate = coordinate;
            return this;
        }

        public GetTripRequest WithDestination(int stopId)
        {
            Guard.Argument(stopId, nameof(stopId)).Positive();

            DestinationName = null;
            DestinationStopId = stopId;
            DestinationCoordinate = null;
            return this;
        }

        public GetTripRequest WithVia(int stopId)
        {
            Guard.Argument(stopId, nameof(stopId)).Positive();

            ViaStopId = stopId;
            return this;
        }

        public GetTripRequest WithNowTime()
        {
            Time = null;
            TimeKind = TripTimeKind.DepartureTime;
            return this;
        }

        public GetTripRequest WithTime(DateTime time, TripTimeKind kind = TripTimeKind.DepartureTime)
        {
            Guard.Argument(time, nameof(time)).Min(new DateTime(2000, 1, 1));
            Guard.Argument(kind, nameof(kind)).Defined();

            Time = time;
            TimeKind = kind;
            return this;
        }

        public GetTripRequest WithMeansOfTransport(MeansOfTransport meansOfTransport)
        {
            Guard.Argument(meansOfTransport, nameof(meansOfTransport)).Defined();

            MeansOfTransport = meansOfTransport;
            return this;
        }

        public GetTripRequest WithBicycle(bool requireBicycle = true)
        {
            RequireBicycle = requireBicycle;
            return this;
        }

        public GetTripRequest WithMaxWalkingDistance(int maxDistance)
        {
            Guard.Argument(maxDistance, nameof(maxDistance)).InRange(500, 20000);

            return WithMaxWalkingDistance(maxDistance, maxDistance);
        }

        public GetTripRequest WithMaxWalkingDistance(int maxDistanceDeparture, int maxDistanceDestination)
        {
            Guard.Argument(maxDistanceDeparture, nameof(maxDistanceDeparture)).InRange(500, 20000);
            Guard.Argument(maxDistanceDestination, nameof(maxDistanceDestination)).InRange(500, 20000);

            MaxWalkingDistanceDeparture = maxDistanceDeparture;
            MaxWalkingDistanceDestination = maxDistanceDestination;
            return this;
        }

        public GetTripRequest WithMaxCyclingDistance(int maxDistance)
        {
            Guard.Argument(maxDistance, nameof(maxDistance)).InRange(500, 20000);

            return WithMaxCyclingDistance(maxDistance, maxDistance);
        }

        public GetTripRequest WithMaxCyclingDistance(int maxDistanceDeparture, int maxDistanceDestination)
        {
            Guard.Argument(maxDistanceDeparture, nameof(maxDistanceDeparture)).InRange(500, 20000);
            Guard.Argument(maxDistanceDestination, nameof(maxDistanceDestination)).InRange(500, 20000);

            MaxCyclingDistanceDeparture = maxDistanceDeparture;
            MaxCyclingDistanceDestination = maxDistanceDestination;
            return this;
        }
    }
}