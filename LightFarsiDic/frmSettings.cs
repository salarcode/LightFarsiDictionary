using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LightFarsiDictionary.Properties;

namespace LightFarsiDictionary
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Settings.Default.KeyboardTextToSpeech = chkTextToSpeech.Checked;
			Settings.Default.SendToSysTray = chkSystray.Checked;
			Settings.Default.KeyboardShortcut = chkKeyboardHook.Checked;
			Settings.Default.Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			chkTextToSpeech.Checked = Settings.Default.KeyboardTextToSpeech;
			chkSystray.Checked = Settings.Default.SendToSysTray;
			chkKeyboardHook.Checked = Settings.Default.KeyboardShortcut;

		}
	}
}
