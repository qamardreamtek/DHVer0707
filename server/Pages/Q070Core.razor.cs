using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class Q070CoreComponent
    {
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> grid0;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> getCmdMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult;

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q070";
            await base.OnInitializedAsync();
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.CmdMst args)
        {
            ObjTab0Selected = args;
            var dialogResult = await DialogService.OpenAsync<ViewCmdMst>("CMD_MST", new Dictionary<string, object>() { { "CMD_DATE", args.CMD_DATE }, { "CMD_SNO", args.CMD_SNO } });
            //await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
            //await InvokeAsync(() => { StateHasChanged(); });
        }

        //DataTable dtMST = new DataTable("CMD_MST"); //命令主檔
        //DataTable dtDTL = new DataTable("PLT_DTL"); //托盤明細(包含所有)
        readonly string dtMST = "CMD_MST"; //命令主檔
        readonly string dtDTL = "PLT_DTL"; //托盤明細(包含所有)
        public string GetSQL()
        {
            //if (dtMST.Rows.Count > 0) dtMST.Rows.Clear();
            //string sSQL = string.Format(@"select * from {0}  where 1=1", dtMST.TableName);
            //if (tbCMD_SNO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and CMD_SNO like '%{0}%'", tbCMD_SNO.Text.Trim().ToUpper());
            //if (tbEQU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and EQU_NO like '%{0}%'", tbEQU_NO.Text.Trim().ToUpper());
            //if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and REQM_NO like '%{0}%'", tbREQM_NO.Text.Trim().ToUpper());
            //if (tbSTN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and STN_NO like '%{0}%'", tbSTN_NO.Text.Trim().ToUpper());
            //if (tbREF_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and REF_NO like '%{0}%'", tbREF_NO.Text.Trim().ToUpper());
            //if (tbCRT_USER.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and CRT_USER like '%{0}%'", tbCRT_USER.Text.Trim().ToUpper());
            //if (tbCMD_DATE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and CMD_DATE like '%{0}%'", tbCMD_DATE.Text.Trim().ToUpper());
            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());

            //sSQL = sSQL + " order by CMD_DATE desc, CMD_SNO desc";


            string strSQL = string.Format(@"select * from {0}  where 1=1", dtMST);

            strSQL += GetContains("CMD_SNO", ref txtCMD_SNO);
            strSQL += GetContains("STN_NO", ref txtSTN_NO);
            strSQL += GetContains("EQU_NO", ref txtEQU_NO);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("CMD_DATE", ref txtCMD_DATE);
            strSQL += GetContains("LOC_NO", ref txtLOC_NO);
            strSQL += GetContains("REF_NO", ref txtREF_NO);
            strSQL += GetContains("CRT_USER", ref txtCRT_USER);

            //   GoodMsg = strSQL;
            return strSQL;
        }
        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            getCmdMstsResult = await AppDb.CmdMsts.FromSqlRaw(GetSQL()).OrderByDescending(a => a.CMD_DATE).ThenByDescending(a => a.CMD_SNO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);
        }
        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
               await QueryMstAsync();
        }
        /// <summary>
        /// 這裡由於 grid0 宣告的限制, 必需在每個頁面做,
        /// 可以把 SwitchToTab0(); 納進來
        /// </summary>
        /// <returns></returns>
        public async Task FixGrid0GotoPage0Async()
        {
            SwitchToTab0();
            await grid0.GoToPage(0);
        }

   
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                // 在 grid0 的 data 更新之前, 先調用 FixGrid0GotoPage0Async
                await FixGrid0GotoPage0Async();
                getCmdMstsResult = await AppDb.CmdMsts.FromSqlRaw(GetSQL()).OrderByDescending(a => a.CMD_DATE).ThenByDescending(a => a.CMD_SNO).AsNoTracking().ToListAsync();

                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getCmdMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getCmdMstsResult.First();
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


        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.CmdMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async System.Threading.Tasks.Task Grid1RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            ObjTab1Selected = args;
        }


        protected async System.Threading.Tasks.Task ReloadTab1()
        {

            var args = ((CmdMst)ObjTab0Selected);
            getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).OrderBy(a => a.SKU_NO).ThenBy(a => a.GR_DATE).ThenBy(a => a.IN_SNO).AsNoTracking().ToListAsync();


            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();
                await ReloadTab2(); // 保留框架
            }
            else
            {

            }
        }
        protected async System.Threading.Tasks.Task ReloadTab2()
        {

        }
        protected async System.Threading.Tasks.Task ResetMainTab()
        {


            ResetValue(ref txtCMD_SNO);
            ResetValue(ref txtSTN_NO);
            ResetValue(ref txtEQU_NO);
            ResetValue(ref txtSU_ID);
            ResetValue(ref txtREQM_NO);
            ResetValue(ref txtCMD_DATE);
            ResetValue(ref txtLOC_NO);
            ResetValue(ref txtREF_NO);
            ResetValue(ref txtCRT_USER);

            getCmdMstsResult = null;
        }

        

    }
}
