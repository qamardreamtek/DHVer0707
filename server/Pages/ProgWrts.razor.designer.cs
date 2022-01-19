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
    public partial class ProgWrtsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt> _getProgWrtsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt> getProgWrtsResult
        {
            get
            {
                return _getProgWrtsResult;
            }
            set
            {
                if (!object.Equals(_getProgWrtsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgWrtsResult", NewValue = value, OldValue = _getProgWrtsResult };
                    _getProgWrtsResult = value;
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
            var mark10Sqlexpress04GetProgWrtsResult = await Mark10Sqlexpress04.GetProgWrts();
            getProgWrtsResult = mark10Sqlexpress04GetProgWrtsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddProgWrt>("Add Prog Wrt", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportProgWrtsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "USER_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Prog Wrts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportProgWrtsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "USER_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Prog Wrts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt args)
        {
            var dialogResult = await DialogService.OpenAsync<EditProgWrt>("Edit Prog Wrt", new Dictionary<string, object>() { {"USER_ID", args.USER_ID}, {"PROG_ID", args.PROG_ID} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteProgWrtResult = await Mark10Sqlexpress04.DeleteProgWrt($"{data.USER_ID}", $"{data.PROG_ID}");
                    if (mark10Sqlexpress04DeleteProgWrtResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteProgWrtException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete ProgWrt" });
            }
        }
    }
}
