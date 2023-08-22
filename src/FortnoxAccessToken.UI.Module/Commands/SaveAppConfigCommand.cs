using FortnoxAccessToken.Library;
using Prism.Events;

namespace FortnoxAccessToken.UI.Module.Commands
{
	public class SaveAppConfigCommand : PubSubEvent<AppConfigEdit>
	{
		//public AppConfigEdit SaveConfig(AppConfigEdit data) {
		//  data = data.Save();
		//  return data;
		//}
	}
}
