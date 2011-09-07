using System;
using System.Data;
using Gtk;

namespace omarkhd.Gymk
{
	public partial class MembersWindow : Gtk.Window
	{
		private DateWidget BirthdayWidget;
		private DateWidget SinceWidget;
		private Client CurrentClient;
		private string LastDir;
		private byte[] ImageToSave;
		
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
			/*this.HeightSpin.SetRange(1, 2.5);
			this.HeightSpin.SetIncrements(0.01, 0.01);
			this.WeightSpin.SetRange(40, 200);
			this.WeightSpin.SetIncrements(0.01, 0.01);*/
			this.PhotoButton.FocusOnClick = false;
			
			this.GenderCombo.AppendText("Masculino");
			this.GenderCombo.AppendText("Femenino");
			
			PackModel pm = new PackModel();
			IDataReader reader = pm.GetAll();
			while(reader.Read())
				this.PackCombo.AppendText((string) reader["Name"]);
			
			//columns for the nodeview
			this.MembersNodeView.AppendColumn("Id", new CellRendererText(), "text", 0);
			this.MembersNodeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);
		}
		
		private void Connect()
		{
			this.SearchEntry.Changed += this.DoSearch;
			this.MembersNodeView.CursorChanged += this.SelectCurrent;
			this.EditButton.Clicked += this.DoEdit;
			this.CancelButton.Clicked += this.DoCancel;
			this.OkButton.Clicked += this.DoOk;
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
			this.SearchEntry.Sensitive = true;
			
			this.IdLabel.Text = "0000";
			this.ActiveCheck.Sensitive = false;
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
		
		private void ClearForm()
		{
			this.IdLabel.Text = "0000";
			this.ActiveCheck.Active = false;
			this.WeightSpin.Text = "";
			this.HeightSpin.Text = "";
			this.GenderCombo.Active = 0;
			this.BirthdayWidget.Date = DateTime.Today;
			this.ContactNameEntry.Text = "";
			this.ContactPhoneEntry.Text = "";
			this.PackCombo.Active = 0;
			this.SinceWidget.Date = DateTime.Today;
			this.PaymentDaySpin.Text = "";
			this.NameEntry.Text = "";
			this.SurnameEntry.Text = "";
			this.AddressEntry.Text = "";
			this.PhoneEntry.Text = "";
			this.EmailEntry.Text = "";
			
			Widget[] widgets = this.PhotoButton.Children;
			foreach(Widget w in widgets)
				this.PhotoButton.Remove(w);
			this.PhotoButton.Label = "Click para seleccionar";
			this.PhotoButton.Relief = ReliefStyle.Normal;
			this.PhotoButton.Sensitive = false;
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
				c.PhoneNumber = (string) reader["PhoneNumber"];
				c.Email = (string) reader["Email"];				
				
				store.AddNode(c);
			}
			
			this.MembersNodeView.NodeStore = store;
			this.MembersNodeView.ShowAll();
		}
		
		private void DoSearch(object sender, EventArgs args)
		{
			this.ClearForm();
			string like = this.SearchEntry.Text.Trim();
			MemberModel model = new MemberModel();
			this.FillNodeView(model.GetAllWithJoinLike(like));
			this.EditButton.Sensitive = false;
		}
		
		private void SelectCurrent(object sender, EventArgs args)
		{
			this.ClearForm();
			this.PhotoButton.Sensitive = true;
			this.PhotoButton.Relief = ReliefStyle.None;
			//default client info
			Client c = (Client) this.MembersNodeView.NodeSelection.SelectedNode;	
			this.CurrentClient = c;
			Member m = new Member();
			m.Id = c.Id;
			m.Sync();
			c = m.InnerClient;			
			
			//client info
			this.ActiveCheck.Active = m.Active;
			this.IdLabel.Text = c.Id.ToString("0000");
			this.NameEntry.Text = c.Name;
			this.SurnameEntry.Text = c.Surname;
			this.AddressEntry.Text = c.Address;
			this.PhoneEntry.Text = c.PhoneNumber;
			this.EmailEntry.Text = c.Email;
			
			//member info
			this.WeightSpin.Value = m.Weight;	
			this.HeightSpin.Value = m.Height;
			this.GenderCombo.Active = m.Gender == 'm' ? 0 : 1;
			this.BirthdayWidget.Date = m.BirthDate;
			this.ContactNameEntry.Text = !string.IsNullOrEmpty(m.InnerContact.Name) ? m.InnerContact.Name : "";
			this.ContactPhoneEntry.Text = !string.IsNullOrEmpty(m.InnerContact.PhoneNumber) ? m.InnerContact.PhoneNumber : "";
			if(m.BinImage != null && m.BinImage.Length > 0)
			{
				foreach(Widget widget in this.PhotoButton.Children)
					this.PhotoButton.Remove(widget);
					
				int h = this.PhotoButton.Allocation.Height;
				int w = this.PhotoButton.Allocation.Width;
				Gdk.Pixbuf pixbuf = new Gdk.Pixbuf(m.BinImage);
				
				double x_scale = (double) w / pixbuf.Width;
				double y_scale = (double) h / pixbuf.Height;
				double scale = Math.Min(x_scale, y_scale);
				pixbuf = pixbuf.ScaleSimple((int) (pixbuf.Width * scale), (int) (pixbuf.Height * scale), Gdk.InterpType.Bilinear);
				this.PhotoButton.Add(new Gtk.Image(pixbuf));
				this.PhotoButton.ShowAll();
			}
			
			//payment info
			this.PaymentDaySpin.Value = m.PaymentDay;
			this.SinceWidget.Date = m.JoinDate;
			PackModel pm = new PackModel();
			IDataReader reader = pm.GetById(m.Pack);
			if(reader.Read())
			{
				string name = (string) reader["Name"];
				long packs = pm.Count();
				for(int i = 0; i < packs; i++)
				{
					this.PackCombo.Active = i;
					string text = this.PackCombo.ActiveText;
					if(name == text)
						break;
				}
			}
						
			//conf
			this.EditButton.Sensitive = true;
		} 
		
		private void DoOk(object sender, EventArgs args)
		{
			Member m = new Member();
			m.Id = this.CurrentClient.Id;
			m.Sync();
			MemberModel mm = new MemberModel();
			
			if(m.Active != this.ActiveCheck.Active)
				mm.Update(m, "Active", this.ActiveCheck.Active);
				
			if(this.ImageToSave != null && this.ImageToSave.Length != m.BinImage.Length)
			{
				m.BinImage = this.ImageToSave;
				mm.SetImage(m);
			}
			
			if(m.Weight != this.WeightSpin.Value)
				mm.Update(m, "Weight", this.WeightSpin.Value);
				
			if(m.Height != this.HeightSpin.Value)
				mm.Update(m, "Height", this.HeightSpin.Value);
				
			char ctrl_gender = this.GenderCombo.Active == 0 ? 'm' : 'f';
			if(m.Gender != ctrl_gender)
				mm.Update(m, "Gender", ctrl_gender);
				
			if(m.BirthDate.CompareTo(this.BirthdayWidget.Date) != 0)
				mm.Update(m, "BirthDate", this.BirthdayWidget.Date.ToString("yyyy-MM-dd"));
			
			if(m.InnerContact.Id == 0 && !string.IsNullOrEmpty(this.ContactNameEntry.Text.Trim() + this.ContactPhoneEntry.Text.Trim()))
			{
				DbModel model = new DbModel("Contact");
				model.Insert(null, this.ContactNameEntry.Text.Trim(), this.ContactPhoneEntry.Text.Trim());
				long last = model.LastInsertId;
				mm.Update(m, "Contact", last);
			}
			
			else if(m.InnerContact.Name != this.ContactNameEntry.Text || m.InnerContact.PhoneNumber != this.ContactPhoneEntry.Text)
			{
				DbModel model = new DbModel("Contact");
				model.UpdateById(m.InnerContact.Id, "Name", this.ContactNameEntry.Text.Trim());
				model.UpdateById(m.InnerContact.Id, "PhoneNumber", this.ContactPhoneEntry.Text.Trim());
			}
			
			Client c = m.InnerClient;
			ClientModel cm = new ClientModel();
			if(c.Name != this.NameEntry.Text)
				cm.Update(c, "Name", this.NameEntry.Text.Trim());
				
			if(c.Surname != this.SurnameEntry.Text)
				cm.Update(c, "Surname", this.SurnameEntry.Text.Trim());
				
			if(c.Address != this.AddressEntry.Text)
				cm.Update(c, "Address", this.AddressEntry.Text.Trim());
				
			omarkhd.Validation.Validator v = new omarkhd.Validation.Validator();
			v.SetRule(this.PhoneEntry.Text, "phone", omarkhd.Validation.ValidationRule.Natural);				
			if(c.PhoneNumber != this.PhoneEntry.Text && v.Run().Status)
				cm.Update(c, "PhoneNumber", this.PhoneEntry.Text.Trim());
				
			v = new omarkhd.Validation.Validator();
			v.SetRule(this.EmailEntry.Text, "email", omarkhd.Validation.ValidationRule.Email);				
				
			if(c.Email != this.EmailEntry.Text && v.Run().Status)
				cm.Update(c, "Email", this.EmailEntry.Text.Trim());
				
			this.DoCancel(null, null);
		}
		
		private void DoEdit(object sender, EventArgs args)
		{
			//preparing
			this.SearchEntry.Sensitive = false;	
			this.MembersNodeView.Sensitive = false;
			this.EditButton.Sensitive = false;
			this.PhotoButton.Relief = ReliefStyle.Normal;
			this.OkButton.Sensitive = true;
			this.CancelButton.Sensitive = true;
			
			//connect-the-photo-button workaround
			this.PhotoButton.Clicked += this.ChoosePicture;
			
			//enabling controls
			this.ActiveCheck.Sensitive = true;
			this.WeightSpin.Sensitive = true;
			this.HeightSpin.Sensitive = true;
			this.GenderCombo.Sensitive = true;
			this.BirthdayBox.Sensitive = true;
			this.ContactNameEntry.Sensitive = true;
			this.ContactPhoneEntry.Sensitive = true;
			this.NameEntry.Sensitive = true;
			this.SurnameEntry.Sensitive = true;
			this.AddressEntry.Sensitive = true;
			this.PhoneEntry.Sensitive = true;
			this.EmailEntry.Sensitive = true;
		}
		
		private void DoCancel(object sender, EventArgs args)
		{
			this.PhotoButton.Clicked -= this.ChoosePicture;
			this.Init();
			this.SelectClient(this.CurrentClient);
		}
		
		private void SelectClient(Client c)
		{
			NodeStore store = this.MembersNodeView.NodeStore;
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
				this.MembersNodeView.NodeSelection.SelectNode(node);
				this.MembersNodeView.HasFocus = true;
			}
		}
		
		private void ChoosePicture(object sender, EventArgs args)
		{
			bool ok = false;
			string title = "Escoja la fotografía";
			string file_name = null;
			string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			if(!string.IsNullOrEmpty(this.LastDir))
				folder = new System.IO.FileInfo(this.LastDir).DirectoryName;
			
			if(AppHelper.Windows)
			{
				System.Windows.Forms.Application.EnableVisualStyles();
				System.Windows.Forms.OpenFileDialog dialog;
				dialog = new System.Windows.Forms.OpenFileDialog();
				dialog.Title = title;
				dialog.ShowReadOnly = true;
				dialog.Multiselect = false;
				dialog.Filter = "Archivos de imagen|*.jpg; *.jpeg; *.png";
				dialog.InitialDirectory = folder;
				System.Windows.Forms.DialogResult dr = dialog.ShowDialog();
				
				if(dr == System.Windows.Forms.DialogResult.OK)
				{
					ok = true;
					file_name = dialog.FileName;
				}
			}
			
			else
			{
				FileChooserDialog dialog = new FileChooserDialog
				(
					title, 
					this,
					FileChooserAction.Open,
					"Cancelar", ResponseType.Cancel,
					"Abrir", ResponseType.Accept
				);
				
				FileFilter filter = new FileFilter();
				filter.Name = "Archivos de imagen";
				filter.AddPattern("*.jpg");
				filter.AddPattern("*.jpeg");
				filter.AddPattern("*.png");
				
				dialog.SelectMultiple = false;
				dialog.AddFilter(filter);
				dialog.SetCurrentFolder(folder);
				ResponseType dr = (ResponseType) dialog.Run();
				if(dr == ResponseType.Accept)
				{
					ok = true;
					file_name = dialog.Filename;
				}
				
				dialog.Destroy();
			}
			
			if(ok)
			{
				this.LastDir = file_name;
				try
				{
					int w = this.PhotoButton.Allocation.Width;
					int h = this.PhotoButton.Allocation.Height;
					this.ImageToSave = new Gdk.Pixbuf(file_name, w, h, true).SaveToBuffer("png");
					//this.TargetMember.BinImage = pixbuf.SaveToBuffer("png");
					this.LoadImage();
				}
				
				catch(GLib.GException)
				{
					GuiHelper.ShowMessage("Esta versión de Gtk# no soporta este tipo de archivos, puede añadir la imagen más tarde si desea");
				}
			}
		}
		
		private void LoadImage()
		{
			if(this.ImageToSave == null || this.ImageToSave.Length == 0)
				return;
				
			Gdk.Pixbuf pixbuf = new Gdk.Pixbuf(this.ImageToSave);
			foreach(Widget w in this.PhotoButton.Children)
				this.PhotoButton.Remove(w);
			this.PhotoButton.Add(new Gtk.Image(pixbuf));
			this.PhotoButton.ShowAll();
		}
		
	}
}

