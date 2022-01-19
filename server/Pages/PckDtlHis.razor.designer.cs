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
    public partial class PckDtlHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi> _getPckDtlHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi> getPckDtlHisResult
        {
            get
            {
                return _getPckDtlHisResult;
            }
            set
            {
                if (!object.Equals(_getPckDtlHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPckDtlHisResult", NewValue = value, OldValue = _getPckDtlHisResult };
                    _getPckDtlHisResult = value;
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
            var mark10Sqlexpress04GetPckDtlHisResult = await Mark10Sqlexpress04.GetPckDtlHis();
            getPckDtlHisResult = mark10Sqlexpress04GetPckDtlHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPckDtlHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_ID_TO,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_USER,PCK_DATE,PCK_STS,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Pck Dtl His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPckDtlHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PCK_NO,PCK_LINE,SU_ID,SU_ID_TO,SU_TYPE,LOC_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,ALO_NO,ALO_LINE,GTIN_UNIT,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_UNIT,SKU_ALO_QTY,SKU_FIN_QTY,PCK_USER,PCK_DATE,PCK_STS,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Pck Dtl His");

            }
        }
    }
}
