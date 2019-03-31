using System;

namespace MBW.Clients.Rejseplanen.Enums
{
    [Flags]
    public enum MeansOfTransport : byte
    {
        Bus = 1,
        Train = 2,
        Metro = 4,

        All = byte.MaxValue
    }
}