
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class AreasWindow
	{
		private global::Gtk.VBox vbox3;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Label label2;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label3;

		private global::Gtk.Entry AreaEntry;

		private global::Gtk.Button OkButton;

		private global::Gtk.Button CancelButton;

		private global::Gtk.VBox vbox5;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView AreasNodeView;

		private global::Gtk.HBox hbox2;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Fixed fixed5;

		private global::Gtk.Button DeleteButton;

		private global::Gtk.Button EditButton;

		private global::Gtk.Button AddButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.AreasWindow
			this.Name = "omarkhd.Gymk.AreasWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Areas");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(2));
			// Container child omarkhd.Gymk.AreasWindow.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed ();
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.vbox3.Add (this.fixed3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Áreas con las que cuenta el gimnasio, estas servirán para la creación de nuevos paquetes de cobro.");
			this.label2.Wrap = true;
			this.label2.Justify = ((global::Gtk.Justification)(3));
			this.vbox4.Add (this.label2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.label2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.fixed4 = new global::Gtk.Fixed ();
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			this.vbox4.Add (this.fixed4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.fixed4]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox4.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hseparator1]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(2));
			// Container child hbox1.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.WidthRequest = 40;
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Área:");
			this.hbox1.Add (this.label3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label3]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.AreaEntry = new global::Gtk.Entry ();
			this.AreaEntry.WidthRequest = 180;
			this.AreaEntry.CanFocus = true;
			this.AreaEntry.Name = "AreaEntry";
			this.AreaEntry.IsEditable = true;
			this.AreaEntry.InvisibleChar = '•';
			this.hbox1.Add (this.AreaEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.AreaEntry]));
			w6.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.OkButton = new global::Gtk.Button ();
			this.OkButton.CanFocus = true;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseUnderline = true;
			this.OkButton.Label = global::Mono.Unix.Catalog.GetString ("Ok");
			this.hbox1.Add (this.OkButton);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.OkButton]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.CancelButton = new global::Gtk.Button ();
			this.CancelButton.CanFocus = true;
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.UseUnderline = true;
			this.CancelButton.Label = global::Mono.Unix.Catalog.GetString ("Cancelar");
			this.hbox1.Add (this.CancelButton);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.CancelButton]));
			w8.Position = 3;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox4.Add (this.hbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox1]));
			w9.Position = 3;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox3.Add (this.vbox4);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.AreasNodeView = new global::Gtk.NodeView ();
			this.AreasNodeView.CanFocus = true;
			this.AreasNodeView.Name = "AreasNodeView";
			this.GtkScrolledWindow.Add (this.AreasNodeView);
			this.vbox5.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.GtkScrolledWindow]));
			w12.Position = 0;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.fixed5 = new global::Gtk.Fixed ();
			this.fixed5.Name = "fixed5";
			this.fixed5.HasWindow = false;
			this.hbox3.Add (this.fixed5);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.fixed5]));
			w13.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.DeleteButton = new global::Gtk.Button ();
			this.DeleteButton.CanFocus = true;
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.UseUnderline = true;
			this.DeleteButton.Label = global::Mono.Unix.Catalog.GetString ("Eliminar");
			this.hbox3.Add (this.DeleteButton);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.DeleteButton]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			this.hbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.hbox3]));
			w15.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.EditButton = new global::Gtk.Button ();
			this.EditButton.CanFocus = true;
			this.EditButton.Name = "EditButton";
			this.EditButton.UseUnderline = true;
			this.EditButton.Label = global::Mono.Unix.Catalog.GetString ("Editar");
			this.hbox2.Add (this.EditButton);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.EditButton]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.AddButton = new global::Gtk.Button ();
			this.AddButton.CanFocus = true;
			this.AddButton.Name = "AddButton";
			this.AddButton.UseUnderline = true;
			this.AddButton.Label = global::Mono.Unix.Catalog.GetString ("Añadir");
			this.hbox2.Add (this.AddButton);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.AddButton]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox5.Add (this.hbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.vbox3.Add (this.vbox5);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox5]));
			w19.Position = 2;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 341;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
