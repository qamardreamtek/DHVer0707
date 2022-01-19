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
    public partial class PltDtlHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi> _getPltDtlHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi> getPltDtlHisResult
        {
            get
            {
                return _getPltDtlHisResult;
            }
            set
            {
                if (!object.Equals(_getPltDtlHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPltDtlHisResult", NewValue = value, OldValue = _getPltDtlHisResult };
                    _getPltDtlHisResult = value;
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
            var mark10Sqlexpress04GetPltDtlHisResult = await Mark10Sqlexpress04.GetPltDtlHis();
            getPltDtlHisResult = mark10Sqlexpress04GetPltDtlHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPltDtlHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SU_ID,SU_TYPE,IN_SNO,WHSE_NO,IN_NO,IN_LINE,GR_DATE,EXPIRE_DATE,DATE_CODE,SKU_NO,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,COUNT_DATE,GTIN_ALO_QTY,SKU_ALO_QTY,LOG_DATE,LOG_USER" }, $"Plt Dtl His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPltDtlHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SU_ID,SU_TYPE,IN_SNO,WHSE_NO,IN_NO,IN_LINE,GR_DATE,EXPIRE_DATE,DATE_CODE,SKU_NO,PLANT,STGE_LOC,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,COUNT_DATE,GTIN_ALO_QTY,SKU_ALO_QTY,LOG_DATE,LOG_USER" }, $"Plt Dtl His");

            }
        }
    }
}
