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
    public partial class InSnoHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi> _getInSnoHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi> getInSnoHisResult
        {
            get
            {
                return _getInSnoHisResult;
            }
            set
            {
                if (!object.Equals(_getInSnoHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInSnoHisResult", NewValue = value, OldValue = _getInSnoHisResult };
                    _getInSnoHisResult = value;
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
            var mark10Sqlexpress04GetInSnoHisResult = await Mark10Sqlexpress04.GetInSnoHis();
            getInSnoHisResult = mark10Sqlexpress04GetInSnoHisResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInSnoHi>("Add In Sno Hi", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportInSnoHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,IN_LINE,TRN_NO,TRN_LINE,SKU_NO,GTIN_NO,REQM_NO,SKU_IN_QTY,SKU_RCV_QTY,SKU_FIN_QTY,SU_ID,SU_TYPE,IN_SNO,LOC_NO,ALO_NO,ALO_LINE,SKU_ALO_QTY,SKU_OUT_QTY,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"In Sno His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportInSnoHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,IN_LINE,TRN_NO,TRN_LINE,SKU_NO,GTIN_NO,REQM_NO,SKU_IN_QTY,SKU_RCV_QTY,SKU_FIN_QTY,SU_ID,SU_TYPE,IN_SNO,LOC_NO,ALO_NO,ALO_LINE,SKU_ALO_QTY,SKU_OUT_QTY,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"In Sno His");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi args)
        {
            var dialogResult = await DialogService.OpenAsync<EditInSnoHi>("Edit In Sno Hi", new Dictionary<string, object>() { {"IN_SNO", args.IN_SNO}, {"LOG_DATE", args.LOG_DATE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteInSnoHiResult = await Mark10Sqlexpress04.DeleteInSnoHi($"{data.IN_SNO}", $"{data.LOG_DATE}");
                    if (mark10Sqlexpress04DeleteInSnoHiResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteInSnoHiException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete InSnoHi" });
            }
        }
    }
}
