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
    public partial class OutSnoHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi> _getOutSnoHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi> getOutSnoHisResult
        {
            get
            {
                return _getOutSnoHisResult;
            }
            set
            {
                if (!object.Equals(_getOutSnoHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOutSnoHisResult", NewValue = value, OldValue = _getOutSnoHisResult };
                    _getOutSnoHisResult = value;
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
            var mark10Sqlexpress04GetOutSnoHisResult = await Mark10Sqlexpress04.GetOutSnoHis();
            getOutSnoHisResult = mark10Sqlexpress04GetOutSnoHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportOutSnoHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "OUT_SNO,WHSE_NO,OUT_NO,OUT_LINE,SKU_NO,GTIN_NO,REQM_NO,REQM_LINE,PICKED_USER,PICKED_DATE,PICKED_QTY,SU_ID_FROM,SU_ID_TO,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Out Sno His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportOutSnoHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "OUT_SNO,WHSE_NO,OUT_NO,OUT_LINE,SKU_NO,GTIN_NO,REQM_NO,REQM_LINE,PICKED_USER,PICKED_DATE,PICKED_QTY,SU_ID_FROM,SU_ID_TO,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Out Sno His");

            }
        }
    }
}
