using System;
using System.IO;
using System.Windows.Forms;
using Plugin.IISControl.Bll;
using Plugin.IISControl.Properties;
using Plugin.IISControl.UI;
using SAL.Windows;

namespace Plugin.IISControl
{
	internal partial class PanelIISSiteCtrl : UserControl
	{
		#region Fields
		private const String Caption = "IIS Site Ctrl";
		private IisSiteControl _webSite;
		#endregion Fields
		#region Properties
		private PluginWindows Plugin { get { return (PluginWindows)this.Window.Plugin; } }
		private IWindow Window { get { return (IWindow)base.Parent; } }
		private IisControl Utils { get { return this.Plugin.GetIisControl(); } }
		private IisSiteControl WebSite
		{
			get
			{
				if(this._webSite == null || this._webSite.Name != this.Plugin.Settings.WebSiteName)
				{
					if(String.IsNullOrEmpty(this.Plugin.Settings.ServerName) || String.IsNullOrEmpty(this.Plugin.Settings.WebSiteName))
						return null;

					IisSiteControl item = this.Utils.GetSiteByName(this.Plugin.Settings.WebSiteName);
					if(item != null)
					{
						this._webSite = item;
						this.Window.Caption = String.Join(" - ", new String[] { this._webSite.Name, PanelIISSiteCtrl.Caption, });
					}
				}
				return this._webSite;
			}
		}

		#endregion Properties
		public PanelIISSiteCtrl()
			=> InitializeComponent();

		protected override void OnCreateControl()
		{
			this.Window.Caption = PanelIISSiteCtrl.Caption;
			this.Window.SetTabPicture(Resources.iis);

			tsbnChangeHomeDir.Enabled = tsmiAddHost.Enabled = !String.IsNullOrEmpty(this.Plugin.Settings.ServerName) && !String.IsNullOrEmpty(this.Plugin.Settings.WebSiteName);

			base.OnCreateControl();
		}

		private void tsbnChangeHomeDir_Click(Object sender, EventArgs e)
		{
			if(this.WebSite!=null)
			{
				String directoryName = this.WebSite.Path;
				using(PathDlg dlg = new PathDlg(this.Plugin, directoryName))
					if(dlg.ShowDialog() == DialogResult.OK)
					{
						if(dlg.EnableCopy)
							if(dlg.CopyFolders())
								this.AddLogMessage(String.Format("Directory '{0}' copied to '{1}'", dlg.SourcePath, dlg.DestinationPath));
							else
							{
								this.AddLogMessage("The process of copying a directory canceled");
								return;
							}
						if(dlg.EnableServerpath)
						{
							this.WebSite.Path = dlg.HomeDirectory;
							this.AddLogMessage(String.Format("Home directory changed to '{0}'", dlg.HomeDirectory));
						}
					}
			} else
				MessageBox.Show("Web Site is not defined");
		}
		private void tsmiAddHost_Click(Object sender, EventArgs e)
		{
			if(tsmiAddHost.ButtonPressed)
				if(this.WebSite!=null)
				{
					using(HostHeaderDlg dlg = new HostHeaderDlg(this.WebSite.GetHostHeaders()))
						if(dlg.ShowDialog() == DialogResult.OK)
						{
							this.WebSite.AddHostHeader(dlg.IP, dlg.Port, dlg.Host);
							tsmiAddHost.DropDownItems.Clear();
							this.AddLogMessage(String.Format("Host header added {0}:{1}", dlg.Host, dlg.Port));
						}
				} else
					MessageBox.Show("Web Site is not defined");
		}
		private void tsmiAddHost_DropDownOpening(Object sender, EventArgs e)
		{
			if(tsmiAddHost.DropDownItems.Count == 0 && this.WebSite!=null)
				foreach(String hostHeader in this.WebSite.GetHostHeaders())
					tsmiAddHost.DropDownItems.Add(hostHeader);
		}
		private void tsmiAddHost_DropDownItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			if(e.ClickedItem != null
				&& MessageBox.Show(String.Format("Are you sure you want to remove {0} from hosts?", e.ClickedItem.Text), this.Window.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.WebSite.RemoveHostHeader(e.ClickedItem.Text);
				tsmiAddHost.DropDownItems.Remove(e.ClickedItem);
			}
		}
		private void AddLogMessage(String message)
		{
			ListViewItem item = lvLog.Items.Insert(0, String.Empty);
			String[] subItems = Array.ConvertAll<String, String>(new String[lvLog.Columns.Count], delegate(String a) { return String.Empty; });
			item.SubItems.AddRange(subItems);

			item.SubItems[colDate.Index].Text = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
			item.SubItems[colMessage.Index].Text = message;
			lvLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private void lvLog_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
				case Keys.Delete:
				case Keys.Back:
					while(lvLog.SelectedItems.Count > 0)
						lvLog.SelectedItems[0].Remove();
					e.Handled = true;
					break;
			}
		}
		private void CopyDirectory(String parentDirectory)
		{
			String source = Path.Combine(this.Plugin.Settings.SourcePath, parentDirectory);
			String destination = Path.Combine(this.Plugin.Settings.DestinationPath, parentDirectory);

			foreach(String file in Directory.GetFiles(source))
				File.Copy(file, Path.Combine(destination, Path.GetFileName(file)));
			foreach(String dir in Directory.GetDirectories(source))
			{
				Directory.CreateDirectory(Path.Combine(destination, dir.Remove(0, source.Length + 1)));
				this.CopyDirectory(dir.Remove(0, this.Plugin.Settings.SourcePath.Length + 1));//Рекурсия
			}
		}
	}
}