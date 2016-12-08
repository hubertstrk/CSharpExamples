using System;

namespace Model
{
    public class CoordinatesPoco : PocoBase
    {
        public CoordinatesPoco( string deviceId, string pointName, double northing, double easting, double elevation )
            : base( deviceId )
        {
            PointName = pointName;
            Northing = northing;
            Easting = easting;
            Elevation = elevation;
        }

        public string PointName { get; set; }

        public double Northing { get; set; }

        public double Easting { get; set; }

        public double Elevation { get; set; }
    }
}
