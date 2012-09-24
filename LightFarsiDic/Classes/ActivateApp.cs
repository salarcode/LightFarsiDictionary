using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LightFarsiDictionary.Classes
{
	class ActivateApp
	{

		// Sets the window to be foreground
		[DllImport("User32")]
		private static extern int SetForegroundWindow(IntPtr hwnd);

		// Activate or minimize a window
		[DllImport("User32.DLL")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		private const int SW_SHOW = 5;
		private const int SW_MINIMIZE = 6;
		private const int SW_RESTORE = 9;

		public static void ActivateApplication(string briefAppName)
		{
			Process[] procList = Process.GetProcessesByName(briefAppName);

			if (procList.Length > 0)
			{
				ShowWindow(procList[0].MainWindowHandle, SW_RESTORE);
				SetForegroundWindow(procList[0].MainWindowHandle);
			}
		}
		public static void ActivateApplication()
		{
			var prc = Process.GetCurrentProcess();

			ShowWindow(prc.MainWindowHandle, SW_RESTORE);
			SetForegroundWindow(prc.MainWindowHandle);
		}

	}
}
