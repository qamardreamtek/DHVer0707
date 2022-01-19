using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RadzenDh5.Models;

namespace RadzenDh5.Pages
{
    // public partial class PltDtlsComponent : ComponentBase
    //public partial class P070PltDtlsComponent : ComponentBase
    public partial class DhLoginComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> _getPltDtlsResult;

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult2 { get; set; }


        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult
        {
            get
            {
                return _getPltDtlsResult;
            }
            set
            {
                if (!object.Equals(_getPltDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPltDtlsResult", NewValue = value, OldValue = _getPltDtlsResult };
                    _getPltDtlsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
           //     await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetPltDtlsResult = await Mark10Sqlexpress04.GetPltDtls();
            getPltDtlsResult = mark10Sqlexpress04GetPltDtlsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPltDtl>("Add Plt Dtl", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPltDtlsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SU_ID,SU_TYPE,IN_SNO,WHSE_NO,IN_NO,IN_LINE,GR_DATE,EXPIRE_DATE,DATE_CODE,SKU_NO,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,COUNT_DATE,GTIN_ALO_QTY,SKU_ALO_QTY" }, $"Plt Dtls");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPltDtlsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SU_ID,SU_TYPE,IN_SNO,WHSE_NO,IN_NO,IN_LINE,GR_DATE,EXPIRE_DATE,DATE_CODE,SKU_NO,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,COUNT_DATE,GTIN_ALO_QTY,SKU_ALO_QTY" }, $"Plt Dtls");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<EditPltDtl>("Edit Plt Dtl", new Dictionary<string, object>() { {"SU_ID", args.SU_ID}, {"IN_SNO", args.IN_SNO}, {"WHSE_NO", args.WHSE_NO}, {"IN_NO", args.IN_NO}, {"IN_LINE", args.IN_LINE}, {"STK_CAT", args.STK_CAT}, {"STK_SPECIAL_IND", args.STK_SPECIAL_IND}, {"STK_SPECIAL_NO", args.STK_SPECIAL_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePltDtlResult = await Mark10Sqlexpress04.DeletePltDtl($"{data.SU_ID}", $"{data.IN_SNO}", $"{data.WHSE_NO}", $"{data.IN_NO}", $"{data.IN_LINE}", $"{data.STK_CAT}", $"{data.STK_SPECIAL_IND}", $"{data.STK_SPECIAL_NO}");
                    if (mark10Sqlexpress04DeletePltDtlResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePltDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PltDtl" });
            }
        }
    }
}
