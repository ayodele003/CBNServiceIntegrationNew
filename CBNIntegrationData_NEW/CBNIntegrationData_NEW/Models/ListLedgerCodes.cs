﻿// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Data.CBNIntegrationData
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using System;

namespace CBNIntegration.Models
{
    public class ListLedgerCodes
    {
        public string LedgerCode { get; set; }

        public string LedgerName { get; set; }

        public string status { get; set; }

        public int ActiveAccountsCount { get; set; }

        public int InactiveAccountsCount { get; set; }

        public Decimal LedgerBalance { get; set; }
    }
}