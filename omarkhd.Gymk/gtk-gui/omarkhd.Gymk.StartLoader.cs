
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class StartLoader
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Fixed fixed1;

		private global::Gtk.Fixed fixed2;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Label MessageLabel;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.ProgressBar LoadBar;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.StartLoader
			this.Name = "omarkhd.Gymk.StartLoader";
			this.Title = global::Mono.Unix.Catalog.GetString ("Cargando pagos...");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(4));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(6));
			this.Gravity = ((global::Gdk.Gravity)(9));
			// Container child omarkhd.Gymk.StartLoader.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.vbox2.Add (this.fixed1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this.vbox2.Add (this.fixed2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed2]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.MessageLabel = new global::Gtk.Label ();
			this.MessageLabel.Name = "MessageLabel";
			this.vbox3.Add (this.MessageLabel);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.MessageLabel]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed4 = new global::Gtk.Fixed ();
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			this.vbox3.Add (this.fixed4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed4]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.LoadBar = new global::Gtk.ProgressBar ();
			this.LoadBar.Name = "LoadBar";
			this.vbox3.Add (this.LoadBar);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.LoadBar]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 119;
			this.Show ();
		}
	}
}
