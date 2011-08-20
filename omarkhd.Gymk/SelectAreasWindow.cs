using System;
using Gtk;
using System.Data;
using omarkhd.DataStructures;

namespace omarkhd.Gymk
{
	public partial class SelectAreasWindow : Gtk.Window
	{
		private IList<long> SelectedIds;
		public SelectAreasWindow(IList<long> list) : base(Gtk.WindowType.Toplevel)
		{
			this.SelectedIds = list;
			this.Build();
			this.CustomBuild();
			this.Fill();
			this.Connect();
		}
		
		private void Connect()
		{
			this.OkButton.Clicked += (object sender, EventArgs args) => this.Destroy();
		}
		
		private void CustomBuild()
		{
			this.Modal = true;
			
			CellRendererToggle cr = new CellRendererToggle();
			cr.Activatable = true;
			cr.Toggled += this.DoToggle;
			this.AreasTreeView.AppendColumn("¿?", cr, "active", 0);
			this.AreasTreeView.AppendColumn("Area", new CellRendererText(), "text", 1);
		}
		
		private void Fill()
		{
			ListStore store = new ListStore(typeof(bool), typeof(string), typeof(long));
			
			AreaModel m = new AreaModel();
			IDataReader reader = m.GetAll();
			
			Area area = null;
			while(reader.Read())
			{
				area = new Area();
				area.Id = (long) reader["Id"];
				area.Name = (string) reader["Name"];
				bool selected = this.SelectedIds.Contains(area.Id);
				store.AppendValues(selected, area.Name, area.Id);
			}
			
			this.AreasTreeView.Model = store;			
			this.AreasTreeView.ShowAll();
		}
		
		private void DoToggle(object sender, ToggledArgs args)
		{
			ListStore store = (ListStore) this.AreasTreeView.Model;
			TreePath path = new TreePath(args.Path);
			TreeIter iter;
			if(store.GetIter(out iter, path))
			{
				bool old_value = (bool) store.GetValue(iter, 0);
				long area_id = (long) store.GetValue(iter, 2);
				if(old_value)
					this.SelectedIds.Remove(area_id);
				else
					this.SelectedIds.Add(area_id);				
				store.SetValue(iter, 0, !old_value);
			}
		}
	}
}

