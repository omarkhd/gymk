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
			sql += " where Name = @p0";
			return ((long) this.DoScalar(sql, area)) > 0;
		}
		
		public bool Update(Area area)
		{
			string sql = "update " + this.TableName;
			sql += " set Name = @p0"; //+ area.Name + "'";
			sql += " where Id = @p1"; //+ area.Id + "'";
			return ((long) this.DoNonQuery(sql, area.Name, area.Id)) > 0;
		}
		
		public bool ExistsExcept(Area a)
		{
			string sub_query = "(select * from " + this.TableName;
			sub_query += " where " + this.IdName + " != @p0) a"; //+ a.Id + "') a";
			string sql = "select count(*) from " + sub_query + " where a.Name = @p1"; //+ a.Name + "'";
			return ((long) this.DoScalar(sql, a.Id, a.Name)) > 0;
		}
	}
}

