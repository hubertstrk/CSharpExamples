using System;

namespace Model
{
    public abstract class PocoBase
    {
        public string DeviceId { get; set; }

        public PocoBase( string deviceId )
        {
            DeviceId = deviceId;
        }
    }
}
