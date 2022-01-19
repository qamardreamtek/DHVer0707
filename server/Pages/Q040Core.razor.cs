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
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class Q040CoreComponent
    {
        protected RadzenGrid<InMst> grid0;
        protected RadzenGrid<InDtl> grid1;

        protected IEnumerable<InMst> getInMstsResult;
        public IEnumerable<InDtl> getInDtlsResult;
        public IEnumerable<InSno> getInSnosResult;


        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q040";
            await base.OnInitializedAsync();
        }

        protected async Task ReloadGrid1()
        {
            var IN_NO = ((InMst)ObjTab0Selected).IN_NO;

            getInDtlsResult = await AppDb.InDtls.Where(a => a.IN_NO == IN_NO).AsNoTracking().ToListAsync();
            if (getInDtlsResult.Count()>0)
            {
                ObjTab1Selected = getInDtlsResult.First();
                await ReloadGrid2();
            }
            await InvokeAsync(() => { StateHasChanged(); });

        }
        async Task ReloadGrid2()
        {
            var IN_NO = ((InDtl)ObjTab1Selected).IN_NO;
            var IN_LINE = ((InDtl)ObjTab1Selected).IN_LINE;
            getInSnosResult = await AppDb.InSnos.Where(a => a.IN_NO == IN_NO && a.IN_LINE == IN_LINE).AsNoTracking().ToListAsync();

            if (getInSnosResult.Count()>0)
            {
                ObjTab2Selected = getInSnosResult.First();
            }
            await InvokeAsync(() => { StateHasChanged(); });

        }


        readonly string dtMST = "IN_MST"; //TR主檔
        //readonly string dtDTL = "IN_DTL"; //TR明細檔
        readonly string dtSNO = "IN_SNO"; //TR托盤序列號明細
     
        public string GetSQL()
        {
            /*
            string strSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.IN_NO=b.IN_NO) where 1=1", dtMST, dtSNO);
            strSQL += GetContains("b.SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("b.GTIN_NO", ref txtGTIN_NO);
            strSQL += GetContains("b.REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("b.SU_ID", ref txtSU_ID);
            strSQL += GetContains("b.IN_NO", ref txtIN_NO);
            */

            // Note by Qamar 2021-12-01
            string strSQL = string.Format(@"select distinct a.* from {0} a full outer join {1} b on (a.IN_NO=b.IN_NO) where 1=1", dtMST, dtSNO);
            strSQL += GetContains("b.SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("b.GTIN_NO", ref txtGTIN_NO);
            strSQL += GetContains("a.REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("b.SU_ID", ref txtSU_ID);
            strSQL += GetContains("a.IN_NO", ref txtIN_NO);

            return strSQL;
        }

        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getInMstsResult = await AppDb.InMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.IN_NO).AsNoTracking().ToListAsync();

                if (getInMstsResult.Count()>0)
                {
                    ObjTab0Selected = getInMstsResult.First();
                    await ReloadGrid1();

                }
                else
                {
                    // Note by Qamar 2021-12-01 原本是註釋掉的
                    getInDtlsResult = null;
                    getInSnosResult = null;
                }
                await InvokeAsync(() => { StateHasChanged(); });

            }
            catch (Exception ex)
            {
                await SimpleDialog(@$"{ex.Message}");
            }

        }



        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            //Note by Qamar 2021-12-01
            //grid0.Value = Enumerable.Empty<TabRenderMode>();
            //await ReloadGrid1();
            //await InvokeAsync(() => { StateHasChanged(); });

            await QueryMstAsync();
        }


        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.InMst args)
        {
            ObjTab0Selected = args;
            await ReloadGrid1();
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(Models.Mark10Sqlexpress04.InMst args)
        {
            // await SimpleDialog("why problem to double click the same row?"); //加上這個, 就不會有問題, 如同20+年前 Access 遇到的問題
            // await InvokeAsync(() => { StateHasChanged(); });
            await Task.Delay(500); // NOTE by Mark, 06/25, 可以避免 https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
            await DialogService.OpenAsync<ViewInMst>("IN_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
      
        }

        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(Models.Mark10Sqlexpress04.InDtl args)
        {
            await DialogService.OpenAsync<ViewInDtl>("IN_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });

        }
        protected async System.Threading.Tasks.Task Grid2RowDoubleClick(Models.Mark10Sqlexpress04.InSno args)
        {
            //SelectedInSno = args;
            await DialogService.OpenAsync<ViewInSno>("IN_SNO", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "SU_ID", args.SU_ID }, { "IN_SNO1", args.IN_SNO1 } });
            await InvokeAsync(() => { StateHasChanged(); });

        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(Models.Mark10Sqlexpress04.InDtl args)
        {
            ObjTab1Selected = args;
            await ReloadGrid2();
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
