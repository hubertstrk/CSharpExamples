using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskyConverter.Database
{
	public class DataAccess : IDisposable
	{
		private DatabaseDataContext m_Database;

		public DataAccess()
		{
			m_Database = new DatabaseDataContext( Properties.Settings.Default.KasperskyConnectionString );
		}

		public void DeleteWebWareContent()
		{
			m_Database.ExecuteCommand( "TRUNCATE TABLE WebWareOrders" );
		}

		public void DeleteKasperskyContent()
		{
			m_Database.ExecuteCommand( "TRUNCATE TABLE KasperskyOrders" );
		}

		public void InsertOrderWebWare( WebWareOrder[] entities )
		{
			m_Database.WebWareOrders.InsertAllOnSubmit( entities );
			m_Database.SubmitChanges();
		}

		public void InsertOrderKaspersky( KasperskyOrder[] entities )
		{
			m_Database.KasperskyOrders.InsertAllOnSubmit( entities );
			m_Database.SubmitChanges();
		}

		public void Dispose()
		{
			if ( m_Database != null )
			{
				m_Database.Dispose();
				m_Database = null;
			}
		}
	}
}
