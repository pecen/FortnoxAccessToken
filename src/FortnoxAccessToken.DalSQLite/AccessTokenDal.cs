using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.DalSQLite
{
    public class AccessTokenDal : IAccessTokenDal
    {
        public AccessTokenDto Fetch(string authorizationId, string clientSecret)
        {
            throw new NotImplementedException();
        }
    }
}
