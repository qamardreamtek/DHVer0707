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
    public partial class TranslatesComponent
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
        protected async System.Threading.Tasks.Task ResetMainTab()
        {
            ResetValue(ref txtTEXT);
            getTranslatesResult = null;
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
                string COPY_TEXT = "NO_SUCH";
                if (selectedTranslate != null)
                {
                    COPY_TEXT = selectedTranslate.TEXT;
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
            if (selectedTranslate == null)
            {
                await SimpleDialog("no data found");
                return;
            }

            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to update");
                AuthMsg = "authorization to update granted";

                var dialogResult = await DialogService.OpenAsync<EditTranslate>("Update TRANSLATE", new Dictionary<string, object>() { { "TEXT", selectedTranslate.TEXT } });
                await InvokeAsync(() => { StateHasChanged(); });

                if (dialogResult != null)
                {

                    //string sRet = Globals.UserLog("05", "S010", this.Text, "Update " + sKey[0] + " = " + sKeyValue[0]);
                    var x = (Translate)dialogResult;
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, $"Update TEXT = {x.TEXT} ");

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
                if (selectedTranslate == null)
                {
                    await SimpleDialog("Please select record to process");
                    return;
                }
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteTranslateResult = await Mark10Sqlexpress04.DeleteTranslate($"{selectedTranslate.TEXT}");
                    if (mark10Sqlexpress04DeleteTranslateResult != null)
                    {
                        // 選定的 row 已刪除, 要釋放掉
                       

                        //string sRet = Globals.UserLog("06", "S010", this.Text, "Delete " + sKey[0] + " = " + sKeyValue[0]);
                       // var x = (Translates)mark10Sqlexpress04DeleteTranslateResult;
                        await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, $"Delete TEXT = {mark10Sqlexpress04DeleteTranslateResult.TEXT} ");
                        selectedTranslate = null;

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


  

        public RadzenDh5.Models.Mark10Sqlexpress04.Translate selectedTranslate;
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.Translate args)
        {
            //  grid0BindEntity = (RadzenDh5.Models.Mark10Sqlexpress04.UserMst)grid0Bind;
            selectedTranslate = args;
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.Translate args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewTranslate>("TRANSLATE", new Dictionary<string, object>() { { "TEXT", selectedTranslate.TEXT } });
        }


        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Translate> grid0;
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }
        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }
        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Translate> _getTranslatesResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Translate> getTranslatesResult
        {
            get
            {
                return _getTranslatesResult;
            }
            set
            {
                if (!object.Equals(_getTranslatesResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTranslatesResult", NewValue = value, OldValue = _getTranslatesResult };
                    _getTranslatesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            PROG_ID = "S090";
            await base.OnInitializedAsync();

            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetTranslatesResult = await Mark10Sqlexpress04.GetTranslates();
            getTranslatesResult = mark10Sqlexpress04GetTranslatesResult;
        }
   
     }
}
