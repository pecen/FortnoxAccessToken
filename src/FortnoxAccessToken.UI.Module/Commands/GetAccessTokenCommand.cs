using Prism.Events;

namespace FortnoxAccessToken.UI.Module.Commands
{
	public class GetAccessTokenCommand : PubSubEvent<string>
	{
		//public string GetAccessToken(AccessTokenRequest request) {
		//  try {
		//    bool exists = AccessTokenInfo.Exists(request.AuthorizationId);

		//    // Check for SQLServer-error
		//    if (!string.IsNullOrEmpty(AccessTokenInfo.ErrorMessage)) {
		//      var msg = AccessTokenInfo.ErrorMessage;
		//      AccessTokenInfo.ErrorMessage = "";
		//      return msg;
		//    }

		//    if (exists) { // = AccessTokenInfo.Exists(request.AuthorizationId)) {
		//      var answer = MessageBox.Show("The given AuthorizationCode is already used. Do you want to send anyway to deactivate this integration?", //"Den AuthorizationCode som angivits är redan förbrukad. Vill du skicka ändå för att deaktivera denna integration?", 
		//        "AccessToken existerar",
		//        MessageBoxButton.YesNo,
		//        MessageBoxImage.Warning,
		//        MessageBoxResult.No);

		//      if (answer == MessageBoxResult.No) {
		//        //return "En AccessToken har redan skapats med given AuthorizationCode.";
		//        return "Den AuthorizationCode som angivits är redan förbrukad.";
		//      }
		//    }

		//    var accessTokenInfo = AccessTokenInfo.GetAccessToken(request.AuthorizationId, request.ClientSecret);

		//    if (!accessTokenInfo.HasError && !exists) {
		//      var authorizationCodeEdit = AuthorizationCodeEdit.NewAuthorizationCode();
		//      authorizationCodeEdit.AuthorizationCode = request.AuthorizationId;
		//      authorizationCodeEdit = authorizationCodeEdit.Save();
		//    }

		//    return accessTokenInfo.AccessToken;
		//  }
		//  catch (Exception ex) {
		//    throw new Exception(ex.Message);
		//  }
		//}

		//public AccessTokenEdit GetAccessToken(AccessTokenRequest request) {
		//  if (AccessTokenEdit.Exists(request.AuthorizationId)) {
		//    return new AccessTokenEdit() {
		//      AccessToken = ""
		//    };
		//  }
		//  return AccessTokenEdit.GetAccessToken(request.AuthorizationId, request.ClientSecret);
		//  //return $"Ny Guid: {Guid.NewGuid().ToString()}";
		//}
	}
}
