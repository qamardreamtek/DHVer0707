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
    public partial class LocMstHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi> _getLocMstHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi> getLocMstHisResult
        {
            get
            {
                return _getLocMstHisResult;
            }
            set
            {
                if (!object.Equals(_getLocMstHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocMstHisResult", NewValue = value, OldValue = _getLocMstHisResult };
                    _getLocMstHisResult = value;
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
            var mark10Sqlexpress04GetLocMstHisResult = await Mark10Sqlexpress04.GetLocMstHis();
            getLocMstHisResult = mark10Sqlexpress04GetLocMstHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportLocMstHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,LOC_NO,LOC_NAME,ZONE_NO,LANE_NO,EQU_NO,ROW_X,BAY_Y,LVL_Z,LOC_ASRS,LOC_STS,LOC_OSTS,AVAIL,DEPTH,LOC_SIZE,LOC_TYPE,LOC_ABC,LOC_SPECIAL,LOC_HOT,LOC_RCV,LOC_STOCK,LOC_QC,LOC_NG,LOC_RETURN,LOC_SORT,LOC_PICK,LOC_STAGE,LOC_DEL,SU_ID,COUNT_DATE,REMARK,TRN_USER,TRN_DATE,LOG_DATE,LOG_USER" }, $"Loc Mst His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportLocMstHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,LOC_NO,LOC_NAME,ZONE_NO,LANE_NO,EQU_NO,ROW_X,BAY_Y,LVL_Z,LOC_ASRS,LOC_STS,LOC_OSTS,AVAIL,DEPTH,LOC_SIZE,LOC_TYPE,LOC_ABC,LOC_SPECIAL,LOC_HOT,LOC_RCV,LOC_STOCK,LOC_QC,LOC_NG,LOC_RETURN,LOC_SORT,LOC_PICK,LOC_STAGE,LOC_DEL,SU_ID,COUNT_DATE,REMARK,TRN_USER,TRN_DATE,LOG_DATE,LOG_USER" }, $"Loc Mst His");

            }
        }
    }
}
