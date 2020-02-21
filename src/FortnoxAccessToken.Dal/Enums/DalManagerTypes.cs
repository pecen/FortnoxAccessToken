using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal.Enums {
  public enum DalManagerTypes {
    [Description("DalManagerTypeAuthCode")]
    AuthCodeManager,

    [Description("DalManagerTypeFortnox")]
    FortnoxManager,

    [Description("DalManagerTypeAppConfig")]
    AppConfigManager
  }
}
