using AsyncProcessor.Processor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProcessor
{
	public partial class Form1 : Form
	{
		private ILogger Logger;
		private ProcessorController _Controller; 

		public Form1()
		{
			InitializeComponent();

			Logger = new Logger( _LstView );

			_Controller = new ProcessorController();
			
			_Controller.Message += _Controller_Message;
		}

		private void _Controller_Message(object sender, string e)
		{
			if (InvokeRequired)
			{
				MethodInvoker log = delegate ()
				{
					Logger.Log( e );
				};
				BeginInvoke( log );
			}
			else
				Logger.Log( e );
		}

		private void _BtnStart_Click(object sender, EventArgs e)
		{
			_Controller.Start();
		}

		private void m_BtnStop_Click(object sender, EventArgs e)
		{
			_Controller.Stop();
		}
	}
}
