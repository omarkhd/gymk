using System;
using System.Data;
using Mono.Data.Sqlite;

namespace omarkhd.Gymk
{
	public class MemberModel : DbModel
	{
		public MemberModel() : base("Member")
		{
		}
		
		public bool Insert(Member m)
		{
			long id = m.InnerClient.Id;
			object contact = (m.InnerContact.Id == 0 ? null : (object) m.InnerContact.Id);
			string bd = m.BirthDate.ToString("yyyy-MM-dd");
			string jd = m.JoinDate.ToString("yyyy-MM-dd");
			bool i_success = base.Insert(id, true, m.Height, m.Weight, m.Gender, bd, m.PaymentDay, jd, m.Pack, contact, null);
			
			if(i_success)
				this.SetImage(m);
				
			return i_success;
		}
		
		public void SetImage(Member m)
		{
			string sql = "update " + this.TableName + " set Photo = @p0 where Id = @p1";
			if(m.BinImage == null || m.BinImage.Length == 0)
				this.DoNonQuery(sql, null, m.Id);
			
			else
			{
				SqliteCommand cmd = this.Db.CreateCommand();
				SqliteParameter p0 = new SqliteParameter("@p0", DbType.Binary, m.BinImage.Length);
				p0.Value = m.BinImage;
				SqliteParameter p1 = new SqliteParameter("@p1", m.Id);
								
				cmd.CommandText = sql;
				cmd.Parameters.Add(p0);
				cmd.Parameters.Add(p1);
				AppHelper.Log(cmd.CommandText);
				cmd.ExecuteNonQuery();
			}				
		}
		
		/*public IDataReader GetAllLike(object key)
		{
			string like = "%" + key + "%";
			string sql = "select * from " + this.TableName;
			sql += " where Id = @p0 or Name like @p1 or Surname like @p2";
			return this.DoReader(sql, key, like, like);
			return null;
		}*/
		
		public IDataReader GetAllWithJoinLike(object key)
		{
			string like = "%" + key + "%";
			string sql = "select * from member_with_client_info";
			sql += " where Id = @p0 or Name like @p1 or Surname like @p2";
			return this.DoReader(sql, key, like, like);
			/*string sql = "select * from member_with_client_info";
			return this.DoReader(sql);*/
		}
		
		public static Member FromId(long id)
		{
			MemberModel mm = new MemberModel();
			IDataReader r = mm.GetById(id);
			Member m = null;
			if(r.Read())
			{
				m = new Member();
				m.Active = (bool) r["Active"];
				m.Height = (float) r["Height"];
				m.Weight = (float) r["Weight"];
				m.Gender = (char) (int.Parse((string) r["Gender"]));
				//Console.Out.WriteLine(m.Gender);
				m.BirthDate = (DateTime) r["BirthDate"];
				m.PaymentDay = (int) ((long) r["PaymentDay"]);
				m.JoinDate = (DateTime) r["JoinDate"];
				m.Pack = (long) r["Pack"];
				m.InnerClient = new Client();
				m.InnerClient.Id = id;
				m.InnerClient.Sync();
			}
			
			return m;
		}
	}
}