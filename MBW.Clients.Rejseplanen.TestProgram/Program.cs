using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MBW.Clients.Rejseplanen;
using MBW.Clients.Rejseplanen.Objects;
using MBW.Clients.Rejseplanen.Schema.RestDepartureBoard;
using MBW.Clients.Rejseplanen.Schema.RestStopsNearby;

namespace ConsoleApp4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient(new SocketsHttpHandler
            {
                // Potentially add a proxy like this
                // Proxy = new WebProxy("http://127.0.0.1:8888")
            });

            RejseplanenClient client = new RejseplanenClient(httpClient);

            // Perform queries
            MBW.Clients.Rejseplanen.Schema.RestLocation.LocationList locationLookup = await client.GetLocationAsync("Vestergade");

            Console.WriteLine("Locations search: " + string.Join(", ", locationLookup.CoordLocation.Select(s => s.Name).Concat(locationLookup.StopLocation.Select(p => p.Name))));

            WGS84Coordinate loc = new WGS84Coordinate
            {
                X = 55.650000,
                Y = 12.560000
            };
            LocationList locationsNearby = await client.GetStopsNearbyAsync(loc);

            Console.WriteLine("Stops nearby: " + locationsNearby.StopLocation.Count);

            DepartureBoard departureBoard = await client.GetDepartureBoardAsync(8600626);

            Console.WriteLine("Coming departures: " + departureBoard.Departure.Count);
        }
    }

}
