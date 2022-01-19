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
    public partial class GtinMstHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi> _getGtinMstHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi> getGtinMstHisResult
        {
            get
            {
                return _getGtinMstHisResult;
            }
            set
            {
                if (!object.Equals(_getGtinMstHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGtinMstHisResult", NewValue = value, OldValue = _getGtinMstHisResult };
                    _getGtinMstHisResult = value;
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
            var mark10Sqlexpress04GetGtinMstHisResult = await Mark10Sqlexpress04.GetGtinMstHis();
            getGtinMstHisResult = mark10Sqlexpress04GetGtinMstHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportGtinMstHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SKU_NO,GTIN_UNIT,GTIN_NO,GTIN_DESC,GTIN_CAT,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_GROSS_WEIGHT,GTIN_NET_WEIGHT,GTIN_WEIGHT_UNIT,GTIN_VOLUME,GTIN_VOLUME_UNIT,GTIN_LENGTH,GTIN_WIDTH,GTIN_HEIGHT,GTIN_DIM_UNIT,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Gtin Mst His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportGtinMstHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SKU_NO,GTIN_UNIT,GTIN_NO,GTIN_DESC,GTIN_CAT,GTIN_NUMERATOR,GTIN_DENOMINATOR,GTIN_GROSS_WEIGHT,GTIN_NET_WEIGHT,GTIN_WEIGHT_UNIT,GTIN_VOLUME,GTIN_VOLUME_UNIT,GTIN_LENGTH,GTIN_WIDTH,GTIN_HEIGHT,GTIN_DIM_UNIT,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Gtin Mst His");

            }
        }
    }
}
