using CaotunSpring.DH.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace RadzenDh5.Pages
{
    public partial class Vr060SComponent
    {


        protected IEnumerable<Models.Mark10Sqlexpress04.Vr060> getVr060sResult;

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "R060";
            await base.OnInitializedAsync();
        }

        public string GetSQL() //RO60
        {


            strFrom = dateFrom.ToString("yyyy-MM-dd");
            strTo = dateTo.ToString("yyyy-MM-dd");
            string strSQL = $@"
            select SKU_NO, SKU_DESC, sum(OUT_COUNT) as Outbound,sum(IN_COUNT) as Inbound,sum(TX_COUNT) as Relocation,sum(OUT_COUNT + IN_COUNT + TX_COUNT) as Total
  from
  (
  select a.SKU_NO, b.SKU_DESC, 0 as OUT_COUNT, count(distinct a.SU_ID) as IN_COUNT, 0 as TX_COUNT from IN_SNO a
                            join SKU_MST b on (a.SKU_NO = b.SKU_NO)
                             where a.SKU_FIN_QTY > 0 and a.TRN_DATE > '{strFrom}' and a.TRN_DATE < '{strTo}'
                             group by a.SKU_NO, b.SKU_DESC
                              UNION ALL
                            select a.SKU_NO, b.SKU_DESC, count(distinct a.SU_ID) as OUT_COUNT, 0 as IN_COUNT, 0 as TX_COUNT from PCK_SNO a
                            join SKU_MST b on (a.SKU_NO = b.SKU_NO)
                             where a.SKU_FIN_QTY > 0 and a.TRN_DATE > '{strFrom}' and a.TRN_DATE < '{strTo}'
                             group by a.SKU_NO, b.SKU_DESC
                              UNION ALL
                             select a.SKU_NO, b.SKU_DESC, 0 as OUT_COUNT, 0 as IN_COUNT, count(distinct TX_NO) as TX_COUNT from TX_LOG a
                            join SKU_MST b on (a.SKU_NO = b.SKU_NO)
                             where a.TX_DATE > '{strFrom}' and a.TX_DATE < '{strTo}'
                             group by a.SKU_NO, b.SKU_DESC
) T1
group by SKU_NO, SKU_DESC
";
            return strSQL;

        }





        protected async Task ReloadMainTab()
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
            getVr060sResult = await AppDb.Vr060s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();
            StateHasChanged();
        }

        protected async Task ButtonQueryClick()
        {
            await ReloadMainTab();

            // ???????????? Query, ???????????? Export
            IsExportDisable = false;

        }
        protected async Task ButtonExportClick()
        {
            try
            {
                //throw new Exception("no authorization to export"); // FOR DEBUG PURPOSE
                if (progWrt.APPROVE_WRT != "Y" && progWrt.EXPORT_WRT != "Y") throw new Exception("no authorization to export");
                AuthMsg = "authorization to export granted";

                // ?????????????????? Export
                IsExportDisable = true;

                // ?????? Export ????????????????????? Query,
                // ????????? Query ??????, ?????????????????????????????????????????????
                await ReloadMainTab();

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
                string strAuth = $@" (USER_ID,PROG_ID)=({ progWrt.USER_ID},{ progWrt.PROG_ID})";
                ErrMsg = ex.Message + strAuth;
            }

        }
    }
}
