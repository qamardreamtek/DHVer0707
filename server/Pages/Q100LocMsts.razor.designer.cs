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
    public partial class Q100LocMstsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> grid0;

        //IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> _getLocMstsResult;


        // NOTE by Mark, 2021-04-09
        [Inject]
        RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }


  
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> getLocMstsResult;

        protected override void OnInitialized()
        {
            getLocMstsResult = AppDb.LocMsts.ToList();

        }


        //protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> getLocMstsResult
        //{
        //    get
        //    {
        //        return _getLocMstsResult;
        //    }
        //    set
        //    {
        //        if (!object.Equals(_getLocMstsResult, value))
        //        {
        //            var args = new PropertyChangedEventArgs(){ Name = "getLocMstsResult", NewValue = value, OldValue = _getLocMstsResult };
        //            _getLocMstsResult = value;
        //            OnPropertyChanged(args);
        //            Reload();
        //        }
        //    }
        //}

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
            var mark10Sqlexpress04GetLocMstsResult = await Mark10Sqlexpress04.GetLocMsts();
            getLocMstsResult = mark10Sqlexpress04GetLocMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddLocMst>("Add Loc Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportLocMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,LOC_NO,LOC_NAME,ZONE_NO,LANE_NO,EQU_NO,ROW_X,BAY_Y,LVL_Z,LOC_ASRS,LOC_STS,LOC_OSTS,AVAIL,DEPTH,LOC_SIZE,LOC_TYPE,LOC_ABC,LOC_SPECIAL,LOC_HOT,LOC_RCV,LOC_STOCK,LOC_QC,LOC_NG,LOC_RETURN,LOC_SORT,LOC_PICK,LOC_STAGE,LOC_DEL,SU_ID,COUNT_DATE,REMARK,TRN_USER,TRN_DATE" }, $"Loc Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportLocMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,LOC_NO,LOC_NAME,ZONE_NO,LANE_NO,EQU_NO,ROW_X,BAY_Y,LVL_Z,LOC_ASRS,LOC_STS,LOC_OSTS,AVAIL,DEPTH,LOC_SIZE,LOC_TYPE,LOC_ABC,LOC_SPECIAL,LOC_HOT,LOC_RCV,LOC_STOCK,LOC_QC,LOC_NG,LOC_RETURN,LOC_SORT,LOC_PICK,LOC_STAGE,LOC_DEL,SU_ID,COUNT_DATE,REMARK,TRN_USER,TRN_DATE" }, $"Loc Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.LocMst args)
        {
            var dialogResult = await DialogService.OpenAsync<EditLocMst>("Edit Loc Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"LOC_NO", args.LOC_NO}, {"ZONE_NO", args.ZONE_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteLocMstResult = await Mark10Sqlexpress04.DeleteLocMst($"{data.WHSE_NO}", $"{data.LOC_NO}", $"{data.ZONE_NO}");
                    if (mark10Sqlexpress04DeleteLocMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteLocMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LocMst" });
            }
        }
    }
}
