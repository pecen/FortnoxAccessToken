using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.UI.Module.Enums
{
    public enum DalManagers
    {
        [Description("File")]
        File,
        [Description("SQLite")]
        SQLite,
        [Description("SQL Server")]
        SQLServer,
        //[Description("XML")]
        //XML,
        //[Description("Json")]
        //Json
    }
}
