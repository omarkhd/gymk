using System;
using Gtk;
using System.Data;
using omarkhd.DataStructures;

namespace omarkhd.Gymk
{
	public partial class PacksWindow : Gtk.Window
	{
		private SpinButton PaymentSpin;
		private SpinButton MembershipSpin;
		private Pack CurrentPack;
		private CrudState CrudOp;
		
		public PacksWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			this.CustomBuild();
			this.Connect();
			this.InitState();
			this.CrudOp = CrudState.None;
		}
		
		private void Connect()
		{
			this.PacksNodeView.CursorChanged += this.SelectCurrent;
			this.DeleteButton.Clicked += this.DoDelete;
			this.EditButton.Clicked += this.DoEdit;
			this.OkButton.Clicked += this.DoOk;
			this.CancelButton.Clicked += this.DoCancel;
			this.AddButton.Clicked += this.DoAdd;
			this.AreasButton.Clicked += this.DoSelectAreas;
		}
		
		private void SelectCurrent(object sender, EventArgs args)
		{
			this.CurrentPack = (Pack) this.PacksNodeView.NodeSelection.SelectedNode;
			Pack p = this.CurrentPack;
			this.NameEntry.Text = p.Name;
			this.PaymentSpin.Text = string.Format("{0:f2}", p.Price);
			this.MembershipSpin.Text = string.Format("{0:f2}", p.Membership);
			this.DeleteButton.Sensitive = true;
			this.EditButton.Sensitive = true;
		}
		
		private void CustomBuild()
		{
			this.PaymentSpin = new SpinButton(0, 1000, 0.01);
			this.MembershipSpin = new SpinButton(0, 1000, 0.01);
			this.SpinBox1.Add(this.PaymentSpin);
			this.SpinBox2.Add(this.MembershipSpin);
			
			this.PacksNodeView.AppendColumn("Nombre", new CellRendererText(), "text", 0);
			this.PacksNodeView.AppendColumn("Costo", new CellRendererText(), "text", 1);
			this.PacksNodeView.AppendColumn("Inscripción", new CellRendererText(), "text", 2);
			this.ShowAll();
			//this.SelectedAreas = new LinkedList<long>();
		}
		
		private void InitState()
		{
			this.NameEntry.Sensitive = false;
			this.AreasButton.Sensitive = false;
			this.PaymentSpin.Sensitive = false;
			this.MembershipSpin.Sensitive = false;
			this.OkButton.Sensitive = false;
			this.CancelButton.Sensitive = false;
			this.DeleteButton.Sensitive = false;
			this.EditButton.Sensitive = false;
			this.PacksNodeView.Sensitive = true;
			this.DeleteButton.Sensitive = false;
			this.EditButton.Sensitive = false;
			this.AddButton.Sensitive = true;
			this.NameEntry.Text = "";
			this.PaymentSpin.Text = "0.00";
			this.MembershipSpin.Text = "0.00";
			this.FillNodeView();
		}
		
		private void FillNodeView()
		{
			NodeStore store = new NodeStore(typeof(Pack));
			PackModel m = new PackModel();
			IDataReader reader = m.GetAll();
			Pack p = null;
			while(reader.Read())
			{
				p = new Pack();
				p.Id = (long) reader["Id"];
				p.Name = (string) reader["Name"];
				p.Price = (float) reader["Price"];
				p.Membership = (float) reader["Membership"];
				p.Areas = new LinkedList<long>();
				store.AddNode(p);
			}
			
			this.PacksNodeView.NodeStore = store;
			this.PacksNodeView.ShowAll();
		}
		
		private void DoDelete(object sender, EventArgs args)
		{
			PackModel m = new PackModel();
			if(m.DeleteById(this.CurrentPack.Id))
				this.InitState();
			else
				GuiHelper.ShowUnexpectedError(this);
		}
		
		private void EditMode()
		{
			this.NameEntry.Sensitive = true;
			this.PaymentSpin.Sensitive = true;
			this.MembershipSpin.Sensitive = true;
			this.AreasButton.Sensitive = true;
			this.OkButton.Sensitive = true;
			this.CancelButton.Sensitive = true;
			this.PacksNodeView.Sensitive = false;
			this.DeleteButton.Sensitive = false;
			this.EditButton.Sensitive = false;
			this.AddButton.Sensitive = false;
			
			this.NameEntry.HasFocus = true;
		}
		
		private void DoEdit(object sender, EventArgs args)
		{
			this.CrudOp = CrudState.Update;
			this.EditMode();
			
		}
		
		private void DoAdd(object sender, EventArgs args)
		{
			this.CurrentPack = new Pack();
			this.CrudOp = CrudState.Create;
			this.InitState();
			this.EditMode();
		}
		
		private void DoCancel(object sender, EventArgs args)
		{
			this.InitState();
		}
		
		private void DoOk(object sender, EventArgs args)
		{
			switch(this.CrudOp)
			{
				case CrudState.Create:
					this.AddPack();
					break;
				case CrudState.Update:
					this.EditPack();
					break;
			}
		}
		
		private void AddPack()
		{
			Pack p = GetPackFromUI();			
			p.Areas = this.CurrentPack.Areas;
			PackModel m = new PackModel();
			if(m.Exists(p))
				GuiHelper.ShowError(this, "Ya existe un paquete con el mismo nombre");
			
			else if(m.Insert(p))
			{
				p.Id = m.LastInsertId;
				m.InsertAreas(p);
				this.InitState();
			}
				
			else
				GuiHelper.ShowError(this, "error en la inserción");
			
		}
		
		private void EditPack() //pendiente por áreas
		{
			Pack p = GetPackFromUI();
			p.Id = this.CurrentPack.Id;
			p.Areas = this.CurrentPack.Areas;
			
			PackModel m = new PackModel();
			if(m.Update(p))
			{
				m.DeleteAreas(p);
				m.InsertAreas(p);	
				this.InitState();
			}
			else if(m.ExistsExcept(p))
				GuiHelper.ShowError(this, "Ya existe otro paquete con el mismo nombre");
			else
				GuiHelper.ShowUnexpectedError(this);
		}
		
		private Pack GetPackFromUI()
		{
			Pack p = new Pack();
			p.Name = this.NameEntry.Text.Trim();
			p.Price = float.Parse(this.PaymentSpin.Text);
			p.Membership = float.Parse(this.MembershipSpin.Text);
			return p;
		}
		
		private void DoSelectAreas(object sender, EventArgs args)
		{
			switch(this.CrudOp)
			{
				case CrudState.Update:
					if(this.CurrentPack.Areas == null)
						this.CurrentPack.Areas = new LinkedList<long>();
					PackModel model = new PackModel();
					IDataReader reader = model.GetAreas(this.CurrentPack);
					while(reader.Read())
					{
						long id = (long) reader["Id"];
						if(!CurrentPack.Areas.Contains(id))
							this.CurrentPack.Areas.Add(id);
					}
					break;
					
				case CrudState.Create:
					if(this.CurrentPack.Areas == null)
						this.CurrentPack.Areas = new LinkedList<long>();
					break;
			}
			
			SelectAreasWindow w = new SelectAreasWindow(this.CurrentPack.Areas);
			w.TransientFor = this;
			w.ShowAll();
		}
	}
}

