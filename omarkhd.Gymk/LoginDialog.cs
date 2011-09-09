using System;
namespace omarkhd.Gymk
{
	public partial class LoginDialog : Gtk.Dialog
	{
		public bool Success { get; private set; }
		private int Hits;
		
		public LoginDialog ()
		{
			this.Build ();
			this.Connect();
			
			this.Success = false;
			this.Hits = 0;
		}
		
		private void Connect()
		{
			this.Response += (s, ra) => this.Destroy();
			this.OkButton.Clicked += this.DoLogin;
		}
		
		private void DoLogin(object sender, EventArgs args)
		{
			if(++this.Hits == 3)
				this.Respond(Gtk.ResponseType.Cancel);
				
			Console.Out.WriteLine("checking...");
		}
	}
}

