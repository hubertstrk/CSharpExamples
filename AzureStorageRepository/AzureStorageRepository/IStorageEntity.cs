using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAzureStorageRepository
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
