
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class NewPasswordDialog
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Fixed fixed1;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment2;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Entry OldEntry;

		private global::Gtk.Fixed fixed8;

		private global::Gtk.Label OldLabel;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.Frame frame2;

		private global::Gtk.Alignment GtkAlignment3;

		private global::Gtk.VBox vbox5;

		private global::Gtk.Entry NewEntry;

		private global::Gtk.VBox vbox6;

		private global::Gtk.Label label2;

		private global::Gtk.Entry RepeatEntry;

		private global::Gtk.Label GtkLabel3;

		private global::Gtk.Label InfoLabel;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button OkButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.NewPasswordDialog
			this.HeightRequest = 220;
			this.Name = "omarkhd.Gymk.NewPasswordDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("Nueva contraseña");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Internal child omarkhd.Gymk.NewPasswordDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.vbox2.Add (this.fixed1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(6));
			// Container child vbox3.Gtk.Box+BoxChild
			this.OldEntry = new global::Gtk.Entry ();
			this.OldEntry.CanFocus = true;
			this.OldEntry.Name = "OldEntry";
			this.OldEntry.IsEditable = true;
			this.OldEntry.InvisibleChar = '•';
			this.vbox3.Add (this.OldEntry);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.OldEntry]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed8 = new global::Gtk.Fixed ();
			this.fixed8.Name = "fixed8";
			this.fixed8.HasWindow = false;
			this.vbox3.Add (this.fixed8);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed8]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.GtkAlignment2.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment2);
			this.OldLabel = new global::Gtk.Label ();
			this.OldLabel.Name = "OldLabel";
			this.OldLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Contraseña anterior</b>");
			this.OldLabel.UseMarkup = true;
			this.frame1.LabelWidget = this.OldLabel;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.fixed4 = new global::Gtk.Fixed ();
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			this.vbox4.Add (this.fixed4);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.fixed4]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			this.vbox5.BorderWidth = ((uint)(6));
			// Container child vbox5.Gtk.Box+BoxChild
			this.NewEntry = new global::Gtk.Entry ();
			this.NewEntry.CanFocus = true;
			this.NewEntry.Name = "NewEntry";
			this.NewEntry.IsEditable = true;
			this.NewEntry.InvisibleChar = '•';
			this.vbox5.Add (this.NewEntry);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.NewEntry]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 0f;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("escríbela de nuevo:");
			this.vbox6.Add (this.label2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.label2]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.RepeatEntry = new global::Gtk.Entry ();
			this.RepeatEntry.CanFocus = true;
			this.RepeatEntry.Name = "RepeatEntry";
			this.RepeatEntry.IsEditable = true;
			this.RepeatEntry.InvisibleChar = '•';
			this.vbox6.Add (this.RepeatEntry);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.RepeatEntry]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox5.Add (this.vbox6);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.vbox6]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.GtkAlignment3.Add (this.vbox5);
			this.frame2.Add (this.GtkAlignment3);
			this.GtkLabel3 = new global::Gtk.Label ();
			this.GtkLabel3.Name = "GtkLabel3";
			this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Nueva</b>");
			this.GtkLabel3.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel3;
			this.vbox4.Add (this.frame2);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.frame2]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.InfoLabel = new global::Gtk.Label ();
			this.InfoLabel.Name = "InfoLabel";
			this.vbox4.Add (this.InfoLabel);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.InfoLabel]));
			w16.Position = 2;
			w16.Expand = false;
			w16.Fill = false;
			this.vbox2.Add (this.vbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox4]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Internal child omarkhd.Gymk.NewPasswordDialog.ActionArea
			global::Gtk.HButtonBox w19 = this.ActionArea;
			w19.Name = "dialog1_ActionArea";
			w19.Spacing = 10;
			w19.BorderWidth = ((uint)(5));
			w19.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancelar");
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w20 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19[this.buttonCancel]));
			w20.Expand = false;
			w20.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.OkButton = new global::Gtk.Button ();
			this.OkButton.CanDefault = true;
			this.OkButton.CanFocus = true;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseUnderline = true;
			this.OkButton.Label = global::Mono.Unix.Catalog.GetString ("Aceptar");
			w19.Add (this.OkButton);
			global::Gtk.ButtonBox.ButtonBoxChild w21 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19[this.OkButton]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 203;
			this.DefaultHeight = 246;
			this.Show ();
		}
	}
}