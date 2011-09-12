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
			this.CustomBuild();
		}
		
		private void CustomBuild()
		{
			this.Title = "omarkhd's GymK";
			
			this.HeaderImage.Pixbuf = new Gdk.Pixbuf(null, "header.png");
			
			SessionRegistry r = SessionRegistry.GetInstance();
			string msg = (string) r["user_name"] + ((bool) r["user_is_admin"] ? " [Administrador]" : "");
			this.StatusInfo.Push(0, msg);
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
			this.ClientsAction.Activated += this.LaunchClients;
			this.ConfigAction.Activated += this.LaunchPreferences;
			this.MembersAction.Activated += this.LaunchMembers;
		}
		
		private void Quit(object sender, object args)
		{
			AppHelper.Log("quitting application");
			Application.Quit();
		}
		
		private void NewEnrollment(object sender, EventArgs args)
		{
			MemberWizard ww = new MemberWizard();
			
			ww.SuccessEvent += (object o) =>
			{
				Member m = (Member) o;
				Client c = m.InnerClient;
				ClientModel cm = new ClientModel();
				MemberModel mm = new MemberModel();
				
				///adding the new client if needed
				if(c.Id == -1) //-1 = new client
				{
					cm.Insert(c);
					c.Id = cm.LastInsertId;
				}
				
				//add the contact info
				if(m.InnerContact.Name.Length > 0)
				{
					DbModel contact_m = new DbModel("Contact");
					contact_m.Insert(null, m.InnerContact.Name, m.InnerContact.PhoneNumber);
					m.InnerContact.Id = contact_m.LastInsertId;
				}
				
				//adding the member
				m.Id = c.Id;
				mm.Insert(m);				
				
				//adding the membership debt
				if(m.ChargeMembership)
				{
					DbModel mship_m = new DbModel("MembershipDebt");
					mship_m.Insert(m.Id, null);
				}
				
				PaymentRuler.ChargeFirstMonth(m);
			};
			
			ww.Run();
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
		
		private void LaunchClients(object sender, EventArgs args)
		{
			ClientsWindow w = new ClientsWindow();
			w.Modal = true;
			w.TransientFor = this;
			w.ShowAll();
		}
		
		private void LaunchMembers(object sender, EventArgs args)
		{
			MembersWindow w = new MembersWindow();
			w.Modal = true;
			w.TransientFor = this;
			w.ShowAll();
		}
	}
}