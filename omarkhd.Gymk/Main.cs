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
				StartLoader loader = new StartLoader();
				loader.SuccessEvent += delegate()
				{
					Window w = new GymkWindow();
					w.ShowAll();
				};
				
				loader.Start();
				Application.Run();
			}
			
			AppHelper.Clean();
		}
	}
}

