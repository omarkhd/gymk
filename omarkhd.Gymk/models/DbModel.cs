using System;
using System.Data;
using Mono.Data.Sqlite;

namespace omarkhd.Gymk
{
	public class DbModel
	{
		private SqliteConnection Db; //change this!
		protected string TableName;
		protected string IdName;
		private IDataReader LastDataReader;
		
		public DbModel(string table_name, string id_name)
		{
			this.TableName = table_name;
			this.IdName = id_name;			
			this.Db = SystemDb.GetConnection();
		}
		
		public DbModel(string table_name) : this(table_name, "Id") {}
		
		public IDataReader GetAll(int start, int count) // get all with limit clause
		{
			string sql = "select * from " + this.TableName;
			if(start >= 0 && count > 0)
				sql += " limit " + start + ", " + count;
				
			return this.DoReader(sql);
		}
		
		public IDataReader GetAll() 
		{
			return this.GetAll(-1, -1); //limitless
		}
		
		public IDataReader GetById(object key)
		{
			string sql = "select * from " + this.TableName;
			sql += " where " + this.IdName + " = @p0";
			
			return this.DoReader(sql, key);
		}
		
		public IDataReader GetBy(string column, object key)
		{
			string sql = "select * from " + this.TableName;
			sql += " where " + column + " = @p0";
			return this.DoReader(sql, key);
		}
		
		public long DeleteAll()
		{
			string sql = "delete from " + this.TableName;
			return (long) this.DoNonQuery(sql);
		}
		
		public bool DeleteById(object key)
		{
			return this.DeleteBy(this.IdName, key) > 0;
		}
		
		public long DeleteBy(string column_name, object key)
		{
			string sql = "delete from " + this.TableName;
			sql += " where " + column_name + " = @p0";
			return (long) this.DoNonQuery(sql, key);
		}
		
		public bool ExistsById(object key)
		{
			string sql = "select count(*) from " + this.TableName;
			sql += " where " + this.IdName + " = @p0";
			return ((long) this.DoScalar(sql, key)) > 0;
		}
		
		public bool Insert(params object[] p)
		{
			string sql = "insert into " + this.TableName + " values(";
			for(int i = 0; i < p.Length; i++)
				sql += "@p" + i + ", ";
			sql = sql.Substring(0, sql.Length - 2);
			sql += ")";
			
			return (((long) this.DoNonQuery(sql, p)) == 1 ? true : false);
		}
		
		public long Count()
		{
			string sql = "select count(*) from " + this.TableName;
			return (long) this.DoScalar(sql);
		}
		
		public long LastInsertId
		{
			get
			{
				string sql = "select last_insert_rowid()";
				return (long) this.DoScalar(sql);
			}
		}
		
		protected object DoScalar(string sql, params object[] args)
		{
			AppHelper.Log(sql);
			SqliteCommand cmd = this.Db.CreateCommand();
			cmd.CommandText = sql;
			this.PutParameters(cmd, args);
			object result = -1; //for convenience
			try
			{
				result = cmd.ExecuteScalar();
			}
			
			catch(SqliteException e)
			{
				AppHelper.Log(e.Message + ", " + e.StackTrace);
			}
			
			return result;
		}
		
		protected long DoNonQuery(string sql, params object[] args)
		{
			AppHelper.Log(sql);
			SqliteCommand cmd = this.Db.CreateCommand();
			cmd.CommandText = sql;
			this.PutParameters(cmd, args);
			long rows_affected = -1;
			try
			{
				rows_affected = cmd.ExecuteNonQuery();
			}
			
			catch(SqliteException e)
			{
				AppHelper.Log(e.Message + ", " + e.StackTrace);
			}
			
			return rows_affected;
		}
		
		protected IDataReader DoReader(string sql, params object[] args)
		{
			AppHelper.Log(sql);
			SqliteCommand cmd = this.Db.CreateCommand();
			cmd.CommandText = sql;
			this.PutParameters(cmd, args);
			IDataReader reader = null;
			
			if(this.LastDataReader != null && !this.LastDataReader.IsClosed)
				this.LastDataReader.Close();
				
			try
			{
				reader = cmd.ExecuteReader();
				this.LastDataReader = reader;
			}
			
			catch(SqliteException e)
			{
				AppHelper.Log(e.Message + ", " + e.StackTrace);
			}
			
			return reader;
		}
		
		protected void PutParameters(SqliteCommand cmd, object[] args)
		{
			for(int i = 0; i < args.Length; i++)
			{
				string p_name = "@p" + i;				
				SqliteParameter p = new SqliteParameter(p_name, args[i]);
				cmd.Parameters.Add(p);				
				cmd.Prepare();
			}
		}
	}
}

