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
    public partial class Q110CoreComponent
    {


        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.TxLog args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewTxLog>("TX_LOG", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "TX_NO", args.TX_NO }, { "TX_LINE", args.TX_LINE } });
        }

        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.TxSno args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewTxSno>("TX_SNO", new Dictionary<string, object>() { { "TX_NO", args.TX_NO }, { "TX_LINE", args.TX_LINE }, { "IN_SNO", args.IN_SNO } });
        }
        // 
        //DataTable dtMST = new DataTable("TX_LOG"); //TX明細
        //DataTable dtDTL = new DataTable("TX_SNO"); //TX SNO
        // 
        readonly string dtMST = "TX_LOG"; //TX明細
        readonly string dtDTL = "TX_SNO"; //TX SNO
        public string GetSQL()
        {
            //string sSQL = string.Format(@"select * from {0}  where 1=1", dtMST.TableName);
            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
            //if (tbTX_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and TX_NO like '%{0}%'", tbTX_NO.Text.Trim().ToUpper());
            //if (tbTX_USER.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and TX_USER like '%{0}%'", tbTX_USER.Text.Trim().ToUpper());
            //if (tbTX_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and TX_NO like '%{0}%'", tbTX_NO.Text.Trim().ToUpper());
            //if (tbBATCH_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and BATCH_NO like '%{0}%'", tbBATCH_NO.Text.Trim().ToUpper());
            //if (tbSTK_CAT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and STK_CAT = '{0}'", tbSTK_CAT.Text.Trim().ToUpper());
            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());

            //if (chkFailed.Checked) sSQL = sSQL + " and TX_STS in ('F','X')";    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!$$$$$$$$$$$$
            //sSQL = sSQL + " order by SU_ID,SKU_NO";

            string strSQL = string.Format(@"select * from {0}  where 1=1 ", dtMST);

            strSQL += GetContains("SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("TX_NO", ref txtTX_NO);
            strSQL += GetContains("TX_USER", ref txtTX_USER);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("BATCH_NO", ref txtBATCH_NO);
            strSQL += GetContains("STK_CAT", ref txtSTK_CAT);
            strSQL += GetContains("LOC_NO", ref txtLOC_NO);

            if (checkBox1Value) strSQL += " and TX_STS in ('F','X')";

            //TODO CHECKBOX

            //   GoodMsg = strSQL;
            return strSQL;
        }
        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            getTxLogsResult = await AppDb.TxLogs.FromSqlRaw(GetSQL()).OrderBy(a => a.SU_ID).ThenBy(a => a.SKU_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);
        }
        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }
      
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getTxLogsResult = await AppDb.TxLogs.FromSqlRaw(GetSQL()).OrderBy(a => a.SU_ID).ThenBy(a => a.SKU_NO).AsNoTracking().ToListAsync();


                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getTxLogsResult.Count() > 0)
                {
                    ObjTab0Selected = getTxLogsResult.First();
                    await ReloadTab1();
                }
                else
                {
                    getTxSnosResult = null;

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }



        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.TxLog> grid0;
        public IEnumerable<Models.Mark10Sqlexpress04.TxLog> getTxLogsResult { get; set; }
        public IEnumerable<Models.Mark10Sqlexpress04.TxSno> getTxSnosResult { get; set; }

        async Task ReloadTab1()
        {
            var args = ((TxLog)ObjTab0Selected);
            getTxSnosResult = AppDb.TxSnos.Where(a => a.TX_NO == args.TX_NO).OrderBy(a => a.IN_SNO);
            if (getTxSnosResult.Count() > 0)
            {
                ObjTab1Selected = getTxSnosResult.First();
                //   await ReloadTab2(); // 採用沒有就沒有
            }
            else
            {
            }
        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.TxLog args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

    }
}
