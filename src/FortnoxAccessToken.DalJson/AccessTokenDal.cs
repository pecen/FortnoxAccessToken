using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using FortnoxAPILibrary.Connectors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.DalJson {
  public class AccessTokenDal : IAccessTokenDal {
    //private HttpClient _client;

    public AccessTokenDal() {
      //CreateClient();
      //RequestUriString = GetAppConfigValue("WSBaseUri");
      //AuthorizationId = "679ac9ad-556c-455d-b2f9-7a7ae6ceae7b";
      //ClientSecret = "6aIXtS1AIo";
    }

    //public string RequestUriString { get; set; }
    //public string AuthorizationId { get; set; }
    //public string ClientSecret { get; set; }
    //public string AccessToken { get; private set; }
    //public HttpStatusCode HttpStatusCode { get; set; }

    private readonly string fileName = "AuthorizationCodes.txt";

    public AccessTokenDto Fetch(string authorizationId, string clientSecret) {
      string accessToken = string.Empty;
      AuthorizationConnector authConnector = null;

      try {
        authConnector = new AuthorizationConnector();
        accessToken = authConnector.GetAccessToken(authorizationId, clientSecret);

        //accessToken = new AuthorizationConnector().GetAccessToken(authorizationId, clientSecret);
        //accessToken = new AuthorizationConnector().GetAccessToken(AuthorizationId, ClientSecret);

        if (accessToken == string.Empty) {
          accessToken = "Denna AuthorizationCode är redan använd, eller har gått ut (giltighetstid = 30 dagar).";
        }
      }
      catch (Exception ex) {
        accessToken = ex.Message;
      }

      //return accessToken;
      return new AccessTokenDto {
        AccessToken = accessToken,
        HasError = authConnector.HasError ? true : false
      };
    }

    #region Old Code
    //public string Fetch_old(string authorizationId, string clientSecret) {
    //  // For test
    //  AuthorizationId = "679ac9ad-556c-455d-b2f9-7a7ae6ceae7b";
    //  ClientSecret = "6aIXtS1AIo";

    //  // TODO: Implement real request
    //  //_client.DefaultRequestHeaders.Add("Authorization-Code", authorizationId);
    //  //_client.DefaultRequestHeaders.Add("Client-Secret", clientSecret);
    //  //_client.DefaultRequestHeaders.Add("Content-Type", GetAppConfigValue("MediaType"));

    //  string jsonSend = $@"{{""Authorization-Code"": ""{AuthorizationId}"", ""Client-Secret"": ""{ClientSecret}""}}";
    //  //var response = SendRequestAsync(CreateHTTPRequest(jsonSend, GetAppConfigValue("WSBaseUri")));
    //  //var response = DoRequest(CreateHTTPRequest(authorizationId, clientSecret, GetAppConfigValue("WSBaseUri")));
    //  DoRequest();

    //  return AccessToken;
    //  //return Guid.NewGuid().ToString();
    //}

    //public void CreateClient() {
    //  _client = new HttpClient() {
    //    BaseAddress = new Uri(GetAppConfigValue("WSBaseUri"))
    //  };

    //  //_client.DefaultRequestHeaders
    //  //  .Accept
    //  //  .Add(new MediaTypeWithQualityHeaderValue(GetAppConfigValue("MediaType")));

    //  //_client.DefaultRequestHeaders.Add("Content-Type", "application/json");
    //  _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
    //}

    //private HttpRequestMessage CreateHTTPRequest(string jsonReq, string jsonUri) {
    //  HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, jsonUri) {
    //    Content = new StringContent(jsonReq, Encoding.UTF8, GetAppConfigValue("MediaType"))
    //  };

    //  return req;
    //}

    //private HttpWebRequest CreateHTTPRequest() {
    //  HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(RequestUriString);
    //  wr.Headers.Add("authorization-code", AuthorizationId);
    //  wr.Headers.Add("client-secret", ClientSecret);
    //  wr.ContentType = "application/json";
    //  wr.Accept = "application/json";
    //  wr.Method = "GET";
    //  return wr;
    //}

    //public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request) {
    //  HttpResponseMessage res = new HttpResponseMessage();

    //  try {
    //    await _client.SendAsync(request)
    //      .ContinueWith(responseTask => {
    //        res = responseTask.Result;
    //        //WriteLine($@"Request message sent to base address: ""{_client.BaseAddress}""");
    //      });
    //  }
    //  catch (Exception ex) {
    //    throw new Exception($@"Failed to send request message to base address: ""{_client.BaseAddress}"", with exception=""{ex}""");
    //  }

    //  return res;
    //}

    //internal void DoRequest() {
    //  WebRequest wr = CreateHTTPRequest();

    //  try {
    //    //if (Method != "GET") {
    //    //  using (wr.GetRequestStream()) { }
    //    //}

    //    using (HttpWebResponse response = (HttpWebResponse)wr.GetResponse()) {
    //      HttpStatusCode = response.StatusCode;

    //      var dataStream = response.GetResponseStream();
    //      StreamReader reader = new StreamReader(dataStream);
    //      string responseFromServer = reader.ReadToEnd();

    //      AccessToken = responseFromServer;
    //      //return new HttpResponseMessage() {
    //      //  Content = new StringContent(responseFromServer),

    //      //};

    //    }
    //  }
    //  catch (WebException we) {
    //    //Error = this.HandleException(we);
    //    throw new WebException(we.Message);
    //  }
    //}
    //private static string GetAppConfigValue(string value) {
    //  return ConfigurationManager.AppSettings[value];
    //}

    //public string Fetch_new(string authorizationId, string clientSecret) {
    //  return GetAccessToken(authorizationId, clientSecret);
    //}

    //public string GetAccessToken(string AuthorizationCode, string ClientSecret) {
    //  string AccessToken = "";
    //  //try {
    //  //  if (string.IsNullOrEmpty(AuthorizationCode) || string.IsNullOrEmpty(ClientSecret)) {
    //  //    return "";
    //  //  }


    //  //  HttpWebRequest wr = CreateHTTPRequest(ConnectionCredentials.FortnoxAPIServer, AuthorizationCode, ClientSecret);
    //  //  using (WebResponse response = wr.GetResponse()) {
    //  //    using (Stream responseStream = response.GetResponseStream()) {
    //  //      XmlSerializer xs = new XmlSerializer(typeof(Authorization));
    //  //      Authorization auth = (Authorization)xs.Deserialize(responseStream);
    //  //      AccessToken = auth.AccessToken;
    //  //    }
    //  //  }
    //  //}
    //  //catch (WebException we) {
    //  //  Error = HandleException(we);
    //  //}

    //  return AccessToken;
    //}
    #endregion

    public bool Exists(string authorizationId) {
      if (!File.Exists(fileName)) {
        return false;
      }

      try {   
        using (StreamReader sr = new StreamReader(fileName)) {
          string line = sr.ReadToEnd();
          string[] strarr = line.Replace("\r\n", "").Split(new char[] { ';' });
          if (strarr.Contains(authorizationId)) {
            return true;
          }
        }
      }
      catch (Exception ex) {
        throw new Exception(ex.Message);
      }

      return false;
    }

    public void Insert(AuthorizationCodeDto data) {
      try {
        using (StreamWriter file = new StreamWriter(fileName, true)) {
          file.WriteLine($"{data.AuthorizationCode};");
        }
      }
      catch(Exception ex) {
        throw new Exception(ex.Message);
      }
    }
  }
}
