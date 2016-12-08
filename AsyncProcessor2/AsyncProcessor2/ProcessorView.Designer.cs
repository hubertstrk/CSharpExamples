namespace AsyncProcessor
{
	partial class ProcessorView
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
			m_Scheduler.SchedulerAction -= Scheduler_SchedulerAction;
			m_Scheduler.Dispose();

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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			this.m_GridScheduler = new System.Windows.Forms.DataGridView();
			this.m_GridScheduler_Col_Icon = new System.Windows.Forms.DataGridViewImageColumn();
			this.m_GridScheduler_Col_EventTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_GridScheduler_Col_Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.schedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_LblSchedulerStatus = new System.Windows.Forms.Label();
			this.m_LblLastRuntime = new System.Windows.Forms.Label();
			this.m_LblLastRuntimeResult = new System.Windows.Forms.Label();
			this.m_LblSchedulerStatusResult = new System.Windows.Forms.Label();
			this.m_GridProcessor = new System.Windows.Forms.DataGridView();
			this.m_GridProcessor_Col_Icon = new System.Windows.Forms.DataGridViewImageColumn();
			this.m_GridProcessor_Col_EventTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_GridProcessor_Col_Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_LblProcessorStatusResult = new System.Windows.Forms.Label();
			this.m_LblProcessorStatus = new System.Windows.Forms.Label();
			this.m_LblQueueCountResult = new System.Windows.Forms.Label();
			this.m_LblQueueCount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.m_GridScheduler)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_GridProcessor)).BeginInit();
			this.SuspendLayout();
			// 
			// m_GridScheduler
			// 
			this.m_GridScheduler.AllowUserToAddRows = false;
			this.m_GridScheduler.AllowUserToDeleteRows = false;
			this.m_GridScheduler.AllowUserToResizeRows = false;
			this.m_GridScheduler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.m_GridScheduler.BackgroundColor = System.Drawing.Color.White;
			this.m_GridScheduler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.m_GridScheduler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.m_GridScheduler.ColumnHeadersHeight = 40;
			this.m_GridScheduler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_GridScheduler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_GridScheduler_Col_Icon,
            this.m_GridScheduler_Col_EventTime,
            this.m_GridScheduler_Col_Message});
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(1);
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_GridScheduler.DefaultCellStyle = dataGridViewCellStyle11;
			this.m_GridScheduler.GridColor = System.Drawing.Color.White;
			this.m_GridScheduler.Location = new System.Drawing.Point(19, 117);
			this.m_GridScheduler.Margin = new System.Windows.Forms.Padding(2);
			this.m_GridScheduler.Name = "m_GridScheduler";
			this.m_GridScheduler.ReadOnly = true;
			this.m_GridScheduler.RowHeadersVisible = false;
			this.m_GridScheduler.RowHeadersWidth = 40;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(3);
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_GridScheduler.RowsDefaultCellStyle = dataGridViewCellStyle12;
			this.m_GridScheduler.RowTemplate.Height = 24;
			this.m_GridScheduler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_GridScheduler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_GridScheduler.ShowCellErrors = false;
			this.m_GridScheduler.ShowCellToolTips = false;
			this.m_GridScheduler.ShowEditingIcon = false;
			this.m_GridScheduler.ShowRowErrors = false;
			this.m_GridScheduler.Size = new System.Drawing.Size(415, 348);
			this.m_GridScheduler.TabIndex = 2;
			// 
			// m_GridScheduler_Col_Icon
			// 
			this.m_GridScheduler_Col_Icon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.m_GridScheduler_Col_Icon.HeaderText = "";
			this.m_GridScheduler_Col_Icon.MinimumWidth = 25;
			this.m_GridScheduler_Col_Icon.Name = "m_GridScheduler_Col_Icon";
			this.m_GridScheduler_Col_Icon.ReadOnly = true;
			this.m_GridScheduler_Col_Icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.m_GridScheduler_Col_Icon.Width = 25;
			// 
			// m_GridScheduler_Col_EventTime
			// 
			dataGridViewCellStyle9.Format = "G";
			dataGridViewCellStyle9.NullValue = null;
			dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(3);
			this.m_GridScheduler_Col_EventTime.DefaultCellStyle = dataGridViewCellStyle9;
			this.m_GridScheduler_Col_EventTime.HeaderText = "Event Time";
			this.m_GridScheduler_Col_EventTime.MinimumWidth = 150;
			this.m_GridScheduler_Col_EventTime.Name = "m_GridScheduler_Col_EventTime";
			this.m_GridScheduler_Col_EventTime.ReadOnly = true;
			this.m_GridScheduler_Col_EventTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.m_GridScheduler_Col_EventTime.Width = 150;
			// 
			// m_GridScheduler_Col_Message
			// 
			dataGridViewCellStyle10.NullValue = null;
			dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3);
			this.m_GridScheduler_Col_Message.DefaultCellStyle = dataGridViewCellStyle10;
			this.m_GridScheduler_Col_Message.HeaderText = "Event";
			this.m_GridScheduler_Col_Message.MinimumWidth = 400;
			this.m_GridScheduler_Col_Message.Name = "m_GridScheduler_Col_Message";
			this.m_GridScheduler_Col_Message.ReadOnly = true;
			this.m_GridScheduler_Col_Message.Width = 400;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.schedulerToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(910, 24);
			this.menuStrip1.TabIndex = 4;
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
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// schedulerToolStripMenuItem
			// 
			this.schedulerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.schedulerToolStripMenuItem.Name = "schedulerToolStripMenuItem";
			this.schedulerToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.schedulerToolStripMenuItem.Text = "Scheduler";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.infoToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// m_LblSchedulerStatus
			// 
			this.m_LblSchedulerStatus.AutoSize = true;
			this.m_LblSchedulerStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblSchedulerStatus.Location = new System.Drawing.Point(14, 41);
			this.m_LblSchedulerStatus.Name = "m_LblSchedulerStatus";
			this.m_LblSchedulerStatus.Size = new System.Drawing.Size(197, 32);
			this.m_LblSchedulerStatus.TabIndex = 5;
			this.m_LblSchedulerStatus.Text = "Scheduler Status:";
			// 
			// m_LblLastRuntime
			// 
			this.m_LblLastRuntime.AutoSize = true;
			this.m_LblLastRuntime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblLastRuntime.Location = new System.Drawing.Point(15, 79);
			this.m_LblLastRuntime.Name = "m_LblLastRuntime";
			this.m_LblLastRuntime.Size = new System.Drawing.Size(104, 21);
			this.m_LblLastRuntime.TabIndex = 7;
			this.m_LblLastRuntime.Text = "Last Runtime:";
			// 
			// m_LblLastRuntimeResult
			// 
			this.m_LblLastRuntimeResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblLastRuntimeResult.Location = new System.Drawing.Point(117, 79);
			this.m_LblLastRuntimeResult.Name = "m_LblLastRuntimeResult";
			this.m_LblLastRuntimeResult.Size = new System.Drawing.Size(206, 21);
			this.m_LblLastRuntimeResult.TabIndex = 8;
			this.m_LblLastRuntimeResult.Text = "2016-05-10 16:15:48";
			// 
			// m_LblSchedulerStatusResult
			// 
			this.m_LblSchedulerStatusResult.AutoSize = true;
			this.m_LblSchedulerStatusResult.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblSchedulerStatusResult.ForeColor = System.Drawing.Color.Blue;
			this.m_LblSchedulerStatusResult.Location = new System.Drawing.Point(208, 41);
			this.m_LblSchedulerStatusResult.Name = "m_LblSchedulerStatusResult";
			this.m_LblSchedulerStatusResult.Size = new System.Drawing.Size(152, 32);
			this.m_LblSchedulerStatusResult.TabIndex = 9;
			this.m_LblSchedulerStatusResult.Text = "Not Running";
			// 
			// m_GridProcessor
			// 
			this.m_GridProcessor.AllowUserToAddRows = false;
			this.m_GridProcessor.AllowUserToDeleteRows = false;
			this.m_GridProcessor.AllowUserToResizeRows = false;
			this.m_GridProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_GridProcessor.BackgroundColor = System.Drawing.Color.White;
			this.m_GridProcessor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.m_GridProcessor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.m_GridProcessor.ColumnHeadersHeight = 40;
			this.m_GridProcessor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_GridProcessor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_GridProcessor_Col_Icon,
            this.m_GridProcessor_Col_EventTime,
            this.m_GridProcessor_Col_Message});
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(1);
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_GridProcessor.DefaultCellStyle = dataGridViewCellStyle15;
			this.m_GridProcessor.GridColor = System.Drawing.Color.White;
			this.m_GridProcessor.Location = new System.Drawing.Point(463, 117);
			this.m_GridProcessor.Margin = new System.Windows.Forms.Padding(2);
			this.m_GridProcessor.Name = "m_GridProcessor";
			this.m_GridProcessor.ReadOnly = true;
			this.m_GridProcessor.RowHeadersVisible = false;
			this.m_GridProcessor.RowHeadersWidth = 40;
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(3);
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_GridProcessor.RowsDefaultCellStyle = dataGridViewCellStyle16;
			this.m_GridProcessor.RowTemplate.Height = 24;
			this.m_GridProcessor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_GridProcessor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_GridProcessor.ShowCellErrors = false;
			this.m_GridProcessor.ShowCellToolTips = false;
			this.m_GridProcessor.ShowEditingIcon = false;
			this.m_GridProcessor.ShowRowErrors = false;
			this.m_GridProcessor.Size = new System.Drawing.Size(424, 348);
			this.m_GridProcessor.TabIndex = 10;
			// 
			// m_GridProcessor_Col_Icon
			// 
			this.m_GridProcessor_Col_Icon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.m_GridProcessor_Col_Icon.HeaderText = "";
			this.m_GridProcessor_Col_Icon.MinimumWidth = 25;
			this.m_GridProcessor_Col_Icon.Name = "m_GridProcessor_Col_Icon";
			this.m_GridProcessor_Col_Icon.ReadOnly = true;
			this.m_GridProcessor_Col_Icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.m_GridProcessor_Col_Icon.Width = 25;
			// 
			// m_GridProcessor_Col_EventTime
			// 
			dataGridViewCellStyle13.Format = "G";
			dataGridViewCellStyle13.NullValue = null;
			dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(3);
			this.m_GridProcessor_Col_EventTime.DefaultCellStyle = dataGridViewCellStyle13;
			this.m_GridProcessor_Col_EventTime.HeaderText = "Event Time";
			this.m_GridProcessor_Col_EventTime.MinimumWidth = 150;
			this.m_GridProcessor_Col_EventTime.Name = "m_GridProcessor_Col_EventTime";
			this.m_GridProcessor_Col_EventTime.ReadOnly = true;
			this.m_GridProcessor_Col_EventTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.m_GridProcessor_Col_EventTime.Width = 150;
			// 
			// m_GridProcessor_Col_Message
			// 
			dataGridViewCellStyle14.NullValue = null;
			dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(3);
			this.m_GridProcessor_Col_Message.DefaultCellStyle = dataGridViewCellStyle14;
			this.m_GridProcessor_Col_Message.HeaderText = "Event";
			this.m_GridProcessor_Col_Message.MinimumWidth = 400;
			this.m_GridProcessor_Col_Message.Name = "m_GridProcessor_Col_Message";
			this.m_GridProcessor_Col_Message.ReadOnly = true;
			this.m_GridProcessor_Col_Message.Width = 400;
			// 
			// m_LblProcessorStatusResult
			// 
			this.m_LblProcessorStatusResult.AutoSize = true;
			this.m_LblProcessorStatusResult.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblProcessorStatusResult.ForeColor = System.Drawing.Color.Blue;
			this.m_LblProcessorStatusResult.Location = new System.Drawing.Point(655, 41);
			this.m_LblProcessorStatusResult.Name = "m_LblProcessorStatusResult";
			this.m_LblProcessorStatusResult.Size = new System.Drawing.Size(54, 32);
			this.m_LblProcessorStatusResult.TabIndex = 12;
			this.m_LblProcessorStatusResult.Text = "Idle";
			// 
			// m_LblProcessorStatus
			// 
			this.m_LblProcessorStatus.AutoSize = true;
			this.m_LblProcessorStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblProcessorStatus.Location = new System.Drawing.Point(457, 41);
			this.m_LblProcessorStatus.Name = "m_LblProcessorStatus";
			this.m_LblProcessorStatus.Size = new System.Drawing.Size(192, 32);
			this.m_LblProcessorStatus.TabIndex = 11;
			this.m_LblProcessorStatus.Text = "Processor Status:";
			// 
			// m_LblQueueCountResult
			// 
			this.m_LblQueueCountResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblQueueCountResult.Location = new System.Drawing.Point(568, 79);
			this.m_LblQueueCountResult.Name = "m_LblQueueCountResult";
			this.m_LblQueueCountResult.Size = new System.Drawing.Size(206, 21);
			this.m_LblQueueCountResult.TabIndex = 14;
			this.m_LblQueueCountResult.Text = "0";
			// 
			// m_LblQueueCount
			// 
			this.m_LblQueueCount.AutoSize = true;
			this.m_LblQueueCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LblQueueCount.Location = new System.Drawing.Point(463, 79);
			this.m_LblQueueCount.Name = "m_LblQueueCount";
			this.m_LblQueueCount.Size = new System.Drawing.Size(105, 21);
			this.m_LblQueueCount.TabIndex = 13;
			this.m_LblQueueCount.Text = "Queue Count:";
			// 
			// ProcessorView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(910, 488);
			this.Controls.Add(this.m_LblQueueCountResult);
			this.Controls.Add(this.m_LblQueueCount);
			this.Controls.Add(this.m_LblProcessorStatusResult);
			this.Controls.Add(this.m_LblProcessorStatus);
			this.Controls.Add(this.m_GridProcessor);
			this.Controls.Add(this.m_LblSchedulerStatusResult);
			this.Controls.Add(this.m_LblLastRuntimeResult);
			this.Controls.Add(this.m_LblLastRuntime);
			this.Controls.Add(this.m_LblSchedulerStatus);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.m_GridScheduler);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimizeBox = false;
			this.Name = "ProcessorView";
			this.ShowIcon = false;
			this.Text = "Async Processor";
			((System.ComponentModel.ISupportInitialize)(this.m_GridScheduler)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_GridProcessor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView m_GridScheduler;
		private System.Windows.Forms.DataGridViewImageColumn m_GridScheduler_Col_Icon;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_GridScheduler_Col_EventTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_GridScheduler_Col_Message;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem schedulerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label m_LblSchedulerStatus;
		private System.Windows.Forms.Label m_LblLastRuntime;
		private System.Windows.Forms.Label m_LblLastRuntimeResult;
		private System.Windows.Forms.Label m_LblSchedulerStatusResult;
		private System.Windows.Forms.DataGridView m_GridProcessor;
		private System.Windows.Forms.DataGridViewImageColumn m_GridProcessor_Col_Icon;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_GridProcessor_Col_EventTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn m_GridProcessor_Col_Message;
		private System.Windows.Forms.Label m_LblProcessorStatusResult;
		private System.Windows.Forms.Label m_LblProcessorStatus;
		private System.Windows.Forms.Label m_LblQueueCountResult;
		private System.Windows.Forms.Label m_LblQueueCount;
	}
}

