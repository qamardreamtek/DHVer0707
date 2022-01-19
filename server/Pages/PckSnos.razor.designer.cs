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
    public partial class PckSnosComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PckSno> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PckSno> _getPckSnosResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PckSno> getPckSnosResult
        {
            get
            {
                return _getPckSnosResult;
            }
            set
            {
                if (!object.Equals(_getPckSnosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPckSnosResult", NewValue = value, OldValue = _getPckSnosResult };
                    _getPckSnosResult = value;
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
            var mark10Sqlexpress04GetPckSnosResult = await Mark10Sqlexpress04.GetPckSnos();
            getPckSnosResult = mark10Sqlexpress04GetPckSnosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPckSno>("Add Pck Sno", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPckSnosToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_ID_TO,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,IN_SNO,IN_NO,IN_LINE,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pck Snos");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPckSnosToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_ID_TO,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,IN_SNO,IN_NO,IN_LINE,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pck Snos");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PckSno args)
        {
            var dialogResult = await DialogService.OpenAsync<EditPckSno>("Edit Pck Sno", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PCK_NO", args.PCK_NO}, {"IN_SNO", args.IN_SNO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePckSnoResult = await Mark10Sqlexpress04.DeletePckSno($"{data.WHSE_NO}", $"{data.PCK_NO}", $"{data.IN_SNO}");
                    if (mark10Sqlexpress04DeletePckSnoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePckSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PckSno" });
            }
        }
    }
}
