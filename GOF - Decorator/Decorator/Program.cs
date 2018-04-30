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
			Decorator sd = new DecoratorStorage();
			Decorator ed = new DecoratorEncryption();
			Decorator cd = new DecoratorCleaning();
			Decorator zd = new DecoratorZipping();

			List<Decorator> decorators = new List<Decorator>() { zd, cd, sd, ed };
			ControllerClass controller = new ControllerClass( decorators );
			controller.Start();

			Console.WriteLine();
			Console.WriteLine( "Press enter to close..." );
			Console.Read();
		}
	}

	public class ControllerClass
	{
		private ConcreteComponent m_Component = new ConcreteComponent();
		private IList<Decorator> m_Decorators = new List<Decorator>();

		public ControllerClass( IList<Decorator> decorators )
		{
			m_Decorators = decorators;
		}

		public void Start()
		{
			Decorator decorator = m_Decorators.First();
			decorator.SetComponent( m_Component );

			Decorator curr = null;
			for ( int i = 1; i < m_Decorators.Count; i++ )
			{
				curr = m_Decorators[i];
				curr.SetComponent( decorator );
				decorator = m_Decorators[i];
			}
			decorator.Process();
		}
	}

	public abstract class Component
	{
		public abstract void Process();
	}

	public class ConcreteComponent : Component
	{
		public override void Process()
		{
			Console.Write( "Processing..." );
			Thread.Sleep( 1000 );
			Console.Write( " Finished" );
			Console.WriteLine();
		}
	}

	public abstract class Decorator : Component
	{
		protected Component component;

		public Decorator SetComponent( Component component )
		{
			this.component = component;
			return this;
		}

		public override void Process()
		{
			if ( component != null )
			{
				component.Process();
			}
		}
	}

	public class DecoratorStorage : Decorator
	{

		public override void Process()
		{
			base.Process();

			Store();
		}

		private void Store()
		{
			Thread.Sleep( 200 );
			Console.WriteLine( "Stored." );
		}
	}

	public class DecoratorEncryption : Decorator
	{
		public override void Process()
		{
			base.Process();

			Encrypt();
		}

		private void Encrypt()
		{
			Thread.Sleep( 200 );
			Console.WriteLine( "Encrypted." );
		}
	}

	public class DecoratorZipping : Decorator
	{
		public override void Process()
		{
			base.Process();

			Zip();
		}

		private void Zip()
		{
			Thread.Sleep( 200 );
			Console.WriteLine( "Zipped." );
		}
	}

	public class DecoratorCleaning : Decorator
	{
		public override void Process()
		{
			base.Process();

			Clean();
		}

		private void Clean()
		{
			Thread.Sleep( 200 );
			Console.WriteLine( "Cleaned." );
		}
	}	
}
