using System;
using System.Resources;
using Gtk;

namespace omarkhd.Gymk
{
	class MainClass
	{
		public static void Main(string[] args) //
		{
			AppHelper.Init();
			Application.Init();
			
			LoginDialog login = new LoginDialog();
			login.Run();
			
			if(login.Success)
			{				
				Window w = new GymkWindow();
				w.ShowAll();			
				Application.Run();
			}
			
			AppHelper.Clean();
		}
	}
}

