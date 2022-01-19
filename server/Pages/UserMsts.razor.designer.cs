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
using RadzenDh5.Data;

namespace RadzenDh5.Pages
{
    public partial class UserMstsComponent : S000Component
    {


        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }



        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> grid0;

        public Object grid0Bind;
        public RadzenDh5.Models.Mark10Sqlexpress04.UserMst grid0BindEntity;



        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> _getUserMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> getUserMstsResult
        {
            get
            {
                return _getUserMstsResult;
            }
            set
            {
                if (!object.Equals(_getUserMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getUserMstsResult", NewValue = value, OldValue = _getUserMstsResult };
                    _getUserMstsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public string GetSQL()
        {
            //DhGlobals.PurifyFilterValue(ref txtUSER_ID);
            //DhGlobals.PurifyFilterValue(ref txtUSER_NAME);
            //DhGlobals.PurifyFilterValue(ref txtDEPT_NAME);

            var dtMST = "USER_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += DhGlobals.GetSQLContains("USER_ID", ref txtUSER_ID);
            strSQL += DhGlobals.GetSQLContains("USER_NAME", ref txtUSER_NAME);
            strSQL += DhGlobals.GetSQLContains("DEPT_NAME", ref txtDEPT_NAME);

            //if (txtUSER_ID != "") strSQL += string.Format(@" and USER_ID like '%{0}%'", txtUSER_ID.ToUpper());
            //if (txtUSER_NAME != "") strSQL += string.Format(@" and USER_NAME like '%{0}%'", txtUSER_NAME.ToUpper());
            //if (txtDEPT_NAME != "") strSQL += string.Format(@" and DEPT_NAME like '%{0}%'", txtDEPT_NAME.ToUpper());

            return strSQL;
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            PROG_ID = "S010";
            await base.OnInitializedAsync();
            //   await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetUserMstsResult = await Mark10Sqlexpress04.GetUserMsts();
            getUserMstsResult = mark10Sqlexpress04GetUserMstsResult;
        }

        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            //var mark10Sqlexpress04GetUserMstsResult = await Mark10Sqlexpress04.GetUserMsts();
            //getUserMstsResult = mark10Sqlexpress04GetUserMstsResult;

            getUserMstsResult = await AppDb.UserMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.USER_ID).AsNoTracking().ToListAsync();

            await grid0.GoToPage(0);
            //  StateHasChanged();
        }
        protected async System.Threading.Tasks.Task ResetMainTab()
        {
            DhGlobals.ResetValue(ref txtUSER_ID);
            DhGlobals.ResetValue(ref txtUSER_NAME);
            DhGlobals.ResetValue(ref txtDEPT_NAME);
            getUserMstsResult = null;
            GoodMsg = null;
            //    InvokeAsync(StateHasChanged);
        }

   

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
                string COPY_USER_ID = "NO_SUCH";
                if (selectedUserMst != null)
                {
                    COPY_USER_ID = selectedUserMst.USER_ID;
                }

                var dialogResult = await DialogService.OpenAsync<AddUserMst>("Create USER_MST", new Dictionary<string, object>() { { "COPY_USER_ID", COPY_USER_ID }, { "USER_NAME", USER_NAME } });
                if (dialogResult != null)
                {
                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Create " + sKey[0] + " = " + sKeyValue[0]);
                    //CLIENT = mark10(192.168.165.199); Create USER_ID = 096
                    var x = (UserMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Create USER_ID = {x.USER_ID} ");

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
            if (selectedUserMst == null)
            {
                await SimpleDialog("no data found");
                return;
            }

            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<EditUserMst>("Edit User Mst", new Dictionary<string, object>() { { "COPY_USER_ID", selectedUserMst.USER_ID } });
                await InvokeAsync(() => { StateHasChanged(); });

                if (dialogResult != null)
                {

                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Update " + sKey[0] + " = " + sKeyValue[0]);
                    var x = (UserMst)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Update USER_ID = {x.USER_ID} ");

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
                if (selectedUserMst == null)
                {
                    await SimpleDialog("Please select record to process");
                    return;
                }
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteUserMstResult = await Mark10Sqlexpress04.DeleteUserMst($"{selectedUserMst.USER_ID}");
                    if (mark10Sqlexpress04DeleteUserMstResult != null)
                    {
                        // 選定的 row 已刪除, 要釋放掉
                        selectedUserMst = null;

                        //string sRet = Globals.UserLog("06", "S010", this.Text, "Delete " + sKey[0] + " = " + sKeyValue[0]);
                        var x = (UserMst)mark10Sqlexpress04DeleteUserMstResult;
                        await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, $"Delete USER_ID = {x.USER_ID} ");


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



        public RadzenDh5.Models.Mark10Sqlexpress04.UserMst selectedUserMst;
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            //  grid0BindEntity = (RadzenDh5.Models.Mark10Sqlexpress04.UserMst)grid0Bind;
            selectedUserMst = args;
        }
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewUserMst>("USER_MST", new Dictionary<string, object>() { { "COPY_USER_ID", args.USER_ID } });
        }


    }
}
