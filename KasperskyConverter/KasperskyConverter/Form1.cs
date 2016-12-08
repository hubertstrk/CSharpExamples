using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Collections;
using KasperskyConverter.Database;

namespace KasperskyConverter
{
	public partial class Form1 : Form
	{
		private string m_KasperskyFile = string.Empty;
		private string m_WebWareFile = string.Empty;

		public Form1()
		{
			InitializeComponent();

			// todo padding for error provdier => looks nicer
		}

		private void m_BtnSelectWebWare_Click( object sender, EventArgs e )
		{
			DialogResult result = m_OpenFileDialog.ShowDialog();
			if ( result == DialogResult.OK )
			{
				m_TxtWebWarePath.Text = m_OpenFileDialog.FileName;
			}
		}

		private void m_BtnSelectKaspersky_Click( object sender, EventArgs e )
		{
			DialogResult result = m_OpenFileDialog.ShowDialog();
			if ( result == DialogResult.OK )
			{
				m_TxtKasperskyPath.Text = m_OpenFileDialog.FileName;
			}
		}

		private void m_BtnImport_Click( object sender, EventArgs e )
		{
			m_ErrorProvider.Clear();

			if ( string.IsNullOrEmpty( m_TxtWebWarePath.Text ) )
			{
				m_ErrorProvider.SetError( m_BtnSelectWebWare, "Web Ware Datei fehlt." );
				return;
			}

			if ( string.IsNullOrEmpty( m_TxtKasperskyPath.Text ) )
			{
				m_ErrorProvider.SetError( m_BtnSelectKaspersky, "Kaspersky Rechnung fehlt." );
				return;
			}

			IFileReader readerWebWare = new CsvReader();
			string[] linesWebWare = readerWebWare.Read( m_TxtWebWarePath.Text );

			IFileReader readerKaspersky = new CsvReader();
			string[] linesKaspersky = readerKaspersky.Read( m_TxtKasperskyPath.Text );

			IConverter<OrderWebWare> converterWebWare = new ConverterWebWare();
			var ordersWebWare = converterWebWare.Convert( linesWebWare );

			using ( DataAccess da = new DataAccess() )
			{
				// delete everything first 
				da.DeleteWebWareContent();

				// add new orders
				WebWareOrder[] toInsert = ordersWebWare.Select( s => s.ToEntity() ).ToArray();
				da.InsertOrderWebWare( toInsert );
			}

			IConverter<OrderKaspersky> converterKaspersky = new ConverterKaspersky();
			var ordersKaspery = converterKaspersky.Convert( linesKaspersky );

			using ( DataAccess da = new DataAccess() )
			{
				// delete everything first
				da.DeleteKasperskyContent();

				// add new orders
				KasperskyOrder[] toInsert = ordersKaspery.Select( k => k.ToEntity() ).ToArray();
				da.InsertOrderKaspersky( toInsert );
			}
		}
	}
}
