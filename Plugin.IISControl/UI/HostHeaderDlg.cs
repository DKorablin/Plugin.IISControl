using System;
using System.Windows.Forms;

namespace Plugin.IISControl.UI
{
	internal partial class HostHeaderDlg : Form
	{
		public String IP
		{
			get => txtIP.Text;
		}
		public String Host
		{
			get => txtHost.Text;
		}
		public Int32 Port
		{
			get => (Int32)udPort.Value;
		}

		public HostHeaderDlg(String[] hosts)
		{
			this.InitializeComponent();
			lbHosts.DataSource = hosts;
		}

		private void txt_TextChanged(Object sender, EventArgs e)
			=> bnOk.Enabled = !String.IsNullOrEmpty(txtHost.Text) && txtIP.MaskCompleted;
	}
}