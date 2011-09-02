using System;
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
			this.Init();
		}
		
		private void CustomBuild()
		{
			this.BirthdayWidget = new DateWidget();
			this.SinceWidget = new DateWidget();
			
			this.BirthdayBox.Add(this.BirthdayWidget.Box);
			this.SinceBox.Add(this.SinceWidget.Box);
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
		}
	}
}

