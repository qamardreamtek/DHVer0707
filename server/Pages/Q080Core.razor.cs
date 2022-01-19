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
    public partial class Q080CoreComponent
    {

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.LocDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewLocDtl>("LOC_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "SU_ID", args.SU_ID }, { "PLANT", args.PLANT }, { "STGE_LOC", args.STGE_LOC }, { "SKU_NO", args.SKU_NO }, { "BATCH_NO", args.BATCH_NO }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO }, { "GTIN_UNIT", args.GTIN_UNIT } });
        }
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
        }

        //DataTable dtMST = new DataTable("LOC_DTL"); //庫存明細
        //DataTable dtDTL = new DataTable("PLT_DTL"); //托盤明細
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q080";
            await base.OnInitializedAsync();
        }

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl> grid0;

        public IEnumerable<Models.Mark10Sqlexpress04.LocDtl> getLocDtlsResult { get; set; }

        public IEnumerable<Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult { get; set; }
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
                getLocDtlsResult = await AppDb.LocDtls.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).ThenBy(a => a.SU_ID).AsNoTracking().ToListAsync();


                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getLocDtlsResult.Count() > 0)
                {
                    ObjTab0Selected = getLocDtlsResult.First();
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
        async Task ReloadTab1()
        {
            //IN_SNO由SAP下傳，如果沒有序列號則只有托盤號，序列號為'X' 
            //sSQL = string.Format(@"select * from {0} where SU_ID='{1}' order by SKU_NO,GR_DATE,IN_SNO", dtDTL.TableName, sSU_ID);


            var args = ((LocDtl)ObjTab0Selected);
            getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).OrderBy(a => a.SKU_NO).ThenBy(a => a.GR_DATE).ThenBy(a => a.IN_SNO).AsNoTracking().ToListAsync();

            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();
                //   await ReloadTab2(); // 採用沒有就沒有
            }
            else
            {
            }
        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.LocDtl args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        //DataTable dtMST = new DataTable("LOC_DTL"); //庫存明細
        //DataTable dtDTL = new DataTable("PLT_DTL"); //托盤明細

        readonly string dtMST = "LOC_DTL"; //庫存明細
        //readonly string dtDTL = "PLT_DTL"; //托盤明細
        public string GetSQL()
        {
            //string sSQL = string.Format(@"select * from {0}  where 1=1", dtMST.TableName);
            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
            //if (tbGTIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and GTIN_NO like '%{0}%'", tbGTIN_NO.Text.Trim().ToUpper());
            //if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and REQM_NO like '%{0}%'", tbREQM_NO.Text.Trim().ToUpper());
            //if (tbIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IN_NO like '%{0}%'", tbIN_NO.Text.Trim().ToUpper());
            //if (tbALO_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and ALO_NO like '%{0}%'", tbALO_NO.Text.Trim().ToUpper());
            //if (tbBATCH_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and BATCH_NO like '%{0}%'", tbBATCH_NO.Text.Trim().ToUpper());
            //if (tbSTK_CAT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and STK_CAT = '{0}'", tbSTK_CAT.Text.Trim().ToUpper());
            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());

            //sSQL = sSQL + " order by SKU_NO, SU_ID";
            string strSQL = string.Format(@"select * from {0}  where 1=1 ", dtMST);


            strSQL += GetContains("SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("GTIN_NO", ref txtGTIN_NO);
            strSQL += GetContains("REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("IN_NO", ref txtIN_NO);
            strSQL += GetContains("ALO_NO", ref txtALO_NO);
            strSQL += GetContains("LOC_NO", ref txtLOC_NO);
            strSQL += GetContains("BATCH_NO", ref txtBATCH_NO);
            strSQL += GetContains("STK_CAT", ref txtSTK_CAT);
            //   GoodMsg = strSQL;
            return strSQL;
        }

        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }



    }
}
