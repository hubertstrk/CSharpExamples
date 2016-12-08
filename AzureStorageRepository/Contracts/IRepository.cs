using Microsoft.WindowsAzure.Storage.Table;
using Model;
using System.Collections.Generic;

namespace Contracts
{
    public interface IRepository
    {
        IEnumerable<PocoBase> GetAll( string partitionKey );

        PocoBase Get( string partitionKey, string rowKey );

        void Add( ITableEntity obj );
    }
}
