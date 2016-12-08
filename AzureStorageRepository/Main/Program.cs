using AzureStorageRepository3;
using Contracts;
using Model;
using System.Collections.Generic;

namespace Main
{
    class Program
    {
        static void Main( string[] args )
        {
            IRepository repo1 = new Repository( "connectionString", "tableName" );
            IEnumerable<PocoBase> entities1 = repo1.GetAll( "deviceId" );
            CoordinatesPoco coordinates = (CoordinatesPoco) repo1.Get( "deviceId", "pointName" );
            repo1.Add( new CoordinatesEntity( "deviceId", "4" ) );

            IRepository repo2 = new Repository( "connectionString", "tableName" );
            StationingInfo si = (StationingInfo) repo2.Get( StationingInfoEntity.MyPartitionKey, "deviceId" );

        }
    }
}
