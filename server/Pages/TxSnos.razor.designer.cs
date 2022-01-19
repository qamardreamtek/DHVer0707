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
    public partial class TxSnosComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.TxSno> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.TxSno> _getTxSnosResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.TxSno> getTxSnosResult
        {
            get
            {
                return _getTxSnosResult;
            }
            set
            {
                if (!object.Equals(_getTxSnosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTxSnosResult", NewValue = value, OldValue = _getTxSnosResult };
                    _getTxSnosResult = value;
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
            var mark10Sqlexpress04GetTxSnosResult = await Mark10Sqlexpress04.GetTxSnos();
            getTxSnosResult = mark10Sqlexpress04GetTxSnosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTxSno>("Add Tx Sno", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportTxSnosToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TX_NO,TX_LINE,IN_SNO" }, $"Tx Snos");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportTxSnosToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TX_NO,TX_LINE,IN_SNO" }, $"Tx Snos");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.TxSno args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTxSno>("Edit Tx Sno", new Dictionary<string, object>() { {"TX_NO", args.TX_NO}, {"TX_LINE", args.TX_LINE}, {"IN_SNO", args.IN_SNO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteTxSnoResult = await Mark10Sqlexpress04.DeleteTxSno($"{data.TX_NO}", $"{data.TX_LINE}", $"{data.IN_SNO}");
                    if (mark10Sqlexpress04DeleteTxSnoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteTxSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TxSno" });
            }
        }
    }
}
