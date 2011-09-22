using System;
using System.Threading;

namespace omarkhd.Gymk
{
	public delegate void LoaderHandler();
	
	public partial class StartLoader : Gtk.Window
	{
		public event LoaderHandler SuccessEvent;
			
		public StartLoader() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
		
		public void Success()
		{
			if(this.SuccessEvent != null)
				this.SuccessEvent();
		}
		
		public void Start()
		{
			this.ShowAll();
			PaymentScanThread thread = new PaymentScanThread(this);
			thread.Launch();
			thread.InnerThread.Join();
		}
		
		public void Update(int percent, string msg)
		{
			this.LoadBar.Fraction = percent / 100.0;
			this.MessageLabel.Text = msg;
		}
	}
}