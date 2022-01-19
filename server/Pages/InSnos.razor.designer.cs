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
    public partial class InSnosComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.InSno> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InSno> _getInSnosResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InSno> getInSnosResult
        {
            get
            {
                return _getInSnosResult;
            }
            set
            {
                if (!object.Equals(_getInSnosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInSnosResult", NewValue = value, OldValue = _getInSnosResult };
                    _getInSnosResult = value;
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
            var mark10Sqlexpress04GetInSnosResult = await Mark10Sqlexpress04.GetInSnos();
            getInSnosResult = mark10Sqlexpress04GetInSnosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInSno>("Add In Sno", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportInSnosToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,IN_LINE,TRN_NO,TRN_LINE,SKU_NO,GTIN_NO,REQM_NO,SKU_IN_QTY,SKU_RCV_QTY,SKU_FIN_QTY,SU_ID,SU_TYPE,IN_SNO1,LOC_NO,ALO_NO,ALO_LINE,SKU_ALO_QTY,SKU_OUT_QTY,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"In Snos");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportInSnosToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,IN_LINE,TRN_NO,TRN_LINE,SKU_NO,GTIN_NO,REQM_NO,SKU_IN_QTY,SKU_RCV_QTY,SKU_FIN_QTY,SU_ID,SU_TYPE,IN_SNO1,LOC_NO,ALO_NO,ALO_LINE,SKU_ALO_QTY,SKU_OUT_QTY,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"In Snos");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.InSno args)
        {
            var dialogResult = await DialogService.OpenAsync<EditInSno>("Edit In Sno", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"IN_NO", args.IN_NO}, {"IN_LINE", args.IN_LINE}, {"SU_ID", args.SU_ID}, {"IN_SNO1", args.IN_SNO1} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteInSnoResult = await Mark10Sqlexpress04.DeleteInSno($"{data.WHSE_NO}", $"{data.IN_NO}", $"{data.IN_LINE}", $"{data.SU_ID}", $"{data.IN_SNO1}");
                    if (mark10Sqlexpress04DeleteInSnoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteInSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete InSno" });
            }
        }
    }
}
