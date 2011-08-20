using System;
using System.Data;
using Gtk;

namespace omarkhd.Gymk
{
	public partial class AreasWindow : Gtk.Window
	{
		private CrudState CrudOp;
		private Area CurrentArea;
		
		public AreasWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.CustomBuild();
			this.Connect();
		}
		
		private void CustomBuild()
		{
			this.AreasNodeView.AppendColumn("Nombre", new CellRendererText(), "text", 0);
			this.InitState();
		}
		
		private void InitState()
		{
			this.AreaEntry.Sensitive = false;
			this.OkButton.Sensitive = false;
			this.CancelButton.Sensitive = false;
			this.DeleteButton.Sensitive = false;
			this.EditButton.Sensitive = false;
			this.AddButton.Sensitive = true;
			this.CrudOp = CrudState.None;
			this.AreaEntry.Text = "";
			this.FillNodeView();
			this.AreasNodeView.Sensitive = true;
		}
		
		private void Connect()
		{
			this.OkButton.Clicked += this.DoOk;
			this.CancelButton.Clicked += this.DoCancel;
			this.AreasNodeView.CursorChanged += this.SelectCurrent;
			this.DeleteButton.Clicked += this.DoDelete;
			this.AddButton.Clicked += this.DoNew;
			this.EditButton.Clicked += this.DoEdit;
		}
		
		private void DoEdit(object sender, EventArgs args)
		{
			this.CrudOp = CrudState.Update;
			this.EditMode();
		}
		
		private void DoNew(object sender, EventArgs args)
		{
			this.CrudOp = CrudState.Create;
			this.EditMode();
		}
		
		private void EditMode()
		{
			this.AreaEntry.Sensitive = true;
			this.OkButton.Sensitive = true;
			this.CancelButton.Sensitive = true;
			this.AreaEntry.HasFocus = true;
			this.AddButton.Sensitive = false;
			this.DeleteButton.Sensitive = false;
			this.EditButton.Sensitive = false;
			this.AreasNodeView.Sensitive = false;
		}
		
		private void SelectCurrent(object sender, EventArgs args)
		{
			this.CurrentArea = (Area) this.AreasNodeView.NodeSelection.SelectedNode;
			this.DeleteButton.Sensitive = true;
			this.EditButton.Sensitive = true;
			this.AreaEntry.Text = this.CurrentArea.Name;
		}
		
		private void DoOk(object sender, EventArgs args)
		{
			switch(this.CrudOp)
			{
				case CrudState.Create:
					this.AddArea(this.AreaEntry.Text.Trim());
					break;
					
				case CrudState.Update:
					this.UpdateArea();
					break;
			}
		}
		
		private void DoCancel(object sender, EventArgs args)
		{
			this.InitState();	
		}
		
		private void AddArea(string area)
		{
			AreaModel m = new AreaModel();
			if(m.Exists(area))
			{
				GuiHelper.ShowError(this, "Ya existe el área que desea agregar");
				this.EditMode();
				return;
			}
			
			bool success = m.Insert(area);
			if(success)
				this.InitState();
			
			else
				GuiHelper.ShowUnexpectedError(this);
		}
		
		private void UpdateArea()
		{
			Area a = this.GetAreaFromUI();
			a.Id = this.CurrentArea.Id;
			AreaModel m = new AreaModel();

			if(m.Update(a))
				this.InitState();
			else if(m.ExistsExcept(a))
				GuiHelper.ShowError(this, "Ya existe un área del gimnasio con el mismo nombre");
			else
				GuiHelper.ShowUnexpectedError(this);
		}
		
		private void DoDelete(object sender, EventArgs args)
		{
			//we have to check if the area is used in a pack
			//before deleting... pending
			AreaModel m = new AreaModel();
			if(m.DeleteById(this.CurrentArea.Id))
				this.InitState();
			else
				GuiHelper.ShowUnexpectedError(this);
		}
		
		private void FillNodeView()
		{
			NodeStore store = new NodeStore(typeof (Area));
			
			AreaModel m = new AreaModel();
			IDataReader reader = m.GetAll();
			
			Area a = null;
			while(reader.Read())
			{
				a = new Area();
				a.Id = (long) reader["Id"];
				a.Name = (string) reader["Name"];
				store.AddNode(a);
			}			
			
			this.AreasNodeView.NodeStore = store;
			this.AreasNodeView.ShowAll();
		}
		
		private Area GetAreaFromUI()
		{
			Area a = new Area();
			a.Name = this.AreaEntry.Text.Trim();
			return a;
		}
	}
}