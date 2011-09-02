using System;
using System.Data;
using Gtk;
using Gdk;
using Mono.Data.Sqlite;

namespace omarkhd.Gymk
{
	public class MemberWizard : Wizard
	{
		private int Step;
		
		//controls
		private RadioButton NewClientButton;
		private RadioButton ExistingClientButton;
		private RadioButton ClientByIdButton;
		private RadioButton ClientSearchButton;
		
		private Button ImageButton;
		
		//info entities
		private Member TargetMember;
		private long ClientId;
		
		//needed vars
		private bool MemberInitialized = false;
		private string LastDir;
		
		public MemberWizard()
		{
			SessionRegistry r = SessionRegistry.GetInstance();
			string gym = (string) r["gym_name"];
			this.WelcomeHeader = "Bienvenido al asistente de inscripción " + (gym == null ? "al gimnasio" : "a " + gym);
			this.NextEvent += this.OnNext;
			this.PreviousEvent += this.OnPrevious;
			this.Step = 0;
			this.TargetMember = new Member();
			this.SidebarImage = "w2.png";
			this.ClientId = 0;
		}
		
		private void OnNext()
		{
			this.GoTo(++this.Step);
			//this.GoTo(4);
		}
		
		private void OnPrevious()
		{
			this.GoTo(--this.Step);
		}
		
		private void GoTo(int step)
		{
			switch(step)
			{
				case 0:
					this.Init();
					break;
					
				case 1:
					this.AskForClient();
					break;
					
				case 2:
					this.ChooseClient();
					break;
					
				case 3:
					this.MemberInfo();
					break;
					
				case 4:
					this.Photo();
					break;
					
				case 5:
					this.Payment();
					break;
					
				case 6:
					this.Summary();
					break;
					
				case 7:
					this.Complete();
					break;
			}
		}
		
		private void CheckPacks()
		{
			PackModel pm = new PackModel();
			if(pm.Count() == 0)
			{
				GuiHelper.ShowError("Para poder inscribir algún miembro, se necesita tener al menos un paquete de cobro");
				this.Destroy();
			}
		}
		
		private void AskForClient() //step 1
		{
			this.CheckPacks();
			//config
			this.Header = "";
			this.Description = "¿Es un cliente existente, o se creará uno nuevo?";
			this.CanGoPrevious = true;
			
			//go!
			this.ClearContentBox();
			
			this.NewClientButton = new RadioButton(null, "Crear nuevo cliente");
			this.ExistingClientButton = new RadioButton(this.NewClientButton, "Usar un cliente existente");
			
			this.PackWidgetSingle(this.ExistingClientButton);
			this.PackWidgetSingle(this.NewClientButton);
			this.ContentVBox.ShowAll();
		}
		
