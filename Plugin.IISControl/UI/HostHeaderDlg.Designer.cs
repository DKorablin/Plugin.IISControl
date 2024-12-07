namespace Plugin.IISControl.UI
{
	partial class HostHeaderDlg
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Button bnCancel;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			this.bnOk = new System.Windows.Forms.Button();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.udPort = new System.Windows.Forms.NumericUpDown();
			this.lbHosts = new System.Windows.Forms.ListBox();
			this.txtIP = new System.Windows.Forms.MaskedTextBox();
			bnCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.udPort)).BeginInit();
			this.SuspendLayout();
			// 
			// bnCancel
			// 
			bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			bnCancel.Location = new System.Drawing.Point(311, 135);
			bnCancel.Name = "bnCancel";
			bnCancel.Size = new System.Drawing.Size(75, 23);
			bnCancel.TabIndex = 8;
			bnCancel.Text = "&Cancel";
			bnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(133, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 13);
			label1.TabIndex = 2;
			label1.Text = "&Host:";
			// 
			// label2
			// 
			label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(301, 11);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 13);
			label2.TabIndex = 4;
			label2.Text = "&Port:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(20, 13);
			label3.TabIndex = 0;
			label3.Text = "&IP:";
			// 
			// bnOk
			// 
			this.bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bnOk.Location = new System.Drawing.Point(230, 135);
			this.bnOk.Name = "bnOk";
			this.bnOk.Size = new System.Drawing.Size(75, 23);
			this.bnOk.TabIndex = 7;
			this.bnOk.Text = "&OK";
			this.bnOk.UseVisualStyleBackColor = true;
			// 
			// txtHost
			// 
			this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHost.Location = new System.Drawing.Point(171, 9);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(124, 20);
			this.txtHost.TabIndex = 3;
			this.txtHost.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// udPort
			// 
			this.udPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.udPort.Location = new System.Drawing.Point(336, 9);
			this.udPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.udPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udPort.Name = "udPort";
			this.udPort.Size = new System.Drawing.Size(50, 20);
			this.udPort.TabIndex = 5;
			this.udPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// lbHosts
			// 
			this.lbHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbHosts.FormattingEnabled = true;
			this.lbHosts.Location = new System.Drawing.Point(12, 36);
			this.lbHosts.Name = "lbHosts";
			this.lbHosts.Size = new System.Drawing.Size(374, 95);
			this.lbHosts.TabIndex = 6;
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(38, 9);
			this.txtIP.Mask = "000/000/000/000";
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(89, 20);
			this.txtIP.TabIndex = 1;
			this.txtIP.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// HostHeaderDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 166);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(label3);
			this.Controls.Add(this.lbHosts);
			this.Controls.Add(this.udPort);
			this.Controls.Add(label2);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(label1);
			this.Controls.Add(this.bnOk);
			this.Controls.Add(bnCancel);
			this.MaximumSize = new System.Drawing.Size(600, 300);
			this.MinimumSize = new System.Drawing.Size(290, 140);
			this.Name = "HostHeaderDlg";
			this.Text = "Add Host";
			((System.ComponentModel.ISupportInitialize)(this.udPort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bnOk;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.NumericUpDown udPort;
		private System.Windows.Forms.ListBox lbHosts;
		private System.Windows.Forms.MaskedTextBox txtIP;
	}
}