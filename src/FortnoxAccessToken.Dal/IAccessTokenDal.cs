using FortnoxAccessToken.Dal.Dto;

namespace FortnoxAccessToken.Dal
{
	public interface IAccessTokenDal
	{
		AccessTokenDto Fetch(string authorizationId, string clientSecret);
		//void Insert(AuthorizationCodeDto data);
		//bool Exists(string authorizationId);
	}
}
