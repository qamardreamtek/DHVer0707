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
    public partial class PckMstsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PckMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PckMst> _getPckMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PckMst> getPckMstsResult
        {
            get
            {
                return _getPckMstsResult;
            }
            set
            {
                if (!object.Equals(_getPckMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPckMstsResult", NewValue = value, OldValue = _getPckMstsResult };
                    _getPckMstsResult = value;
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
            var mark10Sqlexpress04GetPckMstsResult = await Mark10Sqlexpress04.GetPckMsts();
            getPckMstsResult = mark10Sqlexpress04GetPckMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPckMst>("Add Pck Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPckMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PCK_NO,PCK_TYPE,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,STN_NO,START_DATE,END_DATE,PCK_USER,PCK_DATE,PCK_STS,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pck Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPckMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PCK_NO,PCK_TYPE,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,CMD_DATE,CMD_SNO,STN_NO,START_DATE,END_DATE,PCK_USER,PCK_DATE,PCK_STS,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pck Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PckMst args)
        {
            var dialogResult = await DialogService.OpenAsync<EditPckMst>("Edit Pck Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PCK_NO", args.PCK_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePckMstResult = await Mark10Sqlexpress04.DeletePckMst($"{data.WHSE_NO}", $"{data.PCK_NO}");
                    if (mark10Sqlexpress04DeletePckMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePckMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PckMst" });
            }
        }
    }
}
