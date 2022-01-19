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
    public partial class EquMplcCmdHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi> _getEquMplcCmdHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi> getEquMplcCmdHisResult
        {
            get
            {
                return _getEquMplcCmdHisResult;
            }
            set
            {
                if (!object.Equals(_getEquMplcCmdHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEquMplcCmdHisResult", NewValue = value, OldValue = _getEquMplcCmdHisResult };
                    _getEquMplcCmdHisResult = value;
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
            var mark10Sqlexpress04GetEquMplcCmdHisResult = await Mark10Sqlexpress04.GetEquMplcCmdHis();
            getEquMplcCmdHisResult = mark10Sqlexpress04GetEquMplcCmdHisResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEquMplcCmdHi>("Add Equ Mplc Cmd Hi", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportEquMplcCmdHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EquNo,D0,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,D11,D12,D13,D14,LogDT" }, $"Equ Mplc Cmd His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportEquMplcCmdHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EquNo,D0,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,D11,D12,D13,D14,LogDT" }, $"Equ Mplc Cmd His");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEquMplcCmdHi>("Edit Equ Mplc Cmd Hi", new Dictionary<string, object>() { {"EquNo", args.EquNo}, {"D0", args.D0}, {"D1", args.D1}, {"D14", args.D14}, {"LogDT", args.LogDT} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteEquMplcCmdHiResult = await Mark10Sqlexpress04.DeleteEquMplcCmdHi($"{data.EquNo}", $"{data.D0}", $"{data.D1}", $"{data.D14}", $"{data.LogDT}");
                    if (mark10Sqlexpress04DeleteEquMplcCmdHiResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteEquMplcCmdHiException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EquMplcCmdHi" });
            }
        }
    }
}
