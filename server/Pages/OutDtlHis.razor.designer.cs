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
    public partial class OutDtlHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi> _getOutDtlHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi> getOutDtlHisResult
        {
            get
            {
                return _getOutDtlHisResult;
            }
            set
            {
                if (!object.Equals(_getOutDtlHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOutDtlHisResult", NewValue = value, OldValue = _getOutDtlHisResult };
                    _getOutDtlHisResult = value;
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
            var mark10Sqlexpress04GetOutDtlHisResult = await Mark10Sqlexpress04.GetOutDtlHis();
            getOutDtlHisResult = mark10Sqlexpress04GetOutDtlHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportOutDtlHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,OUT_NO,OUT_LINE,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_NO,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_OUT_QTY,SKU_UNIT,SKU_OUT_QTY,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_DESC,DD_LINE,REQM_NO,REQM_LINE,DOC_NO,DOC_LINE,MOVM_TYPE,SKU_GROUP,TP_GROUP,CREATEUSER,CREATEDATE,CREATETIME,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_ALO_QTY,SKU_FIN_QTY,START_DATE,END_DATE,OUT_USER,OUT_DATE,OUT_LOC,OUT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Out Dtl His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportOutDtlHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,OUT_NO,OUT_LINE,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_NO,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_OUT_QTY,SKU_UNIT,SKU_OUT_QTY,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,GTIN_DESC,DD_LINE,REQM_NO,REQM_LINE,DOC_NO,DOC_LINE,MOVM_TYPE,SKU_GROUP,TP_GROUP,CREATEUSER,CREATEDATE,CREATETIME,GTIN_ALO_QTY,GTIN_FIN_QTY,SKU_ALO_QTY,SKU_FIN_QTY,START_DATE,END_DATE,OUT_USER,OUT_DATE,OUT_LOC,OUT_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Out Dtl His");

            }
        }
    }
}
