using Microsoft.EntityFrameworkCore;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class Vr080SComponent
    {
        //DataTable dtMST = new DataTable("OUT_DTL");

        public string txtPIC_NO;
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vr080> grid0;
        protected IEnumerable<Models.Mark10Sqlexpress04.Vr080> getVr080sResult;
        string GetSQL()
        {
            txtPIC_NO = (txtPIC_NO == null) ? "" : txtPIC_NO.Trim();
            string sSQL;

            if (string.IsNullOrEmpty(txtPIC_NO))
            {
                sSQL = string.Format(@"
                    select a.PIC_NO,c.PIC_STS,a.SKU_NO,b.SKU_DESC,a.BATCH_NO,a.COUNT_UNIT,sum(a.GTIN_QTY) as GTIN_QTY,sum(a.COUNT_QTY) as COUNT_QTY,a.SU_ID,sum(a.COUNT_QTY)-sum(a.GTIN_QTY) as DIFF_QTY,c.COUNT_USER as COUNT_USER,c.APPROVE_USER 
                    from PIC_SNO a 
						join PIC_MST c on (a.PIC_NO=c.PIC_NO)
                        join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                    where a.GTIN_QTY <> a.COUNT_QTY
					group by a.PIC_NO,c.PIC_STS,a.SKU_NO,b.SKU_DESC,a.BATCH_NO,a.COUNT_UNIT,c.COUNT_USER,a.SU_ID,c.APPROVE_USER 
					order by a.PIC_NO,a.SKU_NO,a.SU_ID
                    ");
            }
            else
            {
                sSQL = string.Format(@"
                    select a.PIC_NO,c.PIC_STS,a.SKU_NO,b.SKU_DESC,a.BATCH_NO,a.COUNT_UNIT,sum(a.GTIN_QTY) as GTIN_QTY,sum(a.COUNT_QTY) as COUNT_QTY,a.SU_ID,sum(a.COUNT_QTY)-sum(a.GTIN_QTY) as DIFF_QTY,c.COUNT_USER as COUNT_USER,c.APPROVE_USER 
                    from PIC_SNO a 
						join PIC_MST c on (a.PIC_NO=c.PIC_NO)
                        join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                    where a.GTIN_QTY <> a.COUNT_QTY and a.PIC_NO like '%{0}%'
					group by a.PIC_NO,c.PIC_STS,a.SKU_NO,b.SKU_DESC,a.BATCH_NO,a.COUNT_UNIT,c.COUNT_USER,a.SU_ID,c.APPROVE_USER 
					order by a.PIC_NO,a.SKU_NO,a.SU_ID
                    ", txtPIC_NO);
            }
            return sSQL;
        }


        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "R080";
            await base.OnInitializedAsync();
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
                getVr080sResult = await AppDb.Vr080s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();
                IsExportDisable = false;
                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getVr080sResult.Count() > 0)
                {
                    ObjTab0Selected = getVr080sResult.First();

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
                // throw new Exception("no authorization to export"); // FOR DEBUG PURPOSE
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
                await DhGlobals.ExportExcelAsync(dt, ReportPath, ReportFile, ReportName, "", "");
                navigationManager.NavigateTo(@$"{ReportPath}/{ReportFile}", true);

            }
            catch (Exception ex)
            { 
                await SimpleDialog(ex.Message);
            }


        }

    }
}
