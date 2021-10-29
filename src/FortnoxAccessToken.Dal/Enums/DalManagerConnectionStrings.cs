using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal.Enums {
  public enum DalManagerConnectionStrings {
    [Description("FortnoxAccessToken.DalFile.DalManager,FortnoxAccessToken.DalFile")]
    DalFile,

		[Description("FortnoxAccessToken.DalSQLite.DalManager,FortnoxAccessToken.DalSQLite")]
		DalSQLite,

		[Description("FortnoxAccessToken.DalSql.DalManager,FortnoxAccessToken.DalSql")]
		DalSql,

		[Description("FortnoxAccessToken.DalAppConfigXml.DalManager,FortnoxAccessToken.DalAppConfigXml")]
    DalAppConfigXml,

    [Description("FortnoxAccessToken.DalFortnoxSdk.DalManager,FortnoxAccessToken.DalFortnoxSdk")]
    DalFortnoxSdk
  }
}
