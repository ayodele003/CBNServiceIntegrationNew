// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Models.DormantStatistics
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll


using System;

namespace CBNIntegration.Models
{
  public class DormantStatistics
  {
        public int DORMANTCORPORATE { get; set; }

        public int DORMANTINDIVIDUAL { get; set; }
        public int DORMANTACCOUNTS { get; set; }

        public Decimal DORMANTCORPACCAMTNGN { get; set; }

        public Decimal DORMANTCORPACCAMTGBP { get; set; }

        public Decimal DORMANTCORPACCAMTEUR { get; set; }

        public Decimal DORMANTCORPACCAMTUSD { get; set; }

        public Decimal DORMANTINDACCAMTNGN { get; set; }

        public Decimal DORMANTINDACCAMTGBP { get; set; }

        public Decimal DORMANTINDACCAMTEUR { get; set; }

        public Decimal DORMANTINDACCAMTUSD { get; set; }

        public int DORMANTTIER1 { get; set; }

    public int DORMANTTIER2 { get; set; }

    public int DORMANTTIER3 { get; set; }
  }
}
