
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class Wizard
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.Image _SidebarImage;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Fixed fixed9;

		private global::Gtk.Label HeaderLabel;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Label DescriptionLabel;

		private global::Gtk.VBox _vbox_aux;

		private global::Gtk.Fixed fixed2;

		private global::Gtk.VBox _ContentVBox;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Fixed fixed8;

		private global::Gtk.Button _NextButton;

		private global::Gtk.Button _PreviousButton;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.Fixed fixed7;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.Wizard
			this.WidthRequest = 500;
			this.Name = "omarkhd.Gymk.Wizard";
			this.Title = global::Mono.Unix.Catalog.GetString ("Wizard");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.AllowGrow = false;
			// Container child omarkhd.Gymk.Wizard.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this._SidebarImage = new global::Gtk.Image ();
			this._SidebarImage.WidthRequest = 150;
			this._SidebarImage.HeightRequest = 420;
			this._SidebarImage.Name = "_SidebarImage";
			this.hbox1.Add (this._SidebarImage);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this._SidebarImage]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.fixed4 = new global::Gtk.Fixed ();
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			this.vbox1.Add (this.fixed4);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.fixed4]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w3 = new global::Gtk.Viewport ();
			w3.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed9 = new global::Gtk.Fixed ();
			this.fixed9.Name = "fixed9";
			this.fixed9.HasWindow = false;
			this.vbox3.Add (this.fixed9);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed9]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.HeaderLabel = new global::Gtk.Label ();
			this.HeaderLabel.Name = "HeaderLabel";
			this.HeaderLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Título");
			this.vbox3.Add (this.HeaderLabel);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.HeaderLabel]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.DescriptionLabel = new global::Gtk.Label ();
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Descripción");
			this.DescriptionLabel.Wrap = true;
			this.vbox4.Add (this.DescriptionLabel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.DescriptionLabel]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this._vbox_aux = new global::Gtk.VBox ();
			this._vbox_aux.Name = "_vbox_aux";
			this._vbox_aux.Spacing = 6;
			// Container child _vbox_aux.Gtk.Box+BoxChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this._vbox_aux.Add (this.fixed2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this._vbox_aux[this.fixed2]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child _vbox_aux.Gtk.Box+BoxChild
			this._ContentVBox = new global::Gtk.VBox ();
			this._ContentVBox.Name = "_ContentVBox";
			this._ContentVBox.Spacing = 6;
			this._vbox_aux.Add (this._ContentVBox);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this._vbox_aux[this._ContentVBox]));
			w8.Position = 1;
			this.vbox4.Add (this._vbox_aux);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox4[this._vbox_aux]));
			w9.Position = 1;
			this.vbox3.Add (this.vbox4);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
			w10.Position = 2;
			w3.Add (this.vbox3);
			this.scrolledwindow1.Add (w3);
			this.vbox1.Add (this.scrolledwindow1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.scrolledwindow1]));
			w13.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hseparator1]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.fixed8 = new global::Gtk.Fixed ();
			this.fixed8.Name = "fixed8";
			this.fixed8.HasWindow = false;
			this.hbox2.Add (this.fixed8);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.fixed8]));
			w15.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this._NextButton = new global::Gtk.Button ();
			this._NextButton.CanFocus = true;
			this._NextButton.Name = "_NextButton";
			this._NextButton.UseUnderline = true;
			this._NextButton.Label = global::Mono.Unix.Catalog.GetString ("Siguiente");
			this.hbox2.Add (this._NextButton);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2[this._NextButton]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this._PreviousButton = new global::Gtk.Button ();
			this._PreviousButton.CanFocus = true;
			this._PreviousButton.Name = "_PreviousButton";
			this._PreviousButton.UseUnderline = true;
			this._PreviousButton.Label = global::Mono.Unix.Catalog.GetString ("Atrás");
			this.hbox2.Add (this._PreviousButton);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2[this._PreviousButton]));
			w17.PackType = ((global::Gtk.PackType)(1));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w18.Position = 3;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed ();
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.vbox1.Add (this.fixed3);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.fixed3]));
			w19.Position = 4;
			w19.Expand = false;
			w19.Fill = false;
			this.hbox1.Add (this.vbox1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox1]));
			w20.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.fixed7 = new global::Gtk.Fixed ();
			this.fixed7.Name = "fixed7";
			this.fixed7.HasWindow = false;
			this.hbox1.Add (this.fixed7);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.fixed7]));
			w21.Position = 2;
			w21.Expand = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 580;
			this.DefaultHeight = 446;
			this.Show ();
		}
	}
}
