using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Data;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;

namespace RadzenDh5.Pages
{
    public partial class P060CoreComponent
    {
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl args)
        {
            // 原有考慮傳一個 Vc010, 但由於還要多語翻譯, 因此先把翻譯好的欄位名和其值傳到 DialogViewC010
            await DialogService.OpenAsync<DialogViewP060>($"LOC_DTL**",
                       new Dictionary<string, object>() {
                           {"h1", $"{ Lang("WHSE_NO")}"},{ "v1", $"{args.WHSE_NO}"},{"h2", $"{ Lang("STGE_TYPE")}"},{ "v2", $"{args.STGE_TYPE}"},{"h3", $"{ Lang("STGE_BIN")}"},{ "v3", $"{args.STGE_BIN}"},{"h4", $"{ Lang("SU_ID")}"},{ "v4", $"{args.SU_ID}"},{"h5", $"{ Lang("SU_TYPE")}"},{ "v5", $"{args.SU_TYPE}"},{"h6", $"{ Lang("LOC_NO")}"},{ "v6", $"{args.LOC_NO}"},{"h7", $"{ Lang("PLANT")}"},{ "v7", $"{args.PLANT}"},{"h8", $"{ Lang("STGE_LOC")}"},{ "v8", $"{args.STGE_LOC}"},{"h9", $"{ Lang("SKU_NO")}"},{ "v9", $"{args.SKU_NO}"},{"h10", $"{ Lang("BATCH_NO")}"},{ "v10", $"{args.BATCH_NO}"},
                           {"h11", $"{ Lang("STK_CAT")}"},{ "v11", $"{args.STK_CAT}"},{"h12", $"{ Lang("STK_SPECIAL_IND")}"},{ "v12", $"{args.STK_SPECIAL_IND}"},{"h13", $"{ Lang("STK_SPECIAL_NO")}"},{ "v13", $"{args.STK_SPECIAL_NO}"},{"h14", $"{ Lang("GTIN_UNIT")}"},{ "v14", $"{args.GTIN_UNIT}"},{"h15", $"{ Lang("GTIN_QTY")}"},{ "v15", $"{args.GTIN_QTY}"},{"h16", $"{ Lang("SKU_UNIT")}"},{ "v16", $"{args.SKU_UNIT}"},{"h17", $"{ Lang("SKU_QTY")}"},{ "v17", $"{args.SKU_QTY}"},{"h18", $"{ Lang("GTIN_NUMERATOR")}"},{ "v18", $"{args.GTIN_NUMERATOR}"},{"h19", $"{ Lang("GTIN_DENOMINATOR")}"},{ "v19", $"{args.GTIN_DENOMINATOR}"},{"h20", $"{ Lang("GROSS_WEIGHT")}"},{ "v20", $"{args.GROSS_WEIGHT}"},
                           {"h21", $"{ Lang("NET_WEIGHT")}"},{ "v21", $"{args.NET_WEIGHT}"},{"h22", $"{ Lang("WEIGHT_UNIT")}"},{ "v22", $"{args.WEIGHT_UNIT}"},{"h23", $"{ Lang("VOLUME")}"},{ "v23", $"{args.VOLUME}"},{"h24", $"{ Lang("VOLUME_UNIT")}"},{ "v24", $"{args.VOLUME_UNIT}"},{"h25", $"{ Lang("GTIN_ALO_QTY")}"},{ "v25", $"{args.GTIN_ALO_QTY}"},{"h26", $"{ Lang("SKU_ALO_QTY")}"},{ "v26", $"{args.SKU_ALO_QTY}"},{"h27", $"{ Lang("REMARK")}"},{ "v27", $"{args.REMARK}"},{"h28", $"{ Lang("TRN_USER")}"},{ "v28", $"{args.TRN_USER}"},{"h29", $"{ Lang("TRN_DATE")}"},{ "v29", $"{args.TRN_DATE}"},{"h30", $"{ Lang("CRT_USER")}"},{ "v30", $"{args.CRT_USER}"},
                           {"h31", $"{ Lang("CRT_DATE")}"},{ "v31", $"{args.CRT_DATE}"},{"h32", $"{ Lang("EQU_NO")}"},{ "v32", $"{args.EQU_NO}"},{"h33", $"{ Lang("LOC_STS")}"},{ "v33", $"{args.LOC_STS}"},{"h34", $"{ Lang("IN_NO")}"},{ "v34", $"{args.IN_NO}"},{"h35", $"{ Lang("GR_DATE")}"},{ "v35", $"{args.GR_DATE}"},{"h36", $"{ Lang("DATE_CODE")}"},{ "v36", $"{args.DATE_CODE}"},{"h37", $"{ Lang("IN_LINE")}"},{ "v37", $"{args.IN_LINE}"},{"h38", $"{ Lang("INSP_LOT")}"},{ "v38", $"{args.INSP_LOT}"},{"h39", $"{ Lang("GTIN_NO")}"},{ "v39", $"{args.GTIN_NO}"},{"h40", $"{ Lang("REQM_NO")}"},{ "v40", $"{args.REQM_NO}"},
  },
                       new DialogOptions() { });
        }
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }


        public string GetSQL()
        {
            //string sRet = Globals.UserLog("01", "P060", this.Text, "");
            ////Mst
            //if (dtMST.Rows.Count > 0) dtMST.Rows.Clear();
            //string sSQL = string.Format(@"select distinct a.*,d.EQU_NO,d.LOC_STS from {0} a 
            //        join {1} b
            //        on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
            //        join IN_DTL c 
            //        on (b.WHSE_NO=c.WHSE_NO and b.IN_NO=c.IN_NO and b.IN_LINE=c.IN_LINE)
            //        join LOC_MST d
            //        on (a.LOC_NO=d.LOC_NO and a.SU_ID=d.SU_ID)
            //        where a.STGE_TYPE='ATR' and d.LOC_STS='S' and a.GTIN_ALO_QTY=0", dtMST.TableName, dtDTL.TableName);

            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
            //if (tbBATCH_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.BATCH_NO,'') like '%{0}%'", tbBATCH_NO.Text.Trim().ToUpper());
            //if (tbSTK_CAT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.STK_CAT,'') = '{0}'", tbSTK_CAT.Text.Trim().ToUpper());
            //if (tbSTK_SPECIAL_IND.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.STK_SPECIAL_IND,'') = '{0}'", tbSTK_SPECIAL_IND.Text.Trim().ToUpper());
            //if (tbSTK_SPECIAL_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.STK_SPECIAL_NO,'') = '{0}'", tbSTK_SPECIAL_NO.Text.Trim().ToUpper());
            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());

            //if (tbIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.IN_NO like '%{0}%'", tbIN_NO.Text.Trim().ToUpper());
            //if (tbGR_DATE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.GR_DATE like '%{0}%'", tbGR_DATE.Text.Trim().ToUpper());
            //if (tbDATE_CODE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.DATE_CODE like '%{0}%'", tbDATE_CODE.Text.Trim().ToUpper());
            //if (tbEXPIRE_DATE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.EXPIRE_DATE like '%{0}%'", tbEXPIRE_DATE.Text.Trim().ToUpper());

            //if (tbINSP_LOT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and c.INSP_LOT like '%{0}%'", tbINSP_LOT.Text.Trim().ToUpper());
            //if (tbGTIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and c.GTIN_NO like '%{0}%'", tbGTIN_NO.Text.Trim().ToUpper());
            //if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and c.REQM_NO like '%{0}%'", tbREQM_NO.Text.Trim().ToUpper());
            //sSQL = sSQL + " order by a.SKU_NO, a.SU_ID";

            var dtMST = "LOC_DTL"; //庫存明細
            var dtDTL = "PLT_DTL"; //托盤明細
            //string strSQL = string.Format(@"select distinct a.*,d.EQU_NO,d.LOC_STS from {0} a 
            //        join {1} b
            //        on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
            //        join IN_DTL c 
            //        on (b.WHSE_NO=c.WHSE_NO and b.IN_NO=c.IN_NO and b.IN_LINE=c.IN_LINE)
            //        join LOC_MST d
            //        on (a.LOC_NO=d.LOC_NO and a.SU_ID=d.SU_ID)
            //        where a.STGE_TYPE='ATR' and d.LOC_STS='S' and a.GTIN_ALO_QTY=0 ", dtMST, dtDTL);

            //string strSQL = " SELECT * FROM V_LOC_DTL_MST__PLT_DTL__IN_DTL WHERE 1=1 ";
            string strSQL = " SELECT DISTINCT * FROM V_LOC_DTL_MST__PLT_DTL__IN_DTL WHERE 1=1 ";

            strSQL += GetContains("SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("BATCH_NO", ref txtBATCH_NO);
            //     strSQL += GetContains("PORT", ref txtPORT);
            strSQL += GetContains("STK_CAT", ref txtSTK_CAT);
            strSQL += GetContains("SPECIAL_IND", ref txtSPECIAL_IND);
            strSQL += GetContains("SPECIAL_NO", ref txtSPECIAL_NO);
            strSQL += GetContains("EXPIRE_DATE", ref txtEXPIRE_DATE);
            strSQL += GetContains("INSP_LOT", ref txtINSP_LOT);
            strSQL += GetContains("DATE_CODE", ref txtDATE_CODE);
            strSQL += GetContains("IN_NO", ref txtIN_NO);
            strSQL += GetContains("REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("GR_DATE", ref txtGR_DATE);
            strSQL += GetContains("LOC_NO", ref txtLOC_NO);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("GTIN_NO", ref txtGTIN_NO);

            //GoodMsg = strSQL;

            return strSQL;

        }

        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();


        }
    
        private async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getVLocDtlMstPltDtlInDtlsResult = await AppDb.VLocDtlMstPltDtlInDtls.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).ThenBy(a => a.SU_ID).AsNoTracking().ToListAsync();


                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getVLocDtlMstPltDtlInDtlsResult.Count() > 0)
                {
                    ObjTab0Selected = getVLocDtlMstPltDtlInDtlsResult.First();
                    await ReloadTab1();
                }
                else
                {
                    getPltDtlsResult = null;
                }
                await InvokeAsync(() => { StateHasChanged(); });

            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl> grid0;
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P060";
            await base.OnInitializedAsync();
        }

        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult;

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }


        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl> _getVLocDtlMstPltDtlInDtlsResult;


        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl> getVLocDtlMstPltDtlInDtlsResult;


        public int radioValue = 2;

        /// <summary>
        /// 执行数据(Transfer Out)
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteOUTAsync()
        {
            //只能整筆變更，不能改數量
            try
            {
               var drRow = (VLocDtlMstPltDtlInDtl)ObjTab0Selected;


                string sLOC_NO = Convert.ToString(drRow.LOC_NO);
                string sSU_ID = Convert.ToString(drRow.SU_ID);
                string sEQU_NO = Convert.ToString(drRow.EQU_NO);

                //string sPORT = "2";
                //if (cbPORT.SelectedIndex == 1) sPORT = "4";
                string sPORT = "" + radioValue;//bind with radio

                //  Globals.CreateTransferCMD_OUT(sEQU_NO, sLOC_NO, sSU_ID, sPORT);
                await DhGlobals.CreateTransferCMD_OUT(ConnectionString, DhUsername, sEQU_NO, sLOC_NO, sSU_ID, sPORT);

                //MessageBox.Show("Success:SU_ID=" + sSU_ID + ", LOC_NO=" + sLOC_NO);
                await SimpleDialog("Success:SU_ID=" + sSU_ID + ", LOC_NO=" + sLOC_NO);
}
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);

            }
        }

        /// <summary>
        /// 直接取 MLASRS biz logic
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected  async System.Threading.Tasks.Task ButtonExecuteClick()
        {
            //一次一板
            try
            {
                var args = ((VLocDtlMstPltDtlInDtl)ObjTab0Selected);

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                if (args == null) throw new Exception("no data to execute.");

                if (args.STGE_TYPE != "ATR") throw new Exception("can't transfer out the inventory that storage type is not ATR.");
                if (args.LOC_STS != "S") throw new Exception("can't transfer out the inventory that have reserved transfer command.");
                if (args.GTIN_ALO_QTY > 0) throw new Exception("can't transfer out the inventory that have reserved picking order.");

                //string sRet = Globals.UserLog("08", "P060", this.Text, m_dgvExMst.CurrentRow.Cells["SU_ID"].Value.ToString());
                await DoUserLogAsync("08", "P060", PROG_NAME_FOR_LOG, args.SU_ID);

                await ExecuteOUTAsync();

                await QueryMstAsync();


            }
            catch (Exception ex)
            {
                // ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
                await SimpleDialog(ex.Message);
            }



        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async System.Threading.Tasks.Task ReloadTab1()
        {

            var args = ((VLocDtlMstPltDtlInDtl)ObjTab0Selected);
            getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).AsNoTracking().ToListAsync();


            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }
        }
    }
}
