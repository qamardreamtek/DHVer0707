using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class Q120CoreComponent
    {

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PcLog args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPcLog>("PC_LOG", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PC_NO", args.PC_NO }, { "PC_LINE", args.PC_LINE } });
        }
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PcSno args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPcSno>("PC_SNO", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PC_NO", args.PC_NO }, { "PC_LINE", args.PC_LINE }, { "IN_SNO", args.IN_SNO } });
        }

        //DataTable dtMST = new DataTable("PC_LOG"); //PC明細
        //DataTable dtDTL = new DataTable("PC_SNO"); //PC SNO
        // 
        readonly string dtMST = "PC_LOG"; //PC明細
        //readonly string dtDTL = "PC_SNO"; //PC SNO
        public string GetSQL()
        {
            //Mst
            //if (dtMST.Rows.Count > 0) dtMST.Rows.Clear();
            //string sSQL = string.Format(@"select * from {0}  where 1=1", dtMST.TableName);
            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
            //if (tbPC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and PC_NO like '%{0}%'", tbPC_NO.Text.Trim().ToUpper());
            //if (tbPC_USER.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and PC_USER like '%{0}%'", tbPC_USER.Text.Trim().ToUpper());
            //if (tbBATCH_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and BATCH_NO like '%{0}%'", tbBATCH_NO.Text.Trim().ToUpper());
            //if (tbSTK_CAT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and STK_CAT = '{0}'", tbSTK_CAT.Text.Trim().ToUpper());
            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());
            //if (chkFailed.Checked) sSQL = sSQL + " and PC_STS in ('F','X')";

            //sSQL = sSQL + " order by SU_ID,SKU_NO";

            string strSQL = string.Format(@"select * from {0}  where 1=1 ", dtMST);

            strSQL += GetContains("SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("PC_NO", ref txtPC_NO);
            strSQL += GetContains("PC_USER", ref txtPC_USER);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("BATCH_NO", ref txtBATCH_NO);
            strSQL += GetContains("STK_CAT", ref txtSTK_CAT);
            strSQL += GetContains("LOC_NO", ref txtLOC_NO);


            if (checkBox1Value) strSQL += " and  PC_STS in ('F','X')";

            //TODO CHECKBOX

            //   GoodMsg = strSQL;
            return strSQL;
        }
        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            getPcLogsResult = await AppDb.PcLogs.FromSqlRaw(GetSQL()).OrderBy(a => a.SU_ID).ThenBy(a => a.SKU_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);
        }
        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
            //await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
            //await ReloadMainTab();
            //getPcSnosResult = null;

            //ResetGridBindAndSwitchToTab0();
        }

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
              //  getLocDtlsResult = await AppDb.LocDtls.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).ThenBy(a => a.SU_ID).AsNoTracking().ToListAsync();
                getPcLogsResult = await AppDb.PcLogs.FromSqlRaw(GetSQL()).OrderBy(a => a.SU_ID).ThenBy(a => a.SKU_NO).AsNoTracking().ToListAsync();


                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getPcLogsResult.Count() > 0)
                {
                    ObjTab0Selected = getPcLogsResult.First();
                    await ReloadTab1();
                }
                else
                {
                    getPcSnosResult = null;

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
 

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PcLog> grid0;
        public IEnumerable<Models.Mark10Sqlexpress04.PcLog> getPcLogsResult { get; set; }
        public IEnumerable<Models.Mark10Sqlexpress04.PcSno> getPcSnosResult { get; set; }

        async Task ReloadTab1()
        {
            var args = ((PcLog)ObjTab0Selected);
            getPcSnosResult = await AppDb.PcSnos.Where(a => a.PC_NO == args.PC_NO).OrderBy(a => a.IN_SNO).AsNoTracking().ToListAsync();

            if (getPcSnosResult.Count() > 0)
            {
                ObjTab1Selected = getPcSnosResult.First();
                //   await ReloadTab2(); // 採用沒有就沒有
            }
            else
            {
            }
        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.PcLog args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

    }
}
