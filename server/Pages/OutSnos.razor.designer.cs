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
    public partial class OutSnosComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutSno> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutSno> _getOutSnosResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutSno> getOutSnosResult
        {
            get
            {
                return _getOutSnosResult;
            }
            set
            {
                if (!object.Equals(_getOutSnosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOutSnosResult", NewValue = value, OldValue = _getOutSnosResult };
                    _getOutSnosResult = value;
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
            var mark10Sqlexpress04GetOutSnosResult = await Mark10Sqlexpress04.GetOutSnos();
            getOutSnosResult = mark10Sqlexpress04GetOutSnosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddOutSno>("Add Out Sno", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportOutSnosToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "OUT_SNO1,WHSE_NO,OUT_NO,OUT_LINE,SKU_NO,GTIN_NO,REQM_NO,REQM_LINE,PICKED_USER,PICKED_DATE,PICKED_QTY,SU_ID_FROM,SU_ID_TO,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Out Snos");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportOutSnosToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "OUT_SNO1,WHSE_NO,OUT_NO,OUT_LINE,SKU_NO,GTIN_NO,REQM_NO,REQM_LINE,PICKED_USER,PICKED_DATE,PICKED_QTY,SU_ID_FROM,SU_ID_TO,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Out Snos");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.OutSno args)
        {
            var dialogResult = await DialogService.OpenAsync<EditOutSno>("Edit Out Sno", new Dictionary<string, object>() { {"OUT_SNO1", args.OUT_SNO1} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteOutSnoResult = await Mark10Sqlexpress04.DeleteOutSno($"{data.OUT_SNO1}");
                    if (mark10Sqlexpress04DeleteOutSnoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteOutSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete OutSno" });
            }
        }
    }
}
