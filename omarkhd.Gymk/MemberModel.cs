using System;

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
	}
}