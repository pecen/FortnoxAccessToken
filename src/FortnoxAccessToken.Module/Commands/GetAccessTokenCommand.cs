using FortnoxAccessToken.Library;
using FortnoxAccessToken.Module.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FortnoxAccessToken.Module.Commands {
  public class GetAccessTokenCommand : PubSubEvent<string> {
    public string GetAccessToken(AccessTokenRequest request) {
      if (AccessTokenInfo.Exists(request.AuthorizationId)) {
        var answer = MessageBox.Show("Den AuthorizationCode som angivits är redan förbrukad. Vill du skicka ändå för att deaktivera denna integration?", 
          "AccessToken existerar", 
          MessageBoxButton.YesNo, 
          MessageBoxImage.Warning, 
          MessageBoxResult.No);

        if (answer == MessageBoxResult.No) {
          //return "En AccessToken har redan skapats med given AuthorizationCode.";
          return "Den AuthorizationCode som angivits är redan förbrukad.";
        }
      }

      var accessTokenInfo = AccessTokenInfo.GetAccessToken(request.AuthorizationId, request.ClientSecret);

      if (!accessTokenInfo.HasError) {
        var authorizationCodeEdit = AuthorizationCodeEdit.NewAuthorizationCode();
        authorizationCodeEdit.AuthorizationCode = request.AuthorizationId;
        authorizationCodeEdit = authorizationCodeEdit.Save();
      }

      return accessTokenInfo.AccessToken;
      //return $"Ny Guid: {Guid.NewGuid().ToString()}";
    }

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
