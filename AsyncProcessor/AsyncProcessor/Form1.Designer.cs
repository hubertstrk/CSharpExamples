namespace AsyncProcessor
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				if (_Controller != null)
				{
					_Controller.Message -= _Controller_Message;
					_Controller.Dispose();
				}

				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._BtnStart = new System.Windows.Forms.Button();
			this._LstView = new System.Windows.Forms.ListBox();
			this.m_BtnStop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _BtnStart
			// 
			this._BtnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._BtnStart.Location = new System.Drawing.Point(12, 469);
			this._BtnStart.Name = "_BtnStart";
			this._BtnStart.Size = new System.Drawing.Size(75, 34);
			this._BtnStart.TabIndex = 0;
			this._BtnStart.Text = "Start";
			this._BtnStart.UseVisualStyleBackColor = true;
			this._BtnStart.Click += new System.EventHandler(this._BtnStart_Click);
			// 
			// _LstView
			// 
			this._LstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._LstView.FormattingEnabled = true;
			this._LstView.ItemHeight = 16;
			this._LstView.Location = new System.Drawing.Point(12, 12);
			this._LstView.Name = "_LstView";
			this._LstView.Size = new System.Drawing.Size(682, 420);
			this._LstView.TabIndex = 1;
			// 
			// m_BtnStop
			// 
			this.m_BtnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_BtnStop.Location = new System.Drawing.Point(104, 470);
			this.m_BtnStop.Name = "m_BtnStop";
			this.m_BtnStop.Size = new System.Drawing.Size(78, 34);
			this.m_BtnStop.TabIndex = 2;
			this.m_BtnStop.Text = "Stop";
			this.m_BtnStop.UseVisualStyleBackColor = true;
			this.m_BtnStop.Click += new System.EventHandler(this.m_BtnStop_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 515);
			this.Controls.Add(this.m_BtnStop);
			this.Controls.Add(this._LstView);
			this.Controls.Add(this._BtnStart);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "Async Processor";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _BtnStart;
		private System.Windows.Forms.ListBox _LstView;
		private System.Windows.Forms.Button m_BtnStop;
	}
}

