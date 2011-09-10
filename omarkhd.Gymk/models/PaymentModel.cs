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
			sql += "(null, @p0, @p1, @p2, @p3)";
			string date_of = DateTime.Now.ToString("yyyy-MM-dd");
			long user_id = (long) SessionRegistry.GetInstance()["user_id"];
			object id_to_db = null;
			if(user_id != 0)
				id_to_db = user_id;
			return ((long) this.DoNonQuery(sql, date_of, amount, discount, id_to_db)) > 0;
		}
		
		public bool Insert(Payment p)
		{
			return this.Insert(p.Amount, p.Discount);
		}
	}
}

