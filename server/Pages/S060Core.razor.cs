using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace RadzenDh5.Pages
{
    public partial class S060CoreComponent
    {

        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                getUserMstsResult = await AppDb.UserMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.USER_ID).AsNoTracking().ToListAsync();
                await grid0.GoToPage(0); // to fix when query result is out of current page number, no result

                if (getUserMstsResult.Count() >= 1)
                {
                    ObjTab0Selected = getUserMstsResult.First();
                    await ReloadLowerGridsAsync();

                }
                else
                {
                    getProgMstsResult = null;
                    getProgWrtsResult = null;
                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(@$"{ex.Message}");
            }

        }
        protected async System.Threading.Tasks.Task ReloadMainTab()
        {

            getUserMstsResult = await AppDb.UserMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.USER_ID).AsNoTracking().ToListAsync();

            await grid0.GoToPage(0);
            //  StateHasChanged();
        }
        protected async System.Threading.Tasks.Task ResetMainTab()
        {


            ResetValue(ref txtUSER_ID);
            ResetValue(ref txtUSER_NAME);
            ResetValue(ref txtDEPT_NAME);

            getUserMstsResult = null;
            GoodMsg = null;
            //    InvokeAsync(StateHasChanged);
        }


        public string GetSQL()
        {
            var dtMST = "USER_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("USER_ID", ref txtUSER_ID);
            strSQL += GetContains("USER_NAME", ref txtUSER_NAME);
            strSQL += GetContains("DEPT_NAME", ref txtDEPT_NAME);



            return strSQL;
        }
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "S060";
            await base.OnInitializedAsync();
        }
        public string value;

        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> getProgMstsResult;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt> getProgWrtsResult;



        protected async System.Threading.Tasks.Task ButtonToAddClick()
        {

            try
            {

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to add");
                AuthMsg = "authorization to add granted";

                if (ObjTab0Selected == null)
                {
                    await SimpleDialog("no data to process");
                    return;
                }

                if (ObjTab1Selected == null)
                {
                    await SimpleDialog("no data to process");
                    return;
                }

                string sUserId = ((UserMst)ObjTab0Selected).USER_ID;
                string sProgId = ((ProgMst)ObjTab1Selected).PROG_ID;



                //obj.TRN_USER = DhUsername;
                //obj.TRN_DATE = DhGlobals.GetDhTRN_DATE();
                //obj.CRT_USER = obj.TRN_USER;
                //obj.CRT_DATE = obj.TRN_DATE;

                // 按照 MLASRS Program List 顯示順序做預設值
                var sQuery = "Y";
                var sPrint = "N";
                var sImport = "N";
                var sExport = "N";
                var sUpdate = "N";
                var sEnable = "Y";
                var sDelete = "N";
                var sApprove = "N";

                string sSQL1 = string.Format(@"insert into PROG_WRT(USER_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT,ENABLE,REMARK,TRN_DATE,TRN_USER,CRT_DATE,CRT_USER) 
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',convert(varchar(19),getdate(),20),'{11}',convert(varchar(19),getdate(),20),'{11}')",
                             sUserId, sProgId, sQuery, sPrint, sImport, sExport, sUpdate, sDelete, sApprove, sEnable, "", DhUsername);

                using var transaction = AppDb.Database.BeginTransaction();
                try
                {
                    var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                    if (cnt1 < 1) throw new Exception("create failed:" + sSQL1);
                    transaction.Commit();

                    //string sRet = Globals.UserLog("05", "S060", this.Text, "Add USER_ID=" + sUserId + " PROG_ID= " + sProgId);
                    await DoUserLogAsync("05", PROG_ID, PROG_NAME_FOR_LOG, "Add USER_ID=" + sUserId + " PROG_ID= " + sProgId);

                    await ReloadLowerGridsAsync();
                    await InvokeAsync(() => { StateHasChanged(); });
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected async System.Threading.Tasks.Task ButtonToRemoveClick()
        {
            try
            {

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to remove");
                AuthMsg = "authorization to remove granted";


                if (ObjTab0Selected == null)
                {
                    await SimpleDialog("no data to process");
                    return;
                }

                if (ObjTab2Selected == null)
                {
                    await SimpleDialog("no data to process");
                    return;
                }

                string sUserId = ((UserMst)ObjTab0Selected).USER_ID;
                string sProgId = ((ProgWrt)ObjTab2Selected).PROG_ID;


                string sSQL1 = string.Format($@"insert into PROG_WRT_HIS select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER 
                                                from GROUP_WRT where GROUP_ID='{0}' and PROG_ID='{1}'", sUserId, sProgId, DhUsername);
                //if (Globals.UpdateTable(sSQL) < 1) throw new Exception("update failed:" + sSQL);

                string sSQL2 = string.Format(@"delete PROG_WRT where USER_ID='{0}' and PROG_ID='{1}'", sUserId, sProgId);
                //if (Globals.UpdateTable(sSQL) < 1) throw new Exception("update failed:" + sSQL);



                using var transaction = AppDb.Database.BeginTransaction();
                try
                {
                    var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                    var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                    transaction.Commit();
                    //string sRet = Globals.UserLog("06", "S060", this.Text, "Delete USER_ID=" + sUserId + " PROG_ID= " + sProgId);

                    await DoUserLogAsync("06", PROG_ID, PROG_NAME_FOR_LOG, "Delete USER_ID=" + sUserId + " PROG_ID= " + sProgId);
                    await ReloadLowerGridsAsync();
                    await InvokeAsync(() => { StateHasChanged(); });
                }
                catch (Exception ex)
                {
                    throw;
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //protected async System.Threading.Tasks.Task ToEditAuth()
        //{

        //    if (Grid2RowSelected == null)
        //    {
        //        Toast(NotificationSeverity.Info, "Please select Program Authorization!");

        //        return;
        //    }

        //    var dialogResult = await DialogService.OpenAsync<EditProgWrt>("Edit Prog Wrt", new Dictionary<string, object>() { { "USER_ID", Grid2RowSelected.USER_ID }, { "PROG_ID", Grid2RowSelected.PROG_ID } });
        //    await InvokeAsync(() => { StateHasChanged(); });

        //}

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            ObjTab0Selected = args;
            await ReloadLowerGridsAsync();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            ObjTab1Selected = args;
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid2RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt args)
        {
            ObjTab2Selected = args;
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid2RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt args)
        {
            ObjTab2Selected = args;
            var dialogResult = await DialogService.OpenAsync<EditProgWrt>("Edit Prog Wrt", new Dictionary<string, object>() { { "USER_ID", args.USER_ID }, { "PROG_ID", args.PROG_ID } });
            await InvokeAsync(() => { StateHasChanged(); });
        }





        async Task ReloadLowerGridsAsync()
        {
            var args = (UserMst)ObjTab0Selected;
            // PROG 主檔
            getProgMstsResult = await AppDb.ProgMsts.Where(c => !AppDb.ProgWrts.Where(g => g.USER_ID == args.USER_ID).Select(z => z.PROG_ID).Contains(c.PROG_ID)).OrderBy(x => x.PROG_ID).AsNoTracking().ToListAsync();

            // PROG 對 USER 的授權
            getProgWrtsResult = await AppDb.ProgWrts.Where(x => x.USER_ID == args.USER_ID).OrderBy(x => x.PROG_ID).AsNoTracking().ToListAsync();

            if (getProgMstsResult.Count() > 0)
            {
                ObjTab1Selected = getProgMstsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }

            if (getProgWrtsResult.Count() > 0)
            {
                ObjTab2Selected = getProgWrtsResult.First();
            }
            else
            {
                ObjTab2Selected = null;
            }
        }

    }
}