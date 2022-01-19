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
    public partial class InDtlsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.InDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InDtl> _getInDtlsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InDtl> getInDtlsResult
        {
            get
            {
                return _getInDtlsResult;
            }
            set
            {
                if (!object.Equals(_getInDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInDtlsResult", NewValue = value, OldValue = _getInDtlsResult };
                    _getInDtlsResult = value;
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
            var mark10Sqlexpress04GetInDtlsResult = await Mark10Sqlexpress04.GetInDtls();
            getInDtlsResult = mark10Sqlexpress04GetInDtlsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInDtl>("Add In Dtl", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportInDtlsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,IN_LINE,MOVM_TYPE,TRN_NO,TRN_LINE,ITEM_STS,SKU_NO,GTIN_NO,REQM_NO,REQM_TYPE,STK_SEGMENT,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,EXPIRE_DATE,INSP_LOT,GR_DATE,SKU_IN_QTY,SKU_ALO_QTY,SKU_FIN_QTY,SKU_UNIT,GTIN_IN_QTY,GTIN_ALO_QTY,GTIN_FIN_QTY,GTIN_UNIT,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,TO_NO,TO_DATE,TO_SKU_QTY,TO_GTIN_QTY,DATE_CODE,START_DATE,END_DATE,IN_USER,IN_DATE,IN_LOC,IN_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"In Dtls");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportInDtlsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,IN_LINE,MOVM_TYPE,TRN_NO,TRN_LINE,ITEM_STS,SKU_NO,GTIN_NO,REQM_NO,REQM_TYPE,STK_SEGMENT,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,EXPIRE_DATE,INSP_LOT,GR_DATE,SKU_IN_QTY,SKU_ALO_QTY,SKU_FIN_QTY,SKU_UNIT,GTIN_IN_QTY,GTIN_ALO_QTY,GTIN_FIN_QTY,GTIN_UNIT,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,TO_NO,TO_DATE,TO_SKU_QTY,TO_GTIN_QTY,DATE_CODE,START_DATE,END_DATE,IN_USER,IN_DATE,IN_LOC,IN_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"In Dtls");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.InDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<EditInDtl>("Edit In Dtl", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"IN_NO", args.IN_NO}, {"IN_LINE", args.IN_LINE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteInDtlResult = await Mark10Sqlexpress04.DeleteInDtl($"{data.WHSE_NO}", $"{data.IN_NO}", $"{data.IN_LINE}");
                    if (mark10Sqlexpress04DeleteInDtlResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteInDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete InDtl" });
            }
        }
    }
}
