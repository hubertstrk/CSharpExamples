using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskyConverter
{
	public class CsvReader : IFileReader
	{
		public string[] Read( string fileName )
		{
			IList<string> lines = new List<string>();
			string line;

			using ( StreamReader file = new StreamReader( fileName ) )
			{
				while ( ( line = file.ReadLine() ) != null )
				{
					lines.Add( line );
				}
			}
			return lines.ToArray();
		}
	}
}
