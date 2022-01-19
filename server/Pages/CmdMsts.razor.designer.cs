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
    public partial class CmdMstsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> _getCmdMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> getCmdMstsResult
        {
            get
            {
                return _getCmdMstsResult;
            }
            set
            {
                if (!object.Equals(_getCmdMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCmdMstsResult", NewValue = value, OldValue = _getCmdMstsResult };
                    _getCmdMstsResult = value;
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
            var mark10Sqlexpress04GetCmdMstsResult = await Mark10Sqlexpress04.GetCmdMsts();
            getCmdMstsResult = mark10Sqlexpress04GetCmdMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddCmdMst>("Add Cmd Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportCmdMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,NEW_LOC,TRACE,SU_ID,CRT_DTE,EXP_DTE,END_DTE,FIN_DTE,COMPLETECODE,REQM_NO,REQM_LINE,REF_NO,REF_LINE,PROG_ID,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Cmd Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportCmdMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,NEW_LOC,TRACE,SU_ID,CRT_DTE,EXP_DTE,END_DTE,FIN_DTE,COMPLETECODE,REQM_NO,REQM_LINE,REF_NO,REF_LINE,PROG_ID,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Cmd Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.CmdMst args)
        {
            var dialogResult = await DialogService.OpenAsync<EditCmdMst>("Edit Cmd Mst", new Dictionary<string, object>() { {"CMD_DATE", args.CMD_DATE}, {"CMD_SNO", args.CMD_SNO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteCmdMstResult = await Mark10Sqlexpress04.DeleteCmdMst($"{data.CMD_DATE}", $"{data.CMD_SNO}");
                    if (mark10Sqlexpress04DeleteCmdMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteCmdMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete CmdMst" });
            }
        }
    }
}
