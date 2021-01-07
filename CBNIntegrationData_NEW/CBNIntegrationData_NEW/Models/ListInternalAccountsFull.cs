// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Models.ListInternalAccountsFull
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using System;

namespace CBNIntegration.Models
{
  public class ListInternalAccountsFull
  {
    public string NUBAN { get; set; }

    public string NONNUBAN { get; set; }

    public string STATUS { get; set; }

    public string CURRENCY { get; set; }

    //public string DESCRIPTION { get; set; }

    public Decimal TRAN_BAL { get; set; }
  }
}
