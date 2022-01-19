using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using CaotunSpring.DH.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class P030CoreComponent
    {
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.Vp030 args)
        {
            // 原有考慮傳一個 Vc010, 但由於還要多語翻譯, 因此先把翻譯好的欄位名和其值傳到 DialogViewC010
            await DialogService.OpenAsync<DialogViewVp030>($"OUT_MST**",
                       new Dictionary<string, object>() { {"h1", $"{ Lang("WHSE_NO")}"},{ "v1", $"{args.WHSE_NO}"},{"h2", $"{ Lang("OUT_NO")}"},{ "v2", $"{args.OUT_NO}"},{"h3", $"{ Lang("OUT_LINE")}"},{ "v3", $"{args.OUT_LINE}"},{"h4", $"{ Lang("PLANT")}"},{ "v4", $"{args.PLANT}"},{"h5", $"{ Lang("STGE_LOC")}"},{ "v5", $"{args.STGE_LOC}"},{"h6", $"{ Lang("SKU_NO")}"},{ "v6", $"{args.SKU_NO}"},{"h7", $"{ Lang("BATCH_NO")}"},{ "v7", $"{args.BATCH_NO}"},{"h8", $"{ Lang("STK_CAT")}"},{ "v8", $"{args.STK_CAT}"},{"h9", $"{ Lang("STK_SPECIAL_IND")}"},{ "v9", $"{args.STK_SPECIAL_IND}"},{"h10", $"{ Lang("STK_SPECIAL_NO")}"},{ "v10", $"{args.STK_SPECIAL_NO}"},{"h11", $"{ Lang("GTIN_UNIT")}"},{ "v11", $"{args.GTIN_UNIT}"},{"h12", $"{ Lang("GTIN_OUT_QTY")}"},{ "v12", $"{args.GTIN_OUT_QTY}"},{"h13", $"{ Lang("GTIN_ALO_QTY")}"},{ "v13", $"{args.GTIN_ALO_QTY}"},{"h14", $"{ Lang("SKU_UNIT")}"},{ "v14", $"{args.SKU_UNIT}"},{"h15", $"{ Lang("SKU_OUT_QTY")}"},{ "v15", $"{args.SKU_OUT_QTY}"},{"h16", $"{ Lang("SKU_ALO_QTY")}"},{ "v16", $"{args.SKU_ALO_QTY}"},{"h17", $"{ Lang("GROSS_WEIGHT")}"},{ "v17", $"{args.GROSS_WEIGHT}"},{"h18", $"{ Lang("NET_WEIGHT")}"},{ "v18", $"{args.NET_WEIGHT}"},{"h19", $"{ Lang("WEIGHT_UNIT")}"},{ "v19", $"{args.WEIGHT_UNIT}"},{"h20", $"{ Lang("VOLUME")}"},{ "v20", $"{args.VOLUME}"},{"h21", $"{ Lang("VOLUME_UNIT")}"},{ "v21", $"{args.VOLUME_UNIT}"},{"h22", $"{ Lang("GTIN_DESC")}"},{ "v22", $"{args.GTIN_DESC}"},{"h23", $"{ Lang("GTIN_NO")}"},{ "v23", $"{args.GTIN_NO}"},{"h24", $"{ Lang("GTIN_NUMERATOR")}"},{ "v24", $"{args.GTIN_NUMERATOR}"},{"h25", $"{ Lang("GTIN_DENOMINATOR")}"},{ "v25", $"{args.GTIN_DENOMINATOR}"},{"h26", $"{ Lang("REQM_NO")}"},{ "v26", $"{args.REQM_NO}"},{"h27", $"{ Lang("REQM_LINE")}"},{ "v27", $"{args.REQM_LINE}"},{"h28", $"{ Lang("DOC_NO")}"},{ "v28", $"{args.DOC_NO}"},{"h29", $"{ Lang("DOC_LINE")}"},{ "v29", $"{args.DOC_LINE}"},{"h30", $"{ Lang("MOVM_TYPE")}"},{ "v30", $"{args.MOVM_TYPE}"},{"h31", $"{ Lang("SKU_GROUP")}"},{ "v31", $"{args.SKU_GROUP}"},{"h32", $"{ Lang("TP_GROUP")}"},{ "v32", $"{args.TP_GROUP}"},{"h33", $"{ Lang("DD_LINE")}"},{ "v33", $"{args.DD_LINE}"},{"h34", $"{ Lang("CREATEUSER")}"},{ "v34", $"{args.CREATEUSER}"},{"h35", $"{ Lang("CREATEDATE")}"},{ "v35", $"{args.CREATEDATE}"},{"h36", $"{ Lang("CREATETIME")}"},{ "v36", $"{args.CREATETIME}"},{"h37", $"{ Lang("SKU_AVAIL_QTY")}"},{ "v37", $"{args.SKU_AVAIL_QTY}"}},
                       new DialogOptions() { });
        }
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.Vp030Sub args)
        {
            // 原有考慮傳一個 Vc010, 但由於還要多語翻譯, 因此先把翻譯好的欄位名和其值傳到 DialogViewC010
            await DialogService.OpenAsync<DialogViewVp030Sub>($"LOC_DTL**",
                       new Dictionary<string, object>() { { "h1", $"{ Lang("STGE_TYPE")}" }, { "v1", $"{args.STGE_TYPE}" }, { "h2", $"{ Lang("STGE_BIN")}" }, { "v2", $"{args.STGE_BIN}" }, { "h3", $"{ Lang("SU_ID")}" }, { "v3", $"{args.SU_ID}" }, { "h4", $"{ Lang("LOC_NO")}" }, { "v4", $"{args.LOC_NO}" }, { "h5", $"{ Lang("WHSE_NO")}" }, { "v5", $"{args.WHSE_NO}" }, { "h6", $"{ Lang("PLANT")}" }, { "v6", $"{args.PLANT}" }, { "h7", $"{ Lang("STGE_LOC")}" }, { "v7", $"{args.STGE_LOC}" }, { "h8", $"{ Lang("SKU_NO")}" }, { "v8", $"{args.SKU_NO}" }, { "h9", $"{ Lang("BATCH_NO")}" }, { "v9", $"{args.BATCH_NO}" }, { "h10", $"{ Lang("STK_CAT")}" }, { "v10", $"{args.STK_CAT}" }, { "h11", $"{ Lang("STK_SPECIAL_IND")}" }, { "v11", $"{args.STK_SPECIAL_IND}" }, { "h12", $"{ Lang("STK_SPECIAL_NO")}" }, { "v12", $"{args.STK_SPECIAL_NO}" }, { "h13", $"{ Lang("SKU_UNIT")}" }, { "v13", $"{args.SKU_UNIT}" }, { "h14", $"{ Lang("SKU_QTY")}" }, { "v14", $"{args.SKU_QTY}" }, { "h15", $"{ Lang("SKU_ALO_QTY")}" }, { "v15", $"{args.SKU_ALO_QTY}" }, { "h16", $"{ Lang("EXPIRE_DATE")}" }, { "v16", $"{args.EXPIRE_DATE}" }, { "h17", $"{ Lang("GR_DATE")}" }, { "v17", $"{args.GR_DATE}" } },
                       new DialogOptions() { });
        }

        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMst();
        }


        private async Task QueryMst()
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

            DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
            GetVp030sResult = await AppDb.Vp030s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

            //SelectedOutDtl = null;
            //SelectedVp030 = null;

            if (GetVp030sResult.Count() > 0)
            {
                ObjTab0Selected = GetVp030sResult.First();
                await ReloadTab1();
            }
            else
            {
                GetVp030SubsResult = null;
            }
            await InvokeAsync(() => { StateHasChanged(); });

        }

        protected async System.Threading.Tasks.Task ReloadTab1()
        {

            //var args = ((Vp030)ObjTab0Selected);

            GetVp030SubsResult = await AppDb.Vp030Subs.FromSqlRaw(GetSQLSub()).AsNoTracking().ToListAsync();

            if (GetVp030SubsResult.Count() > 0)
            {
                ObjTab1Selected = GetVp030SubsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }
        }
        protected async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        {
            await Execute();




        }
        //DataTable dtMST = new DataTable("OUT_DTL"); //交貨單明細檔
        //DataTable dtDTL = new DataTable("LOC_DTL"); //可分配庫存明細檔
        string dtMST = "OUT_DTL"; //交貨單明細檔        V_P030
        string dtDTL = "LOC_DTL"; //可分配庫存明細檔    V_P030SUB 

        public IEnumerable<Models.Mark10Sqlexpress04.Vp030> GetVp030sResult { get; set; }
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp030Sub> GetVp030SubsResult { get; set; }
        //public Models.Mark10Sqlexpress04.Vp030 SelectedVp030 { get; set; }
        //public Models.Mark10Sqlexpress04.LocDtl SelectedLocDtl { get; set; }


        // public object ObjSelectedVp030 { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P030";
            await base.OnInitializedAsync();
        }

        public async Task Execute()
        {
            try
            {


                //LINE#265 of P030.cs
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                //if (tabTR.SelectedIndex == 0)
                if (selectedTabIndex == 0)// tab0
                {
                    // ******* MAYBE BUG, by Mark 05/08 ******* 
                    // 如果 sub grid 裡的筆數 < 0 的話, throw Exception
                    // 是不是應該為 < 1 才是原構想?
                    //if (m_dgvExDtl.RowCount < 0) throw new Exception("no data to execute");
                    //if (getVp030SubsResult.Count() < 1) throw new Exception("(P030) no data to execute");
                    if (GetVp030SubsResult.Count() < 0) throw new Exception("no data to execute");

                    // ******* MAYBE THIS WAY ******* 
                    //if (getVp030SubsResult.Count() < 1) throw new Exception("no data to execute");
                    // ***********************************************************************************

                    // NOTE by Mark, 05/08
                    // 一下子, 這裡無法驗証是否能多選
                    // 業務設計上, 應該是只有單選
                    // 但這段程序是以多選來進行
                    // 為了包持相容, 應   以list來處理  --- for this case, to be specific
                    // 再確認了P020 sub tab,只允許單選
                    // UI 仍以單選做限制 

                    //DataGridViewRow[] dgvRows = new DataGridViewRow[m_dgvExMst.SelectedRows.Count];
                    //m_dgvExMst.SelectedRows.CopyTo(dgvRows, 0);

                    // TODO UserLog
                    //string sRet = Globals.UserLog("08", "P030", this.Text, m_dgvExMst.CurrentRow.Cells["OUT_NO"].Value.ToString() + "/" + m_dgvExMst.CurrentRow.Cells["OUT_LINE"].Value.ToString());
                    //Globals.AllocateDtl("P030", dgvRows);

                    var args = (Vp030)ObjTab0Selected;
                    await DoUserLogAsync("08", PROG_ID, PROG_NAME_FOR_LOG, args.OUT_NO + "/" + args.OUT_LINE);
                    await DhGlobals.MLASRS_AllocateDtl_P030_Async(ConnectionString, DhUsername, "P030", args);
                    //QueryMst();
                    await Task.Delay(1000); // MLASRS 在這裡沒有 LOG PK 報錯。刻意停一秒再 log 即可 
                    await QueryMst();

                    await SimpleDialog("Confirm success");

                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                // ErrMsg = ex.Message;
                //NotificationService.Notify(NotificationSeverity.Info, ErrMsg);
                await SimpleDialog(ex.Message);
            }
        }

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vp030> grid0;



        protected string GetSQL()
        {
            DhGlobals.PurifyFilterValue(ref txtOUT_NO);
            DhGlobals.PurifyFilterValue(ref txtSHIP_TO);
            DhGlobals.PurifyFilterValue(ref txtSHIP_TO_NAME);
            DhGlobals.PurifyFilterValue(ref txtSKU_NO);
            DhGlobals.PurifyFilterValue(ref txtREQM_NO);
            DhGlobals.PurifyFilterValue(ref txtCREATEUSER);
            DhGlobals.PurifyFilterValue(ref txtCAR_LIC);
            DhGlobals.PurifyFilterValue(ref txtWHSE_DOOR);

            // 1. SELECT
            string sSQL = string.Format(@"
                select b.WHSE_NO,b.OUT_NO,b.OUT_LINE,b.PLANT,b.STGE_LOC,b.SKU_NO,b.BATCH_NO,b.STK_CAT,b.STK_SPECIAL_IND,b.STK_SPECIAL_NO,b.GTIN_UNIT,b.GTIN_OUT_QTY,b.GTIN_ALO_QTY,b.SKU_UNIT,b.SKU_OUT_QTY,b.SKU_ALO_QTY,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.GTIN_DESC,b.GTIN_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.REQM_NO,b.REQM_LINE,b.DOC_NO,b.DOC_LINE,b.MOVM_TYPE,b.SKU_GROUP,b.TP_GROUP,b.DD_LINE,b.CREATEUSER,b.CREATEDATE,b.CREATETIME,IsNull(sum(c.SKU_QTY-c.SKU_ALO_QTY),0) as SKU_AVAIL_QTY
                from {0} a join {1} b on (a.OUT_NO=b.OUT_NO) 
                left join LOC_DTL c on (b.WHSE_NO=c.WHSE_NO and b.PLANT=c.PLANT and b.STGE_LOC=c.STGE_LOC and b.SKU_NO=c.SKU_NO and IsNull(b.BATCH_NO,'')=IsNull(c.BATCH_NO,'') and IsNull(b.STK_CAT,'')=IsNull(c.STK_CAT,'') and IsNull(b.STK_SPECIAL_IND,'')=IsNull(c.STK_SPECIAL_IND,'') and IsNull(b.STK_SPECIAL_NO,'')=IsNull(c.STK_SPECIAL_NO,'') and b.SKU_UNIT=c.SKU_UNIT)
                where a.SHIP_CONDITION not in ('20','90') and b.SKU_OUT_QTY > b.SKU_ALO_QTY
            ", "OUT_MST", dtMST);

            // 2. WHERE
            if (txtOUT_NO != "") sSQL = sSQL + string.Format(@" and a.OUT_NO like '%{0}%'", txtOUT_NO);
            if (txtSKU_NO != "") sSQL = sSQL + string.Format(@" and b.SKU_NO like '%{0}%'", txtSKU_NO);
            if (txtREQM_NO != "") sSQL = sSQL + string.Format(@" and b.REQM_NO like '%{0}%'", txtREQM_NO);
            if (txtCAR_LIC != "") sSQL = sSQL + string.Format(@" and a.CAR_LIC like '%{0}%'", txtCAR_LIC);
            if (txtSHIP_TO != "") sSQL = sSQL + string.Format(@" and a.SHIP_TO like '%{0}%'", txtSHIP_TO);
            if (txtSHIP_TO_NAME != "") sSQL = sSQL + string.Format(@" and a.SHIP_TO_NAME like '%{0}%'", txtSHIP_TO_NAME);
            if (txtCREATEUSER != "") sSQL = sSQL + string.Format(@" and a.CREATEUSER like '%{0}%'", txtCREATEUSER);
            if (txtWHSE_DOOR != "") sSQL = sSQL + string.Format(@" and a.WHSE_DOOR like '%{0}%'", txtWHSE_DOOR);



            // GROUP and ORDER
            sSQL += " group by b.WHSE_NO,b.OUT_NO,b.OUT_LINE,b.PLANT,b.STGE_LOC,b.SKU_NO,b.BATCH_NO,b.STK_CAT,b.STK_SPECIAL_IND,b.STK_SPECIAL_NO,b.GTIN_UNIT,b.GTIN_OUT_QTY,b.GTIN_ALO_QTY,b.SKU_UNIT,b.SKU_OUT_QTY,b.SKU_ALO_QTY,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.GTIN_DESC,b.GTIN_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.REQM_NO,b.REQM_LINE,b.DOC_NO,b.DOC_LINE,b.MOVM_TYPE,b.SKU_GROUP,b.TP_GROUP,b.DD_LINE,b.CREATEUSER,b.CREATEDATE,b.CREATETIME";
            sSQL += " order by b.SKU_NO,b.SKU_OUT_QTY desc";

            return sSQL;
        }




        /// <summary>
        /// 所有 GetSQL 都應在本地完成,不帶參數,
        /// 所有參數都取自本地的變量
        /// 
        /// </summary>
        /// <returns></returns>
        string GetSQLSub()
        {
            //var s = SelectedVp030;
            var s = (Vp030)ObjTab0Selected;
            var strSQL = string.Format(@"
                select a.STGE_TYPE, a.STGE_BIN, a.SU_ID, a.LOC_NO, a.WHSE_NO, a.PLANT ,a.STGE_LOC ,a.SKU_NO ,a.BATCH_NO ,a.STK_CAT ,a.STK_SPECIAL_IND ,a.STK_SPECIAL_NO ,a.SKU_UNIT, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE,min(b.GR_DATE) as GR_DATE from {0} a join PLT_DTL b
                on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and a.BATCH_NO=b.BATCH_NO and a.STK_CAT=b.STK_CAT and a.STK_SPECIAL_IND=b.STK_SPECIAL_IND and a.STK_SPECIAL_NO=b.STK_SPECIAL_NO and a.SKU_UNIT=b.SKU_UNIT and a.SU_ID=b.SU_ID)
                where a.WHSE_NO='{1}' and a.PLANT='{2}' and a.STGE_LOC='{3}' and a.SKU_NO='{4}' and IsNull(a.BATCH_NO,'')='{5}' and IsNull(a.STK_CAT,'')='{6}' and IsNull(a.STK_SPECIAL_IND,'')='{7}' and IsNull(a.STK_SPECIAL_NO,'')='{8}' and a.SKU_UNIT='{9}'
                group by a.STGE_TYPE, a.STGE_BIN, a.SU_ID, a.LOC_NO, a.WHSE_NO, a.PLANT ,a.STGE_LOC ,a.SKU_NO ,a.BATCH_NO ,a.STK_CAT ,a.STK_SPECIAL_IND ,a.STK_SPECIAL_NO ,a.SKU_UNIT, a.SKU_QTY, a.SKU_ALO_QTY, b.EXPIRE_DATE, b.GR_DATE
                order by b.EXPIRE_DATE,b.GR_DATE,a.SKU_QTY
            ", dtDTL, s.WHSE_NO, s.PLANT, s.STGE_LOC, s.SKU_NO, s.BATCH_NO, s.STK_CAT, s.STK_SPECIAL_IND, s.STK_SPECIAL_NO, s.SKU_UNIT);


            return strSQL;


        }
        protected async Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.Vp030 args)
        {

            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
