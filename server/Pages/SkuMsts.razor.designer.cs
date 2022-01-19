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
    public partial class SkuMstsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst> _getSkuMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst> getSkuMstsResult
        {
            get
            {
                return _getSkuMstsResult;
            }
            set
            {
                if (!object.Equals(_getSkuMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSkuMstsResult", NewValue = value, OldValue = _getSkuMstsResult };
                    _getSkuMstsResult = value;
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
            var mark10Sqlexpress04GetSkuMstsResult = await Mark10Sqlexpress04.GetSkuMsts();
            getSkuMstsResult = mark10Sqlexpress04GetSkuMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSkuMst>("Add Sku Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportSkuMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SKU_NO,EAN13_NO,SKU_NAME,SKU_DESC,SKU_BRAND,SKU_CAT,SKU_TYPE,SKU_INDUSTRY,SKU_GROUP,SKU_GROSS_WEIGHT,SKU_NET_WEIGHT,SKU_WEIGHT_UNIT,SKU_VOLUME,SKU_VOLUME_UNIT,GTIN_NO,GTIN_CAT,SKU_LENGTH,SKU_WIDTH,SKU_HEIGHT,SKU_DIM_UNIT,SKU_UNIT,SKU_BATCH,SKU_LOC_SIZE,SKU_LOC_HOT,MIN_SHELF_LIFE,MAX_SHELF_LIFE,VALID_DATE_FROM,VALID_DATE_TO,SKU_BLOCKED,SKU_SNO_IND,OLD_SKU_NO,STGE_CONDITION,CAT_GROUP,TP_GROUP,DIVISION,LABEL_TYPE,LABEL_FORM,SOURCE_SUPPLY,SEASON,PRODUCT_HIERACHY,CAD_IND,XSITE_STS,XDISTR_STS,XSITE_DATE,XDISTR_DATE,TAX_CLASSIFICATION,CONTENT_UNIT,NET_CONTENT,COMPARISON_PRICE,GROSS_CONTENT,DANGEROUS_IND,BATCH_IND,PERIOD_SLED,ROUND_SLED,ASSOR_TYPE,WH_SKU_GROUP,COUNTRY,LOAD_UNIT_GROUP,FREE_CHAR,ZMATERIAL,XPLANT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Sku Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportSkuMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SKU_NO,EAN13_NO,SKU_NAME,SKU_DESC,SKU_BRAND,SKU_CAT,SKU_TYPE,SKU_INDUSTRY,SKU_GROUP,SKU_GROSS_WEIGHT,SKU_NET_WEIGHT,SKU_WEIGHT_UNIT,SKU_VOLUME,SKU_VOLUME_UNIT,GTIN_NO,GTIN_CAT,SKU_LENGTH,SKU_WIDTH,SKU_HEIGHT,SKU_DIM_UNIT,SKU_UNIT,SKU_BATCH,SKU_LOC_SIZE,SKU_LOC_HOT,MIN_SHELF_LIFE,MAX_SHELF_LIFE,VALID_DATE_FROM,VALID_DATE_TO,SKU_BLOCKED,SKU_SNO_IND,OLD_SKU_NO,STGE_CONDITION,CAT_GROUP,TP_GROUP,DIVISION,LABEL_TYPE,LABEL_FORM,SOURCE_SUPPLY,SEASON,PRODUCT_HIERACHY,CAD_IND,XSITE_STS,XDISTR_STS,XSITE_DATE,XDISTR_DATE,TAX_CLASSIFICATION,CONTENT_UNIT,NET_CONTENT,COMPARISON_PRICE,GROSS_CONTENT,DANGEROUS_IND,BATCH_IND,PERIOD_SLED,ROUND_SLED,ASSOR_TYPE,WH_SKU_GROUP,COUNTRY,LOAD_UNIT_GROUP,FREE_CHAR,ZMATERIAL,XPLANT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Sku Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.SkuMst args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSkuMst>("Edit Sku Mst", new Dictionary<string, object>() { {"SKU_NO", args.SKU_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteSkuMstResult = await Mark10Sqlexpress04.DeleteSkuMst($"{data.SKU_NO}");
                    if (mark10Sqlexpress04DeleteSkuMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteSkuMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SkuMst" });
            }
        }
    }
}
