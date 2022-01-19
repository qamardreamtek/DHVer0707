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
    public partial class EquStsLogsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog> _getEquStsLogsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog> getEquStsLogsResult
        {
            get
            {
                return _getEquStsLogsResult;
            }
            set
            {
                if (!object.Equals(_getEquStsLogsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEquStsLogsResult", NewValue = value, OldValue = _getEquStsLogsResult };
                    _getEquStsLogsResult = value;
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
            var mark10Sqlexpress04GetEquStsLogsResult = await Mark10Sqlexpress04.GetEquStsLogs();
            getEquStsLogsResult = mark10Sqlexpress04GetEquStsLogsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEquStsLog>("Add Equ Sts Log", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportEquStsLogsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EquNo,CarNo,StrDT,EndDT,EquSts,TotalSecs" }, $"Equ Sts Logs");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportEquStsLogsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EquNo,CarNo,StrDT,EndDT,EquSts,TotalSecs" }, $"Equ Sts Logs");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEquStsLog>("Edit Equ Sts Log", new Dictionary<string, object>() { {"EquNo", args.EquNo}, {"CarNo", args.CarNo}, {"StrDT", args.StrDT}, {"EquSts", args.EquSts} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteEquStsLogResult = await Mark10Sqlexpress04.DeleteEquStsLog($"{data.EquNo}", $"{data.CarNo}", $"{data.StrDT}", $"{data.EquSts}");
                    if (mark10Sqlexpress04DeleteEquStsLogResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteEquStsLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EquStsLog" });
            }
        }
    }
}
