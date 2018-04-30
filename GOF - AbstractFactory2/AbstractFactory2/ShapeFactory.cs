using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory2
{
	public delegate Shape ShapeFactoryMethod();

	public class ShapeFactory
	{
		private Dictionary<string, ShapeFactoryMethod> _Map = new Dictionary<string, ShapeFactoryMethod>();

		public ShapeFactory()
		{
			CreateShapes();
		}

		public Shape CreateObject( string shapeName )
		{
			return _Map[shapeName]();
		}

		protected void Register( string shapeName, ShapeFactoryMethod shapeFactoryMethod )
		{
			_Map.Add( shapeName, shapeFactoryMethod );
		}

		protected bool Unregister( string shapeName )
		{
			return _Map.Remove( shapeName );
		}

		private void CreateShapes()
		{
			Register( "Circle", Circle.CreateObject );
			Register( "Square", Square.CreateObject );
		}
	}
}