		private void ChooseClient() //step 2
		{
			//this means that the user has completed this step once, 
			//and that she wants to choose if create or use existing client once more
			if(this.TargetMember.InnerClient != null)
			{
				this.TargetMember.InnerClient = null;
				this.OnPrevious();
				return;
			}
			
			bool new_client = this.NewClientButton.Active;
			if(new_client)
			{
				ClientWizard cw = new ClientWizard();
				cw.SuccessEvent += (object target) => 
				{
					this.TargetMember.InnerClient = (Client) target;
					this.OnNext();
				};
				
				cw.CancelEvent += () => this.Step -= 1;
				
				cw.TransientFor = this;
				cw.Run();
			}
			
			else
			{
				this.Description = "Elija un método para seleccionar al cliente que será nuevo miembro del gimnasio";
				this.ClearContentBox();
				
				this.ClientByIdButton = new RadioButton(null, "Id de usuario:");
				this.ClientSearchButton = new RadioButton(this.ClientByIdButton, "Buscar manualmente");
				
				Button test_button= new Button("Comprobar");
				SpinButton id_spin = new SpinButton(0, 5000, 1);
				id_spin.Value = this.ClientId;
				id_spin.TooltipText = "Número de cliente";
				Button search_button = new Button("Clientes...");
				Label empty_label = new Label(" ");
				Label empty_label2 = new Label(" ");
				
				Label info_label = new Label();
				
				this.PackWidgetSingle(this.ClientByIdButton);
				this.PackWidgetPair(id_spin, test_button, true);
				this.PackWidgetSingle(this.ClientSearchButton);
				this.PackWidgetPair(empty_label, search_button, true);
				this.PackWidgetSingle(empty_label2);
				this.PackWidgetSingle(new HSeparator());
				this.PackWidgetSingle(info_label);
				
				//connecting local buttons
				this.ClientByIdButton.Clicked += (object sender, EventArgs args) =>
				{
					bool state = this.ClientByIdButton.Active;
					id_spin.Sensitive = state;
					test_button.Sensitive = state;
					search_button.Sensitive = !state;
				};
				
				id_spin.Changed += (object sender, EventArgs args) => 
				{
					int id;
					this.ClientId = (int.TryParse(id_spin.Text, out id) ? id : id_spin.ValueAsInt);
					//this.ClientId = id_spin.ValueAsInt;
				};
				
				id_spin.Value = this.ClientId;
				
				test_button.Clicked += (object sender, EventArgs args) =>
				{
					long id = this.ClientId;
					ClientModel m = new ClientModel();
					if(m.ExistsById(id))
					{
						IDataReader r = m.GetById(id);
						r.Read();
						Client c = new Client();
						c.Id = id;
						c.Name = (string) r["Name"];
						c.Surname = (string) r["Surname"];
						c.Address = (string) r["Address"];
						c.Email = (string) r["Email"];
						c.PhoneNumber = r["PhoneNumber"].ToString();
						
						string s = c.ToString();
						if(m.IsMember(c))
							s += "\n(Ya es miembro)";
						info_label.Text = s;
					}
					
					else
					{
						info_label.Text = "Número de cliente (" + id + ") no encontrado";
						this.TargetMember.InnerClient = null;
					}
				};
				
				search_button.Clicked += (object sender, EventArgs args) =>
				{
					info_label.Text = "No implementado";
				};
				
				this.ClientByIdButton.Click();
				this.ContentVBox.ShowAll();
				id_spin.HasFocus = true;
			}
		}
		
