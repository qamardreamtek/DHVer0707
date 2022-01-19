using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using CaotunSpring.DH.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RadzenDh5.Pages
{
    public partial class C010CoreComponent
    {
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vc010> grid0;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vc010> getVc010sResult;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult;



        /// <summary>
        /// 由於 C010 tab0 的 grid0 不是標準的 entity, 無法使用標準模板
        /// 這是特例設什出來的 View, 這個反應速度會比標準的 Edit entity 改的 View entity 會快
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.Vc010 args)
        {
            // 原有考慮傳一個 Vc010, 但由於還要多語翻譯, 因此先把翻譯好的欄位名和其值傳到 DialogViewC010
            await DialogService.OpenAsync<DialogViewC010>($"LOC_DTL**",
                       new Dictionary<string, object>() { {"h1", $"{ Lang("WHSE_NO")}"},{ "v1", $"{args.WHSE_NO}"},{"h2", $"{ Lang("STGE_TYPE")}"},{ "v2", $"{args.STGE_TYPE}"},{"h3", $"{ Lang("STGE_BIN")}"},{ "v3", $"{args.STGE_BIN}"},{"h4", $"{ Lang("SU_ID")}"},{ "v4", $"{args.SU_ID}"},{"h5", $"{ Lang("LOC_NO")}"},{ "v5", $"{args.LOC_NO}"},{"h6", $"{ Lang("EQU_NO")}"},{ "v6", $"{args.EQU_NO}"},{"h7", $"{ Lang("PLANT")}"},{ "v7", $"{args.PLANT}"},{"h8", $"{ Lang("STGE_LOC")}"},{ "v8", $"{args.STGE_LOC}"},{"h9", $"{ Lang("SKU_NO")}"},{ "v9", $"{args.SKU_NO}"},{"h10", $"{ Lang("BATCH_NO")}"},{ "v10", $"{args.BATCH_NO}"},{"h11", $"{ Lang("SKU_BATCH")}"},
                           { "v11", $"{args.SKU_BATCH}"},{"h12", $"{ Lang("SKU_SNO_IND")}"},{ "v12", $"{args.SKU_SNO_IND}"},{"h13", $"{ Lang("TRN_DATE")}"},{ "v13", $"{args.TRN_DATE}"},{"h14", $"{ Lang("GTIN_MAX_QTY")}"},{ "v14", $"{args.GTIN_MAX_QTY}"},{"h15", $"{ Lang("COUNT_DATE")}"},{ "v15", $"{args.COUNT_DATE}"},
                           {"h16", $"{ Lang("GTIN_QTY")}"},{ "v16", $"{args.GTIN_QTY}"},{"h17", $"{ Lang("SKU_QTY")}"},{ "v17", $"{args.SKU_QTY}"},{"h18", $"{ Lang("LOC_QTY")}"},{ "v18", $"{args.LOC_QTY}"},{"h19", $"{ Lang("GTIN_UNIT")}"},{ "v19", $"{args.GTIN_UNIT}"},{"h20", $"{ Lang("SKU_UNIT")}"},{ "v20", $"{args.SKU_UNIT}"},
                            },
                       new DialogOptions() { });
        }



        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
            //await InvokeAsync(() => { StateHasChanged(); });
        }

        //DataTable dtMST = new DataTable("LOC_DTL"); //庫存明細
        //DataTable dtDTL = new DataTable("PLT_DTL"); //托盤明細
        //readonly string dtMST = "LOC_DTL"; //庫存明細
        //readonly string dtDTL = "PLT_DTL"; //托盤明細







        public int SelectedMode = 1;
        public bool boolBtnExecuteDisable = true;

        public string txtSKU_NO;
        public string txtSU_ID;

        public string valSKU_NO;
        public string valSU_ID;

   
        /// <summary>
        /// 這是目前唯一有多選的 grid, 必需單獨處理
        /// </summary>
        public List<Models.Mark10Sqlexpress04.Vc010> LocDtlSelectedList { get; set; }


        protected async System.Threading.Tasks.Task Grid0RowDeselect(RadzenDh5.Models.Mark10Sqlexpress04.Vc010 args)
        {
            LocDtlSelectedList.Remove(args);
        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.Vc010 args)
        {

            //LocDtlSelected = args;
            // 這是選定要用來 Execute 
            LocDtlSelectedList.Add(args);

            // 這是純粹畫面上對 tab1 的連動

            // Behavior Note by Mark, 06/13
            // MLASRS C010 behavior:
            // 1. Query 後, 如果 tab0 有顯示內容, 以第一筆為選定反白, 連動 tab1。如果沒有, 提示 no data found, 停在 tab0, 如果查看 tab1, 是清空狀態  
            // 2. 在 tab0 多選時, 僅以最後一個選中來連動 tab1 ( *** 直覺是應該在 tab1 顯示 tab0 的所有選中)
            // 3. 在 tab0 不選某個之前已選的 row 時, 並觸發影響 tab1 的內容 ( *** 所以會造成 tab0 看起來沒有選的資料卻在 tab1 顯示)
            getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).AsNoTracking().ToListAsync();
            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();
            }
            Reload();
        }
     
     
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                //這是要記錄 tab0 選中的 row(s)
                LocDtlSelectedList = new List<Models.Mark10Sqlexpress04.Vc010>();

                // 在 grid0 的 data 更新之前, 先調用 FixGrid0GotoPage0Async
                // await FixGrid0GotoPage0Async();
                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getVc010sResult = await AppDb.Vc010s.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).AsNoTracking().ToListAsync();
                getPltDtlsResult = null; // 不管 Query 的結果如何, 任何 tab1 tab2 總是都要先清空
                                         //   await grid0.GoToPage(0);

                // tab0:grid0 如果經過 Query , 含條件, 返回沒有任何 row時
                if (getVc010sResult.Count() < 1)
                {
                    await SimpleDialog(@$"no data found");
                    return;
                }


                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1
                ObjTab0Selected = getVc010sResult.First();
                var args = getVc010sResult.First();

                // 06/21 19:43 預設的選定(注意是允許多選而使用的 List)
                LocDtlSelectedList.Add(args);


                //sSQL = string.Format(@"select * from {0} where SU_ID='{1}' order by SKU_NO,GR_DATE,IN_SNO", dtDTL.TableName, sSU_ID);
                getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).OrderBy(a => a.SKU_NO).ThenBy(a => a.GR_DATE).ThenBy(a => a.IN_SNO).AsNoTracking().ToListAsync();

                if (getPltDtlsResult.Count() > 0)
                {
                    ObjTab1Selected = getPltDtlsResult.First();
                }
                //    await ReloadTab1();

                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {

            await QueryMstAsync();
            return;
            try
            {

                ErrMsg = null;
                //  boolBtnExecuteDisable = true;
                LocDtlSelectedList = new List<Models.Mark10Sqlexpress04.Vc010>();
                // *** 注意 grid0 是允許多選
                //
                getVc010sResult = null; //grid0
                getPltDtlsResult = null;//grid1 
                await InvokeAsync(() => { StateHasChanged(); });
                await SimpleDialog("to ensure new query will be in process");

                await ReloadTab0();
                ResetGridBindAndSwitchToTab0();

                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                // 如果是由用戶透過快速 click Query 所造成的異常,
                // 先用 SimpleDialog("to ensure new query will be in process");
                // 允許放緩
                // 如真有其它異常, 先不予以理會

            }


        }

        //LINE#66 of C010.cs
        //protected async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        //{

        //    boolBtnExecuteDisable = true;

        //    //一次一板
        //    try
        //    {

        //        if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
        //        AuthMsg = "authorization to execute granted";

        //        if (LocDtlSelectedList == null || LocDtlSelectedList.Count < 0) throw new Exception("no data to execute.");


        //        await ExecuteOUTAsync();
        //        //  await SimpleDialog("Create physical inventory count command complete");

        //        //  LocDtlSelectedList = new List<Models.Mark10Sqlexpress04.Vc010>();

        //        //  await QueryMstAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        await SimpleDialog(@$"{ex.Message}");
        //    }
        //}
        protected async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        {

            boolBtnExecuteDisable = true;

            //一次一板
            try
            {

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                if (LocDtlSelectedList == null || LocDtlSelectedList.Count == 0) throw new Exception("no data to execute.");


                await ExecuteOUTAsync();
                //NotificationService.Notify(NotificationSeverity.Success, "Create physical inventory count command complete");
                //await SimpleDialog("Create physical inventory count command complete");

                //LocDtlSelectedList = new List<Models.Mark10Sqlexpress04.Vc010>();

                //await ReloadTab0();
            }
            catch (Exception ex)
            {

                await SimpleDialog(@$"{ex.Message}");
            }
        }
        protected async System.Threading.Tasks.Task ExecuteOUTAsync()
        {
            try
            {
                // Note by Mark, 06/13 15:00, 已改用最大使用 MLASRS 原有代碼

                // Note by Mark, 06/21 19:41, 強制生成的盤點單的排序
                // https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
                // https://github.com/twoutlook/DH5Ver0414_PUBLISH/discussions/143
                var OrderedLocDtlSelectedList = LocDtlSelectedList.OrderBy(a => a.SKU_NO)
                                                                    .ThenBy(a => a.WHSE_NO)
                                                                    .ThenBy(a => a.STGE_TYPE)
                                                                    .ThenBy(a => a.STGE_BIN)
                                                                    .ThenBy(a => a.SU_ID)
                                                                    .ToList();

                await DhGlobals.MLASRS_CreateCountCMD_OUT_Async(ConnectionString, USER_ID,USER_NAME,DEPT_NAME, PROG_ID, OrderedLocDtlSelectedList,  REMOTE_IP);

                //MessageBox.Show("Create physical inventory count command complete");
                await SimpleDialog("Create physical inventory count command complete");

                await QueryMstAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //protected async Task ExecuteOUTAsync()
        //{
        //    try
        //    {
        //        await DhGlobals.MLASRS_CreateCountCMD_OUT_Async(ConnectionString, DhUsername, PROG_ID, LocDtlSelectedList, DhUser, REMOTE_IP);
        //        await SimpleDialog("Create physical inventory count command complete");
        //        await QueryMstAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new Exception(ex.Message);
        //        throw;
        //    }

        //}
        public string GetSQL()
        {

            txtSKU_NO = (txtSKU_NO == null) ? txtSKU_NO = "" : txtSKU_NO.Trim();
            if (SelectedMode == 1) return GetSQL_BySKU(txtSKU_NO);
            if (SelectedMode == 2) return GetSQL_FAST_MOVE();
            if (SelectedMode == 3) return GetSQL_SLOW_MOVE();//3
            if (SelectedMode == 4) return GetSQL_NOT_FULL();//4;
            return "";
        }


        public string GetSQL_BySKU(string SKU_NO = "") //1
        {


            string strSQL = $@"
                    select a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,max(b.COUNT_DATE) as COUNT_DATE,sum(b.GTIN_QTY) as GTIN_QTY,sum(b.SKU_QTY) as SKU_QTY,a.GTIN_QTY as LOC_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    from LOC_DTL a
                    join PLT_DTL b on(a.WHSE_NO= b.WHSE_NO and a.PLANT= b.PLANT and a.STGE_LOC= b.STGE_LOC and a.SKU_NO= b.SKU_NO and IsNull(a.BATCH_NO,'')= IsNull(a.BATCH_NO, '') and IsNull(a.STK_SPECIAL_IND,'')= IsNull(b.STK_SPECIAL_IND, '') and IsNull(a.STK_SPECIAL_NO,'')= IsNull(b.STK_SPECIAL_NO, '') and a.GTIN_UNIT = b.GTIN_UNIT and a.SU_ID = b.SU_ID)
                    join SKU_MST c on(a.SKU_NO= c.SKU_NO)
                    join LOC_MST d on(a.LOC_NO= d.LOC_NO and a.SU_ID= d.SU_ID)
                    join SKU_SUT e on(a.WHSE_NO= e.WHSE_NO and a.SU_TYPE= e.SU_TYPE and a.SKU_NO= e.SKU_NO and a.GTIN_UNIT= e.GTIN_UNIT)
                    where a.STGE_TYPE= 'ATR' and d.LOC_STS = 'S' and a.GTIN_ALO_QTY = 0
                    ";

            if (SKU_NO != "") strSQL += @$" AND a.SKU_NO like '%{SKU_NO}%'";

            strSQL += @$" group by a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,a.GTIN_QTY,a.GTIN_UNIT,a.SKU_UNIT
                          having a.TRN_DATE > max(b.COUNT_DATE)
                          -- order by a.SKU_NO        
                    ";
            return strSQL;
        }
        public string GetSQL_FAST_MOVE()//2
        {
            string strSQL = $@"
                    select a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,max(b.COUNT_DATE) as COUNT_DATE,sum(b.GTIN_QTY) as GTIN_QTY,sum(b.SKU_QTY) as SKU_QTY,a.GTIN_QTY as LOC_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    from LOC_DTL a 
                    join PLT_DTL b on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
                    join SKU_MST c on (a.SKU_NO=c.SKU_NO)
                    join LOC_MST d on (a.LOC_NO=d.LOC_NO and a.SU_ID=d.SU_ID)
                    join SKU_SUT e on (a.WHSE_NO=e.WHSE_NO and a.SU_TYPE=e.SU_TYPE and a.SKU_NO=e.SKU_NO and a.GTIN_UNIT=e.GTIN_UNIT)
                    where a.STGE_TYPE='ATR' and d.LOC_STS='S' and a.GTIN_ALO_QTY=0
                    and a.SKU_NO in (select SKU_NO from OUT_DTL where DATEDIFF(day,TRN_DATE,convert(varchar(19),getdate(),20)) <31 group by SKU_NO having count(*) >20)
                    group by a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,a.GTIN_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    having a.TRN_DATE > max(b.COUNT_DATE)
                    -- order by a.SKU_NO
            ";
            return strSQL;
        }
        public string GetSQL_SLOW_MOVE()//3
        {
            string strSQL = $@"
                    select a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,max(b.COUNT_DATE) as COUNT_DATE,sum(b.GTIN_QTY) as GTIN_QTY,sum(b.SKU_QTY) as SKU_QTY,a.GTIN_QTY as LOC_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    from LOC_DTL a 
                    join PLT_DTL b on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
                    join SKU_MST c on (a.SKU_NO=c.SKU_NO)
                    join LOC_MST d on (a.LOC_NO=d.LOC_NO and a.SU_ID=d.SU_ID)
                    join SKU_SUT e on (a.WHSE_NO=e.WHSE_NO and a.SU_TYPE=e.SU_TYPE and a.SKU_NO=e.SKU_NO and a.GTIN_UNIT=e.GTIN_UNIT)
                    where a.STGE_TYPE='ATR' and d.LOC_STS='S' and a.GTIN_ALO_QTY=0
                    and a.SKU_NO not in (select distinct SKU_NO from OUT_DTL where DATEDIFF(day,TRN_DATE,convert(varchar(19),getdate(),20)) <31)
                    group by a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,a.GTIN_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    having a.TRN_DATE > max(b.COUNT_DATE)
                    -- order by a.SKU_NO
            ";
            return strSQL;
        }
        string GetSQL_NOT_FULL()//4
        {
            string sSQL = @"
                    select a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,max(b.COUNT_DATE) as COUNT_DATE,sum(b.GTIN_QTY) as GTIN_QTY,sum(b.SKU_QTY) as SKU_QTY,a.GTIN_QTY as LOC_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    from LOC_DTL a 
                    join PLT_DTL b on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
                    join SKU_MST c on (a.SKU_NO=c.SKU_NO)
                    join LOC_MST d on (a.LOC_NO=d.LOC_NO and a.SU_ID=d.SU_ID)
                    join SKU_SUT e on (a.WHSE_NO=e.WHSE_NO and a.SU_TYPE=e.SU_TYPE and a.SKU_NO=e.SKU_NO and a.GTIN_UNIT=e.GTIN_UNIT)
                    where a.STGE_TYPE='ATR' and d.LOC_STS='S' and a.GTIN_ALO_QTY=0
                    
                    group by a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,a.GTIN_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    having a.TRN_DATE > max(b.COUNT_DATE) and sum(b.GTIN_QTY) < e.GTIN_MAX_QTY
                    -- order by a.SKU_NO
            ";
            return sSQL;
        }
        protected async System.Threading.Tasks.Task ReloadTab0()
        {
            ObjTab0Selected = null;
            ObjTab1Selected = null;
            getPltDtlsResult = null;

            getVc010sResult = await AppDb.Vc010s.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);

            // tab0:grid0 如果經過 Query , 含條件, 返回沒有任何 row時
            if (getVc010sResult.Count() < 1)
            {
                await SimpleDialog(@$"no data found");
            }
        }

    }
}
