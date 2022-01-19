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
    public partial class UserLogsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.UserLog> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserLog> _getUserLogsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserLog> getUserLogsResult
        {
            get
            {
                return _getUserLogsResult;
            }
            set
            {
                if (!object.Equals(_getUserLogsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getUserLogsResult", NewValue = value, OldValue = _getUserLogsResult };
                    _getUserLogsResult = value;
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
            var mark10Sqlexpress04GetUserLogsResult = await Mark10Sqlexpress04.GetUserLogs();
            getUserLogsResult = mark10Sqlexpress04GetUserLogsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddUserLog>("Add User Log", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportUserLogsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "LOG_DATE,LOG_TYPE,USER_ID,PROG_ID,PROG_NAME,DEPT_NAME,USER_NAME,REMARK" }, $"User Logs");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportUserLogsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "LOG_DATE,LOG_TYPE,USER_ID,PROG_ID,PROG_NAME,DEPT_NAME,USER_NAME,REMARK" }, $"User Logs");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.UserLog args)
        {
            var dialogResult = await DialogService.OpenAsync<EditUserLog>("Edit User Log", new Dictionary<string, object>() { {"LOG_DATE", args.LOG_DATE}, {"LOG_TYPE", args.LOG_TYPE}, {"USER_ID", args.USER_ID}, {"PROG_ID", args.PROG_ID} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteUserLogResult = await Mark10Sqlexpress04.DeleteUserLog($"{data.LOG_DATE}", $"{data.LOG_TYPE}", $"{data.USER_ID}", $"{data.PROG_ID}");
                    if (mark10Sqlexpress04DeleteUserLogResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteUserLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete UserLog" });
            }
        }
    }
}
