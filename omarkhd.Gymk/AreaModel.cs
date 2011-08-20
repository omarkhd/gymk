using System;
namespace omarkhd.Gymk
{
	public class AreaModel : DbModel
	{
		public AreaModel() : base("Area") {}
		
		public bool Insert(string area)
		{
			return this.Insert(null, area);
		}
		
		public bool Exists(string area)
		{
			string sql = "select count(*) from " + this.TableName;
			sql += " where Name = '" + area + "'";
			return ((long) this.DoScalar(sql)) > 0;
		}
		
		public bool Update(Area area)
		{
			string sql = "update " + this.TableName;
			sql += " set Name = '" + area.Name + "'";
			sql += " where Id = '" + area.Id + "'";
			return ((long) this.DoNonQuery(sql)) > 0;
		}
		
		public bool ExistsExcept(Area a)
		{
			string sub_query = "(select * from " + this.TableName;
			sub_query += " where " + this.IdName + " != '" + a.Id + "') a";
			string sql = "select count(*) from " + sub_query + " where a.Name = '" + a.Name + "'";
			return ((long) this.DoScalar(sql)) > 0;
		}
	}
}

