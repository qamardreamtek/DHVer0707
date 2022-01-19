﻿using System;
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
    public partial class GroupDtlHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtlHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtlHi> _getGroupDtlHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtlHi> getGroupDtlHisResult
        {
            get
            {
                return _getGroupDtlHisResult;
            }
            set
            {
                if (!object.Equals(_getGroupDtlHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGroupDtlHisResult", NewValue = value, OldValue = _getGroupDtlHisResult };
                    _getGroupDtlHisResult = value;
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
            var mark10Sqlexpress04GetGroupDtlHisResult = await Mark10Sqlexpress04.GetGroupDtlHis();
            getGroupDtlHisResult = mark10Sqlexpress04GetGroupDtlHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportGroupDtlHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "GROUP_ID,USER_ID,USER_NAME,DEPT_NAME,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Group Dtl His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportGroupDtlHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "GROUP_ID,USER_ID,USER_NAME,DEPT_NAME,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Group Dtl His");

            }
        }
    }
}
