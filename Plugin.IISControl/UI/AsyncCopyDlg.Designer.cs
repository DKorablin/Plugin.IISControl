namespace Plugin.IISControl.UI
{
	partial class AsyncCopyDlg
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
			this.bnCancel = new System.Windows.Forms.Button();
			this.pbStatus = new System.Windows.Forms.ProgressBar();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.bgProcessing = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// bnCancel
			// 
			this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Location = new System.Drawing.Point(305, 56);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(75, 23);
			this.bnCancel.TabIndex = 0;
			this.bnCancel.Text = "&Cancel";
			this.bnCancel.UseVisualStyleBackColor = true;
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// pbStatus
			// 
			this.pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbStatus.Location = new System.Drawing.Point(12, 13);
			this.pbStatus.Name = "pbStatus";
			this.pbStatus.Size = new System.Drawing.Size(368, 18);
			this.pbStatus.TabIndex = 1;
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFile.Location = new System.Drawing.Point(12, 37);
			this.txtFile.Name = "txtFile";
			this.txtFile.ReadOnly = true;
			this.txtFile.Size = new System.Drawing.Size(368, 13);
			this.txtFile.TabIndex = 2;
			// 
			// bgProcessing
			// 
			this.bgProcessing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgProcessing_DoWork);
			this.bgProcessing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgProcessing_RunWorkerCompleted);
			// 
			// AsyncCopyDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(392, 91);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.pbStatus);
			this.Controls.Add(this.bnCancel);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 125);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(125, 125);
			this.Name = "AsyncCopyDlg";
			this.ShowInTaskbar = false;
			this.Text = "Copying...";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.ProgressBar pbStatus;
		private System.Windows.Forms.TextBox txtFile;
		private System.ComponentModel.BackgroundWorker bgProcessing;
	}
}