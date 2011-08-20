using System;
using Gtk;

namespace omarkhd.Gymk
{
	public static class GuiHelper
	{
		public static void ShowMessage(string msg)
		{
			GuiHelper.ShowMessage(null, "", msg, false);
		}
		
		public static void ShowMessage(string title, string msg)
		{
			GuiHelper.ShowMessage(null, title, msg, false);
		}
		
		public static void ShowMessage(Window parent, string msg)
		{
			GuiHelper.ShowMessage(parent, "", msg, false);
		}
		
		public static void ShowMessage(Window parent, string title, string msg)
		{
			GuiHelper.ShowMessage(parent, title, msg, false);
		}
		
		public static void ShowMessage(Window parent, string title, string msg, bool error)
		{
			MessageType type = (error ? MessageType.Error : MessageType.Info);
			MessageDialog dlg = new MessageDialog
			(
				parent,
				DialogFlags.Modal,
				type,
				ButtonsType.Ok,
				null
			);
			
			dlg.Title = title;
			dlg.Text = msg;
			if(parent == null)
				dlg.WindowPosition = WindowPosition.Mouse;
				
			dlg.Opacity = 0.95;
			//dlg.Deletable = false;
			
			//AppHelper.Log("launching message dialog" + (parent != null ? " con parent" :  ""));
			dlg.Run();
			//AppHelper.Log("destroying message dialog");
			dlg.Destroy();
		}
		
		public static void ShowError(string error)
		{
			GuiHelper.ShowMessage(null, "", error, true);
		}
		
		public static void ShowError(string title, string error)
		{
			GuiHelper.ShowMessage(null, title, error, true);
		}
		
		public static void ShowError(Window parent, string error)
		{
			GuiHelper.ShowMessage(parent, "", error, true);
		}
		
		public static void ShowError(Window parent, string title, string error)
		{
			GuiHelper.ShowMessage(parent, title, error, true);
		}
		
		public static void ShowUnexpectedError(Window parent)
		{
			SessionRegistry r = SessionRegistry.GetInstance();
			string error = "Este error es producto de un fallo en el sistema o en la configuración del mismo, favor de contactarme.";
			error += "\n" + r["author"] + " <" + r["author_contact"] + ">";
			string title = "Error inesperado";
			GuiHelper.ShowMessage(parent, title, error, true);
		}
	}
}
