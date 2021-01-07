using NLog;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using CBNIntegrationData.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text;
using System.IO;

namespace CBNIntegrationData_NEW.Data
{
    public class CBNIntegrationCRUD
    {
        string ConnStr = string.Empty, jsonOutputParam = "@jsonOutput", json = string.Empty;
        Logger logger = LogManager.GetCurrentClassLogger();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        readonly string connectionString = ConfigurationManager.ConnectionStrings["FinacleDataAccess"].ConnectionString;
        readonly string TransactionDetailsQry = ConfigurationManager.AppSettings["TransactionDetailsQry"];
        readonly string TransactionDetailsChannelQry = ConfigurationManager.AppSettings["TransactionDetailsChannelQry"];
        readonly string AccountDetailsQry = ConfigurationManager.AppSettings["AccountDetailsQry"];
        readonly string AccountDetailsChannelsQry = ConfigurationManager.AppSettings["AccountDetailsChannelsQry"];
        readonly string SignatoriesQry = ConfigurationManager.AppSettings["SignatoriesQry"];
        readonly string SignatoriesWithNINQry = ConfigurationManager.AppSettings["SignatoriesWithNINQry"];
        readonly string ListAccountsByBVNQry = ConfigurationManager.AppSettings["ListAccountsByBVNQry"];
        readonly string ListAccountsByRCNoQry = ConfigurationManager.AppSettings["ListAccountsByRCNoQry"];
        readonly string ListAccountsByTINQry = ConfigurationManager.AppSettings["ListAccountsByTINQry"];
        readonly string ListAccountsByNINQry = ConfigurationManager.AppSettings["ListAccountsByNINQry"];
        readonly string ActiveTINQry = ConfigurationManager.AppSettings["ActiveTINQry"];
        readonly string ActiveRCNoQry = ConfigurationManager.AppSettings["ActiveRCNoQry"];
        readonly string ActiveNINQry = ConfigurationManager.AppSettings["ActiveNINQry"];
        readonly string ListTIN_RCNoQry = ConfigurationManager.AppSettings["ListTIN_RCNoQry"];
        readonly string ListInternalAccountsQry = ConfigurationManager.AppSettings["ListInternalAccountsQry"];
        readonly string ListInternalAccountsFullQry = ConfigurationManager.AppSettings["ListInternalAccountsFullQry"];
        readonly string InternalAccountsSignatoriesQry = ConfigurationManager.AppSettings["InternalAccountsSignatoriesQry"];
        readonly string ListStatisticsQry = ConfigurationManager.AppSettings["ListStatisticsQry"];
        readonly string DormantStatisticsQry = ConfigurationManager.AppSettings["DormantStatisticsQry"];
        readonly string ClosedStatisticsQry = ConfigurationManager.AppSettings["ClosedStatisticsQry"];
        readonly string PendingDebitQry = ConfigurationManager.AppSettings["PendingDebitQry"];

        string sql = string.Empty, result = string.Empty;
        
