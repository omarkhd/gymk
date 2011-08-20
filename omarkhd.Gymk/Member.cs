using System;
namespace omarkhd.Gymk
{
	public class Member
	{
		public Client InnerClient;
		public Contact InnerContact;
		public DateTime BirthDate;
		public DateTime JoinDate;
		
		public int PaymentDay;
		public byte[] BinImage;
		public double Height;
		public double Weight;
		public char Gender;	
		public long Pack;
		
		public Member()
		{
		}
		
		public override string ToString ()
		{
			string str = string.Empty;
			str += "Estatura: " + this.Height + " Mts., ";
			str += "Peso: " + this.Weight + " Kg., ";
			str += "Sexo: " + this.Gender.ToString().ToUpper();
			str += "\nFecha de nacimiento: " + this.BirthDate.ToString();
			
			return str;
		}
	}
}

