using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumBit
{
	class Program
	{
		static void Main( string[] args )
		{
			MyEnumeration e = MyEnumeration.OK;
			e = e.Add( MyEnumeration.Error );
			e = e.Add( MyEnumeration.Attention );
			e = e.Add( MyEnumeration.Warning );
			e = e.Add( MyEnumeration.Error );
			e = e.Add( MyEnumeration.Disaster );

			bool result = e.Has( MyEnumeration.Disaster );
			result = e.Has( MyEnumeration.Warning );
			result = e.Has( MyEnumeration.Error );
			e = e.Remove( MyEnumeration.Warning );
			e = e.Remove( MyEnumeration.Disaster );

			MyEnumeration r = GetMostSevere( e );
		}

		private static MyEnumeration GetMostSevere( MyEnumeration e )
		{
			MyEnumeration mostSevere = MyEnumeration.OK;
			foreach ( MyEnumeration enumeration in Enum.GetValues( typeof( MyEnumeration ) ) )
			{
				if ( e.Has( enumeration ) )
					mostSevere = enumeration;

			}
			return mostSevere;
		}
	}

	[FlagsAttribute]
	public enum MyEnumeration
	{ 
		OK = 1,
		Attention = 2, 
		Warning = 4, 
		Error = 8,
		Disaster = 16,
	}

	public static class EnumerationExtensions
	{
		public static bool Has<T>( this Enum type, T value )
		{
			try
			{
				return ( ( (int) (object) type & (int) (object) value ) == (int) (object) value );
			}
			catch
			{
				return false;
			}
		}

		public static bool Is<T>( this Enum type, T value )
		{
			try
			{
				return (int) (object) type == (int) (object) value;
			}
			catch
			{
				return false;
			}
		}


		public static T Add<T>( this Enum type, T value )
		{
			try
			{
				return (T) (object) ( ( (int) (object) type | (int) (object) value ) );
			}
			catch ( Exception ex )
			{
				throw new ArgumentException(
					string.Format(
						"Could not append value from enumerated type '{0}'.",
						typeof( T ).Name
						), ex );
			}
		}


		public static T Remove<T>( this Enum type, T value )
		{
			try
			{
				return (T) (object) ( ( (int) (object) type & ~(int) (object) value ) );
			}
			catch ( Exception ex )
			{
				throw new ArgumentException(
					string.Format(
						"Could not remove value from enumerated type '{0}'.",
						typeof( T ).Name
						), ex );
			}
		}
	}
}
