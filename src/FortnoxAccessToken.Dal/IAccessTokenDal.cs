﻿using FortnoxAccessToken.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal {
  public interface IAccessTokenDal {
    AccessTokenDto Fetch(string authorizationId, string clientSecret);
    //void Insert(AuthorizationCodeDto data);
    //bool Exists(string authorizationId);
  }
}
