using System;
using Gdk;
using Gtk;

namespace omarkhd.Gymk
{
	public delegate void WizardHandler();
	public delegate void WizardSuccessHandler(object target);
	
	public partial class Wizard : Gtk.Window
	{
		public static readonly string DefaultImage;
		public static readonly string DefaultHeader;
		public static readonly string DefaultDescription;
		public static readonly string DefaultTitle;
		
		static Wizard()
		{
			DefaultImage = "default_wizard_image.png";
			DefaultHeader = "Bienvenido al asistente personalizado";
			DefaultDescription = "Este asistente te ayudará a ejecutar esta tarea de una manera más fácil e intuitiva.";
			DefaultTitle = "Asistente";
		}
		
		//making some ui elements available to inherited classes
		protected Button NextButton { get { return this._NextButton; }}
		protected Button PreviousButton { get { return this._PreviousButton; }}
		protected string WelcomeHeader;
		protected string WelcomeDescription;
		public VBox ContentVBox
		{
			get { return this._ContentVBox; }
			private set { this._ContentVBox = value; }
		}
		
		//events
		protected event WizardHandler NextEvent;
		protected event WizardHandler PreviousEvent;
		public event WizardHandler CancelEvent;
		public event WizardSuccessHandler SuccessEvent;
		
		public Wizard() : this(Wizard.DefaultTitle, Wizard.DefaultHeader, Wizard.DefaultDescription) {}		
		public Wizard(string title, string welcome_header, string welcome_description) : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.CustomBuild();
			this.Title = title;
			this.WelcomeHeader = welcome_header;
			this.WelcomeDescription = welcome_description;
			this.Connect();
		}
		
		public void Run() //not a blocking Run(), like Gtk.Dialog
		{		
			this.Init();
			this.ShowAll();
		}
		
		public virtual void Init()
		{
			this.Header = this.WelcomeHeader;
			this.Description = this.WelcomeDescription;
			this.PreviousButton.Sensitive = false;
			this.NextLabel = "Siguiente";
			this.ClearContentBox();
		}
		
		private void Next()
		{
			if(this.NextEvent != null)
				this.NextEvent();
		}
		
		private void Previous()
		{
			if(this.PreviousEvent != null)
				this.PreviousEvent();
		}
		
		private void Cancel()
		{
			if(this.CancelEvent != null)
				this.CancelEvent();
		}
		
		protected void Success(object target)
		{
			if(this.SuccessEvent != null)
				this.SuccessEvent(target);
		}
		
		public void ClearContentBox()
		{
			Widget[] widgets = this.ContentVBox.Children;
			foreach(Widget w in widgets)
			{
				//AppHelper.Log("deleting " + w);
				this.ContentVBox.Remove(w);
				//w.HideAll();
			}
			this.ContentVBox.ShowAll();
		}
		
		private void CustomBuild()
		{
			//Window
			this.Modal = true;
			this.SidebarImage = Wizard.DefaultImage;
			//DescriptionLabel
			this.DescriptionLabel.Wrap = true;
			this.DescriptionLabel.Justify = Gtk.Justification.Center;
			//HeaderLabel
			this.HeaderLabel.Justify = Gtk.Justification.Center;
			this.HeaderLabel.Wrap = true;
		}
		
		public string Description
		{
			get
			{
				return this.DescriptionLabel.Text;
			}
			
			set
			{
				this.DescriptionLabel.Markup = "<b>" + value + "</b>";
			}			
		}
		
		public string Header
		{
			get
			{
				return this.HeaderLabel.Text;
			}
			
			set
			{
				this.HeaderLabel.Text = "<b>" + value + "</b>";
				this.HeaderLabel.UseMarkup = true;
			}
		}
		
		protected string SidebarImage
		{
			get
			{
				return this._SidebarImage.Pixbuf.ToString();
			}
			
			set
			{
				try
				{
					this._SidebarImage.Pixbuf = new Pixbuf(null, value);
				}
			
				catch
				{
					AppHelper.Log("could not find resource '" + value + "'");
					this._SidebarImage.Pixbuf = new Pixbuf(null, Wizard.DefaultImage);
				}
			}
		}
		
		private void Connect()
		{
			this.NextButton.Clicked += (object sender, EventArgs args) => this.Next();
			this.PreviousButton.Clicked += (object sender, EventArgs args) => this.Previous();
			
			//ask before closing, and if closing, send a CancelEvent signal
			this.DeleteEvent += (object sender, DeleteEventArgs args) =>
			{
				MessageDialog dlg = new MessageDialog
				(
					this,
					DialogFlags.Modal,
					MessageType.Question,
					ButtonsType.YesNo,
					"¿Está seguro que desea cerrar el asistente?"
				);
				
				ResponseType r = (ResponseType) dlg.Run();
				dlg.Destroy();
				
				if(r == ResponseType.No || r == ResponseType.DeleteEvent)
					args.RetVal = true; //prevent dialog from closing
				else				
					this.Cancel(); //signal the EventCancel
			};
		}
		
		protected bool CanGoNext
		{
			get { return this.NextButton.Sensitive; }
			set { this.NextButton.Sensitive = value; }
		}
		
		protected bool CanGoPrevious
		{
			get { return this.PreviousButton.Sensitive; }
			set { this.PreviousButton.Sensitive = value; }
		}
		
		protected string NextLabel
		{
			get { return this.NextButton.Label; }
			set { this.NextButton.Label = value; }
		}
		
		protected void PackWidgetPair(Widget w1, Widget w2, bool inversed)
		{
			HBox hbox = new HBox();
			hbox.WidthRequest = 300;
			w1.WidthRequest = (inversed ? 200 : 100);
			w2.WidthRequest = (inversed ? 100 : 200);
			
			Label label = w1 as Label;
			if(label != null)
			{
				label.Justify = Justification.Left;
				label.Wrap = true;
			}
			
			hbox.PackStart(w1, true, false, 0);
			hbox.PackStart(w2, true, false, 0);
			this.ContentVBox.PackStart(hbox, false, false, 0);
		}
		
		protected void PackWidgetPair(Widget w1, Widget w2)
		{
			this.PackWidgetPair(w1, w2, false);
		}
		
		protected void PackWidgetSingle(Widget w1)
		{
			HBox hbox = new HBox();
			hbox.WidthRequest = 300;
			w1.WidthRequest = 300;
			
			Label label = w1 as Label;
			if(label != null)
			{
				label.Justify = Gtk.Justification.Left;
				label.Wrap = true;
			}
			
			hbox.PackStart(w1, true, false, 0);
			this.ContentVBox.PackStart(hbox, false, false, 0);
		}
	}
}

