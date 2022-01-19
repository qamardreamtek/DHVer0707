using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace RadzenDh5.Pages
{
    public partial class Q030CoreComponent
    {
     

        public string GetSQL()
        {
            var dtMST = "SKU_SUT";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("WHSE_NO", ref txtWHSE_NO);
            strSQL += GetContains("SKU_NO", ref txtSKU_NO);

            return strSQL;
        }
        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            //GoodMsg = " " + GetSQL();
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
            getSkuSutsResult = await AppDb.SkuSuts.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).ThenBy(a => a.GTIN_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);

            if (getSkuSutsResult.Count() > 0)
            {
                ObjTab0Selected = getSkuSutsResult.First();
            }
        }


      
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.SkuSut args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewSkuSut>("SKU_SUT", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "SKU_NO", args.SKU_NO }, { "GTIN_UNIT", args.GTIN_UNIT }, { "SU_TYPE", args.SU_TYPE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

    }
}
