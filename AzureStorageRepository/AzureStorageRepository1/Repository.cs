using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageRepository1
{
    public interface IRepository
    {
        IEnumerable<MyTableEntity> GetAll( string partitionKey );
    }

    public class Repository : IRepository
    {
        private CloudTable _Table;

        public Repository( string connectionString, string tableName )
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse( CloudConfigurationManager.GetSetting( connectionString ) );
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            _Table = tableClient.GetTableReference( tableName );
        }

        public IEnumerable<MyTableEntity> GetAll( string partitionKey )
        {
            TableQuery<MyTableEntity> query = new TableQuery<MyTableEntity>().Where( TableQuery.GenerateFilterCondition( "PartitionKey", QueryComparisons.Equal, partitionKey ) );
            return _Table.ExecuteQuery( query ).ToList();
        }
    }
}
