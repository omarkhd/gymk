using System;
using System.IO;

namespace omarkhd.Gymk
{
	public static class AppHelper
	{
		private static StreamWriter FileLog;
		private static bool LogToFile;
		
		static AppHelper()
		{
			AppHelper.LogToFile = false;	
			try
			{
				FileStream file_stream = new FileStream("gymk.log", FileMode.Append, FileAccess.Write);
				AppHelper.FileLog = new StreamWriter(file_stream);
				AppHelper.LogToFile = true;
			}
			
			catch(IOException)
			{
				AppHelper.Log("unable to open file for logging");
			}
		}
		
		public static void Log(object msg)
		{
			DateTime now = DateTime.Now;
			string log_str = now.ToString("dd/MM/yyyy hh:mm:ss");
			log_str += " -> " + msg;
			Console.Out.WriteLine(log_str);
			if(AppHelper.LogToFile)
			{
				AppHelper.FileLog.WriteLine(log_str);
				AppHelper.FileLog.Flush();
			}
		}
		
		public static bool Windows
		{
			get
			{
				string os = Environment.OSVersion.ToString();
				bool windows = false;
				if(os.Contains("Microsoft") || os.Contains("Windows"))
					windows = true;
				return windows;
			}
		}
		
		public static void Init()
		{
			SetVars();
			
			try { SystemDb.GetConnection(); }
			catch(Exception e)
			{
				AppHelper.Log("No se pudo conectar con SQLite. Detalles: " + e.Message + ": " + e.StackTrace);
				Environment.Exit(0);
			}
		}
		
		public static void Clean()
		{
			SystemDb.DestroyConnection();
		}
		
		private static void SetVars()
		{
			SessionRegistry r = SessionRegistry.GetInstance();
			r["author"] = "Omar Karim Martín Cornejo";
			r["author_contact"] = "omarkhd.mx@gmail.com";			
			r["db_path"] = "db/gymk.db";
			r["gym_name"] = "Géminis";
		}
	}
}

