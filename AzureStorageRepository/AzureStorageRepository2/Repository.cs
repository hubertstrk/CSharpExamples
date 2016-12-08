using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageRepository2
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll( string partitionKey );
    }

    public class Repository<TEntity> where TEntity : class, new()
    {
        private CloudTable _Table;

        public Repository( string connectionString, string tableName )
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse( CloudConfigurationManager.GetSetting( connectionString ) );
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            _Table = tableClient.GetTableReference( tableName );
        }

        public List<TEntity> GetAll( string partitionKey )
        {
            TableQuery query = new TableQuery().Where( TableQuery.GenerateFilterCondition( "PartitionKey", QueryComparisons.Equal, partitionKey ) );
            return _Table.ExecuteQuery( query ).ToList();

        }
    }
}
