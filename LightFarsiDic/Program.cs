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
			if (!IsAnotherInstanceRunning(Application.ProductName))
			{
				WarmUpTheDatabase();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				PrcMessaging.StartPrcMessaging();
				_mainForm = new frmMain();
				Application.Run(_mainForm);
			}
			else
			{
				PrcMessaging.StartPrcMessaging();
				PrcMessaging.SendCommand(PrcMessaging.Cmd_ShowUp);
			}
		}

		static frmMain _mainForm;
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

		private static Mutex _mutex;
		internal static bool IsAnotherInstanceRunning(string name)
		{
			// code to ensure that only one copy of the software is running.
			try
			{
				_mutex = Mutex.OpenExisting(name);
				return true;
			}
			catch
			{
				try
				{
					//since we didn’t find a mutex with that name, create one
					_mutex = new Mutex(true, name);
				}
				catch (Exception)
				{
					// So, the mutex is already open but it is not accesable!
					return true;
				}
			}
			return false;
		}

		public static void ShowUp()
		{
			if (_mainForm == null)
				return;
			_mainForm.WindowState = FormWindowState.Normal;
			_mainForm.Show();
			_mainForm.Activate();
		}
	}
}