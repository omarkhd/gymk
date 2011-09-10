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
	}
}

