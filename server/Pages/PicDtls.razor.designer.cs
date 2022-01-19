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
    public partial class PicDtlsComponent : ComponentBase
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
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> _getPicDtlsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> getPicDtlsResult
        {
            get
            {
                return _getPicDtlsResult;
            }
            set
            {
                if (!object.Equals(_getPicDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPicDtlsResult", NewValue = value, OldValue = _getPicDtlsResult };
                    _getPicDtlsResult = value;
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
            var mark10Sqlexpress04GetPicDtlsResult = await Mark10Sqlexpress04.GetPicDtls();
            getPicDtlsResult = mark10Sqlexpress04GetPicDtlsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPicDtl>("Add Pic Dtl", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPicDtlsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PIC_NO,PIC_LINE,STGE_TYPE,STGE_BIN,SU_ID,PLANT,STGE_LOC,SKU_NO,BATCH_NO,COUNT_USER,COUNT_QTY,COUNT_UNIT,WMSLOC_IND,REASON1,REASON2,REASON3,REASON4,REASON5,REASON6,REASON7,REASON8,REASON9,REASON10,BATCH_IND,SERIAL_IND,START_DATE,END_DATE,PIC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pic Dtls");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPicDtlsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PIC_NO,PIC_LINE,STGE_TYPE,STGE_BIN,SU_ID,PLANT,STGE_LOC,SKU_NO,BATCH_NO,COUNT_USER,COUNT_QTY,COUNT_UNIT,WMSLOC_IND,REASON1,REASON2,REASON3,REASON4,REASON5,REASON6,REASON7,REASON8,REASON9,REASON10,BATCH_IND,SERIAL_IND,START_DATE,END_DATE,PIC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pic Dtls");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PicDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<EditPicDtl>("Edit Pic Dtl", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PIC_NO", args.PIC_NO}, {"PIC_LINE", args.PIC_LINE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePicDtlResult = await Mark10Sqlexpress04.DeletePicDtl($"{data.WHSE_NO}", $"{data.PIC_NO}", $"{data.PIC_LINE}");
                    if (mark10Sqlexpress04DeletePicDtlResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePicDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PicDtl" });
            }
        }
    }
}
