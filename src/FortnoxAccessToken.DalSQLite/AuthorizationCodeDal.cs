using Csla.Data;
using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using Microsoft.Data.Sqlite;
using System;
using System.Configuration;

namespace FortnoxAccessToken.DalSQLite {
	public class AuthorizationCodeDal : IAuthorizationCodeDal {
		public AuthorizationCodeDal() {
			// Both of these rows work, but use either of them. 
			//SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_winsqlite3()); 
			SQLitePCL.Batteries.Init();
		}
		public bool Exists(string authorizationId) {
			using (var ctx = ConnectionManager<SqliteConnection>.GetManager(ConfigurationManager.AppSettings["DbInUse"])) {
				var cm = ctx.Connection.CreateCommand();
				cm.CommandType = System.Data.CommandType.Text;
				cm.CommandText = "SELECT AuthorizationCode FROM AuthorizationCodes WHERE AuthorizationCode=@authorizationId";
				cm.Parameters.AddWithValue("@authorizationId", authorizationId);

				string retval = (string)cm.ExecuteScalar();
				return !string.IsNullOrEmpty(retval);
			}
		}

		public void Insert(AuthorizationCodeDto data) {
			using (var ctx = ConnectionManager<SqliteConnection>.GetManager(ConfigurationManager.AppSettings["DbInUse"])) {
				using (var cm = ctx.Connection.CreateCommand()) {
					cm.CommandType = System.Data.CommandType.Text;
					cm.CommandText = "Insert Into AuthorizationCodes (AuthorizationCode,Date) VALUES (@authorizationCode,@date)";
					cm.Parameters.AddWithValue("@authorizationCode", data.AuthorizationCode);
					cm.Parameters.AddWithValue("@date", DateTimeOffset.Now);
					cm.ExecuteNonQuery();
					cm.Parameters.Clear();
					cm.CommandText = "Select last_insert_rowid() from AuthorizationCodes";
					var r = cm.ExecuteScalar();
					data.Id = int.Parse(r.ToString());
				}
			}
		}
	}
}
