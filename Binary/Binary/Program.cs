using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary
{
    class Program
    {
        static void Main( string[] args )
        {
            int i = 100;
            byte[] bytes = BitConverter.GetBytes( i );
            short j = BitConverter.ToInt16( bytes, 0 );
        }
    }
}
