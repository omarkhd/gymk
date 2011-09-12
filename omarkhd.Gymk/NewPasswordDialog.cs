using System;
namespace omarkhd.Gymk
{
	public partial class NewPasswordDialog : Gtk.Dialog
	{
		private bool IsSelf;
		
		public string Old { private set; get; }
		public string New { private set; get; }
		
		public NewPasswordDialog(bool self)
		{
			this.IsSelf = self;
			
			this.Build();
			this.CustomBuild();
			this.Connect();
		}
		
		private void CustomBuild()
		{
			this.OldEntry.Visibility = false;
			this.NewEntry.Visibility = false;
			this.RepeatEntry.Visibility = false;
			
			if(!this.IsSelf)
			{
				this.OldLabel.Sensitive = false;
				this.OldEntry.Sensitive = false;
				this.NewEntry.HasFocus = true;
			}
		}
		
		private void Connect()
		{
			this.OkButton.Clicked += DoCheck;
			this.Response += (o, ra) => this.Destroy();
		}
		
		private void DoCheck(object sender, EventArgs args)
		{
			this.Old = this.OldEntry.Text;
			this.New = this.NewEntry.Text;
			
			if(this.CheckNew())
				this.Respond(Gtk.ResponseType.Ok);
			else
				this.InfoLabel.Text = "Las contraseñas no coinciden";
		}
		
		private bool CheckNew()
		{
			return this.NewEntry.Text == this.RepeatEntry.Text;
		}
	}
}

