using System;
using System.Windows.Forms;
using System.IO;

namespace Plugin.IISControl.UI
{
	internal partial class PathDlg : Form
	{
		private readonly PluginWindows _plugin;

		public String HomeDirectory => txtPath.Text;

		public String SourcePath => txtSource.Text;

		public String DestinationPath => txtDestination.Text;

		public Boolean EnableCopy => cbEnableCopy.Checked;

		public Boolean EnableServerpath => cbEnableServerPath.Checked;

		public PathDlg(PluginWindows plugin,String homeDir)
		{
			this._plugin=plugin;
			this.InitializeComponent();
			txtPath.Text = homeDir;
			this.txtPath_TextChanged(txtPath, EventArgs.Empty);

			cbEnableServerPath.Checked = cbEnableCopy.Checked = false;
			this.cbEnable_CheckedChanged(cbEnableServerPath, EventArgs.Empty);
			this.cbEnable_CheckedChanged(cbEnableCopy, EventArgs.Empty);
			txtSource.Text = this._plugin.Settings.SourcePath;
			txtDestination.Text = this._plugin.Settings.DestinationPath;
		}

		public Boolean CopyFolders()
		{
			if(!Directory.Exists(this._plugin.Settings.SourcePath))
			{
				MessageBox.Show(String.Format("Folder {0} not found", this._plugin.Settings.SourcePath), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			} else if(!Directory.Exists(this._plugin.Settings.DestinationPath))
			{
				MessageBox.Show(String.Format("Folder {0} not found", this._plugin.Settings.DestinationPath), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			} else
				return AsyncCopyDlg.StartProcess(this._plugin.Settings.SourcePath, this._plugin.Settings.DestinationPath);
		}

		private void txtPath_TextChanged(Object sender, EventArgs e)
			=> bnOk.Enabled = !String.IsNullOrEmpty(txtPath.Text);

		private void cbEnable_CheckedChanged(Object sender, EventArgs e)
		{
			GroupBox gb;
			if(sender == cbEnableCopy)
				gb = gbCopy;
			else if(sender == cbEnableServerPath)
				gb = gbServerPath;
			else
				throw new NotImplementedException();

			gb.Enabled = ((CheckBox)sender).Checked;
			bnOk.Enabled = cbEnableServerPath.Checked || cbEnableCopy.Checked;
			if(bnOk.Enabled)
				this.txtPath_TextChanged(txtPath, e);
		}
		private void bnBrowse_Click(Object sender, EventArgs e)
		{
			TextBox txtPath;
			if(sender == bnSourceBrowse)
				txtPath = txtSource;
			else if(sender == bnDestinationBrowse)
				txtPath = txtDestination;
			else
				throw new NotImplementedException();

			using(FolderBrowserDialog dlg = new FolderBrowserDialog() { SelectedPath = txtPath.Text, })
				if(dlg.ShowDialog() == DialogResult.OK)
					txtPath.Text = dlg.SelectedPath;
		}
	}
}