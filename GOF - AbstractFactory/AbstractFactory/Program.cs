using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory
{
	public class Program
	{
		static void Main( string[] args )
		{
			DriverFactory fac = new DriverFactory();
			Driver driver = fac.GetDriver( "Trimble" );
			Product prod = driver.CreateDriver();
			prod.Measure();

			fac = new DriverFactory();
			driver = fac.GetDriver( "Leica" );
			prod = driver.CreateDriver();
			prod.Measure();

			Console.ReadLine();
		}
	}

	public class DriverFactory
	{
		public Driver GetDriver( string manufacturer )
		{
			if ( manufacturer == "Trimble" )
				return new TSTrimble();
			else
				return new TSLeica();
		}
	}
	
	//Product
	public abstract class Product
	{
		public abstract void Measure();
	}

	//ConcreteProductA
	public class DistanceLeica : Product
	{
		public override void Measure()
		{
			Console.WriteLine( "Leica measured." );
		}
	}

	//ConcreteProductB 
	public class DistanceTrimble : Product
	{
		public override void Measure()
		{
			Console.WriteLine( "Trimble measured." );
		}
	}

	//Creator
	public abstract class Driver
	{
		public abstract Product CreateDriver();
	}

	//ConcreteCreatorA
	public class TSLeica : Driver
	{
		public override Product CreateDriver()
		{
			return new DistanceLeica();
		}
	}

	//ConcreteCreatorB
	public class TSTrimble : Driver
	{
		public override Product CreateDriver()
		{
			return new DistanceTrimble();
		}
	}

      
}
