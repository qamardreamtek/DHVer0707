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
    public partial class SkuSutsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut> _getSkuSutsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut> getSkuSutsResult
        {
            get
            {
                return _getSkuSutsResult;
            }
            set
            {
                if (!object.Equals(_getSkuSutsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSkuSutsResult", NewValue = value, OldValue = _getSkuSutsResult };
                    _getSkuSutsResult = value;
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
            var mark10Sqlexpress04GetSkuSutsResult = await Mark10Sqlexpress04.GetSkuSuts();
            getSkuSutsResult = mark10Sqlexpress04GetSkuSutsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSkuSut>("Add Sku Sut", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportSkuSutsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,SKU_NO,GTIN_UNIT,SKU_NAME,SKU_DESC,SKU_UNIT,SU_TYPE,SU_UNIT,SU_LENGTH,SU_WIDTH,SU_HEIGHT,SU_DIM_UNIT,SKU_MAX_QTY,GTIN_NO,GTIN_MAX_QTY,GTIN_LAYER,GTIN_LAYER_QTY,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Sku Suts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportSkuSutsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,SKU_NO,GTIN_UNIT,SKU_NAME,SKU_DESC,SKU_UNIT,SU_TYPE,SU_UNIT,SU_LENGTH,SU_WIDTH,SU_HEIGHT,SU_DIM_UNIT,SKU_MAX_QTY,GTIN_NO,GTIN_MAX_QTY,GTIN_LAYER,GTIN_LAYER_QTY,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Sku Suts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.SkuSut args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSkuSut>("Edit Sku Sut", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"SKU_NO", args.SKU_NO}, {"GTIN_UNIT", args.GTIN_UNIT}, {"SU_TYPE", args.SU_TYPE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteSkuSutResult = await Mark10Sqlexpress04.DeleteSkuSut($"{data.WHSE_NO}", $"{data.SKU_NO}", $"{data.GTIN_UNIT}", $"{data.SU_TYPE}");
                    if (mark10Sqlexpress04DeleteSkuSutResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteSkuSutException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SkuSut" });
            }
        }
    }
}
