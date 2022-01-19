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
    public partial class CmdMstHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.CmdMstHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.CmdMstHi> _getCmdMstHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.CmdMstHi> getCmdMstHisResult
        {
            get
            {
                return _getCmdMstHisResult;
            }
            set
            {
                if (!object.Equals(_getCmdMstHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCmdMstHisResult", NewValue = value, OldValue = _getCmdMstHisResult };
                    _getCmdMstHisResult = value;
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
            var mark10Sqlexpress04GetCmdMstHisResult = await Mark10Sqlexpress04.GetCmdMstHis();
            getCmdMstHisResult = mark10Sqlexpress04GetCmdMstHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportCmdMstHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,NEW_LOC,TRACE,SU_ID,CRT_DTE,EXP_DTE,END_DTE,FIN_DTE,COMPLETECODE,REQM_NO,REQM_LINE,REF_NO,REF_LINE,PROG_ID,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Cmd Mst His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportCmdMstHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,NEW_LOC,TRACE,SU_ID,CRT_DTE,EXP_DTE,END_DTE,FIN_DTE,COMPLETECODE,REQM_NO,REQM_LINE,REF_NO,REF_LINE,PROG_ID,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Cmd Mst His");

            }
        }
    }
}
