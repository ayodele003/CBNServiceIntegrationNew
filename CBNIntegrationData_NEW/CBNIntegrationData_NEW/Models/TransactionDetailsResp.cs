﻿// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Models.TransactionDetailsResp
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

namespace CBNIntegration.Models
{
  public class TransactionDetailsResp
  {
    public string Status { get; set; }

    public string Msg { get; set; }

    public TransactionDetails[] Result { get; set; }
  }
}