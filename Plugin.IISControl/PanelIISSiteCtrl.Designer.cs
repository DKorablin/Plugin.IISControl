namespace Plugin.IISControl
{
	partial class PanelIISSiteCtrl
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelIISSiteCtrl));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbnChangeHomeDir = new System.Windows.Forms.ToolStripButton();
			this.tsmiAddHost = new System.Windows.Forms.ToolStripSplitButton();
			this.lvLog = new System.Windows.Forms.ListView();
			this.colDate = new System.Windows.Forms.ColumnHeader();
			this.colMessage = new System.Windows.Forms.ColumnHeader();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsMain
			// 
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbnChangeHomeDir,
            this.tsmiAddHost});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(150, 25);
			this.tsMain.TabIndex = 0;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbnChangeHomeDir
			// 
			this.tsbnChangeHomeDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbnChangeHomeDir.Image = ((System.Drawing.Image)(resources.GetObject("tsbnChangeHomeDir.Image")));
			this.tsbnChangeHomeDir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbnChangeHomeDir.Name = "tsbnChangeHomeDir";
			this.tsbnChangeHomeDir.Size = new System.Drawing.Size(23, 22);
			this.tsbnChangeHomeDir.ToolTipText = "Specify local path for selected website";
			this.tsbnChangeHomeDir.Click += new System.EventHandler(this.tsbnChangeHomeDir_Click);
			// 
			// tsmiAddHost
			// 
			this.tsmiAddHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsmiAddHost.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddHost.Image")));
			this.tsmiAddHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsmiAddHost.Name = "tsmiAddHost";
			this.tsmiAddHost.Size = new System.Drawing.Size(32, 22);
			this.tsmiAddHost.ToolTipText = "Add host value";
			this.tsmiAddHost.Click += new System.EventHandler(this.tsmiAddHost_Click);
			this.tsmiAddHost.DropDownOpening += new System.EventHandler(this.tsmiAddHost_DropDownOpening);
			this.tsmiAddHost.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmiAddHost_DropDownItemClicked);
			// 
			// lvLog
			// 
			this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colMessage});
			this.lvLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvLog.FullRowSelect = true;
			this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvLog.Location = new System.Drawing.Point(0, 25);
			this.lvLog.Name = "lvLog";
			this.lvLog.Size = new System.Drawing.Size(150, 125);
			this.lvLog.TabIndex = 1;
			this.lvLog.UseCompatibleStateImageBehavior = false;
			this.lvLog.View = System.Windows.Forms.View.Details;
			this.lvLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvLog_KeyDown);
			// 
			// colDate
			// 
			this.colDate.Text = "Date";
			// 
			// colMessage
			// 
			this.colMessage.Text = "Message";
			// 
			// PanelIISControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvLog);
			this.Controls.Add(this.tsMain);
			this.Name = "PanelIISControl";
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ListView lvLog;
		private System.Windows.Forms.ColumnHeader colDate;
		private System.Windows.Forms.ColumnHeader colMessage;
		private System.Windows.Forms.ToolStripButton tsbnChangeHomeDir;
		private System.Windows.Forms.ToolStripSplitButton tsmiAddHost;
	}
}
