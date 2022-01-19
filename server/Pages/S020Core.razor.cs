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
    public partial class S020CoreComponent
    {




        public async Task FixGrid0GotoPage0Async()
        {
            SwitchToTab0();
            await grid0.GoToPage(0);
        }
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                // 在 grid0 的 data 更新之前, 先調用 FixGrid0GotoPage0Async
                await FixGrid0GotoPage0Async();
                getGroupMstsResult = await AppDb.GroupMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.GROUP_ID).AsNoTracking().ToListAsync();
                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getGroupMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getGroupMstsResult.First();

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected async Task ButtonQueryClick()
        {
            await QueryMstAsync();
        }

        protected async System.Threading.Tasks.Task ButtonCreateClick()
        {

            try
            {
                var args = (GroupMst)ObjTab0Selected;
                string COPY_GROUP_ID = "NO_SUCH";
                if (args != null)
                {
                    COPY_GROUP_ID = args.GROUP_ID;
                }
                var dialogResult = await DialogService.OpenAsync<AddGroupMst>("Create GROUP_MST", new Dictionary<string, object>() { { "COPY_GROUP_ID", COPY_GROUP_ID }, { "USER_NAME", USER_NAME } });
                if (dialogResult != null)
                {
                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Create " + sKey[0] + " = " + sKeyValue[0]);
                    //CLIENT = mark10(192.168.165.199); Create USER_ID = 096
                    var x = (GroupMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Create GROUP_ID = {x.GROUP_ID} ");

                    await SimpleDialog("Create success:1 record");
                    await QueryMstAsync();
                }
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }


        }

        protected async System.Threading.Tasks.Task ButtonUpdateClick()
        {
            var args = (GroupMst)ObjTab0Selected;
            if (args == null)
            {
                await SimpleDialog("no data found");
                return;
            }

            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<EditGroupMst>("Update GROUP_MST", new Dictionary<string, object>() { { "GROUP_ID", args.GROUP_ID } });
                await InvokeAsync(() => { StateHasChanged(); });

                if (dialogResult != null)
                {

                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Update " + sKey[0] + " = " + sKeyValue[0]);
                    var x = (GroupMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Update GROUP_ID = {x.GROUP_ID} ");

                    await SimpleDialog("Update sucess");
                    await QueryMstAsync();
                }

            }
            catch (Exception ex)
            {
                //  ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
                await SimpleDialog(ex.Message);
            }

        }
        protected async System.Threading.Tasks.Task ButtonDeleteClick()
        {

            try
            {
                var args = (GroupMst)ObjTab0Selected;
                if (args == null)
                {
                    await SimpleDialog("no data found");
                    return;
                }
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteGroupMstResult = await Mark10Sqlexpress04.DeleteGroupMst($"{args.GROUP_ID}");
                    if (mark10Sqlexpress04DeleteGroupMstResult != null)
                    {
                        // 選定的 row 已刪除, 要釋放掉
                        args = null;

                        //string sRet = Globals.UserLog("06", "S010", this.Text, "Delete " + sKey[0] + " = " + sKeyValue[0]);
                        var x = (GroupMst)mark10Sqlexpress04DeleteGroupMstResult;
                        await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, $"Delete GROUP_ID = {x.GROUP_ID} ");


                        await SimpleDialog("delete success");
                        await QueryMstAsync();
                    }
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete UserMst" });
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }

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