		private void MemberInfo() //step 3
		{
			//if the member's inner client is null and the user has reached this
			//step, the user has chosen a client id instead of creating one...
			//and here we are verifying the info given before
			if(this.TargetMember.InnerClient == null)
			{
				ClientModel cm = new ClientModel();
				bool error = false;
				string msg = "";
				Client c = new Client();
				c.Id = this.ClientId;
				
				if(!cm.ExistsById(c.Id))
				{
					msg = "No se puede encontrar al número de cliente " + this.ClientId;
					error = true;
				}
				
				else if(cm.IsMember(c))
				{
					msg = "El cliente elegido ya es un miembro del gimnasio";
					error = true;
				}
				
				if(error)
				{
					GuiHelper.ShowError(this, msg);
					this.Step -= 1;
					return;
				}
			}
			
			//ok, let's continue if everything as expected:
			//if InnerClient == null, this.ClientId should hold
			//an integer pointing to an existing client :)
			
			if(!this.MemberInitialized)
			{
				this.MemberInitialized = true;
				this.TargetMember.Height = 1.0;
				this.TargetMember.Weight = 40.0;
				this.TargetMember.Gender = 'm';
				this.TargetMember.BirthDate = DateTime.Today;
				Contact ctc = new Contact();
				ctc.Name = "";
				ctc.PhoneNumber = "";
				this.TargetMember.InnerContact = ctc;
				this.TargetMember.PaymentDay = DateTime.Today.Day;
				this.TargetMember.JoinDate = DateTime.Today;
				this.TargetMember.Pack = 0;
			}
			
			this.ClearContentBox();
			this.Description = "Información requerida del nuevo miembro";	
			
			Label l1 = new Label("Peso (Kg)");
			Label l2 = new Label("Estatura (Mts)");	
			Label l3 = new Label("Sexo");
			Label l4 = new Label("Nacimiento");
			Label l5 = new Label("\nEn caso de accidente, contactar a la siguiente persona:\n");
			Label l6 = new Label("Nombre");
			Label l7 = new Label("Teléfono");
					
			SpinButton weight_spin = new SpinButton(40, 200, 0.01);
			SpinButton height_spin = new SpinButton(1, 2.5, 0.01);
			ComboBox gender_combo = new ComboBox(new string[] {"Masculino", "Femenino"});
			DateWidget dw = new DateWidget();		
			Entry contact_name_entry = new Entry();
			Entry contact_phone_entry = new Entry();			
			
			weight_spin.Changed += (s, a) =>
			{
				float weight;
				this.TargetMember.Weight = (float.TryParse(weight_spin.Text, out weight) ? weight : weight_spin.Value);
			};
			
			height_spin.Changed += (s, a) => 
			{
				float height;
				this.TargetMember.Height = (float.TryParse(height_spin.Text, out height) ? height : height_spin.Value);
			};
			
			gender_combo.Changed += (s, a) => this.TargetMember.Gender = (gender_combo.Active == 0 ? 'm' : 'f');
			contact_name_entry.Changed += (s, a) => this.TargetMember.InnerContact.Name = contact_name_entry.Text.Trim();
			contact_phone_entry.Changed += (s, a) => this.TargetMember.InnerContact.PhoneNumber = contact_phone_entry.Text.Trim();
			dw.Changed += (s, a) => this.TargetMember.BirthDate = dw.Date;
			
			this.PackWidgetPair(l1, weight_spin);
			this.PackWidgetPair(l2, height_spin);
			this.PackWidgetPair(l3, gender_combo);
			this.PackWidgetPair(l4, dw.Box);
			this.PackWidgetSingle(l5);
			this.PackWidgetPair(l6, contact_name_entry);
			this.PackWidgetPair(l7, contact_phone_entry);
			
			weight_spin.Value = this.TargetMember.Weight;
			height_spin.Value = this.TargetMember.Height;
			gender_combo.Active = (this.TargetMember.Gender == 'm' ? 0 : 1);
			dw.Date = this.TargetMember.BirthDate;
			
			contact_name_entry.Text = this.TargetMember.InnerContact.Name;
			contact_phone_entry.Text = this.TargetMember.InnerContact.PhoneNumber;
			
			this.ContentVBox.ShowAll();
		}
		
		private void Photo() //step 4
		{
			//ok, let's check if the user can reach this step, or
			//return to the previous
			
			Validation.Validator v = new Validation.Validator();
			Contact ct = this.TargetMember.InnerContact;
			v.SetRule(ct.Name, "nombre de contacto", 2, 50);
			v.SetRule(ct.PhoneNumber, "teléfono de contacto", 7, 13, Validation.ValidationRule.Number);
			Validation.ValidationResponse r = v.Run();
			if(!r.Status)
			{
				string s = "";
				for(int i = 0; i < r.Messages.Length; s += r.Messages[i++] + "\n");
				GuiHelper.ShowError(s);
				this.Step -= 1;
				return;
			}
			
			else if(!(string.IsNullOrEmpty(ct.Name) == string.IsNullOrEmpty(ct.PhoneNumber)))
			{
				GuiHelper.ShowError(this, "Si va a proporcionar los datos de contacto, debe proporcionar ambos");
				this.Step -= 1;
				return;
			}
			
			//ok, if everything is ok, lets ask for the photo :)
			this.Header = "";
			this.ClearContentBox();
			this.Description = "Introduzca opcionalmente una fotografía para identificar al cliente";
			
			Button img_button = new Button();
			this.ImageButton = img_button;
			img_button.SetSizeRequest(300, 250);
			img_button.Clicked += this.ChoosePicture;
			
			if(this.TargetMember.BinImage == null)
				this.CleanImage(null, null);
			else
				this.LoadImage();
			
			Button clean_button = new Button("Quitar");
			clean_button.Relief = ReliefStyle.None;
			clean_button.Clicked += this.CleanImage;
			
			LinkButton link = new LinkButton("", "O bien, toma una fotografía");
			link.HasTooltip = false;
			link.FocusOnClick = false;
			link.Clicked += this.TakePicture;
			
			this.PackWidgetSingle(img_button);
			this.PackWidgetPair(clean_button, link);
			this.ContentVBox.ShowAll();
		}
		
