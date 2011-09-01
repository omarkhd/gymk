using System;
using System.Data;

namespace omarkhd.Gymk
{
	public class MemberModel : DbModel
	{
		public MemberModel() : base("Member")
		{
		}
		
		public bool Insert(Member m)
		{
			long id = m.InnerClient.Id;
			object contact = (m.InnerContact.Id == 0 ? null : (object) m.InnerContact.Id);
			string bd = m.BirthDate.ToString("yyyy-MM-dd");
			string jd = m.JoinDate.ToString("yyyy-MM-dd");
			return base.Insert(id, true, m.Height, m.Weight, m.Gender, bd, m.PaymentDay, jd, m.Pack, contact, null);
		}
		
		public static Member FromId(long id)
		{
			MemberModel mm = new MemberModel();
			IDataReader r = mm.GetById(id);
			Member m = null;
			if(r.Read())
			{
				m = new Member();
				m.Active = (bool) r["Active"];
				m.Height = (float) r["Height"];
				m.Weight = (float) r["Weight"];
				m.Gender = (char) (int.Parse((string) r["Gender"]));
				//Console.Out.WriteLine(m.Gender);
				m.BirthDate = (DateTime) r["BirthDate"];
				m.PaymentDay = (int) ((long) r["PaymentDay"]);
				m.JoinDate = (DateTime) r["JoinDate"];
				m.Pack = (long) r["Pack"];
				m.InnerClient = new Client();
				m.InnerClient.Id = id;
				m.InnerClient.Sync();
			}
			
			return m;
		}
	}
}