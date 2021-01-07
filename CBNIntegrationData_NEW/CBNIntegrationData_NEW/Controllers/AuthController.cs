// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Controllers.AuthController
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using CBNIntegration.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Security;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace CBNIntegration.Controllers
{
  public class AuthController : ApiController
  {
    private Logger logger = LogManager.GetCurrentClassLogger();
    private string UserValidationBaseURL = ConfigurationManager.AppSettings["BaseURL"];
    private AuthTokenResp authTokenResp = new AuthTokenResp();
    private ErrorResponse errorResponse = new ErrorResponse();
    private SuccessResponse successResponse = new SuccessResponse();
    private StringBuilder stringBuilder = new StringBuilder();

    public static string Base64Encode(string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

    [HttpPost]
    public AuthTokenResp Token([FromBody] AuthTokenReq authTokenReq)
    {
      ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback) ((_param1, _param2, _param3, _param4) => true);
      try
      {
        this.stringBuilder.Append(authTokenReq.Username);
        this.stringBuilder.Append(":");
        this.stringBuilder.Append(authTokenReq.Password);
        string str1 = "Basic " + AuthController.Base64Encode(this.stringBuilder.ToString());
        this.logger.Info("Starting::: Token Generation Calls. Header " + str1);
        if (str1.StartsWith("Basic"))
        {
          string[] strArray1 = Encoding.UTF8.GetString(Convert.FromBase64String(str1.Substring("Basic ".Length).Trim())).Split(':');
          RestClient restClient = new RestClient(this.UserValidationBaseURL + "ValidateUserNew?Username=" + strArray1[0] + "&Password=" + strArray1[1]);
          RestRequest restRequest = new RestRequest(Method.GET);
          restRequest.AddHeader("cache-control", "no-cache");
          restRequest.AddHeader("Content-Type", "application/json");
          IRestResponse restResponse = restClient.Execute((IRestRequest) restRequest);
          AuthResponseBody authResponseBody1 = new AuthResponseBody();
          AuthResponseBody authResponseBody2 = JsonConvert.DeserializeObject<AuthResponseBody>(restResponse.Content);
          if (authResponseBody2.Status == "00")
          {
            string[] strArray2 = authResponseBody2.Result.Split('|');
            this.logger.Info("Result::: DB Query Response " + authResponseBody2.Result);
            if (strArray2[0] == "1" && strArray2[1] == "2")
            {
              Claim[] claimArray = new Claim[1]
              {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", strArray1[0] + "|" + strArray2[1])
              };
              SigningCredentials signingCredentials = new SigningCredentials((SecurityKey) new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jlklk;lkl;wkwipoiuwoulwlrwwqxdwfrr")), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
              DateTime? expires = new DateTime?(DateTime.Now.AddMinutes(1.0));
              string str2 = new JwtSecurityTokenHandler().WriteToken((SecurityToken) new JwtSecurityToken("wemabank.com", "cbn.gov.ng", (IEnumerable<Claim>) claimArray, expires: expires, signingCredentials: signingCredentials));
              this.authTokenResp = new AuthTokenResp()
              {
                ResponseCode = this.successResponse.Status,
                ResponseMessage = this.successResponse.Msg,
                Token = str2
              };
              return this.authTokenResp;
            }
          }
        }
        this.authTokenResp = new AuthTokenResp()
        {
          ResponseCode = this.errorResponse.Status,
          ResponseMessage = this.errorResponse.Msg,
          Token = ""
        };
        return this.authTokenResp;
      }
      catch (Exception ex)
      {
        this.logger.Info("Entering Exceptions::: message:-" + ex.Message);
        this.authTokenResp = new AuthTokenResp()
        {
          ResponseCode = this.errorResponse.Status,
          ResponseMessage = this.errorResponse.Msg,
          Token = ex.Message
        };
        return this.authTokenResp;
      }
    }
  }
}
