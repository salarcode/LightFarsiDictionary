using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheBigBrother.Keylogger;

namespace LightFarsiDictionary.KeySniff
{
	class KeyboardActivation
	{
		private static int _lastKeys = 0;
		public static bool HookKeyboardProccess(Keys key, KeyboardHook.KeyState keystate)
		{

			bool action = false;
			if (key == Keys.Control ||
				(int)key == 162 ||
				(int)key == 163)
			{
				_lastKeys = 1;
			}
			else if (key == Keys.C)
			{
				if (keystate == KeyboardHook.KeyState.KeyDown)
					return false;

				if (_lastKeys == 1)
				{
					_lastKeys = 2;
				}
				else if (_lastKeys == 2)
				{
					_lastKeys = 0;
					action = true;
				}
				else
				{
					_lastKeys = 0;
				}
			}
			else
			{
				_lastKeys = 0;
			}
			return action;
		}

	}
}
