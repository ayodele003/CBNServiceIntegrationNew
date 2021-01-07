// Decompiled with JetBrains decompiler
// Type: CBNIntegration.Data.CBNIntegrationData
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using CBNIntegration.Models;
using Dapper;
using NLog;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CBNIntegration.Data
{
  public class CBNIntegrationData
  {
    private Logger logger = LogManager.GetCurrentClassLogger();
    private XmlDocument doc = new XmlDocument();
    private readonly string url = ConfigurationManager.AppSettings["BaseURL"];
    private ResponseBody responseBody = new ResponseBody();
    private SuccessResponse successResponse = new SuccessResponse();
    private ErrorResponse errorResponse = new ErrorResponse();
    private EmptyResponse emptyResponse = new EmptyResponse();
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["FinacleDataAccess"].ConnectionString;
    private readonly string TransactionDetailsQry = ConfigurationManager.AppSettings[nameof (TransactionDetailsQry)];
    private readonly string TransactionDetailsChannelQry = ConfigurationManager.AppSettings[nameof (TransactionDetailsChannelQry)];
    private readonly string AccountDetailsQry = ConfigurationManager.AppSettings[nameof (AccountDetailsQry)];
    private readonly string AccountDetailsChannelsQry = ConfigurationManager.AppSettings[nameof (AccountDetailsChannelsQry)];
    private readonly string SignatoriesQry = ConfigurationManager.AppSettings[nameof (SignatoriesQry)];
    private readonly string SignatoriesWithNINQry = ConfigurationManager.AppSettings[nameof (SignatoriesWithNINQry)];
    private readonly string ListAccountsByBVNQry = ConfigurationManager.AppSettings[nameof (ListAccountsByBVNQry)];
    private readonly string ListAccountsByRCNoQry = ConfigurationManager.AppSettings[nameof (ListAccountsByRCNoQry)];
    private readonly string ListAccountsByTINQry = ConfigurationManager.AppSettings[nameof (ListAccountsByTINQry)];
    private readonly string ListAccountsByNINQry = ConfigurationManager.AppSettings[nameof (ListAccountsByNINQry)];
    private readonly string ActiveTINQry = ConfigurationManager.AppSettings[nameof (ActiveTINQry)];
    private readonly string ActiveRCNoQry = ConfigurationManager.AppSettings[nameof (ActiveRCNoQry)];
    private readonly string ActiveNINQry = ConfigurationManager.AppSettings[nameof (ActiveNINQry)];
    private readonly string ListTIN_RCNoQry = ConfigurationManager.AppSettings[nameof (ListTIN_RCNoQry)];
    private readonly string ListLedgerCodesQry = ConfigurationManager.AppSettings[nameof (ListLedgerCodesQry)];
    private readonly string ListInternalAccountsQry = ConfigurationManager.AppSettings[nameof (ListInternalAccountsQry)];
    private readonly string ListInternalAccountsFullQry = ConfigurationManager.AppSettings[nameof (ListInternalAccountsFullQry)];
    private readonly string InternalAccountsSignatoriesQry = ConfigurationManager.AppSettings[nameof (InternalAccountsSignatoriesQry)];
    private readonly string ListStatisticsQry = ConfigurationManager.AppSettings[nameof (ListStatisticsQry)];
    private readonly string DormantStatisticsQry = ConfigurationManager.AppSettings[nameof (DormantStatisticsQry)];
    private readonly string ClosedStatisticsQry = ConfigurationManager.AppSettings[nameof (ClosedStatisticsQry)];
    private readonly string PendingDebitQry = ConfigurationManager.AppSettings[nameof (PendingDebitQry)];

    public List<CBNIntegration.Models.TransactionDetails> TransactionDetails(
      TransactionDetailsReq transactionDetailsReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.TransactionDetailsQry), Encoding.UTF8), (object) transactionDetailsReq.AccountNo, (object) transactionDetailsReq.StartDate, (object) transactionDetailsReq.EndDate);
          List<CBNIntegration.Models.TransactionDetails> list = cnn.Query<CBNIntegration.Models.TransactionDetails>(sql).ToList<CBNIntegration.Models.TransactionDetails>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.TransactionDetails>();
      }
    }

    public List<CBNIntegration.Models.TransactionDetailsChannels> TransactionDetailsChannels(
      TransactionDetailsChannelsReq transactionDetailsChannelsReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.TransactionDetailsChannelQry), Encoding.UTF8), (object) transactionDetailsChannelsReq.AccountNo, (object) transactionDetailsChannelsReq.StartDate, (object) transactionDetailsChannelsReq.EndDate);
          List<CBNIntegration.Models.TransactionDetailsChannels> list = cnn.Query<CBNIntegration.Models.TransactionDetailsChannels>(sql).ToList<CBNIntegration.Models.TransactionDetailsChannels>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.TransactionDetailsChannels>();
      }
    }

    public List<CBNIntegration.Models.AccountDetails> AccountDetails(
      AccountDetailsReq accountDetailsReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.AccountDetailsQry), Encoding.UTF8), (object) accountDetailsReq.AccountNo);
          List<CBNIntegration.Models.AccountDetails> list = cnn.Query<CBNIntegration.Models.AccountDetails>(sql).ToList<CBNIntegration.Models.AccountDetails>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.AccountDetails>();
      }
    }

    public List<CBNIntegration.Models.AccountDetailsChannels> AccountDetailsChannels(
      AccountDetailsChannelsReq accountDetailsChannelsReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.AccountDetailsChannelsQry), Encoding.UTF8), (object) accountDetailsChannelsReq.AccountNo);
          List<CBNIntegration.Models.AccountDetailsChannels> list = cnn.Query<CBNIntegration.Models.AccountDetailsChannels>(sql).ToList<CBNIntegration.Models.AccountDetailsChannels>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.AccountDetailsChannels>();
      }
    }

    public List<CBNIntegration.Models.Signatories> Signatories(
      SignatoriesReq signatoriesReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.SignatoriesQry), Encoding.UTF8), (object) signatoriesReq.AccountNo);
          List<CBNIntegration.Models.Signatories> list = cnn.Query<CBNIntegration.Models.Signatories>(sql).ToList<CBNIntegration.Models.Signatories>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.Signatories>();
      }
    }

    public List<CBNIntegration.Models.SignatoriesWithNIN> SignatoriesWithNIN(
      SignatoriesWithNINReq signatoriesWithNINReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.SignatoriesWithNINQry), Encoding.UTF8), (object) signatoriesWithNINReq.AccountNo);
          List<CBNIntegration.Models.SignatoriesWithNIN> list = cnn.Query<CBNIntegration.Models.SignatoriesWithNIN>(sql).ToList<CBNIntegration.Models.SignatoriesWithNIN>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.SignatoriesWithNIN>();
      }
    }

    public List<CBNIntegration.Models.ListAccountsByBVN> ListAccountsByBVN(
      ListAccountsByBVNReq listAccountsByBVNReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListAccountsByBVNQry), Encoding.UTF8), (object) listAccountsByBVNReq.BVN);
          List<CBNIntegration.Models.ListAccountsByBVN> list = cnn.Query<CBNIntegration.Models.ListAccountsByBVN>(sql).ToList<CBNIntegration.Models.ListAccountsByBVN>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListAccountsByBVN>();
      }
    }

    public List<CBNIntegration.Models.ListAccountsByRCNo> ListAccountsByRCNo(
      ListAccountsByRCNoReq listAccountsByRCNoReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListAccountsByRCNoQry), Encoding.UTF8), (object) listAccountsByRCNoReq.RCNo);
          List<CBNIntegration.Models.ListAccountsByRCNo> list = cnn.Query<CBNIntegration.Models.ListAccountsByRCNo>(sql).ToList<CBNIntegration.Models.ListAccountsByRCNo>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListAccountsByRCNo>();
      }
    }

    public List<CBNIntegration.Models.ListAccountsByTIN> ListAccountsByTIN(
      ListAccountsByTINReq listAccountsByTINReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListAccountsByTINQry), Encoding.UTF8), (object) listAccountsByTINReq.TIN);
          List<CBNIntegration.Models.ListAccountsByTIN> list = cnn.Query<CBNIntegration.Models.ListAccountsByTIN>(sql).ToList<CBNIntegration.Models.ListAccountsByTIN>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListAccountsByTIN>();
      }
    }

    public List<CBNIntegration.Models.ListAccountsByNIN> ListAccountsByNIN(
      ListAccountsByNINReq listAccountsByNINReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListAccountsByNINQry), Encoding.UTF8), (object) listAccountsByNINReq.NIN);
          List<CBNIntegration.Models.ListAccountsByNIN> list = cnn.Query<CBNIntegration.Models.ListAccountsByNIN>(sql).ToList<CBNIntegration.Models.ListAccountsByNIN>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListAccountsByNIN>();
      }
    }

    public List<CBNIntegration.Models.ActiveTIN> ActiveTIN()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ActiveTINQry), Encoding.UTF8));
          List<CBNIntegration.Models.ActiveTIN> list = cnn.Query<CBNIntegration.Models.ActiveTIN>(sql).ToList<CBNIntegration.Models.ActiveTIN>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ActiveTIN>();
      }
    }

    public List<CBNIntegration.Models.ActiveRCNo> ActiveRCNo()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ActiveRCNoQry), Encoding.UTF8));
          List<CBNIntegration.Models.ActiveRCNo> list = cnn.Query<CBNIntegration.Models.ActiveRCNo>(sql).ToList<CBNIntegration.Models.ActiveRCNo>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ActiveRCNo>();
      }
    }

    public List<CBNIntegration.Models.ActiveNIN> ActiveNIN()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ActiveNINQry), Encoding.UTF8));
          List<CBNIntegration.Models.ActiveNIN> list = cnn.Query<CBNIntegration.Models.ActiveNIN>(sql).ToList<CBNIntegration.Models.ActiveNIN>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ActiveNIN>();
      }
    }

    public List<CBNIntegration.Models.ListTIN_RCNo> ListTIN_RCNo()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListTIN_RCNoQry), Encoding.UTF8));
          List<CBNIntegration.Models.ListTIN_RCNo> list = cnn.Query<CBNIntegration.Models.ListTIN_RCNo>(sql).ToList<CBNIntegration.Models.ListTIN_RCNo>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListTIN_RCNo>();
      }
    }

    public List<CBNIntegration.Models.ListLedgerCodes> ListLedgerCodes()
        {
            try
            {
                using (OracleConnection cnn = new OracleConnection(this.connectionString))
                {
                    cnn.Open();
                    string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListLedgerCodesQry), Encoding.UTF8));
                    List<CBNIntegration.Models.ListLedgerCodes> list = cnn.Query<CBNIntegration.Models.ListLedgerCodes>(sql).ToList<CBNIntegration.Models.ListLedgerCodes>();
                    cnn.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<CBNIntegration.Models.ListLedgerCodes>();
            }
        }

        public List<CBNIntegration.Models.ListInternalAccounts> ListInternalAccounts(
      ListInternalAccountsReq listInternalAccountsReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListInternalAccountsQry), Encoding.UTF8), (object) listInternalAccountsReq.LedgerCode);
          List<CBNIntegration.Models.ListInternalAccounts> list = cnn.Query<CBNIntegration.Models.ListInternalAccounts>(sql).ToList<CBNIntegration.Models.ListInternalAccounts>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListInternalAccounts>();
      }
    }

    public List<CBNIntegration.Models.ListInternalAccountsFull> ListInternalAccountsFull(
      ListInternalAccountsFullReq listInternalAccountsFullReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListInternalAccountsFullQry), Encoding.UTF8), (object) listInternalAccountsFullReq.LedgerCode);
          List<CBNIntegration.Models.ListInternalAccountsFull> list = cnn.Query<CBNIntegration.Models.ListInternalAccountsFull>(sql).ToList<CBNIntegration.Models.ListInternalAccountsFull>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListInternalAccountsFull>();
      }
    }

    public List<CBNIntegration.Models.InternalAccountsSignatories> InternalAccountsSignatories(
      InternalAccountsSignatoriesReq internalAccountsSignatoriesReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.InternalAccountsSignatoriesQry), Encoding.UTF8), (object) internalAccountsSignatoriesReq.LedgerCode);
          List<CBNIntegration.Models.InternalAccountsSignatories> list = cnn.Query<CBNIntegration.Models.InternalAccountsSignatories>(sql).ToList<CBNIntegration.Models.InternalAccountsSignatories>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.InternalAccountsSignatories>();
      }
    }

    public List<CBNIntegration.Models.ListStatistics> ListStatistics()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ListStatisticsQry), Encoding.UTF8));
          List<CBNIntegration.Models.ListStatistics> list = cnn.Query<CBNIntegration.Models.ListStatistics>(sql).ToList<CBNIntegration.Models.ListStatistics>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ListStatistics>();
      }
    }

    public List<CBNIntegration.Models.DormantStatistics> DormantStatistics()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.DormantStatisticsQry), Encoding.UTF8));
          List<CBNIntegration.Models.DormantStatistics> list = cnn.Query<CBNIntegration.Models.DormantStatistics>(sql).ToList<CBNIntegration.Models.DormantStatistics>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.DormantStatistics>();
      }
    }

    public List<CBNIntegration.Models.ClosedStatistics> ClosedStatistics()
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.ClosedStatisticsQry), Encoding.UTF8));
          List<CBNIntegration.Models.ClosedStatistics> list = cnn.Query<CBNIntegration.Models.ClosedStatistics>(sql).ToList<CBNIntegration.Models.ClosedStatistics>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.ClosedStatistics>();
      }
    }

    public List<CBNIntegration.Models.PendingDebit> PendingDebit(
      PendingDebitReq pendingDebitReq)
    {
      try
      {
        using (OracleConnection cnn = new OracleConnection(this.connectionString))
        {
          cnn.Open();
          string sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), this.PendingDebitQry), Encoding.UTF8), (object) pendingDebitReq.AccountNo);
          List<CBNIntegration.Models.PendingDebit> list = cnn.Query<CBNIntegration.Models.PendingDebit>(sql).ToList<CBNIntegration.Models.PendingDebit>();
          cnn.Close();
          return list;
        }
      }
      catch (Exception ex)
      {
        return new List<CBNIntegration.Models.PendingDebit>();
      }
    }
  }
}
