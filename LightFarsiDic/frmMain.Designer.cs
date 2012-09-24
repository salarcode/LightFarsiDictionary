namespace LightFarsiDictionary
{
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.txtMeaning = new System.Windows.Forms.TextBox();
			this.lblExactWord = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblSite = new System.Windows.Forms.LinkLabel();
			this.lnkSources = new System.Windows.Forms.LinkLabel();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnSay = new System.Windows.Forms.Button();
			this.sysIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.mnuSystray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.txtWord = new LightFarsiDictionary.Controls.ucTextManualComplete();
			this.mnuSystray.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtMeaning
			// 
			this.txtMeaning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMeaning.Location = new System.Drawing.Point(12, 69);
			this.txtMeaning.Multiline = true;
			this.txtMeaning.Name = "txtMeaning";
			this.txtMeaning.ReadOnly = true;
			this.txtMeaning.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtMeaning.Size = new System.Drawing.Size(313, 160);
			this.txtMeaning.TabIndex = 5;
			// 
			// lblExactWord
			// 
			this.lblExactWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblExactWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblExactWord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblExactWord.Location = new System.Drawing.Point(14, 53);
			this.lblExactWord.Name = "lblExactWord";
			this.lblExactWord.ReadOnly = true;
			this.lblExactWord.Size = new System.Drawing.Size(254, 14);
			this.lblExactWord.TabIndex = 3;
			this.lblExactWord.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "لغت انگلیسی/فارسی را وارد کنید";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(268, 53);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "معنی لغت:";
			// 
			// lblSite
			// 
			this.lblSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSite.AutoSize = true;
			this.lblSite.Location = new System.Drawing.Point(12, 232);
			this.lblSite.Name = "lblSite";
			this.lblSite.Size = new System.Drawing.Size(76, 13);
			this.lblSite.TabIndex = 6;
			this.lblSite.TabStop = true;
			this.lblSite.Text = "salarcode.com";
			this.lblSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSite_LinkClicked);
			// 
			// lnkSources
			// 
			this.lnkSources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lnkSources.AutoSize = true;
			this.lnkSources.Location = new System.Drawing.Point(86, 232);
			this.lnkSources.Name = "lnkSources";
			this.lnkSources.Size = new System.Drawing.Size(67, 13);
			this.lnkSources.TabIndex = 6;
			this.lnkSources.TabStop = true;
			this.lnkSources.Text = "open-source";
			this.lnkSources.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSources_LinkClicked);
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSettings.Image = global::LightFarsiDictionary.Properties.Resources.settings;
			this.btnSettings.Location = new System.Drawing.Point(280, 28);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(45, 23);
			this.btnSettings.TabIndex = 2;
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			this.btnSettings.MouseEnter += new System.EventHandler(this.btnSay_MouseEnter);
			// 
			// btnSay
			// 
			this.btnSay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSay.Image = global::LightFarsiDictionary.Properties.Resources.Say16;
			this.btnSay.Location = new System.Drawing.Point(229, 28);
			this.btnSay.Name = "btnSay";
			this.btnSay.Size = new System.Drawing.Size(45, 23);
			this.btnSay.TabIndex = 2;
			this.btnSay.UseVisualStyleBackColor = true;
			this.btnSay.Click += new System.EventHandler(this.btnSay_Click);
			this.btnSay.MouseEnter += new System.EventHandler(this.btnSay_MouseEnter);
			// 
			// sysIcon
			// 
			this.sysIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.sysIcon.BalloonTipText = "از اینجا به دیکشنری دسترسی خواهید داشت";
			this.sysIcon.ContextMenuStrip = this.mnuSystray;
			this.sysIcon.Text = "English to Farsi / Farsi to English";
			this.sysIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sysIcon_MouseUp);
			// 
			// mnuSystray
			// 
			this.mnuSystray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow,
            this.mnuExit});
			this.mnuSystray.Name = "mnuSystray";
			this.mnuSystray.Size = new System.Drawing.Size(127, 48);
			// 
			// mnuShow
			// 
			this.mnuShow.Name = "mnuShow";
			this.mnuShow.Size = new System.Drawing.Size(126, 22);
			this.mnuShow.Text = "نمایش فرم";
			this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(126, 22);
			this.mnuExit.Text = "خروج";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// txtWord
			// 
			this.txtWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtWord.AutoPerformComplete = true;
			this.txtWord.BackColor = System.Drawing.Color.Transparent;
			this.txtWord.Location = new System.Drawing.Point(12, 29);
			this.txtWord.Name = "txtWord";
			this.txtWord.Size = new System.Drawing.Size(211, 21);
			this.txtWord.SuggestionVisible = false;
			this.txtWord.TabIndex = 1;
			this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(337, 251);
			this.Controls.Add(this.txtWord);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnSay);
			this.Controls.Add(this.txtMeaning);
			this.Controls.Add(this.lblExactWord);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lnkSources);
			this.Controls.Add(this.lblSite);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "English to Farsi / Farsi to English";
			this.Activated += new System.EventHandler(this.frmMain_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
			this.mnuSystray.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.ucTextManualComplete txtWord;
		private System.Windows.Forms.Button btnSay;
		private System.Windows.Forms.TextBox txtMeaning;
		private System.Windows.Forms.TextBox lblExactWord;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel lblSite;
		private System.Windows.Forms.LinkLabel lnkSources;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.NotifyIcon sysIcon;
		private System.Windows.Forms.ContextMenuStrip mnuSystray;
		private System.Windows.Forms.ToolStripMenuItem mnuShow;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
	}
}