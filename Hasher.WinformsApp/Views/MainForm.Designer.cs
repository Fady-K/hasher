using Hasher.Core;
using Hasher.WinformsApp.Properties;

namespace Hasher.WinformsApp.Views
{
	partial class MainForm
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
			_configurations.LastSelectedFile = txtBoxFilePath.Text;
			_configurations.LastUsedHashingAlgorithm = cmbbxHashingAlgorithm.SelectedItem.ToString();

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.FileHasherTab = new System.Windows.Forms.TabPage();
			this.pnlGenerateHash = new System.Windows.Forms.Panel();
			this.pnlGenerateHashButton = new System.Windows.Forms.Panel();
			this.btnGenerateHash = new System.Windows.Forms.Button();
			this.panelSep = new System.Windows.Forms.Panel();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.pnlFileHasher = new System.Windows.Forms.Panel();
			this.panelHashingAlgorithmSelection = new System.Windows.Forms.Panel();
			this.btnSelectHashingAlgorithm = new System.Windows.Forms.Button();
			this.cmbbxHashingAlgorithm = new System.Windows.Forms.ComboBox();
			this.pnlFilePath = new System.Windows.Forms.Panel();
			this.txtBoxFilePath = new System.Windows.Forms.TextBox();
			this.btnFilePath = new System.Windows.Forms.Button();
			this.pnlFileHasherHeading = new System.Windows.Forms.Panel();
			this.lblFileHasher = new System.Windows.Forms.Label();
			this.HashersTabContorl = new System.Windows.Forms.TabControl();
			this.FileHasherTab.SuspendLayout();
			this.pnlGenerateHash.SuspendLayout();
			this.pnlGenerateHashButton.SuspendLayout();
			this.pnlFileHasher.SuspendLayout();
			this.panelHashingAlgorithmSelection.SuspendLayout();
			this.pnlFilePath.SuspendLayout();
			this.pnlFileHasherHeading.SuspendLayout();
			this.HashersTabContorl.SuspendLayout();
			this.SuspendLayout();
			// 
			// FileHasherTab
			// 
			this.FileHasherTab.Controls.Add(this.pnlGenerateHash);
			this.FileHasherTab.Controls.Add(this.pnlFileHasher);
			this.FileHasherTab.Controls.Add(this.pnlFileHasherHeading);
			this.FileHasherTab.Location = new System.Drawing.Point(4, 25);
			this.FileHasherTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.FileHasherTab.Name = "FileHasherTab";
			this.FileHasherTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.FileHasherTab.Size = new System.Drawing.Size(792, 474);
			this.FileHasherTab.TabIndex = 0;
			this.FileHasherTab.Text = "File Hasher";
			this.FileHasherTab.UseVisualStyleBackColor = true;
			// 
			// pnlGenerateHash
			// 
			this.pnlGenerateHash.Controls.Add(this.pnlGenerateHashButton);
			this.pnlGenerateHash.Controls.Add(this.panelSep);
			this.pnlGenerateHash.Controls.Add(this.richTextBoxLog);
			this.pnlGenerateHash.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGenerateHash.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlGenerateHash.Location = new System.Drawing.Point(3, 213);
			this.pnlGenerateHash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlGenerateHash.Name = "pnlGenerateHash";
			this.pnlGenerateHash.Size = new System.Drawing.Size(786, 259);
			this.pnlGenerateHash.TabIndex = 3;
			// 
			// pnlGenerateHashButton
			// 
			this.pnlGenerateHashButton.Controls.Add(this.btnGenerateHash);
			this.pnlGenerateHashButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlGenerateHashButton.Location = new System.Drawing.Point(0, 118);
			this.pnlGenerateHashButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlGenerateHashButton.Name = "pnlGenerateHashButton";
			this.pnlGenerateHashButton.Size = new System.Drawing.Size(786, 70);
			this.pnlGenerateHashButton.TabIndex = 5;
			// 
			// btnGenerateHash
			// 
			this.btnGenerateHash.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenerateHash.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGenerateHash.Location = new System.Drawing.Point(0, 0);
			this.btnGenerateHash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnGenerateHash.Name = "btnGenerateHash";
			this.btnGenerateHash.Size = new System.Drawing.Size(786, 70);
			this.btnGenerateHash.TabIndex = 4;
			this.btnGenerateHash.Text = "Generate Hash";
			this.btnGenerateHash.UseVisualStyleBackColor = true;
			this.btnGenerateHash.Click += new System.EventHandler(this.btnGenerateHash_Click);
			// 
			// panelSep
			// 
			this.panelSep.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelSep.Location = new System.Drawing.Point(0, 188);
			this.panelSep.Name = "panelSep";
			this.panelSep.Size = new System.Drawing.Size(786, 21);
			this.panelSep.TabIndex = 7;
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxLog.Location = new System.Drawing.Point(0, 209);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ReadOnly = true;
			this.richTextBoxLog.Size = new System.Drawing.Size(786, 50);
			this.richTextBoxLog.TabIndex = 6;
			this.richTextBoxLog.Text = "";
			// 
			// pnlFileHasher
			// 
			this.pnlFileHasher.Controls.Add(this.panelHashingAlgorithmSelection);
			this.pnlFileHasher.Controls.Add(this.pnlFilePath);
			this.pnlFileHasher.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFileHasher.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlFileHasher.Location = new System.Drawing.Point(3, 70);
			this.pnlFileHasher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFileHasher.Name = "pnlFileHasher";
			this.pnlFileHasher.Size = new System.Drawing.Size(786, 143);
			this.pnlFileHasher.TabIndex = 1;
			// 
			// panelHashingAlgorithmSelection
			// 
			this.panelHashingAlgorithmSelection.Controls.Add(this.btnSelectHashingAlgorithm);
			this.panelHashingAlgorithmSelection.Controls.Add(this.cmbbxHashingAlgorithm);
			this.panelHashingAlgorithmSelection.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHashingAlgorithmSelection.Location = new System.Drawing.Point(0, 70);
			this.panelHashingAlgorithmSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panelHashingAlgorithmSelection.Name = "panelHashingAlgorithmSelection";
			this.panelHashingAlgorithmSelection.Size = new System.Drawing.Size(786, 70);
			this.panelHashingAlgorithmSelection.TabIndex = 5;
			// 
			// btnSelectHashingAlgorithm
			// 
			this.btnSelectHashingAlgorithm.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelectHashingAlgorithm.Location = new System.Drawing.Point(0, 0);
			this.btnSelectHashingAlgorithm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSelectHashingAlgorithm.Name = "btnSelectHashingAlgorithm";
			this.btnSelectHashingAlgorithm.Size = new System.Drawing.Size(167, 70);
			this.btnSelectHashingAlgorithm.TabIndex = 4;
			this.btnSelectHashingAlgorithm.Text = "Hashing Algorithm";
			this.btnSelectHashingAlgorithm.UseVisualStyleBackColor = true;
			// 
			// cmbbxHashingAlgorithm
			// 
			this.cmbbxHashingAlgorithm.DropDownHeight = 100;
			this.cmbbxHashingAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbxHashingAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbbxHashingAlgorithm.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbbxHashingAlgorithm.IntegralHeight = false;
			this.cmbbxHashingAlgorithm.Location = new System.Drawing.Point(192, 25);
			this.cmbbxHashingAlgorithm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbbxHashingAlgorithm.Name = "cmbbxHashingAlgorithm";
			this.cmbbxHashingAlgorithm.Size = new System.Drawing.Size(568, 26);
			this.cmbbxHashingAlgorithm.Sorted = true;
			this.cmbbxHashingAlgorithm.TabIndex = 3;
			this.cmbbxHashingAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbbxHashingAlgorithm_SelectedIndexChanged);
			// 
			// pnlFilePath
			// 
			this.pnlFilePath.Controls.Add(this.txtBoxFilePath);
			this.pnlFilePath.Controls.Add(this.btnFilePath);
			this.pnlFilePath.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFilePath.Location = new System.Drawing.Point(0, 0);
			this.pnlFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFilePath.Name = "pnlFilePath";
			this.pnlFilePath.Size = new System.Drawing.Size(786, 70);
			this.pnlFilePath.TabIndex = 4;
			// 
			// txtBoxFilePath
			// 
			this.txtBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtBoxFilePath.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxFilePath.Location = new System.Drawing.Point(167, 0);
			this.txtBoxFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtBoxFilePath.Multiline = true;
			this.txtBoxFilePath.Name = "txtBoxFilePath";
			this.txtBoxFilePath.ReadOnly = true;
			this.txtBoxFilePath.Size = new System.Drawing.Size(619, 70);
			this.txtBoxFilePath.TabIndex = 1;
			// 
			// btnFilePath
			// 
			this.btnFilePath.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFilePath.Location = new System.Drawing.Point(0, 0);
			this.btnFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnFilePath.Name = "btnFilePath";
			this.btnFilePath.Size = new System.Drawing.Size(167, 70);
			this.btnFilePath.TabIndex = 2;
			this.btnFilePath.Text = "File Path";
			this.btnFilePath.UseVisualStyleBackColor = true;
			this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
			// 
			// pnlFileHasherHeading
			// 
			this.pnlFileHasherHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFileHasherHeading.Controls.Add(this.lblFileHasher);
			this.pnlFileHasherHeading.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFileHasherHeading.Location = new System.Drawing.Point(3, 2);
			this.pnlFileHasherHeading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFileHasherHeading.Name = "pnlFileHasherHeading";
			this.pnlFileHasherHeading.Size = new System.Drawing.Size(786, 68);
			this.pnlFileHasherHeading.TabIndex = 2;
			// 
			// lblFileHasher
			// 
			this.lblFileHasher.AutoSize = true;
			this.lblFileHasher.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFileHasher.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFileHasher.Location = new System.Drawing.Point(0, 0);
			this.lblFileHasher.Name = "lblFileHasher";
			this.lblFileHasher.Size = new System.Drawing.Size(269, 56);
			this.lblFileHasher.TabIndex = 1;
			this.lblFileHasher.Text = "File Hasher";
			// 
			// HashersTabContorl
			// 
			this.HashersTabContorl.Controls.Add(this.FileHasherTab);
			this.HashersTabContorl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HashersTabContorl.Location = new System.Drawing.Point(0, 0);
			this.HashersTabContorl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.HashersTabContorl.Name = "HashersTabContorl";
			this.HashersTabContorl.SelectedIndex = 0;
			this.HashersTabContorl.Size = new System.Drawing.Size(800, 503);
			this.HashersTabContorl.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnGenerateHash;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 503);
			this.Controls.Add(this.HashersTabContorl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hasher";
			this.FileHasherTab.ResumeLayout(false);
			this.pnlGenerateHash.ResumeLayout(false);
			this.pnlGenerateHashButton.ResumeLayout(false);
			this.pnlFileHasher.ResumeLayout(false);
			this.panelHashingAlgorithmSelection.ResumeLayout(false);
			this.pnlFilePath.ResumeLayout(false);
			this.pnlFilePath.PerformLayout();
			this.pnlFileHasherHeading.ResumeLayout(false);
			this.pnlFileHasherHeading.PerformLayout();
			this.HashersTabContorl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage FileHasherTab;
		private System.Windows.Forms.Panel pnlGenerateHash;
		private System.Windows.Forms.Panel pnlGenerateHashButton;
		private System.Windows.Forms.Button btnGenerateHash;
		private System.Windows.Forms.Panel pnlFileHasher;
		private System.Windows.Forms.Panel panelHashingAlgorithmSelection;
		private System.Windows.Forms.Button btnSelectHashingAlgorithm;
		private System.Windows.Forms.ComboBox cmbbxHashingAlgorithm;
		private System.Windows.Forms.Panel pnlFilePath;
		private System.Windows.Forms.TextBox txtBoxFilePath;
		private System.Windows.Forms.Button btnFilePath;
		private System.Windows.Forms.Panel pnlFileHasherHeading;
		private System.Windows.Forms.Label lblFileHasher;
		private System.Windows.Forms.TabControl HashersTabContorl;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.Panel panelSep;
	}
}

