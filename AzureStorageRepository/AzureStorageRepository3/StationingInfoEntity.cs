using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace AzureStorageRepository3
{
    public class StationingInfoEntity : TableEntityBase
    {
        public const string MyPartitionKey = "1";

        public static string GetPartitionKey()
        {
            return MyPartitionKey;
        }

        public StationingInfoEntity()
        { }

        public StationingInfoEntity( string deviceId, int backsights )
        {
            PartitionKey = MyPartitionKey;
            RowKey = deviceId;
            Backsights = backsights;
        }

        public int Backsights { get; set; }

        public override PocoBase ConvertToEntity()
        {
            return new StationingInfo( RowKey, Backsights );
        }
    }
}
