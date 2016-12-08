using System;

namespace Model
{
    public class StationingInfo : PocoBase
    {
        public int Backsights { get; set; }

        public StationingInfo( string deviceId, int backsights ) : base( deviceId )
        {
            Backsights = backsights;
        }
    }
}
