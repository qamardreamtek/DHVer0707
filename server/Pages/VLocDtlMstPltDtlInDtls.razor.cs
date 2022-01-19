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
    public partial class VLocDtlMstPltDtlInDtlsComponent
    {
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl args)
        {
            // KEY" WHSE_NO, SU_ID, PLANT, STEG_LOG,SKU_NO, BATCH_NO,STK_CAT,STK_SPECIAL_IND, STK_SPECIAL_NO, GTIN_UNIT
            //var dialogResult = await DialogService.OpenAsync<ViewLocDtl>("LOC_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "SU_ID", args.SU_ID }, { "PLANT", args.PLANT }, { "STGE_LOC", args.STGE_LOC }, { "SKU_NO", args.SKU_NO }, { "BATCH_NO", args.BATCH_NO }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO }, { "GTIN_UNIT", args.GTIN_UNIT } });
     
        // NO DATA DEBUG    
      //      var dialogResult = await DialogService.OpenAsync<ViewLocDtl>("LOC_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "SU_ID", args.SU_ID }, { "PLANT", args.PLANT }, { "STGE_LOC", args.STGE_LOC }, { "SKU_NO", args.SKU_NO }, { "BATCH_NO", args.BATCH_NO }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
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
        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            getVLocDtlMstPltDtlInDtlsResult = await AppDb.VLocDtlMstPltDtlInDtls.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).ThenBy(a => a.SU_ID).AsNoTracking().ToListAsync();
              await grid0.GoToPage(0);
        }
        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

            await ReloadMainTab();

            ResetGridBindAndSwitchToTab0();


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


        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl> getVLocDtlMstPltDtlInDtlsResult
        {
            get
            {
                return _getVLocDtlMstPltDtlInDtlsResult;
            }
            set
            {
                if (!object.Equals(_getVLocDtlMstPltDtlInDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getVLocDtlMstPltDtlInDtlsResult", NewValue = value, OldValue = _getVLocDtlMstPltDtlInDtlsResult };
                    _getVLocDtlMstPltDtlInDtlsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        //protected override async System.Threading.Tasks.Task OnInitializedAsync()
        //{
        //    await Load();
        //}
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetVLocDtlMstPltDtlInDtlsResult = await Mark10Sqlexpress04.GetVLocDtlMstPltDtlInDtls();
            getVLocDtlMstPltDtlInDtlsResult = mark10Sqlexpress04GetVLocDtlMstPltDtlInDtlsResult;
        }

        //public string PortVal = "2";
        public int value = 2;

        RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl Grid0RowSelected;


        /// <summary>
        /// 执行数据(Transfer Out)
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteOUT()
        {
            //只能整筆變更，不能改數量
            try
            {
                var drRow = Grid0RowSelected;

                string sLOC_NO = Convert.ToString(drRow.LOC_NO);
                string sSU_ID = Convert.ToString(drRow.SU_ID);
                string sEQU_NO = Convert.ToString(drRow.EQU_NO);

                //string sPORT = "2";
                //if (cbPORT.SelectedIndex == 1) sPORT = "4";
                string sPORT = "" + value;//bind with radio

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
        protected new async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        {
            //一次一板
            try
            {

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                if (Grid0RowSelected == null) throw new Exception("no data to execute.");

                if (Grid0RowSelected.STGE_TYPE != "ATR") throw new Exception("can't transfer out the inventory that storage type is not ATR.");
                if (Grid0RowSelected.LOC_STS != "S") throw new Exception("can't transfer out the inventory that have reserved transfer command.");
                if (Grid0RowSelected.GTIN_ALO_QTY > 0) throw new Exception("can't transfer out the inventory that have reserved picking order.");

                //string sRet = Globals.UserLog("08", "P060", this.Text, m_dgvExMst.CurrentRow.Cells["SU_ID"].Value.ToString());
                await DoUserLogAsync("08", "P060", PROG_NAME_FOR_LOG, Grid0RowSelected.SU_ID);

                await ExecuteOUT();

                await ReloadMainTab();

                ResetGridBindAndSwitchToTab0();
                // QueryMst();

            }
            catch (Exception ex)
            {
                // ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
                await SimpleDialog(ex.Message);
            }



        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl args)
        {
            Grid0RowSelected = args;

            getPltDtlsResult = AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID);


            //Dtl
            //if (dtDTL.Rows.Count > 0) dtDTL.Rows.Clear();
            //if (!string.IsNullOrEmpty(sSU_ID))
            //{
            //    //IN_SNO由SAP下傳，如果沒有序列號則只有托盤號，序列號為'X' 
            //    sSQL = string.Format(@"select * from {0} where SU_ID='{1}' order by SKU_NO,GR_DATE,IN_SNO", dtDTL.TableName, sSU_ID);
            //    Globals.QueryTable(ref dtDTL, sSQL);
            //}


        }
    }
}
