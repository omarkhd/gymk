
// This file has been generated by the GUI designer. Do not modify.
namespace omarkhd.Gymk
{
	public partial class GymkWindow
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action ArchivoAction;

		private global::Gtk.Action addAction;

		private global::Gtk.Action NewEnrollmentAction;

		private global::Gtk.Action NewClientAction;

		private global::Gtk.Action QuitAction;

		private global::Gtk.Action EditarAction;

		private global::Gtk.Action ConfigAction;

		private global::Gtk.Action CatlogosAction;

		private global::Gtk.Action dndMultipleAction;

		private global::Gtk.Action AreasAction;

		private global::Gtk.Action PacksAction;

		private global::Gtk.Action ClientsAction;

		private global::Gtk.Action MembersAction;

		private global::Gtk.Action AyudaAction;

		private global::Gtk.Action infoAction;

		private global::Gtk.VBox vbox2;

		private global::Gtk.MenuBar menubar2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget omarkhd.Gymk.GymkWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.ArchivoAction = new global::Gtk.Action ("ArchivoAction", global::Mono.Unix.Catalog.GetString ("_Archivo"), null, null);
			this.ArchivoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Archivo");
			w1.Add (this.ArchivoAction, null);
			this.addAction = new global::Gtk.Action ("addAction", global::Mono.Unix.Catalog.GetString ("_Nuevo"), null, "gtk-add");
			this.addAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Nuevo");
			w1.Add (this.addAction, null);
			this.NewEnrollmentAction = new global::Gtk.Action ("NewEnrollmentAction", global::Mono.Unix.Catalog.GetString ("Inscripción"), null, null);
			this.NewEnrollmentAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Inscripción");
			w1.Add (this.NewEnrollmentAction, null);
			this.NewClientAction = new global::Gtk.Action ("NewClientAction", global::Mono.Unix.Catalog.GetString ("Cliente"), null, null);
			this.NewClientAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Cliente");
			w1.Add (this.NewClientAction, null);
			this.QuitAction = new global::Gtk.Action ("QuitAction", global::Mono.Unix.Catalog.GetString ("_Salir"), null, "gtk-cancel");
			this.QuitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Cancel");
			w1.Add (this.QuitAction, null);
			this.EditarAction = new global::Gtk.Action ("EditarAction", global::Mono.Unix.Catalog.GetString ("Editar"), null, null);
			this.EditarAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Editar");
			w1.Add (this.EditarAction, null);
			this.ConfigAction = new global::Gtk.Action ("ConfigAction", global::Mono.Unix.Catalog.GetString ("Configuración"), null, "gtk-preferences");
			this.ConfigAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Configuración");
			w1.Add (this.ConfigAction, null);
			this.CatlogosAction = new global::Gtk.Action ("CatlogosAction", global::Mono.Unix.Catalog.GetString ("Catálogos"), null, null);
			this.CatlogosAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Catálogos");
			w1.Add (this.CatlogosAction, null);
			this.dndMultipleAction = new global::Gtk.Action ("dndMultipleAction", global::Mono.Unix.Catalog.GetString ("Catálogos"), null, "gtk-dnd-multiple");
			this.dndMultipleAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Catálogos");
			w1.Add (this.dndMultipleAction, null);
			this.AreasAction = new global::Gtk.Action ("AreasAction", global::Mono.Unix.Catalog.GetString ("Áreas"), null, null);
			this.AreasAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Áreas");
			w1.Add (this.AreasAction, null);
			this.PacksAction = new global::Gtk.Action ("PacksAction", global::Mono.Unix.Catalog.GetString ("Paquetes"), null, null);
			this.PacksAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Paquetes");
			w1.Add (this.PacksAction, null);
			this.ClientsAction = new global::Gtk.Action ("ClientsAction", global::Mono.Unix.Catalog.GetString ("Clientes"), null, null);
			this.ClientsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Clientes");
			w1.Add (this.ClientsAction, null);
			this.MembersAction = new global::Gtk.Action ("MembersAction", global::Mono.Unix.Catalog.GetString ("Miembros"), null, null);
			this.MembersAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Miembros");
			w1.Add (this.MembersAction, null);
			this.AyudaAction = new global::Gtk.Action ("AyudaAction", global::Mono.Unix.Catalog.GetString ("Ayuda"), null, null);
			this.AyudaAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Ayuda");
			w1.Add (this.AyudaAction, null);
			this.infoAction = new global::Gtk.Action ("infoAction", global::Mono.Unix.Catalog.GetString ("Acerca de"), null, "gtk-info");
			this.infoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Acerca de");
			w1.Add (this.infoAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "omarkhd.Gymk.GymkWindow";
			this.Title = "";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child omarkhd.Gymk.GymkWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar2'><menu name='ArchivoAction' action='ArchivoAction'><menu name='addAction' action='addAction'><menuitem name='NewEnrollmentAction' action='NewEnrollmentAction'/><menuitem name='NewClientAction' action='NewClientAction'/></menu><menuitem name='QuitAction' action='QuitAction'/></menu><menu name='EditarAction' action='EditarAction'><menu name='dndMultipleAction' action='dndMultipleAction'><menuitem name='AreasAction' action='AreasAction'/><menuitem name='PacksAction' action='PacksAction'/><menuitem name='ClientsAction' action='ClientsAction'/><menuitem name='MembersAction' action='MembersAction'/></menu><menuitem name='ConfigAction' action='ConfigAction'/></menu><menu name='AyudaAction' action='AyudaAction'><menuitem name='infoAction' action='infoAction'/></menu></menubar></ui>");
			this.menubar2 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar2")));
			this.menubar2.Name = "menubar2";
			this.vbox2.Add (this.menubar2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.menubar2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 451;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
