using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LightFarsiDictionary
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ThreadException += Application_ThreadException;
			Application.Run(new frmMain());
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}
}