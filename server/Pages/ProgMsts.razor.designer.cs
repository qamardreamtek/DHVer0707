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
    public partial class ProgMstsComponent : S000Component
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> _getProgMstsResult;


        public IList<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> progMstsList
        {
            get { return new List<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(getProgMstsResult); }
        }


        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> getProgMstsResult
        {
            get
            {
                return _getProgMstsResult;
            }
            set
            {
                if (!object.Equals(_getProgMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getProgMstsResult", NewValue = value, OldValue = _getProgMstsResult };
                    _getProgMstsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "S030";
            await base.OnInitializedAsync();
        //    await Load();
        }

        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetProgMstsResult = await Mark10Sqlexpress04.GetProgMsts();
            getProgMstsResult = mark10Sqlexpress04GetProgMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            try
            {

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to create");
                AuthMsg = "authorization to create granted";

                var dialogResult = await DialogService.OpenAsync<AddProgMst>("Add Prog Mst", null);
                await grid0.Reload();

                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }

        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportProgMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "PROG_ID,PROG_NAME,PROG_TYPE,PARENT_ID,PROG_NODE,PROG_PATH,PROG_SNO,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,TW_NAME,CN_NAME,TH_NAME,VN_NAME" }, $"Prog Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportProgMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "PROG_ID,PROG_NAME,PROG_TYPE,PARENT_ID,PROG_NODE,PROG_PATH,PROG_SNO,ENABLE,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,TW_NAME,CN_NAME,TH_NAME,VN_NAME" }, $"Prog Msts");

            }
        }

        //public RadzenDh5.Models.Mark10Sqlexpress04.ProgMst selectedProgMst;
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            selectedProgMst = args;
            // return;

        }
        protected async System.Threading.Tasks.Task XXXGrid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<EditProgMst>("Edit Prog Mst", new Dictionary<string, object>() { { "PROG_ID", args.PROG_ID } });
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }

        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteProgMstResult = await Mark10Sqlexpress04.DeleteProgMst($"{data.PROG_ID}");
                    if (mark10Sqlexpress04DeleteProgMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete UserMst" });
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }
    }
}
