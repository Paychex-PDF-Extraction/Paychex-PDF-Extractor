namespace Paychex_itext
{
	partial class Paychex
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
			if (disposing && (components != null))
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
			this.btnBrowse = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.txtFilePath = new System.Windows.Forms.TextBox();
			this.btnProcess = new System.Windows.Forms.Button();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(39, 18);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 0;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// txtFilePath
			// 
			this.txtFilePath.Location = new System.Drawing.Point(120, 18);
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.Size = new System.Drawing.Size(614, 20);
			this.txtFilePath.TabIndex = 1;
			// 
			// btnProcess
			// 
			this.btnProcess.Location = new System.Drawing.Point(39, 89);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(75, 23);
			this.btnProcess.TabIndex = 2;
			this.btnProcess.Text = "Process";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// txtResults
			// 
			this.txtResults.Location = new System.Drawing.Point(120, 91);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.Size = new System.Drawing.Size(614, 347);
			this.txtResults.TabIndex = 3;
			// 
			// Paychex
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtResults);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.txtFilePath);
			this.Controls.Add(this.btnBrowse);
			this.Name = "Paychex";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Paychex Project";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox txtFilePath;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.TextBox txtResults;
	}
}

