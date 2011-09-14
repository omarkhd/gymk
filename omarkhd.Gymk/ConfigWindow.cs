using System;
using Gtk;

namespace omarkhd.Gymk
{
	public partial class ConfigWindow : Gtk.Window
	{
		private User CurrentUser;
		private CrudState CrudOp;
		private string OldPassword;
		private string NewPassword;
		private bool ChangePassword;
		
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
			this.InitGral();
			this.InitPayment();
			
			this.InitUsers();
			this.CrudOp = CrudState.None;
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
			this.NewPassword = "";
			this.OldPassword = "";
			
			SessionRegistry r = SessionRegistry.GetInstance();
			this.AddButton.Sensitive = (bool) r["user_is_admin"];
			
			this.CleanUserForm();
			this.FillNodeView();
		}
		
		private void InitGral()
		{
			DbRegister register = DbRegister.GetInstance();
			
			this.GymNameEntry.Text = (string) register["gym_name"];
			this.GymAddressEntry.Text = (string) register["gym_address"];
			this.GymPhoneEntry.Text = (string) register["gym_phone"];
			this.OwnerNameEntry.Text = (string) register["owner_name"];
			this.OwnerPhoneEntry.Text = (string) register["owner_phone"];
			this.OwnerEmailEntry.Text = (string) register["owner_email"];
		}
		
		private void InitPayment()
		{
			DbRegister register = DbRegister.GetInstance();
			
			this.DelayChargeSpin.Value = (float) register["delay_charge"];
			this.SaturdayCheck.Active = (bool) register["delay_saturday"];
			this.SundayCheck.Active = (bool) register["delay_sunday"];
		}
		
		private void CleanUserForm()
		{
			this.AliasEntry.Text = "";
			this.AdminCheckBox.Active = false;
			this.ActiveCheckBox.Active = false;
			this.NameEntry.Text = "";
		}
		
