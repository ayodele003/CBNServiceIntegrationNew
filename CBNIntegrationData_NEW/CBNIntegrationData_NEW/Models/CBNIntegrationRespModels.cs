﻿// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Models.AuthTokenResp
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

namespace CBNIntegration.Models
{
  public class AuthTokenResp
  {
    public string ResponseCode = "00";
    public string ResponseMessage = "Success";

    public string Token { get; set; }
  }
}
