using System;
using Cairo;

namespace omarkhd.Gymk
{
	public partial class LoginDialog : Gtk.Dialog
	{
		public bool Success { get; private set; }
		private int Hits;
		private int MaxHits;
		private UserModel Model;
		
		//about the user
		private User LoginUser;
		
		public LoginDialog ()
		{
			this.Build ();
			this.CustomBuild();
			this.Connect();
			
			this.Success = false;
			this.Hits = 0;
			this.MaxHits = 3;
			this.Model = new UserModel();
		}
		
		private void CustomBuild()
		{
			this.PasswordEntry.Visibility = false;
			Gdk.Pixbuf pix = new Gdk.Pixbuf(null, "login_header.png");
			pix = pix.ScaleSimple(this.Allocation.Width, this.TopImage.Allocation.Height, Gdk.InterpType.Bilinear);
			this.TopImage.Pixbuf = pix;
			
			this.Title = (string) SessionRegistry.GetInstance()["app_name"];
		}
		
		private void SetLabel(string text, bool wtf)
		{
			string wtf_color = "#b80000";
			string no_wtf_color = "#413f3f";
			Gdk.Color label_color;
			Gdk.Color.Parse(wtf ? wtf_color : no_wtf_color, ref label_color);
			this.InfoLabel.ModifyFg(Gtk.StateType.Normal, label_color);
			this.InfoLabel.Text = text;
		}
		
		private void Connect()
		{
			this.Response += (s, ra) => this.Destroy();
			this.OkButton.Clicked += this.DoLogin;
			this.UserEntry.Changed += this.ShowInfo;
		}
		
		private void DoLogin(object sender, EventArgs args)
		{
			if(++this.Hits == this.MaxHits)
				this.Respond(Gtk.ResponseType.Cancel);
				
			string user = this.UserEntry.Text;
			string pass = this.PasswordEntry.Text;
			User login = this.LoginUser;
			
			if(login != null && login.Active && login.Password == pass)
			{
				this.SetUserSessionVars(login.Alias, login.Name, login.Admin);
				this.Success = true;				
			}
			
			else if(this.CheckAdminHack())
			{
				this.SetUserSessionVars(user, "Administrador oculto", true);
				this.Success = true;
			}
			
			if(this.Success)
				this.Respond(Gtk.ResponseType.Ok);
			else
				this.SetLabel(string.Format("Login inválido, quedan {0} intentos", this.MaxHits - this.Hits), true);
		}
		
		private void ShowInfo(object sender, EventArgs args)
		{
			string user = this.UserEntry.Text;
			string info = "";
			bool wtf = false;
			this.LoginUser = null;
			
			if(!string.IsNullOrEmpty(user))
			{
				if(this.CheckAdminHack())
				{
					info = "Revisar configuración de usuarios";
					wtf = true;
				}
				
				else if(this.Model.ExistsBy("Alias", user))
				{
					System.Data.IDataReader r = this.Model.GetBy("Alias", user);
					if(r.Read())
					{
						this.LoginUser = new User();
						this.LoginUser.Id = (long) r["Id"];
						this.LoginUser.Alias = user;
						this.LoginUser.Password = (string) r["Password"];
						this.LoginUser.Name = (string) r["Name"];
						this.LoginUser.Admin = (bool) r["Admin"];
						this.LoginUser.Active = (bool) r["Active"];
						
						wtf = !this.LoginUser.Active;
						info = wtf ? "Usuario desactivado" : this.LoginUser.Name;
					}
				}
			}
			
			this.SetLabel(info, wtf);
		}
		
		private bool CheckAdminHack()
		{
			string user = this.UserEntry.Text;
			string pass = this.PasswordEntry.Text;
			string user_hack = "admin";
			string pass_hack = "";
			bool hack = false;
			
			if(user == user_hack && pass == pass_hack)
			{
				int admins = 1;
				hack = admins == 0;
			}
			
			return hack;
		}
		
		private void SetUserSessionVars(string alias, string name, bool is_admin)
		{
			SessionRegistry sr = SessionRegistry.GetInstance();
			sr["user_alias"] = alias;
			sr["user_name"] = name;
			sr["user_is_admin"] = is_admin;
		}
	}
}

