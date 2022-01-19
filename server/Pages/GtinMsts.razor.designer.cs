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
    public partial class GtinMstsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst> _getGtinMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst> getGtinMstsResult
        {
            get
            {
                return _getGtinMstsResult;
            }
            set
            {
                if (!object.Equals(_getGtinMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGtinMstsResult", NewValue = value, OldValue = _getGtinMstsResult };
                    _getGtinMstsResult = value;
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
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetGtinMstsResult = await Mark10Sqlexpress04.GetGtinMsts();
            getGtinMstsResult = mark10Sqlexpress04GetGtinMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddGtinMst>("Add Gtin Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportGtinMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SKU_NO,GTIN_UNIT,GTIN_NO,GTIN_DESC,GTIN_CAT,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_GROSS_WEIGHT,GTIN_NET_WEIGHT,GTIN_WEIGHT_UNIT,GTIN_VOLUME,GTIN_VOLUME_UNIT,GTIN_LENGTH,GTIN_WIDTH,GTIN_HEIGHT,GTIN_DIM_UNIT,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Gtin Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportGtinMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SKU_NO,GTIN_UNIT,GTIN_NO,GTIN_DESC,GTIN_CAT,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_GROSS_WEIGHT,GTIN_NET_WEIGHT,GTIN_WEIGHT_UNIT,GTIN_VOLUME,GTIN_VOLUME_UNIT,GTIN_LENGTH,GTIN_WIDTH,GTIN_HEIGHT,GTIN_DIM_UNIT,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Gtin Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.GtinMst args)
        {
            var dialogResult = await DialogService.OpenAsync<EditGtinMst>("Edit Gtin Mst", new Dictionary<string, object>() { {"SKU_NO", args.SKU_NO}, {"GTIN_UNIT", args.GTIN_UNIT} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteGtinMstResult = await Mark10Sqlexpress04.DeleteGtinMst($"{data.SKU_NO}", $"{data.GTIN_UNIT}");
                    if (mark10Sqlexpress04DeleteGtinMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteGtinMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete GtinMst" });
            }
        }
    }
}
