using System;
using Gtk;
using omarkhd.Validation;

namespace omarkhd.Gymk
{
	class ClientWizard : Wizard
	{
		private int Step;
		
		//constructing object
		private Client InnerClient;
		
		//needed widgets
		private Entry NameEntry;
		private Entry SurnameEntry;
		private Entry AddressEntry;
		private Entry PhoneEntry;
		private Entry EmailEntry;
		
		public ClientWizard()
		{
			this.WelcomeHeader = "Bienvenido al asistente para alta de clientes";
			this.NextEvent += this.OnNext;
			this.PreviousEvent += this.OnPrevious;
			this.Step = 0;
			this.InnerClient = new Client();
		}
		
		public void OnNext()
		{
			//this.GoTo(this.Step + 1);
			this.GoTo(this.Step += 1);
		}
		
		public void OnPrevious()
		{
			//this.GoTo(this.Step - 1);
			this.GoTo(this.Step -= 1);
		}
		
		public void GoTo(int step)
		{
			switch(step)
			{
				case 0:
					this.Init();
					break;
				
				case 1:
					this.ContactInfo();
					break;
					
				case 2:
					this.Summary();
					break;
				
				case 3:
					this.Complete();
					break;
			}
		}
		
		private void ContactInfo() //step 1
		{
			this.ClearContentBox();
			//config
			this.Header = "";
			this.Description = "Introduzca la información de contacto del nuevo cliente";
			this.CanGoPrevious = true;
			//creating ui
			Label name_label = new Label("Nombre(s)");
			Label surname_label = new Label("Apellido(s)");
			Label address_label = new Label("Dirección");
			Label phone_label = new Label("Teléfono");
			Label email_label = new Label("E-mail");
			
			Client c = this.InnerClient;
			this.NameEntry = new Entry(c.Name);
			this.SurnameEntry = new Entry(c.Surname);
			this.AddressEntry = new Entry(c.Address);
			this.PhoneEntry = new Entry(c.PhoneNumber);
			this.EmailEntry = new Entry(c.Email);
			
			this.PackWidgetPair(name_label, this.NameEntry);
			this.PackWidgetPair(surname_label, this.SurnameEntry);
			this.PackWidgetPair(address_label, this.AddressEntry);
			this.PackWidgetPair(phone_label, this.PhoneEntry);
			this.PackWidgetPair(email_label, this.EmailEntry);
			this.ContentVBox.ShowAll();
			
			//final conf
			this.NameEntry.HasFocus = true;
		}
		
		private void Summary() //step 2
		{
			Client c = this.InnerClient;
			c.Name = this.NameEntry.Text;
			c.Surname = this.SurnameEntry.Text;
			c.Address = this.AddressEntry.Text;
			c.PhoneNumber = this.PhoneEntry.Text;
			c.Email = this.EmailEntry.Text;
			
			Validator v = new Validator();
			v.SetRule(c.Name, "<Nombre>", 2, 50, ValidationRule.Required);
			v.SetRule(c.Surname, "<Apellido>", 2, 50, ValidationRule.Required);
			v.SetRule(c.Address, "<Dirección>", 0, 100);
			v.SetRule(c.PhoneNumber, "<Teléfono>", ValidationRule.Number);
			v.SetRule(c.Email, "<E-mail>", ValidationRule.Email);
			ValidationResponse r = v.Run();
			if(!r.Status)
			{
				string msg = string.Empty;
				for(int i = 0; i < r.Messages.Length; msg += r.Messages[i++] + Environment.NewLine);
				GuiHelper.ShowMessage(this, msg);
				this.Step -= 1;
				return;
			}	
			
			//if everything is ok let's show the resume
			this.ClearContentBox();
			this.Description = "Se dará de alta al siguiente cliente:";
			this.PackWidgetSingle(new Label(this.InnerClient.ToString()));
			this.ContentVBox.ShowAll();
			this.NextLabel = "Aceptar";
		}
		
		private void Complete() //step 3 
		{
			ClientModel cm = new ClientModel();
			if(cm.Exists(this.InnerClient))
			{
				GuiHelper.ShowError(this, "El cliente que intenta añadir ya existe, o hay algún cliente registrado con el mismo nombre y apellido.");
				this.Step -= 1;
			}
			
			else
			{
				this.Success(this.InnerClient);
				this.Destroy();
			}
		}
		
		public override void Init()
		{
			base.Init();
			this.Step = 0;
		}
	}
}
