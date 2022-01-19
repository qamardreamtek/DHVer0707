using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using CaotunSpring.DH.Tools;
using RadzenDh5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class S040CoreComponent
    {
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> grid0;

  

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> getGroupMstsResult;
     

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            try
            {

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to add");
                AuthMsg = "authorization to add granted";

                var dialogResult = await DialogService.OpenAsync<AddGroupMst>("Add Group Mst", null);
                await grid0.Reload();

                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }

     

  
        public string GetSQL()
        {
            var dtMST = "GROUP_MST";

            string strSQL = $@" select * from {dtMST} where 1 = 1 ";

            strSQL += GetContains("GROUP_ID", ref txtGROUP_ID);
            strSQL += GetContains("GROUP_NAME", ref txtGROUP_NAME);
            strSQL += GetContains("OWNER_ID", ref txtOWNER_ID);
            strSQL += GetContains("OWNER_NAME", ref txtOWNER_NAME);


            return strSQL;
        }
    


        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getGroupMstsResult = await AppDb.GroupMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.GROUP_ID).AsNoTracking().ToListAsync();

                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getGroupMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getGroupMstsResult.First();
                    await ReloadLowerGrids();
                }
                else
                {
                    getUserMstsResult = null;
                    getGroupDtlsResult = null;

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }

        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "S040";
            await base.OnInitializedAsync();
        }


       // public string value;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> getUserMstsResult;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl> getGroupDtlsResult;


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

                string sGroupId = ((GroupMst)ObjTab0Selected).GROUP_ID; // LINE#51 ofSO40.cs
                var user = (UserMst)ObjTab1Selected;
                string sUserId = user.USER_ID;
                string sUserName = user.USER_NAME;
                string sDeptName = user.DEPT_NAME;


                //如果該群組已有權限GROUP_WRT，則同步生成PROG_WRT
                string sSQL1 = string.Format(@"
                        insert into PROG_WRT_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER 
                            from PROG_WRT 
                            where USER_ID='{0}' and PROG_ID in (select PROG_ID from GROUP_WRT where GROUP_ID='{1}')
                        ", sUserId, sGroupId, DhUsername);

                string sSQL2 = string.Format(@"
                        delete PROG_WRT 
                        where USER_ID='{0}' and PROG_ID in (select PROG_ID from GROUP_WRT where GROUP_ID='{1}')
                        ", sUserId, sGroupId);

                //string sSQL3 = string.Format(@"
                //            insert into PROG_WRT 
                //                select '{0}' as USER_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT, 'Y' as ENABLE,
                //                    '' as REMARK, '{1}' as TRN_USER, convert(varchar(19),getdate(),20) as TRN_DATE, '{1}' as CRT_USER, convert(varchar(19),getdate(),20) as CRT_DATE 
                //                from GROUP_WRT where GROUP_ID='{1}' and ENABLE='Y'
                //              ",sUserId, Globals.USER_NAME, sGroupId);
                // BUG REPORT by Mark, 05/04
                // 原 WES LINE#99 of S040.cs
                // from GROUP_WRT where GROUP_ID='{1}' and ENABLE='Y'
                // {1} 會取用到 Globals.USER_NAME 而不是 sGroupId
                // 因此  用戶 無法在此獲得 透過 群組的程序授權

                // WebApp 在這裡直接修護
                string sSQL3 = string.Format(@"
                        insert into PROG_WRT 
                            select '{0}' as USER_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT, 'Y' as ENABLE,
                                '' as REMARK, '{1}' as TRN_USER, convert(varchar(19),getdate(),20) as TRN_DATE, '{1}' as CRT_USER, convert(varchar(19),getdate(),20) as CRT_DATE 
                            from GROUP_WRT where GROUP_ID='{2}' and ENABLE='Y'
                        ", sUserId, DhUsername, sGroupId);

                string sSQL4 = string.Format(@"
                            insert into GROUP_DTL(GROUP_ID,USER_ID,USER_NAME,DEPT_NAME,ENABLE,REMARK,TRN_DATE,TRN_USER,CRT_DATE,CRT_USER) 
                            values('{0}','{1}','{2}','{3}','{4}','{5}',convert(varchar(19),getdate(),20),'{6}',convert(varchar(19),getdate(),20),'{6}')
                            ", sGroupId, sUserId, sUserName, sDeptName, "Y", "", DhUsername);

                using var transaction = AppDb.Database.BeginTransaction();
                try
                {
                    var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                    var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                    var cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL3);
                    var cnt4 = await AppDb.Database.ExecuteSqlRawAsync(sSQL4);
                    NotificationService.Notify(NotificationSeverity.Success, $@"Database transaction success ({cnt1},{cnt2},{cnt3},{cnt4}) ");

                    transaction.Commit();
                    //string sRet = Globals.UserLog("05", "S040", this.Text, "Add " + sGroupId + " group USER_ID= " + sUserId);

                    await DoUserLogAsync("05", "S040", PROG_NAME_BY_CULTURE, "Add " + sGroupId + " group USER_ID= " + sUserId);

                }
                catch (Exception ex)
                {
                    throw;
                }

                await ReloadLowerGrids();
                await InvokeAsync(() => { StateHasChanged(); });
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

                string sGroupId = ((GroupMst)ObjTab0Selected).GROUP_ID; // LINE#51 ofSO40.cs
                string sUserId = ((GroupDtl)ObjTab2Selected).USER_ID; // LINE#51 ofSO40.cs

                //如果該群組已有權限GROUP_WRT，則同步刪除PROG_WRT
                string sSQL1 = string.Format(@"
                        insert into PROG_WRT_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER 
                            from PROG_WRT 
                            where USER_ID='{0}' and PROG_ID in (select PROG_ID from GROUP_WRT where GROUP_ID='{1}')
                        ", sUserId, sGroupId, DhUsername);

                string sSQL2 = string.Format(@"
                        delete PROG_WRT 
                            where USER_ID='{0}' and PROG_ID in (select PROG_ID from GROUP_WRT where GROUP_ID='{1}')
                        ", sUserId, sGroupId);

                string sSQL3 = string.Format(@"
                        insert into GROUP_DTL_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER 
                            from GROUP_DTL 
                            where USER_ID='{0}' and GROUP_ID='{1}'
                        ", sUserId, sGroupId, DhUsername);

                string sSQL4 = string.Format(@"
                        delete GROUP_DTL 
                            where GROUP_ID='{0}' and USER_ID='{1}'
                        ", sGroupId, sUserId);

                using var transaction = AppDb.Database.BeginTransaction();
                try
                {
                    var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                    var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                    var cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL3);
                    var cnt4 = await AppDb.Database.ExecuteSqlRawAsync(sSQL4);

                    transaction.Commit();
                    //string sRet = Globals.UserLog("06", "S040", this.Text, "Delete " + sGroupId + " group USER_ID= " + sUserId);
                    await DoUserLogAsync("06", "S040", PROG_NAME_FOR_LOG, "Delete " + sGroupId + " group USER_ID= " + sUserId);

                    NotificationService.Notify(NotificationSeverity.Success, $@"Database transaction success ({cnt1},{cnt2},{cnt3},{cnt4}) ");

                    await ReloadLowerGrids();
                    await InvokeAsync(() => { StateHasChanged(); });
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }

        protected async Task Grid0RowSelect(Models.Mark10Sqlexpress04.GroupMst args)
        {
            ObjTab0Selected = args;
            await ReloadLowerGrids();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            ObjTab1Selected = args;
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid2RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl args)
        {
            ObjTab2Selected = args;
            await InvokeAsync(() => { StateHasChanged(); });
        }
        async Task ReloadLowerGrids()
        {
            var args = (GroupMst)ObjTab0Selected;
            getUserMstsResult = await AppDb.UserMsts.Where(c => !AppDb.GroupDtls.Where(g => g.GROUP_ID == args.GROUP_ID).Select(z => z.USER_ID).Contains(c.USER_ID)).OrderBy(x => x.USER_ID).AsNoTracking().ToListAsync();
            getGroupDtlsResult = await AppDb.GroupDtls.Where(x => x.GROUP_ID == args.GROUP_ID).OrderBy(x => x.USER_ID).AsNoTracking().ToListAsync();

            if (getUserMstsResult.Count() > 0)
            {
                ObjTab1Selected = getUserMstsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }

            if (getGroupDtlsResult.Count() > 0)
            {
                ObjTab2Selected = getGroupDtlsResult.First();
            }
            else
            {
                ObjTab2Selected = null;
            }
        }
    }
}