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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnSay = new System.Windows.Forms.Button();
			this.txtMeaning = new System.Windows.Forms.TextBox();
			this.lblExactWord = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblSite = new System.Windows.Forms.LinkLabel();
			this.lnkSources = new System.Windows.Forms.LinkLabel();
			this.txtWord = new LightFarsiDictionary.Controls.ucTextManualComplete();
			this.SuspendLayout();
			// 
			// btnSay
			// 
			this.btnSay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSay.Image = global::LightFarsiDictionary.Properties.Resources.Say16;
			this.btnSay.Location = new System.Drawing.Point(282, 29);
			this.btnSay.Name = "btnSay";
			this.btnSay.Size = new System.Drawing.Size(40, 21);
			this.btnSay.TabIndex = 2;
			this.btnSay.UseVisualStyleBackColor = true;
			this.btnSay.Click += new System.EventHandler(this.btnSay_Click);
			this.btnSay.MouseEnter += new System.EventHandler(this.btnSay_MouseEnter);
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
			this.txtMeaning.Size = new System.Drawing.Size(310, 160);
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
			this.lblExactWord.Size = new System.Drawing.Size(251, 14);
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
			this.label2.Location = new System.Drawing.Point(265, 53);
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
			// txtWord
			// 
			this.txtWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtWord.AutoPerformComplete = true;
			this.txtWord.BackColor = System.Drawing.Color.Transparent;
			this.txtWord.Location = new System.Drawing.Point(12, 29);
			this.txtWord.Name = "txtWord";
			this.txtWord.Size = new System.Drawing.Size(264, 21);
			this.txtWord.SuggestionVisible = false;
			this.txtWord.TabIndex = 1;
			this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 251);
			this.Controls.Add(this.txtWord);
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
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
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
	}
}