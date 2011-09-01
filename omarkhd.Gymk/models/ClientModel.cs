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
			sql += " where Name = @p0 and Surname = @p1";
			return (((long) this.DoScalar(sql, c.Name, c.Surname)) > 0 ? true : false);
		}
		
		public IDataReader GetNonMembers()
		{
			string sql = "select c.* from " + this.TableName + " c";
			sql += " left outer join Member m on c.Id = m.Id where m.Id is null";
			return this.DoReader(sql);
		}
		
		public IDataReader GetAllLike(object key)
		{
			string like = "%" + key + "%";
			string sql = "select * from " + this.TableName;
			sql += " where Id = @p0 or Name like @p1 or Surname like @p2";
			return this.DoReader(sql, key, like, like);
		}
		
		public bool Update(Client c)
		{
			string sql = "Update " + this.TableName + " set Name = @p0, ";
			sql += "Surname = @p1, Address = @p2, PhoneNumber = @p3, Email = @p4 ";
			sql += "where " + this.IdName + " = @p5";
			return this.DoNonQuery(sql, c.Name, c.Surname, c.Address, c.PhoneNumber, c.Email, c.Id) > 0;
		}
		
		public bool IsMember(Client c)
		{
			string sql = "select count(*) from Member where Id = @p0";
			return ((long) this.DoScalar(sql, c.Id)) > 0;
		}
		
		public static Client FromId(long id)
		{
			ClientModel cm = new ClientModel();
			IDataReader r = cm.GetById(id);
			Client c = null;
			if(r.Read())
			{
				c = new Client();
				c.Name = (string) r["Name"];
				c.Surname = (string) r["Surname"];
				c.Address = (string) r["Address"];
				c.PhoneNumber = r["PhoneNumber"].ToString();
				c.Email = (string) r["Email"];
				return c;
			}
			
			return c;
		}
	}
}

