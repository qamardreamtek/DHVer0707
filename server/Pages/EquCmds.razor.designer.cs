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
    public partial class EquCmdsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.EquCmd> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquCmd> _getEquCmdsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.EquCmd> getEquCmdsResult
        {
            get
            {
                return _getEquCmdsResult;
            }
            set
            {
                if (!object.Equals(_getEquCmdsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEquCmdsResult", NewValue = value, OldValue = _getEquCmdsResult };
                    _getEquCmdsResult = value;
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
            var mark10Sqlexpress04GetEquCmdsResult = await Mark10Sqlexpress04.GetEquCmds();
            getEquCmdsResult = mark10Sqlexpress04GetEquCmdsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEquCmd>("Add Equ Cmd", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportEquCmdsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CmdSno,EquNo,CmdMode,CmdSts,Source,Destination,LocSize,Priority,RCVDT,ACTDT,CSTPresenceDT,ENDDT,CompleteCode,CompleteIndex,CarNo,ReNewFlag,FromInfo,PLT_ID" }, $"Equ Cmds");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportEquCmdsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CmdSno,EquNo,CmdMode,CmdSts,Source,Destination,LocSize,Priority,RCVDT,ACTDT,CSTPresenceDT,ENDDT,CompleteCode,CompleteIndex,CarNo,ReNewFlag,FromInfo,PLT_ID" }, $"Equ Cmds");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.EquCmd args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEquCmd>("Edit Equ Cmd", new Dictionary<string, object>() { {"CmdSno", args.CmdSno}, {"EquNo", args.EquNo}, {"CmdMode", args.CmdMode}, {"Source", args.Source} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteEquCmdResult = await Mark10Sqlexpress04.DeleteEquCmd($"{data.CmdSno}", $"{data.EquNo}", $"{data.CmdMode}", $"{data.Source}");
                    if (mark10Sqlexpress04DeleteEquCmdResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteEquCmdException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EquCmd" });
            }
        }
    }
}
