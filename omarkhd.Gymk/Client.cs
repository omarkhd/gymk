using System;
using Gtk;

namespace omarkhd.Gymk
{
	[TreeNode(ListOnly = true)]
	public class Client : TreeNode
	{
		public string Name = string.Empty;
		public string Surname = string.Empty;
		public string Address = string.Empty;
		public string PhoneNumber = string.Empty;
		public string Email = string.Empty;
		
		[TreeNodeValue(Column = 0)]
		public long Id;
		
		[TreeNodeValue(Column = 1)]
		public string FullName { get { return this.Name + " " + this.Surname; }}
		
		public Client ()
		{
		}
		
		public override string ToString ()
		{
			string ln = Environment.NewLine;
			string str = string.Empty;
			str += (string.IsNullOrEmpty(this.Name) ? "" : "Nombre: " + this.FullName);
			str += (string.IsNullOrEmpty(this.PhoneNumber) || this.PhoneNumber == "0" ? "" : ln + "Teléfono: " + this.PhoneNumber);
			str += (string.IsNullOrEmpty(this.Address) ? "" : ln + "Dirección: " + this.Address);
			str += (string.IsNullOrEmpty(this.Email) ? "" : ln + "Correo electrónico: " + this.Email);
			return str;
		}
		
		public bool Sync()
		{
			Client c = ClientModel.FromId(this.Id);
			if(c == null)
				return false;
			this.Name = c.Name;
			this.Surname = c.Surname;
			this.Address = c.Address;
			this.PhoneNumber = c.PhoneNumber;
			this.Email = c.Email;
			return true;
		}
	}
}

