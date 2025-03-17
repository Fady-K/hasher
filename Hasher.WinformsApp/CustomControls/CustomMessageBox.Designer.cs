namespace Hasher.WinformsApp.CustomControls
{
	partial class CustomMessageBoxForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBoxForm));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.txtboxMessage = new System.Windows.Forms.TextBox();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlFooter.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(726, 47);
			this.pnlHeader.TabIndex = 0;
			// 
			// txtboxMessage
			// 
			this.txtboxMessage.BackColor = System.Drawing.Color.White;
			this.txtboxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtboxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtboxMessage.Location = new System.Drawing.Point(0, 47);
			this.txtboxMessage.Multiline = true;
			this.txtboxMessage.Name = "txtboxMessage";
			this.txtboxMessage.ReadOnly = true;
			this.txtboxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtboxMessage.Size = new System.Drawing.Size(726, 251);
			this.txtboxMessage.TabIndex = 2;
			// 
			// pnlFooter
			// 
			this.pnlFooter.Controls.Add(this.btnOK);
			this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new System.Drawing.Point(0, 232);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(726, 66);
			this.pnlFooter.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.BackColor = System.Drawing.Color.WhiteSmoke;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnOK.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(0, 0);
			this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(726, 66);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// CustomMessageBoxForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 298);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.txtboxMessage);
			this.Controls.Add(this.pnlHeader);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CustomMessageBoxForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CustomMessageBox";
			this.pnlFooter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.TextBox txtboxMessage;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Button btnOK;
	}
}