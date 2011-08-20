using System;
namespace omarkhd.Gymk
{
	public partial class ConfigWindow : Gtk.Window
	{
		public ConfigWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.Modal = true;
		}
	}
}

