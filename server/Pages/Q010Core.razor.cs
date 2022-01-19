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
    public partial class Q010CoreComponent
    {
        //DataTable dtMST = new DataTable("IN_MST"); //TR主檔
        //DataTable dtDTL = new DataTable("IN_DTL"); //TR明細檔
        //DataTable dtSNO = new DataTable("IN_SNO"); //TR托盤序列號明細
        // NOTE by Mark,

        public IList<Models.Mark10Sqlexpress04.InMst> inMstsList
        {
            //      get { return new List<Models.Mark10Sqlexpress04.InMst>(getInMstsResult); }
            get { return getInMstsResult.ToList(); }

        }


        public IList<Models.Mark10Sqlexpress04.InDtl> inDtlsList { get; set; }
        public IList<Models.Mark10Sqlexpress04.InSno> inSnosList { get; set; }




        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(Models.Mark10Sqlexpress04.SkuMst args)
        {

            var dialogResult = await DialogService.OpenAsync<ViewSkuMst>("SKU_MST", new Dictionary<string, object>() { { "SKU_NO", args.SKU_NO } });
            await InvokeAsync(() => { StateHasChanged(); });

        }


        public string GetSQL()
        {

            var dtMST = "SKU_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("GTIN_NO", ref txtGTIN_NO);

            return strSQL;
        }
        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

            getSkuMstsResult = await AppDb.SkuMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.SKU_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);

            if (getSkuMstsResult.Count > 0)
            {
                ObjTab0Selected = getSkuMstsResult.First();
            }
        }
    }
}
