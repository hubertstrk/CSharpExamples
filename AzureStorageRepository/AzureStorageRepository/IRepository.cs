using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAzureStorageRepository
{
    public interface IIGenericRepository<TEntity>
    {
        IEnumerable<TEntity> SelectAll( string partitionKey );

        //TableEntity SelectByID( TableEntity obj );

        //void Insert( TableEntity obj );

        //void Update( TableEntity obj );

        //void Delete( object id );
    }

    public class GenericRepository<TEntity> : IIGenericRepository<TEntity>
    {
        private CloudTable _Table;
        private string _TableName;

        public GenericRepository( string connectionString, string tableName )
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse( CloudConfigurationManager.GetSetting( connectionString ) );
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            _Table = tableClient.GetTableReference( tableName );
        }

        public IEnumerable<TEntity> SelectAll( string partitionKey )
        {
            TableQuery<TEntity> query = new TableQuery<TEntity>().Where( TableQuery.GenerateFilterCondition( "PartitionKey", QueryComparisons.Equal, partitionKey ) );
            //_Table.CreateQuery<TEntity>( _TableName ).ToList();
            _Table.ExecuteQuery( query );
        }
    }
}
