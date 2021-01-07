// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Controllers.CBNController
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using CBNIntegration.Data;
using CBNIntegration.Models;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Web.Http;

namespace CBNIntegration.Controllers
{
  public class CBNController : ApiController
  {
    private Logger logger = LogManager.GetCurrentClassLogger();
    private CBNIntegrationData cBNIntegrationData = new CBNIntegrationData();
    private Success success = new Success();
    private Failed failed = new Failed();

    [HttpPost]
    public TransactionDetailsResp TransactionDetails(
      [FromBody] TransactionDetailsReq transactionDetailsReq)
    {
           
           if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
           
            {
                TransactionDetailsReq transactionDetailsReq1 = new TransactionDetailsReq()
           {
          StartDate = this.dateConvert(transactionDetailsReq.StartDate),
          EndDate = this.dateConvert(transactionDetailsReq.EndDate),
          AccountNo = transactionDetailsReq.AccountNo
        };
        this.logger.Info<TransactionDetailsReq>("Request {@value}", transactionDetailsReq);
        CBNIntegration.Models.TransactionDetails[] array = this.cBNIntegrationData.TransactionDetails(transactionDetailsReq1).ToArray();
        int length = array.Length;
        TransactionDetailsResp transactionDetailsResp = new TransactionDetailsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<TransactionDetailsResp>("Response {@value}", transactionDetailsResp);
        return transactionDetailsResp;
      }
      TransactionDetailsResp transactionDetailsResp1 = new TransactionDetailsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<TransactionDetailsResp>("Response {@value}", transactionDetailsResp1);
      return transactionDetailsResp1;
    }

    [HttpPost]
    public TransactionDetailsChannelsResp TransactionDetailsChannels(
      [FromBody] TransactionDetailsChannelsReq transactionDetailsChannelsReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
   
      {
        TransactionDetailsChannelsReq transactionDetailsChannelsReq1 = new TransactionDetailsChannelsReq()
        {
          StartDate = this.dateConvert(transactionDetailsChannelsReq.StartDate),
          EndDate = this.dateConvert(transactionDetailsChannelsReq.EndDate),
          AccountNo = transactionDetailsChannelsReq.AccountNo
        };
        this.logger.Info<TransactionDetailsChannelsReq>("Request {@value}", transactionDetailsChannelsReq1);
        CBNIntegration.Models.TransactionDetailsChannels[] array = this.cBNIntegrationData.TransactionDetailsChannels(transactionDetailsChannelsReq1).ToArray();
        int length = array.Length;
        TransactionDetailsChannelsResp detailsChannelsResp = new TransactionDetailsChannelsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<TransactionDetailsChannelsResp>("Response {@value}", detailsChannelsResp);
        return detailsChannelsResp;
      }
      TransactionDetailsChannelsResp detailsChannelsResp1 = new TransactionDetailsChannelsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<TransactionDetailsChannelsResp>("Response {@value}", detailsChannelsResp1);
      return detailsChannelsResp1;
    }

