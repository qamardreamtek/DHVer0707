using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class ProgMstsComponent
    {

        public ProgMst selectedProgMst;


        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            //  GoodMsg = " " + GetSQL();
            //string sRet = Globals.UserLog("01", "S010", this.Text, "");
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
            await ReloadMainTab();

        }


        protected async System.Threading.Tasks.Task ButtonCreateClick(MouseEventArgs args)
        {

            try
            {
                string COPY_PROG_ID = "NO_SUCH";
                if (selectedProgMst != null)
                {
                    COPY_PROG_ID = selectedProgMst.PROG_ID;
                }
                var dialogResult = await DialogService.OpenAsync<AddProgMst>("Create PROG_MST", new Dictionary<string, object>() { { "COPY_PROG_ID", COPY_PROG_ID }, { "USER_NAME", USER_NAME } });
                if (dialogResult != null)
                {
                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Create " + sKey[0] + " = " + sKeyValue[0]);
                    //CLIENT = mark10(192.168.165.199); Create USER_ID = 096
                    var x = (ProgMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Create PROG_ID = {x.PROG_ID} ");

                    await SimpleDialog("Create success:1 record");
                }
                //  await grid0.Reload();

                //  await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }


        }

        protected async System.Threading.Tasks.Task ButtonUpdateClick(MouseEventArgs args)
        {
            if (selectedProgMst == null)
            {
                await SimpleDialog("no data found");
                return;
            }

            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<EditProgMst>("Update PROG_MST", new Dictionary<string, object>() { { "PROG_ID", selectedProgMst.PROG_ID } });
                await InvokeAsync(() => { StateHasChanged(); });

                if (dialogResult != null)
                {

                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Update " + sKey[0] + " = " + sKeyValue[0]);
                    var x = (ProgMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Update PROG_ID = {x.PROG_ID} ");

                    await SimpleDialog("Update sucess");
                }

            }
            catch (Exception ex)
            {
                //  ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
                await SimpleDialog(ex.Message);
            }




            //   GoodMsg = "to update";
            //var dialogResult = await DialogService.OpenAsync<AddUserMst>("Create USER_MST", null);
            //await grid0.Reload();

            //await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async System.Threading.Tasks.Task ButtonDeleteClick(MouseEventArgs args)
        {
            //GoodMsg = "to delete";
            //var dialogResult = await DialogService.OpenAsync<AddUserMst>("Create USER_MST", null);
            //await grid0.Reload();

            //await InvokeAsync(() => { StateHasChanged(); });

            try
            {
                if (selectedProgMst == null)
                {
                    await SimpleDialog("no data found");
                    return;
                }
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteProgMstResult = await Mark10Sqlexpress04.DeleteProgMst($"{selectedProgMst.PROG_ID}");
                    if (mark10Sqlexpress04DeleteProgMstResult != null)
                    {
                        // 選定的 row 已刪除, 要釋放掉
                        selectedProgMst = null;

                        //string sRet = Globals.UserLog("06", "S010", this.Text, "Delete " + sKey[0] + " = " + sKeyValue[0]);
                        var x = (ProgMst)mark10Sqlexpress04DeleteProgMstResult;
                        await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, $"Delete PROG_ID = {x.PROG_ID} ");


                        await SimpleDialog("delete success");

                        await ReloadMainTab();
                    }
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete UserMst" });
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }

        }




        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            //var mark10Sqlexpress04getProgMstsResult = await Mark10Sqlexpress04.GetUserMsts();
            //getProgMstsResult = mark10Sqlexpress04getProgMstsResult;

            getProgMstsResult = await AppDb.ProgMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.PROG_ID).AsNoTracking().ToListAsync();

            await grid0.GoToPage(0);
            //  StateHasChanged();
        }
        protected async System.Threading.Tasks.Task ResetMainTab()
        {

            ResetValue(ref txtPROG_ID);
            ResetValue(ref txtPROG_NAME);

            getProgMstsResult = null;
            GoodMsg = null;
            //    InvokeAsync(StateHasChanged);
        }


        public string GetSQL()
        {
            var dtMST = "PROG_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("PROG_ID", ref txtPROG_ID);
            strSQL += GetContains("PROG_NAME", ref txtPROG_NAME);

            return strSQL;
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewProgMst>("PROG_MST", new Dictionary<string, object>() { { "PROG_ID", args.PROG_ID } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
