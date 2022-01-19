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
    public partial class GroupDtlsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl> _getGroupDtlsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl> getGroupDtlsResult
        {
            get
            {
                return _getGroupDtlsResult;
            }
            set
            {
                if (!object.Equals(_getGroupDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGroupDtlsResult", NewValue = value, OldValue = _getGroupDtlsResult };
                    _getGroupDtlsResult = value;
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
            var mark10Sqlexpress04GetGroupDtlsResult = await Mark10Sqlexpress04.GetGroupDtls();
            getGroupDtlsResult = mark10Sqlexpress04GetGroupDtlsResult;

            var mark10Sqlexpress04GetGroupMstsResult = await Mark10Sqlexpress04.GetGroupMsts();
            getGroupMstsResult = mark10Sqlexpress04GetGroupMstsResult;

        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddGroupDtl>("Add Group Dtl", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<EditGroupDtl>("Edit Group Dtl", new Dictionary<string, object>() { {"GROUP_ID", args.GROUP_ID}, {"USER_ID", args.USER_ID} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteGroupDtlResult = await Mark10Sqlexpress04.DeleteGroupDtl($"{data.GROUP_ID}", $"{data.USER_ID}");
                    if (mark10Sqlexpress04DeleteGroupDtlResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteGroupDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete GroupDtl" });
            }
        }
    }
}