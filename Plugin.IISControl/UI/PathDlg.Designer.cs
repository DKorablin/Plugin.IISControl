namespace Plugin.IISControl.UI
{
	partial class PathDlg
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
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			this.txtPath = new System.Windows.Forms.TextBox();
			this.bnCancel = new System.Windows.Forms.Button();
			this.bnOk = new System.Windows.Forms.Button();
			this.gbCopy = new System.Windows.Forms.GroupBox();
			this.bnDestinationBrowse = new System.Windows.Forms.Button();
			this.bnSourceBrowse = new System.Windows.Forms.Button();
			this.txtDestination = new System.Windows.Forms.TextBox();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.cbEnableCopy = new System.Windows.Forms.CheckBox();
			this.gbServerPath = new System.Windows.Forms.GroupBox();
			this.cbEnableServerPath = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.gbCopy.SuspendLayout();
			this.gbServerPath.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(7, 21);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 13);
			label2.TabIndex = 0;
			label2.Text = "&Source:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(7, 47);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(63, 13);
			label3.TabIndex = 1;
			label3.Text = "&Destination:";
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(10, 17);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(261, 20);
			this.txtPath.TabIndex = 0;
			this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
			// 
			// bnCancel
			// 
			this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Location = new System.Drawing.Point(211, 136);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(75, 23);
			this.bnCancel.TabIndex = 2;
			this.bnCancel.Text = "&Cancel";
			this.bnCancel.UseVisualStyleBackColor = true;
			// 
			// bnOk
			// 
			this.bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bnOk.Location = new System.Drawing.Point(130, 136);
			this.bnOk.Name = "bnOk";
			this.bnOk.Size = new System.Drawing.Size(75, 23);
			this.bnOk.TabIndex = 3;
			this.bnOk.Text = "&OK";
			this.bnOk.UseVisualStyleBackColor = true;
			// 
			// gbCopy
			// 
			this.gbCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbCopy.Controls.Add(this.bnDestinationBrowse);
			this.gbCopy.Controls.Add(this.bnSourceBrowse);
			this.gbCopy.Controls.Add(this.txtDestination);
			this.gbCopy.Controls.Add(this.txtSource);
			this.gbCopy.Controls.Add(label3);
			this.gbCopy.Controls.Add(label2);
			this.gbCopy.Location = new System.Drawing.Point(9, 12);
			this.gbCopy.Name = "gbCopy";
			this.gbCopy.Size = new System.Drawing.Size(277, 70);
			this.gbCopy.TabIndex = 4;
			this.gbCopy.TabStop = false;
			this.gbCopy.Text = "1: Folder Copy";
			// 
			// bnDestinationBrowse
			// 
			this.bnDestinationBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bnDestinationBrowse.Location = new System.Drawing.Point(247, 44);
			this.bnDestinationBrowse.Name = "bnDestinationBrowse";
			this.bnDestinationBrowse.Size = new System.Drawing.Size(24, 20);
			this.bnDestinationBrowse.TabIndex = 5;
			this.bnDestinationBrowse.Text = "...";
			this.bnDestinationBrowse.UseVisualStyleBackColor = true;
			this.bnDestinationBrowse.Click += new System.EventHandler(this.bnBrowse_Click);
			// 
			// bnSourceBrowse
			// 
			this.bnSourceBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bnSourceBrowse.Location = new System.Drawing.Point(247, 18);
			this.bnSourceBrowse.Name = "bnSourceBrowse";
			this.bnSourceBrowse.Size = new System.Drawing.Size(24, 20);
			this.bnSourceBrowse.TabIndex = 4;
			this.bnSourceBrowse.Text = "...";
			this.bnSourceBrowse.UseVisualStyleBackColor = true;
			this.bnSourceBrowse.Click += new System.EventHandler(this.bnBrowse_Click);
			// 
			// txtDestination
			// 
			this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDestination.Location = new System.Drawing.Point(76, 44);
			this.txtDestination.Name = "txtDestination";
			this.txtDestination.Size = new System.Drawing.Size(165, 20);
			this.txtDestination.TabIndex = 3;
			// 
			// txtSource
			// 
			this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSource.Location = new System.Drawing.Point(76, 18);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(165, 20);
			this.txtSource.TabIndex = 2;
			// 
			// cbEnableCopy
			// 
			this.cbEnableCopy.AutoSize = true;
			this.cbEnableCopy.Location = new System.Drawing.Point(92, 11);
			this.cbEnableCopy.Name = "cbEnableCopy";
			this.cbEnableCopy.Size = new System.Drawing.Size(59, 17);
			this.cbEnableCopy.TabIndex = 5;
			this.cbEnableCopy.Text = "&Enable";
			this.cbEnableCopy.UseVisualStyleBackColor = true;
			this.cbEnableCopy.CheckedChanged += new System.EventHandler(this.cbEnable_CheckedChanged);
			// 
			// gbServerPath
			// 
			this.gbServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbServerPath.Controls.Add(this.txtPath);
			this.gbServerPath.Location = new System.Drawing.Point(9, 89);
			this.gbServerPath.Name = "gbServerPath";
			this.gbServerPath.Size = new System.Drawing.Size(277, 43);
			this.gbServerPath.TabIndex = 6;
			this.gbServerPath.TabStop = false;
			this.gbServerPath.Text = "2: Server Path";
			// 
			// cbEnableServerPath
			// 
			this.cbEnableServerPath.AutoSize = true;
			this.cbEnableServerPath.Location = new System.Drawing.Point(92, 88);
			this.cbEnableServerPath.Name = "cbEnableServerPath";
			this.cbEnableServerPath.Size = new System.Drawing.Size(59, 17);
			this.cbEnableServerPath.TabIndex = 7;
			this.cbEnableServerPath.Text = "&Enable";
			this.cbEnableServerPath.UseVisualStyleBackColor = true;
			this.cbEnableServerPath.CheckedChanged += new System.EventHandler(this.cbEnable_CheckedChanged);
			// 
			// PathDlg
			// 
			this.AcceptButton = this.bnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(292, 166);
			this.Controls.Add(this.cbEnableServerPath);
			this.Controls.Add(this.gbServerPath);
			this.Controls.Add(this.cbEnableCopy);
			this.Controls.Add(this.gbCopy);
			this.Controls.Add(this.bnOk);
			this.Controls.Add(this.bnCancel);
			this.MaximumSize = new System.Drawing.Size(600, 200);
			this.MinimumSize = new System.Drawing.Size(180, 200);
			this.Name = "PathDlg";
			this.Text = "Change server path";
			this.gbCopy.ResumeLayout(false);
			this.gbCopy.PerformLayout();
			this.gbServerPath.ResumeLayout(false);
			this.gbServerPath.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.Button bnOk;
		private System.Windows.Forms.GroupBox gbCopy;
		private System.Windows.Forms.Button bnDestinationBrowse;
		private System.Windows.Forms.Button bnSourceBrowse;
		private System.Windows.Forms.TextBox txtDestination;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.CheckBox cbEnableCopy;
		private System.Windows.Forms.GroupBox gbServerPath;
		private System.Windows.Forms.CheckBox cbEnableServerPath;
	}
}