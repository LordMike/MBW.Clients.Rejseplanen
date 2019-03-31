namespace MBW.Clients.Rejseplanen.Objects
{
    public struct WGS84Coordinate
    {
        const int Factor = 1_000_000;

        public double X { get; set; }
        public double Y { get; set; }

        public int XInteger => (int)(X * Factor);
        public int YInteger => (int)(Y * Factor);
    }
}