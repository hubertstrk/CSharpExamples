namespace DotNetTicks
{
	partial class _MainWnd
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_MainWnd));
			this._TxtInput = new System.Windows.Forms.TextBox();
			this._TxtResult = new System.Windows.Forms.TextBox();
			this._LblResult = new System.Windows.Forms.Label();
			this._LblInput = new System.Windows.Forms.Label();
			this._ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.converterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuConvertToDateTime = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuConvertToTicks = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this._ErrorProvider)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _TxtInput
			// 
			this._TxtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._TxtInput.Location = new System.Drawing.Point(74, 33);
			this._TxtInput.Name = "_TxtInput";
			this._TxtInput.Size = new System.Drawing.Size(271, 20);
			this._TxtInput.TabIndex = 0;
			this._TxtInput.TextChanged += new System.EventHandler(this.OnTextChangedInput);
			this._TxtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPressedInput);
			// 
			// _TxtResult
			// 
			this._TxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._TxtResult.Location = new System.Drawing.Point(74, 60);
			this._TxtResult.Name = "_TxtResult";
			this._TxtResult.ReadOnly = true;
			this._TxtResult.Size = new System.Drawing.Size(271, 20);
			this._TxtResult.TabIndex = 1;
			// 
			// _LblResult
			// 
			this._LblResult.AutoSize = true;
			this._LblResult.Location = new System.Drawing.Point(12, 63);
			this._LblResult.Name = "_LblResult";
			this._LblResult.Size = new System.Drawing.Size(59, 13);
			this._LblResult.TabIndex = 2;
			this._LblResult.Text = "Date Time:";
			// 
			// _LblInput
			// 
			this._LblInput.AutoSize = true;
			this._LblInput.Location = new System.Drawing.Point(12, 36);
			this._LblInput.Name = "_LblInput";
			this._LblInput.Size = new System.Drawing.Size(36, 13);
			this._LblInput.TabIndex = 3;
			this._LblInput.Text = "Ticks:";
			// 
			// _ErrorProvider
			// 
			this._ErrorProvider.ContainerControl = this;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.converterToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(371, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// converterToolStripMenuItem
			// 
			this.converterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuConvertToDateTime,
            this._MenuConvertToTicks});
			this.converterToolStripMenuItem.Name = "converterToolStripMenuItem";
			this.converterToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.converterToolStripMenuItem.Text = "Converter";
			// 
			// _MenuConvertToDateTime
			// 
			this._MenuConvertToDateTime.Checked = true;
			this._MenuConvertToDateTime.CheckOnClick = true;
			this._MenuConvertToDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this._MenuConvertToDateTime.Name = "_MenuConvertToDateTime";
			this._MenuConvertToDateTime.Size = new System.Drawing.Size(174, 22);
			this._MenuConvertToDateTime.Text = "Ticks -> Date Time";
			this._MenuConvertToDateTime.Click += new System.EventHandler(this._MenuToDateTime_Click);
			// 
			// _MenuConvertToTicks
			// 
			this._MenuConvertToTicks.CheckOnClick = true;
			this._MenuConvertToTicks.Name = "_MenuConvertToTicks";
			this._MenuConvertToTicks.Size = new System.Drawing.Size(174, 22);
			this._MenuConvertToTicks.Text = "Date Time -> Ticks";
			this._MenuConvertToTicks.Click += new System.EventHandler(this._MenuToTicks_Click);
			// 
			// _MainWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 110);
			this.Controls.Add(this._LblInput);
			this.Controls.Add(this._LblResult);
			this.Controls.Add(this._TxtResult);
			this.Controls.Add(this._TxtInput);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "_MainWnd";
			this.ShowIcon = false;
			this.Text = "DotNetTicks";
			this.Load += new System.EventHandler(this.OnLoad);
			((System.ComponentModel.ISupportInitialize)(this._ErrorProvider)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _TxtInput;
		private System.Windows.Forms.TextBox _TxtResult;
		private System.Windows.Forms.Label _LblResult;
		private System.Windows.Forms.Label _LblInput;
		private System.Windows.Forms.ErrorProvider _ErrorProvider;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem converterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _MenuConvertToDateTime;
		private System.Windows.Forms.ToolStripMenuItem _MenuConvertToTicks;
	}
}

