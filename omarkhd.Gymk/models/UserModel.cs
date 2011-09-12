using System;
namespace omarkhd.Gymk
{
	public class UserModel : DbModel
	{
		public UserModel() : base("User")
		{
		}
		
		public long ActiveAdmins
		{
			get
			{
				string sql = "select count(*) from " + this.TableName;
				sql += " where Admin = @p0 and Active = @p1";
				return (long) this.DoScalar(sql, true, true);
			}
		}
		
		public bool Insert(User user)
		{
			return this.Insert(null, user.Alias, user.Password, user.Name, user.Admin, user.Active);
		}
		
		public static User FromId(long id)
		{
			UserModel model = new UserModel();
			User user = null;
			System.Data.IDataReader reader = model.GetById(id);
			if(reader.Read())
			{
				user.Id = id;
				user.Name = (string) reader["Name"];
				user.Alias = (string) reader["Alias"];	
				user.Password = (string) reader["Password"];
				user.Active = (bool) reader["Active"];
				user.Admin = (bool) reader["Admin"];
			}
			
			return user;
		}
	}
}

