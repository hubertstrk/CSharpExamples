using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageRepository1
{
    public class MyTableEntity : TableEntity
    {
        public MyTableEntity()
        { }

        public double Northing { get; set; }

        public double Easting { get; set; }

        public double Elevation { get; set; }

        public MyTableEntity( string deviceId, string pointName )
        {
            PartitionKey = deviceId;
            RowKey = pointName;
        }
    }
}
