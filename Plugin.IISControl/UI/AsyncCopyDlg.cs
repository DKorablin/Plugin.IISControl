using System;
using System.Windows.Forms;
using System.IO;

namespace Plugin.IISControl.UI
{
	internal partial class AsyncCopyDlg : Form
	{
		private volatile Boolean _cancel = false;

		private String SourcePath { get; set; }

		private String DestinationPath { get; set; }

		public AsyncCopyDlg()
			=> this.InitializeComponent();

		public static Boolean StartProcess(String sourcePath, String destimationPath)
		{
			using(AsyncCopyDlg dlg = new AsyncCopyDlg())
			{
				dlg.SourcePath = sourcePath;
				dlg.DestinationPath = destimationPath;
				return dlg.ShowDialog() == DialogResult.OK;
			}
		}

		protected override void OnShown(EventArgs e)
		{
			if(bgProcessing.IsBusy)
				MessageBox.Show("WTF!!!");
			bgProcessing.RunWorkerAsync();
			base.OnShown(e);
		}

		private void bnCancel_Click(Object sender, EventArgs e)
		{
			bnCancel.Enabled = false;
			this._cancel = true;
			bgProcessing.CancelAsync();
		}

		private void bgProcessing_DoWork(Object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			base.Invoke((MethodInvoker)delegate() { Text = "Deleting..."; });
			if(this.DeleteDirectoryContents())
			{
				base.Invoke((MethodInvoker)delegate() { Text = "Copying..."; });
				if(this.CopyDirectory(String.Empty))
					e.Result = true;
			}
			e.Result = false;
		}

		private void bgProcessing_RunWorkerCompleted(Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			base.DialogResult = (e.Result as Boolean?) == true ? DialogResult.Cancel : DialogResult.OK;
			base.Close();
		}

		private Boolean DeleteDirectoryContents()
		{
			foreach(String dir in Directory.GetDirectories(this.DestinationPath))
			{
				if(this._cancel)
					return false;

				txtFile.Invoke((MethodInvoker)delegate() { txtFile.Text = dir; });

				if(!this.InvokeIOOperationSafe(dir, (MethodInvoker)delegate() { Directory.Delete(dir, true); }))
					return false;
			}
			foreach(String file in Directory.GetFiles(this.DestinationPath))
			{
				if(this._cancel)
					return false;

				txtFile.Invoke((MethodInvoker)delegate() { txtFile.Text = file; });

				if(!this.InvokeIOOperationSafe(file, (MethodInvoker)delegate() { File.Delete(file); }))
					return false;
			}
			return true;
		}
		private Boolean CopyDirectory(String parentDirectory)
		{
			if(this._cancel)
				return false;
			String source = Path.Combine(this.SourcePath, parentDirectory);
			String destination = Path.Combine(this.DestinationPath, parentDirectory);

			foreach(String file in Directory.GetFiles(source))
			{
				if(this._cancel)
					return false;

				txtFile.Invoke((MethodInvoker)delegate() { txtFile.Text = file; });

				String fileName=Path.Combine(destination, Path.GetFileName(file));
				if(!this.InvokeIOOperationSafe(fileName, (MethodInvoker)delegate() { File.Copy(file, fileName); }))
					return false;
			}

			foreach(String dir in Directory.GetDirectories(source))
			{
				if(this._cancel)
					return false;

				String dirName = Path.Combine(destination, dir.Remove(0, source.Length + 1));
				//Directory.CreateDirectory(dirName);
				if(!this.InvokeIOOperationSafe(dirName, (MethodInvoker)delegate() { Directory.CreateDirectory(dirName); })
					|| !this.CopyDirectory(dir.Remove(0, this.SourcePath.Length + 1)))//Рекурсия
					return false;
			}
			return true;
		}
		private Boolean InvokeIOOperationSafe(String title, Delegate method)
		{
			Boolean result = false;
			while(!result)
			{
				try
				{ method.DynamicInvoke(); result = true; } catch(Exception exc)
				{
					switch(MessageBox.Show(exc.Message, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation))
					{
						case DialogResult.Abort:
							return false;
						case DialogResult.Retry:
							break;
						case DialogResult.Ignore:
							result = true;
							break;
					}
				}
			}
			return result;
		}
	}
}