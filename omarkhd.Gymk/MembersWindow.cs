using System;
using System.Data;
using Gtk;

namespace omarkhd.Gymk
{
	public partial class MembersWindow : Gtk.Window
	{
		private DateWidget BirthdayWidget;
		private DateWidget SinceWidget;
		
		public MembersWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.CustomBuild();
			this.Connect();
			this.Init();
		}
		
		private void CustomBuild()
		{
			this.BirthdayWidget = new DateWidget();
			this.SinceWidget = new DateWidget();
			
			this.BirthdayBox.Add(this.BirthdayWidget.Box);
			this.SinceBox.Add(this.SinceWidget.Box);
			
			//configuring some ui elements
			this.HeightSpin.SetRange(40, 200);
			this.HeightSpin.SetIncrements(0.01, 0.01);
			
			this.GenderCombo.AppendText("Masculino");
			this.GenderCombo.AppendText("Femenino");
			
			//columns for the nodeview
			this.MembersNodeView.AppendColumn("Id", new CellRendererText(), "text", 0);
			this.MembersNodeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);
		}
		
		private void Connect()
		{
			this.SearchEntry.Changed += this.DoSearch;
			this.MembersNodeView.CursorChanged += this.SelectCurrent;
		}
		
		private void Init()
		{
			//control buttons
			this.EditButton.Sensitive = false;
			this.DeleteButton.Sensitive = false;
			this.OkButton.Sensitive = false;
			this.CancelButton.Sensitive = false;
			
			//data controls
			this.MembersNodeView.Sensitive = true;
			
			this.IdLabel.Text = "0000";
			this.PhotoButton.Sensitive = false;
			this.WeightSpin.Sensitive = false;
			this.HeightSpin.Sensitive = false;
			this.GenderCombo.Sensitive = false;
			this.BirthdayBox.Sensitive = false;
			this.ContactNameEntry.Sensitive = false;
			this.ContactPhoneEntry.Sensitive = false;
			
			this.PackCombo.Sensitive = false;
			this.SinceBox.Sensitive = false;
			this.PaymentDaySpin.Sensitive = false;
			
			this.NameEntry.Sensitive = false;
			this.SurnameEntry.Sensitive = false;
			this.AddressEntry.Sensitive = false;
			this.PhoneEntry.Sensitive = false;
			this.EmailEntry.Sensitive = false;
			
			//filling the gap
			this.DoSearch(null, null);
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
			
			this.MembersNodeView.NodeStore = store;
			this.MembersNodeView.ShowAll();
		}
		
		private void DoSearch(object sender, EventArgs args)
		{
			string like = this.SearchEntry.Text.Trim();
			MemberModel model = new MemberModel();
			this.FillNodeView(model.GetAllWithJoinLike(like));
			//this.CleanForm();
			this.EditButton.Sensitive = false;
		}
		
		private void SelectCurrent(object sender, EventArgs args)
		{
			//default client info
			Client c = (Client) this.MembersNodeView.NodeSelection.SelectedNode;	
			Member m = new Member();
			m.Id = c.Id;
			m.Sync();
			c = m.InnerClient;			
			
			this.IdLabel.Text = c.Id.ToString("0000");
			this.NameEntry.Text = c.Name;
			this.SurnameEntry.Text = c.Surname;
			this.AddressEntry.Text = c.Address;
			this.PhoneEntry.Text = c.PhoneNumber;
			this.EmailEntry.Text = c.Email;
			
			//payment info
			this.WeightSpin.Value = m.Weight;	
			this.HeightSpin.Value = m.Height;
			this.GenderCombo.Active = m.Gender == 'm' ? 0 : 1;
			this.BirthdayWidget.Date = m.BirthDate;
			
			Console.Out.WriteLine(m.InnerContact);
			
			//conf
			this.EditButton.Sensitive = true;
		} 
	}
}

