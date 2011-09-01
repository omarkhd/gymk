using System;

namespace omarkhd.Gymk
{
	public class PaymentRuler
	{
		public static void ChargeMonth(Member m, int month, int year)
		{
			m.Sync();
			DateTime s = PaymentRuler.ComputeStartDate(m, month, year);
			DateTime e = PaymentRuler.ComputeEndDate(m, month, year);
			
			MonthlyChargeModel mcm = new MonthlyChargeModel();
			if(!mcm.Exists(m, s))
				mcm.Insert(m, s, e);
		}
		
		public static void ChargeMonth(Member m)
		{
			PaymentRuler.ChargeMonth(m, DateTime.Today.Month, DateTime.Today.Year);
		}
		
		public static void ChargeFirstMonth(Member m)
		{
			m.Sync();
			int month = DateTime.Now.Month;
			int year = DateTime.Now.Year;
			DateTime s = PaymentRuler.ComputeStartDate(m, month, year);
			DateTime e = PaymentRuler.ComputeEndDate(m, month, year);
			
			MonthlyChargeModel mcm = new MonthlyChargeModel();
			mcm.Insert(m, s, e);
			
			if(!m.ChargeFirstMonth)
			{
				Payment p = new Payment();
				p.Amount = 0;
				p.Discount = 0;
				PaymentModel pm = new PaymentModel();
				pm.Insert(p);
				p.Id = pm.LastInsertId;
				mcm.UpdatePaymentOf(m, s, p);
			}
		}
		
		private static DateTime ComputeStartDate(Member m, int month, int year)
		{
			DateTime start_date;
			int day_to_pay = m.PaymentDay;
			int last_day_of_month = DateTime.DaysInMonth(year, month);
			
			if(day_to_pay > last_day_of_month)
				start_date = new DateTime(year, month, last_day_of_month).AddDays(day_to_pay - last_day_of_month);
			else
				start_date = new DateTime(year, month, day_to_pay);
			
			Console.Out.WriteLine(start_date);
			return start_date;		
		}
		
		private static DateTime ComputeEndDate(Member m, int month, int year)
		{
			DateTime from_date = new DateTime(year, month, 1).AddMonths(1);
			DateTime next_start_date = PaymentRuler.ComputeStartDate(m, from_date.Month, from_date.Year);
			Console.WriteLine(next_start_date.AddDays(-1));
			return next_start_date.AddDays(-1);
		}
	}
}

