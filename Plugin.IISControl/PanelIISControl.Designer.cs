namespace Plugin.IISControl
{
	partial class PanelIISControl
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
			System.Windows.Forms.ToolStrip tsMain;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelIISControl));
			this.tsbnRefresh = new System.Windows.Forms.ToolStripButton();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.lvSites = new System.Windows.Forms.ListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsCopy = new AlphaOmega.Windows.Forms.ContextMenuStripCopy();
			this.pgSettings = new System.Windows.Forms.PropertyGrid();
			this.bwSiteList = new System.ComponentModel.BackgroundWorker();
			this.bwSiteInfo = new System.ComponentModel.BackgroundWorker();
			tsMain = new System.Windows.Forms.ToolStrip();
			tsMain.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsMain
			// 
			tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbnRefresh});
			tsMain.Location = new System.Drawing.Point(0, 0);
			tsMain.Name = "tsMain";
			tsMain.Size = new System.Drawing.Size(150, 25);
			tsMain.TabIndex = 0;
			// 
			// tsbnRefresh
			// 
			this.tsbnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbnRefresh.Image")));
			this.tsbnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbnRefresh.Name = "tsbnRefresh";
			this.tsbnRefresh.Size = new System.Drawing.Size(23, 22);
			this.tsbnRefresh.Text = "Refresh";
			this.tsbnRefresh.Click += new System.EventHandler(this.tsbnRefresh_Click);
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.Location = new System.Drawing.Point(0, 25);
			this.splitMain.Name = "splitMain";
			this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.lvSites);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.pgSettings);
			this.splitMain.Size = new System.Drawing.Size(150, 125);
			this.splitMain.SplitterDistance = 62;
			this.splitMain.TabIndex = 1;
			// 
			// lvSites
			// 
			this.lvSites.AllowColumnReorder = true;
			this.lvSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colId,
            this.colPath});
			this.lvSites.ContextMenuStrip = this.cmsCopy;
			this.lvSites.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSites.FullRowSelect = true;
			this.lvSites.HideSelection = false;
			this.lvSites.Location = new System.Drawing.Point(0, 0);
			this.lvSites.Name = "lvSites";
			this.lvSites.Size = new System.Drawing.Size(150, 62);
			this.lvSites.TabIndex = 0;
			this.lvSites.UseCompatibleStateImageBehavior = false;
			this.lvSites.View = System.Windows.Forms.View.Details;
			this.lvSites.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSites_ColumnClick);
			this.lvSites.SelectedIndexChanged += new System.EventHandler(this.lvSites_SelectedIndexChanged);
			this.lvSites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSites_KeyDown);
			// 
			// colName
			// 
			this.colName.Text = "Name";
			// 
			// colId
			// 
			this.colId.Text = "ID";
			// 
			// colPath
			// 
			this.colPath.Text = "Path";
			// 
			// cmsCopy
			// 
			this.cmsCopy.Name = "cmsCopy";
			this.cmsCopy.Size = new System.Drawing.Size(103, 26);
			// 
			// pgSettings
			// 
			this.pgSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgSettings.LineColor = System.Drawing.SystemColors.ControlDark;
			this.pgSettings.Location = new System.Drawing.Point(0, 0);
			this.pgSettings.Name = "pgSettings";
			this.pgSettings.Size = new System.Drawing.Size(150, 59);
			this.pgSettings.TabIndex = 0;
			this.pgSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgSettings_PropertyValueChanged);
			// 
			// bwSiteList
			// 
			this.bwSiteList.WorkerReportsProgress = true;
			this.bwSiteList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSiteList_DoWork);
			this.bwSiteList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSiteList_ProgressChanged);
			this.bwSiteList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSiteList_RunWorkerCompleted);
			// 
			// bwSiteInfo
			// 
			this.bwSiteInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSiteInfo_DoWork);
			this.bwSiteInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSiteInfo_RunWorkerCompleted);
			// 
			// PanelIISControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitMain);
			this.Controls.Add(tsMain);
			this.Name = "PanelIISControl";
			tsMain.ResumeLayout(false);
			tsMain.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Plugin.IISControl.UI.ListViewSorter lvColumnSorter;
		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.PropertyGrid pgSettings;
		private System.Windows.Forms.ListView lvSites;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colId;
		private System.Windows.Forms.ColumnHeader colPath;
		private System.ComponentModel.BackgroundWorker bwSiteList;
		private System.ComponentModel.BackgroundWorker bwSiteInfo;
		private System.Windows.Forms.ToolStripButton tsbnRefresh;
		private AlphaOmega.Windows.Forms.ContextMenuStripCopy cmsCopy;

	}
}
