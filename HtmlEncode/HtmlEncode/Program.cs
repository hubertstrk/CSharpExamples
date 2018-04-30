using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HtmlEncode
{
	class Program
	{
		static void Main( string[] args )
		{
			string s = WebUtility.HtmlEncode( char(cf83) );
		}
	}
}
