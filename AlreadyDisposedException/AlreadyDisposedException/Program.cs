using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlreadyDisposedException
{
	class Program
	{
		static void Main( string[] args )
		{
			MyObject myObject = new MyObject();
			myObject.Dispose();

			try
			{
				myObject.m_AutoResetLock.Reset();
			}
			catch ( ObjectDisposedException )
			{

			}
		}
	}

	class MyObject : IDisposable
	{
		public AutoResetEvent m_AutoResetLock;

		public MyObject()
		{
			m_AutoResetLock = new AutoResetEvent( false );
		}

		public void Dispose()
		{
			if ( m_AutoResetLock != null )
			{
				m_AutoResetLock.Close();
				m_AutoResetLock.Dispose();
				m_AutoResetLock = null;
			}
		}
	}
}
