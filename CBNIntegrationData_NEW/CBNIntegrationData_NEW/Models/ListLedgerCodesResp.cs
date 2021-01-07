using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBNIntegration.Models
{
    public class ListLedgerCodesResp
    {
        public string Status { get; set; }

        public string Msg { get; set; }

        public ListLedgerCodes[] Result { get; set; }
    }
}