		private void CleanImage(object sender, EventArgs args)
		{
			foreach(Widget w in this.ImageButton.Children)
				this.ImageButton.Remove(w);
			this.ImageButton.Label = "Click para seleccionar";
			this.TargetMember.BinImage = null;
			/*byte[] bytes = this.MemberPixbuf.SaveToBuffer("png");
			Console.Out.WriteLine(bytes.Length);
			DbModel m = new DbModel("imgtest", "Id");
			SqliteCommand cmd = (SqliteCommand) m.Db.CreateCommand();
			cmd.CommandText = "insert into imgtest values(null, @img)";
			cmd.Parameters.Add("@img", DbType.Binary, bytes.Length).Value = bytes;
			Console.Out.WriteLine(cmd.ExecuteNonQuery());*/
		}
		
		private void LoadImage()
		{
			if(this.TargetMember.BinImage == null)
				return;
				
			Pixbuf pixbuf = new Pixbuf(this.TargetMember.BinImage);
			foreach(Widget w in this.ImageButton.Children)
				this.ImageButton.Remove(w);
			this.ImageButton.Add(new Gtk.Image(pixbuf));
			this.ImageButton.ShowAll();
		}
		
		private void TakePicture(object sender, EventArgs args)
		{
			GuiHelper.ShowMessage("Aún no implementado");
			/*DbModel m = new DbModel("imgtest", "Id");
			SqliteCommand cmd = (SqliteCommand) m.Db.CreateCommand();
			cmd.CommandText = "select * from imgtest where Id = 7";
			IDataReader r = cmd.ExecuteReader();
			r.Read();
			long length = r.GetBytes(1, 0, null, 0, 0);
			byte[] bytes = new byte[length];
			r.GetBytes(1, 0, bytes, 0, bytes.Length);
			
			Pixbuf p = new Pixbuf(bytes);
			Widget[] ws = this.ImageButton.Children;
			foreach(Widget w in ws)
				this.ImageButton.Remove(w);
			this.ImageButton.Add(new Gtk.Image(p));
			this.ImageButton.ShowAll();*/
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
					Pixbuf pixbuf = new Pixbuf(file_name, 300, 250, true);
					this.TargetMember.BinImage = pixbuf.SaveToBuffer("png");
					this.LoadImage();
				}
				
