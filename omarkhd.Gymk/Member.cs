using System;

namespace omarkhd.Gymk
{
	public class Member
	{
		public Client InnerClient;
		public Contact InnerContact;
		public DateTime BirthDate;
		public DateTime JoinDate;
		
		public long Id;	
		public int PaymentDay;
		public byte[] BinImage;
		public double Height;
		public double Weight;
		public char Gender;	
		public long Pack;
		public bool Active;
		
		public bool ChargeFirstMonth;
		public bool ChargeMembership;
		
		public Member()
		{
			this.ChargeFirstMonth = true;
			this.ChargeMembership = true;
		}
		
		public override string ToString ()
		{
			string str = string.Empty;
			str += "Estatura: " + string.Format("{0:#.##}", this.Height) + " Mts., ";
			str += "Peso: " + string.Format("{0:#.##}", this.Weight) + " Kg., ";
			str += "Sexo: " + this.Gender.ToString().ToUpper();
			str += "\nFecha de nacimiento: " + this.BirthDate.ToString("dd/MM/yyyy");
			
			return str;
		}
		
		public bool Sync()
		{
			Member m = MemberModel.FromId(this.Id);
			if(m == null)
				return false;
			this.InnerClient = m.InnerClient;
			this.BirthDate = m.BirthDate;
			this.JoinDate = m.JoinDate;
			this.PaymentDay = m.PaymentDay;
			this.Height = m.Height;
			this.Weight = m.Weight;
			this.Gender = m.Gender;
			this.Pack = m.Pack;
			this.Active = m.Active;
			return true;	
		}
	}
}

