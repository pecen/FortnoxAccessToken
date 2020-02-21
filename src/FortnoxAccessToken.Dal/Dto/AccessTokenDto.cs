using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal.Dto {
  public class AccessTokenDto {
    public string AccessToken { get; set; }
    public bool HasError { get; set; }
  }
}
