using System;
using System.Data;

namespace omarkhd.Gymk
{
	public class MonthlyChargeModel : DbModel
	{
		public MonthlyChargeModel() : base("MonthlyCharge")
		{
		}
		
		public bool Insert(Member m, DateTime start, DateTime end)
		{
			string fmt = "yyyy-MM-dd";
			string _start = start.ToString(fmt);
			string _end = end.ToString(fmt);
			return base.Insert(m.Id, null, _start, _end, null);	
		}
		
		public bool Exists(Member m, DateTime start)
		{
			string sql = "select count(*) from " + this.TableName;
			sql += " where Member = @p0 and StartDate = @p1";
			return ((long) this.DoScalar(sql, m.Id, start.ToString("yyyy-MM-dd"))) > 0;
		}
		
		public bool UpdatePaymentOf(Member m, DateTime sd, Payment p)
		{
			string sql = "update " + this.TableName;
			sql += " set Payment = @p0";
			sql += " where Member = @p1 and StartDate = @p2";
			return (long) this.DoNonQuery(sql, p.Id, m.Id, sd.ToString("yyyy-MM-dd")) > 0;
		}
	}
}

