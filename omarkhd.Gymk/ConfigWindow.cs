using System;
using Gtk;

namespace omarkhd.Gymk
{
	public partial class ConfigWindow : Gtk.Window
	{
		public ConfigWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.CustomBuild();
			this.Init();
			this.Connect();
			this.Modal = true;
		}
		
		private void Init()
		{
			this.InitUsers();
		}
		
		private void InitUsers()
		{
			//users
			this.UsersNodeView.Sensitive = true;
			this.EditButton.Sensitive = false;
			this.OkButton.Sensitive = false;
			this.CancelButton.Sensitive = false;
			this.AliasEntry.Sensitive = false;
			this.AdminCheckBox.Sensitive = false;
			this.ActiveCheckBox.Sensitive = false;
			this.PasswordButton.Sensitive = false;
			this.AccessButton.Sensitive = false;
			this.NameEntry.Sensitive = false;
			this.AddButton.Sensitive = true;
			
			this.FillNodeView();
		}
		
		private void Connect()
		{
			//users
			this.AddButton.Clicked += this.DoAdd;
			this.CancelButton.Clicked += this.DoCancel;
			this.OkButton.Clicked += this.DoOk;
		}
		
		private void CustomBuild()
		{
			string[] labels = new string[] { "General", "Pagos", "Usuarios" };
			string[] images = new string[] { "opt_general.png", "opt_payments.png", "opt_users.png" };
			
			//creating beautiful tabs :D
			for(int i = 0; i < labels.Length; i++)
			{
				VBox nb_vbox = new VBox();
				nb_vbox.WidthRequest = 60;
				Image img = new Image(null, images[i]);
				Label lbl = new Label(labels[i]);
				nb_vbox.PackStart(img);
				nb_vbox.PackStart(lbl);			
				this.notebook1.SetTabLabel(this.notebook1.GetNthPage(i), nb_vbox);
				nb_vbox.ShowAll();
			}
			
			this.UsersNodeView.AppendColumn("Usuario", new CellRendererText(), "text", 0);
		}
		
		private void FillNodeView()
		{
			NodeStore store = new NodeStore(typeof(User));
			User u = null;
			UserModel model = new UserModel();
			System.Data.IDataReader reader = model.GetAll();
			
			while(reader.Read())
			{
				u = new User();
				u.Id = (long) reader["Id"];
				u.Name = (string) reader["Name"];
				u.Alias = (string) reader["Alias"];	
				u.Password = (string) reader["Password"];
				u.Active = (bool) reader["Active"];
				u.Admin = (bool) reader["Admin"];				
				
				store.AddNode(u);
			}
			
			this.UsersNodeView.NodeStore = store;
			this.UsersNodeView.ShowAll();
		}
		
		private void DoAdd(object sender, EventArgs args)
		{
			this.AdminCheckBox.Sensitive = true;
			this.ActiveCheckBox.Sensitive = true;
			this.NameEntry.Sensitive = true;
			this.PasswordButton.Sensitive = true;
			this.AliasEntry.Sensitive = true;
			this.AddButton.Sensitive = false;
			this.OkButton.Sensitive = true;
			this.CancelButton.Sensitive = true;
		}
		
		private void DoCancel(object sender, EventArgs args)
		{
			this.InitUsers();	
		}		
		
		private void DoOk(object sender, EventArgs args)
		{
			User user = new User();
			user.Active = this.ActiveCheckBox.Active;
			user.Admin = this.AdminCheckBox.Active;
			user.Alias = this.AliasEntry.Text.Trim();
			user.Name = this.NameEntry.Text.Trim();
			string password_string = "fija";
			user.Password = HashHelper.GetMd5Of(password_string);
			
			UserModel model = new UserModel();
			model.Insert(user);
		}
	}
}

