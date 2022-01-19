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
    public partial class LocDtlsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl> _getLocDtlsResult;


        // NOTE by Mark
        //public  IList<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl> locDtlsList
        //{
        //    get { return new List<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>(getLocDtlsResult); }
        //}
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList { get; set; }



        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl> getLocDtlsResult
        {
            get
            {
                return _getLocDtlsResult;
            }
            set
            {
                if (!object.Equals(_getLocDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocDtlsResult", NewValue = value, OldValue = _getLocDtlsResult };
                    _getLocDtlsResult = value;
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
            var mark10Sqlexpress04GetLocDtlsResult = await Mark10Sqlexpress04.GetLocDtls();
            getLocDtlsResult = mark10Sqlexpress04GetLocDtlsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddLocDtl>("Add Loc Dtl", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            var brief = "DOING C010";
            var msg = "ButtonQuertyClick";
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = brief, Detail = msg, Duration = 4000 });


            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        {
            var brief = "DOING C010";
            var msg = "ButtonExecuteClick";
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = brief, Detail = msg, Duration = 4000 });


            await InvokeAsync(() => { StateHasChanged(); });
        }


        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportLocDtlsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_ALO_QTY,SKU_ALO_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Loc Dtls");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportLocDtlsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,STGE_TYPE,STGE_BIN,SU_ID,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,GTIN_NUMERATOR,GTIN_DENOMINATOR,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_ALO_QTY,SKU_ALO_QTY,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Loc Dtls");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.LocDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<EditLocDtl>("Edit Loc Dtl", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"SU_ID", args.SU_ID}, {"PLANT", args.PLANT}, {"STGE_LOC", args.STGE_LOC}, {"SKU_NO", args.SKU_NO}, {"BATCH_NO", args.BATCH_NO}, {"STK_CAT", args.STK_CAT}, {"STK_SPECIAL_IND", args.STK_SPECIAL_IND}, {"STK_SPECIAL_NO", args.STK_SPECIAL_NO}, {"GTIN_UNIT", args.GTIN_UNIT} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteLocDtlResult = await Mark10Sqlexpress04.DeleteLocDtl($"{data.WHSE_NO}", $"{data.SU_ID}", $"{data.PLANT}", $"{data.STGE_LOC}", $"{data.SKU_NO}", $"{data.BATCH_NO}", $"{data.STK_CAT}", $"{data.STK_SPECIAL_IND}", $"{data.STK_SPECIAL_NO}", $"{data.GTIN_UNIT}");
                    if (mark10Sqlexpress04DeleteLocDtlResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteLocDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LocDtl" });
            }
        }
    }
}
