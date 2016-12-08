using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageRepository2
{
    class Program
    {
        static void Main( string[] args )
        {
            IRepository repo = new Repository( "bla", "bla" );
            IEnumerable<MyTableEntity> entities = repo.GetAll( "123456789" );
        }
    }
}
