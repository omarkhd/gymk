using System;
//using System.Data.SQLite;
using Mono.Data.Sqlite;
using System.Data;

namespace omarkhd.Gymk
{
	public static class SystemDb
	{
		private static IDbConnection Connection; // SQLiteConnection
		
		static SystemDb()
		{
			Connection = null;
		}
		
		public static IDbConnection GetConnection()
		{
			if(SystemDb.Connection == null)
				SystemDb.MakeConnection();
			
			else
				AppHelper.Log("obtaining instanced connection to database");
				
			return SystemDb.Connection;
		}
		
		private static void MakeConnection()
		{
			SessionRegistry r = SessionRegistry.GetInstance();
			string conn_string = "Data Source=" + r["db_path"] + ";version=3";
			//SystemDb.Connection = new SQLiteConnection(conn_string);
			SystemDb.Connection = new SqliteConnection(conn_string);
			SystemDb.Connection.Open();
			AppHelper.Log("connection to database " + r["db_path"] + " opened");
			SystemDb.SetPragma();
		}
		
		public static void DestroyConnection()
		{
			if(SystemDb.Connection != null)
			{
				SystemDb.Connection.Close();
				SessionRegistry r = SessionRegistry.GetInstance();
				AppHelper.Log("connection to database " + r["db_path"] + " closed");
			}
		}
		
		private static void SetPragma()
		{
			IDbCommand cmd = SystemDb.Connection.CreateCommand();
			cmd.CommandText = "pragma foreign_keys = ON";
			try
			{
				AppHelper.Log("enabling foreign key support in Sqlite: " + cmd.CommandText);
				cmd.ExecuteNonQuery();
			}
			
			catch(SqliteException e)
			{
				AppHelper.Log("Error enabling foreign keys support in Sqlite. Details: " + e.Message + ", " + e.StackTrace);
			}
		}
	}
}

