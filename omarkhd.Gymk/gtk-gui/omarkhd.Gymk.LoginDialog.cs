
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class LoginDialog
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Image TopImage;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.Label label1;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.Fixed fixed5;

		private global::Gtk.VBox vbox5;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label2;

		private global::Gtk.Entry UserEntry;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label3;

		private global::Gtk.Entry PasswordEntry;

		private global::Gtk.VBox vbox6;

		private global::Gtk.Fixed fixed6;

		private global::Gtk.Label InfoLabel;

		private global::Gtk.Label GtkLabel2;

		private global::Gtk.Fixed fixed2;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button OkButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.LoginDialog
			this.HeightRequest = 270;
			this.Name = "omarkhd.Gymk.LoginDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Resizable = false;
			// Internal child omarkhd.Gymk.LoginDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.TopImage = new global::Gtk.Image ();
			this.TopImage.HeightRequest = 70;
			this.TopImage.Name = "TopImage";
			this.vbox2.Add (this.TopImage);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.TopImage]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed ();
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.vbox3.Add (this.fixed3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Ingresa tus credenciales de acceso");
			this.vbox3.Add (this.label1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.label1]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.fixed4 = new global::Gtk.Fixed ();
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			this.vbox4.Add (this.fixed4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.fixed4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.fixed5 = new global::Gtk.Fixed ();
			this.fixed5.Name = "fixed5";
			this.fixed5.HasWindow = false;
			this.vbox4.Add (this.fixed5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.fixed5]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.WidthRequest = 70;
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Usuario");
			this.label2.Wrap = true;
			this.hbox1.Add (this.label2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label2]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.UserEntry = new global::Gtk.Entry ();
			this.UserEntry.CanFocus = true;
			this.UserEntry.Name = "UserEntry";
			this.UserEntry.IsEditable = true;
			this.UserEntry.InvisibleChar = '•';
			this.hbox1.Add (this.UserEntry);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.UserEntry]));
			w8.Position = 1;
			this.vbox5.Add (this.hbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox1]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.WidthRequest = 70;
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Contraseña");
			this.label3.Wrap = true;
			this.hbox2.Add (this.label3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label3]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.PasswordEntry = new global::Gtk.Entry ();
			this.PasswordEntry.CanFocus = true;
			this.PasswordEntry.Name = "PasswordEntry";
			this.PasswordEntry.IsEditable = true;
			this.PasswordEntry.InvisibleChar = '•';
			this.hbox2.Add (this.PasswordEntry);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.PasswordEntry]));
			w11.Position = 1;
			this.vbox5.Add (this.hbox2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.fixed6 = new global::Gtk.Fixed ();
			this.fixed6.Name = "fixed6";
			this.fixed6.HasWindow = false;
			this.vbox6.Add (this.fixed6);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.fixed6]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.InfoLabel = new global::Gtk.Label ();
			this.InfoLabel.Name = "InfoLabel";
			this.vbox6.Add (this.InfoLabel);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.InfoLabel]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			this.vbox5.Add (this.vbox6);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.vbox6]));
			w15.Position = 2;
			this.vbox4.Add (this.vbox5);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.vbox5]));
			w16.Position = 2;
			this.vbox3.Add (this.vbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
			w17.Position = 2;
			this.GtkAlignment.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Bienvenido</b>");
			this.GtkLabel2.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel2;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
			w20.Position = 1;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this.vbox2.Add (this.fixed2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed2]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w22.Position = 0;
			// Internal child omarkhd.Gymk.LoginDialog.ActionArea
			global::Gtk.HButtonBox w23 = this.ActionArea;
			w23.Name = "dialog1_ActionArea";
			w23.Spacing = 10;
			w23.BorderWidth = ((uint)(5));
			w23.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancelar");
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w24 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w23[this.buttonCancel]));
			w24.Expand = false;
			w24.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.OkButton = new global::Gtk.Button ();
			this.OkButton.CanDefault = true;
			this.OkButton.CanFocus = true;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseUnderline = true;
			this.OkButton.Label = global::Mono.Unix.Catalog.GetString ("Aceptar");
			w23.Add (this.OkButton);
			global::Gtk.ButtonBox.ButtonBoxChild w25 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w23[this.OkButton]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 264;
			this.DefaultHeight = 296;
			this.Show ();
		}
	}
}
