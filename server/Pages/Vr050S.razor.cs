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
    public partial class Vr050SComponent
    {

        protected IEnumerable<Models.Mark10Sqlexpress04.Vr050> getVr050sResult;

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "R050";
            await base.OnInitializedAsync();
        }

        public string GetSQL()
        {
            string strSQL = $@"SELECT * FROM V_R050";
            return strSQL;
        }

        protected async Task ReloadMainTab()
        {
            getVr050sResult = await AppDb.Vr050s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();
            StateHasChanged();
        }

        protected async Task ButtonQueryClick()
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
            await ReloadMainTab();

            // 只要做過 Query, 就要允許 Export
            IsExportDisable = false;

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
                await ReloadMainTab();

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
                string strAuth = $@" (USER_ID,PROG_ID)=({ progWrt.USER_ID},{ progWrt.PROG_ID})";
                ErrMsg = ex.Message + strAuth;
            }
        }
    }
}
