using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBNIntegrationData.Models
{
    public class TransactionDetailsReq
    {

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AccountNo { get; set; }
    }

    public class TransactionDetailsChannelsReq
    {

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AccountNo { get; set; }
    }

    public class AccountDetailsReq
    {

        public string AccountNo { get; set; }
    }

    public class AccountDetailsChannelsReq
    {
        public string AccountNo { get; set; }
    }

    public class SignatoriesReq
    {

        public string AccountNo { get; set; }
    }

    public class SignatoriesWithNINReq
    {
        public string AccountNo { get; set; }
    }

    public class ListAccountsByBVNReq
    {
        public string BVN { get; set; }
    }

    public class ListAccountsByRCNoReq
    {

        public string RCNo { get; set; }
    }

    public class ListAccountsByTINReq
    {

        public string TIN { get; set; }
    }

    public class ListAccountsByNINReq
    {

        public string NIN { get; set; }
    }

    public class ListInternalAccountsReq
    {

        public string LedgerCode { get; set; }
    }

    public class ListInternalAccountsFullReq
    {

        public string LedgerCode { get; set; }
    }

    public class InternalAccountsSignatoriesReq
    {

        public string LedgerCode { get; set; }
    }

    public class ListStatisticsReq
    {
        public string LedgerCode { get; set; }
    }

    public class DormantStatisticsReq
    {
        public string LedgerCode { get; set; }
    }

    public class ClosedStatisticsReq
    {
        public string LedgerCode { get; set; }
    }

    public class Auth
    {
        public string ApiKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

   
}