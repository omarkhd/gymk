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
				this._Date = value;
				this.Init();
			}
		}
		public DateWidget(int year, int month, int day) : this(new DateTime(year, month, day)) {}
		public DateWidget() : this(DateTime.Today) {}	
		public DateWidget(DateTime date)
		{
			this.Build();
			this.Date = date;
		}
		
		private void Build()
		{
			this.YearSpin = new SpinButton(1900, 2100, 1);
			this.MonthCombo = new ComboBox(SpDate.GetMonthNames());
			this.DaySpin = new SpinButton(1, 1, 1);
		}
		
		private void Init()
		{
			try
			{
				this.Disconnect();
				this.YearSpin.Value = this.Date.Year;
				this.MonthCombo.Active = this.Date.Month - 1;
				this.DaySpin.SetRange(1, DateTime.DaysInMonth(this.Date.Year, this.Date.Month));
				this.DaySpin.Value = this.Date.Day;
				this.Connect();
			}
			
			catch(Exception) {}
		}
		
		private void UpdateDate(object sender, EventArgs args)
		{
			if(this.YearSpin.Text.Length == 0 || this.DaySpin.Text.Length == 0)
				return;
			
			int year = int.TryParse(this.YearSpin.Text, out year) ? (year <= 0 ? 1 : year) : this.YearSpin.ValueAsInt;
			int month = SpDate.GetMonthNumber(this.MonthCombo.ActiveText);
			int day = int.TryParse(this.DaySpin.Text, out day) ? (day <= 0 ? 1 : day) : this.YearSpin.ValueAsInt;
			int max_days = DateTime.DaysInMonth(year, month);
			this.DaySpin.SetRange(1, max_days);
			
			if(day > max_days)
			{
				day = max_days;
				this.DaySpin.Value = max_days;
			}
			
			this._Date = new DateTime(year, month, day);
			
			if(this.Changed != null)
				this.Changed(sender, args);
		}
		
		private void Connect()
		{
			this.YearSpin.Changed += this.UpdateDate;
			this.MonthCombo.Changed += this.UpdateDate;
			this.DaySpin.Changed += this.UpdateDate;
		}
		
		private void Disconnect()
		{
			this.YearSpin.Changed -= this.UpdateDate;
			this.MonthCombo.Changed -= this.UpdateDate;
			this.DaySpin.Changed -= this.UpdateDate;
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

