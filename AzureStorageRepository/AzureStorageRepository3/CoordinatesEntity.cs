using System;
using Microsoft.WindowsAzure.Storage.Table;
using Model;

namespace AzureStorageRepository3
{
    public class CoordinatesEntity : TableEntityBase
    {
        public CoordinatesEntity()
        { }

        public double Northing { get; set; }

        public double Easting { get; set; }

        public double Elevation { get; set; }

        public CoordinatesEntity( string deviceId, string pointName )
        {
            PartitionKey = deviceId;
            RowKey = pointName;
        }

        public override PocoBase ConvertToEntity()
        {
            return new CoordinatesPoco( PartitionKey, RowKey, Northing, Easting, Elevation );
        }
    }
}
