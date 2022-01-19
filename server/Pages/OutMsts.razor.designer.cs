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
    public partial class OutMstsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> _getOutMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> getOutMstsResult
        {
            get
            {
                return _getOutMstsResult;
            }
            set
            {
                if (!object.Equals(_getOutMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOutMstsResult", NewValue = value, OldValue = _getOutMstsResult };
                    _getOutMstsResult = value;
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
            var mark10Sqlexpress04GetOutMstsResult = await Mark10Sqlexpress04.GetOutMsts();
            getOutMstsResult = mark10Sqlexpress04GetOutMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddOutMst>("Add Out Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportOutMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,OUT_NO,OUT_TYPE,OUT_DATE,OUT_TIME,PLAN_DATE,PICK_DATE,PICK_TIME,LOAD_DATE,TP_DATE,WHSE_DOOR,SHIP_NO,SHIP_LOC,SHIP_TO,SHIP_TO_NAME,SHIP_CONDITION,QUEUE,CAR_LIC,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,DD_NO,DOC_DATE,CREATEUSER,CREATEDATE,CREATETIME,OUT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Out Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportOutMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,OUT_NO,OUT_TYPE,OUT_DATE,OUT_TIME,PLAN_DATE,PICK_DATE,PICK_TIME,LOAD_DATE,TP_DATE,WHSE_DOOR,SHIP_NO,SHIP_LOC,SHIP_TO,SHIP_TO_NAME,SHIP_CONDITION,QUEUE,CAR_LIC,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,DD_NO,DOC_DATE,CREATEUSER,CREATEDATE,CREATETIME,OUT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Out Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.OutMst args)
        {
            var dialogResult = await DialogService.OpenAsync<EditOutMst>("Edit Out Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"OUT_NO", args.OUT_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteOutMstResult = await Mark10Sqlexpress04.DeleteOutMst($"{data.WHSE_NO}", $"{data.OUT_NO}");
                    if (mark10Sqlexpress04DeleteOutMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteOutMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete OutMst" });
            }
        }
    }
}