    [HttpPost]
    public AccountDetailsResp AccountDetails([FromBody] CBNIntegration.Models.AccountDetails accountDetails)
    {
            if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))

              
      {
        AccountDetailsReq accountDetailsReq = new AccountDetailsReq()
        {
          AccountNo = accountDetails.ACCOUNTNO
        };
        this.logger.Info<AccountDetailsReq>("Request {@value}", accountDetailsReq);
        CBNIntegration.Models.AccountDetails[] array = this.cBNIntegrationData.AccountDetails(accountDetailsReq).ToArray();
        int length = array.Length;
        AccountDetailsResp accountDetailsResp = new AccountDetailsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<AccountDetailsResp>("Response {@value}", accountDetailsResp);
        return accountDetailsResp;
      }
      AccountDetailsResp accountDetailsResp1 = new AccountDetailsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<AccountDetailsResp>("Response {@value}", accountDetailsResp1);
      return accountDetailsResp1;
    }

    [HttpPost]
    public AccountDetailsChannelsResp AccountDetailsChannels(
      [FromBody] AccountDetailsChannelsReq accountDetailsChannelsReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        AccountDetailsChannelsReq accountDetailsChannelsReq1 = new AccountDetailsChannelsReq()
        {
          AccountNo = accountDetailsChannelsReq.AccountNo
        };
        this.logger.Info<AccountDetailsChannelsReq>("Request {@value}", accountDetailsChannelsReq1);
        CBNIntegration.Models.AccountDetailsChannels[] array = this.cBNIntegrationData.AccountDetailsChannels(accountDetailsChannelsReq1).ToArray();
        int length = array.Length;
        AccountDetailsChannelsResp detailsChannelsResp = new AccountDetailsChannelsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<AccountDetailsChannelsResp>("Response {@value}", detailsChannelsResp);
        return detailsChannelsResp;
      }
      AccountDetailsChannelsResp detailsChannelsResp1 = new AccountDetailsChannelsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<AccountDetailsChannelsResp>("Response {@value}", detailsChannelsResp1);
      return detailsChannelsResp1;
    }

    [HttpPost]
    public SignatoriesResp Signatories([FromBody] SignatoriesReq signatoriesReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        SignatoriesReq signatoriesReq1 = new SignatoriesReq()
        {
          AccountNo = signatoriesReq.AccountNo
        };
        this.logger.Info<SignatoriesReq>("Request {@value}", signatoriesReq1);
        CBNIntegration.Models.Signatories[] array = this.cBNIntegrationData.Signatories(signatoriesReq1).ToArray();
        int length = array.Length;
        SignatoriesResp signatoriesResp = new SignatoriesResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<SignatoriesResp>("Response {@value}", signatoriesResp);
        return signatoriesResp;
      }
      SignatoriesResp signatoriesResp1 = new SignatoriesResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<SignatoriesResp>("Response {@value}", signatoriesResp1);
      return signatoriesResp1;
    }

    //[HttpPost]
    //public SignatoriesWithNINResp SignatoriesWithNIN(
    //  [FromBody] SignatoriesWithNINReq signatoriesWithNINReq)
    //{

    //        if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
    //        {
    //            SignatoriesWithNINReq signatoriesWithNINReq1 = new SignatoriesWithNINReq()
    //    {
    //      AccountNo = signatoriesWithNINReq.AccountNo
    //    };
    //    this.logger.Info<SignatoriesWithNINReq>("Request {@value}", signatoriesWithNINReq1);
    //    CBNIntegration.Models.SignatoriesWithNIN[] array = this.cBNIntegrationData.SignatoriesWithNIN(signatoriesWithNINReq1).ToArray();
    //    int length = array.Length;
    //    SignatoriesWithNINResp signatoriesWithNinResp = new SignatoriesWithNINResp()
    //    {
    //      Status = this.success.ResponseCode,
    //      Msg = this.success.ResponseMessage,
    //      Result = array
    //    };
    //    this.logger.Info<SignatoriesWithNINResp>("Response {@value}", signatoriesWithNinResp);
    //    return signatoriesWithNinResp;
    //  }
    //  SignatoriesWithNINResp signatoriesWithNinResp1 = new SignatoriesWithNINResp()
    //  {
    //    Status = this.failed.ResponseCode,
    //    Msg = this.failed.ResponseMessage
    //  };
    //  this.logger.Info<SignatoriesWithNINResp>("Response {@value}", signatoriesWithNinResp1);
    //  return signatoriesWithNinResp1;
    //}

    [HttpPost]
    public ListAccountsByBVNResp ListAccountsByBVN(
      [FromBody] ListAccountsByBVNReq listAccountsByBVNReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        ListAccountsByBVNReq listAccountsByBVNReq1 = new ListAccountsByBVNReq()
        {
          BVN = listAccountsByBVNReq.BVN
        };
        this.logger.Info<ListAccountsByBVNReq>("Request {@value}", listAccountsByBVNReq1);
        CBNIntegration.Models.ListAccountsByBVN[] array = this.cBNIntegrationData.ListAccountsByBVN(listAccountsByBVNReq1).ToArray();
        int length = array.Length;
        ListAccountsByBVNResp accountsByBvnResp = new ListAccountsByBVNResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListAccountsByBVNResp>("Response {@value}", accountsByBvnResp);
        return accountsByBvnResp;
      }
      ListAccountsByBVNResp accountsByBvnResp1 = new ListAccountsByBVNResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListAccountsByBVNResp>("Response {@value}", accountsByBvnResp1);
      return accountsByBvnResp1;
    }

    [HttpPost]
    public ListAccountsByRCNoResp ListAccountsByRCNo(
      [FromBody] ListAccountsByRCNoReq listAccountsByRCNoReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        ListAccountsByRCNoReq listAccountsByRCNoReq1 = new ListAccountsByRCNoReq()
        {
          RCNo = listAccountsByRCNoReq.RCNo
        };
        this.logger.Info<ListAccountsByRCNoReq>("Request {@value}", listAccountsByRCNoReq1);
        CBNIntegration.Models.ListAccountsByRCNo[] array = this.cBNIntegrationData.ListAccountsByRCNo(listAccountsByRCNoReq1).ToArray();
        int length = array.Length;
        ListAccountsByRCNoResp accountsByRcNoResp = new ListAccountsByRCNoResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListAccountsByRCNoResp>("Response {@value}", accountsByRcNoResp);
        return accountsByRcNoResp;
      }
      ListAccountsByRCNoResp accountsByRcNoResp1 = new ListAccountsByRCNoResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListAccountsByRCNoResp>("Response {@value}", accountsByRcNoResp1);
      return accountsByRcNoResp1;
    }

    [HttpPost]
    public ListAccountsByTINResp ListAccountsByTIN(
      [FromBody] ListAccountsByTINReq listAccountsByTINReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        ListAccountsByTINReq listAccountsByTINReq1 = new ListAccountsByTINReq()
        {
          TIN = listAccountsByTINReq.TIN
        };
        this.logger.Info<ListAccountsByTINReq>("Request {@value}", listAccountsByTINReq1);
        CBNIntegration.Models.ListAccountsByTIN[] array = this.cBNIntegrationData.ListAccountsByTIN(listAccountsByTINReq1).ToArray();
        int length = array.Length;
        ListAccountsByTINResp accountsByTinResp = new ListAccountsByTINResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListAccountsByTINResp>("Response {@value}", accountsByTinResp);
        return accountsByTinResp;
      }
      ListAccountsByTINResp accountsByTinResp1 = new ListAccountsByTINResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListAccountsByTINResp>("Response {@value}", accountsByTinResp1);
      return accountsByTinResp1;
    }

    [HttpPost]
    public ListAccountsByNINResp ListAccountsByNIN(
      [FromBody] ListAccountsByNINReq listAccountsByNINReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        ListAccountsByNINReq listAccountsByNINReq1 = new ListAccountsByNINReq()
        {
          NIN = listAccountsByNINReq.NIN
        };
        this.logger.Info<ListAccountsByNINReq>("Request {@value}", listAccountsByNINReq1);
        CBNIntegration.Models.ListAccountsByNIN[] array = this.cBNIntegrationData.ListAccountsByNIN(listAccountsByNINReq1).ToArray();
        int length = array.Length;
        ListAccountsByNINResp accountsByNinResp = new ListAccountsByNINResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListAccountsByNINResp>("Response {@value}", accountsByNinResp);
        return accountsByNinResp;
      }
      ListAccountsByNINResp accountsByNinResp1 = new ListAccountsByNINResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListAccountsByNINResp>("Response {@value}", accountsByNinResp1);
      return accountsByNinResp1;
    }

    [HttpPost]
    public ActiveTINResp ActiveTIN([FromBody] ActiveTINReq activeTINReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<ActiveTINReq>("Request {@value}", activeTINReq);
        CBNIntegration.Models.ActiveTIN[] array = this.cBNIntegrationData.ActiveTIN().ToArray();
        int length = array.Length;
        ActiveTINResp activeTinResp = new ActiveTINResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ActiveTINResp>("Response {@value}", activeTinResp);
        return activeTinResp;
      }
      ActiveTINResp activeTinResp1 = new ActiveTINResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ActiveTINResp>("Response {@value}", activeTinResp1);
      return activeTinResp1;
    }

    [HttpPost]
    public ActiveRCNoResp ActiveRCNo(ActiveRCNoReq activeRCNoReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<ActiveRCNoReq>("Request {@value}", activeRCNoReq);
        CBNIntegration.Models.ActiveRCNo[] array = this.cBNIntegrationData.ActiveRCNo().ToArray();
        int length = array.Length;
        ActiveRCNoResp activeRcNoResp = new ActiveRCNoResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ActiveRCNoResp>("Response {@value}", activeRcNoResp);
        return activeRcNoResp;
      }
      ActiveRCNoResp activeRcNoResp1 = new ActiveRCNoResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ActiveRCNoResp>("Response {@value}", activeRcNoResp1);
      return activeRcNoResp1;
    }

    [HttpPost]
    public ActiveNINResp ActiveNIN(ActiveNINReq activeNINReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<ActiveNINReq>("Request {@value}", activeNINReq);
        CBNIntegration.Models.ActiveNIN[] array = this.cBNIntegrationData.ActiveNIN().ToArray();
        int length = array.Length;
        ActiveNINResp activeNinResp = new ActiveNINResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ActiveNINResp>("Response {@value}", activeNinResp);
        return activeNinResp;
      }
      ActiveNINResp activeNinResp1 = new ActiveNINResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ActiveNINResp>("Response {@value}", activeNinResp1);
      return activeNinResp1;
    }

    [HttpPost]
    public ListTIN_RCNoResp ListTIN_RCNo(ListTIN_RCNoReq listTIN_RCNoReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<ListTIN_RCNoReq>("Request {@value}", listTIN_RCNoReq);
        CBNIntegration.Models.ListTIN_RCNo[] array = this.cBNIntegrationData.ListTIN_RCNo().ToArray();
        int length = array.Length;
        ListTIN_RCNoResp listTinRcNoResp = new ListTIN_RCNoResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListTIN_RCNoResp>("Response {@value}", listTinRcNoResp);
        return listTinRcNoResp;
      }
      ListTIN_RCNoResp listTinRcNoResp1 = new ListTIN_RCNoResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListTIN_RCNoResp>("Response {@value}", listTinRcNoResp1);
      return listTinRcNoResp1;
    }

    [HttpPost]
        public ListLedgerCodesResp ListLedgerCodes(ListLedgerCodesReq listLedgerCodesReq)
        {
            if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
            {
                this.logger.Info<ListLedgerCodesReq>("Request {@value}", listLedgerCodesReq);
                CBNIntegration.Models.ListLedgerCodes[] array = this.cBNIntegrationData.ListLedgerCodes().ToArray();
                int length = array.Length;
                ListLedgerCodesResp listLedgerCodesResp = new ListLedgerCodesResp()
                {
                    Status = this.success.ResponseCode,
                    Msg = this.success.ResponseMessage,
                    Result = array
                };
                this.logger.Info<ListLedgerCodesResp>("Response {@value}", listLedgerCodesResp);
                return listLedgerCodesResp;
            }
            ListLedgerCodesResp listLedgerCodesResp1 = new ListLedgerCodesResp()
            {
                Status = this.failed.ResponseCode,
                Msg = this.failed.ResponseMessage
            };
            this.logger.Info<ListLedgerCodesResp>("Response {@value}", listLedgerCodesResp1);
            return listLedgerCodesResp1;
        }

        [HttpPost]
    public ListInternalAccountsResp ListInternalAccounts(
      [FromBody] ListInternalAccountsReq listInternalAccountsReq)
    {
      string AuthToken = this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim();
      ListInternalAccountsReq listInternalAccountsReq1 = new ListInternalAccountsReq()
      {
        LedgerCode = listInternalAccountsReq.LedgerCode
      };
      if (CBNController.ValidateToken(AuthToken))
      {
        this.logger.Info<ListInternalAccountsReq>("Request {@value}", listInternalAccountsReq1);
        CBNIntegration.Models.ListInternalAccounts[] array = this.cBNIntegrationData.ListInternalAccounts(listInternalAccountsReq1).ToArray();
        int length = array.Length;
        ListInternalAccountsResp internalAccountsResp = new ListInternalAccountsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListInternalAccountsResp>("Response {@value}", internalAccountsResp);
        return internalAccountsResp;
      }
      ListInternalAccountsResp internalAccountsResp1 = new ListInternalAccountsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListInternalAccountsResp>("Response {@value}", internalAccountsResp1);
      return internalAccountsResp1;
    }

    [HttpPost]
    public ListInternalAccountsFullResp ListInternalAccountsFull(
      [FromBody] ListInternalAccountsFullReq listInternalAccountsFullReq)
    {
      string AuthToken = this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim();
      ListInternalAccountsFullReq listInternalAccountsFullReq1 = new ListInternalAccountsFullReq()
      {
        LedgerCode = listInternalAccountsFullReq.LedgerCode
      };
      if (CBNController.ValidateToken(AuthToken))
      {
        this.logger.Info<ListInternalAccountsFullReq>("Request {@value}", listInternalAccountsFullReq1);
        CBNIntegration.Models.ListInternalAccountsFull[] array = this.cBNIntegrationData.ListInternalAccountsFull(listInternalAccountsFullReq1).ToArray();
        int length = array.Length;
        ListInternalAccountsFullResp accountsFullResp = new ListInternalAccountsFullResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListInternalAccountsFullResp>("Response {@value}", accountsFullResp);
        return accountsFullResp;
      }
      ListInternalAccountsFullResp accountsFullResp1 = new ListInternalAccountsFullResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListInternalAccountsFullResp>("Response {@value}", accountsFullResp1);
      return accountsFullResp1;
    }

    //[HttpPost]
    //public InternalAccountsSignatoriesResp InternalAccountsSignatories(
    //  [FromBody] InternalAccountsSignatoriesReq internalAccountsSignatoriesReq)
    //{
    //  string AuthToken = this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim();
    //  InternalAccountsSignatoriesReq internalAccountsSignatoriesReq1 = new InternalAccountsSignatoriesReq()
    //  {
    //    LedgerCode = internalAccountsSignatoriesReq.LedgerCode
    //  };
    //  if (CBNController.ValidateToken(AuthToken))
    //  {
    //    this.logger.Info<InternalAccountsSignatoriesReq>("Request {@value}", internalAccountsSignatoriesReq1);
    //    CBNIntegration.Models.InternalAccountsSignatories[] array = this.cBNIntegrationData.InternalAccountsSignatories(internalAccountsSignatoriesReq1).ToArray();
    //    int length = array.Length;
    //    InternalAccountsSignatoriesResp accountsSignatoriesResp = new InternalAccountsSignatoriesResp()
    //    {
    //      Status = this.success.ResponseCode,
    //      Msg = this.success.ResponseMessage,
    //      Result = array
    //    };
    //    this.logger.Info<InternalAccountsSignatoriesResp>("Response {@value}", accountsSignatoriesResp);
    //    return accountsSignatoriesResp;
    //  }
    //  InternalAccountsSignatoriesResp accountsSignatoriesResp1 = new InternalAccountsSignatoriesResp()
    //  {
    //    Status = this.failed.ResponseCode,
    //    Msg = this.failed.ResponseMessage
    //  };
    //  this.logger.Info<InternalAccountsSignatoriesResp>("Response {@value}", accountsSignatoriesResp1);
    //  return accountsSignatoriesResp1;
    //}

    [HttpPost]
    public ListStatisticsResp ListStatistics([FromBody] ListStatisticsReq listStatisticsReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<ListStatisticsReq>("Request {@value}", listStatisticsReq);
        CBNIntegration.Models.ListStatistics[] array = this.cBNIntegrationData.ListStatistics().ToArray();
        int length = array.Length;
        ListStatisticsResp listStatisticsResp = new ListStatisticsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ListStatisticsResp>("Response {@value}", listStatisticsResp);
        return listStatisticsResp;
      }
      ListStatisticsResp listStatisticsResp1 = new ListStatisticsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ListStatisticsResp>("Response {@value}", listStatisticsResp1);
      return listStatisticsResp1;
    }

    [HttpPost]
    public DormantStatisticsResp DormantStatistics(
      [FromBody] DormantStatisticsReq dormantStatisticsReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<DormantStatisticsReq>("Request {@value}", dormantStatisticsReq);
        CBNIntegration.Models.DormantStatistics[] array = this.cBNIntegrationData.DormantStatistics().ToArray();
        int length = array.Length;
        DormantStatisticsResp dormantStatisticsResp = new DormantStatisticsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<DormantStatisticsResp>("Response {@value}", dormantStatisticsResp);
        return dormantStatisticsResp;
      }
      DormantStatisticsResp dormantStatisticsResp1 = new DormantStatisticsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<DormantStatisticsResp>("Response {@value}", dormantStatisticsResp1);
      return dormantStatisticsResp1;
    }

    [HttpPost]
    public ClosedStatisticsResp ClosedStatistics(
      [FromBody] ClosedStatisticsReq closedStatisticsReq)
    {
      if (CBNController.ValidateToken(this.Request.Headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<ClosedStatisticsReq>("Request {@value}", closedStatisticsReq);
        CBNIntegration.Models.ClosedStatistics[] array = this.cBNIntegrationData.ClosedStatistics().ToArray();
        int length = array.Length;
        ClosedStatisticsResp closedStatisticsResp = new ClosedStatisticsResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<ClosedStatisticsResp>("Response {@value}", closedStatisticsResp);
        return closedStatisticsResp;
      }
      ClosedStatisticsResp closedStatisticsResp1 = new ClosedStatisticsResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<ClosedStatisticsResp>("Response {@value}", closedStatisticsResp1);
      return closedStatisticsResp1;
    }

    [HttpPost]
    public PendingDebitResp PendingDebit([FromBody] PendingDebitReq pendingDebitReq)
    {
      HttpRequestHeaders headers = this.Request.Headers;
      PendingDebitReq pendingDebitReq1 = new PendingDebitReq()
      {
        AccountNo = pendingDebitReq.AccountNo
      };
      if (CBNController.ValidateToken(headers.GetValues("Authorization").First<string>().ToString().Substring("Bearer ".Length).Trim()))
      {
        this.logger.Info<PendingDebitReq>("Request {@value}", pendingDebitReq);
        CBNIntegration.Models.PendingDebit[] array = this.cBNIntegrationData.PendingDebit(pendingDebitReq1).ToArray();
        int length = array.Length;
        PendingDebitResp pendingDebitResp = new PendingDebitResp()
        {
          Status = this.success.ResponseCode,
          Msg = this.success.ResponseMessage,
          Result = array
        };
        this.logger.Info<PendingDebitResp>("Response {@value}", pendingDebitResp);
        return pendingDebitResp;
      }
      PendingDebitResp pendingDebitResp1 = new PendingDebitResp()
      {
        Status = this.failed.ResponseCode,
        Msg = this.failed.ResponseMessage
      };
      this.logger.Info<PendingDebitResp>("Response {@value}", pendingDebitResp1);
      return pendingDebitResp1;
    }

    private static bool ValidateToken(string AuthToken)
    {
      JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
      TokenValidationParameters validationParameters = CBNController.GetValidationParameters();
      IPrincipal principal = (IPrincipal) securityTokenHandler.ValidateToken(AuthToken, validationParameters, out SecurityToken _);
      return true;
    }

    private static TokenValidationParameters GetValidationParameters() => new TokenValidationParameters()
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = "wemabank.com",
      ValidAudience = "cbn.gov.ng",
      IssuerSigningKey = (SecurityKey) new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jlklk;lkl;wkwipoiuwoulwlrwwqxdwfrr"))
    };

    public string dateConvert(string date) => DateTime.ParseExact(date.Replace("-", ""), "ddMMyyyy", (IFormatProvider) CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy", (IFormatProvider) CultureInfo.CurrentCulture);
  }
}
