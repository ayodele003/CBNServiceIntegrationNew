// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Models.AuthTokenFailedResp
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

namespace CBNIntegration.Models
{
  public class AuthTokenFailedResp
  {
    public string ResponseCode = "91";
    public string ResponseMessage = "Something went wrong - can not generate access token";

    public string ErrorMessage { get; set; }
  }
}
