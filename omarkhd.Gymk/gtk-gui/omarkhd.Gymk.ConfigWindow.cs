
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class ConfigWindow
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Fixed fixed1;

		private global::Gtk.Notebook notebook1;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Fixed fixed2;

		private global::Gtk.VBox vbox5;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label1;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.Label label2;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.VBox vbox6;

		private global::Gtk.HBox hbox4;

		private global::Gtk.VBox vbox7;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView UsersNodeView;

		private global::Gtk.Button AddButton;

		private global::Gtk.Button EditButton;

		private global::Gtk.HBox hbox13;

		private global::Gtk.Button CancelButton;

		private global::Gtk.Button OkButton;

		private global::Gtk.VBox vbox8;

		private global::Gtk.Fixed fixed6;

		private global::Gtk.HBox hbox12;

		private global::Gtk.CheckButton AdminCheckBox;

		private global::Gtk.CheckButton ActiveCheckBox;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label4;

		private global::Gtk.Entry AliasEntry;

		private global::Gtk.VBox vbox9;

		private global::Gtk.HBox hbox8;

		private global::Gtk.Label label5;

		private global::Gtk.Entry NameEntry;

		private global::Gtk.HBox hbox11;

		private global::Gtk.Button PasswordButton;

		private global::Gtk.Button AccessButton;

		private global::Gtk.VBox vbox10;

		private global::Gtk.Fixed fixed5;

		private global::Gtk.Label label3;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.ConfigWindow
			this.Name = "omarkhd.Gymk.ConfigWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Preferencias");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child omarkhd.Gymk.ConfigWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.vbox1.Add (this.fixed1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.fixed1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 2;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this.vbox2.Add (this.fixed2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			this.vbox5.Add (this.hbox2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
			w3.Position = 0;
			this.vbox2.Add (this.vbox5);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox5]));
			w4.Position = 1;
			this.notebook1.Add (this.vbox2);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("General");
			this.notebook1.SetTabLabel (this.vbox2, this.label1);
			this.label1.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed ();
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.vbox3.Add (this.fixed3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed3]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			this.notebook1.Add (this.vbox3);
			global::Gtk.Notebook.NotebookChild w7 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox3]));
			w7.Position = 1;
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Pagos");
			this.notebook1.SetTabLabel (this.vbox3, this.label2);
			this.label2.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
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
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			this.vbox7.BorderWidth = ((uint)(7));
			// Container child vbox7.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.WidthRequest = 160;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.UsersNodeView = new global::Gtk.NodeView ();
			this.UsersNodeView.CanFocus = true;
			this.UsersNodeView.Name = "UsersNodeView";
			this.GtkScrolledWindow.Add (this.UsersNodeView);
			this.vbox7.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.GtkScrolledWindow]));
			w10.Position = 0;
			// Container child vbox7.Gtk.Box+BoxChild
			this.AddButton = new global::Gtk.Button ();
			this.AddButton.CanFocus = true;
			this.AddButton.Name = "AddButton";
			this.AddButton.UseUnderline = true;
			this.AddButton.Label = global::Mono.Unix.Catalog.GetString ("Añadir");
			this.vbox7.Add (this.AddButton);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.AddButton]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.EditButton = new global::Gtk.Button ();
			this.EditButton.CanFocus = true;
			this.EditButton.Name = "EditButton";
			this.EditButton.UseUnderline = true;
			this.EditButton.Label = global::Mono.Unix.Catalog.GetString ("Editar");
			this.vbox7.Add (this.EditButton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.EditButton]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox13 = new global::Gtk.HBox ();
			this.hbox13.Name = "hbox13";
			this.hbox13.Spacing = 6;
			// Container child hbox13.Gtk.Box+BoxChild
			this.CancelButton = new global::Gtk.Button ();
			this.CancelButton.CanFocus = true;
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.UseUnderline = true;
			this.CancelButton.Label = global::Mono.Unix.Catalog.GetString ("Cancelar");
			this.hbox13.Add (this.CancelButton);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.CancelButton]));
			w13.Position = 0;
			// Container child hbox13.Gtk.Box+BoxChild
			this.OkButton = new global::Gtk.Button ();
			this.OkButton.CanFocus = true;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseUnderline = true;
			this.OkButton.Label = global::Mono.Unix.Catalog.GetString ("Ok");
			this.hbox13.Add (this.OkButton);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.OkButton]));
			w14.Position = 1;
			this.vbox7.Add (this.hbox13);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox13]));
			w15.Position = 3;
			w15.Expand = false;
			w15.Fill = false;
			this.hbox4.Add (this.vbox7);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.vbox7]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vbox8 = new global::Gtk.VBox ();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			this.vbox8.BorderWidth = ((uint)(6));
			// Container child vbox8.Gtk.Box+BoxChild
			this.fixed6 = new global::Gtk.Fixed ();
			this.fixed6.Name = "fixed6";
			this.fixed6.HasWindow = false;
			this.vbox8.Add (this.fixed6);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.fixed6]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.hbox12 = new global::Gtk.HBox ();
			this.hbox12.Name = "hbox12";
			this.hbox12.Spacing = 6;
			// Container child hbox12.Gtk.Box+BoxChild
			this.AdminCheckBox = new global::Gtk.CheckButton ();
			this.AdminCheckBox.CanFocus = true;
			this.AdminCheckBox.Name = "AdminCheckBox";
			this.AdminCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Administrador");
			this.AdminCheckBox.DrawIndicator = true;
			this.AdminCheckBox.UseUnderline = true;
			this.hbox12.Add (this.AdminCheckBox);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.AdminCheckBox]));
			w18.Position = 0;
			// Container child hbox12.Gtk.Box+BoxChild
			this.ActiveCheckBox = new global::Gtk.CheckButton ();
			this.ActiveCheckBox.CanFocus = true;
			this.ActiveCheckBox.Name = "ActiveCheckBox";
			this.ActiveCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Activo");
			this.ActiveCheckBox.DrawIndicator = true;
			this.ActiveCheckBox.UseUnderline = true;
			this.hbox12.Add (this.ActiveCheckBox);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.ActiveCheckBox]));
			w19.Position = 1;
			this.vbox8.Add (this.hbox12);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.hbox12]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.WidthRequest = 50;
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Usuario");
			this.label4.Wrap = true;
			this.hbox7.Add (this.label4);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label4]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.AliasEntry = new global::Gtk.Entry ();
			this.AliasEntry.CanFocus = true;
			this.AliasEntry.Name = "AliasEntry";
			this.AliasEntry.IsEditable = true;
			this.AliasEntry.InvisibleChar = '●';
			this.hbox7.Add (this.AliasEntry);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.AliasEntry]));
			w22.Position = 1;
			this.vbox8.Add (this.hbox7);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.hbox7]));
			w23.Position = 2;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.vbox9 = new global::Gtk.VBox ();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 6;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.WidthRequest = 50;
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre");
			this.label5.Wrap = true;
			this.hbox8.Add (this.label5);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.label5]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.NameEntry = new global::Gtk.Entry ();
			this.NameEntry.CanFocus = true;
			this.NameEntry.Name = "NameEntry";
			this.NameEntry.IsEditable = true;
			this.NameEntry.InvisibleChar = '●';
			this.hbox8.Add (this.NameEntry);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.NameEntry]));
			w25.Position = 1;
			this.vbox9.Add (this.hbox8);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox8]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox11 = new global::Gtk.HBox ();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.PasswordButton = new global::Gtk.Button ();
			this.PasswordButton.CanFocus = true;
			this.PasswordButton.Name = "PasswordButton";
			this.PasswordButton.UseUnderline = true;
			this.PasswordButton.Label = global::Mono.Unix.Catalog.GetString ("Cambiar contraseña...");
			this.hbox11.Add (this.PasswordButton);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.PasswordButton]));
			w27.Position = 0;
			// Container child hbox11.Gtk.Box+BoxChild
			this.AccessButton = new global::Gtk.Button ();
			this.AccessButton.CanFocus = true;
			this.AccessButton.Name = "AccessButton";
			this.AccessButton.UseUnderline = true;
			this.AccessButton.Label = global::Mono.Unix.Catalog.GetString ("Permisos...");
			this.hbox11.Add (this.AccessButton);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.AccessButton]));
			w28.Position = 1;
			this.vbox9.Add (this.hbox11);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox11]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.vbox10 = new global::Gtk.VBox ();
			this.vbox10.Name = "vbox10";
			this.vbox10.Spacing = 6;
			this.vbox9.Add (this.vbox10);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.vbox10]));
			w30.Position = 2;
			this.vbox8.Add (this.vbox9);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.vbox9]));
			w31.Position = 3;
			this.hbox4.Add (this.vbox8);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.vbox8]));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			this.vbox6.Add (this.hbox4);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox4]));
			w33.Position = 0;
			// Container child vbox6.Gtk.Box+BoxChild
			this.fixed5 = new global::Gtk.Fixed ();
			this.fixed5.Name = "fixed5";
			this.fixed5.HasWindow = false;
			this.vbox6.Add (this.fixed5);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.fixed5]));
			w34.Position = 1;
			w34.Expand = false;
			w34.Fill = false;
			this.vbox4.Add (this.vbox6);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.vbox6]));
			w35.Position = 1;
			this.notebook1.Add (this.vbox4);
			global::Gtk.Notebook.NotebookChild w36 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox4]));
			w36.Position = 2;
			// Notebook tab
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Usuarios");
			this.notebook1.SetTabLabel (this.vbox4, this.label3);
			this.label3.ShowAll ();
			this.vbox1.Add (this.notebook1);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.notebook1]));
			w37.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 428;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
