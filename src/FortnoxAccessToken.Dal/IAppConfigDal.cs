using FortnoxAccessToken.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal {
  public interface IAppConfigDal {
    AppConfigDto Fetch();
    void Insert(AppConfigDto data);
    void Update(AppConfigDto data);
  }
}
