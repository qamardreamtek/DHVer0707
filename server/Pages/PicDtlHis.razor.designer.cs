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
    public partial class PicDtlHisComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi> _getPicDtlHisResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi> getPicDtlHisResult
        {
            get
            {
                return _getPicDtlHisResult;
            }
            set
            {
                if (!object.Equals(_getPicDtlHisResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPicDtlHisResult", NewValue = value, OldValue = _getPicDtlHisResult };
                    _getPicDtlHisResult = value;
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
            var mark10Sqlexpress04GetPicDtlHisResult = await Mark10Sqlexpress04.GetPicDtlHis();
            getPicDtlHisResult = mark10Sqlexpress04GetPicDtlHisResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPicDtlHisToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PIC_NO,PIC_LINE,STGE_TYPE,STGE_BIN,SU_ID,PLANT,STGE_LOC,SKU_NO,BATCH_NO,COUNT_USER,COUNT_QTY,COUNT_UNIT,WMSLOC_IND,REASON1,REASON2,REASON3,REASON4,REASON5,REASON6,REASON7,REASON8,REASON9,REASON10,BATCH_IND,SERIAL_IND,START_DATE,END_DATE,PIC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Pic Dtl His");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPicDtlHisToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PIC_NO,PIC_LINE,STGE_TYPE,STGE_BIN,SU_ID,PLANT,STGE_LOC,SKU_NO,BATCH_NO,COUNT_USER,COUNT_QTY,COUNT_UNIT,WMSLOC_IND,REASON1,REASON2,REASON3,REASON4,REASON5,REASON6,REASON7,REASON8,REASON9,REASON10,BATCH_IND,SERIAL_IND,START_DATE,END_DATE,PIC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,LOG_DATE,LOG_USER" }, $"Pic Dtl His");

            }
        }
    }
}
