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
using System.Data.Common;
using System.Data;

namespace CaotunSpring.DH.Tools
{



    public partial class DhGlobalsService
    {

        /// <summary>
        /// 這是 S030 S040 共用的
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="DhUsername"></param>
        /// <param name="sWHSE_NO"></param>
        /// <param name="sPIC_NO"></param>
        /// <param name="sPIC_TYPE"></param>
        /// <param name="sAPPROVE"></param>
        /// <returns></returns>
        public async Task MLASRS_CountConfirm_Async(string conn, string DhUsername, string sWHSE_NO, string sPIC_NO, string sPIC_TYPE, string sAPPROVE)
        {
            // STEP 1: function name and parameters
            //         public static void CountConfirm(string sWHSE_NO, string sPIC_NO, string sPIC_TYPE, string sAPPROVE
            //
            // STEP 2: Globals.USER_NAME and WMSDB
            Globals.USER_NAME = DhUsername;
            WMSDB = new WESDB(DB_PROVIDER_TYPE, conn);

            //整單確認
            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            DataTable dtSQL = new DataTable();
            DataTable dtTable = new DataTable();

            string sSQL = string.Empty;

            int iResult = 0;

            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
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
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dtSQL != null) { dtSQL.Dispose(); dtSQL = null; }
                if (dtTable != null) { dtTable.Dispose(); dtTable = null; }
            }
        }





        /// <summary>
        /// 06/13, 重新封裝
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="DhUsername"></param>
        /// <param name="sPROG_ID"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task MLASRS_CreateCountCMD_OUT_Async(string conn, string USER_ID, string USER_NAME, string DEPT_NAME, string sPROG_ID, List<RadzenDh5.Models.Mark10Sqlexpress04.Vc010> items,  string REMOTE_IP)
        {

            // STEP 1: method name and parameter
            //public static void CreateCountCMD_OUT(DataGridViewRow[] drRows)

            // STEP 2: new WESDB with DB_PROVIDER_TYPE
            WMSDB = new WESDB(DB_PROVIDER_TYPE, conn);

            // STEP 3:  Globals.USER_NAME 給定值用 DhUsername
            Globals.USER_NAME = USER_NAME;



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
                    // STEP4 , 直接取第一筆, 也就是 index 為 0 的三個值
                    //string sPLANT = Convert.ToString(drRows[0].Cells["PLANT"].Value);
                    //string sSTGE_LOC = Convert.ToString(drRows[0].Cells["STGE_LOC"].Value);
                    //string sWHSE_NO = Convert.ToString(drRows[0].Cells["WHSE_NO"].Value);

                    string sPLANT = Convert.ToString(items[0].PLANT);
                    string sSTGE_LOC = Convert.ToString(items[0].STGE_LOC);
                    string sWHSE_NO = Convert.ToString(items[0].WHSE_NO);



                    //取得盤點單號yyMMddnnnn
                    string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                    string sPIC_NO = GetCmdSno(ref dbConnection, ref dbTransaction, "PIC", sCMD_DATE, 4);
                    if (sPIC_NO == "") throw new Exception("can't get PIC_NO");

                    sPIC_NO = sCMD_DATE + sPIC_NO;

                    //產生PIC_MST
                    string sPIC_TYPE = "03";
                    string sPIC_GROUP = "3" + sPLANT;
                    sSQL = string.Format(@"
                            insert into PIC_MST(WHSE_NO,PIC_NO,PIC_GROUP,PIC_TYPE,PLANT,STGE_LOC,COUNT_USER,SHELF,CREATEUSER,CREATEDATE,CREATETIME,PIC_STS,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{6}',convert(varchar(10),getdate(),23),convert(varchar(8),getdate(),24),'1','1','N',N'{6}',convert(varchar(19),getdate(),20),N'{6}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPIC_NO, sPIC_GROUP, sPIC_TYPE, sPLANT, sSTGE_LOC, Globals.USER_NAME, "ASRS");
                    iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iResult < 1) throw new Exception("no data update:" + sSQL);

                    int iLine = 0;

                    // STEP5 以帶入的 List 取代 DataGridViewRow
                    //       如果想要再進一步, 可以考慮在調用之前就先轉起 DataGridViewRow

                    //foreach (DataGridViewRow drRow in drRows)
                    //{

                    //    string sLOC_NO = Convert.ToString(drRow.Cells["LOC_NO"].Value);
                    //    string sSU_ID = Convert.ToString(drRow.Cells["SU_ID"].Value);
                    //    string sSKU_NO = Convert.ToString(drRow.Cells["SKU_NO"].Value);
                    //    string sBATCH_NO = Convert.ToString(drRow.Cells["BATCH_NO"].Value);
                    //    string sGTIN_UNIT = Convert.ToString(drRow.Cells["GTIN_UNIT"].Value);
                    //    string sGTIN_QTY = Convert.ToString(drRow.Cells["GTIN_QTY"].Value);
                    //    string sSKU_UNIT = Convert.ToString(drRow.Cells["SKU_UNIT"].Value);
                    //    string sSKU_QTY = Convert.ToString(drRow.Cells["SKU_QTY"].Value);
                    //    string sBATCH_IND = Convert.ToString(drRow.Cells["SKU_BATCH"].Value);
                    //    string sSERIAL_IND = Convert.ToString(drRow.Cells["SKU_SNO_IND"].Value);

                    foreach (var item in items)
                    {
                        // 這部份, 單獨拿到 notepad, 可以做替換後再放進來
                        string sLOC_NO = Convert.ToString(item.LOC_NO);
                        string sSU_ID = Convert.ToString(item.SU_ID);
                        string sSKU_NO = Convert.ToString(item.SKU_NO);
                        string sBATCH_NO = Convert.ToString(item.BATCH_NO);
                        string sGTIN_UNIT = Convert.ToString(item.GTIN_UNIT);
                        string sGTIN_QTY = Convert.ToString(item.GTIN_QTY);
                        string sSKU_UNIT = Convert.ToString(item.SKU_UNIT);
                        string sSKU_QTY = Convert.ToString(item.SKU_QTY);
                        string sBATCH_IND = Convert.ToString(item.SKU_BATCH);
                        string sSERIAL_IND = Convert.ToString(item.SKU_SNO_IND);



                        if (sBATCH_IND == "Y") sBATCH_IND = "X";
                        else sBATCH_IND = "";
                        if (sSERIAL_IND == "Y") sSERIAL_IND = "X";
                        else sSERIAL_IND = "";

                        // STEP 6
                        //string sEQU_NO = Convert.ToString(drRow.Cells["EQU_NO"].Value);
                        string sEQU_NO = Convert.ToString(item.EQU_NO);


                        string sPORT = "4";
                        string sSTGE_TYPE = "ATR";
                        string sSTGE_BIN = "ASRSA00000";

                        //檢查是否已產生CMD_MST
                        bool bCMD = false;
                        dataTable = new DataTable();
                        sSQL = string.Format(@"
                        select * from CMD_MST where CMD_STS in ('0','1') and SU_ID='{0}' and IO_TYPE='31'
                    ", sSU_ID);
                        WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);
                        if (dataTable.Rows.Count > 0) bCMD = true;

                        iLine++;
                        string sPIC_LINE = iLine.ToString("0000");

                        //生成PIC_DTL
                        sSQL = string.Format(@"
                            insert into PIC_DTL(WHSE_NO,PIC_NO,PIC_LINE,STGE_TYPE,STGE_BIN,SU_ID,PLANT,STGE_LOC,SKU_NO,BATCH_NO,COUNT_USER,COUNT_UNIT,COUNT_QTY,WMSLOC_IND,BATCH_IND,SERIAL_IND,PIC_STS,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','1','1','N',N'{10}',convert(varchar(19),getdate(),20),N'{10}',convert(varchar(19),getdate(),20))
                            ", sWHSE_NO, sPIC_NO, iLine.ToString("0000"), sSTGE_TYPE, sSTGE_BIN, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, Globals.USER_NAME, sGTIN_UNIT, "0", "X", sBATCH_IND, sSERIAL_IND);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iResult < 1) throw new Exception("no data update:" + sSQL);

                        //生成PIC_SNO
                        sSQL = string.Format(@"
                            insert into PIC_SNO 
                            select '{0}' as WHSE_NO,'{1}' as PIC_NO,'{2}' as PIC_LINE,'{3}' as STGE_TYPE,'{4}' as STGE_BIN,'{5}' as SU_ID,'{6}' as PLANT,'{7}' as STGE_LOC,'{8}' as SKU_NO,'{9}' as BATCH_NO,IN_SNO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,GTIN_UNIT as COUNT_UNIT,0 as COUNT_QTY,'' as COUNT_USER,'' as COUNT_DATE,'' as APPROVE_USER,'' as APPROVE_DATE,'' as START_DATE,'' as END_DATE,'1' as PIC_STS,'' as REMARK,'1' as SOURCE,'N' as APPROVE_IND,convert(varchar(19),getdate(),20) as TRN_DATE,N'{11}' as TRN_USER,convert(varchar(19),getdate(),20) as CRT_DATE,N'{11}' as CRT_USER,IN_NO,IN_LINE
                            from PLT_DTL
                            where WHSE_NO='{0}' and SU_ID='{5}' and PLANT='{6}' and STGE_LOC='{7}' and SKU_NO='{8}' and BATCH_NO='{9}' and GTIN_UNIT='{10}'
                            ", sWHSE_NO, sPIC_NO, iLine.ToString("0000"), sSTGE_TYPE, sSTGE_BIN, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sGTIN_UNIT, Globals.USER_NAME);
                        iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                        if (!bCMD)
                        {
                            //取得CMD_SNO
                            string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                            if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                            //預約LOC_MST
                            sSQL = string.Format(@"update LOC_MST 
                            set LOC_STS='C',TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}'
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
                            string sCMD_MODE = "3";
                            string sIO_TYPE = "32"; //count pallet out
                            string sTRACE = "00";
                            //string sPROG_ID = "C010";   // STEP 7  帶進來的參數已有這個值, 不必重覆

                            sSQL = string.Format(@"
                            insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{17}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20))
                        ", sCMD_DATE, sCMD_SNO, sCMD_STS, sEQU_NO, sPRTY, sSTN_NO, sCMD_MODE, sIO_TYPE, sLOC_NO, sTRACE, sSU_ID, sPROG_ID, "", "", "", "", Globals.USER_NAME, sPIC_NO);
                            iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                            if (iResult < 1) throw new Exception("no data create:" + sSQL);
                        }

                    }

                    dbTransaction.Commit();

                    // STEP 8 UserLog 
                    //    string sRet = Globals.UserLog("08", "C010", "Physical Inventory Count", sPIC_NO);
                   // await UserLogAsync("08", "C010", "Physical Inventory Count", sPIC_NO, DhUser, REMOTE_IP);
                    await MLASRS_UserLog_Async("08", "C010", "Physical Inventory Count", sPIC_NO, USER_ID,USER_NAME,DEPT_NAME ,REMOTE_IP,conn);

                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();

                    // STEP 8, 改為直接 throw, 可以在 caller 斷點看詳細信息
                    // throw new Exception(ex.Message);
                    throw;
                }

            }
            catch (Exception ex)
            {
                // STEP 9, 改為直接 throw, 可以在 caller 斷點看詳細信息
                // throw new Exception(ex.Message);
                throw;
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dataTable != null) { dataTable.Dispose(); dataTable = null; }
            }
        }

    }



}