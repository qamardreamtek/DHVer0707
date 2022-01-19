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
    public partial class OutDtlsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl> _getOutDtlsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl> getOutDtlsResult
        {
            get
            {
                return _getOutDtlsResult;
            }
            set
            {
                if (!object.Equals(_getOutDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOutDtlsResult", NewValue = value, OldValue = _getOutDtlsResult };
                    _getOutDtlsResult = value;
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
            var mark10Sqlexpress04GetOutDtlsResult = await Mark10Sqlexpress04.GetOutDtls();
            getOutDtlsResult = mark10Sqlexpress04GetOutDtlsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddOutDtl>("Add Out Dtl", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportOutDtlsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,OUT_NO,OUT_LINE,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_NO,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_OUT_QTY,SKU_UNIT,SKU_OUT_QTY,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_DESC,DD_LINE,REQM_NO,REQM_LINE,DOC_NO,DOC_LINE,MOVM_TYPE,SKU_GROUP,TP_GROUP,CREATEUSER,CREATEDATE,CREATETIME,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_ALO_QTY,SKU_FIN_QTY,START_DATE,END_DATE,OUT_USER,OUT_DATE,OUT_LOC,OUT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Out Dtls");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportOutDtlsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,OUT_NO,OUT_LINE,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_NO,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_OUT_QTY,SKU_UNIT,SKU_OUT_QTY,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_DESC,DD_LINE,REQM_NO,REQM_LINE,DOC_NO,DOC_LINE,MOVM_TYPE,SKU_GROUP,TP_GROUP,CREATEUSER,CREATEDATE,CREATETIME,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_ALO_QTY,SKU_FIN_QTY,START_DATE,END_DATE,OUT_USER,OUT_DATE,OUT_LOC,OUT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Out Dtls");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.OutDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<EditOutDtl>("Edit Out Dtl", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"OUT_NO", args.OUT_NO}, {"OUT_LINE", args.OUT_LINE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteOutDtlResult = await Mark10Sqlexpress04.DeleteOutDtl($"{data.WHSE_NO}", $"{data.OUT_NO}", $"{data.OUT_LINE}");
                    if (mark10Sqlexpress04DeleteOutDtlResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteOutDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete OutDtl" });
            }
        }
    }
}
