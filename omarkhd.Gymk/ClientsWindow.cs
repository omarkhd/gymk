using System;
using Gtk;
using System.Data;

namespace omarkhd.Gymk
{
	public partial class ClientsWindow : Gtk.Window
	{
		private Client CurrentClient;
		
		public ClientsWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.CustomBuild();
			this.Connect();
			this.Init();	
		}
		
		private void Init()
		{
			this.SearchEntry.Sensitive = true;
			this.EditButton.Sensitive = false;
			this.DeleteButton.Sensitive = false;
			this.OkButton.Sensitive = false;
			this.CancelButton.Sensitive = false;
			this.NameEntry.Sensitive = false;
			this.SurnameEntry.Sensitive = false;
			this.AddressEntry.Sensitive = false;
			this.PhoneEntry.Sensitive = false;
			this.EmailEntry.Sensitive = false;
			
			this.CleanForm();
			
			ClientModel m = new ClientModel();
			this.FillNodeView(m.GetAllLike(this.SearchEntry.Text));
			this.ClientsNodeView.Sensitive = true;
		}
		
		private void CleanForm()
		{
			this.NameEntry.Text = "";
			this.SurnameEntry.Text = "";
			this.AddressEntry.Text = "";
			this.PhoneEntry.Text = "";
			this.EmailEntry.Text = "";
			this.IdLabel.Text = "0000";
		}
		
		private void CustomBuild()
		{	
			this.ClientsNodeView.AppendColumn("Id", new CellRendererText(), "text", 0);
			this.ClientsNodeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);
		}
		
		private void Connect()
		{
			this.ClientsNodeView.CursorChanged += this.SelectCurrent;
			this.ClientsNodeView.RowActivated += this.DoEdit;
			this.EditButton.Clicked += this.DoEdit;
			this.CancelButton.Clicked += this.DoCancel;
			this.SearchEntry.Changed += this.DoSearch;
			this.OkButton.Clicked += this.DoOk;
		}
		
		private void FillNodeView()
		{
			ClientModel model = new ClientModel();
			this.FillNodeView(model.GetAll());
		}
		
		private void FillNodeView(IDataReader reader)
		{
			NodeStore store = new NodeStore(typeof(Client));
			Client c = null;
			
			while(reader.Read())
			{
				c = new Client();
				c.Id = (long) reader["Id"];
				c.Name = (string) reader["Name"];
				c.Surname = (string) reader["Surname"];	
				c.Address = (string) reader["Address"];
				decimal pn = (decimal) reader["PhoneNumber"];
				c.PhoneNumber = (pn == 0 ? "" : pn.ToString());
				c.Email = (string) reader["Email"];
				store.AddNode(c);
			}
			
			this.ClientsNodeView.NodeStore = store;
			this.ClientsNodeView.ShowAll();
		}
		
		private void SelectCurrent(object sender, EventArgs args)
		{
			this.CurrentClient = (Client) this.ClientsNodeView.NodeSelection.SelectedNode;	
			Client c = this.CurrentClient;
			this.IdLabel.Text = c.Id.ToString("X4");
			this.NameEntry.Text = c.Name;
			this.SurnameEntry.Text = c.Surname;
			this.AddressEntry.Text = c.Address;
			this.PhoneEntry.Text = c.PhoneNumber;
			this.EmailEntry.Text = c.Email;
			this.EditButton.Sensitive = true;
		}
		
		private void DoEdit(object sender, EventArgs args)
		{
			this.EditButton.Sensitive = false;
			this.OkButton.Sensitive = true;
			this.CancelButton.Sensitive = true;
			
			this.NameEntry.Sensitive = true;
			this.SurnameEntry.Sensitive = true;
			this.AddressEntry.Sensitive = true;
			this.PhoneEntry.Sensitive = true;
			this.EmailEntry.Sensitive = true;
			
			this.NameEntry.HasFocus = true;
			this.ClientsNodeView.Sensitive = false;
			this.SearchEntry.Sensitive = false;
		}
		
		private void DoCancel(object sender, EventArgs args)
		{
			this.Init();
			this.SelectClient(this.CurrentClient);
		}
		
		private void SelectClient(Client c)
		{
			NodeStore store = this.ClientsNodeView.NodeStore;
			TreeNode node = null;
			bool found = false;
			
			for(int i = 0; ; i++)
			{
				TreePath path = new TreePath(i.ToString());
				node = (TreeNode) store.GetNode(path);
				Client temp = (Client) node;
				
				if(temp == null)
					break;
					
				else if(temp.Id == c.Id)
				{
					found = true;
					break;
				}
			}
						
			if(found)
			{
				this.ClientsNodeView.NodeSelection.SelectNode(node);
				this.ClientsNodeView.HasFocus = true;
			}
		}
		
		private void DoSearch(object sender, EventArgs args)
		{
			string like = this.SearchEntry.Text;
			ClientModel model = new ClientModel();
			this.FillNodeView(model.GetAllLike(like));
			this.CleanForm();
			this.EditButton.Sensitive = false;
		}
		
		private void DoOk(object sender, EventArgs args)
		{
			Client c = this.CurrentClient;
			c.Name = this.NameEntry.Text;
			c.Surname = this.SurnameEntry.Text;
			c.Address = this.AddressEntry.Text;
			c.PhoneNumber = this.PhoneEntry.Text;
			c.Email = this.EmailEntry.Text;
			
			ClientModel model = new ClientModel();
			if(!model.Update(c))
			{
				GuiHelper.ShowError(this, "Ha ocurrido un error en la actualización del cliente");
				return;
			}
			
			this.Init();
			this.SelectClient(this.CurrentClient);
		}
	}
}