				catch(GLib.GException)
				{
					GuiHelper.ShowMessage("Esta versión de Gtk# no soporta este tipo de archivos, puede añadir la imagen más tarde si desea");
				}
			}
		}
		
		private void Payment() //step 5
		{
			this.NextLabel = "Siguente";
			//whether the user selected a photo or not
			//let¿s ask for payment info
			this.Description = "Información de pago";
			this.ClearContentBox();
			
			Label l1 = new Label("Inscribir en");
			Label l2 = new Label("Miembro desde");
			Label l3 = new Label("Día de pago");
			
			ComboBox pack_combo;
			DateWidget dw_since = new DateWidget();
			SpinButton payment_day_spin = new SpinButton(1, 31, 1);
			
			payment_day_spin.Value = dw_since.Date.Day;
			
			int found_index = -1;
			long found_id = -1;
			long id_0 = -1;
			PackModel pm = new PackModel();
			IDataReader r = pm.GetAll();
			string[] packs = new string[pm.Count()];
			for(int i = 0; r.Read(); i++)
			{
				if(i == 0)
					id_0 = (long) r["Id"];
				packs[i] = (string) r["Name"];
				if(((long) r["Id"]) == this.TargetMember.Pack)
				{
					found_id = (long) r["Id"];
					found_index = i;
				}
			}
			pack_combo = new ComboBox(packs);
			
			if(found_index == -1)
			{
				pack_combo.Active = 0;
				this.TargetMember.Pack = id_0;
			}
			
			else
			{
				pack_combo.Active = found_index;
				this.TargetMember.Pack = found_id;
			}
			
			dw_since.Date = this.TargetMember.JoinDate;
			payment_day_spin.Value = this.TargetMember.PaymentDay;
			
			//connect with targetmemeber
			dw_since.Changed += (s, a) => this.TargetMember.JoinDate = dw_since.Date;
			payment_day_spin.Changed += (s, a) => this.TargetMember.PaymentDay = payment_day_spin.ValueAsInt;
			pack_combo.Changed += (s, a) =>
			{
				IDataReader r2 = pm.GetBy("Name", pack_combo.ActiveText);
				r2.Read();
				this.TargetMember.Pack = (long) r2["Id"];
			};
			
			CheckButton month_check = new CheckButton("Cobrar primer mes");
			CheckButton membership_check = new CheckButton("Cobrar inscripción");				
			
			month_check.Active = this.TargetMember.ChargeFirstMonth;
			membership_check.Active = this.TargetMember.ChargeMembership;
			month_check.Toggled += (object s, EventArgs args) => this.TargetMember.ChargeFirstMonth = ((CheckButton) s).Active;
			membership_check.Toggled += (object s, EventArgs args) => this.TargetMember.ChargeMembership = ((CheckButton) s).Active;
			
			this.PackWidgetPair(l1, pack_combo);
			this.PackWidgetPair(l2, dw_since.Box);
			this.PackWidgetPair(l3, payment_day_spin);
			this.PackWidgetSingle(new Label("\n"));
			this.PackWidgetSingle(month_check);
			this.PackWidgetSingle(membership_check);
			this.ContentVBox.ShowAll();
		}
		
		private void Summary()
		{
			this.ClearContentBox();
			this.Description = "Se dará de alta al siguiente nuevo miembro del gimnasio";
			this.NextLabel = "Aceptar";
			
			Gtk.Image img = null;
			if(this.TargetMember.BinImage != null)
			{
				Pixbuf pixbuf;			
				pixbuf = new Pixbuf(this.TargetMember.BinImage);
				double s = 0.4;
				pixbuf = pixbuf.ScaleSimple((int) (pixbuf.Width * s), (int) (pixbuf.Height * s), InterpType.Bilinear);
				img = new Gtk.Image(pixbuf);
			}
			
			ClientModel cm = new ClientModel();
			Client client = null;
			bool new_client = (this.TargetMember.InnerClient == null ? false : true);
			if(!new_client)
			{
				IDataReader r = cm.GetById(this.ClientId);
				r.Read();
				client = new Client();
				client.Id = this.ClientId;
				client.Name = (string) r["Name"];
				client.Surname = (string) r["Surname"];
				client.Address = (string) r["Address"];
				client.PhoneNumber = ((decimal) r["PhoneNumber"]).ToString();
				client.Email = (string) r["Email"];
				this.TargetMember.InnerClient = client;
			}
			
			else
			{
				client = this.TargetMember.InnerClient;
				client.Id = -1;
			}
				
			PackModel pm = new PackModel();
			IDataReader pr = pm.GetById(this.TargetMember.Pack);
			pr.Read();
			string p_name = (string) pr["Name"];
			double p_price = (float) pr["Price"];
			string str_pay = string.Empty;
			str_pay += "Fecha de ingreso: " + this.TargetMember.JoinDate.ToString("dd/MM/yyyy");
			str_pay += "\nDía de pago: " + this.TargetMember.PaymentDay + " de cada mes";		
			str_pay += "\nInscrito a : " + p_name + " (" + string.Format("{0:C}", p_price) + " mensuales)";
			
			string ct_str = string.Empty;
			if(this.TargetMember.InnerContact != null)
			{
				ct_str += "Contacto en caso de lesión\n";
				ct_str += "Nombre: " + this.TargetMember.InnerContact.Name + "\n";
				ct_str += "Teléfono: " + this.TargetMember.InnerContact.PhoneNumber;
			}
			
			if(img != null)
				this.PackWidgetSingle(img);			
			this.PackWidgetSingle(new Label(client.ToString()));
			this.PackWidgetSingle(new Label(this.TargetMember.ToString()));
			this.PackWidgetSingle(new Label(str_pay));
			this.PackWidgetSingle(new Label(ct_str));
			
			this.ContentVBox.ShowAll();
		}
		
		private void Complete()
		{
			this.Success(this.TargetMember);
			this.Destroy();
		}
	}
}

