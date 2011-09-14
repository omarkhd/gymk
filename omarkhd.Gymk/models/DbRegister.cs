using System;
using System.Data;

namespace omarkhd.Gymk
{
	public class DbRegister : DbModel
	{
		private static DbRegister Instance;
			
		static DbRegister()
		{
			Instance = null;
		}		
		
		private DbRegister() : base ("Register", "Key")
		{
		}
		
		public static DbRegister GetInstance()
		{
			if(Instance == null)
				Instance = new DbRegister();
			return Instance;	
		}
		
		public object this[string key]
		{
			get
			{
				object to_return = null;
				IDataReader reader = this.GetById(key);
				if(reader.Read())
					to_return = reader["Value"];
					
				return this.GetParseOf(key, to_return);
			}
				
			set
			{
				if(this.ExistsById(key))
					this.UpdateById(key, "Value", value);
				else
					this.Insert(key, value);
			}
		}
		
		private object GetParseOf(string key, object val)
		{
			object to_return = val;
			
			switch(key)
			{
				case "delay_saturday":
					goto case "__return_bool";
					
				case "delay_sunday":
					goto case "__return_bool";
					
				case "delay_charge":
					goto case "__return_float";
					
				case "__return_bool":
					int i = 0;
					int.TryParse((string) val, out i);
					bool b = Convert.ToBoolean(i);
					to_return = b;
					break;
					
				case "__return_float":
					float f = 0.0f;
					float.TryParse((string) val, out f);
					to_return = f;
					break;
					
				default:
					if(to_return == null)
						to_return = "";
					break;
			}
			
			return to_return;
		}
	}
}

