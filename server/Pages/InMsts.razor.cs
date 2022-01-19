using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RadzenDh5.Pages
{
    public partial class InMstsComponent
    {

        Models.Mark10Sqlexpress04.InMst SelectedInMst { get; set; }
        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.InMst args)
        {
            //  var dialogResult = await DialogService.OpenAsync<EditLocMst>("Edit Loc Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"LOC_NO", args.LOC_NO}, {"ZONE_NO", args.ZONE_NO} });

            string msg = "Grid0RowSelect";

            SelectedInMst = args;
            //   reloadGrid2();


            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = msg, Duration = 4000 });



            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
