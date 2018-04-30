using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder
{
	class Program
	{
		static void Main( string[] args )
		{
			BuilderWeb webBuilder = new BuilderWeb( @"www.Trimble.com" );
			BuilderFile fileBuilder = new BuilderFile( @"C:\Temp", true );

			Director director = new Director();
			director.Construct( webBuilder );
			director.Construct( fileBuilder );

			Product webProduct = webBuilder.GetResult();
			Product fileProduct = fileBuilder.GetResult();

			webProduct.GetContent();
			fileProduct.GetContent();

			Console.ReadLine();
		}
	}

	/// <summary>
	/// Director
	/// </summary>
	class Director
	{
		// Builder uses a complex series of steps
		public void Construct( Builder builder )
		{
			builder.Create();
		}
	}

	/// <summary>
	/// Builder
	/// </summary>
	abstract class Builder
	{
		public abstract void Create();
		public abstract Product GetResult();
	}

	/// <summary>
	/// Concrete builder
	/// </summary>
	class BuilderWeb : Builder
	{
		private WebProduct _Product = new WebProduct();

		private string _Url;

		public BuilderWeb( string url )
		{
			_Url = url;
		}

		public override void Create()
		{
			// build product with url
			_Product.Build( _Url );
		}

		public override Product GetResult()
		{
			return _Product;
		}
	}

	/// <summary>
	/// Concrete builder
	/// </summary>
	class BuilderFile : Builder
	{
		private FileProduct product = new FileProduct();

		private string _FileName;
		private bool _Option; 

		public BuilderFile( string fileName, bool option )
		{
			_FileName = fileName;
			_Option = option;
		}

		public override void Create()
		{
			// build product with filename and option
			product.Build( _FileName + " " + _Option.ToString() );
		}

		public override Product GetResult()
		{
			return product;
		}
	}

	/// <summary>
	/// Product
	/// </summary>
	public abstract class Product
	{
		public string _Part;

		public void Build( string part )
		{
			_Part = part;
		}

		public void Display()
		{
			Console.WriteLine( _Part );
		}

		public abstract void GetContent();
	}

	public class FileProduct : Product
	{
		public override void GetContent()
		{
			// get file from c drive
			Console.WriteLine( "Copying file: " + _Part );
		}
	}

	public class WebProduct : Product
	{
		public override void GetContent()
		{
			// get file from web
			Console.WriteLine( "Downloading: " + _Part );
		}
	}
}
      
