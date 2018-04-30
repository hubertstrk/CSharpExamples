using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Decorator
{
	class Program
	{
		static void Main( string[] args )
		{
			ConcreteComponent component = new ConcreteComponent();
			ConcreteDecoratorA decoratorA = new ConcreteDecoratorA();
			ConcreteDecoratorB decoratorB = new ConcreteDecoratorB();
			decoratorA.SetComponent( component );
			decoratorB.SetComponent( decoratorA );
			decoratorB.Operation();

			Console.WriteLine();
			Console.WriteLine( "Press enter to close..." );
			Console.Read();
		}
	}

	// Component
	public abstract class Component
	{
		public abstract string Operation();
	}

	// ConcreteComponent
	public class ConcreteComponent : Component
	{
		public override string Operation()
		{
			Console.WriteLine( "ConcreteComponent.Operation()" );
			return "ConcreteComponentResult";
		}
	}

	// Decorator
	public abstract class Decorator : Component
	{
		protected Component m_Component;

		public void SetComponent( Component component )
		{
			this.m_Component = component;
		}

		public override string Operation()
		{
			if ( m_Component != null )
			{
				return m_Component.Operation();
			}
			return string.Empty;
		}
	}

	public class ConcreteDecoratorA : Decorator
	{
		public override string Operation()
		{
			string result = base.Operation();

			AddedBehavior( result );

			return "ConcreteDecoratorAResult";
		}

		void AddedBehavior( string result )
		{
			Console.WriteLine( "Added beahiour: Do something 1. Result: " + result );
		}
	}

	public class ConcreteDecoratorB : Decorator
	{
		public override string Operation()
		{
			string result = base.Operation();

			AddedBehavior( result );

			return "ConcreteDecoratorBResult";
		}

		void AddedBehavior(string result)
		{
			Console.WriteLine( "Added beahiour: Do something 2. Result: " + result );
		}
	}
}
