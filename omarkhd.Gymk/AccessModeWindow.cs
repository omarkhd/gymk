using System;
namespace omarkhd.Gymk
{
	public partial class AccessModeWindow : Gtk.Window
	{
		public AccessModeWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
		
		public void Launch()
		{
			this.Realize();
			this.Fullscreen();
			this.ShowAll();
		}
	}
}