		private void Connect()
		{
			//users
			this.AddButton.Clicked += this.DoAdd;
			this.CancelButton.Clicked += this.DoCancel;
			this.OkButton.Clicked += this.DoOk;
			this.UsersNodeView.CursorChanged += this.SelectCurrent;
			this.EditButton.Clicked += this.DoEdit;
			this.PasswordButton.Clicked += this.DoChangePassword;
			this.SavePaymentButton.Clicked += this.DoPaymentsOk;
			this.SaveGralButton.Clicked += this.DoGralOk;
			this.Close1Button.Clicked += (s, a) => this.Destroy();
			this.Close2Button.Clicked += (s, a) => this.Destroy();
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
		
		private void UsersEditMode()
		{
			this.AdminCheckBox.Sensitive = true;
			this.ActiveCheckBox.Sensitive = true;
			this.NameEntry.Sensitive = true;
			this.PasswordButton.Sensitive = true;
			this.AliasEntry.Sensitive = true;
			this.AddButton.Sensitive = false;
			this.OkButton.Sensitive = true;
			this.CancelButton.Sensitive = true;
			this.EditButton.Sensitive = false;
			this.UsersNodeView.Sensitive = false;
			this.OldPassword = "";
			this.NewPassword = "";
		}
		
		private void DoAdd(object sender, EventArgs args)
		{
			this.CleanUserForm();
			this.UsersEditMode();
			this.CrudOp = CrudState.Create;
		}
		
		private void DoCancel(object sender, EventArgs args)
		{
			this.InitUsers();	
			this.CrudOp = CrudState.None;
		}		
		
		private void DoOk(object sender, EventArgs args)
		{
			UserModel model = new UserModel();
			
			if(this.CrudOp == CrudState.Create)
			{
				User user = new User();
				user.Active = this.ActiveCheckBox.Active;
				user.Admin = this.AdminCheckBox.Active;
				user.Alias = this.AliasEntry.Text.Trim();
				user.Name = this.NameEntry.Text.Trim();
				user.Password = HashHelper.GetMd5Of(this.NewPassword);
				
				if(model.Insert(user))
				{
					this.CurrentUser = user;
					this.CurrentUser.Id = model.LastInsertId;
				}
			}
			
			else if(this.CrudOp == CrudState.Update)
			{
				User u = this.CurrentUser;
				User to = new User();
				to.Alias = this.AliasEntry.Text;
				to.Active = this.ActiveCheckBox.Active;
				to.Admin = this.AdminCheckBox.Active;
				to.Name = this.NameEntry.Text;
				
				if(to.Admin != u.Admin)
					model.UpdateById(u.Id, "Admin", to.Admin);
				if(to.Active != u.Active)
					model.UpdateById(u.Id, "Active", to.Active);
				if(to.Alias != u.Alias)
					model.UpdateById(u.Id, "Alias", to.Alias);
				if(to.Name != u.Name)
					model.UpdateById(u.Id, "Name", to.Name);
				
				if(this.ChangePassword)
				{
					SessionRegistry r = SessionRegistry.GetInstance();
					long sess_id = (long) r["user_id"];
					bool can_change = false;
				
					if(sess_id != u.Id)
						can_change = true;
					else
					{
						string old_md5 = HashHelper.GetMd5Of(this.OldPassword);
						if(old_md5 == u.Password)
							can_change = true;						
					}
					
					if(can_change)
					{
						string new_md5 = HashHelper.GetMd5Of(this.NewPassword);
						if(new_md5 != u.Password)
							model.UpdateById(u.Id, "Password", new_md5);
					}
					
					else
						GuiHelper.ShowMessage(this, "No se pudo cambiar la contraseña");
				}
			}
			
			this.InitUsers();
			this.SelectUser(this.CurrentUser);
		}
		
		private void SelectCurrent(object sender, EventArgs args)
		{
			SessionRegistry r = SessionRegistry.GetInstance();
			if(((bool) r["user_is_admin"]))
				this.EditButton.Sensitive = true;
				
			User user = (User) this.UsersNodeView.NodeSelection.SelectedNode;
			this.CurrentUser = user;
			this.AdminCheckBox.Active = user.Admin;
			this.ActiveCheckBox.Active = user.Active;
			this.AliasEntry.Text = user.Alias;
			this.NameEntry.Text = user.Name;
		}
		
		private void DoEdit(object sender, EventArgs args)
		{
			this.ChangePassword = false;
			this.CrudOp = CrudState.Update;
			this.UsersEditMode();
		}
		
		private void SelectUser(User u)
		{
			NodeStore store = this.UsersNodeView.NodeStore;
			TreeNode node = null;
			bool found = false;
			
			for(int i = 0; ; i++)
			{
				TreePath path = new TreePath(i.ToString());
				node = (TreeNode) store.GetNode(path);
				User temp = (User) node;
				
				if(temp == null)
					break;
					
				else if(temp.Id == u.Id)
				{
					found = true;
					break;
				}
			}
						
			if(found)
			{
				this.UsersNodeView.NodeSelection.SelectNode(node);
				this.UsersNodeView.HasFocus = true;
			}
		}
		
		private void DoChangePassword(object sender, EventArgs args)
		{
			this.ChangePassword = false;
			
			SessionRegistry r = SessionRegistry.GetInstance();
			bool is_self = this.CurrentUser != null ? ((long) r["user_id"]) == this.CurrentUser.Id : false;
			NewPasswordDialog dlg = new NewPasswordDialog(is_self);
			this.ChangePassword = ((Gtk.ResponseType) dlg.Run()) == ResponseType.Ok;
			
			this.OldPassword = dlg.Old;
			this.NewPassword = dlg.New;
		}
		
		private void DoPaymentsOk(object sender, EventArgs args)
		{
			DbRegister register = DbRegister.GetInstance();
			register["delay_charge"] = string.Format("{0:0.00}", this.DelayChargeSpin.Value);
			register["delay_saturday"] = this.SaturdayCheck.Active;
			register["delay_sunday"] = this.SundayCheck.Active;
			this.Destroy();	
		}
		
		private void DoGralOk(object sender, EventArgs args)
		{
			DbRegister register = DbRegister.GetInstance();
			register["gym_name"] = this.GymNameEntry.Text;
			register["gym_address"] = this.GymAddressEntry.Text;
			register["gym_phone"] = this.GymPhoneEntry.Text;
			register["owner_name"] = this.OwnerNameEntry.Text;
			register["owner_phone"] = this.OwnerPhoneEntry.Text;
			register["owner_email"] = this.OwnerEmailEntry.Text;
			
			this.Destroy();
		}
	}
}