        public string TransactionDetails(string StartDate, string EndDate, string AccountNo)
        {
            // sql = string.Format(TransactionDetailsQry, AccountNo, StartDate, EndDate); \\CBNResources\\TransactionDetailsQry.txt
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), TransactionDetailsQry), Encoding.UTF8), AccountNo, StartDate, EndDate);
            logger.Info("Logging TransactionDetails Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("TransactionDetails Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string TransactionDetailsChannels(string StartDate, string EndDate, string AccountNo)
        {
            // sql = string.Format(TransactionDetailsChannelQry,AccountNo,StartDate,EndDate); \\CBNResources\\TransactionDetailsChannelQry.txt
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), TransactionDetailsChannelQry), Encoding.UTF8), AccountNo, StartDate, EndDate);
            logger.Info("Logging TransactionDetailsChannel Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("TransactionDetailsChannel Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string AccountDetails(string AccountNo)
        {
            //sql = string.Format(AccountDetailsQry,AccountNo); "\\CBNResources\\AccountDetailsQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), AccountDetailsQry), Encoding.UTF8), AccountNo);
            logger.Info("Logging AccountDetails Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("AccountDetails Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string AccountDetailsChannels(string AccountNo)
        {
            //sql = string.Format(AccountDetailsChannelsQry,AccountNo); "\\CBNResources\\AccountDetailsChannelsQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), AccountDetailsChannelsQry), Encoding.UTF8), AccountNo);
            logger.Info("Logging AccountDetailsChannels Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("AccountDetailsChannels Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string Signatories(string AccountNo)
        {

            //sql = string.Format(SignatoriesQry,AccountNo);"\\CBNResources\\SignatoriesQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), SignatoriesQry), Encoding.UTF8), AccountNo);
            logger.Info("Logging Signatories Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("Signatories Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string SignatoriesWithNIN(string AccountNo)
        {
            //sql = string.Format(SignatoriesWithNINQry,AccountNo); "\\CBNResources\\SignatoriesWithNINQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), SignatoriesWithNINQry), Encoding.UTF8), AccountNo);
            logger.Info("Logging SignatoriesWithNIN Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("SignatoriesWithNIN Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListAccountsByBVN(string BVN)
        {

            //sql = string.Format(ListAccountsByBVNQry,BVN); "\\CBNResources\\ListAccountsByBVNQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListAccountsByBVNQry), Encoding.UTF8), BVN);
            logger.Info("Logging ListAccountsByBVN Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListAccountsByBVN Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListAccountsByRCNo(string RCNo)
        {

            // sql = string.Format(ListAccountsByRCNoQry,RCNo); "\\CBNResources\\ListAccountsByRCNoQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListAccountsByRCNoQry), Encoding.UTF8), RCNo);
            logger.Info("Logging ListAccountsByRCNo Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListAccountsByRCNo Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListAccountsByTIN(string TIN)
        {

            // sql = string.Format(ListAccountsByTINQry,TIN); "\\CBNResources\\ListAccountsByTINQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListAccountsByTINQry), Encoding.UTF8), TIN);
            logger.Info("Logging ListAccountsByTIN Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListAccountsByTIN Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListAccountsByNIN(string NIN)
        {

            //sql = string.Format(ListAccountsByNINQry,NIN); "\\CBNResources\\ListAccountsByNINQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListAccountsByNINQry), Encoding.UTF8), NIN);
            logger.Info("Logging ListAccountsByNIN Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListAccountsByNIN Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ActiveTIN()
        {

            //sql = string.Format(ActiveTINQry); "\\CBNResources\\ActiveTINQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ActiveTINQry), Encoding.UTF8));
            logger.Info("Logging ActiveTIN Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ActiveTIN Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ActiveRCNo()
        {

            //sql = string.Format(ActiveRCNoQry);"\\CBNResources\\ActiveRCNoQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ActiveRCNoQry), Encoding.UTF8));
            logger.Info("Logging ActiveRCNo Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ActiveRCNo Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ActiveNIN()
        {

            //sql = string.Format(ActiveNINQry); "\\CBNResources\\ActiveNINQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ActiveNINQry), Encoding.UTF8));
            logger.Info("Logging ActiveNIN Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ActiveNIN Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListTIN_RCNo()
        {

            // sql = string.Format(ListTIN_RCNoQry);"\\CBNResources\\ListTIN_RCNoQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListTIN_RCNoQry), Encoding.UTF8));
            logger.Info("Logging ListTIN_RCNo Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListTIN_RCNo Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListInternalAccounts(string LedgerCode)
        {

            //sql = string.Format(ListInternalAccountsQry, LedgerCode);"\\CBNResources\\ListInternalAccountsQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListInternalAccountsQry), Encoding.UTF8), LedgerCode);
            logger.Info("Logging ListInternalAccounts Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListInternalAccounts Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListInternalAccountsFull(string LedgerCode)
        {

            //sql = string.Format(ListInternalAccountsFullQry, LedgerCode); "\\CBNResources\\ListInternalAccountsFullQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListInternalAccountsFullQry), Encoding.UTF8), LedgerCode);
            logger.Info("Logging ListInternalAccountsFull Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListInternalAccountsFull Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string InternalAccountsSignatories(string LedgerCode)
        {

            //sql = string.Format(InternalAccountsSignatoriesQry, LedgerCode);  "\\CBNResources\\InternalAccountsSignatoriesQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), InternalAccountsSignatoriesQry), Encoding.UTF8),LedgerCode);
            logger.Info("Logging InternalAccountsSignatories Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("InternalAccountsSignatories Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ListStatistics()
        {

            //sql = string.Format(ListStatisticsQry); "\\CBNResources\\ListStatisticsQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ListStatisticsQry), Encoding.UTF8));
            logger.Info("Logging ListStatistics Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ListStatistics Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string DormantStatistics()
        {
            // string sql = File.ReadAllText(@"DormantStatisticsQry.txt", Encoding.UTF8);
            //string sql  = File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Resources\\DormantStatisticsQry.txt");

            // string sql  = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), DormantStatisticsQry), Encoding.UTF8); "\\CBNResources\\DormantStatisticsQry.txt"

            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), DormantStatisticsQry), Encoding.UTF8));
            //sql = string.Format(DormantStatisticsQry);
            logger.Info("Logging DormantStatistics Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("DormantStatistics Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string ClosedStatistics()
        {

            //sql = string.Format(ClosedStatisticsQry); "\\CBNResources\\ClosedStatisticsQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ClosedStatisticsQry), Encoding.UTF8));
            logger.Info("Logging ClosedStatistics Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("ClosedStatistics Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        public string PendingDebit(string AccountNo)
        {

            //sql = string.Format(ClosedStatisticsQry); "\\CBNResources\\ClosedStatisticsQry.txt"
            sql = string.Format(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), PendingDebitQry), Encoding.UTF8), AccountNo);
            logger.Info("Logging PendingDebit Query:: " + sql);
            try
            {
                result = QueryCalls(sql);
                return result;
            }
            catch (Exception ex)
            {
                logger.Info("PendingDebit Query Entered Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }

        private string QueryCalls(string sql)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            logger.Info("Logging CBNIntegration Finacle Connection:: " + sql);
            try
            {
                logger.Info("CBNIntegration QueryCalls:: " + connectionString);
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = new OracleCommand(sql, conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    logger.Info(sql + " ::::::Logging RowCount::: " + dt.Rows.Count);
                    int rowCount = dt.Rows.Count;
                    if (rowCount > 0)
                    {
                        
                        Dictionary<string, object> row;
                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }

                    }
                    conn.Close();
                    return serializer.Serialize(rows);
                }
            }
            catch (OracleException ex)
            {
                logger.Info("::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
            catch (Exception ex)
            {
                logger.Info("PND Exception::: " + ex.Message);
                return "Something Went Wrong: " + "General App Exception - No Record Found";
            }
        }


        //private string QueryCalls2(DataSet ds)
        //{
        

        //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        //    logger.Info("Logging CBNIntegration Finacle Connection:: " + sql);
        //    try
        //    {
        //        logger.Info("CBNIntegration QueryCalls:: " + connectionString);
        //        using (OracleConnection conn = new OracleConnection(connectionString))
        //        {
        //            OracleCommand cmd = new OracleCommand(sql, conn);
        //            conn.Open();
        //            cmd.CommandType = CommandType.Text;
        //            OracleDataAdapter oda = new OracleDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            oda.Fill(dt);
        //            logger.Info(sql + " ::::::Logging RowCount::: " + dt.Rows.Count);
        //            int rowCount = dt.Rows.Count;
        //            if (rowCount > 0)
        //            {

        //                //Dictionary<string, object> row;
        //                //foreach (DataRow dr in dt.Rows)
        //                //{
        //                //    row = new Dictionary<string, object>();
        //                //    foreach (DataColumn col in dt.Columns)
        //                //    {
        //                //        row.Add(col.ColumnName, dr[col]);
        //                //    }
        //                //    rows.Add(row);
        //                //}

        //                ArrayList root = new ArrayList();
        //                List<Dictionary<string, object>> row;
        //                Dictionary<string, object> rows;
        //                foreach (DataTable dt in ds.Tables)
        //                {
        //                    row = new List<Dictionary<string, object>>();
        //                    foreach (DataRow dr in dt.Rows)
        //                    {
        //                        rows = new Dictionary<string, object>();
        //                        foreach (DataColumn col in dt.Columns)
        //                        {
        //                            row.Add(col.ColumnName, dr[col]);
        //                        }
        //                        row.Add(rows);
        //                    }
        //                    root.Add(row);

        //                }
        //            }
        //            conn.Close();
        //            // JObject json = JObject.Parse();
        //            return JsonConvert.SerializeObject(rows, Formatting.Indented);
        //        }
        //    }
        //    catch (OracleException ex)
        //    {
        //        logger.Info("::: " + ex.Message);
        //        return "Something Went Wrong: " + "General App Exception - No Record Found";
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Info("PND Exception::: " + ex.Message);
        //        return "Something Went Wrong: " + "General App Exception - No Record Found";
        //    }
        //}
        public string ValidateUser(string username, string password)
        {
            ConnStr = ConfigurationManager.ConnectionStrings["CBNIntegrationDB"].ConnectionString;
            
            try
            {
                if(username == "CBN"){

              
                //logger.Info("Checking Username and Password");
                //using (SqlConnection conn = new SqlConnection(ConnStr))
                //{
                //    if (conn.State == ConnectionState.Closed)
                //    {

                //        conn.Open();
                //        SqlCommand command = new SqlCommand("CBNIntegrationUserSelect", conn);
                //        command.CommandType = CommandType.StoredProcedure;
                //        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                //        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;                        
                //        command.Parameters.Add(jsonOutputParam, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                //        command.ExecuteNonQuery();
                //        json = command.Parameters[jsonOutputParam].Value.ToString();

                //        conn.Close();

                //    }


                //}

                
                }
                logger.Info("Checking Username and Password");
                //return json;
                return "1|2";

            }

            catch (Exception ex)
            {
                logger.Info("Checking Username and Password");
                logger.Info(ex.Message); logger.Info(ex.StackTrace);
                return "Something Went Wrong: " + "General App Exception - No Record Found"; 

            }
        }

        //public string ConvertDataTabletoString()
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection("Data Source=SureshDasari;Initial Catalog=master;Integrated Security=true"))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select title=City,lat=latitude,lng=longitude,description from LocationDetails", con))
        //        {
        //            con.Open();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(dt);
        //            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        //            Dictionary<string, object> row;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                row = new Dictionary<string, object>();
        //                foreach (DataColumn col in dt.Columns)
        //                {
        //                    row.Add(col.ColumnName, dr[col]);
        //                }
        //                rows.Add(row);
        //            }
        //            return serializer.Serialize(rows);
        //        }
        //    }
        //}
    }
}