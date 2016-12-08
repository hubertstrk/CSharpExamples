using Contracts;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorageRepository3
{
    public class Repository : IRepository
    {
        private CloudTable _Context;

        public Repository( string connectionString, string tableName )
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse( CloudConfigurationManager.GetSetting( connectionString ) );
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            _Context = tableClient.GetTableReference( tableName );
        }

        public void Add( ITableEntity obj )
        {
            TableOperation insertOperation = TableOperation.Insert( obj  );
            _Context.Execute( insertOperation );
        }

        public IEnumerable<PocoBase> GetAll( string partitionKey )
        {
            TableQuery query = new TableQuery().Where( TableQuery.GenerateFilterCondition( "PartitionKey", QueryComparisons.Equal, partitionKey ) );
            return _Context.ExecuteQuery( query ).Cast<TableEntityBase>().Select( s => s.ConvertToEntity() );
        }

        public PocoBase Get( string partitionKey, string rowKey )
        {
            TableQuery query = new TableQuery().Where( TableQuery.GenerateFilterCondition( "PartitionKey", QueryComparisons.Equal, partitionKey ) );
            ITableEntity entity = _Context.ExecuteQuery( query ).FirstOrDefault();
            if ( entity == null )
                return null;
            TableEntityBase tableEntity = (TableEntityBase) entity;
            return tableEntity.ConvertToEntity();
        }
    }
}
