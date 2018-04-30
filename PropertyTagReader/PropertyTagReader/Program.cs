using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace PropertyTagReader
{
	class Program
	{
		static void Main( string[] args )
		{
			Console.Title = "Property Tag Reader";

			if ( args.Count() == 0 )
			{
				EventLogger.WriteAndExit( "You must specify an image file..." );
			}

			string fileName = GetFileName( args );

			Image image = Bitmap.FromFile( fileName );
			PropertyTargetReader reader = new PropertyTargetReader();

			Console.WriteLine( "Number of tags in file: " + reader.Number( image ) );
			Console.WriteLine( "Ids: " + reader.GetAllIds( image ) );
			Console.WriteLine( "270 (0x010E): " + reader.ReadMetadata( image ) );

			Console.ReadLine();
		}

		private static string GetFileName( string[] args )
		{
			// prepare file path
			string fileName = string.Empty;
			foreach ( string arg in args )
			{
				fileName += arg;
				fileName += " ";
			}
			fileName = fileName.TrimEnd();
			return fileName;
		}
	}

	public class PropertyTargetReader
	{
		public string ReadMetadata( Image image )
		{
			PropertyItem propItem = image.GetPropertyItem( 0x010E );
			return Encoding.UTF8.GetString( propItem.Value );
		}

		public string GetAllIds( Image image )
		{
			return String.Join( ", ", image.PropertyItems.Select( pi => pi.Id ).ToArray() );
		}

		public int Number( Image image )
		{
			return image.PropertyItems.Count();
		}
	}
}
