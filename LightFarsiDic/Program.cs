using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using LightFarsiDic.Database.Entities;

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
			Application.ThreadException += Application_ThreadException;
			WarmUpTheDatabase();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}

		internal static IAsyncResult _warmUp;
		/// <summary>
		/// 
		/// </summary>
		static void WarmUpTheDatabase()
		{
			_warmUp = new Action(
				() =>
				{
					try
					{
						dicenfaSession.OpenStatelessSession().Dispose();
					}
					catch
					{
					}
					_warmUp = null;
				})
				.BeginInvoke(null, null);
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.ToString(), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}
}