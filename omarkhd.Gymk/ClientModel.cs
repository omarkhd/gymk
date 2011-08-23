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
		
		public IDataReader GetAllLike(object key)
		{
			string like = "'%" + key + "%'";
			string sql = "select * from " + this.TableName;
			sql += " where Id like " + like + " or Name like " + like + " or Surname like " + like;
			return this.DoReader(sql);
		}
		
		public bool Update(Client c)
		{
			string sql = "update Client set Name = '" + c.Name + "', ";
			sql += "Surname = '" + c.Surname + "', Address = '" + c.Address + "', ";
			sql += "PhoneNumber = '" + c.PhoneNumber + "', Email = '" + c.Email + "' ";
			sql += "where " + this.IdName + " = '" + c.Id + "'";
			return this.DoNonQuery(sql) > 0;
		}
	}
}

