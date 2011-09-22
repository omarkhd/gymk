using System;
using System.Data;
using System.Threading;

namespace omarkhd.Gymk
{
	public class PaymentScanThread
	{
		public Thread InnerThread { get; private set; }
		private StartLoader Loader;
		
		public PaymentScanThread(StartLoader loader)
		{
			this.Loader = loader;
			this.InnerThread = new Thread(this.Scan);
		}
		
		private void Scan()
		{
			this.Loader.Update(0, "Comenzando...");
			
			MemberModel mm = new MemberModel();
			long members = mm.Count();
			double step = 100.0 / members;
			double real_percent = 0.0;
			int percent = 0;
			IDataReader reader = mm.GetAll();
			
			while(reader.Read())
			{
				real_percent += step;
				percent = (int) real_percent;
				Thread.Sleep(5);
				this.Loader.Update(percent, percent + "%");
				
				Console.Out.WriteLine(reader["Height"] + ", " + reader["Weight"]);
				
				while(Gtk.Application.EventsPending())
					Gtk.Application.RunIteration();
			}
			
			this.Loader.Update(100, "Iniciando...");
			while(Gtk.Application.EventsPending())
				Gtk.Application.RunIteration();
			Thread.Sleep(500);
			
			this.Loader.Success();
			this.Loader.Destroy();
		}
		
		public void Launch()
		{
			this.InnerThread.Start();
		}
	}
}

