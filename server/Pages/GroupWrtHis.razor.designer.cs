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
    public partial class GroupWrtHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrtHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrtHi> _getGroupWrtHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrtHi> getGroupWrtHisResult
        {
            get
            {
                return _getGroupWrtHisResult;
            }
            set
            {
                if (!object.Equals(_getGroupWrtHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGroupWrtHisResult", NewValue = value, OldValue = _getGroupWrtHisResult };
                    _getGroupWrtHisResult = value;
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
            var mark10Sqlexpress04GetGroupWrtHisResult = await Mark10Sqlexpress04.GetGroupWrtHis();
            getGroupWrtHisResult = mark10Sqlexpress04GetGroupWrtHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportGroupWrtHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "GROUP_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Group Wrt His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportGroupWrtHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "GROUP_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Group Wrt His");

            }
        }
    }
}
