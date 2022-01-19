using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class GroupMstsComponent
    {

   

        //public string value;
        //public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> userMsts;
        //public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl> groupDtls;
 

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
                string COPY_GROUP_ID = "NO_SUCH";
                if (selectedGroupMst != null)
                {
                    COPY_GROUP_ID = selectedGroupMst.GROUP_ID;
                }
                var dialogResult = await DialogService.OpenAsync<AddGroupMst>("Create GROUP_MST", new Dictionary<string, object>() { { "COPY_GROUP_ID", COPY_GROUP_ID }, { "USER_NAME", USER_NAME } });
                if (dialogResult != null)
                {
                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Create " + sKey[0] + " = " + sKeyValue[0]);
                    //CLIENT = mark10(192.168.165.199); Create USER_ID = 096
                    var x = (GroupMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Create GROUP_ID = {x.GROUP_ID} ");

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
            if (selectedGroupMst == null)
            {
                await SimpleDialog("no data found");
                return;
            }

            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<ViewGroupMst>("GROUP_MST", new Dictionary<string, object>() { { "GROUP_ID", selectedGroupMst.GROUP_ID } });
                await InvokeAsync(() => { StateHasChanged(); });

                if (dialogResult != null)
                {

                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Update " + sKey[0] + " = " + sKeyValue[0]);
                    var x = (GroupMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Update GROUP_ID = {x.GROUP_ID} ");

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
                if (selectedGroupMst == null)
                {
                    await SimpleDialog("no data found");
                    return;
                }
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteGroupMstResult = await Mark10Sqlexpress04.DeleteGroupMst($"{selectedGroupMst.GROUP_ID}");
                    if (mark10Sqlexpress04DeleteGroupMstResult != null)
                    {
                        // 選定的 row 已刪除, 要釋放掉
                        selectedGroupMst = null;

                        //string sRet = Globals.UserLog("06", "S010", this.Text, "Delete " + sKey[0] + " = " + sKeyValue[0]);
                        var x = (GroupMst)mark10Sqlexpress04DeleteGroupMstResult;
                        await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, $"Delete GROUP_ID = {x.GROUP_ID} ");


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
            //var mark10Sqlexpress04getGroupMstsResult = await Mark10Sqlexpress04.GetUserMsts();
            //getGroupMstsResult = mark10Sqlexpress04getGroupMstsResult;

            getGroupMstsResult = await AppDb.GroupMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.GROUP_ID).AsNoTracking().ToListAsync();

            await grid0.GoToPage(0);
            //  StateHasChanged();
        }
        protected async System.Threading.Tasks.Task ResetMainTab()
        {
            ResetValue(ref txtGROUP_ID);
            ResetValue(ref txtGROUP_NAME);
            ResetValue(ref txtOWNER_NAME);

            getGroupMstsResult = null;
            GoodMsg = null;
            //    InvokeAsync(StateHasChanged);
        }


        public string GetSQL()
        {
            var dtMST = "GROUP_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("GROUP_ID", ref txtGROUP_ID);
            strSQL += GetContains("GROUP_NAME", ref txtGROUP_NAME);
            strSQL += GetContains("OWNER_NAME", ref txtOWNER_NAME);

            return strSQL;
        }
    }
}