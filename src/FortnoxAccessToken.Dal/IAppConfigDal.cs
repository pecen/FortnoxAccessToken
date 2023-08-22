using FortnoxAccessToken.Dal.Dto;

namespace FortnoxAccessToken.Dal
{
	public interface IAppConfigDal
	{
		AppConfigDto Fetch();
		void Insert(AppConfigDto data);
		void Update(AppConfigDto data);
	}
}
