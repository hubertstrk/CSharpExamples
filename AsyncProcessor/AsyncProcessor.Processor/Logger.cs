using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProcessor.Processor
{
	public interface ILogger
	{
		void Log(string message);
	}

	public class Logger : ILogger
	{
		private ListBox _ListBox;

		public Logger(ListBox listbox )
		{
			_ListBox = listbox;
		}

		public void Log(string message)
		{
			_ListBox.Items.Add( string.Format( "{0}: {1}", DateTime.UtcNow.ToString(), message ) );
		}
	}
}
