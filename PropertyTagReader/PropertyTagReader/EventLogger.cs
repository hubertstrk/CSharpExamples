using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTagReader
{
	/// <summary>
	/// Helper class to write information to the console. 
	/// </summary>
	public static class EventLogger
	{
		/// <summary>
		/// Write exception to screen. 
		/// </summary>
		/// <param name="ex">The exception</param>
		public static void WriteAndExit( Exception ex )
		{
			Console.WriteLine( ex.ToString() );
			Console.ReadLine();
			Environment.Exit( -1 );
		}

		/// <summary>
		/// Write message to screen. 
		/// </summary>
		/// <param name="message">The message</param>
		public static void WriteAndExit( string message )
		{
			Console.WriteLine( message );
			Console.ReadLine();
			Environment.Exit( -1 );
		}

		/// <summary>
		/// Write messages and header to screen. 
		/// </summary>
		/// <param name="header">The header text</param>
		/// <param name="message">The messages</param>
		public static void WriteInfo( string header, string[] message )
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine( " >> " + header );
			Console.WriteLine();

			for ( int i = 0; i < message.Count(); i++ )
				Console.WriteLine( "    " + message[i] );

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine();
		}
	}
}