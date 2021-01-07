using CBNIntegrationData_NEW.Data;
using CBNIntegrationData_NEW.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CBNIntegrationData_NEW.Controllers
{
    public class CBNQueriesController : ApiController
    {        

        CBNIntegrationCRUD cBNIntegrationCRUD = new CBNIntegrationCRUD();
        Logger logger = LogManager.GetCurrentClassLogger();
        ResponseBody responseBody = new ResponseBody();
        SuccessResponse successResponse = new SuccessResponse();
        ErrorResponse errorResponse = new ErrorResponse();
        EmptyResponse emptyResponse = new EmptyResponse();
        string result;

        [HttpGet]
        //public ResponseBody TransactionDetails(TransactionDetailsReq transactionDetailsReq)
        public ResponseBody TransactionDetails(string StartDate, string EndDate, string AccountNo)
        {

            try
            {                
                    if (StartDate != string.Empty && AccountNo != string.Empty && StartDate != string.Empty)
                    {                   

                    result = cBNIntegrationCRUD.TransactionDetails(StartDate,EndDate,AccountNo);
                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }                    
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  ex.Message
                };
                return responseBody;
            }

        }

        [HttpGet]
        public ResponseBody TransactionDetailsChannels(string StartDate, string EndDate, string AccountNo)
        {
            try
            {

                if (StartDate != string.Empty && AccountNo != string.Empty && StartDate != string.Empty)
                {

                result = cBNIntegrationCRUD.TransactionDetailsChannels(StartDate, EndDate, AccountNo);              
                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            }
                else
                {
                responseBody = new ResponseBody()
                {
                    Status = emptyResponse.Status,
                    Msg = emptyResponse.Msg,
                    Result = "Please enter values"
                };
                return responseBody;
            }
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }

        [HttpGet]
        public ResponseBody AccountDetails(string AccountNo)
        {
            try
            {
                if (AccountNo != string.Empty) {                

                result = cBNIntegrationCRUD.AccountDetails(AccountNo);

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                   else if (result.Contains("Something Went Wrong: "))
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = errorResponse.Status,
                            Msg = errorResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            }
                else
                {
                responseBody = new ResponseBody()
                {
                    Status = emptyResponse.Status,
                    Msg = emptyResponse.Msg,
                    Result = "Please enter values"
                };
                return responseBody;
            }
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody AccountDetailsChannels(string AccountNo)
        {

            try
            {
                if(AccountNo != string.Empty) { 
               
                result = cBNIntegrationCRUD.AccountDetailsChannels(AccountNo);

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            }
                else
                {
                responseBody = new ResponseBody()
                {
                    Status = emptyResponse.Status,
                    Msg = emptyResponse.Msg,
                    Result = "Please enter values"
                };
                return responseBody;
            }
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody Signatories(string AccountNo)
        {
            try
            {
                if(AccountNo != string.Empty)
                { 
              
                result = cBNIntegrationCRUD.Signatories(AccountNo);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result 
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }

        [HttpGet]
        public ResponseBody SignatoriesWithNIN(string AccountNo)
        {

            try
            {
                if (AccountNo != string.Empty) {              

                result = cBNIntegrationCRUD.SignatoriesWithNIN(AccountNo);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }


        [HttpGet]
        public ResponseBody ListAccountsByBVN(string BVN)
        {

            try
            {
                if(BVN != string.Empty) {                

                result = cBNIntegrationCRUD.ListAccountsByBVN(BVN);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }


        [HttpGet]
        public ResponseBody ListAccountsByRCNo(string RCNo)
        {
            try
            {
                if(RCNo != string.Empty) { 
               
                result = cBNIntegrationCRUD.ListAccountsByRCNo(RCNo);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }


        [HttpGet]
        public ResponseBody ListAccountsByTIN(string TIN)
        {
            try
            {
                if(TIN != string.Empty) { 
               
                result = cBNIntegrationCRUD.ListAccountsByTIN(TIN);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }

        [HttpGet]
        public ResponseBody ListAccountsByNIN(string NIN)
        {

            try
            {
                if(NIN != string.Empty) { 
              
                result = cBNIntegrationCRUD.ListAccountsByNIN(NIN);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }

        [HttpGet]
        public ResponseBody ActiveTIN()
        {

            try
            {

                result = cBNIntegrationCRUD.ActiveTIN();

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }
                           
           
                }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody ActiveRCNo()
        {

            try
            {
                result = cBNIntegrationCRUD.ActiveRCNo();

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }
            
            }
            catch (Exception ex)
            {
           responseBody = new ResponseBody()
             {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody ActiveNIN()
        {

            try
            {
                result = cBNIntegrationCRUD.ActiveNIN();

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody ListTIN_RCNo()
        {

            try
            {
                result = cBNIntegrationCRUD.ListTIN_RCNo();

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }
           
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
            {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody ListInternalAccounts(string LedgerCode)
        {
            try
            {
                if(LedgerCode != string.Empty) { 
                result = cBNIntegrationCRUD.ListInternalAccounts(LedgerCode);

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            }
                else
                {
                responseBody = new ResponseBody()
                {
                    Status = emptyResponse.Status,
                    Msg = emptyResponse.Msg,
                    Result = "Please enter values"
                };
                return responseBody;
            }
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody ListInternalAccountsFull(string LedgerCode)
        {

            try
            {
                if(LedgerCode != string.Empty) { 
               

                result = cBNIntegrationCRUD.ListInternalAccountsFull(LedgerCode);

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            }
                else
                {
                responseBody = new ResponseBody()
                {
                    Status = emptyResponse.Status,
                    Msg = emptyResponse.Msg,
                    Result = "Please enter values"
                };
                return responseBody;
            }
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody InternalAccountsSignatories(string LedgerCode)
        {

            try
            {
                if(LedgerCode != string.Empty) { 
                
                result = cBNIntegrationCRUD.InternalAccountsSignatories(LedgerCode);

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }

            }
                else
                {
                responseBody = new ResponseBody()
                {
                    Status = emptyResponse.Status,
                    Msg = emptyResponse.Msg,
                    Result = "Please enter values"
                };
                return responseBody;
            }
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}

        [HttpGet]
        public ResponseBody ListStatistics()
        {

            try
            {
                             

                result = cBNIntegrationCRUD.ListStatistics();

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }
            
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
}


        [HttpGet]
        public ResponseBody DormantStatistics()
        {

            try
            {
                             
                result = cBNIntegrationCRUD.DormantStatistics();

                if (result != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                    };
                    return responseBody;
                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                    };
                    return responseBody;
                }
           
        }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
        {
            Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result =  "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }


         [HttpGet]
         public ResponseBody ClosedStatistics()
            {
                try
                {
                  
                 
                   result = cBNIntegrationCRUD.ClosedStatistics();

                    if (result != string.Empty)
                    {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

              
            }
                catch (Exception ex)
                {
                    responseBody = new ResponseBody()
                        {
                        Status = errorResponse.Status,
                        Msg = errorResponse.Msg,
                        Result =  "General App Exception - No Record Found"
                    };
                    return responseBody;
                }
            }

        [HttpGet]
        public ResponseBody PendingDebit(string AccountNo)
        {
            try
            {
                if (AccountNo != string.Empty)
                {

                    result = cBNIntegrationCRUD.PendingDebit(AccountNo);

                    if (result != string.Empty)
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = successResponse.Status,
                            Msg = successResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else if (result.Contains("Something Went Wrong: "))
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = errorResponse.Status,
                            Msg = errorResponse.Msg,
                            Result = result
                        };
                        return responseBody;
                    }
                    else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }

                }
                else
                {
                    responseBody = new ResponseBody()
                    {
                        Status = emptyResponse.Status,
                        Msg = emptyResponse.Msg,
                        Result = "Please enter values"
                    };
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                responseBody = new ResponseBody()
                {
                    Status = errorResponse.Status,
                    Msg = errorResponse.Msg,
                    Result = "General App Exception - No Record Found"
                };
                return responseBody;
            }
        }

        [HttpGet]
         public ResponseBody ValidateUserNew(string Username, string Password)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                logger.Info("Executing... ValidateUserNew");

                try
                {
                    logger.Info("Started::: Validating the Endpoint Credentials - " + Username);                
                    var ValidAuthValue = cBNIntegrationCRUD.ValidateUser(Username,Password);
                    logger.Info("Ended::: Validating the Endpoint Credentials");
                if (ValidAuthValue != string.Empty)
                {
                    responseBody = new ResponseBody()
                    {
                        Status = successResponse.Status,
                        Msg = successResponse.Msg,
                        Result = ValidAuthValue
                    };
                    return responseBody;
                }
               else
                    {
                        responseBody = new ResponseBody()
                        {
                            Status = emptyResponse.Status,
                            Msg = emptyResponse.Msg,
                        };
                        return responseBody;
                    }
                
                }

                catch (Exception ex)
                {
                    logger.Info("Ended::: Validating User's Credential Auth Exceptions");
                    logger.Info(ex.Message); logger.Info(ex.StackTrace);
                    responseBody = new ResponseBody()
                    {
                        Status = errorResponse.Status,
                        Msg = errorResponse.Msg,
                        Result =  "General App Exception - No Record Found"
                    };
                    return responseBody;
                }
            }
    }
}
