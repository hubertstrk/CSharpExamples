using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DotNetTicks
{
	public partial class _MainWnd : Form
	{
		public _MainWnd()
		{
			InitializeComponent();
		}

		private void OnLoad( object sender, EventArgs e )
		{
			_TxtInput.Focus();
		}

		private void ConvertInput()
		{
			RemoveErrorProvider();

			if ( _MenuConvertToDateTime.Checked )
			{
				ConvertToDateTime();
			}
			else
			{
				ConvertToTicks();
			}
		}

		private void ConvertToTicks()
		{
			string input = _TxtInput.Text;

			#region Validation

			string format = @"\b\d\d\d\d-\d\d-\d\d \d\d:\d\d:\d\d";
			Match match = Regex.Match( _TxtInput.Text, format );
			if ( !match.Success )
			{
				_ErrorProvider.SetError( _TxtInput, "Invalid format." );
				return;
			}

			#endregion

			#region Conversion

			DateTime inputDateTime;
			bool success = DateTime.TryParse( input, out inputDateTime );

			if ( !success )
			{
				_ErrorProvider.SetError( _TxtInput, "Wrong format." );
				return;
			}
			else
			{
				_TxtResult.Text = inputDateTime.Ticks.ToString();
			}

			#endregion
		}

		private void ConvertToDateTime()
		{
			string input = _TxtInput.Text;

			#region Validation

			string pattern = "[^0-9]"; 
			Match match = Regex.Match( _TxtInput.Text, pattern );

			if ( match.Success )
			{
				_ErrorProvider.SetError( _TxtInput, "Wrong input: " + match.Value + " (" + match.Index + ")" );
				return;
			}

			#endregion

			#region Conversion

			DateTime dateTime = new DateTime( Convert.ToInt64( input ) );
			_TxtResult.Text = dateTime.ToString() + "." + dateTime.Millisecond.ToString( "000" );

			#endregion
		}

		private void OnKeyPressedInput( object sender, KeyPressEventArgs e )
		{
			RemoveErrorProvider();

			if ( e.KeyChar == 13 )
			{
				ConvertInput();
			}
		}

		private void OnTextChangedInput( object sender, EventArgs e )
		{
			if ( !string.IsNullOrEmpty( _TxtResult.Text ) )
				_TxtResult.Text = string.Empty;
		}

		private void RemoveErrorProvider()
		{
			_ErrorProvider.SetError( _TxtInput, string.Empty );
		}

		private void _BtnConvert_Click( object sender, EventArgs e )
		{
			ConvertInput();
		}

		private void _MenuToDateTime_Click( object sender, EventArgs e )
		{
			_MenuConvertToTicks.Checked = false;

			if ( !_MenuConvertToDateTime.Checked )
				_MenuConvertToDateTime.Checked = true;

			_LblInput.Text = "Ticks:";
			_LblResult.Text = "Date Time:";
		}

		private void _MenuToTicks_Click( object sender, EventArgs e )
		{
			_MenuConvertToDateTime.Checked = false;

			if ( !_MenuConvertToTicks.Checked )
				_MenuConvertToTicks.Checked = true;

			_LblInput.Text = "Date Time:";
			_LblResult.Text = "Ticks:";
		}

		private void closeToolStripMenuItem_Click( object sender, EventArgs e )
		{
			Close();
		}
	}
}
