using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace RadzenDh5.Pages
{
    public partial class Q020CoreComponent
    {

        public string GetSQL()
        {

            var dtMST = "GTIN_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("GTIN_NO", ref txtGTIN_NO);

            return strSQL;
        }
        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

            getGtinMstsResult = await AppDb.GtinMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).ThenBy(a => a.GTIN_UNIT).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);

            if (getGtinMstsResult.Count() > 0)
            {
                ObjTab0Selected = getGtinMstsResult.First();
            }
        }


        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.GtinMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewGtinMst>("GTIN_MST", new Dictionary<string, object>() { { "SKU_NO", args.SKU_NO }, { "GTIN_UNIT", args.GTIN_UNIT } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
