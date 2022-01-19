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
    public partial class EquTrnLogsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog> _getEquTrnLogsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog> getEquTrnLogsResult
        {
            get
            {
                return _getEquTrnLogsResult;
            }
            set
            {
                if (!object.Equals(_getEquTrnLogsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEquTrnLogsResult", NewValue = value, OldValue = _getEquTrnLogsResult };
                    _getEquTrnLogsResult = value;
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
            var mark10Sqlexpress04GetEquTrnLogsResult = await Mark10Sqlexpress04.GetEquTrnLogs();
            getEquTrnLogsResult = mark10Sqlexpress04GetEquTrnLogsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEquTrnLog>("Add Equ Trn Log", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportEquTrnLogsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TrnDT,CmdSno,EquNo,CmdMode,CmdSts,Source,Destination,LocSize,CompleteCode,CompleteIndex,CarNo,TrnUserID,TrnDesc" }, $"Equ Trn Logs");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportEquTrnLogsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TrnDT,CmdSno,EquNo,CmdMode,CmdSts,Source,Destination,LocSize,CompleteCode,CompleteIndex,CarNo,TrnUserID,TrnDesc" }, $"Equ Trn Logs");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEquTrnLog>("Edit Equ Trn Log", new Dictionary<string, object>() { {"TrnDT", args.TrnDT}, {"CmdSno", args.CmdSno}, {"EquNo", args.EquNo}, {"CmdMode", args.CmdMode} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteEquTrnLogResult = await Mark10Sqlexpress04.DeleteEquTrnLog($"{data.TrnDT}", $"{data.CmdSno}", $"{data.EquNo}", $"{data.CmdMode}");
                    if (mark10Sqlexpress04DeleteEquTrnLogResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteEquTrnLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EquTrnLog" });
            }
        }
    }
}
