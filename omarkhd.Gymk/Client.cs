using System;
namespace omarkhd.Gymk
{
	public class Client
	{
		public string Name = string.Empty;
		public string Surname = string.Empty;
		public string Address = string.Empty;
		public string PhoneNumber = string.Empty;
		public string Email = string.Empty;
		public long Id;
		//public string PictureFileName = string.Empty;
		
		public Client ()
		{
		}
		
		public override string ToString ()
		{
			string ln = Environment.NewLine;
			string str = string.Empty;
			str += (string.IsNullOrEmpty(this.Name) ? "" : "Nombre: " + this.Name + " " + this.Surname);
			str += (string.IsNullOrEmpty(this.PhoneNumber) ? "" : ln + "Teléfono: " + this.PhoneNumber);
			str += (string.IsNullOrEmpty(this.Address) ? "" : ln + "Dirección: " + this.Address);
			str += (string.IsNullOrEmpty(this.Email) ? "" : ln + "Correo electrónico: " + this.Email);
			return str;
		}
	}
}

