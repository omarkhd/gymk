using System;
using Gtk;

namespace omarkhd.Gymk
{
	public class DateWidget
	{
		public event EventHandler Changed;
		
		private SpinButton YearSpin;
		private ComboBox MonthCombo;
		private SpinButton DaySpin;
		private DateTime _Date;
		public DateTime Date
		{
			get { return this._Date; }
			set
			{
				if(value != null)
				{
					this._Date = value;
					this.Init();
				}
			}
		}
		public DateWidget(int year, int month, int day) : this(new DateTime(year, month, day)) {}
		public DateWidget() : this(DateTime.Today) {}	
		public DateWidget(DateTime date)
		{
			this._Date = date;
			this.Build();
			this.Init();
			this.Connect();
		}
		
		private void Build()
		{
			this.YearSpin = new SpinButton(1900, 2100, 1);
			this.MonthCombo = new ComboBox(SpDate.GetMonthNames());
			this.DaySpin = new SpinButton(1, DateTime.DaysInMonth(this.Date.Year, this.Date.Month), 1);
		}
		
		private void Init()
		{
			try
			{
				this.YearSpin.Value = this.Date.Year;
				this.MonthCombo.Active = this.Date.Month - 1;
				this.DaySpin.Value = this.Date.Day;
			}
			
			catch(Exception) {}
		}
		
		private void UpdateDate(object sender, EventArgs args)
		{
			this.UpdateMonth();
			int year = this.YearSpin.ValueAsInt;
			int month = SpDate.GetMonthNumber(this.MonthCombo.ActiveText);
			int day = this.DaySpin.ValueAsInt;
			
			this._Date = new DateTime(year, month, day);
			
			if(this.Changed != null)
				this.Changed(sender, args);
		}
		
		private void UpdateMonth()
		{
			int year = this.YearSpin.ValueAsInt;
			int month = SpDate.GetMonthNumber(this.MonthCombo.ActiveText);
			int day = this.DaySpin.ValueAsInt;
			int in_month = DateTime.DaysInMonth(year, month);
			this.DaySpin.SetRange(1, DateTime.DaysInMonth(year, month));
			this.DaySpin.Value = (day > in_month ? in_month : day);
		}
		
		private void Connect()
		{
			this.YearSpin.Changed += this.UpdateDate;
			this.MonthCombo.Changed += this.UpdateDate;
			this.DaySpin.Changed += this.UpdateDate;
		}
		
		private string[] GetDaysArray()
		{
			int days = DateTime.DaysInMonth(this.Date.Year, this.Date.Month);
			string[] days_a = new string[days];
			for(int i = 0; i < days; days_a[i++] = i.ToString());
			return days_a;
		}
		
		public HBox Box
		{
			get
			{
				HBox box = new HBox();
				box.PackStart(this.DaySpin);
				box.PackStart(this.MonthCombo);
				box.PackStart(this.YearSpin);
				return box;
			}
		}
	}
}

