using System;
using System.Data;
using omarkhd.DataStructures;

namespace omarkhd.Gymk
{
	public class PackModel : DbModel
	{
		public PackModel() : base("Pack")
		{
		}
		
		public bool Insert(Pack p)
		{
			return this.Insert(null, p.Name, p.Price, p.Membership);
		}
		
		public bool Exists(Pack p)
		{
			string sql = "select count(*) from " + this.TableName;
			sql += " where Name = @p0"; //+ p.Name + "'";
			return ((long) this.DoScalar(sql, p.Name)) > 0;
		}
		
		public bool ExistsExcept(Pack p)
		{
			string sql = "select count(*) from ";
			sql += "(select * from " + this.TableName + " where " + this.IdName + " != @p0)"; //+ p.Id + "')";
			sql += " a where a.Name = @p1"; //+ p.Name + "'";
			return ((long) this.DoScalar(sql, p.Id, p.Name)) > 0;
		}
		
		public bool Update(Pack p)
		{
			string sql = "update " + this.TableName + " set Name = @p0"; //+ p.Name + "'";
			sql += ", Price = @p1, Membership = @p2 ";
			sql += "where " + this.IdName + " = @p3"; //+ p.Id;
			return ((long) this.DoNonQuery(sql, p.Name, p.Price, p.Membership, p.Id)) > 0;
		}
		
		public IDataReader GetAreas(Pack p)
		{
			string sql = "select a.* from Area a inner join PackArea pa on a.Id = pa.Area ";
			sql += "where pa.Pack = @p0"; //+ p.Id + "'";
			return this.DoReader(sql, p.Id);
		}
		
		public int InsertAreas(Pack p)
		{
			IList<long> list = p.Areas;
			if(list == null || list.Length == 0)
				return 0;
			
			int inserted = 0;
			DbModel model = new DbModel("PackArea", null);
			for(int i = 0; i < list.Length; i++)
				inserted += (model.Insert(p.Id, list[i]) ? 1 : 0);
			 return inserted;
		}
		
		public long DeleteAreas(Pack p)
		{
			DbModel model = new DbModel("PackArea", null);
			return model.DeleteBy("Pack", p.Id);
		}
	}
}

