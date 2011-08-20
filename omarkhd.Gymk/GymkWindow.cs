using System;
using Gtk;

namespace omarkhd.Gymk
{
	public partial class GymkWindow : Gtk.Window
	{
		public GymkWindow () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.Connect();
			this.Title = "omarkhd's GymK";
		}
		
		private void Connect()
		{
			//this method connects all the signals to
			//their respective gui elements			
			this.DeleteEvent += this.Quit;
			this.NewEnrollmentAction.Activated += this.NewEnrollment;
			this.NewClientAction.Activated += this.NewClient;
			this.QuitAction.Activated += this.Quit;
			this.AreasAction.Activated += this.LaunchAreas;
			this.PacksAction.Activated += this.LaunchPacks;
			this.ConfigAction.Activated += this.LaunchPreferences;
		}
		
		private void Quit(object sender, object args)
		{
			AppHelper.Log("quitting application");
			Application.Quit();
		}
		
		private void NewEnrollment(object sender, EventArgs args)
		{
			MemberWizard cw = new MemberWizard();
			cw.Run();
		}
		
		private void NewClient(object sender, EventArgs args)
		{
			ClientWizard w = new ClientWizard();
			w.SuccessEvent += (object c) =>
			{
				Client client = (Client) c;
				ClientModel client_m = new ClientModel();
				bool success = client_m.Insert(client);
				if(!success)
					GuiHelper.ShowError(w, "No se pudo completar la operación debido a un error interno");
			};
			
			w.Run();
		}
		
		private void LaunchPreferences(object sender, EventArgs args)
		{
			ConfigWindow conf = new ConfigWindow();
			conf.TransientFor = this;
			conf.ShowAll();
		}
		
		private void LaunchAreas(object sender, EventArgs args)
		{
			AreasWindow w = new AreasWindow();
			w.Modal = true;
			w.TransientFor = this;
			w.ShowAll();
		}
		
		private void LaunchPacks(object sender, EventArgs args)
		{
			PacksWindow w = new PacksWindow();
			w.Modal = true;
			w.TransientFor = this;
			w.ShowAll();
		}
	}
}