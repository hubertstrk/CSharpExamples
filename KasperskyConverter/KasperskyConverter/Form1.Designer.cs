namespace KasperskyConverter
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
			this.m_BtnClose = new System.Windows.Forms.Button();
			this.m_BtnSelectWebWare = new System.Windows.Forms.Button();
			this.m_TxtWebWarePath = new System.Windows.Forms.TextBox();
			this.m_BtnImport = new System.Windows.Forms.Button();
			this.m_TxtKasperskyPath = new System.Windows.Forms.TextBox();
			this.m_LblWebWareSelect = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_BtnSelectKaspersky = new System.Windows.Forms.Button();
			this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.m_ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.m_ErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// m_BtnClose
			// 
			this.m_BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_BtnClose.Location = new System.Drawing.Point(575, 227);
			this.m_BtnClose.Name = "m_BtnClose";
			this.m_BtnClose.Size = new System.Drawing.Size(75, 27);
			this.m_BtnClose.TabIndex = 0;
			this.m_BtnClose.Text = "Beenden";
			this.m_BtnClose.UseVisualStyleBackColor = true;
			// 
			// m_BtnSelectWebWare
			// 
			this.m_BtnSelectWebWare.Location = new System.Drawing.Point(356, 61);
			this.m_BtnSelectWebWare.Name = "m_BtnSelectWebWare";
			this.m_BtnSelectWebWare.Size = new System.Drawing.Size(32, 23);
			this.m_BtnSelectWebWare.TabIndex = 1;
			this.m_BtnSelectWebWare.Text = "...";
			this.m_BtnSelectWebWare.UseVisualStyleBackColor = true;
			this.m_BtnSelectWebWare.Click += new System.EventHandler(this.m_BtnSelectWebWare_Click);
			// 
			// m_TxtWebWarePath
			// 
			this.m_TxtWebWarePath.Location = new System.Drawing.Point(25, 61);
			this.m_TxtWebWarePath.Name = "m_TxtWebWarePath";
			this.m_TxtWebWarePath.ReadOnly = true;
			this.m_TxtWebWarePath.Size = new System.Drawing.Size(317, 22);
			this.m_TxtWebWarePath.TabIndex = 2;
			// 
			// m_BtnImport
			// 
			this.m_BtnImport.Location = new System.Drawing.Point(25, 227);
			this.m_BtnImport.Name = "m_BtnImport";
			this.m_BtnImport.Size = new System.Drawing.Size(75, 27);
			this.m_BtnImport.TabIndex = 3;
			this.m_BtnImport.Text = "Import";
			this.m_BtnImport.UseVisualStyleBackColor = true;
			this.m_BtnImport.Click += new System.EventHandler(this.m_BtnImport_Click);
			// 
			// m_TxtKasperskyPath
			// 
			this.m_TxtKasperskyPath.Location = new System.Drawing.Point(25, 146);
			this.m_TxtKasperskyPath.Name = "m_TxtKasperskyPath";
			this.m_TxtKasperskyPath.ReadOnly = true;
			this.m_TxtKasperskyPath.Size = new System.Drawing.Size(317, 22);
			this.m_TxtKasperskyPath.TabIndex = 4;
			// 
			// m_LblWebWareSelect
			// 
			this.m_LblWebWareSelect.AutoSize = true;
			this.m_LblWebWareSelect.Location = new System.Drawing.Point(22, 28);
			this.m_LblWebWareSelect.Name = "m_LblWebWareSelect";
			this.m_LblWebWareSelect.Size = new System.Drawing.Size(173, 17);
			this.m_LblWebWareSelect.TabIndex = 6;
			this.m_LblWebWareSelect.Text = "Pfad zur Web Ware Datei:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 107);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Pfad zur Kaspersky Rechnung:";
			// 
			// m_BtnSelectKaspersky
			// 
			this.m_BtnSelectKaspersky.Location = new System.Drawing.Point(356, 146);
			this.m_BtnSelectKaspersky.Name = "m_BtnSelectKaspersky";
			this.m_BtnSelectKaspersky.Size = new System.Drawing.Size(32, 23);
			this.m_BtnSelectKaspersky.TabIndex = 8;
			this.m_BtnSelectKaspersky.Text = "...";
			this.m_BtnSelectKaspersky.UseVisualStyleBackColor = true;
			this.m_BtnSelectKaspersky.Click += new System.EventHandler(this.m_BtnSelectKaspersky_Click);
			// 
			// m_OpenFileDialog
			// 
			this.m_OpenFileDialog.Filter = "CSV|*.csv|All Files|*.*";
			this.m_OpenFileDialog.InitialDirectory = "C:\\";
			this.m_OpenFileDialog.Title = "Web Ware Datei";
			// 
			// m_ErrorProvider
			// 
			this.m_ErrorProvider.ContainerControl = this;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(689, 279);
			this.Controls.Add(this.m_BtnSelectKaspersky);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_LblWebWareSelect);
			this.Controls.Add(this.m_TxtKasperskyPath);
			this.Controls.Add(this.m_BtnImport);
			this.Controls.Add(this.m_TxtWebWarePath);
			this.Controls.Add(this.m_BtnSelectWebWare);
			this.Controls.Add(this.m_BtnClose);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "Kaspersky Converter";
			((System.ComponentModel.ISupportInitialize)(this.m_ErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_BtnClose;
		private System.Windows.Forms.Button m_BtnSelectWebWare;
		private System.Windows.Forms.TextBox m_TxtWebWarePath;
		private System.Windows.Forms.Button m_BtnImport;
		private System.Windows.Forms.TextBox m_TxtKasperskyPath;
		private System.Windows.Forms.Label m_LblWebWareSelect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_BtnSelectKaspersky;
		private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
		private System.Windows.Forms.ErrorProvider m_ErrorProvider;
	}
}

