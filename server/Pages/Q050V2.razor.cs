using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using System.Linq.Dynamic.Core;

namespace RadzenDh5.Pages
{
    public partial class Q050V2Component
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


        Models.Mark10Sqlexpress04.InMst SelectedInMst { get; set; }

       
        void ReloadChildGrids()
        {
            var IN_NO = SelectedInMst.IN_NO;
            inDtlsList = AppDb.InDtls.Where(a => a.IN_NO == IN_NO).ToList();
            if (inDtlsList.Count == 0)
            {
                inSnosList = AppDb.InSnos.Take(0).ToList();

            }
            else
            {
                var IN_LINE = inDtlsList[0].IN_LINE;
                inSnosList = AppDb.InSnos.Where(a => a.IN_NO == IN_NO && a.IN_LINE == IN_LINE).ToList();
            }


        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.InMst args)
        {
            //  var dialogResult = await DialogService.OpenAsync<EditLocMst>("Edit Loc Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"LOC_NO", args.LOC_NO}, {"ZONE_NO", args.ZONE_NO} });
            SelectedInMst = args;

            string Summary = "Row Select";
            string Detail = "IN_NO = "+SelectedInMst.IN_NO;

            ReloadChildGrids();


            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = Summary, Detail = Detail, Duration = 4000 });



            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
