using System;
using TheCodeKing.Net.Messaging;

namespace LightFarsiDictionary
{
	public class PrcMessaging
	{
		private const string channel = "LightFarsiDictionary";

		public const string Cmd_ShowUp = "ShowUp";

		private static IXDListener _listener;
		private static IXDBroadcast _broadcast;
		public static void StartPrcMessaging()
		{
			if (_broadcast != null)
				return;
			_broadcast = XDBroadcast.CreateBroadcast(XDTransportMode.WindowsMessaging, false);
			_listener = XDListener.CreateListener(XDTransportMode.WindowsMessaging);
			_listener.MessageReceived += Listener_MessageReceived;
			_listener.RegisterChannel(channel);
		}


		static void Listener_MessageReceived(object sender, XDMessageEventArgs e)
		{
			if (e.DataGram.Channel != channel)
				return;
			try
			{
				ProcessCommand(e.DataGram.Message);
			}
			catch { }
		}

		private static void ProcessCommand(string cmd)
		{
			switch (cmd)
			{
				case Cmd_ShowUp:
					Program.ShowUp();
					break;
			}
		}

		public static void SendCommand(string cmd)
		{
			_broadcast.SendToChannel(channel, cmd);
		}
		public static void SendCommandAsync(string cmd)
		{
			new Action<string>(SendCommand).BeginInvoke(cmd, null, null);
		}
	}
}
