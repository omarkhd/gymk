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
			
			Window w = new GymkWindow();
			w.ShowAll();			
			
			Application.Run();
			AppHelper.Clean();
		}
	}
}

