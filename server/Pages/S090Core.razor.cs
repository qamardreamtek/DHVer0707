using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class S090CoreComponent
    {
        public string GetSQL()
        {


            var dtMST = "TRANSLATE";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("TEXT", ref txtTEXT);
            return strSQL;
        }

        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            //var mark10Sqlexpress04getTranslatesResult = await Mark10Sqlexpress04.GetUserMsts();
            //getTranslatesResult = mark10Sqlexpress04getTranslatesResult;

            getTranslatesResult = await AppDb.Translates.FromSqlRaw(GetSQL()).OrderBy(a => a.TEXT).AsNoTracking().ToListAsync();

            await grid0.GoToPage(0);
            //  StateHasChanged();
        }
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
                getTranslatesResult = await AppDb.Translates.FromSqlRaw(GetSQL()).OrderBy(a => a.TEXT).AsNoTracking().ToListAsync();

                if (getTranslatesResult.Count() > 0)
                {
                    ObjTab0Selected = getTranslatesResult.First();

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }




        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }




        protected async System.Threading.Tasks.Task ButtonCreateClick()
        {
            try
            {
                var args = (Translate)ObjTab0Selected;
                string COPY_TEXT = "NO_SUCH";
                if (args != null)
                {
                    COPY_TEXT = args.TEXT;
                }

                var dialogResult = await DialogService.OpenAsync<AddTranslate>("Create TRANSLATE", new Dictionary<string, object>() { { "COPY_TEXT", COPY_TEXT }, { "USER_NAME", USER_NAME } });
                if (dialogResult != null)
                {
                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Create " + sKey[0] + " = " + sKeyValue[0]);
                    //CLIENT = mark10(192.168.165.199); Create USER_ID = 096
                    var x = (Translate)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Add TEXT = {x.TEXT} ");

                    await SimpleDialog("Create success:1 record");
                }
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }


        }

        protected async System.Threading.Tasks.Task ButtonUpdateClick()
        {
            var args = (Translate)ObjTab0Selected;
            if (args == null)
            {
                await SimpleDialog("no data found");
                return;
            }

            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<EditTranslate>("Update TRANSLATE", new Dictionary<string, object>() { { "TEXT", args.TEXT } });
                await InvokeAsync(() => { StateHasChanged(); });

                if (dialogResult != null)
                {

                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Update " + sKey[0] + " = " + sKeyValue[0]);
                    var x = (Translate)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Update TEXT = {x.TEXT} ");

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
                var args = (Translate)ObjTab0Selected;
                if (args == null)
                {
                    await SimpleDialog("Please select record to process");
                    return;
                }
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteTranslateResult = await Mark10Sqlexpress04.DeleteTranslate($"{args.TEXT}");
                    if (mark10Sqlexpress04DeleteTranslateResult != null)
                    {
                        // 選定的 row 已刪除, 要釋放掉


                        //string sRet = Globals.UserLog("06", "S010", this.Text, "Delete " + sKey[0] + " = " + sKeyValue[0]);
                        // var x = (Translates)mark10Sqlexpress04DeleteTranslateResult;
                        await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, $"Delete TEXT = {mark10Sqlexpress04DeleteTranslateResult.TEXT} ");
                        ObjTab0Selected = null;

                        await SimpleDialog("delete success");

                        await ReloadMainTab();
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





        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.Translate args)
        {

            ObjTab0Selected = args;
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.Translate args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewTranslate>("TRANSLATE", new Dictionary<string, object>() { { "TEXT", args.TEXT } });
        }


        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Translate> grid0;
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }
        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Translate> getTranslatesResult;

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            PROG_ID = "S090";
            await base.OnInitializedAsync();
        }


    }
}
