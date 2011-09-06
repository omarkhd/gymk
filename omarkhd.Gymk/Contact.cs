using System;
using System.Data;

namespace omarkhd.Gymk
{
	public class Contact
	{
		public long Id;
		public string Name;
		public string PhoneNumber;
		
		public Contact()
		{
		}
		
		public bool Sync()
		{
			DbModel m = new DbModel("Contact");
			IDataReader r = m.GetById(this.Id);
			bool success = false;
				
			if(r.Read())
			{
				this.Name = (string) r["Name"];
				this.PhoneNumber = r["PhoneNumber"].ToString();
				success = true;
			}
			
			return success;
		}
	}
}

