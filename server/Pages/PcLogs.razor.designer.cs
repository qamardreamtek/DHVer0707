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
    public partial class PcLogsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PcLog> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PcLog> _getPcLogsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PcLog> getPcLogsResult
        {
            get
            {
                return _getPcLogsResult;
            }
            set
            {
                if (!object.Equals(_getPcLogsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPcLogsResult", NewValue = value, OldValue = _getPcLogsResult };
                    _getPcLogsResult = value;
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
            var mark10Sqlexpress04GetPcLogsResult = await Mark10Sqlexpress04.GetPcLogs();
            getPcLogsResult = mark10Sqlexpress04GetPcLogsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPcLog>("Add Pc Log", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPcLogsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PC_NO,PC_LINE,SU_ID,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,SKU_UNIT,SKU_QTY,MOVM_TYPE,STK_CAT_TO,STK_SPECIAL_IND_TO,STK_SPECIAL_NO_TO,SKU_QTY_TO,PC_USER,PC_DATE,PC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pc Logs");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPcLogsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PC_NO,PC_LINE,SU_ID,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,SKU_UNIT,SKU_QTY,MOVM_TYPE,STK_CAT_TO,STK_SPECIAL_IND_TO,STK_SPECIAL_NO_TO,SKU_QTY_TO,PC_USER,PC_DATE,PC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pc Logs");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PcLog args)
        {
            var dialogResult = await DialogService.OpenAsync<EditPcLog>("Edit Pc Log", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PC_NO", args.PC_NO}, {"PC_LINE", args.PC_LINE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePcLogResult = await Mark10Sqlexpress04.DeletePcLog($"{data.WHSE_NO}", $"{data.PC_NO}", $"{data.PC_LINE}");
                    if (mark10Sqlexpress04DeletePcLogResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePcLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PcLog" });
            }
        }
    }
}
