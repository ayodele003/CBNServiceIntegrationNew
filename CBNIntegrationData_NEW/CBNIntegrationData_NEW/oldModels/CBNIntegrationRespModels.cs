using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBNIntegrationData_NEW.Models
{
    
    public class SuccessResponse
    {
        public string Status = "00";
        public string Msg = "Success";
    }

    public class ErrorResponse
    {
        public string Status = "01";
        public string Msg = "Error encountered";
    }

    public class EmptyResponse
    {
        public string Status = "02";
        public string Msg = "No transaction within specified period";
    }
   
    public class ResponseBody
    {
        public string Status { get; set; }
        public string Msg { get; set; }
        public string Result { get; set; }
    }
}