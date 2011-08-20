using System;
namespace omarkhd.Gymk
{
	public class SpDate
	{
		public SpDate()
		{
		}
		
		public static string GetMonthName(int month)
		{
			if(month == 1)
				return "Enero";
			else if(month == 2)
				return "Febrero";
			else if(month == 3)
				return "Marzo";
			else if(month == 4)
				return "Abril";
			else if(month == 5)
				return "Mayo";
			else if(month == 6)
				return "Junio";
			else if(month == 7)
				return "Julio";
			else if(month == 8)
				return "Agosto";
			else if(month == 9)
				return "Septiembre";
			else if(month == 10)
				return "Octubre";
			else if(month == 11)
				return "Noviembre";
			else if(month == 12)
				return "Diciembre";
			
			return "";
		}
		
		public static int GetMonthNumber(string month)
		{
			if(month.ToLower() == "enero")
				return 1;
			if(month.ToLower() == "febrero")
				return 2;
			if(month.ToLower() == "marzo")
				return 3;
			if(month.ToLower() == "abril")
				return 4;
			if(month.ToLower() == "mayo")
				return 5;
			if(month.ToLower() == "junio")
				return 6;
			if(month.ToLower() == "julio")
				return 7;
			if(month.ToLower() == "agosto")
				return 8;
			if(month.ToLower() == "septiembre")
				return 9;
			if(month.ToLower() == "octubre")
				return 10;
			if(month.ToLower() == "noviembre")
				return 11;
			if(month.ToLower() == "diciembre")
				return 12;
			
			return 0;
		}
		
		public static string[] GetMonthNames()
		{
			return new string[]
			{
				"Enero",
				"Febrero",
				"Marzo",
				"Abril",
				"Mayo",
				"Junio",
				"Julio",
				"Agosto",
				"Septiembre",
				"Octubre",
				"Noviembre",
				"Diciembre"
			};
		}
	}
}

