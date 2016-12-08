using Microsoft.WindowsAzure.Storage.Table;
using Model;

namespace AzureStorageRepository3
{
    public abstract class TableEntityBase : TableEntity
    {
        public abstract PocoBase ConvertToEntity();
    }
}
