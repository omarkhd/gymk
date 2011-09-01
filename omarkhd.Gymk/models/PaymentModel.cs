using System;
namespace omarkhd.Gymk
{
	public class PaymentModel : DbModel
	{
		public PaymentModel() : base("Payment")
		{
		}
		
		public bool Insert(float amount, float discount)
		{
			string sql = "insert into " + this.TableName + " values";
			sql += "(null, @p0, @p1, @p2)";
			string date_of = DateTime.Now.ToString("yyyy-MM-dd");
			return ((long) this.DoNonQuery(sql, date_of, amount, discount)) > 0;
		}
		
		public bool Insert(Payment p)
		{
			return this.Insert(p.Amount, p.Discount);
		}
	}
}

