using System;
using System.Data;

namespace omarkhd.Gymk
{
	public class ClientModel : DbModel
	{
		public ClientModel() : base("Client")
		{
		}
		
		public bool Insert(Client c)
		{
			return this.Insert(null, c.Name, c.Surname, c.Address, c.PhoneNumber, c.Email);
		}
		
		public bool Exists(Client c)
		{
			string sql = "select count(*) from " + this.TableName;
			sql += " where Name = '" + c.Name + "' and Surname = '" + c.Surname + "'";
			return (((long) this.DoScalar(sql)) > 0 ? true : false);
		}
		
		public IDataReader GetNonMembers()
		{
			string sql = "select c.* from " + this.TableName + " c";
			sql += " left outer join Member m on c.Id = m.Id where m.Id is null";
			return this.DoReader(sql);
		}
	}
}

