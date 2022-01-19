//using CaotunSpring.DH.Tools.Data;
//using RadzenDh5.Models;
using RadzenDh5.DHModels;
using RadzenDh5.DHData;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Radzen;
using System.Data.Common;
using System.Data;
using Microsoft.Extensions.Configuration;
using ProgWrt = RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt;
using ProgMst = RadzenDh5.Models.Mark10Sqlexpress04.ProgMst;

namespace CaotunSpring.DH.Tools
{

    public class WESDB
    {
        public static DbProviderFactory dbProviderFactory = null;
        public static string dbConnectionString = null;

        public string ConnectionName = null;

        public WESDB(string DbProviderType, string connectionString)
        {

            try
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);



                dbProviderFactory = DbProviderFactories.GetFactory(DbProviderType);
                dbConnectionString = connectionString;

                if (string.IsNullOrEmpty(dbConnectionString)) throw new Exception("database connection string is null or empty");
                if (dbConnectionString.IndexOf("User") < 0 && dbConnectionString.IndexOf("USER") < 0 && dbConnectionString.IndexOf("user") < 0) dbConnectionString = clsTool_2.funStrDecrypt(dbConnectionString); //解密
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void funGetFactory(string DbProviderType, string connectionString)
        {
            try
            {
                dbProviderFactory = DbProviderFactories.GetFactory(DbProviderType);
                dbConnectionString = connectionString;

                if (string.IsNullOrEmpty(dbConnectionString)) throw new Exception("database connection string is null or empty");

                if (dbConnectionString.IndexOf("User") < 0 && dbConnectionString.IndexOf("USER") < 0 && dbConnectionString.IndexOf("user") < 0) dbConnectionString = clsTool_2.funStrDecrypt(dbConnectionString); //解密
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public enum eumDBTransaction
        {
            Begin,
            Commit,
            Rollback
        }

        public DbConnection funCreateConnection()
        {
            try
            {
                return dbProviderFactory.CreateConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool funIsConnect(DbConnection dbConnection)
        {
            try
            {
                if (dbConnection != null)
                {
                    if (dbConnection.State == ConnectionState.Open)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool funOpenDB(ref DbConnection dbConnection)
        {
            try
            {
                if (dbConnection != null)
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                }

                dbConnection.ConnectionString = dbConnectionString;
                dbConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool funRSSQL(string strSQL, ref DbDataReader dbDataReader, DbConnection dbConnection, DbTransaction dbTransaction)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();
            try
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Transaction = dbTransaction;
                dbCommand.CommandText = strSQL;

                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    return true;
                }
                else
                {
                    dbDataReader.Close();
                    dbDataReader = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (dbDataReader != null)
                {
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
                dbDataReader = null;
                throw new Exception(ex.Message);
            }
            finally
            {
                dbCommand.Dispose();
                dbCommand = null;
            }
        }
        public bool funGetDT(string strSQL, ref DataTable dataTable, DbConnection dbConnection, DbTransaction dbTransaction)
        {
            DbDataAdapter dbAdapter = dbProviderFactory.CreateDataAdapter();
            DbCommand dbCommand = dbConnection.CreateCommand();
            DataTable dt = new DataTable(dataTable.TableName);
            try
            {
                dataTable.Clear();

                dbCommand.CommandType = CommandType.Text;
                dbCommand.Transaction = dbTransaction;
                dbCommand.CommandText = strSQL;

                dbAdapter.SelectCommand = dbCommand;
                dbAdapter.Fill(dt);

                dataTable = dt.Copy();

                if (dataTable.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dt != null) { dt.Dispose(); dt = null; }
                if (dbAdapter != null) { dbAdapter.Dispose(); dbAdapter = null; }
                if (dbCommand != null) { dbCommand.Dispose(); dbCommand = null; }
            }
        }
        public int funExecSQL(string strSQL, DbConnection dbConnection, DbTransaction dbTransaction)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();
            try
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = strSQL;
                dbCommand.Transaction = dbTransaction;

                int iExecNum = dbCommand.ExecuteNonQuery();
                return iExecNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbCommand.Dispose();
                dbCommand = null;
            }
        }
        public bool funCommitCtrl(eumDBTransaction eumTran, DbConnection dbConnection, ref DbTransaction dbTransaction)
        {
            try
            {
                switch (eumTran)
                {
                    case eumDBTransaction.Begin:
                        dbTransaction = dbConnection.BeginTransaction();
                        break;
                    case eumDBTransaction.Commit:
                        dbTransaction.Commit();
                        dbTransaction.Dispose();
                        dbTransaction = null;
                        break;
                    case eumDBTransaction.Rollback:
                        dbTransaction.Rollback();
                        dbTransaction.Dispose();
                        dbTransaction = null;
                        break;
                    default:
                        throw new Exception();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool funCloseDB(ref DbConnection dbConnection)
        {
            try
            {
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;
                return true;
            }
            catch (Exception ex)
            {
                dbConnection.Dispose();
                dbConnection = null;
                throw new Exception(ex.Message);
            }
        }

        public void funExecGetValue(string strSQL, DbConnection dbConnection, out string oValue)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();
            try
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = strSQL;

                oValue = dbCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbCommand.Dispose();
                dbCommand = null;
            }
        }

    }
    public partial class DhGlobalsService
    {
        public static WESDB WMSDB;
        [Inject]
        protected NotificationService NotificationService { get; set; }
        [Inject]
        IConfiguration Configuration { get; set; }

        //public static void ChangeLocStockCat(DataGridViewRow dgvRow, string sSTK_CAT_TO, string sREMARK_TO)
        // STEP 1. Parameter
        //        
        //
        public async Task ChangeLocStockCatAsync(string conn, string DhUsername, RadzenDh5.Models.Mark10Sqlexpress04.Vp080 dgvRow, string sSTK_CAT_TO, string sREMARK_TO)
        {
            // STEP 2. WMSDB
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            int iResult = 0;
            DataTable dtSQL = new DataTable();
            string sSQL = string.Empty;
            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                //string sSTGE_TYPE = Convert.ToString(dgvRow.Cells["STGE_TYPE"].Value);
                //string sSTGE_BIN = Convert.ToString(dgvRow.Cells["STGE_BIN"].Value);

                //string sWHSE_NO = Convert.ToString(dgvRow.Cells["WHSE_NO"].Value).Trim();
                //string sSU_ID = Convert.ToString(dgvRow.Cells["SU_ID"].Value).Trim();
                //string sLOC_NO = Convert.ToString(dgvRow.Cells["LOC_NO"].Value).Trim();
                //string sSKU_NO = Convert.ToString(dgvRow.Cells["SKU_NO"].Value).Trim();
                //string sPLANT = Convert.ToString(dgvRow.Cells["PLANT"].Value).Trim();
                //string sSTGE_LOC = Convert.ToString(dgvRow.Cells["STGE_LOC"].Value).Trim();
                //string sBATCH_NO = Convert.ToString(dgvRow.Cells["BATCH_NO"].Value).Trim();
                //string sSTK_CAT = Convert.ToString(dgvRow.Cells["STK_CAT"].Value).Trim();
                //string sSTK_SPECIAL_IND = Convert.ToString(dgvRow.Cells["STK_SPECIAL_IND"].Value).Trim();
                //string sSTK_SPECIAL_NO = Convert.ToString(dgvRow.Cells["STK_SPECIAL_NO"].Value).Trim();
                //string sGTIN_UNIT = Convert.ToString(dgvRow.Cells["GTIN_UNIT"].Value).Trim();
                //decimal dGTIN_QTY = Convert.ToDecimal(dgvRow.Cells["GTIN_QTY"].Value);
                //string sREMARK = Convert.ToString(dgvRow.Cells["REMARK"].Value).Trim();
                //decimal dGTIN_NUMERATOR = Convert.ToDecimal(dgvRow.Cells["GTIN_NUMERATOR"].Value);
                //decimal dGTIN_DENOMINATOR = Convert.ToDecimal(dgvRow.Cells["GTIN_DENOMINATOR"].Value);
                //string sSKU_UNIT = Convert.ToString(dgvRow.Cells["SKU_UNIT"].Value).Trim();
                //decimal dSKU_QTY = Decimal.Round(dGTIN_NUMERATOR * dGTIN_QTY / dGTIN_DENOMINATOR, 3);
                //string sSKU_SNO_IND = Convert.ToString(dgvRow.Cells["SKU_SNO_IND"].Value).Trim();


                // STEP 3  處理變量
                string sWHSE_NO = Convert.ToString(dgvRow.WHSE_NO).Trim();
                string sSU_ID = Convert.ToString(dgvRow.SU_ID).Trim();
                string sLOC_NO = Convert.ToString(dgvRow.LOC_NO).Trim();
                string sSKU_NO = Convert.ToString(dgvRow.SKU_NO).Trim();
                string sPLANT = Convert.ToString(dgvRow.PLANT).Trim();
                string sSTGE_LOC = Convert.ToString(dgvRow.STGE_LOC).Trim();
                string sBATCH_NO = Convert.ToString(dgvRow.BATCH_NO).Trim();
                string sSTK_CAT = Convert.ToString(dgvRow.STK_CAT).Trim();
                string sSTK_SPECIAL_IND = Convert.ToString(dgvRow.STK_SPECIAL_IND).Trim();
                string sSTK_SPECIAL_NO = Convert.ToString(dgvRow.STK_SPECIAL_NO).Trim();
                string sGTIN_UNIT = Convert.ToString(dgvRow.GTIN_UNIT).Trim();
                decimal dGTIN_QTY = Convert.ToDecimal(dgvRow.GTIN_QTY);
                string sREMARK = Convert.ToString(dgvRow.REMARK).Trim();
                decimal dGTIN_NUMERATOR = Convert.ToDecimal(dgvRow.GTIN_NUMERATOR);
                decimal dGTIN_DENOMINATOR = Convert.ToDecimal(dgvRow.GTIN_DENOMINATOR);
                string sSKU_UNIT = Convert.ToString(dgvRow.SKU_UNIT).Trim();
                decimal dSKU_QTY = Decimal.Round(dGTIN_NUMERATOR * dGTIN_QTY / dGTIN_DENOMINATOR, 3);
                string sSKU_SNO_IND = Convert.ToString(dgvRow.SKU_SNO_IND).Trim();





                if (sSTK_CAT_TO == sSTK_CAT) throw new Exception("invalid STK_CAT_TO:" + sSTK_CAT_TO);

                string sMOVM_TYPE = "";
                switch (sSTK_CAT)
                {
                    case "":
                        if (sSTK_CAT_TO == "Q") sMOVM_TYPE = "322";
                        if (sSTK_CAT_TO == "S") sMOVM_TYPE = "344";
                        break;
                    case "Q":
                        if (sSTK_CAT_TO == "") sMOVM_TYPE = "321";
                        if (sSTK_CAT_TO == "S") sMOVM_TYPE = "350";
                        break;
                    case "S":
                        if (sSTK_CAT_TO == "") sMOVM_TYPE = "343";
                        if (sSTK_CAT_TO == "Q") sMOVM_TYPE = "349";
                        break;
                    default: throw new Exception("invalid STK_CAT:" + sSTK_CAT);
                }

                if (sMOVM_TYPE == "") throw new Exception("invalid STK_CAT_TO:" + sSTK_CAT_TO);

                if (sSTK_CAT_TO != "" && sSTK_CAT_TO != "Q" && sSTK_CAT_TO != "S") throw new Exception("Incorrect stock category:" + sSTK_CAT_TO);

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    //備份LOC_DTL到歷史檔(Source)
                    sSQL = string.Format(@"
                        insert into LOC_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER 
                        from LOC_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    //備份LOC_DTL到歷史檔(Destination)
                    sSQL = string.Format(@"
                        insert into LOC_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER 
                        from LOC_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1)
                    {
                        //無既有數據，直接更改Source為Destination
                        sSQL = string.Format(@"
                        update LOC_DTL set STK_CAT='{10}',TRN_USER=N'{11}',TRN_DATE=convert(varchar(19),getdate(),20),REMARK=REMARK+CASE WHEN '{12}'='' THEN '' ELSE '::{12}' END
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sSTK_CAT_TO, Globals.USER_NAME, sREMARK_TO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);
                    }
                    else
                    {
                        //有既有數據
                        //更新LOC_DTL(Destination須考量合併)
                        sSQL = string.Format(@"
                        update LOC_DTL set GTIN_QTY=GTIN_QTY+{10},SKU_QTY=SKU_QTY+{11},TRN_USER=N'{12}',TRN_DATE=convert(varchar(19),getdate(),20),REMARK=REMARK+CASE WHEN '{13}'='' THEN '' ELSE '::{13}' END
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY, dSKU_QTY, Globals.USER_NAME, sREMARK_TO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                        //刪除Source
                        sSQL = string.Format(@"
                        delete LOC_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);
                    }

                    //備份PLT_DTL到歷史檔(Source)
                    sSQL = string.Format(@"
                        insert into PLT_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER 
                        from PLT_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    //生成PC_LOG
                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                    string sPC_NO = sCMD_DATE + GetCmdSno(ref dbConnection, ref dbTransaction, "PC", sCMD_DATE, 4);
                    string sPC_LINE = "0001";

                    //生成PC_LOG
                    sSQL = string.Format(@"
                        insert into PC_LOG (WHSE_NO,PC_NO,PC_LINE,SU_ID,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,SKU_UNIT,SKU_QTY,MOVM_TYPE,STK_CAT_TO,STK_SPECIAL_IND_TO,STK_SPECIAL_NO_TO,SKU_QTY_TO,PC_USER,PC_DATE,PC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',convert(varchar(19),getdate(),20),'0','','1','Y','{19}',convert(varchar(19),getdate(),20),'{19}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sPC_NO, sPC_LINE, sSU_ID, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, dSKU_QTY, sMOVM_TYPE, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, dSKU_QTY, Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    //更新前須先產生PC_SNO
                    sSQL = string.Format(@"
                    insert into PC_SNO 
                    select distinct '{0}' as WHSE_NO, '{1}' as PC_NO, '{2}' as PC_LINE, IN_SNO , '{3}' as TRN_USER,convert(varchar(19),getdate(),20) as TRN_DATE,'{3}' as CRT_USER,convert(varchar(19),getdate(),20) as CRT_DATE
                    from PLT_DTL 
                    where SU_ID='{4}' and SKU_NO='{5}' and PLANT='{6}' and STGE_LOC='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and GTIN_UNIT='{12}'
                ", sWHSE_NO, sPC_NO, sPC_LINE, Globals.USER_NAME, sSU_ID, sSKU_NO, sPLANT, sSTGE_LOC, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    //要判斷是否有序列號
                    if (sSKU_SNO_IND == "Y")
                    {
                        //有序列號者不可拆數量，要變只能一起變，否則就是在PLT明細變更
                        //直接將Source改為Destination
                        sSQL = string.Format(@"
                        update PLT_DTL set STK_CAT='{10}'
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sSTK_CAT_TO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);
                    }
                    else
                    {
                        //備份PLT_DTL到歷史檔(Destination)
                        sSQL = string.Format(@"
                        insert into PLT_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER 
                        from PLT_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, Globals.USER_NAME);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1)
                        {
                            //無Destination既有數據，直接改Source為Destination
                            sSQL = string.Format(@"
                        update PLT_DTL set STK_CAT='{10}'
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sSTK_CAT_TO); //只異動該筆
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);
                        }
                        else
                        {
                            //有Destination既有數據
                            //更新PLT_DTL(須考慮合併到Destination情況)
                            sSQL = string.Format(@"
                        update PLT_DTL set GTIN_QTY=GTIN_QTY+{10},SKU_QTY=SKU_QTY+{11}
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY, dSKU_QTY);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                            //刪除Source
                            sSQL = string.Format(@"
                        delete PLT_DTL
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        }
                    }

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dbTransaction != null) { dbTransaction.Dispose(); dbTransaction = null; }

                if (dtSQL != null) { dtSQL.Dispose(); dtSQL = null; }
            }
        }


        public async Task<ProgWrt> GetProgWrt(string USER_ID, string PROG_ID)
        {
            var obj = await Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID).AsNoTracking().FirstOrDefaultAsync();
            return obj;
        }

        public async Task<ProgMst> GetProgMst(string PROG_ID)
        {
            var obj = await Db.ProgMsts.Where(a => a.PROG_ID == PROG_ID).AsNoTracking().FirstOrDefaultAsync();
            return obj;
        }

        public async Task<string> GetProgNameByCulture(ProgMst progMst, string Culture)
        {
            if (Culture == "th-TH")
            {
                return progMst.TH_NAME;
            }
            if (Culture == "zh-CHT")
            {
                return progMst.TW_NAME;
            }
            if (Culture == "zh-CHS")
            {
                return progMst.CN_NAME;
            }
            return progMst.PROG_NAME;


        }





        public async Task MLASRS_ChangePlcStockCat_Async(string conn, string DhUsername, RadzenDh5.Models.Mark10Sqlexpress04.Vp080 item, PltDtl item2, string sSTK_CAT_TO, decimal dGTIN_QTY_TO)
        {
            //throw new Exception("[ChangeLocStockCat] no data update:" + "SQL....");
            // LogProg("P080", "ChangeLocStockCat, DhUsername = " + DhUsername);
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);


            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            int iResult = 0;
            DataTable dtSQL = new DataTable();
            string sSQL = string.Empty;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                string sWHSE_NO = Convert.ToString(item.WHSE_NO).Trim();
                string sSTGE_TYPE = Convert.ToString(item.STGE_TYPE).Trim();
                string sSTGE_BIN = Convert.ToString(item.STGE_BIN).Trim();
                string sSU_ID = Convert.ToString(item.SU_ID).Trim();
                string sSU_TYPE = Convert.ToString(item.SU_TYPE).Trim();
                string sLOC_NO = Convert.ToString(item.LOC_NO).Trim();
                string sSKU_NO = Convert.ToString(item.SKU_NO).Trim();
                string sPLANT = Convert.ToString(item.PLANT).Trim();
                string sSTGE_LOC = Convert.ToString(item.STGE_LOC).Trim();
                string sBATCH_NO = Convert.ToString(item.BATCH_NO).Trim();
                string sSTK_CAT = Convert.ToString(item.STK_CAT).Trim();
                string sSTK_SPECIAL_IND = Convert.ToString(item.STK_SPECIAL_IND).Trim();
                string sSTK_SPECIAL_NO = Convert.ToString(item.STK_SPECIAL_NO).Trim();
                string sGTIN_UNIT = Convert.ToString(item.GTIN_UNIT).Trim();
                decimal dGTIN_QTY_LOC = Convert.ToDecimal(item.GTIN_QTY);
                decimal dGTIN_NUMERATOR = Convert.ToDecimal(item.GTIN_NUMERATOR);
                decimal dGTIN_DENOMINATOR = Convert.ToDecimal(item.GTIN_DENOMINATOR);
                decimal dGROSS_WEIGHT = Convert.ToDecimal(item.GROSS_WEIGHT);
                decimal dNET_WEIGHT = Convert.ToDecimal(item.NET_WEIGHT);
                string sWEIGHT_UNIT = Convert.ToString(item.WEIGHT_UNIT).Trim();
                decimal dVOLUME = Convert.ToDecimal(item.VOLUME);
                string sVOLUME_UNIT = Convert.ToString(item.VOLUME_UNIT).Trim();
                string sREMARK = Convert.ToString(item.REMARK).Trim();
                decimal dGTIN_ALO_QTY = Convert.ToDecimal(item.GTIN_ALO_QTY);
                string sSKU_UNIT = Convert.ToString(item.SKU_UNIT).Trim();
                decimal dSKU_QTY_LOC = Convert.ToDecimal(item.SKU_QTY);
                decimal dSKU_ALO_QTY = Convert.ToDecimal(item.SKU_ALO_QTY);

                if (dGTIN_ALO_QTY > 0) throw new Exception("Allocated storage unit can't change stock category");

                string sSKU_SNO_IND = Convert.ToString(item.SKU_SNO_IND).Trim();

                //PLT_DTL是針對IN_SNO整筆變更，如果IN_SNO='**********'才能拆分數量
                string sIN_SNO = Convert.ToString(item2.IN_SNO).Trim();
                string sIN_NO = Convert.ToString(item2.IN_NO).Trim();
                string sIN_LINE = Convert.ToString(item2.IN_LINE).Trim();
                decimal dGTIN_QTY_PLT = Convert.ToDecimal(item2.GTIN_QTY); //原有數量

                decimal dSKU_QTY_TO = Decimal.Round(dGTIN_NUMERATOR * dGTIN_QTY_TO / dGTIN_DENOMINATOR, 3); //Destination拆分
                decimal dGROSS_WEIGHT_TO = Decimal.Round(dGROSS_WEIGHT * dGTIN_QTY_TO / dGTIN_QTY_LOC, 3); //Destination拆分
                decimal dNET_WEIGHT_TO = Decimal.Round(dNET_WEIGHT * dGTIN_QTY_TO / dGTIN_QTY_LOC, 3); //Destination拆分
                decimal dVOLUME_TO = Decimal.Round(dVOLUME * dGTIN_QTY_TO / dGTIN_QTY_LOC, 3); //Destination拆分

                if (sSTK_CAT_TO == sSTK_CAT) throw new Exception("invalid STK_CAT_TO:" + sSTK_CAT_TO);

                string sMOVM_TYPE = "";
                switch (sSTK_CAT)
                {
                    case "":
                        if (sSTK_CAT_TO == "Q") sMOVM_TYPE = "322";
                        if (sSTK_CAT_TO == "S") sMOVM_TYPE = "344";
                        break;
                    case "Q":
                        if (sSTK_CAT_TO == "") sMOVM_TYPE = "321";
                        if (sSTK_CAT_TO == "S") sMOVM_TYPE = "350";
                        break;
                    case "S":
                        if (sSTK_CAT_TO == "") sMOVM_TYPE = "343";
                        if (sSTK_CAT_TO == "Q") sMOVM_TYPE = "349";
                        break;
                    default: throw new Exception("invalid STK_CAT:" + sSTK_CAT);
                }

                if (sMOVM_TYPE == "") throw new Exception("invalid STK_CAT_TO:" + sSTK_CAT_TO);

                if (sSTK_CAT_TO != "" && sSTK_CAT_TO != "Q" && sSTK_CAT_TO != "S") throw new Exception("Incorrect stock category:" + sSTK_CAT_TO);

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    //備份LOC_DTL到歷史檔(Source)
                    sSQL = string.Format(@"
                        insert into LOC_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER 
                        from LOC_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, DhUsername);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    //備份LOC_DTL到歷史檔(Destination)
                    sSQL = string.Format(@"
                    insert into LOC_DTL_HIS 
                    select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER 
                    from LOC_DTL 
                    where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, DhUsername);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1)
                    {
                        //無Destination既有數據
                        if (dGTIN_QTY_TO == dGTIN_QTY_LOC)
                        {
                            //直接更改Source為Destination
                            sSQL = string.Format(@"
                            update LOC_DTL set STK_CAT='{10}',TRN_USER=N'{11}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sSTK_CAT_TO, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);
                        }
                        else
                        {
                            //拆分為2筆
                            sSQL = string.Format(@"
                            insert into LOC_DTL(WHSE_NO,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_ALO_QTY,SKU_ALO_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}',{16},{17},{18},{19},{20},'{21}',{22},'{23}',{24},{25},'{26}','{27}',convert(varchar(19),getdate(),20),'{24}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sSTGE_TYPE, sSTGE_BIN, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY_TO, sSKU_UNIT, dSKU_QTY_TO, dGTIN_NUMERATOR, dGTIN_DENOMINATOR, dGROSS_WEIGHT_TO, dNET_WEIGHT_TO, sWEIGHT_UNIT, dVOLUME_TO, sVOLUME_UNIT, 0, 0, "", DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data create:" + sSQL);

                            //更新LOC_DTL(Source)
                            sSQL = string.Format(@"
                            update LOC_DTL set GTIN_QTY=GTIN_QTY-{10},SKU_QTY=SKU_QTY-{11},GROSS_WEIGHT=GROSS_WEIGHT-{12},NET_WEIGHT=NET_WEIGHT-{13},VOLUME=VOLUME-{14},TRN_USER=N'{15}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY_TO, dSKU_QTY_TO, dGROSS_WEIGHT_TO, dNET_WEIGHT_TO, dVOLUME_TO, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);
                        }
                    }
                    else
                    {
                        //有既有數據
                        //更新LOC_DTL(Destination)
                        sSQL = string.Format(@"
                            update LOC_DTL set GTIN_QTY=GTIN_QTY+{10},SKU_QTY=SKU_QTY+{11},GROSS_WEIGHT=GROSS_WEIGHT+{12},NET_WEIGHT=NET_WEIGHT+{13},VOLUME=VOLUME+{14},TRN_USER=N'{15}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY_TO, dSKU_QTY_TO, dGROSS_WEIGHT_TO, dNET_WEIGHT_TO, dVOLUME_TO, DhUsername);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);

                        if (dGTIN_QTY_TO == dGTIN_QTY_LOC)
                        {
                            //刪除Source
                            sSQL = string.Format(@"
                        delete LOC_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);
                        }
                        else
                        {
                            //更新LOC_DTL(Source)
                            sSQL = string.Format(@"
                            update LOC_DTL set GTIN_QTY=GTIN_QTY-{10},SKU_QTY=SKU_QTY-{11},GROSS_WEIGHT=GROSS_WEIGHT-{12},NET_WEIGHT=NET_WEIGHT-{13},VOLUME=VOLUME+{14},TRN_USER=N'{15}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY_TO, dSKU_QTY_TO, dGROSS_WEIGHT_TO, dNET_WEIGHT_TO, dVOLUME_TO, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);
                        }
                    }

                    //備份PLT_DTL到歷史檔by IN_SNO(Source)
                    sSQL = string.Format(@"
                        insert into PLT_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{11}' as LOG_USER 
                        from PLT_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, DhUsername);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    //要判斷是否有序列號
                    if (sSKU_SNO_IND == "Y")
                    {
                        //有序列號者不可拆數量，要變只能一起變，否則就是在PLT明細變更
                        //直接將Source改為Destination by IN_SNO
                        sSQL = string.Format(@"
                        update PLT_DTL set STK_CAT='{11}'
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, sSTK_CAT_TO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);
                    }
                    else
                    {
                        //備份PLT_DTL到歷史檔by IN_SNO(Destination)
                        sSQL = string.Format(@"
                        insert into PLT_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{13}' as LOG_USER 
                        from PLT_DTL 
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}' and IN_NO='{11}' and IN_LINE='{12}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, sIN_NO, sIN_LINE, DhUsername);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1)
                        {
                            //無Destination既有數據，直接改Source為Destination by IN_SNO
                            sSQL = string.Format(@"
                        update PLT_DTL set STK_CAT='{13}'
                        where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}' and IN_NO='{11}' and IN_LINE='{12}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, sIN_NO, sIN_LINE, sSTK_CAT_TO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);
                        }
                        else
                        {
                            //有Destination既有數據(IN_SNO='**********'可以拆數量)
                            //更新PLT_DTL(Destination) by IN_SNO
                            sSQL = string.Format(@"
                            update PLT_DTL set GTIN_QTY=GTIN_QTY+{13},SKU_QTY=SKU_QTY+{14}
                            where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}' and IN_NO='{11}' and IN_LINE='{12}'
                        ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, sIN_NO, sIN_LINE, dGTIN_QTY_TO, dSKU_QTY_TO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            if (dGTIN_QTY_TO == dGTIN_QTY_PLT)
                            {
                                //刪除Source
                                sSQL = string.Format(@"
                                delete PLT_DTL
                                where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}' and IN_NO='{11}' and IN_LINE='{12}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, sIN_NO, sIN_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data delete:" + sSQL);
                            }
                            else
                            {
                                //減Source
                                sSQL = string.Format(@"
                                update PLT_DTL set GTIN_QTY=GTIN_QTY-{13},SKU_QTY=SKU_QTY-{14}
                                where WHSE_NO='{0}' and SU_ID ='{1}' and PLANT ='{2}' and STGE_LOC ='{3}' and SKU_NO ='{4}' and IsNull(BATCH_NO,'') ='{5}' and IsNull(STK_CAT,'') ='{6}' and IsNull(STK_SPECIAL_IND,'') ='{7}' and IsNull(STK_SPECIAL_NO,'') ='{8}' and GTIN_UNIT ='{9}' and IN_SNO='{10}' and IN_NO='{11}' and IN_LINE='{12}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO, sIN_NO, sIN_LINE, dGTIN_QTY_TO, dSKU_QTY_TO);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }
                        }
                    }

                    // LINE#4122, Globals.cs
                    //生成PC_LOG
                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                    string sPC_NO = sCMD_DATE + GetCmdSno(ref dbConnection, ref dbTransaction, "PC", sCMD_DATE, 4);
                    string sPC_LINE = "0001";


                    //生成PC_LOG
                    sSQL = string.Format(@"
                        insert into PC_LOG (WHSE_NO,PC_NO,PC_LINE,SU_ID,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,SKU_UNIT,SKU_QTY,MOVM_TYPE,STK_CAT_TO,STK_SPECIAL_IND_TO,STK_SPECIAL_NO_TO,SKU_QTY_TO,PC_USER,PC_DATE,PC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',convert(varchar(19),getdate(),20),'0','','1','Y','{19}',convert(varchar(19),getdate(),20),'{19}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sPC_NO, sPC_LINE, sSU_ID, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, dSKU_QTY_LOC, sMOVM_TYPE, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, dSKU_QTY_TO, DhUsername);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    //更新前須先產生PC_SNO
                    sSQL = string.Format(@"
                    insert into PC_SNO 
                    select distinct '{0}' as WHSE_NO, '{1}' as PC_NO, '{2}' as PC_LINE, IN_SNO , '{3}' as TRN_USER,convert(varchar(19),getdate(),20) as TRN_DATE,'{3}' as CRT_USER,convert(varchar(19),getdate(),20) as CRT_DATE
                    from PLT_DTL 
                    where SU_ID='{4}' and SKU_NO='{5}' and PLANT='{6}' and STGE_LOC='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and GTIN_UNIT='{12}' and IN_SNO='{13}'
                ", sWHSE_NO, sPC_NO, sPC_LINE, DhUsername, sSU_ID, sSKU_NO, sPLANT, sSTGE_LOC, sBATCH_NO, sSTK_CAT_TO, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    dbTransaction.Commit();
                   // LogProg("P080", " after  dbTransaction.Commit();");
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dbTransaction != null) { dbTransaction.Dispose(); dbTransaction = null; }
                if (dtSQL != null) { dtSQL.Dispose(); dtSQL = null; }
            }


        }



        //Globals.USER_NAME


        private class Globals
        {
            public static string USER_NAME;
        }





        public static string DB_PROVIDER_TYPE = "System.Data.SqlClient"; // static, Note by Mark, 05/09
        /// <summary>
        /// 命名規則: CO30 rootname Async
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="DhUsername"></param>
        /// <param name="sPROG_ID"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task C030CountConfirmAsync(string conn, string DhUsername, string sPROG_ID, string sWHSE_NO, string sPIC_NO, string sPIC_TYPE, string sAPPROVE)
        {
            // READABLE, by Mark, 05/09, 不再取代 Globals.USER_NAME ， 直接按這格式給值
            Globals.USER_NAME = DhUsername;

            try // 將整個  try 往上提, LINE#798
            {
                // NOTE by Mark, implement static DB_PROVIDER_TYPE
                WMSDB = new WESDB(DB_PROVIDER_TYPE, conn);
                //throw new Exception(" TESTING [C030CountConfirmAsync] [throw new Exception], 確認這模擬的信息能回到上層, 在頁面 ErrMsg 顯示 ");

                //整單確認 LINE#788
                DbConnection dbConnection = WMSDB.funCreateConnection();
                DbTransaction dbTransaction = null;
                DataTable dtSQL = new DataTable();
                DataTable dtTable = new DataTable();

                string sSQL = string.Empty;

                int iResult = 0;

                // 测试数据库连接是否成功
                // NOTE by Mark, 無需在這裡重覆, 
                //dbConnection = WMSDB.funCreateConnection();

                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                //更新不能盤點的PIC_DTL
                sSQL = string.Format(@"
                update PIC_DTL set PIC_STS='8',COUNT_QTY=0,TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),APPROVE_IND='Y' 
                where PIC_STS in ('0','1','2','3') and WHSE_NO='{0}' and PIC_NO='{1}' and COUNT_QTY=0 
                and NOT EXISTS(select * from LOC_DTL where SU_ID=PIC_DTL.SU_ID and WHSE_NO=PIC_DTL.WHSE_NO and PLANT=PIC_DTL.PLANT and STGE_LOC=PIC_DTL.STGE_LOC and SKU_NO=PIC_DTL.SKU_NO and BATCH_NO=PIC_DTL.BATCH_NO and GTIN_UNIT=PIC_DTL.COUNT_UNIT)
            ", sWHSE_NO, sPIC_NO);
                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                sSQL = string.Format(@"
                    select distinct a.* from PIC_DTL a 
                    join LOC_DTL b on (a.SU_ID=b.SU_ID and a.SKU_NO=b.SKU_NO and a.BATCH_NO=b.BATCH_NO and a.COUNT_UNIT=b.GTIN_UNIT) 
                    where a.WHSE_NO='{0}' and a.PIC_NO='{1}' and a.PIC_STS in ('0','1','2','3','9') and a.APPROVE_IND='N' 
                ", sWHSE_NO, sPIC_NO);
                dtSQL = new DataTable();
                WMSDB.funGetDT(sSQL, ref dtSQL, dbConnection, dbTransaction);
                if (dtSQL.Rows.Count < 1) return;


                // TESTING BY MARK, 05/10 00:36
                //DataTable dd = dtSQL; 
                //Save_Excel(dd, $@"A12345.xls", "AAA BBB CCC", "2021-01-01", "2021-03-31");


                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    //更新盤點明細
                    for (int i = 0; i < dtSQL.Rows.Count; i++)
                    {
                        string sPIC_LINE = Convert.ToString(dtSQL.Rows[i]["PIC_LINE"]);
                        string sSTGE_TYPE = Convert.ToString(dtSQL.Rows[i]["STGE_TYPE"]);
                        string sSTGE_BIN = Convert.ToString(dtSQL.Rows[i]["STGE_BIN"]);
                        string sSU_ID = Convert.ToString(dtSQL.Rows[i]["SU_ID"]);
                        string sPLANT = Convert.ToString(dtSQL.Rows[i]["PLANT"]);
                        string sSTGE_LOC = Convert.ToString(dtSQL.Rows[i]["STGE_LOC"]);
                        string sSKU_NO = Convert.ToString(dtSQL.Rows[i]["SKU_NO"]);
                        string sBATCH_NO = Convert.ToString(dtSQL.Rows[i]["BATCH_NO"]);
                        string sCOUNT_UNIT = Convert.ToString(dtSQL.Rows[i]["COUNT_UNIT"]);
                        decimal dCOUNT_QTY = Convert.ToDecimal(dtSQL.Rows[i]["COUNT_QTY"]);
                        string sPIC_STS = Convert.ToString(dtSQL.Rows[i]["PIC_STS"]);
                        decimal dCOUNT_QTY_SNO = 0;

                        sSQL = string.Format(@"
                        select IsNull(sum(COUNT_QTY),0) as COUNT_QTY from PIC_SNO 
                        where WHSE_NO='{0}' and PIC_NO='{1}' and PIC_LINE='{2}'
                    ", sWHSE_NO, sPIC_NO, sPIC_LINE);
                        dtTable = new DataTable();
                        if (WMSDB.funGetDT(sSQL, ref dtTable, dbConnection, dbTransaction))
                        {
                            dCOUNT_QTY_SNO = Convert.ToDecimal(dtTable.Rows[0]["COUNT_QTY"]);
                        }
                        else
                        {
                            dCOUNT_QTY_SNO = 0;
                        }

                        if (dCOUNT_QTY_SNO == 0 && sPIC_STS != "3") //沒有輸入盤點數據，自動計算盤點數據
                        {
                            decimal dGTIN_QTY = 0;
                            decimal dSKU_QTY = 0;
                            //如果沒有輸入盤點值默認為庫存值
                            sSQL = string.Format(@"
                            select sum(GTIN_QTY) as GTIN_QTY,sum(SKU_QTY) as SKU_QTY,GTIN_UNIT,SKU_UNIT from LOC_DTL 
                            where SU_ID='{0}' and PLANT='{1}' and STGE_LOC='{2}' and SKU_NO='{3}' and BATCH_NO='{4}' and (GTIN_UNIT='{5}')
                            group by GTIN_UNIT,SKU_UNIT
                        ", sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sCOUNT_UNIT);
                            dtTable = new DataTable();
                            if (WMSDB.funGetDT(sSQL, ref dtTable, dbConnection, dbTransaction))
                            {
                                for (int j = 0; j < dtTable.Rows.Count; j++)
                                {
                                    if (Convert.ToString(dtTable.Rows[j]["GTIN_UNIT"]) == sCOUNT_UNIT)
                                    {
                                        dGTIN_QTY = dGTIN_QTY + Convert.ToDecimal(dtTable.Rows[j]["GTIN_QTY"]);
                                    }
                                    if (Convert.ToString(dtTable.Rows[j]["SKU_UNIT"]) == sCOUNT_UNIT)
                                    {
                                        dSKU_QTY = dSKU_QTY + Convert.ToDecimal(dtTable.Rows[j]["SKU_QTY"]);
                                    }
                                }
                            }
                            if (dGTIN_QTY > 0) dCOUNT_QTY = dGTIN_QTY;
                            if (dSKU_QTY > 0) dCOUNT_QTY = dSKU_QTY;
                        }

                        //dbTransaction = dbConnection.BeginTransaction();
                        try
                        {
                            //備份盤點明細
                            sSQL = string.Format(@"
                            insert into PIC_DTL_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PIC_DTL 
                            where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}' and PIC_STS='{4}'
                        ", Globals.USER_NAME, sWHSE_NO, sPIC_NO, sPIC_LINE, sPIC_STS);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data create:" + sSQL);

                            //更新PIC_STS
                            sSQL = string.Format(@"
                            update PIC_DTL 
                            set PIC_STS='9',APPROVE_IND='{6}',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),COUNT_QTY={1}
                            where WHSE_NO='{2}' and PIC_NO='{3}' and PIC_LINE='{4}' and PIC_STS='{5}'
                        ", Globals.USER_NAME, dCOUNT_QTY, sWHSE_NO, sPIC_NO, sPIC_LINE, sPIC_STS, sAPPROVE);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            //更新PIC_SNO
                            sSQL = string.Format(@"
                            select * from PIC_SNO 
                            where WHSE_NO='{0}' and PIC_NO='{1}' and PIC_LINE='{3}'
                        ", sWHSE_NO, sPIC_NO, sPIC_NO, sPIC_LINE);
                            dtTable = new DataTable();
                            if (!WMSDB.funGetDT(sSQL, ref dtTable, dbConnection, dbTransaction))
                            {
                                //默認為PLT_DTL
                                sSQL = string.Format(@"
                                insert into PIC_SNO 
                                select '{0}' as WHSE_NO,'{1}' as PIC_NO,'{2}' as PIC_LINE,'{3}' as STGE_TYPE,'{4}' as STGE_BIN,'{5}' as SU_ID,'{6}' as PLANT,'{7}' as STGE_LOC,'{8}' as SKU_NO,'{9}' as BATCH_NO,IN_SNO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,'{10}' as COUNT_UNIT,GTIN_QTY as COUNT_QTY,'{11}' as COUNT_USER,convert(varchar(19),getdate(),20) as COUNT_DATE,N'{11}' as APPROVE_USER,convert(varchar(19),getdate(),20) as APPROVE_DATE,convert(varchar(19),getdate(),20) as START_DATE,convert(varchar(19),getdate(),20) as END_DATE,'9' as PIC_STS,'' as REMARK,'1' as SOURCE,'{12}' as APPROVE_IND,convert(varchar(19),getdate(),20) as TRN_DATE,N'{11}' as TRN_USER,convert(varchar(19),getdate(),20) as CRT_DATE,N'{11}' as CRT_USER,IN_NO,IN_LINE
                                from PLT_DTL
                                where WHSE_NO='{0}' and SU_ID='{5}' and PLANT='{6}' and STGE_LOC='{7}' and SKU_NO='{8}' and BATCH_NO='{9}' and GTIN_UNIT='{10}'
                            ", sWHSE_NO, sPIC_NO, sPIC_LINE, sSTGE_TYPE, sSTGE_BIN, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sCOUNT_UNIT, Globals.USER_NAME, sAPPROVE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            }
                            else
                            {
                                //備份盤點明細SNO
                                sSQL = string.Format(@"
                                insert into PIC_SNO_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PIC_SNO 
                                where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}' and PIC_STS in ('0','1')
                            ", Globals.USER_NAME, sWHSE_NO, sPIC_NO, sPIC_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                //if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                //更新盤點明細SNO
                                sSQL = string.Format(@"
                                update PIC_SNO set PIC_STS='9',APPROVE_IND='{5}',APPROVE_USER=N'{0}',APPROVE_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),COUNT_QTY=(CASE WHEN COUNT_QTY>0 THEN COUNT_QTY WHEN GTIN_UNIT='{4}' THEN GTIN_QTY ELSE 0 END)
                                where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}' and PIC_STS in ('0','1','2','3')
                            ", Globals.USER_NAME, sWHSE_NO, sPIC_NO, sPIC_LINE, sCOUNT_UNIT, sAPPROVE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                //if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //dbTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            //dbTransaction.Rollback();
                            throw new Exception(ex.Message);
                        }
                    }

                    sSQL = string.Format(@"
                    select a.* from PIC_DTL a 
                    where a.WHSE_NO='{0}' and a.PIC_NO='{1}' and a.PIC_STS in ('0','1','2','3')
                ", sWHSE_NO, sPIC_NO);
                    dtSQL = new DataTable();
                    if (WMSDB.funGetDT(sSQL, ref dtSQL, dbConnection, dbTransaction)) throw new Exception("need reconfirm");

                    //dbTransaction=dbConnection.BeginTransaction();
                    try
                    {
                        //備份盤點主檔
                        sSQL = string.Format(@"
                        insert into PIC_MST_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PIC_MST 
                        where WHSE_NO='{1}' and PIC_NO='{2}' 
                    ", Globals.USER_NAME, sWHSE_NO, sPIC_NO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data create:" + sSQL);

                        //記錄COUNT_DATE(有可能無庫存)
                        if (sPIC_TYPE != "01" && sAPPROVE == "Y")
                        {
                            sSQL = string.Format(@"
                            update PLT_DTL 
                            set COUNT_DATE=convert(varchar(19),getdate(),20)
                            where SU_ID in (select distinct SU_ID from PIC_DTL where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_STS='9' and COUNT_QTY > 0) 
                        ", Globals.USER_NAME, sWHSE_NO, sPIC_NO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        }

                        //更新盤點主檔
                        sSQL = string.Format(@"
                        update PIC_MST set PIC_STS='9',APPROVE_IND='{3}',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),APPROVE_USER=N'{0}',APPROVE_DATE=convert(varchar(19),getdate(),20)
                        where WHSE_NO='{1}' and PIC_NO='{2}' 
                    ", Globals.USER_NAME, sWHSE_NO, sPIC_NO, sAPPROVE);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);

                        //SAP盤點要Approve後才釋放LOC_MST(ASRS盤點回庫即釋放)
                        if (sPIC_TYPE != "01" && sAPPROVE == "Y")
                        {
                            sSQL = string.Format(@"
                            update LOC_MST 
                            set LOC_STS='S',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where SU_ID in (select distinct SU_ID from PIC_DTL where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_STS='9' and COUNT_QTY > 0) 
                        ", Globals.USER_NAME, sWHSE_NO, sPIC_NO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        }

                        //dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        //dbTransaction.Rollback();
                        throw new Exception(ex.Message);
                    }

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);// NOTE by Mark, 這是確保能將失敗的 Message 回到上層
            }
        }

        /// <summary>
        /// P060
        /// STEP 1: remove static , add conn and DhUsername, turn it to async
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="DhUsername"></param>
        /// <param name="sEQU_NO"></param>
        /// <param name="sLOC_NO"></param>
        /// <param name="sSU_ID"></param>
        /// <param name="sPORT"></param>
        public async Task CreateTransferCMD_OUT(string conn, string DhUsername, string sEQU_NO, string sLOC_NO, string sSU_ID, string sPORT)
        {
            // STEP 2
            Globals.USER_NAME = DhUsername;
            WMSDB = new WESDB(DB_PROVIDER_TYPE, conn); // NOTE by Mark, implement static DB_PROVIDER_TYPE


            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            DataTable dataTable = new DataTable();

            string sSQL = string.Empty;

            int iResult = 0;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try
                {

                    //取得CMD_SNO
                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                    string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                    if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                    //預約LOC_MST
                    sSQL = string.Format(@"update LOC_MST 
                    set LOC_STS='O',TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}'
                    where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='S'
                    ", sLOC_NO, sSU_ID, Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    string sCMD_STS = "0";
                    string sSTN_NO = "";
                    switch (sEQU_NO)
                    {
                        case "01":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 2).ToString("00");
                            break;
                        case "02":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 8).ToString("00");
                            break;
                        case "03":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 14).ToString("00");
                            break;
                        case "04":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 20).ToString("00");
                            break;
                        default:
                            break;
                    }

                    string sPRTY = "5";
                    string sCMD_MODE = "2";
                    string sIO_TYPE = "22"; //Transfer pallet out
                    string sTRACE = "00";
                    string sPROG_ID = "P060";

                    sSQL = string.Format(@"
                insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, "", "", "", "", Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    //檢查母托盤是否已有命令
                    sSQL = string.Format(@"select * from CMD_MST where SU_ID='{0}' and CMD_STS in ('0','1','2','3','4','5','6','F','X')", sSU_ID);
                    WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);

                    if (dataTable.Rows.Count > 1) throw new Exception("duplicate CMD_MST:" + sSQL);

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dataTable != null) { dataTable.Dispose(); dataTable = null; }
            }
        }

        /// <summary>
        /// 
        /// P100
        /// </summary>

        /// <returns></returns>
        public async Task CreateEmptyCMD_OUT(string conn, string DhUsername, string sPROG_ID, string sEQU_NO, string sLOC_NO, string sSU_ID, string sREMARK, string sPORT)
        {

            try
            {
                Globals.USER_NAME = DhUsername;
                //throw new Exception(" TESTING [C030CountConfirmAsync] [throw new Exception], 確認這模擬的信息能回到上層, 在頁面 ErrMsg 顯示 ");

                WMSDB = new WESDB(DB_PROVIDER_TYPE, conn); // NOTE by Mark, implement static DB_PROVIDER_TYPE

                //整單確認
                DbConnection dbConnection = WMSDB.funCreateConnection();
                DbTransaction dbTransaction = null;
                DataTable dataTable = new DataTable();

                string sSQL = string.Empty;

                int iResult = 0;

                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try // This is for Transaction
                {
                    //檢查母托盤是否已有命令
                    sSQL = string.Format(@"select * from CMD_MST where SU_ID='{0}' and CMD_STS in ('0','1','2')", sSU_ID);
                    WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);
                    if (dataTable.Rows.Count > 1) throw new Exception("duplicate CMD_MST:" + sSQL);

                    //取得CMD_SNO
                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                    string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                    if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                    //預約LOC_MST
                    sSQL = string.Format(@"update LOC_MST 
                    set LOC_STS='O',LOC_OSTS='E',TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}'
                    where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='E'
                    ", sLOC_NO, sSU_ID, Globals.USER_NAME);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    string sCMD_STS = "0";
                    string sSTN_NO = "";
                    switch (sEQU_NO)
                    {
                        case "01":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 2).ToString("00");
                            break;
                        case "02":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 8).ToString("00");
                            break;
                        case "03":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 14).ToString("00");
                            break;
                        case "04":
                            sSTN_NO = "A" + (int.Parse(sPORT) + 20).ToString("00");
                            break;
                        default:
                            break;
                    }

                    string sPRTY = "5";
                    string sCMD_MODE = "2";
                    string sIO_TYPE = "20"; //Empty pallet in
                    string sTRACE = "00";
                    //    string sPROG_ID = "P100";

                    sSQL = string.Format(@"
                insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,REMARK)
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20),N'{17}')
                ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, "", "", "", "", Globals.USER_NAME, sREMARK);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);// NOTE by Mark, 這是確保能將失敗的 Message 回到上層
            }
        }


        public async Task MLASRS_ChangePalletQty_Async(string conn, string DhUsername, decimal sGTIN_QTY_NEW, List<Vp070> dgvRows, string sSU_ID_TO, string sLOC_NO_TO, string sSU_TYPE_TO, decimal dGrossWeight_TO, decimal dVolume_TO)
        //public static void ChangePalletQty(DataGridViewRow[] dgvRows, string sSU_ID_TO, string sLOC_NO_TO, string sSU_TYPE_TO, decimal dGrossWeight_TO, decimal dVolume_TO)
        {
            //public async Task MLASRS_AllocateDtl_P030_Async(string conn, string DhUsername, string sPROG_ID, RadzenDh5.Models.Mark10Sqlexpress04.Vp030 item)

            // 最大相容性 NOTE by Mark, 05/08
            // Preparation is ready to use WES code as possible
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);
            // 
            Globals.USER_NAME = DhUsername;


            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            int iResult = 0;
            DataTable dtSQL = new DataTable();
            string sSQL = string.Empty;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    if (string.IsNullOrEmpty(sSU_ID_TO)) throw new Exception("destination storage unit number must input");
                    if (sSU_ID_TO.Length != 6) throw new Exception("destination storage unit number incorrect");

                    foreach (var dgvRow in dgvRows)
                    {
                        //decimal dSKU_QTY = Convert.ToDecimal(dgvRow.Cells["SKU_QTY"].Value);
                        //string sLOC_QTY = Convert.ToString(dgvRow.Cells["LOC_QTY"].Value);
                        //string sGROSS_WEIGHT = Convert.ToString(dgvRow.Cells["GROSS_WEIGHT"].Value);
                        //string sNET_WEIGHT = Convert.ToString(dgvRow.Cells["NET_WEIGHT"].Value);
                        //string sWEIGHT_UNIT = Convert.ToString(dgvRow.Cells["WEIGHT_UNIT"].Value);
                        //string sVOLUME = Convert.ToString(dgvRow.Cells["VOLUME"].Value);
                        //string sVOLUME_UNIT = Convert.ToString(dgvRow.Cells["VOLUME_UNIT"].Value);

                        decimal dSKU_QTY = Convert.ToDecimal(dgvRow.SKU_QTY);
                        string sLOC_QTY = Convert.ToString(dgvRow.LOC_QTY);
                        string sGROSS_WEIGHT = Convert.ToString(dgvRow.GROSS_WEIGHT);
                        string sNET_WEIGHT = Convert.ToString(dgvRow.NET_WEIGHT);
                        string sWEIGHT_UNIT = Convert.ToString(dgvRow.WEIGHT_UNIT);
                        string sVOLUME = Convert.ToString(dgvRow.VOLUME);
                        string sVOLUME_UNIT = Convert.ToString(dgvRow.VOLUME_UNIT);

                        dGrossWeight_TO = dGrossWeight_TO + Decimal.Round(Convert.ToDecimal(sGROSS_WEIGHT) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
                        dVolume_TO = dVolume_TO + Decimal.Round(Convert.ToDecimal(sVOLUME) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
                    }

                    if (dGrossWeight_TO > 960) throw new Exception("Can't over 960KG");

                    if (sSU_TYPE_TO == "L1")
                    {
                        if (dVolume_TO > (Decimal)1.617) throw new Exception("Storage unit type L1 can't over 1.617 M3");
                    }
                    else
                    {
                        if (dVolume_TO > (Decimal)1.925) throw new Exception("Storage unit type L2 can't over 1.925 M3");
                    }

                    foreach (var dgvRow in dgvRows)
                    {
                        //string sWHSE_NO = Convert.ToString(dgvRow.Cells["WHSE_NO"].Value);
                        //string sIN_NO = Convert.ToString(dgvRow.Cells["IN_NO"].Value);
                        //string sIN_LINE = Convert.ToString(dgvRow.Cells["IN_LINE"].Value);
                        //string sSU_ID = Convert.ToString(dgvRow.Cells["SU_ID"].Value);
                        //string sSU_TYPE = Convert.ToString(dgvRow.Cells["SU_TYPE"].Value);
                        //string sIN_SNO = Convert.ToString(dgvRow.Cells["IN_SNO"].Value);

                        //string sGR_DATE = Convert.ToString(dgvRow.Cells["GR_DATE"].Value);
                        //string sEXPIRE_DATE = Convert.ToString(dgvRow.Cells["EXPIRE_DATE"].Value);
                        //string sDATE_CODE = Convert.ToString(dgvRow.Cells["DATE_CODE"].Value);

                        //string sPLANT = Convert.ToString(dgvRow.Cells["PLANT"].Value);
                        //string sSTGE_LOC = Convert.ToString(dgvRow.Cells["STGE_LOC"].Value);
                        //string sSKU_NO = Convert.ToString(dgvRow.Cells["SKU_NO"].Value);
                        //string sBATCH_NO = Convert.ToString(dgvRow.Cells["BATCH_NO"].Value);
                        //string sSTK_CAT = Convert.ToString(dgvRow.Cells["STK_CAT"].Value);
                        //string sSTK_SPECIAL_IND = Convert.ToString(dgvRow.Cells["STK_SPECIAL_IND"].Value);
                        //string sSTK_SPECIAL_NO = Convert.ToString(dgvRow.Cells["STK_SPECIAL_NO"].Value);
                        //string sGTIN_UNIT = Convert.ToString(dgvRow.Cells["GTIN_UNIT"].Value);
                        //string sGTIN_QTY = Convert.ToString(dgvRow.Cells["GTIN_QTY"].Value);
                        string sWHSE_NO = Convert.ToString(dgvRow.WHSE_NO);
                        string sIN_NO = Convert.ToString(dgvRow.IN_NO);
                        string sIN_LINE = Convert.ToString(dgvRow.IN_LINE);
                        string sSU_ID = Convert.ToString(dgvRow.SU_ID);
                        string sSU_TYPE = Convert.ToString(dgvRow.SU_TYPE);
                        string sIN_SNO = Convert.ToString(dgvRow.IN_SNO);

                        string sGR_DATE = Convert.ToString(dgvRow.GR_DATE);
                        string sEXPIRE_DATE = Convert.ToString(dgvRow.EXPIRE_DATE);
                        string sDATE_CODE = Convert.ToString(dgvRow.DATE_CODE);

                        string sPLANT = Convert.ToString(dgvRow.PLANT);
                        string sSTGE_LOC = Convert.ToString(dgvRow.STGE_LOC);
                        string sSKU_NO = Convert.ToString(dgvRow.SKU_NO);
                        string sBATCH_NO = Convert.ToString(dgvRow.BATCH_NO);
                        string sSTK_CAT = Convert.ToString(dgvRow.STK_CAT);
                        string sSTK_SPECIAL_IND = Convert.ToString(dgvRow.STK_SPECIAL_IND);
                        string sSTK_SPECIAL_NO = Convert.ToString(dgvRow.STK_SPECIAL_NO);
                        string sGTIN_UNIT = Convert.ToString(dgvRow.GTIN_UNIT);
                        //string sGTIN_QTY = Convert.ToString(dgvRow.GTIN_QTY); // -----------這應該是
                        string sGTIN_QTY = sGTIN_QTY_NEW.ToString(); //**************************************************

                        bool bDelete = true;
                        // 這裡要處理 GTIN_QTY
                        // 以上下文來看, sGTIN_QTY_OLD 是放在 .Tag
                        // 而 Web 的做法, 是要外加一個欄位以供輸入
                        // 因此 sGTIN_QTY_OLD 仍是 List 帶進去的,
                        // 那麼新的值要額外以參數帶入 , 
                        // sGTIN_QTY_NEW

                        //string sGTIN_QTY_OLD = Convert.ToString(dgvRow.Cells["GTIN_QTY"].Tag);


                        //if (string.IsNullOrEmpty(sGTIN_QTY_OLD)) sGTIN_QTY_OLD = sGTIN_QTY;
                        //if (sGTIN_QTY_OLD != sGTIN_QTY) bDelete = false;

                        //string sSKU_UNIT = Convert.ToString(dgvRow.Cells["SKU_UNIT"].Value);
                        //string sSKU_QTY = Convert.ToString(dgvRow.Cells["SKU_QTY"].Value);
                        //string sCOUNT_DATE = Convert.ToString(dgvRow.Cells["COUNT_DATE"].Value);

                        //decimal dGTIN_QTY = Convert.ToDecimal(dgvRow.Cells["GTIN_QTY"].Value);
                        //decimal dSKU_QTY = Convert.ToDecimal(dgvRow.Cells["SKU_QTY"].Value);

                        //string sSTGE_TYPE = Convert.ToString(dgvRow.Cells["STGE_TYPE"].Value);
                        //string sSTGE_BIN = Convert.ToString(dgvRow.Cells["STGE_BIN"].Value);
                        //string sLOC_NO = Convert.ToString(dgvRow.Cells["LOC_NO"].Value);
                        //decimal dGTIN_NUMERATOR = Convert.ToDecimal(dgvRow.Cells["GTIN_NUMERATOR"].Value);
                        //decimal dGTIN_DENOMINATOR = Convert.ToDecimal(dgvRow.Cells["GTIN_DENOMINATOR"].Value);
                        //string sGROSS_WEIGHT = Convert.ToString(dgvRow.Cells["GROSS_WEIGHT"].Value);
                        //string sNET_WEIGHT = Convert.ToString(dgvRow.Cells["NET_WEIGHT"].Value);
                        //string sWEIGHT_UNIT = Convert.ToString(dgvRow.Cells["WEIGHT_UNIT"].Value);
                        //string sVOLUME = Convert.ToString(dgvRow.Cells["VOLUME"].Value);
                        //string sVOLUME_UNIT = Convert.ToString(dgvRow.Cells["VOLUME_UNIT"].Value);
                        //string sLOC_QTY = Convert.ToString(dgvRow.Cells["LOC_QTY"].Value);


                        //string sGTIN_QTY_OLD = Convert.ToString(dgvRow.GTIN_QTY"].Tag);
                        string sGTIN_QTY_OLD = Convert.ToString(dgvRow.GTIN_QTY); // **************************************************

                        if (string.IsNullOrEmpty(sGTIN_QTY_OLD)) sGTIN_QTY_OLD = sGTIN_QTY;
                        if (sGTIN_QTY_OLD != sGTIN_QTY) bDelete = false;

                        string sSKU_UNIT = Convert.ToString(dgvRow.SKU_UNIT);
                        string sSKU_QTY = Convert.ToString(dgvRow.SKU_QTY);
                        string sCOUNT_DATE = Convert.ToString(dgvRow.COUNT_DATE);

                        decimal dGTIN_QTY = Convert.ToDecimal(dgvRow.GTIN_QTY);
                        decimal dSKU_QTY = Convert.ToDecimal(dgvRow.SKU_QTY);

                        string sSTGE_TYPE = Convert.ToString(dgvRow.STGE_TYPE);
                        string sSTGE_BIN = Convert.ToString(dgvRow.STGE_BIN);
                        string sLOC_NO = Convert.ToString(dgvRow.LOC_NO);
                        decimal dGTIN_NUMERATOR = Convert.ToDecimal(dgvRow.GTIN_NUMERATOR);
                        decimal dGTIN_DENOMINATOR = Convert.ToDecimal(dgvRow.GTIN_DENOMINATOR);
                        string sGROSS_WEIGHT = Convert.ToString(dgvRow.GROSS_WEIGHT);
                        string sNET_WEIGHT = Convert.ToString(dgvRow.NET_WEIGHT);
                        string sWEIGHT_UNIT = Convert.ToString(dgvRow.WEIGHT_UNIT);
                        string sVOLUME = Convert.ToString(dgvRow.VOLUME);
                        string sVOLUME_UNIT = Convert.ToString(dgvRow.VOLUME_UNIT);
                        string sLOC_QTY = Convert.ToString(dgvRow.LOC_QTY);

                        dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;

                        //計算移動的GROSS_WEIGHT,NET_WEIGHT,VOLUME

                        decimal dGrossWeight = Decimal.Round(Convert.ToDecimal(sGROSS_WEIGHT) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
                        decimal dNetWeight = Decimal.Round(Convert.ToDecimal(sNET_WEIGHT) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);
                        decimal dVolume = Decimal.Round(Convert.ToDecimal(sVOLUME) * dSKU_QTY / Convert.ToDecimal(sLOC_QTY), 3);

                        //insert PLT_DTL_HIS from PLT1.IN_SNO(source)
                        sSQL = string.Format(@"
                        insert into PLT_DTL_HIS
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                        from PLT_DTL 
                        where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                    ", Globals.USER_NAME, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("1 data not create:" + sSQL);

                        //insert PLT_DTL_HIS from PLT2.IN_SNO
                        if (sIN_SNO == "**********") //無序列號
                        {
                            //insert PLT_DTL_HIS from PLT1.IN_SNO(destination)
                            sSQL = string.Format(@"
                            insert into PLT_DTL_HIS
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                            from PLT_DTL 
                            where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                        ", Globals.USER_NAME, sSU_ID_TO, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult > 0) //目標托盤已存在
                            {
                                //update PLT_DTL(destination)
                                sSQL = string.Format(@"
                                update PLT_DTL set GTIN_QTY=GTIN_QTY+{5},SKU_QTY=SKU_QTY+{6}
                                where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                            ", sWHSE_NO, sSU_ID_TO, sIN_NO, sIN_LINE, sIN_SNO, dGTIN_QTY, dSKU_QTY);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("2 data not update:" + sSQL);

                                if (!bDelete)
                                {
                                    //updat PLT_DTL(source)
                                    sSQL = string.Format(@"
                                    update PLT_DTL set GTIN_QTY=GTIN_QTY-{5},SKU_QTY=SKU_QTY-{6}
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                                ", sWHSE_NO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, dGTIN_QTY, dSKU_QTY);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("3 data not update:" + sSQL);
                                }
                                else
                                {
                                    //delete PLT_DTL(source)
                                    sSQL = string.Format(@"
                                    delete PLT_DTL 
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                                ", sWHSE_NO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("4 data not update:" + sSQL);
                                }
                            }
                            else
                            {
                                if (!bDelete) //拆成2筆
                                {
                                    //insert PLT_DTL(destination)
                                    sSQL = string.Format(@"
                                    insert into PLT_DTL 
                                    select '{0}' as SU_ID,SU_TYPE,IN_SNO,WHSE_NO,IN_NO,IN_LINE,GR_DATE,EXPIRE_DATE,DATE_CODE,SKU_NO,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,{1} as GTIN_QTY,SKU_UNIT,{2} as SKU_QTY,'0000-00-00' as COUNT_DATE,0 as GTIN_ALO_QTY,0 as SKU_ALO_QTY
                                    where SU_ID='{3}' and IN_NO='{4}' and IN_LINE='{5}' and IN_SNO='{6}' and WHSE_NO='{7}'
                                ", sSU_ID_TO, dGTIN_QTY, dSKU_QTY, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("5 data not creat:" + sSQL);

                                    //updat PLT_DTL(source)
                                    sSQL = string.Format(@"
                                    update PLT_DTL set GTIN_QTY=GTIN_QTY-{5},SKU_QTY=SKU_QTY-{6}
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{0}'
                                ", sWHSE_NO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, dGTIN_QTY, dSKU_QTY);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("6 data not update:" + sSQL);
                                }
                                else
                                {
                                    //直接整筆更新為新托盤ID
                                    //update PLT_DTL(source) to destination
                                    sSQL = string.Format(@"
                                    update PLT_DTL set SU_ID='{0}'
                                    where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                                ", sSU_ID_TO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("7 data not update:" + sSQL);
                                }
                            }
                        }
                        else //有序列號，直接更新SU_ID為目的托盤
                        {
                            //update PLT_DTL(source) to destination
                            sSQL = string.Format(@"
                            update PLT_DTL set SU_ID='{0}'
                            where SU_ID='{1}' and IN_NO='{2}' and IN_LINE='{3}' and IN_SNO='{4}' and WHSE_NO='{5}'
                        ", sSU_ID_TO, sSU_ID, sIN_NO, sIN_LINE, sIN_SNO, sWHSE_NO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("8 data not update:" + sSQL);
                        }

                        //insert LOC_DTL_HIS from PLT1(source)
                        sSQL = string.Format(@"
                        insert into LOC_DTL_HIS
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                        from LOC_DTL 
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}'
                    ", Globals.USER_NAME, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("9 data not update:" + sSQL);

                        //delete or update LOC_DTL from PLT1(source)
                        dtSQL = new DataTable();
                        sSQL = string.Format(@"
                        select * from LOC_DTL
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{0}'
                    ", sGTIN_UNIT, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                        dtSQL = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtSQL, dbConnection, dbTransaction);
                        if (dtSQL.Rows.Count > 0)
                        {
                            //Source LOC_DTL
                            decimal dGtinQty = Convert.ToDecimal(dtSQL.Rows[0]["GTIN_QTY"]);
                            decimal dGtinAloQty = Convert.ToDecimal(dtSQL.Rows[0]["GTIN_ALO_QTY"]);
                            if (dGtinAloQty > 0) throw new Exception("this pallet have allocate quanity, can't move");
                            if (dGtinQty > dGTIN_QTY) //拆行
                            {
                                //update LOC_DTL(source)
                                dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;
                                sSQL = string.Format(@"
                                update LOC_DTL set GTIN_QTY=GTIN_QTY-{0},SKU_QTY=SKU_QTY-{1},TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}',GROSS_WEIGHT=GROSS_WEIGHT-{13},NET_WEIGHT=NET_WEIGHT-{14},VOLUME=VOLUME-{15}
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and GTIN_UNIT='{12}'
                            ", dGTIN_QTY, dSKU_QTY, Globals.USER_NAME, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGrossWeight, dNetWeight, dVolume);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("10 data not update:" + sSQL);
                            }
                            else
                            {
                                //delete
                                sSQL = string.Format(@"
                                delete LOC_DTL
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and GTIN_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("11 data not update:" + sSQL);
                            }
                        }
                        else
                        {
                            //異常
                            throw new Exception("no data found:" + sSQL);
                        }

                        //insert LOC_DTL_HIS from PLT2(destination)
                        sSQL = string.Format(@"
                        insert into LOC_DTL_HIS
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER
                        from LOC_DTL 
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}'
                    ", Globals.USER_NAME, sWHSE_NO, sSU_ID_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                        //Insert or update LOC_DTL from PLT2(destination)
                        dtSQL = new DataTable();
                        sSQL = string.Format(@"
                        select * from LOC_DTL
                        where WHSE_NO='{1}' and SU_ID='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{0}'
                    ", sGTIN_UNIT, sWHSE_NO, sSU_ID_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                        dtSQL = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtSQL, dbConnection, dbTransaction);
                        if (dtSQL.Rows.Count > 0) //目標數據已存在
                        {
                            dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;
                            //destination LOC_DTL
                            //update
                            sSQL = string.Format(@"
                            update LOC_DTL set GTIN_QTY=GTIN_QTY+{0},SKU_QTY=SKU_QTY+{1},TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}',GROSS_WEIGHT=GROSS_WEIGHT+{13},NET_WEIGHT=NET_WEIGHT+{14},VOLUME=VOLUME+{15}
                            where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and GTIN_UNIT='{12}'
                        ", dGTIN_QTY, dSKU_QTY, Globals.USER_NAME, sWHSE_NO, sSU_ID_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGrossWeight, dNetWeight, dVolume);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("12 data not update:" + sSQL);
                        }
                        else
                        {
                            //insert
                            dSKU_QTY = dGTIN_QTY * dGTIN_NUMERATOR / dGTIN_DENOMINATOR;
                            sSQL = string.Format(@"
                            insert into LOC_DTL(WHSE_NO,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_ALO_QTY,SKU_ALO_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}',convert(varchar(19),getdate(),20),'{27}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sSTGE_TYPE, sSTGE_BIN, sSU_ID_TO, sSU_TYPE_TO, sLOC_NO_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY, sSKU_UNIT, dSKU_QTY, dGTIN_NUMERATOR, dGTIN_DENOMINATOR, dGrossWeight, dNetWeight, sWEIGHT_UNIT, dVolume, sVOLUME_UNIT, 0, 0, "", Globals.USER_NAME);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("13 data not create:" + sSQL);
                        }

                        //生成TX_LOG & TX_SNO
                        string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                        string sTX_NO = sCMD_DATE + GetCmdSno(ref dbConnection, ref dbTransaction, "TX", sCMD_DATE, 4);

                        //生成TX_LOG
                        sSQL = string.Format(@"
                        insert into TX_LOG (WHSE_NO,TX_NO,TX_LINE,STGE_TYPE,STGE_TYPE_TO,STGE_BIN,STGE_BIN_TO,SU_ID,SU_ID_TO,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,TX_USER,TX_DATE,TX_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}',convert(varchar(19),getdate(),20),'X','','1','Y','{21}',convert(varchar(19),getdate(),20),'{21}',convert(varchar(19),getdate(),20))
                    ", sWHSE_NO, sTX_NO, "0001", sSTGE_TYPE, sSTGE_TYPE, sSTGE_BIN, sSTGE_BIN, sSU_ID, sSU_ID_TO, sLOC_NO_TO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, dGTIN_QTY, sSKU_UNIT, dSKU_QTY, Globals.USER_NAME);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("14 data not update:" + sSQL);

                        //生成TX_SNO
                        sSQL = string.Format(@"
                        insert into TX_SNO 
                        select distinct '{0}' as TX_NO, '{1}' as TX_LINE, IN_SNO 
                        from PLT_DTL 
                        where SU_ID='{2}' and SKU_NO='{3}' and PLANT='{4}' and STGE_LOC='{5}' and IsNull(BATCH_NO,'')='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}' and IN_SNO='{11}'
                    ", sTX_NO, "0001", sSU_ID_TO, sSKU_NO, sPLANT, sSTGE_LOC, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT, sIN_SNO);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("15 data not create:" + sSQL);
                    }

                    //throw new Exception("...debug");
                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dbTransaction != null) { dbTransaction.Dispose(); dbTransaction = null; }
                if (dtSQL != null) { dtSQL.Dispose(); dtSQL = null; }
            }
        }




        /// <summary>
        /// 改用 MLASRS_AllocateDtlAsync 有問題, 
        /// 最後的參數
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="DhUsername"></param>
        /// <param name="sPROG_ID"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task MLASRS_AllocateDtl_P030_Async(string conn, string DhUsername, string sPROG_ID, RadzenDh5.Models.Mark10Sqlexpress04.Vp030 item)
        {
            // 最大相容性 NOTE by Mark, 05/08
            // Preparation is ready to use WES code as possible
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);

            // 以下儘可能保持 WES biz logic

            //此程式是Muti delivery orderc合併為一個波次分配
            //DbConnection dbConnection = WMSDB.funCreateConnection();
            DbConnection dbConnection = null;

            DbTransaction dbTransaction = null;

            DataTable dtOutDtl = new DataTable();
            DataTable dtLocDtl = new DataTable();
            DataTable dtPckMst = new DataTable();
            DataTable dtPltDtl = new DataTable();
            string sSQL = string.Empty;
            int iResult = 0;
            try
            {
                // TECH ISSUE
                // Note by Mark, 05/08, 遇到 dbConnection 還沒 ready 的情況
                // That because for log, connectiong string was damaged
                // FIXED ALREADY
                // NO NEED TO APPLY ADVANCED THECK TO WAIT




                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    bool bNextLine = true;
                    string sOUT_NO = string.Empty;
                    string sOUT_LINE = string.Empty;
                    //for (int idx = 0; idx < dgvRows.Length; idx++)
                    if (1 == 1) // 進到這裡, 必需是 One and The Only One

                    {
                        bool bNextNo = false;
                        bNextLine = false; //控制不要多次生成OUT_DTL_HIS
                        if (Convert.ToString(item.OUT_NO).Trim() != sOUT_NO) { bNextNo = true; bNextLine = true; }
                        sOUT_NO = Convert.ToString(item.OUT_NO).Trim();
                        if (Convert.ToString(item.OUT_LINE).Trim() != sOUT_LINE && bNextNo == false) { bNextLine = true; }
                        sOUT_LINE = Convert.ToString(item.OUT_LINE).Trim();

                        string sWHSE_NO = Convert.ToString(item.WHSE_NO).Trim();
                        string sPLANT = Convert.ToString(item.PLANT).Trim();
                        string sSTGE_LOC = Convert.ToString(item.STGE_LOC).Trim();
                        string sSKU_NO = Convert.ToString(item.SKU_NO).Trim();
                        string sBATCH_NO = Convert.ToString(item.BATCH_NO).Trim();
                        string sSTK_CAT = Convert.ToString(item.STK_CAT).Trim();
                        string sSTK_SPECIAL_IND = Convert.ToString(item.STK_SPECIAL_IND).Trim();
                        string sSTK_SPECIAL_NO = Convert.ToString(item.STK_SPECIAL_NO).Trim();
                        string sGTIN_UNIT = Convert.ToString(item.GTIN_UNIT).Trim();
                        string sSKU_UNIT = Convert.ToString(item.SKU_UNIT).Trim();
                        decimal dTotalDemandQty = Convert.ToDecimal(item.SKU_OUT_QTY) - Convert.ToDecimal(item.SKU_ALO_QTY);
                        decimal dOutGtinNumerator = Convert.ToDecimal(item.GTIN_NUMERATOR);
                        decimal dOutGtinDenominator = Convert.ToDecimal(item.GTIN_DENOMINATOR);


                        //儲位明細
                        sSQL = string.Format(@"
                        select a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT,a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE, min(b.GR_DATE) as GR_DATE,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR 
                        from LOC_DTL a
                        join PLT_DTL b
                        on (a.SU_ID=b.SU_ID and a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT)
                        join LOC_MST c on (a.LOC_NO=c.LOC_NO)
                        where c.LOC_STS='S' and a.STGE_TYPE='ATR' and a.SKU_ALO_QTY=0 and a.WHSE_NO='{0}' and a.PLANT='{1}' and a.STGE_LOC='{2}' and a.SKU_NO='{3}' and IsNull(a.BATCH_NO,'')='{4}' and IsNull(a.STK_CAT,'')='{5}' and IsNull(a.STK_SPECIAL_IND,'')='{6}' and IsNull(a.STK_SPECIAL_NO,'')='{7}' and a.SKU_UNIT='{8}'
                        group by a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY,a.SKU_ALO_QTY,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR
                        order by min(b.EXPIRE_DATE),min(b.GR_DATE),a.SKU_QTY desc
                    ", sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                        dtLocDtl = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtLocDtl, dbConnection, dbTransaction);

                        // MAYBE BUG, Report by Mark, 2021-05-08
                        // 
                        // 原本構想在這裡, 應該要加判斷,
                        // 結果上游不當以 假性  多筆進來
                        // 以為可以以 loop ignore 掉無資料的,
                        // 結果什麼都沒能做, 就直通到  dbTransaction.Commit();
                        // 如果按原構想, 允許多筆進來
                        // 也可以 ignore 掉無資料的
                        // 也可以 dbTransaction.Commit();
                        // 但是要 throw new Exception("什麼都沒做到");
                        // 才是緃深防禦的實現

                        //if (dtLocDtl.Rows.Count < 1) continue; //無此儲位Item

                        // 這是應該加擋的寫法
                        // 如果不想節外生枝, 仍可以默默給過,
                        // 反正下個動作的 for ,也會自動不執行全過

                        // BAD PRACTICE, Note by Mark, 這部份,先做和 WES 一樣的效果, 假性的 Confirm success
                        // 反正能做的, 還是能做,
                        // 只是需要人工去清理這種 BAD RECORDS, 或是就放著

                        // 這現象可由
                        //   SELECT * FROM USER_LOG 
                        //   WHERE PROG_ID = 'P030'
                        //   ORDER BY LOG_DATE DESC
                        // 在 REMARK 看到處理多次同樣記錄的情形
                        // 剛好趁這例子把寫入 USER_LOG 先完善 
                        //if (dtLocDtl.Rows.Count < 1) throw new Exception("Item not found"); //無此儲位Item


                        for (int iLoc = 0; iLoc < dtLocDtl.Rows.Count; iLoc++)
                        {

                            decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_NUMERATOR"]);
                            decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_DENOMINATOR"]);
                            string sLocGtinUnit = Convert.ToString(dtLocDtl.Rows[iLoc]["GTIN_UNIT"]).Trim();

                            if (dTotalDemandQty == 0) break; //合併後的Item需求總數已全部分配完成

                            decimal dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_QTY"]);
                            decimal dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]);
                            decimal dLocAvailQty = dLocSkuQty - dLocSkuAloQty; //在储位托盤上可分配的Item總數

                            if (dLocAvailQty <= 0) continue; //因為可能被之前的處理先分配了

                            string sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["EXPIRE_DATE"]).Trim();
                            string sGR_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["GR_DATE"]).Trim();
                            string sSU_ID = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_ID"]).Trim();
                            string sLOC_NO = Convert.ToString(dtLocDtl.Rows[iLoc]["LOC_NO"]).Trim();
                            string sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_TYPE"]).Trim();
                            string sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                            string sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_TYPE"]).Trim();

                            decimal dLocTotalAloQty = 0; //累計储位分配數
                            decimal dLocPickQty = 0; //該儲位分配數

                            if (dTotalDemandQty >= dLocAvailQty) //需求總數>=可分配在储數
                            {
                                dLocPickQty = dLocAvailQty; //該儲位托盤可全部分配
                            }
                            else
                            {
                                //當總需求數<托盤數時，要找下一托盤，
                                //直到剩餘總需求數是=托盤可分配數時，如果是等餘則選取該托盤，如果是大於則選擇前一筆托盤

                                bool bSelect = false;
                                int iSelect = 0;
                                int j = iLoc; //當前LocDtl Index
                                while (true)
                                {
                                    j++; //下一筆
                                    if (j >= dtLocDtl.Rows.Count) break; //超出LocDtl row index

                                    decimal dLocQty = 0;

                                    if (sGR_DATE != Convert.ToString(dtLocDtl.Rows[j]["GR_DATE"]))
                                    {
                                        //遇到下一個FIFO則往回選大於需求的
                                        while (true)
                                        {
                                            j--;

                                            if (j < iLoc) //回到當前locdtl row index
                                            {
                                                bSelect = true;
                                                iSelect = iLoc;
                                                break;
                                            }

                                            dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                            if (dLocQty >= dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //相同的FIFO,直到儲位數量<=需求數則選前一個儲位數量>需求數的托盤
                                        dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                        if (dLocQty <= dTotalDemandQty)
                                        {
                                            if (dLocQty == dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                            }
                                            else
                                            {
                                                bSelect = true;
                                                iSelect = j - 1;
                                            }
                                        }
                                    }

                                    if (bSelect) break;
                                }

                                if (bSelect)
                                {
                                    //可能托盤改變所以要重新賦值
                                    dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_QTY"]);
                                    dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_ALO_QTY"]);
                                    dLocAvailQty = dLocSkuQty - dLocSkuAloQty;

                                    sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["EXPIRE_DATE"]);
                                    sGR_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["GR_DATE"]);
                                    sSU_ID = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_ID"]);
                                    sLOC_NO = Convert.ToString(dtLocDtl.Rows[iSelect]["LOC_NO"]);
                                    sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["STGE_TYPE"]).Trim();
                                    sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                                    sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_TYPE"]).Trim();
                                }

                                dLocPickQty = dTotalDemandQty; //該儲位托盤部分分配
                            }

                            //找已經生成的托盤出庫分揀指令
                            //找已經生成的PCK_MST
                            string sPCK_NO = string.Empty;
                            string sPCK_LINE = "0001";
                            sSQL = string.Format(@"
                            select a.PCK_NO,count(b.PCK_LINE) as CNT 
                            from PCK_MST a join PCK_DTL b
                            on (a.WHSE_NO=b.WHSE_NO and a.PCK_NO=b.PCK_NO)
                            where a.SU_ID='{0}' and a.PCK_STS in ('0','1') and a.PCK_TYPE='P' and a.LOC_NO='{1}'
                            group by a.PCK_NO
                        ", sSU_ID, sLOC_NO);
                            dtPckMst = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtPckMst, dbConnection, dbTransaction);
                            if (dtPckMst.Rows.Count < 1)
                            {
                                //創建CMD_MST & PCK_MST
                                //取得CMD_SNO
                                string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");

                                string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);

                                if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");


                                //預約LOC_MST
                                sSQL = string.Format(@"
                                update LOC_MST 
                                set LOC_STS='O',LOC_OSTS='S',TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20) 
                                where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='S'
                            ", sLOC_NO, sSU_ID, DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                string sSTN_NO = "A04";

                                sPCK_NO = sCMD_DATE + sCMD_SNO;
                                //生成CMD_MST(如果STGE_TYPE="ATR"是自動倉)
                                if (sSTGE_BIN == "ASRSA00000" && sLOC_NO.Length == 7)
                                {
                                    //生成CMD_MST
                                    string sCMD_STS = "0";
                                    string sEQU_NO = "01";
                                    switch (sLOC_NO.Substring(0, 2))
                                    {
                                        case "01":
                                        case "02":
                                            sEQU_NO = "01";
                                            break;
                                        case "03":
                                        case "04":
                                            sEQU_NO = "02";
                                            break;
                                        case "05":
                                        case "06":
                                            sEQU_NO = "03";
                                            break;
                                        case "07":
                                        case "08":
                                            sEQU_NO = "04";
                                            break;
                                        default: throw new Exception("invalid LOC_NO:" + sLOC_NO);
                                    }


                                    switch (sEQU_NO)
                                    {
                                        case "01":
                                            sSTN_NO = "A04";
                                            break;
                                        case "02":
                                            sSTN_NO = "A10";
                                            break;
                                        case "03":
                                            sSTN_NO = "A16";
                                            break;
                                        case "04":
                                            sSTN_NO = "A22";
                                            break;
                                        default: throw new Exception("invalid EQU_NO:" + sEQU_NO);
                                    }

                                    string sPRTY = "5";
                                    string sCMD_MODE = "2";
                                    string sIO_TYPE = "21";
                                    string sTRACE = "00";

                                    sSQL = string.Format(@"
                                    insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                                ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, sOUT_NO, sOUT_LINE, sPCK_NO, "P", DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }

                                //生成PCK_MST
                                sSQL = string.Format(@"
                                insert into PCK_MST(WHSE_NO,PCK_NO,PCK_TYPE,STGE_BIN,STGE_TYPE,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,STN_NO,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',N'{13}',convert(varchar(19),getdate(),20),N'{13}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPCK_NO, "P", sSTGE_TYPE, sSTGE_BIN, sSU_ID, sSU_TYPE, sLOC_NO, sCMD_DATE, sCMD_SNO, sSTN_NO, "0", "Y", DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);
                            }
                            else
                            {
                                sPCK_NO = Convert.ToString(dtPckMst.Rows[0]["PCK_NO"]).Trim();
                                sPCK_LINE = (int.Parse(Convert.ToString(dtPckMst.Rows[0]["CNT"])) + 1).ToString("0000");
                            }

                            decimal dPickQty = dLocPickQty;
                            if (dLocPickQty >= dTotalDemandQty) dPickQty = dTotalDemandQty; //如果托盤储位可分配數>Delivery Item需求數
                            dLocPickQty = dLocPickQty - dPickQty; //該托盤餘數
                            dLocTotalAloQty = dLocTotalAloQty + dPickQty; //該托盤累計分配餘數

                            //產生PCK_DTL
                            decimal dGtinPickAloQty = Decimal.Round(dPickQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                            insert into PCK_DTL(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}',N'{23}',convert(varchar(19),getdate(),20),N'{23}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinPickAloQty, 0, sSKU_UNIT, dPickQty, 0, "0", "Y", DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data create:" + sSQL);

                            //現在不能產生PCK_SNO，必須在出庫命令完成時刪除PLT_DTL及產生PCK_SNO
                            sSQL = string.Format(@"
                            select IN_SNO,IN_NO,IN_LINE,SKU_QTY,IsNull(SKU_ALO_QTY,0) as SKU_ALO_QTY 
                            from PLT_DTL 
                            where SKU_QTY > IsNull(SKU_ALO_QTY,0) and SU_ID='{0}' and WHSE_NO= '{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}' 
                            order by EXPIRE_DATE,GR_DATE
                        ", sSU_ID, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            dtPltDtl = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtPltDtl, dbConnection, dbTransaction);
                            if (dtPltDtl.Rows.Count < 1) throw new Exception("no pallet item data:" + sSQL);

                            decimal dSnoPickQty = dPickQty;
                            decimal dSnoTrnQty = 0;
                            for (int iSno = 0; iSno < dtPltDtl.Rows.Count; iSno++)
                            {
                                if (dSnoPickQty <= 0) break;

                                string sIN_SNO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_SNO"]);
                                string sIN_NO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_NO"]);
                                string sIN_LINE = Convert.ToString(dtPltDtl.Rows[iSno]["IN_LINE"]);
                                decimal dSnoSkuQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_QTY"]);
                                decimal dSnoSkuAloQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_ALO_QTY"]);
                                if (dSnoPickQty >= (dSnoSkuQty - dSnoSkuAloQty))
                                {
                                    dSnoTrnQty = (dSnoSkuQty - dSnoSkuAloQty);
                                }
                                else
                                {
                                    dSnoTrnQty = dSnoPickQty;
                                }

                                //生成PCK_SNO
                                if (sIN_SNO != "**********")
                                {
                                    decimal dGtinSnoTrnQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                    sSQL = string.Format(@"
                                    insert into PCK_SNO(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,IN_SNO,IN_NO,IN_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}','{23}',N'{24}',convert(varchar(19),getdate(),20),N'{24}',convert(varchar(19),getdate(),20))
                                    ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinSnoTrnQty, 0, sSKU_UNIT, dSnoTrnQty, 0, sIN_SNO, sIN_NO, sIN_LINE, DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }

                                //備份PLT_DTL
                                sSQL = string.Format(@"
                                insert into PLT_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PLT_DTL 
                                where WHSE_NO='{1}' and SU_ID='{2}' and IN_SNO='{3}' and IN_NO='{4}' and IN_LINE='{5}'
                            ", DhUsername, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                //更新PLT_DTL
                                decimal dSnoGtinAloQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                sSQL = string.Format(@"
                                update PLT_DTL set GTIN_ALO_QTY=IsNull(GTIN_ALO_QTY,0)+{0},SKU_ALO_QTY=IsNull(SKU_ALO_QTY,0)+{1}
                                where WHSE_NO='{2}' and SU_ID='{3}' and IN_SNO='{4}' and IN_NO='{5}' and IN_LINE='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}'
                            ", dSnoGtinAloQty, dSnoTrnQty, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                dSnoPickQty = dSnoPickQty - dSnoTrnQty;
                            }

                            dTotalDemandQty = dTotalDemandQty - dPickQty;

                            //備份OUT_DTL
                            if (bNextLine)
                            {
                                sSQL = string.Format(@"
                            insert into OUT_DTL_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from OUT_DTL 
                            where WHSE_NO='{1}' and OUT_NO='{2}' and OUT_LINE='{3}'
                            ", DhUsername, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //更新OUT_DTL.GTIN_ALO_QTY & SKU_ALO_QTY
                            decimal dGtinAloQty = Decimal.Round(dPickQty * dOutGtinDenominator / dOutGtinNumerator, 3);
                            sSQL = string.Format(@"
                            update OUT_DTL set OUT_STS='1',GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{3}' and OUT_NO='{4}' and OUT_LINE='{5}'
                            ", dGtinAloQty, Decimal.Round(dPickQty, 3), DhUsername, sWHSE_NO, sOUT_NO, sOUT_LINE);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            if (bNextNo)
                            {
                                //備份OUT_MST
                                sSQL = string.Format(@"
                                insert into OUT_MST_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{2}' as LOG_USER from OUT_MST 
                                where WHSE_NO='{0}' and OUT_NO='{1}'
                            ", sWHSE_NO, sOUT_NO, DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //更新OUT_MST
                            sSQL = string.Format(@"
                            update OUT_MST set OUT_STS=CASE WHEN (select count(*) from OUT_DTL where OUT_STS in ('0','1') and WHSE_NO='{0}' and OUT_NO='{1}') < 1 THEN '9' ELSE '1' END,
                                TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and OUT_NO='{1}' and OUT_STS in ('0','1')
                         ", sWHSE_NO, sOUT_NO, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL); //如果被取消則無法完成過帳

                            //該托盤已全部分配完或已無Delivery Item可分配
                            //備份LOC_DTL到歷史檔
                            sSQL = string.Format(@"
                                insert into LOC_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER from LOC_DTL 
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            //更新LOC_DTL
                            decimal dLocGtinTotalAloQty = Decimal.Round(dLocTotalAloQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                                update LOC_DTL 
                                set GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and SKU_UNIT='{12}'
                            ", dLocGtinTotalAloQty, dLocTotalAloQty.ToString(), DhUsername, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"] = Decimal.Round(Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]) + dLocTotalAloQty, 3);

                            if (dTotalDemandQty <= 0) break; //合併後的總需求數>0,找下一個托盤

                        } //LocDtl loop
                    } //Next Item

                    dbTransaction.Commit();

                    // NOTE by Mark, 05/08, housekeeping
                    if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                    dbConnection.Dispose(); dbConnection = null;

                    if (dtOutDtl != null) { dtOutDtl.Dispose(); dtOutDtl = null; }
                    if (dtLocDtl != null) { dtLocDtl.Dispose(); dtLocDtl = null; }
                    if (dtPckMst != null) { dtPckMst.Dispose(); dtPckMst = null; }
                    if (dtPltDtl != null) { dtPltDtl.Dispose(); dtPltDtl = null; }

                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }

                //   MessageBox.Show("Confirm success");
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);
                // NOTE by Mark, 05/08, housekeeping

                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dtOutDtl != null) { dtOutDtl.Dispose(); dtOutDtl = null; }
                if (dtLocDtl != null) { dtLocDtl.Dispose(); dtLocDtl = null; }
                if (dtPckMst != null) { dtPckMst.Dispose(); dtPckMst = null; }
                if (dtPltDtl != null) { dtPltDtl.Dispose(); dtPltDtl = null; }


                throw new Exception(ex.Message);
            }
        }



        public async Task<(bool, string)> AllocateDtlAsync(string conn, string DhUsername, string sPROG_ID, RadzenDh5.Models.Mark10Sqlexpress04.OutDtl item)
        {

            // NOTE by Mark, 05/07
            // dgvRows 原本是在 WinForm 選到的 row(s)
            // 確認是單選
            // 直接使用
            // 如果沒有選在前置檢查就不會走到這裡

            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);

            // LINE#1879 of Globals.cs
            // 此程式是Muti delivery orderc合併為一個波次分配

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;

            DataTable dtOutDtl = new DataTable();
            DataTable dtLocDtl = new DataTable();
            DataTable dtPckMst = new DataTable();
            DataTable dtPltDtl = new DataTable();
            string sSQL = string.Empty;
            int iResult = 0;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                LogP020("测试数据库连接是否成功:" + WMSDB.funOpenDB(ref dbConnection));

                if (!WMSDB.funOpenDB(ref dbConnection))
                {

                    LogP020("测试数据库连接是否成功:" + "Database connection failed");
                    return (false, "Database connection failed");

                }

                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    bool bNextLine = true;
                    string sOUT_NO = string.Empty;
                    string sOUT_LINE = string.Empty;
                    //for (int idx = 0; idx < dgvRows.Length; idx++)
                    //{
                    //foreach ( var item in dgvRows)
                    if (1 == 1)
                    {
                        bool bNextNo = false;
                        bNextLine = false; //控制不要多次生成OUT_DTL_HIS
                        if (Convert.ToString(item.OUT_NO).Trim() != sOUT_NO) { bNextNo = true; bNextLine = true; }
                        sOUT_NO = Convert.ToString(item.OUT_NO).Trim();
                        if (Convert.ToString(item.OUT_LINE).Trim() != sOUT_LINE && bNextNo == false) { bNextLine = true; }
                        sOUT_LINE = Convert.ToString(item.OUT_LINE).Trim();

                        string sWHSE_NO = Convert.ToString(item.WHSE_NO).Trim();
                        string sPLANT = Convert.ToString(item.PLANT).Trim();
                        string sSTGE_LOC = Convert.ToString(item.STGE_LOC).Trim();
                        string sSKU_NO = Convert.ToString(item.SKU_NO).Trim();
                        string sBATCH_NO = Convert.ToString(item.BATCH_NO).Trim();
                        string sSTK_CAT = Convert.ToString(item.STK_CAT).Trim();
                        string sSTK_SPECIAL_IND = Convert.ToString(item.STK_SPECIAL_IND).Trim();
                        string sSTK_SPECIAL_NO = Convert.ToString(item.STK_SPECIAL_NO).Trim();
                        string sGTIN_UNIT = Convert.ToString(item.GTIN_UNIT).Trim();
                        string sSKU_UNIT = Convert.ToString(item.SKU_UNIT).Trim();
                        decimal dTotalDemandQty = Convert.ToDecimal(item.SKU_OUT_QTY) - Convert.ToDecimal(item.SKU_ALO_QTY);
                        decimal dOutGtinNumerator = Convert.ToDecimal(item.GTIN_NUMERATOR);
                        decimal dOutGtinDenominator = Convert.ToDecimal(item.GTIN_DENOMINATOR);

                        //儲位明細
                        sSQL = string.Format(@"
                        select a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT,a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE, min(b.GR_DATE) as GR_DATE,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR 
                        from LOC_DTL a
                        join PLT_DTL b
                        on (a.SU_ID=b.SU_ID and a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT)
                        join LOC_MST c on (a.LOC_NO=c.LOC_NO)
                        where c.LOC_STS='S' and a.STGE_TYPE='ATR' and a.SKU_ALO_QTY=0 and a.WHSE_NO='{0}' and a.PLANT='{1}' and a.STGE_LOC='{2}' and a.SKU_NO='{3}' and IsNull(a.BATCH_NO,'')='{4}' and IsNull(a.STK_CAT,'')='{5}' and IsNull(a.STK_SPECIAL_IND,'')='{6}' and IsNull(a.STK_SPECIAL_NO,'')='{7}' and a.SKU_UNIT='{8}'
                        group by a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY,a.SKU_ALO_QTY,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR
                        order by min(b.EXPIRE_DATE),min(b.GR_DATE),a.SKU_QTY desc
                    ", sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                        dtLocDtl = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtLocDtl, dbConnection, dbTransaction);

                        LogP020("Dtl - 1");
                        LogP020(sSQL);
                        LogP020("dtLocDtl.Rows.Count=" + dtLocDtl.Rows.Count);


                        if (dtLocDtl.Rows.Count < 1)
                        //continue; //無此儲位Item
                        {
                            return (true, "無此儲位Item");
                        }


                        for (int iLoc = 0; iLoc < dtLocDtl.Rows.Count; iLoc++)
                        {

                            decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_NUMERATOR"]);
                            decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_DENOMINATOR"]);
                            string sLocGtinUnit = Convert.ToString(dtLocDtl.Rows[iLoc]["GTIN_UNIT"]).Trim();

                            if (dTotalDemandQty == 0) break; //合併後的Item需求總數已全部分配完成

                            decimal dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_QTY"]);
                            decimal dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]);
                            decimal dLocAvailQty = dLocSkuQty - dLocSkuAloQty; //在储位托盤上可分配的Item總數

                            if (dLocAvailQty <= 0) continue; //因為可能被之前的處理先分配了

                            string sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["EXPIRE_DATE"]).Trim();
                            string sGR_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["GR_DATE"]).Trim();
                            string sSU_ID = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_ID"]).Trim();
                            string sLOC_NO = Convert.ToString(dtLocDtl.Rows[iLoc]["LOC_NO"]).Trim();
                            string sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_TYPE"]).Trim();
                            string sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                            string sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_TYPE"]).Trim();

                            decimal dLocTotalAloQty = 0; //累計储位分配數
                            decimal dLocPickQty = 0; //該儲位分配數

                            if (dTotalDemandQty >= dLocAvailQty) //需求總數>=可分配在储數
                            {
                                dLocPickQty = dLocAvailQty; //該儲位托盤可全部分配
                            }
                            else
                            {
                                //當總需求數<托盤數時，要找下一托盤，
                                //直到剩餘總需求數是=托盤可分配數時，如果是等餘則選取該托盤，如果是大於則選擇前一筆托盤

                                bool bSelect = false;
                                int iSelect = 0;
                                int j = iLoc; //當前LocDtl Index
                                while (true)
                                {
                                    j++; //下一筆
                                    if (j >= dtLocDtl.Rows.Count) break; //超出LocDtl row index

                                    decimal dLocQty = 0;

                                    if (sGR_DATE != Convert.ToString(dtLocDtl.Rows[j]["GR_DATE"]))
                                    {
                                        //遇到下一個FIFO則往回選大於需求的
                                        while (true)
                                        {
                                            j--;

                                            if (j < iLoc) //回到當前locdtl row index
                                            {
                                                bSelect = true;
                                                iSelect = iLoc;
                                                break;
                                            }

                                            dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                            if (dLocQty >= dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //相同的FIFO,直到儲位數量<=需求數則選前一個儲位數量>需求數的托盤
                                        dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                        if (dLocQty <= dTotalDemandQty)
                                        {
                                            if (dLocQty == dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                            }
                                            else
                                            {
                                                bSelect = true;
                                                iSelect = j - 1;
                                            }
                                        }
                                    }

                                    if (bSelect) break;
                                }

                                if (bSelect)
                                {
                                    //可能托盤改變所以要重新賦值
                                    dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_QTY"]);
                                    dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_ALO_QTY"]);
                                    dLocAvailQty = dLocSkuQty - dLocSkuAloQty;

                                    sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["EXPIRE_DATE"]);
                                    sGR_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["GR_DATE"]);
                                    sSU_ID = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_ID"]);
                                    sLOC_NO = Convert.ToString(dtLocDtl.Rows[iSelect]["LOC_NO"]);
                                    sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["STGE_TYPE"]).Trim();
                                    sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                                    sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_TYPE"]).Trim();
                                }

                                dLocPickQty = dTotalDemandQty; //該儲位托盤部分分配
                            }

                            //找已經生成的托盤出庫分揀指令
                            //找已經生成的PCK_MST
                            string sPCK_NO = string.Empty;
                            string sPCK_LINE = "0001";
                            sSQL = string.Format(@"
                            select a.PCK_NO,count(b.PCK_LINE) as CNT 
                            from PCK_MST a join PCK_DTL b
                            on (a.WHSE_NO=b.WHSE_NO and a.PCK_NO=b.PCK_NO)
                            where a.SU_ID='{0}' and a.PCK_STS in ('0','1') and a.PCK_TYPE='P' and a.LOC_NO='{1}'
                            group by a.PCK_NO
                        ", sSU_ID, sLOC_NO);
                            dtPckMst = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtPckMst, dbConnection, dbTransaction);
                            if (dtPckMst.Rows.Count < 1)
                            {
                                //創建CMD_MST & PCK_MST
                                //取得CMD_SNO
                                string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                                string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);






                                if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                                //預約LOC_MST
                                sSQL = string.Format(@"
                                update LOC_MST 
                                set LOC_STS='O',LOC_OSTS='S',TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20) 
                                where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='S'
                            ", sLOC_NO, sSU_ID, DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                string sSTN_NO = "A04";

                                sPCK_NO = sCMD_DATE + sCMD_SNO;
                                //生成CMD_MST(如果STGE_TYPE="ATR"是自動倉)
                                if (sSTGE_BIN == "ASRSA00000" && sLOC_NO.Length == 7)
                                {
                                    //生成CMD_MST
                                    string sCMD_STS = "0";
                                    string sEQU_NO = "01";
                                    switch (sLOC_NO.Substring(0, 2))
                                    {
                                        case "01":
                                        case "02":
                                            sEQU_NO = "01";
                                            break;
                                        case "03":
                                        case "04":
                                            sEQU_NO = "02";
                                            break;
                                        case "05":
                                        case "06":
                                            sEQU_NO = "03";
                                            break;
                                        case "07":
                                        case "08":
                                            sEQU_NO = "04";
                                            break;
                                        default: throw new Exception("invalid LOC_NO:" + sLOC_NO);
                                    }


                                    switch (sEQU_NO)
                                    {
                                        case "01":
                                            sSTN_NO = "A04";
                                            break;
                                        case "02":
                                            sSTN_NO = "A10";
                                            break;
                                        case "03":
                                            sSTN_NO = "A16";
                                            break;
                                        case "04":
                                            sSTN_NO = "A22";
                                            break;
                                        default: throw new Exception("invalid EQU_NO:" + sEQU_NO);
                                    }

                                    string sPRTY = "5";
                                    string sCMD_MODE = "2";
                                    string sIO_TYPE = "21";
                                    string sTRACE = "00";

                                    sSQL = string.Format(@"
                                    insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                                ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, sOUT_NO, sOUT_LINE, sPCK_NO, "P", DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }

                                //生成PCK_MST
                                sSQL = string.Format(@"
                                insert into PCK_MST(WHSE_NO,PCK_NO,PCK_TYPE,STGE_BIN,STGE_TYPE,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,STN_NO,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',N'{13}',convert(varchar(19),getdate(),20),N'{13}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPCK_NO, "P", sSTGE_TYPE, sSTGE_BIN, sSU_ID, sSU_TYPE, sLOC_NO, sCMD_DATE, sCMD_SNO, sSTN_NO, "0", "Y", DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);
                            }
                            else
                            {
                                sPCK_NO = Convert.ToString(dtPckMst.Rows[0]["PCK_NO"]).Trim();
                                sPCK_LINE = (int.Parse(Convert.ToString(dtPckMst.Rows[0]["CNT"])) + 1).ToString("0000");
                            }

                            decimal dPickQty = dLocPickQty;
                            if (dLocPickQty >= dTotalDemandQty) dPickQty = dTotalDemandQty; //如果托盤储位可分配數>Delivery Item需求數
                            dLocPickQty = dLocPickQty - dPickQty; //該托盤餘數
                            dLocTotalAloQty = dLocTotalAloQty + dPickQty; //該托盤累計分配餘數

                            //產生PCK_DTL
                            decimal dGtinPickAloQty = Decimal.Round(dPickQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                            insert into PCK_DTL(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}',N'{23}',convert(varchar(19),getdate(),20),N'{23}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinPickAloQty, 0, sSKU_UNIT, dPickQty, 0, "0", "Y", DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data create:" + sSQL);

                            //現在不能產生PCK_SNO，必須在出庫命令完成時刪除PLT_DTL及產生PCK_SNO
                            sSQL = string.Format(@"
                            select IN_SNO,IN_NO,IN_LINE,SKU_QTY,IsNull(SKU_ALO_QTY,0) as SKU_ALO_QTY 
                            from PLT_DTL 
                            where SKU_QTY > IsNull(SKU_ALO_QTY,0) and SU_ID='{0}' and WHSE_NO= '{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}' 
                            order by EXPIRE_DATE,GR_DATE
                        ", sSU_ID, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            dtPltDtl = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtPltDtl, dbConnection, dbTransaction);
                            if (dtPltDtl.Rows.Count < 1) throw new Exception("no pallet item data:" + sSQL);

                            decimal dSnoPickQty = dPickQty;
                            decimal dSnoTrnQty = 0;
                            for (int iSno = 0; iSno < dtPltDtl.Rows.Count; iSno++)
                            {
                                if (dSnoPickQty <= 0) break;

                                string sIN_SNO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_SNO"]);
                                string sIN_NO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_NO"]);
                                string sIN_LINE = Convert.ToString(dtPltDtl.Rows[iSno]["IN_LINE"]);
                                decimal dSnoSkuQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_QTY"]);
                                decimal dSnoSkuAloQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_ALO_QTY"]);
                                if (dSnoPickQty >= (dSnoSkuQty - dSnoSkuAloQty))
                                {
                                    dSnoTrnQty = (dSnoSkuQty - dSnoSkuAloQty);
                                }
                                else
                                {
                                    dSnoTrnQty = dSnoPickQty;
                                }

                                //生成PCK_SNO
                                if (sIN_SNO != "**********")
                                {
                                    decimal dGtinSnoTrnQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                    sSQL = string.Format(@"
                                    insert into PCK_SNO(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,IN_SNO,IN_NO,IN_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}','{23}',N'{24}',convert(varchar(19),getdate(),20),N'{24}',convert(varchar(19),getdate(),20))
                                    ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinSnoTrnQty, 0, sSKU_UNIT, dSnoTrnQty, 0, sIN_SNO, sIN_NO, sIN_LINE, DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }

                                //備份PLT_DTL
                                sSQL = string.Format(@"
                                insert into PLT_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PLT_DTL 
                                where WHSE_NO='{1}' and SU_ID='{2}' and IN_SNO='{3}' and IN_NO='{4}' and IN_LINE='{5}'
                            ", DhUsername, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                //更新PLT_DTL
                                decimal dSnoGtinAloQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                sSQL = string.Format(@"
                                update PLT_DTL set GTIN_ALO_QTY=IsNull(GTIN_ALO_QTY,0)+{0},SKU_ALO_QTY=IsNull(SKU_ALO_QTY,0)+{1}
                                where WHSE_NO='{2}' and SU_ID='{3}' and IN_SNO='{4}' and IN_NO='{5}' and IN_LINE='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}'
                            ", dSnoGtinAloQty, dSnoTrnQty, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                dSnoPickQty = dSnoPickQty - dSnoTrnQty;
                            }

                            dTotalDemandQty = dTotalDemandQty - dPickQty;

                            //備份OUT_DTL
                            if (bNextLine)
                            {
                                sSQL = string.Format(@"
                            insert into OUT_DTL_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from OUT_DTL 
                            where WHSE_NO='{1}' and OUT_NO='{2}' and OUT_LINE='{3}'
                            ", DhUsername, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //更新OUT_DTL.GTIN_ALO_QTY & SKU_ALO_QTY
                            decimal dGtinAloQty = Decimal.Round(dPickQty * dOutGtinDenominator / dOutGtinNumerator, 3);
                            sSQL = string.Format(@"
                            update OUT_DTL set OUT_STS='1',GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{3}' and OUT_NO='{4}' and OUT_LINE='{5}'
                            ", dGtinAloQty, Decimal.Round(dPickQty, 3), DhUsername, sWHSE_NO, sOUT_NO, sOUT_LINE);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            if (bNextNo)
                            {
                                //備份OUT_MST
                                sSQL = string.Format(@"
                                insert into OUT_MST_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{2}' as LOG_USER from OUT_MST 
                                where WHSE_NO='{0}' and OUT_NO='{1}'
                            ", sWHSE_NO, sOUT_NO, DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //更新OUT_MST
                            sSQL = string.Format(@"
                            update OUT_MST set OUT_STS=CASE WHEN (select count(*) from OUT_DTL where OUT_STS in ('0','1') and WHSE_NO='{0}' and OUT_NO='{1}') < 1 THEN '9' ELSE '1' END,
                                TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and OUT_NO='{1}' and OUT_STS in ('0','1')
                         ", sWHSE_NO, sOUT_NO, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL); //如果被取消則無法完成過帳

                            //該托盤已全部分配完或已無Delivery Item可分配
                            //備份LOC_DTL到歷史檔
                            sSQL = string.Format(@"
                                insert into LOC_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER from LOC_DTL 
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            //更新LOC_DTL
                            decimal dLocGtinTotalAloQty = Decimal.Round(dLocTotalAloQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                                update LOC_DTL 
                                set GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and SKU_UNIT='{12}'
                            ", dLocGtinTotalAloQty, dLocTotalAloQty.ToString(), DhUsername, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"] = Decimal.Round(Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]) + dLocTotalAloQty, 3);

                            if (dTotalDemandQty <= 0) break; //合併後的總需求數>0,找下一個托盤

                        } //LocDtl loop
                    } //Next Item

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    LogP020("****************** dbTransaction.Rollback(); ********************");
                    throw new Exception(ex.Message);
                }

                //MessageBox.Show("Confirm success");
                LogP020("Confirm success");
                return (true, "Confirm success");
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                LogP020(ex.Message);
                return (true, ex.Message);
            }
            finally
            {


                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dtOutDtl != null) { dtOutDtl.Dispose(); dtOutDtl = null; }
                if (dtLocDtl != null) { dtLocDtl.Dispose(); dtLocDtl = null; }
                if (dtPckMst != null) { dtPckMst.Dispose(); dtPckMst = null; }
                if (dtPltDtl != null) { dtPltDtl.Dispose(); dtPltDtl = null; }
            }




        }

        /// <summary>
        /// MLASRS_ 表示直接取用
        /// 
        /// caller will handle confirm success or fialed with any exception 
        /// </summary>
        /// <param name="sPROG_ID"></param>
        /// <param name="sOUT_NOs"></param>
        /// <returns></returns>

        public async Task MLASRS_AllocateMst_Async(string conn, string DhUsername, string sPROG_ID, string sOUT_NOs)
        {
            // STEP 1
            // public static void AllocateMst(string sPROG_ID, string sOUT_NOs)

            // STEP 2
            WMSDB = new WESDB(DB_PROVIDER_TYPE, conn); // NOTE by Mark, implement static DB_PROVIDER_TYPE
            Globals.USER_NAME = DhUsername;


            //此程式是Muti delivery orderc合併為一個波次分配

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;

            DataTable dtMergeOutDtl = new DataTable();
            DataTable dtOutDtl = new DataTable();
            DataTable dtLocDtl = new DataTable();
            DataTable dtPckMst = new DataTable();
            DataTable dtPltDtl = new DataTable();
            string sSQL = string.Empty;
            int iResult = 0;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                sSQL = string.Format(@"
                select WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT,sum(SKU_OUT_QTY - SKU_ALO_QTY) as SKU_CMD_QTY 
                from OUT_DTL
                where OUT_NO in ({0}) and OUT_STS in ('0','1') and SKU_OUT_QTY > SKU_ALO_QTY
                group by WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT
                order by WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT
            ", sOUT_NOs);
                dtMergeOutDtl = new DataTable();
                WMSDB.funGetDT(sSQL, ref dtMergeOutDtl, dbConnection, dbTransaction);
                if (dtMergeOutDtl.Rows.Count < 1) throw new Exception("no execute data:" + sSQL);

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    //根據合併後的Item總數來分配Loc_Dtl
                    for (int idx = 0; idx < dtMergeOutDtl.Rows.Count; idx++)
                    {
                        string sWHSE_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["WHSE_NO"]).Trim();
                        string sPLANT = Convert.ToString(dtMergeOutDtl.Rows[idx]["PLANT"]).Trim();
                        string sSTGE_LOC = Convert.ToString(dtMergeOutDtl.Rows[idx]["STGE_LOC"]).Trim();
                        string sSKU_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["SKU_NO"]).Trim();
                        string sBATCH_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["BATCH_NO"]).Trim();
                        string sSTK_CAT = Convert.ToString(dtMergeOutDtl.Rows[idx]["STK_CAT"]).Trim();
                        string sSTK_SPECIAL_IND = Convert.ToString(dtMergeOutDtl.Rows[idx]["STK_SPECIAL_IND"]).Trim();
                        string sSTK_SPECIAL_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["STK_SPECIAL_NO"]).Trim();
                        string sGTIN_UNIT = Convert.ToString(dtMergeOutDtl.Rows[idx]["GTIN_UNIT"]).Trim();
                        string sSKU_UNIT = Convert.ToString(dtMergeOutDtl.Rows[idx]["SKU_UNIT"]).Trim();
                        decimal dTotalDemandQty = Convert.ToDecimal(dtMergeOutDtl.Rows[idx]["SKU_CMD_QTY"]); //合併後的Item需求總數

                        //儲位明細
                        sSQL = string.Format(@"
                        select a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE, min(b.GR_DATE) as GR_DATE,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR 
                        from LOC_DTL a
                        join PLT_DTL b
                        on (a.SU_ID=b.SU_ID and a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT)
                        join LOC_MST c on (a.LOC_NO=c.LOC_NO)
                        where c.LOC_STS='S' and a.STGE_TYPE='ATR' and a.SKU_ALO_QTY=0 and a.WHSE_NO='{1}' and a.PLANT='{2}' and a.STGE_LOC='{3}' and a.SKU_NO='{4}' and IsNull(a.BATCH_NO,'')='{5}' and IsNull(a.STK_CAT,'')='{6}' and IsNull(a.STK_SPECIAL_IND,'')='{7}' and IsNull(a.STK_SPECIAL_NO,'')='{8}' and a.SKU_UNIT='{9}'
                        group by a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR
                        order by min(b.EXPIRE_DATE),min(b.GR_DATE),a.SKU_QTY desc
                    ", sOUT_NOs, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                        dtLocDtl = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtLocDtl, dbConnection, dbTransaction);
                        if (dtLocDtl.Rows.Count < 1) continue; //無此儲位Item

                        //decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_NUMERATOR"]);
                        //decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_DENOMINATOR"]);

                        for (int iLoc = 0; iLoc < dtLocDtl.Rows.Count; iLoc++)
                        {
                            decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_NUMERATOR"]);
                            decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_DENOMINATOR"]);
                            string sLocGtinUnit = Convert.ToString(dtLocDtl.Rows[iLoc]["GTIN_UNIT"]).Trim();

                            if (dTotalDemandQty == 0) break; //合併後的Item需求總數已全部分配完成

                            decimal dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_QTY"]);
                            decimal dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]);
                            decimal dLocAvailQty = dLocSkuQty - dLocSkuAloQty; //在储位托盤上可分配的Item總數

                            if (dLocAvailQty <= 0) continue; //因為可能被之前的處理先分配了

                            string sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["EXPIRE_DATE"]).Trim();
                            string sGR_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["GR_DATE"]).Trim();
                            string sSU_ID = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_ID"]).Trim();
                            string sLOC_NO = Convert.ToString(dtLocDtl.Rows[iLoc]["LOC_NO"]).Trim();
                            string sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_TYPE"]).Trim();
                            string sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                            string sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_TYPE"]).Trim();

                            decimal dLocTotalAloQty = 0; //累計储位分配數
                            decimal dLocPickQty = 0; //該儲位分配數

                            if (dTotalDemandQty >= dLocAvailQty) //需求總數>=可分配在储數
                            {
                                dLocPickQty = dLocAvailQty; //該儲位托盤可全部分配
                            }
                            else
                            {
                                //當總需求數<托盤數時，要找下一托盤，
                                //直到剩餘總需求數是=托盤可分配數時，如果是等餘則選取該托盤，如果是大於則選擇前一筆托盤

                                bool bSelect = false;
                                int iSelect = 0;
                                int j = iLoc; //當前LocDtl Index
                                while (true)
                                {
                                    j++; //下一筆
                                    if (j >= dtLocDtl.Rows.Count) break; //超出LocDtl row index

                                    decimal dLocQty = 0;

                                    if (sGR_DATE != Convert.ToString(dtLocDtl.Rows[j]["GR_DATE"]))
                                    {
                                        //遇到下一個FIFO則往回選大於需求的
                                        while (true)
                                        {
                                            j--;

                                            if (j < iLoc) //回到當前locdtl row index
                                            {
                                                bSelect = true;
                                                iSelect = iLoc;
                                                break;
                                            }

                                            dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                            if (dLocQty >= dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //相同的FIFO,直到儲位數量<=需求數則選前一個儲位數量>需求數的托盤
                                        dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                        if (dLocQty <= dTotalDemandQty)
                                        {
                                            if (dLocQty == dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                            }
                                            else
                                            {
                                                bSelect = true;
                                                iSelect = j - 1;
                                            }
                                        }
                                    }

                                    if (bSelect) break;
                                }

                                if (bSelect)
                                {
                                    //可能托盤改變所以要重新賦值
                                    dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_QTY"]);
                                    dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_ALO_QTY"]);
                                    dLocAvailQty = dLocSkuQty - dLocSkuAloQty;

                                    sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["EXPIRE_DATE"]);
                                    sGR_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["GR_DATE"]);
                                    sSU_ID = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_ID"]);
                                    sLOC_NO = Convert.ToString(dtLocDtl.Rows[iSelect]["LOC_NO"]);
                                    sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["STGE_TYPE"]).Trim();
                                    sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                                    sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_TYPE"]).Trim();
                                }

                                dLocPickQty = dTotalDemandQty; //該儲位托盤部分分配
                            }

                            //合併的Delivery order明細
                            sSQL = string.Format(@"
                            select *,(SKU_OUT_QTY - SKU_ALO_QTY) as SKU_CMD_QTY 
                            from OUT_DTL
                            where OUT_NO in ({0}) and OUT_STS in ('0','1') and SKU_OUT_QTY > SKU_ALO_QTY
                                and WHSE_NO='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            order by (SKU_OUT_QTY - SKU_ALO_QTY) desc
                        ", sOUT_NOs, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            dtOutDtl = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtOutDtl, dbConnection, dbTransaction);
                            if (dtOutDtl.Rows.Count < 1) continue; //無此Delivery Item

                            //分配到各OUT_DTL
                            decimal dOutGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_NUMERATOR"]);
                            decimal dOutGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_DENOMINATOR"]);
                            for (int iOut = 0; iOut < dtOutDtl.Rows.Count; iOut++)
                            {
                                decimal dOutCmdQty = Convert.ToDecimal(dtOutDtl.Rows[iOut]["SKU_CMD_QTY"]); //delivery item demand qty
                                string sOUT_NO = Convert.ToString(dtOutDtl.Rows[iOut]["OUT_NO"]);
                                string sOUT_LINE = Convert.ToString(dtOutDtl.Rows[iOut]["OUT_LINE"]);
                                dOutGtinNumerator = Convert.ToDecimal(dtOutDtl.Rows[iOut]["GTIN_NUMERATOR"]);
                                dOutGtinDenominator = Convert.ToDecimal(dtOutDtl.Rows[iOut]["GTIN_DENOMINATOR"]);

                                //找已經生成的托盤出庫分揀指令
                                //找已經生成的PCK_MST
                                string sPCK_NO = string.Empty;
                                string sPCK_LINE = "0001";
                                sSQL = string.Format(@"
                                select a.PCK_NO,count(b.PCK_LINE) as CNT 
                                from PCK_MST a join PCK_DTL b
                                on (a.WHSE_NO=b.WHSE_NO and a.PCK_NO=b.PCK_NO)
                                where a.SU_ID='{0}' and a.PCK_STS in ('0','1') and a.PCK_TYPE='P' and a.LOC_NO='{1}'
                                group by a.PCK_NO
                            ", sSU_ID, sLOC_NO);
                                dtPckMst = new DataTable();
                                WMSDB.funGetDT(sSQL, ref dtPckMst, dbConnection, dbTransaction);
                                if (dtPckMst.Rows.Count < 1)
                                {
                                    //創建CMD_MST & PCK_MST
                                    //取得CMD_SNO
                                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                                    string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                                    if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                                    //預約LOC_MST
                                    sSQL = string.Format(@"
                                    update LOC_MST 
                                    set LOC_STS='O',LOC_OSTS='S',TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20) 
                                    where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='S'
                                ", sLOC_NO, sSU_ID, Globals.USER_NAME);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                    sPCK_NO = sCMD_DATE + sCMD_SNO;
                                    //生成CMD_MST(如果STGE_TYPE="ATR"是自動倉)
                                    if (sSTGE_BIN == "ASRSA00000" && sLOC_NO.Length == 7)
                                    {
                                        //生成CMD_MST
                                        string sCMD_STS = "0";
                                        string sEQU_NO = "01";
                                        switch (sLOC_NO.Substring(0, 2))
                                        {
                                            case "01":
                                            case "02":
                                                sEQU_NO = "01";
                                                break;
                                            case "03":
                                            case "04":
                                                sEQU_NO = "02";
                                                break;
                                            case "05":
                                            case "06":
                                                sEQU_NO = "03";
                                                break;
                                            case "07":
                                            case "08":
                                                sEQU_NO = "04";
                                                break;
                                            default: throw new Exception("invalid LOC_NO:" + sLOC_NO);
                                        }

                                        string sSTN_NO = "A04";
                                        switch (sEQU_NO)
                                        {
                                            case "01":
                                                sSTN_NO = "A04";
                                                break;
                                            case "02":
                                                sSTN_NO = "A10";
                                                break;
                                            case "03":
                                                sSTN_NO = "A16";
                                                break;
                                            case "04":
                                                sSTN_NO = "A22";
                                                break;
                                            default: throw new Exception("invalid EQU_NO:" + sEQU_NO);
                                        }

                                        string sPRTY = "5";
                                        string sCMD_MODE = "2";
                                        string sIO_TYPE = "21";
                                        string sTRACE = "00";

                                        sSQL = string.Format(@"
                                        insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                                    ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, sOUT_NO, sOUT_LINE, sPCK_NO, "P", Globals.USER_NAME);
                                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                        if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                    }

                                    //生成PCK_MST
                                    sSQL = string.Format(@"
                                    insert into PCK_MST(WHSE_NO,PCK_NO,PCK_TYPE,STGE_BIN,STGE_TYPE,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',N'{12}',convert(varchar(19),getdate(),20),N'{12}',convert(varchar(19),getdate(),20))
                                ", sWHSE_NO, sPCK_NO, "P", sSTGE_TYPE, sSTGE_BIN, sSU_ID, sSU_TYPE, sLOC_NO, sCMD_DATE, sCMD_SNO, "0", "Y", Globals.USER_NAME);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }
                                else
                                {
                                    sPCK_NO = Convert.ToString(dtPckMst.Rows[0]["PCK_NO"]).Trim();
                                    sPCK_LINE = (int.Parse(Convert.ToString(dtPckMst.Rows[0]["CNT"])) + 1).ToString("0000");
                                }

                                decimal dPickQty = dLocPickQty;
                                if (dLocPickQty >= dOutCmdQty) dPickQty = dOutCmdQty; //如果托盤储位可分配數>Delivery Item需求數
                                dLocPickQty = dLocPickQty - dPickQty; //該托盤餘數
                                dLocTotalAloQty = dLocTotalAloQty + dPickQty; //該托盤累計分配餘數

                                //計算PickGtinAloQty

                                decimal dPickGtinAloQty = dPickQty * dLocGtinDenominator / dLocGtinNumerator; //換算為GTIN_ALO_QTY


                                //產生PCK_DTL
                                sSQL = string.Format(@"
                                insert into PCK_DTL(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}',N'{23}',convert(varchar(19),getdate(),20),N'{23}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dPickGtinAloQty, 0, sSKU_UNIT, dPickQty, 0, "0", "Y", Globals.USER_NAME);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                //現在不能產生PCK_SNO，必須在出庫命令完成時刪除PLT_DTL及產生PCK_SNO
                                sSQL = string.Format(@"
                                select IN_SNO,IN_NO,IN_LINE,SKU_QTY,IsNull(SKU_ALO_QTY,0) as SKU_ALO_QTY
                                from PLT_DTL 
                                where SKU_QTY > IsNull(SKU_ALO_QTY,0) and SU_ID='{0}' and WHSE_NO= '{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}' 
                                order by EXPIRE_DATE,GR_DATE
                            ", sSU_ID, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                                dtPltDtl = new DataTable();
                                WMSDB.funGetDT(sSQL, ref dtPltDtl, dbConnection, dbTransaction);
                                if (dtPltDtl.Rows.Count < 1) throw new Exception("no pallet item data:" + sSQL);

                                decimal dSnoPickQty = dPickQty;
                                decimal dSnoTrnQty = 0;
                                for (int iSno = 0; iSno < dtPltDtl.Rows.Count; iSno++)
                                {
                                    if (dSnoPickQty <= 0) break;

                                    string sIN_SNO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_SNO"]);
                                    string sIN_NO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_NO"]);
                                    string sIN_LINE = Convert.ToString(dtPltDtl.Rows[iSno]["IN_LINE"]);
                                    decimal dSnoSkuQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_QTY"]);
                                    decimal dSnoSkuAloQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_ALO_QTY"]);
                                    if (dSnoPickQty >= (dSnoSkuQty - dSnoSkuAloQty))
                                    {
                                        dSnoTrnQty = (dSnoSkuQty - dSnoSkuAloQty);
                                    }
                                    else
                                    {
                                        dSnoTrnQty = dSnoPickQty;
                                    }

                                    //生成PCK_SNO
                                    decimal dGtinSnoTrnQty = dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator;
                                    sSQL = string.Format(@"
                                        insert into PCK_SNO(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,IN_SNO,IN_NO,IN_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}','{23}',N'{24}',convert(varchar(19),getdate(),20),N'{24}',convert(varchar(19),getdate(),20))
                                        ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinSnoTrnQty, 0, sSKU_UNIT, dSnoTrnQty, 0, sIN_SNO, sIN_NO, sIN_LINE, Globals.USER_NAME);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                    //備份PLT_DTL
                                    sSQL = string.Format(@"
                                    insert into PLT_DTL_HIS 
                                    select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PLT_DTL 
                                    where WHSE_NO='{1}' and SU_ID='{2}' and IN_SNO='{3}' and IN_NO='{4}' and IN_LINE='{5}'
                                ", Globals.USER_NAME, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                    //更新PLT_DTL
                                    decimal dSnoGtinAloQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                    sSQL = string.Format(@"
                                    update PLT_DTL set GTIN_ALO_QTY=IsNull(GTIN_ALO_QTY,0)+{0},SKU_ALO_QTY=IsNull(SKU_ALO_QTY,0)+{1}
                                    where WHSE_NO='{2}' and SU_ID='{3}' and IN_SNO='{4}' and IN_NO='{5}' and IN_LINE='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}'
                                ", dSnoGtinAloQty, dSnoTrnQty, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                    dSnoPickQty = dSnoPickQty - dSnoTrnQty;
                                }

                                dTotalDemandQty = dTotalDemandQty - dPickQty;

                                //備份OUT_DTL
                                sSQL = string.Format(@"
                                insert into OUT_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from OUT_DTL 
                                where WHSE_NO='{1}' and OUT_NO='{2}' and OUT_LINE='{3}'
                                ", Globals.USER_NAME, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                //更新OUT_DTL.GTIN_ALO_QTY & SKU_ALO_QTY
                                decimal dGtinAloQty = Decimal.Round(dPickQty * dOutGtinDenominator / dOutGtinNumerator, 3);
                                sSQL = string.Format(@"
                                update OUT_DTL set OUT_STS='1',GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and OUT_NO='{4}' and OUT_LINE='{5}'
                                ", dGtinAloQty, Decimal.Round(dPickQty, 3), Globals.USER_NAME, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                //備份OUT_MST
                                sSQL = string.Format(@"
                                insert into OUT_MST_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{2}' as LOG_USER from OUT_MST 
                                where WHSE_NO='{0}' and OUT_NO='{1}'
                            ", sWHSE_NO, sOUT_NO, Globals.USER_NAME);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                //更新OUT_MST
                                sSQL = string.Format(@"
                                update OUT_MST set OUT_STS=CASE WHEN (select count(*) from OUT_DTL where OUT_STS in ('0','1') and WHSE_NO='{0}' and OUT_NO='{1}') < 1 THEN '9' ELSE '1' END,
                                    TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{0}' and OUT_NO='{1}' and OUT_STS in ('0','1')
                            ", sWHSE_NO, sOUT_NO, Globals.USER_NAME);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL); //如果被取消則無法完成過帳

                                if (dLocPickQty > 0) continue; //托盤還有餘數，且還有下一個Delivery Item可以分配
                                else break; //托盤已無於數可分配Delivery Item

                            } //OutDtl loop


                            //該托盤已全部分配完或已無Delivery Item可分配
                            //備份LOC_DTL到歷史檔
                            sSQL = string.Format(@"
                                insert into LOC_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER from LOC_DTL 
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, Globals.USER_NAME);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            //更新LOC_DTL
                            decimal dLocTotalGtinAloQty = Decimal.Round(dLocTotalAloQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                                update LOC_DTL 
                                set GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and SKU_UNIT='{12}'
                            ", dLocTotalGtinAloQty, dLocTotalAloQty.ToString(), Globals.USER_NAME, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"] = Decimal.Round(Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]) + dLocTotalAloQty, 3);

                            if (dTotalDemandQty <= 0) break; //合併後的總需求數>0,找下一個托盤

                        } //LocDtl loop
                    } //MergeOutDtl loop

                    // TESING STEP 4 AND 5, 
                    //throw new Exception("模擬失敗...");

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }

                // STEP 4
                //MessageBox.Show("Confirm success");
            }
            catch (Exception ex)
            {
                // STEP 5
                //MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dtMergeOutDtl != null) { dtMergeOutDtl.Dispose(); dtMergeOutDtl = null; }
                if (dtOutDtl != null) { dtOutDtl.Dispose(); dtOutDtl = null; }
                if (dtLocDtl != null) { dtLocDtl.Dispose(); dtLocDtl = null; }
                if (dtPckMst != null) { dtPckMst.Dispose(); dtPckMst = null; }
                if (dtPltDtl != null) { dtPltDtl.Dispose(); dtPltDtl = null; }
            }
        }


        public async Task<bool> MLASRS_EmptyCheckAsync(string SU_ID)
        {
            //string sSQL = string.Format(@"select * from PLT_DTL where SU_ID='{0}'", sSU_ID);
            //if (dataTable.Rows.Count > 0) bReturn = false;

            int cnt = await Db.PltDtls.Where(a => a.SU_ID == SU_ID).AsNoTracking().CountAsync();
            return cnt > 0 ? false : true;
        }

        public async Task MLASRS_CreateEmptyCMD_IN_Async(string conn, string DhUsername, string sSU_ID, string sREMARK)
        {
            // STEP 1
            //   async Task MLASRS_{}_Async
            //   string conn, string DhUsername,

            // STEP 2
            WMSDB = new WESDB(DB_PROVIDER_TYPE, conn); // NOTE by Mark, implement static DB_PROVIDER_TYPE
            Globals.USER_NAME = DhUsername;


            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            DataTable dataTable = new DataTable();

            string sSQL = string.Empty;

            int iResult = 0;

            try
            {
                //throw new Exception("sim MLASRS_CreateEmptyCMD_IN_Async exception ...");
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try
                {

                    //檢查母托盤是否已有命令
                    sSQL = string.Format(@"select * from CMD_MST where SU_ID='{0}' and CMD_STS in ('0','1','2','X')", sSU_ID);
                    WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);
                    if (dataTable.Rows.Count > 1) throw new Exception("duplicate CMD_MST:" + sSQL);

                    //取得CMD_SNO
                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                    string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                    if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                    //生成CMD_MST(先不給值，等掃碼時才給LOC_NO,EQU_NO,STN_NO
                    string sCMD_STS = "X";
                    string sLOC_NO = "";
                    string sEQU_NO = "";
                    string sSTN_NO = "";
                    string sPRTY = "5";
                    string sCMD_MODE = "1";
                    string sIO_TYPE = "10"; //Empty pallet in
                    string sTRACE = "00";
                    string sPROG_ID = "P090";

                    sSQL = string.Format(@"
                insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,REMARK)
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20),N'{17}')
                ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, "", "", "", "", Globals.USER_NAME, sREMARK);
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data create:" + sSQL);

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dataTable != null) { dataTable.Dispose(); dataTable = null; }
            }
        }



        /// <summary>
        /// 這 AllocateDtl 在 MLASRS 是 P020 P030 共用,
        /// 但由於 參數, 暫時分別處理
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="DhUsername"></param>
        /// <param name="sPROG_ID"></param>
        /// <param name="dgvRows"></param>
        /// <returns></returns>
        public async Task MLASRS_AllocateDtl_Async(string conn, string DhUsername, string sPROG_ID, RadzenDh5.Models.Mark10Sqlexpress04.OutDtl[] dgvRows)
        {
            // STEP 1
            // public static void AllocateDtl(string sPROG_ID, DataGridViewRow[] dgvRows)
            // dgvRows 已經給成 array, 可以少動些原代碼

            // STEP 2
            WMSDB = new WESDB(DB_PROVIDER_TYPE, conn); // NOTE by Mark, implement static DB_PROVIDER_TYPE
            Globals.USER_NAME = DhUsername;



            //此程式是Muti delivery orderc合併為一個波次分配

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;

            DataTable dtOutDtl = new DataTable();
            DataTable dtLocDtl = new DataTable();
            DataTable dtPckMst = new DataTable();
            DataTable dtPltDtl = new DataTable();
            string sSQL = string.Empty;
            int iResult = 0;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    bool bNextLine = true;
                    string sOUT_NO = string.Empty;
                    string sOUT_LINE = string.Empty;
                    for (int idx = 0; idx < dgvRows.Length; idx++)

                    {
                        bool bNextNo = false;
                        bNextLine = false; //控制不要多次生成OUT_DTL_HIS
                                           //if (Convert.ToString(dgvRows[idx].Cells["OUT_NO"].Value).Trim() != sOUT_NO) { bNextNo = true; bNextLine = true; }
                                           //sOUT_NO = Convert.ToString(dgvRows[idx].Cells["OUT_NO"].Value).Trim();
                                           //if (Convert.ToString(dgvRows[idx].Cells["OUT_LINE"].Value).Trim() != sOUT_LINE && bNextNo == false) { bNextLine = true; }
                                           //sOUT_LINE = Convert.ToString(dgvRows[idx].Cells["OUT_LINE"].Value).Trim();

                        // STEP 3

                        //string sWHSE_NO = Convert.ToString(dgvRows[idx].Cells["WHSE_NO"].Value).Trim();
                        //string sPLANT = Convert.ToString(dgvRows[idx].Cells["PLANT"].Value).Trim();
                        //string sSTGE_LOC = Convert.ToString(dgvRows[idx].Cells["STGE_LOC"].Value).Trim();
                        //string sSKU_NO = Convert.ToString(dgvRows[idx].Cells["SKU_NO"].Value).Trim();
                        //string sBATCH_NO = Convert.ToString(dgvRows[idx].Cells["BATCH_NO"].Value).Trim();
                        //string sSTK_CAT = Convert.ToString(dgvRows[idx].Cells["STK_CAT"].Value).Trim();
                        //string sSTK_SPECIAL_IND = Convert.ToString(dgvRows[idx].Cells["STK_SPECIAL_IND"].Value).Trim();
                        //string sSTK_SPECIAL_NO = Convert.ToString(dgvRows[idx].Cells["STK_SPECIAL_NO"].Value).Trim();
                        //string sGTIN_UNIT = Convert.ToString(dgvRows[idx].Cells["GTIN_UNIT"].Value).Trim();
                        //string sSKU_UNIT = Convert.ToString(dgvRows[idx].Cells["SKU_UNIT"].Value).Trim();
                        //decimal dTotalDemandQty = Convert.ToDecimal(dgvRows[idx].Cells["SKU_OUT_QTY"].Value) - Convert.ToDecimal(dgvRows[idx].Cells["SKU_ALO_QTY"].Value);
                        //decimal dOutGtinNumerator = Convert.ToDecimal(dgvRows[idx].Cells["GTIN_NUMERATOR"].Value);
                        //decimal dOutGtinDenominator = Convert.ToDecimal(dgvRows[idx].Cells["GTIN_DENOMINATOR"].Value);

                        if (Convert.ToString(dgvRows[idx].OUT_NO).Trim() != sOUT_NO) { bNextNo = true; bNextLine = true; }
                        sOUT_NO = Convert.ToString(dgvRows[idx].OUT_NO).Trim();
                        if (Convert.ToString(dgvRows[idx].OUT_LINE).Trim() != sOUT_LINE && bNextNo == false) { bNextLine = true; }
                        sOUT_LINE = Convert.ToString(dgvRows[idx].OUT_LINE).Trim();

                        string sWHSE_NO = Convert.ToString(dgvRows[idx].WHSE_NO).Trim();
                        string sPLANT = Convert.ToString(dgvRows[idx].PLANT).Trim();
                        string sSTGE_LOC = Convert.ToString(dgvRows[idx].STGE_LOC).Trim();
                        string sSKU_NO = Convert.ToString(dgvRows[idx].SKU_NO).Trim();
                        string sBATCH_NO = Convert.ToString(dgvRows[idx].BATCH_NO).Trim();
                        string sSTK_CAT = Convert.ToString(dgvRows[idx].STK_CAT).Trim();
                        string sSTK_SPECIAL_IND = Convert.ToString(dgvRows[idx].STK_SPECIAL_IND).Trim();
                        string sSTK_SPECIAL_NO = Convert.ToString(dgvRows[idx].STK_SPECIAL_NO).Trim();
                        string sGTIN_UNIT = Convert.ToString(dgvRows[idx].GTIN_UNIT).Trim();
                        string sSKU_UNIT = Convert.ToString(dgvRows[idx].SKU_UNIT).Trim();
                        decimal dTotalDemandQty = Convert.ToDecimal(dgvRows[idx].SKU_OUT_QTY) - Convert.ToDecimal(dgvRows[idx].SKU_ALO_QTY);
                        decimal dOutGtinNumerator = Convert.ToDecimal(dgvRows[idx].GTIN_NUMERATOR);
                        decimal dOutGtinDenominator = Convert.ToDecimal(dgvRows[idx].GTIN_DENOMINATOR);




                        //儲位明細
                        sSQL = string.Format(@"
                        select a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT,a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE, min(b.GR_DATE) as GR_DATE,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR 
                        from LOC_DTL a
                        join PLT_DTL b
                        on (a.SU_ID=b.SU_ID and a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT)
                        join LOC_MST c on (a.LOC_NO=c.LOC_NO)
                        where c.LOC_STS='S' and a.STGE_TYPE='ATR' and a.SKU_ALO_QTY=0 and a.WHSE_NO='{0}' and a.PLANT='{1}' and a.STGE_LOC='{2}' and a.SKU_NO='{3}' and IsNull(a.BATCH_NO,'')='{4}' and IsNull(a.STK_CAT,'')='{5}' and IsNull(a.STK_SPECIAL_IND,'')='{6}' and IsNull(a.STK_SPECIAL_NO,'')='{7}' and a.SKU_UNIT='{8}'
                        group by a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY,a.SKU_ALO_QTY,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR
                        order by min(b.EXPIRE_DATE),min(b.GR_DATE),a.SKU_QTY desc
                    ", sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                        dtLocDtl = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtLocDtl, dbConnection, dbTransaction);
                        if (dtLocDtl.Rows.Count < 1) continue; //無此儲位Item


                        for (int iLoc = 0; iLoc < dtLocDtl.Rows.Count; iLoc++)
                        {

                            decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_NUMERATOR"]);
                            decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_DENOMINATOR"]);
                            string sLocGtinUnit = Convert.ToString(dtLocDtl.Rows[iLoc]["GTIN_UNIT"]).Trim();

                            if (dTotalDemandQty == 0) break; //合併後的Item需求總數已全部分配完成

                            decimal dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_QTY"]);
                            decimal dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]);
                            decimal dLocAvailQty = dLocSkuQty - dLocSkuAloQty; //在储位托盤上可分配的Item總數

                            if (dLocAvailQty <= 0) continue; //因為可能被之前的處理先分配了

                            string sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["EXPIRE_DATE"]).Trim();
                            string sGR_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["GR_DATE"]).Trim();
                            string sSU_ID = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_ID"]).Trim();
                            string sLOC_NO = Convert.ToString(dtLocDtl.Rows[iLoc]["LOC_NO"]).Trim();
                            string sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_TYPE"]).Trim();
                            string sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                            string sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_TYPE"]).Trim();

                            decimal dLocTotalAloQty = 0; //累計储位分配數
                            decimal dLocPickQty = 0; //該儲位分配數

                            if (dTotalDemandQty >= dLocAvailQty) //需求總數>=可分配在储數
                            {
                                dLocPickQty = dLocAvailQty; //該儲位托盤可全部分配
                            }
                            else
                            {
                                //當總需求數<托盤數時，要找下一托盤，
                                //直到剩餘總需求數是=托盤可分配數時，如果是等餘則選取該托盤，如果是大於則選擇前一筆托盤

                                bool bSelect = false;
                                int iSelect = 0;
                                int j = iLoc; //當前LocDtl Index
                                while (true)
                                {
                                    j++; //下一筆
                                    if (j >= dtLocDtl.Rows.Count) break; //超出LocDtl row index

                                    decimal dLocQty = 0;

                                    if (sGR_DATE != Convert.ToString(dtLocDtl.Rows[j]["GR_DATE"]))
                                    {
                                        //遇到下一個FIFO則往回選大於需求的
                                        while (true)
                                        {
                                            j--;

                                            if (j < iLoc) //回到當前locdtl row index
                                            {
                                                bSelect = true;
                                                iSelect = iLoc;
                                                break;
                                            }

                                            dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                            if (dLocQty >= dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //相同的FIFO,直到儲位數量<=需求數則選前一個儲位數量>需求數的托盤
                                        dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                        if (dLocQty <= dTotalDemandQty)
                                        {
                                            if (dLocQty == dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                            }
                                            else
                                            {
                                                bSelect = true;
                                                iSelect = j - 1;
                                            }
                                        }
                                    }

                                    if (bSelect) break;
                                }

                                if (bSelect)
                                {
                                    //可能托盤改變所以要重新賦值
                                    dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_QTY"]);
                                    dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_ALO_QTY"]);
                                    dLocAvailQty = dLocSkuQty - dLocSkuAloQty;

                                    sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["EXPIRE_DATE"]);
                                    sGR_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["GR_DATE"]);
                                    sSU_ID = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_ID"]);
                                    sLOC_NO = Convert.ToString(dtLocDtl.Rows[iSelect]["LOC_NO"]);
                                    sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["STGE_TYPE"]).Trim();
                                    sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                                    sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_TYPE"]).Trim();
                                }

                                dLocPickQty = dTotalDemandQty; //該儲位托盤部分分配
                            }

                            //找已經生成的托盤出庫分揀指令
                            //找已經生成的PCK_MST
                            string sPCK_NO = string.Empty;
                            string sPCK_LINE = "0001";
                            sSQL = string.Format(@"
                            select a.PCK_NO,count(b.PCK_LINE) as CNT 
                            from PCK_MST a join PCK_DTL b
                            on (a.WHSE_NO=b.WHSE_NO and a.PCK_NO=b.PCK_NO)
                            where a.SU_ID='{0}' and a.PCK_STS in ('0','1') and a.PCK_TYPE='P' and a.LOC_NO='{1}'
                            group by a.PCK_NO
                        ", sSU_ID, sLOC_NO);
                            dtPckMst = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtPckMst, dbConnection, dbTransaction);
                            if (dtPckMst.Rows.Count < 1)
                            {
                                //創建CMD_MST & PCK_MST
                                //取得CMD_SNO
                                string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                                string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                                if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                                //預約LOC_MST
                                sSQL = string.Format(@"
                                update LOC_MST 
                                set LOC_STS='O',LOC_OSTS='S',TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20) 
                                where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='S'
                            ", sLOC_NO, sSU_ID, Globals.USER_NAME);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                string sSTN_NO = "A04";

                                sPCK_NO = sCMD_DATE + sCMD_SNO;
                                //生成CMD_MST(如果STGE_TYPE="ATR"是自動倉)
                                if (sSTGE_BIN == "ASRSA00000" && sLOC_NO.Length == 7)
                                {
                                    //生成CMD_MST
                                    string sCMD_STS = "0";
                                    string sEQU_NO = "01";
                                    switch (sLOC_NO.Substring(0, 2))
                                    {
                                        case "01":
                                        case "02":
                                            sEQU_NO = "01";
                                            break;
                                        case "03":
                                        case "04":
                                            sEQU_NO = "02";
                                            break;
                                        case "05":
                                        case "06":
                                            sEQU_NO = "03";
                                            break;
                                        case "07":
                                        case "08":
                                            sEQU_NO = "04";
                                            break;
                                        default: throw new Exception("invalid LOC_NO:" + sLOC_NO);
                                    }


                                    switch (sEQU_NO)
                                    {
                                        case "01":
                                            sSTN_NO = "A04";
                                            break;
                                        case "02":
                                            sSTN_NO = "A10";
                                            break;
                                        case "03":
                                            sSTN_NO = "A16";
                                            break;
                                        case "04":
                                            sSTN_NO = "A22";
                                            break;
                                        default: throw new Exception("invalid EQU_NO:" + sEQU_NO);
                                    }

                                    string sPRTY = "5";
                                    string sCMD_MODE = "2";
                                    string sIO_TYPE = "21";
                                    string sTRACE = "00";

                                    sSQL = string.Format(@"
                                    insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                                ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, sOUT_NO, sOUT_LINE, sPCK_NO, "P", Globals.USER_NAME);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }

                                //生成PCK_MST
                                sSQL = string.Format(@"
                                insert into PCK_MST(WHSE_NO,PCK_NO,PCK_TYPE,STGE_BIN,STGE_TYPE,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,STN_NO,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',N'{13}',convert(varchar(19),getdate(),20),N'{13}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPCK_NO, "P", sSTGE_TYPE, sSTGE_BIN, sSU_ID, sSU_TYPE, sLOC_NO, sCMD_DATE, sCMD_SNO, sSTN_NO, "0", "Y", Globals.USER_NAME);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);
                            }
                            else
                            {
                                sPCK_NO = Convert.ToString(dtPckMst.Rows[0]["PCK_NO"]).Trim();
                                sPCK_LINE = (int.Parse(Convert.ToString(dtPckMst.Rows[0]["CNT"])) + 1).ToString("0000");
                            }

                            decimal dPickQty = dLocPickQty;
                            if (dLocPickQty >= dTotalDemandQty) dPickQty = dTotalDemandQty; //如果托盤储位可分配數>Delivery Item需求數
                            dLocPickQty = dLocPickQty - dPickQty; //該托盤餘數
                            dLocTotalAloQty = dLocTotalAloQty + dPickQty; //該托盤累計分配餘數

                            //產生PCK_DTL
                            decimal dGtinPickAloQty = Decimal.Round(dPickQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                            insert into PCK_DTL(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}',N'{23}',convert(varchar(19),getdate(),20),N'{23}',convert(varchar(19),getdate(),20))
                        ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinPickAloQty, 0, sSKU_UNIT, dPickQty, 0, "0", "Y", Globals.USER_NAME);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data create:" + sSQL);

                            //現在不能產生PCK_SNO，必須在出庫命令完成時刪除PLT_DTL及產生PCK_SNO
                            sSQL = string.Format(@"
                            select IN_SNO,IN_NO,IN_LINE,SKU_QTY,IsNull(SKU_ALO_QTY,0) as SKU_ALO_QTY 
                            from PLT_DTL 
                            where SKU_QTY > IsNull(SKU_ALO_QTY,0) and SU_ID='{0}' and WHSE_NO= '{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}' 
                            order by EXPIRE_DATE,GR_DATE
                        ", sSU_ID, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            dtPltDtl = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtPltDtl, dbConnection, dbTransaction);
                            if (dtPltDtl.Rows.Count < 1) throw new Exception("no pallet item data:" + sSQL);

                            decimal dSnoPickQty = dPickQty;
                            decimal dSnoTrnQty = 0;
                            for (int iSno = 0; iSno < dtPltDtl.Rows.Count; iSno++)
                            {
                                if (dSnoPickQty <= 0) break;

                                string sIN_SNO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_SNO"]);
                                string sIN_NO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_NO"]);
                                string sIN_LINE = Convert.ToString(dtPltDtl.Rows[iSno]["IN_LINE"]);
                                decimal dSnoSkuQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_QTY"]);
                                decimal dSnoSkuAloQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_ALO_QTY"]);
                                if (dSnoPickQty >= (dSnoSkuQty - dSnoSkuAloQty))
                                {
                                    dSnoTrnQty = (dSnoSkuQty - dSnoSkuAloQty);
                                }
                                else
                                {
                                    dSnoTrnQty = dSnoPickQty;
                                }

                                //生成PCK_SNO
                                if (sIN_SNO != "**********")
                                {
                                    decimal dGtinSnoTrnQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                    sSQL = string.Format(@"
                                    insert into PCK_SNO(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,IN_SNO,IN_NO,IN_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}','{23}',N'{24}',convert(varchar(19),getdate(),20),N'{24}',convert(varchar(19),getdate(),20))
                                    ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinSnoTrnQty, 0, sSKU_UNIT, dSnoTrnQty, 0, sIN_SNO, sIN_NO, sIN_LINE, Globals.USER_NAME);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data create:" + sSQL);
                                }

                                //備份PLT_DTL
                                sSQL = string.Format(@"
                                insert into PLT_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PLT_DTL 
                                where WHSE_NO='{1}' and SU_ID='{2}' and IN_SNO='{3}' and IN_NO='{4}' and IN_LINE='{5}'
                            ", Globals.USER_NAME, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data create:" + sSQL);

                                //更新PLT_DTL
                                decimal dSnoGtinAloQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                sSQL = string.Format(@"
                                update PLT_DTL set GTIN_ALO_QTY=IsNull(GTIN_ALO_QTY,0)+{0},SKU_ALO_QTY=IsNull(SKU_ALO_QTY,0)+{1}
                                where WHSE_NO='{2}' and SU_ID='{3}' and IN_SNO='{4}' and IN_NO='{5}' and IN_LINE='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}'
                            ", dSnoGtinAloQty, dSnoTrnQty, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);

                                dSnoPickQty = dSnoPickQty - dSnoTrnQty;
                            }

                            dTotalDemandQty = dTotalDemandQty - dPickQty;

                            //備份OUT_DTL
                            if (bNextLine)
                            {
                                sSQL = string.Format(@"
                            insert into OUT_DTL_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from OUT_DTL 
                            where WHSE_NO='{1}' and OUT_NO='{2}' and OUT_LINE='{3}'
                            ", Globals.USER_NAME, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //更新OUT_DTL.GTIN_ALO_QTY & SKU_ALO_QTY
                            decimal dGtinAloQty = Decimal.Round(dPickQty * dOutGtinDenominator / dOutGtinNumerator, 3);
                            sSQL = string.Format(@"
                            update OUT_DTL set OUT_STS='1',GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{3}' and OUT_NO='{4}' and OUT_LINE='{5}'
                            ", dGtinAloQty, Decimal.Round(dPickQty, 3), Globals.USER_NAME, sWHSE_NO, sOUT_NO, sOUT_LINE);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            if (bNextNo)
                            {
                                //備份OUT_MST
                                sSQL = string.Format(@"
                                insert into OUT_MST_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{2}' as LOG_USER from OUT_MST 
                                where WHSE_NO='{0}' and OUT_NO='{1}'
                            ", sWHSE_NO, sOUT_NO, Globals.USER_NAME);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);
                            }

                            //更新OUT_MST
                            sSQL = string.Format(@"
                            update OUT_MST set OUT_STS=CASE WHEN (select count(*) from OUT_DTL where OUT_STS in ('0','1') and WHSE_NO='{0}' and OUT_NO='{1}') < 1 THEN '9' ELSE '1' END,
                                TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                            where WHSE_NO='{0}' and OUT_NO='{1}' and OUT_STS in ('0','1')
                         ", sWHSE_NO, sOUT_NO, Globals.USER_NAME);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL); //如果被取消則無法完成過帳

                            //該托盤已全部分配完或已無Delivery Item可分配
                            //備份LOC_DTL到歷史檔
                            sSQL = string.Format(@"
                                insert into LOC_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER from LOC_DTL 
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, Globals.USER_NAME);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            //更新LOC_DTL
                            decimal dLocGtinTotalAloQty = Decimal.Round(dLocTotalAloQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                                update LOC_DTL 
                                set GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and SKU_UNIT='{12}'
                            ", dLocGtinTotalAloQty, dLocTotalAloQty.ToString(), Globals.USER_NAME, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data update:" + sSQL);

                            dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"] = Decimal.Round(Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]) + dLocTotalAloQty, 3);

                            if (dTotalDemandQty <= 0) break; //合併後的總需求數>0,找下一個托盤

                        } //LocDtl loop
                    } //Next Item

                    // TESING STEP 4 AND 5, 
                    // throw new Exception("模擬失敗 tab1...");

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
                // STEP 4, by caller directly
                //MessageBox.Show("Confirm success");
            }
            catch (Exception ex)
            {
                // STEP 5
                //MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dtOutDtl != null) { dtOutDtl.Dispose(); dtOutDtl = null; }
                if (dtLocDtl != null) { dtLocDtl.Dispose(); dtLocDtl = null; }
                if (dtPckMst != null) { dtPckMst.Dispose(); dtPckMst = null; }
                if (dtPltDtl != null) { dtPltDtl.Dispose(); dtPltDtl = null; }
            }
        }


        public async Task<(bool, string)> AllocateMstAsync(string conn, string DhUsername, string sPROG_ID, string sOUT_NOs)
        {
            string DbProviderType = "System.Data.SqlClient";

            //建立實例
            WMSDB = new WESDB(DbProviderType, conn);


            //此程式是Muti delivery orderc合併為一個波次分配

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;

            DataTable dtMergeOutDtl = new DataTable();
            DataTable dtOutDtl = new DataTable();
            DataTable dtLocDtl = new DataTable();
            DataTable dtPckMst = new DataTable();
            DataTable dtPltDtl = new DataTable();
            string sSQL = string.Empty;
            int iResult = 0;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                sSQL = string.Format(@"
                select WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT,sum(SKU_OUT_QTY - SKU_ALO_QTY) as SKU_CMD_QTY 
                from OUT_DTL
                where OUT_NO in ({0}) and OUT_STS in ('0','1') and SKU_OUT_QTY > SKU_ALO_QTY
                group by WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT
                order by WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT
            ", sOUT_NOs);
                dtMergeOutDtl = new DataTable();
                WMSDB.funGetDT(sSQL, ref dtMergeOutDtl, dbConnection, dbTransaction);
                if (dtMergeOutDtl.Rows.Count < 1)
                {
                    return (false, "no execute data:" + sSQL);
                }
                LogP020("Step1 pass");
                LogP020(sSQL);


                dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    //根據合併後的Item總數來分配Loc_Dtl
                    for (int idx = 0; idx < dtMergeOutDtl.Rows.Count; idx++)
                    {
                        string sWHSE_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["WHSE_NO"]).Trim();
                        string sPLANT = Convert.ToString(dtMergeOutDtl.Rows[idx]["PLANT"]).Trim();
                        string sSTGE_LOC = Convert.ToString(dtMergeOutDtl.Rows[idx]["STGE_LOC"]).Trim();
                        string sSKU_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["SKU_NO"]).Trim();
                        string sBATCH_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["BATCH_NO"]).Trim();
                        string sSTK_CAT = Convert.ToString(dtMergeOutDtl.Rows[idx]["STK_CAT"]).Trim();
                        string sSTK_SPECIAL_IND = Convert.ToString(dtMergeOutDtl.Rows[idx]["STK_SPECIAL_IND"]).Trim();
                        string sSTK_SPECIAL_NO = Convert.ToString(dtMergeOutDtl.Rows[idx]["STK_SPECIAL_NO"]).Trim();
                        string sGTIN_UNIT = Convert.ToString(dtMergeOutDtl.Rows[idx]["GTIN_UNIT"]).Trim();
                        string sSKU_UNIT = Convert.ToString(dtMergeOutDtl.Rows[idx]["SKU_UNIT"]).Trim();
                        decimal dTotalDemandQty = Convert.ToDecimal(dtMergeOutDtl.Rows[idx]["SKU_CMD_QTY"]); //合併後的Item需求總數

                        //儲位明細
                        sSQL = string.Format(@"
                        select a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE, min(b.GR_DATE) as GR_DATE,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR 
                        from LOC_DTL a
                        join PLT_DTL b
                        on (a.SU_ID=b.SU_ID and a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT)
                        join LOC_MST c on (a.LOC_NO=c.LOC_NO)
                        where c.LOC_STS='S' and a.STGE_TYPE='ATR' and a.SKU_ALO_QTY=0 and a.WHSE_NO='{1}' and a.PLANT='{2}' and a.STGE_LOC='{3}' and a.SKU_NO='{4}' and IsNull(a.BATCH_NO,'')='{5}' and IsNull(a.STK_CAT,'')='{6}' and IsNull(a.STK_SPECIAL_IND,'')='{7}' and IsNull(a.STK_SPECIAL_NO,'')='{8}' and a.SKU_UNIT='{9}'
                        group by a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR
                        order by min(b.EXPIRE_DATE),min(b.GR_DATE),a.SKU_QTY desc
                    ", sOUT_NOs, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                        dtLocDtl = new DataTable();
                        WMSDB.funGetDT(sSQL, ref dtLocDtl, dbConnection, dbTransaction);
                        if (dtLocDtl.Rows.Count < 1) continue; //無此儲位Item

                        LogP020("Step2 pass");
                        LogP020(sSQL);

                        //decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_NUMERATOR"]);
                        //decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_DENOMINATOR"]);

                        for (int iLoc = 0; iLoc < dtLocDtl.Rows.Count; iLoc++)
                        {
                            decimal dLocGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_NUMERATOR"]);
                            decimal dLocGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["GTIN_DENOMINATOR"]);
                            string sLocGtinUnit = Convert.ToString(dtLocDtl.Rows[iLoc]["GTIN_UNIT"]).Trim();

                            if (dTotalDemandQty == 0) break; //合併後的Item需求總數已全部分配完成

                            decimal dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_QTY"]);
                            decimal dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]);
                            decimal dLocAvailQty = dLocSkuQty - dLocSkuAloQty; //在储位托盤上可分配的Item總數

                            if (dLocAvailQty <= 0) continue; //因為可能被之前的處理先分配了

                            string sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["EXPIRE_DATE"]).Trim();
                            string sGR_DATE = Convert.ToString(dtLocDtl.Rows[iLoc]["GR_DATE"]).Trim();
                            string sSU_ID = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_ID"]).Trim();
                            string sLOC_NO = Convert.ToString(dtLocDtl.Rows[iLoc]["LOC_NO"]).Trim();
                            string sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_TYPE"]).Trim();
                            string sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                            string sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iLoc]["SU_TYPE"]).Trim();

                            decimal dLocTotalAloQty = 0; //累計储位分配數
                            decimal dLocPickQty = 0; //該儲位分配數

                            if (dTotalDemandQty >= dLocAvailQty) //需求總數>=可分配在储數
                            {
                                dLocPickQty = dLocAvailQty; //該儲位托盤可全部分配
                            }
                            else
                            {
                                //當總需求數<托盤數時，要找下一托盤，
                                //直到剩餘總需求數是=托盤可分配數時，如果是等餘則選取該托盤，如果是大於則選擇前一筆托盤

                                bool bSelect = false;
                                int iSelect = 0;
                                int j = iLoc; //當前LocDtl Index
                                while (true)
                                {
                                    j++; //下一筆
                                    if (j >= dtLocDtl.Rows.Count) break; //超出LocDtl row index

                                    decimal dLocQty = 0;

                                    if (sGR_DATE != Convert.ToString(dtLocDtl.Rows[j]["GR_DATE"]))
                                    {
                                        //遇到下一個FIFO則往回選大於需求的
                                        while (true)
                                        {
                                            j--;

                                            if (j < iLoc) //回到當前locdtl row index
                                            {
                                                bSelect = true;
                                                iSelect = iLoc;
                                                break;
                                            }

                                            dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                            if (dLocQty >= dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //相同的FIFO,直到儲位數量<=需求數則選前一個儲位數量>需求數的托盤
                                        dLocQty = Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_QTY"]) - Convert.ToDecimal(dtLocDtl.Rows[j]["SKU_ALO_QTY"]);
                                        if (dLocQty <= dTotalDemandQty)
                                        {
                                            if (dLocQty == dTotalDemandQty)
                                            {
                                                bSelect = true;
                                                iSelect = j;
                                            }
                                            else
                                            {
                                                bSelect = true;
                                                iSelect = j - 1;
                                            }
                                        }
                                    }

                                    if (bSelect) break;
                                }

                                if (bSelect)
                                {
                                    //可能托盤改變所以要重新賦值
                                    dLocSkuQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_QTY"]);
                                    dLocSkuAloQty = Convert.ToDecimal(dtLocDtl.Rows[iSelect]["SKU_ALO_QTY"]);
                                    dLocAvailQty = dLocSkuQty - dLocSkuAloQty;

                                    sEXPIRE_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["EXPIRE_DATE"]);
                                    sGR_DATE = Convert.ToString(dtLocDtl.Rows[iSelect]["GR_DATE"]);
                                    sSU_ID = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_ID"]);
                                    sLOC_NO = Convert.ToString(dtLocDtl.Rows[iSelect]["LOC_NO"]);
                                    sSTGE_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["STGE_TYPE"]).Trim();
                                    sSTGE_BIN = Convert.ToString(dtLocDtl.Rows[iLoc]["STGE_BIN"]).Trim();
                                    sSU_TYPE = Convert.ToString(dtLocDtl.Rows[iSelect]["SU_TYPE"]).Trim();
                                }

                                dLocPickQty = dTotalDemandQty; //該儲位托盤部分分配
                            }

                            //合併的Delivery order明細
                            sSQL = string.Format(@"
                            select *,(SKU_OUT_QTY - SKU_ALO_QTY) as SKU_CMD_QTY 
                            from OUT_DTL
                            where OUT_NO in ({0}) and OUT_STS in ('0','1') and SKU_OUT_QTY > SKU_ALO_QTY
                                and WHSE_NO='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            order by (SKU_OUT_QTY - SKU_ALO_QTY) desc
                        ", sOUT_NOs, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            dtOutDtl = new DataTable();
                            WMSDB.funGetDT(sSQL, ref dtOutDtl, dbConnection, dbTransaction);
                            if (dtOutDtl.Rows.Count < 1) continue; //無此Delivery Item

                            LogP020("Step3 pass");
                            LogP020(sSQL);


                            //分配到各OUT_DTL
                            decimal dOutGtinNumerator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_NUMERATOR"]);
                            decimal dOutGtinDenominator = Convert.ToDecimal(dtLocDtl.Rows[0]["GTIN_DENOMINATOR"]);
                            for (int iOut = 0; iOut < dtOutDtl.Rows.Count; iOut++)
                            {
                                decimal dOutCmdQty = Convert.ToDecimal(dtOutDtl.Rows[iOut]["SKU_CMD_QTY"]); //delivery item demand qty
                                string sOUT_NO = Convert.ToString(dtOutDtl.Rows[iOut]["OUT_NO"]);
                                string sOUT_LINE = Convert.ToString(dtOutDtl.Rows[iOut]["OUT_LINE"]);
                                dOutGtinNumerator = Convert.ToDecimal(dtOutDtl.Rows[iOut]["GTIN_NUMERATOR"]);
                                dOutGtinDenominator = Convert.ToDecimal(dtOutDtl.Rows[iOut]["GTIN_DENOMINATOR"]);

                                //找已經生成的托盤出庫分揀指令
                                //找已經生成的PCK_MST
                                string sPCK_NO = string.Empty;
                                string sPCK_LINE = "0001";
                                sSQL = string.Format(@"
                                select a.PCK_NO,count(b.PCK_LINE) as CNT 
                                from PCK_MST a join PCK_DTL b
                                on (a.WHSE_NO=b.WHSE_NO and a.PCK_NO=b.PCK_NO)
                                where a.SU_ID='{0}' and a.PCK_STS in ('0','1') and a.PCK_TYPE='P' and a.LOC_NO='{1}'
                                group by a.PCK_NO
                            ", sSU_ID, sLOC_NO);

                                LogP020("Step4 MORE BIZ LOGIC here");
                                LogP020(sSQL);


                                dtPckMst = new DataTable();
                                WMSDB.funGetDT(sSQL, ref dtPckMst, dbConnection, dbTransaction);
                                if (dtPckMst.Rows.Count < 1)
                                {
                                    //創建CMD_MST & PCK_MST
                                    //取得CMD_SNO
                                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");


                                    string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);

                                    if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                                    //預約LOC_MST
                                    sSQL = string.Format(@"
                                    update LOC_MST 
                                    set LOC_STS='O',LOC_OSTS='S',TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20) 
                                    where LOC_NO='{0}' and SU_ID='{1}' and LOC_STS='S'
                                ", sLOC_NO, sSU_ID, DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1) throw new Exception("no data update:" + sSQL);



                                    LogP020("Step5 pass");
                                    LogP020(sSQL);




                                    sPCK_NO = sCMD_DATE + sCMD_SNO;
                                    //生成CMD_MST(如果STGE_TYPE="ATR"是自動倉)
                                    if (sSTGE_BIN == "ASRSA00000" && sLOC_NO.Length == 7)
                                    {
                                        //生成CMD_MST
                                        string sCMD_STS = "0";
                                        string sEQU_NO = "01";
                                        switch (sLOC_NO.Substring(0, 2))
                                        {
                                            case "01":
                                            case "02":
                                                sEQU_NO = "01";
                                                break;
                                            case "03":
                                            case "04":
                                                sEQU_NO = "02";
                                                break;
                                            case "05":
                                            case "06":
                                                sEQU_NO = "03";
                                                break;
                                            case "07":
                                            case "08":
                                                sEQU_NO = "04";
                                                break;
                                            default: throw new Exception("invalid LOC_NO:" + sLOC_NO);
                                        }

                                        string sSTN_NO = "A04";
                                        switch (sEQU_NO)
                                        {
                                            case "01":
                                                sSTN_NO = "A04";
                                                break;
                                            case "02":
                                                sSTN_NO = "A10";
                                                break;
                                            case "03":
                                                sSTN_NO = "A16";
                                                break;
                                            case "04":
                                                sSTN_NO = "A22";
                                                break;
                                            default: throw new Exception("invalid EQU_NO:" + sEQU_NO);
                                        }

                                        string sPRTY = "5";
                                        string sCMD_MODE = "2";
                                        string sIO_TYPE = "21";
                                        string sTRACE = "00";

                                        sSQL = string.Format(@"
                                        insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                                    ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, sOUT_NO, sOUT_LINE, sPCK_NO, "P", DhUsername);
                                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                        if (iResult < 1)
                                        {
                                            return (false, "no execute data:" + sSQL);
                                        }


                                        LogP020("Step6 pass");
                                        LogP020(sSQL);

                                    }

                                    //生成PCK_MST
                                    sSQL = string.Format(@"
                                    insert into PCK_MST(WHSE_NO,PCK_NO,PCK_TYPE,STGE_BIN,STGE_TYPE,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',N'{12}',convert(varchar(19),getdate(),20),N'{12}',convert(varchar(19),getdate(),20))
                                ", sWHSE_NO, sPCK_NO, "P", sSTGE_TYPE, sSTGE_BIN, sSU_ID, sSU_TYPE, sLOC_NO, sCMD_DATE, sCMD_SNO, "0", "Y", DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1)
                                    {
                                        return (false, "no execute data:" + sSQL);
                                    }


                                    LogP020("Step7 pass");
                                    LogP020(sSQL);


                                }
                                else
                                {
                                    sPCK_NO = Convert.ToString(dtPckMst.Rows[0]["PCK_NO"]).Trim();
                                    sPCK_LINE = (int.Parse(Convert.ToString(dtPckMst.Rows[0]["CNT"])) + 1).ToString("0000");
                                }

                                decimal dPickQty = dLocPickQty;
                                if (dLocPickQty >= dOutCmdQty) dPickQty = dOutCmdQty; //如果托盤储位可分配數>Delivery Item需求數
                                dLocPickQty = dLocPickQty - dPickQty; //該托盤餘數
                                dLocTotalAloQty = dLocTotalAloQty + dPickQty; //該托盤累計分配餘數

                                //計算PickGtinAloQty

                                decimal dPickGtinAloQty = dPickQty * dLocGtinDenominator / dLocGtinNumerator; //換算為GTIN_ALO_QTY


                                //產生PCK_DTL
                                sSQL = string.Format(@"
                                insert into PCK_DTL(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_STS,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}',N'{23}',convert(varchar(19),getdate(),20),N'{23}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dPickGtinAloQty, 0, sSKU_UNIT, dPickQty, 0, "0", "Y", DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1)
                                {
                                    return (false, "no execute data:" + sSQL);
                                }

                                LogP020("Step8 pass");
                                LogP020(sSQL);


                                //現在不能產生PCK_SNO，必須在出庫命令完成時刪除PLT_DTL及產生PCK_SNO
                                sSQL = string.Format(@"
                                select IN_SNO,IN_NO,IN_LINE,SKU_QTY,IsNull(SKU_ALO_QTY,0) as SKU_ALO_QTY
                                from PLT_DTL 
                                where SKU_QTY > IsNull(SKU_ALO_QTY,0) and SU_ID='{0}' and WHSE_NO= '{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}' 
                                order by EXPIRE_DATE,GR_DATE
                            ", sSU_ID, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                                dtPltDtl = new DataTable();
                                WMSDB.funGetDT(sSQL, ref dtPltDtl, dbConnection, dbTransaction);
                                if (iResult < 1)
                                {
                                    return (false, "no pallet item data:" + sSQL);
                                }


                                LogP020("Step9 pass");
                                LogP020(sSQL);

                                decimal dSnoPickQty = dPickQty;
                                decimal dSnoTrnQty = 0;
                                for (int iSno = 0; iSno < dtPltDtl.Rows.Count; iSno++)
                                {
                                    if (dSnoPickQty <= 0) break;

                                    string sIN_SNO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_SNO"]);
                                    string sIN_NO = Convert.ToString(dtPltDtl.Rows[iSno]["IN_NO"]);
                                    string sIN_LINE = Convert.ToString(dtPltDtl.Rows[iSno]["IN_LINE"]);
                                    decimal dSnoSkuQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_QTY"]);
                                    decimal dSnoSkuAloQty = Convert.ToDecimal(dtPltDtl.Rows[iSno]["SKU_ALO_QTY"]);
                                    if (dSnoPickQty >= (dSnoSkuQty - dSnoSkuAloQty))
                                    {
                                        dSnoTrnQty = (dSnoSkuQty - dSnoSkuAloQty);
                                    }
                                    else
                                    {
                                        dSnoTrnQty = dSnoPickQty;
                                    }

                                    //生成PCK_SNO
                                    decimal dGtinSnoTrnQty = dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator;
                                    sSQL = string.Format(@"
                                        insert into PCK_SNO(WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,IN_SNO,IN_NO,IN_LINE,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}',{19},{20},'{21}','{22}','{23}',N'{24}',convert(varchar(19),getdate(),20),N'{24}',convert(varchar(19),getdate(),20))
                                        ", sWHSE_NO, sPCK_NO, sPCK_LINE, sSU_ID, sSU_TYPE, sLOC_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sOUT_NO, sOUT_LINE, sLocGtinUnit, dGtinSnoTrnQty, 0, sSKU_UNIT, dSnoTrnQty, 0, sIN_SNO, sIN_NO, sIN_LINE, DhUsername);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1)
                                    {
                                        return (false, "no data create:" + sSQL);
                                    }

                                    LogP020("Step10 pass");
                                    LogP020(sSQL);



                                    //備份PLT_DTL
                                    sSQL = string.Format(@"
                                    insert into PLT_DTL_HIS 
                                    select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from PLT_DTL 
                                    where WHSE_NO='{1}' and SU_ID='{2}' and IN_SNO='{3}' and IN_NO='{4}' and IN_LINE='{5}'
                                ", DhUsername, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1)
                                    {
                                        return (false, "no data create:" + sSQL);
                                    }

                                    LogP020("Step11 pass");
                                    LogP020(sSQL);


                                    //更新PLT_DTL
                                    decimal dSnoGtinAloQty = Decimal.Round(dSnoTrnQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                                    sSQL = string.Format(@"
                                    update PLT_DTL set GTIN_ALO_QTY=IsNull(GTIN_ALO_QTY,0)+{0},SKU_ALO_QTY=IsNull(SKU_ALO_QTY,0)+{1}
                                    where WHSE_NO='{2}' and SU_ID='{3}' and IN_SNO='{4}' and IN_NO='{5}' and IN_LINE='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}'
                                ", dSnoGtinAloQty, dSnoTrnQty, sWHSE_NO, sSU_ID, sIN_SNO, sIN_NO, sIN_LINE, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO);
                                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                    if (iResult < 1)
                                    {
                                        return (false, "no data create:" + sSQL);
                                    }

                                    LogP020("Step12 pass");
                                    LogP020(sSQL);



                                    dSnoPickQty = dSnoPickQty - dSnoTrnQty;
                                }

                                dTotalDemandQty = dTotalDemandQty - dPickQty;

                                //備份OUT_DTL
                                sSQL = string.Format(@"
                                insert into OUT_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{0}' as LOG_USER from OUT_DTL 
                                where WHSE_NO='{1}' and OUT_NO='{2}' and OUT_LINE='{3}'
                                ", DhUsername, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1) throw new Exception("no data update:" + sSQL);


                                LogP020("Step13 pass");
                                LogP020(sSQL);




                                //更新OUT_DTL.GTIN_ALO_QTY & SKU_ALO_QTY
                                decimal dGtinAloQty = Decimal.Round(dPickQty * dOutGtinDenominator / dOutGtinNumerator, 3);
                                sSQL = string.Format(@"
                                update OUT_DTL set OUT_STS='1',GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and OUT_NO='{4}' and OUT_LINE='{5}'
                                ", dGtinAloQty, Decimal.Round(dPickQty, 3), DhUsername, sWHSE_NO, sOUT_NO, sOUT_LINE);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1)
                                {
                                    return (false, "no data create:" + sSQL);
                                }

                                LogP020("Step14 pass");
                                LogP020(sSQL);



                                //備份OUT_MST
                                sSQL = string.Format(@"
                                insert into OUT_MST_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{2}' as LOG_USER from OUT_MST 
                                where WHSE_NO='{0}' and OUT_NO='{1}'
                            ", sWHSE_NO, sOUT_NO, DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1)
                                {
                                    return (false, "no data create:" + sSQL);
                                }


                                LogP020("Step15 pass");
                                LogP020(sSQL);


                                //更新OUT_MST
                                sSQL = string.Format(@"
                                update OUT_MST set OUT_STS=CASE WHEN (select count(*) from OUT_DTL where OUT_STS in ('0','1') and WHSE_NO='{0}' and OUT_NO='{1}') < 1 THEN '9' ELSE '1' END,
                                    TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{0}' and OUT_NO='{1}' and OUT_STS in ('0','1')
                            ", sWHSE_NO, sOUT_NO, DhUsername);
                                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                                if (iResult < 1)
                                {
                                    return (false, "no data create:" + sSQL);
                                }


                                LogP020("Step16 pass");
                                LogP020(sSQL);


                                if (dLocPickQty > 0) continue; //托盤還有餘數，且還有下一個Delivery Item可以分配
                                else break; //托盤已無於數可分配Delivery Item

                            } //OutDtl loop


                            //該托盤已全部分配完或已無Delivery Item可分配
                            //備份LOC_DTL到歷史檔
                            sSQL = string.Format(@"
                                insert into LOC_DTL_HIS 
                                select *,convert(varchar(19),getdate(),20) as LOG_DATE,N'{10}' as LOG_USER from LOC_DTL 
                                where WHSE_NO='{0}' and SU_ID='{1}' and PLANT='{2}' and STGE_LOC='{3}' and SKU_NO='{4}' and IsNull(BATCH_NO,'')='{5}' and IsNull(STK_CAT,'')='{6}' and IsNull(STK_SPECIAL_IND,'')='{7}' and IsNull(STK_SPECIAL_NO,'')='{8}' and SKU_UNIT='{9}'
                            ", sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT, DhUsername);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1)
                            {
                                return (false, "no data create:" + sSQL);
                            }


                            LogP020("Step17 pass");
                            LogP020(sSQL);


                            //更新LOC_DTL
                            decimal dLocTotalGtinAloQty = Decimal.Round(dLocTotalAloQty * dLocGtinDenominator / dLocGtinNumerator, 3);
                            sSQL = string.Format(@"
                                update LOC_DTL 
                                set GTIN_ALO_QTY=GTIN_ALO_QTY+{0},SKU_ALO_QTY=SKU_ALO_QTY+{1},TRN_USER=N'{2}',TRN_DATE=convert(varchar(19),getdate(),20)
                                where WHSE_NO='{3}' and SU_ID='{4}' and PLANT='{5}' and STGE_LOC='{6}' and SKU_NO='{7}' and IsNull(BATCH_NO,'')='{8}' and IsNull(STK_CAT,'')='{9}' and IsNull(STK_SPECIAL_IND,'')='{10}' and IsNull(STK_SPECIAL_NO,'')='{11}' and SKU_UNIT='{12}'
                            ", dLocTotalGtinAloQty, dLocTotalAloQty.ToString(), DhUsername, sWHSE_NO, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sSKU_UNIT);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);



                            //LogP020("***************" + sSQL);

                            if (iResult < 1)
                            {
                                return (false, "no data create:" + sSQL);
                            }


                            LogP020("Step18 pass");
                            LogP020(sSQL);



                            dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"] = Decimal.Round(Convert.ToDecimal(dtLocDtl.Rows[iLoc]["SKU_ALO_QTY"]) + dLocTotalAloQty, 3);

                            if (dTotalDemandQty <= 0) break; //合併後的總需求數>0,找下一個托盤

                        } //LocDtl loop
                    } //MergeOutDtl loop

                    dbTransaction.Commit();

                    LogP020("=== end success ===");
                    LogP020(sSQL);

                    return (true, "after Commit");

                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();

                    LogP020("=== end by Rollback ===");
                    LogP020(sSQL);

                    return (false, "after rollback" + ex.Message);
                }

                //MessageBox.Show("Confirm success");
            }
            catch (Exception ex)
            {
                //    return (false, "after rollback" + ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dtMergeOutDtl != null) { dtMergeOutDtl.Dispose(); dtMergeOutDtl = null; }
                if (dtOutDtl != null) { dtOutDtl.Dispose(); dtOutDtl = null; }
                if (dtLocDtl != null) { dtLocDtl.Dispose(); dtLocDtl = null; }
                if (dtPckMst != null) { dtPckMst.Dispose(); dtPckMst = null; }
                if (dtPltDtl != null) { dtPltDtl.Dispose(); dtPltDtl = null; }
            }

            LogP020("=== after finally ===");


            return (false, "after finally");
        }





        //if (tbOUT_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.OUT_NO like '%{0}%'", tbOUT_NO.Text.Trim().ToUpper());
        // if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
        // if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.REQM_NO like '%{0}%'", tbREQM_NO.Text.Trim().ToUpper());
        // if (tbCAR_LIC.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.CAR_LIC like '%{0}%'", tbCAR_LIC.Text.Trim().ToUpper());
        // if (tbSHIP_TO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SHIP_TO like '%{0}%'", tbSHIP_TO.Text.Trim().ToUpper());
        // if (tbSHIP_TO_NAME.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SHIP_TO_NAME like '%{0}%'", tbSHIP_TO_NAME.Text.Trim().ToUpper());
        // if (tbCREATEUSER.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.CREATEUSER like '%{0}%'", tbCREATEUSER.Text.Trim().ToUpper());
        // if (tbWHSE_DOOR.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.WHSE_DOOR like '%{0}%'", tbWHSE_DOOR.Text.Trim().ToUpper());
        public string GetP030SQL()
        {
            string strSQL = $@"

                select b.WHSE_NO,b.OUT_NO,b.OUT_LINE,b.PLANT,b.STGE_LOC,b.SKU_NO,b.BATCH_NO,b.STK_CAT,b.STK_SPECIAL_IND,b.STK_SPECIAL_NO,b.GTIN_UNIT,b.GTIN_OUT_QTY,b.GTIN_ALO_QTY,b.SKU_UNIT,b.SKU_OUT_QTY,b.SKU_ALO_QTY,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.GTIN_DESC,b.GTIN_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.REQM_NO,b.REQM_LINE,b.DOC_NO,b.DOC_LINE,b.MOVM_TYPE,b.SKU_GROUP,b.TP_GROUP,b.DD_LINE,b.CREATEUSER,b.CREATEDATE,b.CREATETIME,IsNull(sum(c.SKU_QTY-c.SKU_ALO_QTY),0) as SKU_AVAIL_QTY
                from OUT_MST a join OUT_DTL b on (a.OUT_NO=b.OUT_NO) 
                left join LOC_DTL c on (b.WHSE_NO=c.WHSE_NO and b.PLANT=c.PLANT and b.STGE_LOC=c.STGE_LOC and b.SKU_NO=c.SKU_NO and IsNull(b.BATCH_NO,'')=IsNull(c.BATCH_NO,'') and IsNull(b.STK_CAT,'')=IsNull(c.STK_CAT,'') and IsNull(b.STK_SPECIAL_IND,'')=IsNull(c.STK_SPECIAL_IND,'') and IsNull(b.STK_SPECIAL_NO,'')=IsNull(c.STK_SPECIAL_NO,'') and b.SKU_UNIT=c.SKU_UNIT)
                where a.SHIP_CONDITION not in ('20','90') and b.SKU_OUT_QTY > b.SKU_ALO_QTY

				group by b.WHSE_NO,b.OUT_NO,b.OUT_LINE,b.PLANT,b.STGE_LOC,b.SKU_NO,b.BATCH_NO,b.STK_CAT,b.STK_SPECIAL_IND,b.STK_SPECIAL_NO,b.GTIN_UNIT,b.GTIN_OUT_QTY,b.GTIN_ALO_QTY,b.SKU_UNIT,b.SKU_OUT_QTY,b.SKU_ALO_QTY,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.GTIN_DESC,b.GTIN_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.REQM_NO,b.REQM_LINE,b.DOC_NO,b.DOC_LINE,b.MOVM_TYPE,b.SKU_GROUP,b.TP_GROUP,b.DD_LINE,b.CREATEUSER,b.CREATEDATE,b.CREATETIME
     
                ";
            return strSQL;
            //order by b.SKU_NO,b.SKU_OUT_QTY desc

        }



        public bool QueryTable(string conn, ref DataTable dtTable, string sSQL)
        {
            // STEP 2. WMSDB
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);


            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            DataTable dataTable = new DataTable(dtTable.TableName);

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);

                dtTable = dataTable.Copy();
                dtTable.TableName = dtTable.TableName;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dataTable != null) { dataTable.Dispose(); dataTable = null; }
            }
            return true;
        }

    }

}