namespace LightFarsiDictionary
{
	partial class frmSettings
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkTextToSpeech = new System.Windows.Forms.CheckBox();
			this.chkKeyboardHook = new System.Windows.Forms.CheckBox();
			this.chkSystray = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkTextToSpeech);
			this.groupBox1.Controls.Add(this.chkKeyboardHook);
			this.groupBox1.Controls.Add(this.chkSystray);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(302, 112);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "تنظیمات";
			// 
			// chkTextToSpeech
			// 
			this.chkTextToSpeech.AutoSize = true;
			this.chkTextToSpeech.Location = new System.Drawing.Point(119, 75);
			this.chkTextToSpeech.Name = "chkTextToSpeech";
			this.chkTextToSpeech.Size = new System.Drawing.Size(158, 17);
			this.chkTextToSpeech.TabIndex = 0;
			this.chkTextToSpeech.Text = "تلفظ لغاط با فشردن کلید F12";
			this.chkTextToSpeech.UseVisualStyleBackColor = true;
			// 
			// chkKeyboardHook
			// 
			this.chkKeyboardHook.AutoSize = true;
			this.chkKeyboardHook.Location = new System.Drawing.Point(37, 52);
			this.chkKeyboardHook.Name = "chkKeyboardHook";
			this.chkKeyboardHook.Size = new System.Drawing.Size(240, 17);
			this.chkKeyboardHook.TabIndex = 0;
			this.chkKeyboardHook.Text = "نمایش لغات از حافظه با فشردن کلید Ctrl+C+C";
			this.chkKeyboardHook.UseVisualStyleBackColor = true;
			// 
			// chkSystray
			// 
			this.chkSystray.AutoSize = true;
			this.chkSystray.Location = new System.Drawing.Point(82, 29);
			this.chkSystray.Name = "chkSystray";
			this.chkSystray.Size = new System.Drawing.Size(195, 17);
			this.chkSystray.TabIndex = 0;
			this.chkSystray.Text = "ارسال به تسکبار به جای بستن برنامه";
			this.chkSystray.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(93, 131);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "تایید";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(12, 131);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "انصراف";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(327, 165);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettings";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "تنظیمات";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox chkTextToSpeech;
		private System.Windows.Forms.CheckBox chkKeyboardHook;
		private System.Windows.Forms.CheckBox chkSystray;
	}
}