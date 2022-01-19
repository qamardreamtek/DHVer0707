using CaotunSpring.DH.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace RadzenDh5.Pages
{
    public partial class R040CoreComponent
    {
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vr040> grid0;
        protected IEnumerable<Models.Mark10Sqlexpress04.Vr040> getVr040sResult;
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "R040";
            await base.OnInitializedAsync();
        }

        public string GetSQL()//R040
        {
            strFrom = dateFrom.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US")) ;
            strTo = dateTo.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US")) + " 23:59:59";
            string strSQL = $@"
                select SUBSTRING(c.TRN_DATE,1,10) as DATE,c.SKU_NO,b.SKU_DESC,d.EXPIRE_DATE ,c.BATCH_NO,CASE WHEN c.IN_SNO = '**********' THEN '' ELSE c.IN_SNO END as IN_SNO,c.GTIN_UNIT,sum(c.GTIN_FIN_QTY) as GTIN_QTY from PCK_SNO c
 join SKU_MST b on (c.SKU_NO = b.SKU_NO)
 join IN_DTL d on (c.WHSE_NO = d.WHSE_NO and c.IN_NO = d.IN_NO and c.IN_LINE = d.IN_LINE)
where c.TRN_DATE > '{strFrom}' and c.TRN_DATE < '{strTo}'
group by SUBSTRING(c.TRN_DATE, 1, 10),c.SKU_NO,b.SKU_DESC,d.EXPIRE_DATE,c.BATCH_NO,c.IN_SNO,c.GTIN_UNIT
  order by SUBSTRING(c.TRN_DATE,1,10),c.SKU_NO


";
            return strSQL;

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
                getVr040sResult = await AppDb.Vr040s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();
                IsExportDisable = false;
                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getVr040sResult.Count() > 0)
                {
                    ObjTab0Selected = getVr040sResult.First();

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected async Task ButtonQueryClick()
        {
            await QueryMstAsync();
        }
        protected async Task ButtonExportClick()
        {
            try
            {
                //throw new Exception("no authorization to export"); // FOR DEBUG PURPOSE
                if (progWrt.APPROVE_WRT != "Y" && progWrt.EXPORT_WRT != "Y") throw new Exception("no authorization to export");
                AuthMsg = "authorization to export granted";

                // 基本避免重覆 Export
                IsExportDisable = true;

                // 不管 Export 之前有沒有先做 Query,
                // 總是再 Query 一次, 確保畫面上看到的和導出的會一致
                await QueryMstAsync();

                // REPORT SOP, by Mark, 05/10
                DataTable dt = AppDb.DataTable(GetSQL());
                ReportFile = DhGlobals.GetReportFile(PROG_ID);
                ReportName = DhGlobals.GetReportName(PROG_ID);


                await DoUserLogAsync("03", PROG_ID, PROG_NAME_FOR_LOG, ReportFile);
                await DhGlobals.ExportExcelAsync(dt, ReportPath, ReportFile, ReportName, strFrom, strTo);
                navigationManager.NavigateTo(@$"{ReportPath}/{ReportFile}", true);

            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }

        }
    }
}
