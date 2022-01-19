using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
     public partial class P020CoreComponent
    {
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> grid0;

        //DataTable dtMST = new DataTable("OUT_MST"); //交貨單主檔
        //DataTable dtDTL = new DataTable("OUT_DTL"); //交貨單明細檔
        string dtMST = "OUT_MST"; //交貨單主檔
        string dtDTL = "OUT_DTL"; //交貨單明細檔
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> getOutMstsResult { get; set; }
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl> getOutDtlsResult { get; set; }
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
                getOutMstsResult = await AppDb.OutMsts.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getOutMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getOutMstsResult.First();
                    await ReloadTab1();
                }
                else
                {
                    getOutDtlsResult = null;
                }
                await InvokeAsync(() => { StateHasChanged(); });

            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected  async System.Threading.Tasks.Task ButtonExecuteClick()
        {
            //  await Execute();

            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");

                //if (tabTR.SelectedIndex == 0)
                if (selectedTabIndex == 0) // 有按 tab 來決定執行 Note by Mark, 

                {
                    //Allocate by muti delivery order
                    //合併多個DO為一個波次
                    //依據合併後的ITEM總數量挑選托盤
                    //先依托盤先進先出及數量排序
                    //在相同先進先出條件下(同一個先進先出條件下)，要做最少板出
                    //如果需求總數>=可分配總數，則取可分配總數
                    //如果需求總數<可分配總數，則取可分配總數，則排列組合，先找1托可滿足，其次找2托合計可滿足，再其次找3托合計可滿足，以此類推
                    //同一托盤取EXPIRE_DATE,GR_DATE無最小者代表整托的EXPIRE_DATE,GR_DATE

                    //if (m_dgvExMst.RowCount < 0) throw new Exception("no data to execute"); //是指第幾筆, zero base
                    if (getOutMstsResult.Count() < 0) throw new Exception("no data to execute");// *** QUESTION ???


                    //DataGridViewRow[] dgvRows =new DataGridViewRow[m_dgvExMst.SelectedRows.Count];
                    //m_dgvExMst.SelectedRows.CopyTo(dgvRows,0);

                    string sOUT_NOs = string.Empty;

                    // Review NOTE by Mark, 06/06 15:20, MLASRS 只允許單選 
                    //foreach (DataGridViewRow dgvRow in m_dgvExMst.SelectedRows)
                    //{
                    //    sOUT_NOs = sOUT_NOs + "'" + Convert.ToString(dgvRow.Cells["OUT_NO"].Value) + "',";
                    //}
                    //sOUT_NOs = sOUT_NOs.Substring(0, sOUT_NOs.Length - 1);

                    var args = (OutMst)ObjTab0Selected;
                    sOUT_NOs = sOUT_NOs + "'" + Convert.ToString(args.OUT_NO) + "'";

                    //string sRet = Globals.UserLog("08", "P020", this.Text, m_dgvExMst.CurrentRow.Cells["OUT_NO"].Value.ToString());
                    await DoUserLogAsync("08", PROG_ID, PROG_NAME, args.OUT_NO);

                    // Globals.AllocateMst("P020", sOUT_NOs);
                    await DhGlobals.MLASRS_AllocateMst_Async(ConnectionString, DhUsername, "P020", sOUT_NOs);
                    await SimpleDialog("confirm success"); // get it from Globals.AllocateMst("P020", sOUT_NOs);
                    await QueryMstAsync();
                }

                //if (tabTR.SelectedIndex == 1)
                if (selectedTabIndex == 1) // tab1
                {
                    //if (m_dgvExDtl.RowCount < 0) throw new Exception("no data to execute"); // 同 grid0, 這裡是指  tab1 grid1, 如果沒有選 row 要提示
                    if (getOutDtlsResult.Count() <0) throw new Exception("no data to execute"); // *** QUESTION ???


                    //DataGridViewRow[] dgvRows = new DataGridViewRow[m_dgvExDtl.SelectedRows.Count];
                    //m_dgvExDtl.SelectedRows.CopyTo(dgvRows, 0);
                    //由這個 log 間接說明 tab1 也是單選
                    //string sRet = Globals.UserLog("08", "P020", this.Text, m_dgvExDtl.CurrentRow.Cells["OUT_NO"].Value.ToString() + "/" + m_dgvExDtl.CurrentRow.Cells["OUT_LINE"].Value.ToString());

                    var args = (OutDtl)ObjTab1Selected;

                    await DoUserLogAsync("08", PROG_ID, PROG_NAME, args.OUT_NO + "/" + args.OUT_LINE);

                    //  Globals.AllocateDtl("P020", SelectedOutDtl);
                    //int[] array1 = new int[] { 1, 3, 5, 7, 9 };
                    RadzenDh5.Models.Mark10Sqlexpress04.OutDtl[] array1 = new RadzenDh5.Models.Mark10Sqlexpress04.OutDtl[] { args };
                    await DhGlobals.MLASRS_AllocateDtl_Async(ConnectionString, DhUsername, "P020", array1);
                    await SimpleDialog("Confirm success");
                    //QueryMst();
                    await QueryMstAsync();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }


        }




        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P020";
            await base.OnInitializedAsync();
        }

    




        public string GetSQL()
        {


            GoodMsg = "";
            ErrMsg = "";
            string strSQL = "";
            try
            {

                DhGlobals.PurifyFilterValue(ref txtOUT_NO);
                DhGlobals.PurifyFilterValue(ref txtSHIP_TO);
                DhGlobals.PurifyFilterValue(ref txtSHIP_TO_NAME);
                DhGlobals.PurifyFilterValue(ref txtSKU_NO);
                DhGlobals.PurifyFilterValue(ref txtREQM_NO);
                DhGlobals.PurifyFilterValue(ref txtCREATEUSER);
                DhGlobals.PurifyFilterValue(ref txtCAR_LIC);
                DhGlobals.PurifyFilterValue(ref txtWHSE_DOOR);

                //string sRet = Globals.UserLog("01", "P020", this.Text, "");
                //Mst
                strSQL = string.Format(@"
                select distinct a.* from {0} a join {1} b 
                on (a.OUT_NO=b.OUT_NO) where a.SHIP_CONDITION in ('20','90') and b.GTIN_OUT_QTY > b.GTIN_ALO_QTY ", dtMST, dtDTL);

                if (txtOUT_NO != "") strSQL += string.Format(@" and a.OUT_NO like '%{0}%'", txtOUT_NO);
                if (txtSKU_NO != "") strSQL += string.Format(@" and b.SKU_NO like '%{0}%'", txtSKU_NO);
                if (txtREQM_NO != "") strSQL += string.Format(@" and b.REQM_NO like '%{0}%'", txtREQM_NO);
                if (txtCAR_LIC != "") strSQL += string.Format(@" and a.CAR_LIC like '%{0}%'", txtCAR_LIC);
                if (txtSHIP_TO != "") strSQL += string.Format(@" and a.SHIP_TO like '%{0}%'", txtSHIP_TO);
                if (txtSHIP_TO_NAME != "") strSQL += string.Format(@" and a.SHIP_TO_NAME like '%{0}%'", txtSHIP_TO_NAME);
                if (txtCREATEUSER != "") strSQL += string.Format(@" and a.CREATEUSER like '%{0}%'", txtCREATEUSER);
                if (txtWHSE_DOOR != "") strSQL += string.Format(@" and a.WHSE_DOOR like '%{0}%'", txtWHSE_DOOR);



                strSQL += " order by a.PICK_DATE,a.PICK_TIME";


                return strSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + strSQL);
            }





        }


        protected async System.Threading.Tasks.Task ReloadTab1()
        {

            var args = ((OutMst)ObjTab0Selected);
            var OUT_NO = args.OUT_NO;
            getOutDtlsResult = await AppDb.OutDtls.Where(a => a.OUT_NO == OUT_NO).AsNoTracking().ToListAsync();


            if (getOutDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getOutDtlsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.OutMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(Models.Mark10Sqlexpress04.OutDtl args)
        {
             ObjTab1Selected = args;
        }


        // P020 grid0
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.OutMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewOutMst>("OUT_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "OUT_NO", args.OUT_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        // P020 grid1
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.OutDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewOutDtl>("OUT_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "OUT_NO", args.OUT_NO }, { "OUT_LINE", args.OUT_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
