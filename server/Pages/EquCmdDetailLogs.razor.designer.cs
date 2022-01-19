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
    public partial class EquCmdDetailLogsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog> _getEquCmdDetailLogsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog> getEquCmdDetailLogsResult
        {
            get
            {
                return _getEquCmdDetailLogsResult;
            }
            set
            {
                if (!object.Equals(_getEquCmdDetailLogsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEquCmdDetailLogsResult", NewValue = value, OldValue = _getEquCmdDetailLogsResult };
                    _getEquCmdDetailLogsResult = value;
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
            var mark10Sqlexpress04GetEquCmdDetailLogsResult = await Mark10Sqlexpress04.GetEquCmdDetailLogs();
            getEquCmdDetailLogsResult = mark10Sqlexpress04GetEquCmdDetailLogsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEquCmdDetailLog>("Add Equ Cmd Detail Log", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportEquCmdDetailLogsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "LogDT,CmdSno,EquNo,CmdMode,FBank,FBayLevel,TBank,TBayLevel,TransferInfo,WriteBuffer,WritePLC,StartAction,Cycle1,Fork1,LoadPresence_On,CSTPresence_On,Cycle2,Fork2,LoadPresence_Off,CSTPresence_Off,CmdFinish,CompleteCode,PLCTimerCount,Notes" }, $"Equ Cmd Detail Logs");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportEquCmdDetailLogsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "LogDT,CmdSno,EquNo,CmdMode,FBank,FBayLevel,TBank,TBayLevel,TransferInfo,WriteBuffer,WritePLC,StartAction,Cycle1,Fork1,LoadPresence_On,CSTPresence_On,Cycle2,Fork2,LoadPresence_Off,CSTPresence_Off,CmdFinish,CompleteCode,PLCTimerCount,Notes" }, $"Equ Cmd Detail Logs");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEquCmdDetailLog>("Edit Equ Cmd Detail Log", new Dictionary<string, object>() { {"LogDT", args.LogDT}, {"CmdSno", args.CmdSno}, {"EquNo", args.EquNo}, {"CmdMode", args.CmdMode} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteEquCmdDetailLogResult = await Mark10Sqlexpress04.DeleteEquCmdDetailLog($"{data.LogDT}", $"{data.CmdSno}", $"{data.EquNo}", $"{data.CmdMode}");
                    if (mark10Sqlexpress04DeleteEquCmdDetailLogResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteEquCmdDetailLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EquCmdDetailLog" });
            }
        }
    }
}
