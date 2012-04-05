namespace LightFarsiDictionary.Controls
{
	partial class ucTextManualComplete
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtText = new System.Windows.Forms.TextBox();
			this.lstSuggest = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// txtText
			// 
			this.txtText.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtText.Location = new System.Drawing.Point(0, 0);
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(247, 20);
			this.txtText.TabIndex = 0;
			this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
			this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyDown);
			this.txtText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtText_KeyPress);
			// 
			// lstSuggest
			// 
			this.lstSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSuggest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstSuggest.FormattingEnabled = true;
			this.lstSuggest.Location = new System.Drawing.Point(0, 20);
			this.lstSuggest.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.lstSuggest.Name = "lstSuggest";
			this.lstSuggest.Size = new System.Drawing.Size(247, 109);
			this.lstSuggest.TabIndex = 1;
			this.lstSuggest.Click += new System.EventHandler(this.lstSuggest_Click);
			this.lstSuggest.SelectedIndexChanged += new System.EventHandler(this.lstSuggest_SelectedIndexChanged);
			this.lstSuggest.VisibleChanged += new System.EventHandler(this.lstSuggest_VisibleChanged);
			this.lstSuggest.DoubleClick += new System.EventHandler(this.lstSuggest_DoubleClick);
			this.lstSuggest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSuggest_KeyDown);
			this.lstSuggest.Leave += new System.EventHandler(this.lstSuggest_Leave);
			// 
			// ucTextManualComplete
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.lstSuggest);
			this.Controls.Add(this.txtText);
			this.Name = "ucTextManualComplete";
			this.Size = new System.Drawing.Size(247, 129);
			this.Load += new System.EventHandler(this.ucTextManualComplete_Load);
			this.Leave += new System.EventHandler(this.ucTextManualComplete_Leave);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.ListBox lstSuggest;

	}
}
