using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dispose
{
	class Program
	{
		static void Main( string[] args )
		{
		}
	}

	public class Test : IDisposable
	{
		private bool _IsDisposed = false;

		/// <summary>
		/// Implementation of Dispose according to .NET Framework Design Guidelines.
		/// </summary>
		/// <remarks>Do not make this method virtual.
		/// A derived class should not be able to override this method.
		/// </remarks>
		public void Dispose()
		{
			Dispose( true );
			// Take object off the Finalization queue 
			// to prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Implementation of Dispose according to .NET Framework Design Guidelines.
		/// </summary>
		/// <param name="isDisposing"></param>
		/// <remarks>
		/// <para><list type="bulleted">Dispose(bool isDisposing) executes in two distinct scenarios.
		/// <item>If <paramref name="isDisposing"/> equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources
		/// can be disposed.</item>
		/// <item>If <paramref name="isDisposing"/> equals false, the method has been called by the 
		/// runtime from inside the finalizer and you should not reference 
		/// other objects. Only unmanaged resources can be disposed.</item></list></para>
		/// </remarks>
		protected virtual void Dispose( bool disposing )
		{
			if ( !_IsDisposed )
			{
				if ( disposing )
				{
					// release managed resources
				}

				// release unmanaged resources. If disposing is false, 
				// only the following code is executed
			}

			_IsDisposed = true;
		}

	}

	public class SubTest : Test
	{
		private bool _IsDisposed = false;

		/// <summary>
		/// Implementation of Dispose according to .NET Framework Design Guidelines.
		/// </summary>
		/// <param name="isDisposing"></param>
		/// <remarks>
		/// <para><list type="bulleted">Dispose(bool isDisposing) executes in two distinct scenarios.
		/// <item>If <paramref name="isDisposing"/> equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources
		/// can be disposed.</item>
		/// <item>If <paramref name="isDisposing"/> equals false, the method has been called by the 
		/// runtime from inside the finalizer and you should not reference 
		/// other objects. Only unmanaged resources can be disposed.</item></list></para>
		/// </remarks>
		protected override void Dispose( bool disposing )
		{
			if ( _IsDisposed )
			{
				try
				{
					if ( disposing )
					{
						// release managed resources    
					}

					// release unmanaged resources. If disposing is false, 
					// only the following code is executed

					_IsDisposed = true;

				}
				finally
				{
					// call Dispose on your base class.
					base.Dispose( disposing );
				}
			}
		}

	}
}
