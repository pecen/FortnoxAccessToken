using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal.Dto {
  public class AppConfigDto {
    public string DalManagerType { get; set; }
    public string BaseUri { get; set; }
    public string ClientSecret { get; set; }
    public string DbInUse { get; set; }

  }
}
