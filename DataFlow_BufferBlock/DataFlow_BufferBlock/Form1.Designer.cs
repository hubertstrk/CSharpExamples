namespace DataFlow_BufferBlock
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
            this._BtnStart = new System.Windows.Forms.Button();
            this._BtnCancel = new System.Windows.Forms.Button();
            this._BtnClose = new System.Windows.Forms.Button();
            this._LblSizeText = new System.Windows.Forms.Label();
            this._Timer = new System.Windows.Forms.Timer(this.components);
            this._LblBufferSizeT1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _BtnStart
            // 
            this._BtnStart.Location = new System.Drawing.Point(26, 31);
            this._BtnStart.Name = "_BtnStart";
            this._BtnStart.Size = new System.Drawing.Size(112, 100);
            this._BtnStart.TabIndex = 0;
            this._BtnStart.Text = "Start";
            this._BtnStart.UseVisualStyleBackColor = true;
            this._BtnStart.Click += new System.EventHandler(this._BtnStart_Click);
            // 
            // _BtnCancel
            // 
            this._BtnCancel.Location = new System.Drawing.Point(164, 31);
            this._BtnCancel.Name = "_BtnCancel";
            this._BtnCancel.Size = new System.Drawing.Size(112, 100);
            this._BtnCancel.TabIndex = 2;
            this._BtnCancel.Text = "Cancel";
            this._BtnCancel.UseVisualStyleBackColor = true;
            this._BtnCancel.Click += new System.EventHandler(this._BtnCancel_Click);
            // 
            // _BtnClose
            // 
            this._BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._BtnClose.Location = new System.Drawing.Point(415, 211);
            this._BtnClose.Name = "_BtnClose";
            this._BtnClose.Size = new System.Drawing.Size(75, 23);
            this._BtnClose.TabIndex = 3;
            this._BtnClose.Text = "Close";
            this._BtnClose.UseVisualStyleBackColor = true;
            this._BtnClose.Click += new System.EventHandler(this._BtnClose_Click);
            // 
            // _LblSizeText
            // 
            this._LblSizeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._LblSizeText.AutoSize = true;
            this._LblSizeText.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblSizeText.Location = new System.Drawing.Point(350, 31);
            this._LblSizeText.Name = "_LblSizeText";
            this._LblSizeText.Size = new System.Drawing.Size(46, 37);
            this._LblSizeText.TabIndex = 4;
            this._LblSizeText.Text = "T1";
            // 
            // _LblBufferSizeT1
            // 
            this._LblBufferSizeT1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._LblBufferSizeT1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblBufferSizeT1.Location = new System.Drawing.Point(415, 31);
            this._LblBufferSizeT1.Name = "_LblBufferSizeT1";
            this._LblBufferSizeT1.Size = new System.Drawing.Size(75, 37);
            this._LblBufferSizeT1.TabIndex = 1;
            this._LblBufferSizeT1.Text = "99";
            this._LblBufferSizeT1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 246);
            this.Controls.Add(this._LblSizeText);
            this.Controls.Add(this._BtnClose);
            this.Controls.Add(this._BtnCancel);
            this.Controls.Add(this._LblBufferSizeT1);
            this.Controls.Add(this._BtnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Data Flow Library - Buffer Block";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _BtnStart;
        private System.Windows.Forms.Button _BtnCancel;
        private System.Windows.Forms.Button _BtnClose;
        private System.Windows.Forms.Label _LblSizeText;
        private System.Windows.Forms.Timer _Timer;
        private System.Windows.Forms.Label _LblBufferSizeT1;
    }
}

