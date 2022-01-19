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
    public partial class TxLogsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.TxLog> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.TxLog> _getTxLogsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.TxLog> getTxLogsResult
        {
            get
            {
                return _getTxLogsResult;
            }
            set
            {
                if (!object.Equals(_getTxLogsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTxLogsResult", NewValue = value, OldValue = _getTxLogsResult };
                    _getTxLogsResult = value;
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
            var mark10Sqlexpress04GetTxLogsResult = await Mark10Sqlexpress04.GetTxLogs();
            getTxLogsResult = mark10Sqlexpress04GetTxLogsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTxLog>("Add Tx Log", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportTxLogsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,TX_NO,TX_LINE,STGE_TYPE,STGE_TYPE_TO,STGE_BIN,STGE_BIN_TO,SU_ID,SU_ID_TO,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,TX_USER,TX_DATE,TX_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Tx Logs");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportTxLogsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,TX_NO,TX_LINE,STGE_TYPE,STGE_TYPE_TO,STGE_BIN,STGE_BIN_TO,SU_ID,SU_ID_TO,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,TX_USER,TX_DATE,TX_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Tx Logs");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.TxLog args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTxLog>("Edit Tx Log", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"TX_NO", args.TX_NO}, {"TX_LINE", args.TX_LINE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteTxLogResult = await Mark10Sqlexpress04.DeleteTxLog($"{data.WHSE_NO}", $"{data.TX_NO}", $"{data.TX_LINE}");
                    if (mark10Sqlexpress04DeleteTxLogResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteTxLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TxLog" });
            }
        }
    }
}
