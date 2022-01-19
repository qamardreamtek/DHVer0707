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
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.AspNetCore.Components.Web;

namespace RadzenDh5.Pages
{
    public partial class S050CoreComponent

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

                getGroupMstsResult = await AppDb.GroupMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.GROUP_ID).AsNoTracking().ToListAsync();
                await grid0.GoToPage(0); // to fix when query result is out of current page number, no result

                if (getGroupMstsResult.Count() >= 1)
                {
                    ObjTab0Selected = getGroupMstsResult.First();
                    await ReloadLowerGridsAsync();

                }
                else
                {
                    getProgMstsResult = null;
                    getGroupWrtsResult = null;
                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(@$"{ex.Message}");
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
        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            PROG_ID = "S050";
            await base.OnInitializedAsync();

        }



        public bool IsTopShow = true;
        public string value;

        //getGroupMstsResult
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> getProgMstsResult;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt> getGroupWrtsResult;
      
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

                string sGroupId = ((GroupMst)ObjTab0Selected).GROUP_ID; 
                string sProgId = ((ProgMst)ObjTab1Selected).PROG_ID; 

                string sQuery = "Y";
                string sPrint = "N";
                string sImport = "N";
                string sExport = "N";
                string sUpdate = "N";
                string sDelete = "N";
                string sApprove = "N";
                string sEnable = "Y";

                string sSQL1 = string.Format(@"
                        insert into GROUP_WRT(GROUP_ID,PROG_ID,QUERY_WRT,PRINT_WRT,IMPORT_WRT,EXPORT_WRT,UPDATE_WRT,DELETE_WRT,APPROVE_WRT,ENABLE,REMARK,TRN_DATE,TRN_USER,CRT_DATE,CRT_USER) 
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',convert(varchar(19),getdate(),20),'{11}',convert(varchar(19),getdate(),20),'{11}')
                        ", sGroupId, sProgId, sQuery, sPrint, sImport, sExport, sUpdate, sDelete, sApprove, sEnable, "", DhUsername);
                //if (Globals.UpdateTable(sSQL) < 1) throw new Exception("create failed:" + sSQL);

                //新加PROG:同步更新PROG_WRT(GROUP中的每個USER)
                string sSQL2 = string.Format(@"
                        insert into PROG_WRT_HIS 
                            select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER from PROG_WRT 
                            where PROG_ID='{0}' and USER_ID in (select USER_ID from GROUP_DTL where GROUP_ID='{1}')
                        ", sProgId, sGroupId, DhUsername);
                //Globals.UpdateTable(sSQL);

                string sSQL3 = string.Format(@"
                        delete PROG_WRT 
                            where PROG_ID='{0}' and USER_ID in (select USER_ID from GROUP_DTL where GROUP_ID='{1}')
                        ", sProgId, sGroupId);
                //Globals.UpdateTable(sSQL);

                string sSQL4 = string.Format(@"insert into PROG_WRT select USER_ID,'{0}' as PROG_ID, '{1}' as QUERY_WRT, '{2}' as PRINT_WRT, '{3}' as IMPORT_WRT, '{4}' as EXPORT_WRT, '{5}' as UPDATE_WRT, '{6}' as DELETE_WRT, '{7}' as APPROVE_WRT, 'Y' as ENABLE,
                         '' as REMARK, '{8}' as TRN_USER, convert(varchar(19),getdate(),20) as TRN_DATE, '{8}' as CRT_USER, convert(varchar(19),getdate(),20) as CRT_DATE from GROUP_DTL where GROUP_ID='{9}' and ENABLE='Y'",
                      sProgId, sQuery, sPrint, sImport, sExport, sUpdate, sDelete, sApprove, DhUsername, sGroupId);
                using var transaction = AppDb.Database.BeginTransaction();
                try
                {
                    var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                    
                    // FOR DEBUG PURPOSE, TO TEST THROW WORKING!
                    //cnt1 = 0;

                    if (cnt1 != 1)
                    {
                        throw new Exception("create failed: " + sSQL1);
                    }
                    var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                    var cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL3);
                    var cnt4 = await AppDb.Database.ExecuteSqlRawAsync(sSQL4);
                    NotificationService.Notify(NotificationSeverity.Success, $@"Database transaction success ({cnt1},{cnt2},{cnt3},{cnt4}) ");

                    transaction.Commit();
                    //string sRet = Globals.UserLog("05", "S050", this.Text, "Add " + sGroupId + " group PROG_ID= " + sProgId);
                    await DoUserLogAsync("05", "S050", PROG_NAME_FOR_LOG, "Add " + sGroupId + " group PROG_ID= " + sProgId);

                }
                catch (Exception ex)
                {
                    throw;
                }

                await ReloadLowerGridsAsync();
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

                string sGroupId = ((GroupMst)ObjTab0Selected).GROUP_ID;
                string sProgId = ((GroupWrt)ObjTab2Selected).PROG_ID;


                string sSQL1 = string.Format(@"insert into GROUP_WRT_HIS select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER from GROUP_WRT where GROUP_ID='{0}' and PROG_ID='{1}'"
                                , sGroupId, sProgId, DhUsername);
                //if (Globals.UpdateTable(sSQL) < 1) throw new Exception("update failed:" + sSQL);

                string sSQL2 = string.Format(@"delete GROUP_WRT where GROUP_ID='{0}' and PROG_ID='{1}'", sGroupId, sProgId);
                //if (Globals.UpdateTable(sSQL) < 1) throw new Exception("update failed:" + sSQL);

                //新加PROG:同步更新PROG_WRT(GROUP中的每個USER)
                string sSQL3 = string.Format(@"insert into PROG_WRT_HIS select *,convert(varchar(19),getdate(),20) as LOG_DATE, N'{2}' as LOG_USER from PROG_WRT where PROG_ID='{0}' and USER_ID in (select USER_ID from GROUP_DTL where GROUP_ID='{1}')"
                                , sProgId, sGroupId, DhUsername);
                //Globals.UpdateTable(sSQL);

                string sSQL4 = string.Format(@"delete PROG_WRT where PROG_ID='{0}' and USER_ID in (select USER_ID from GROUP_DTL where GROUP_ID='{1}')", sProgId, sGroupId);



                using var transaction = AppDb.Database.BeginTransaction();
                try
                {
                    var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                    // FOR DEBUG PURPOSE, TO TEST THROW WORKING!
                    //cnt1 = 0;

                    if (cnt1 != 1)
                    {
                        throw new Exception("create failed: " + sSQL1);
                    }

                    var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                    var cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL3);
                    var cnt4 = await AppDb.Database.ExecuteSqlRawAsync(sSQL4);
                    NotificationService.Notify(NotificationSeverity.Success, $@"Database transaction success ({cnt1},{cnt2},{cnt3},{cnt4}) ");

                    transaction.Commit();
                    //string sRet = Globals.UserLog("06", "S050", this.Text, "Delete " + sGroupId + " group PROG_ID= " + sProgId);

                    await DoUserLogAsync("06", "S050", PROG_NAME_FOR_LOG, "Delete " + sGroupId + " group PROG_ID= " + sProgId);

           
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                await ReloadLowerGridsAsync();
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }


        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.GroupMst args)
        {

            //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = "...寫業務邏輯", Duration = 4000 });
            //GroupMstSelected = args;
            ObjTab0Selected = args;
            await ReloadLowerGridsAsync();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid2RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt args)
        {
            ObjTab2Selected = args;
            var dialogResult = await DialogService.OpenAsync<EditGroupWrt>("Edit GROUP_WRT", new Dictionary<string, object>() { { "GROUP_ID", args.GROUP_ID }, { "PROG_ID", args.PROG_ID } });
            await ReloadLowerGridsAsync();
            await InvokeAsync(() => { StateHasChanged(); });// { {"GROUP_ID", args.GROUP_ID}, {"PROG_ID", args.PROG_ID} });
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            ObjTab1Selected = args;
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid2RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt args)
        {
            ObjTab2Selected = args;
            await InvokeAsync(() => { StateHasChanged(); });
        }



        async Task ReloadLowerGridsAsync()
        {
            var args = (GroupMst)ObjTab0Selected;
            getProgMstsResult = await AppDb.ProgMsts.Where(c => !AppDb.GroupWrts.Where(g => g.GROUP_ID == args.GROUP_ID)
                                        .Select(z => z.PROG_ID).Contains(c.PROG_ID)).OrderBy(x => x.PROG_ID).AsNoTracking().ToListAsync();
            getGroupWrtsResult = await AppDb.GroupWrts.Where(x => x.GROUP_ID == args.GROUP_ID).OrderBy(x => x.PROG_ID).AsNoTracking().ToListAsync();

            if (getProgMstsResult.Count() > 0)
            {
                ObjTab1Selected = getProgMstsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }

            if (getGroupWrtsResult.Count() > 0)
            {
                ObjTab2Selected = getGroupWrtsResult.First();
            }
            else
            {
                ObjTab2Selected = null;
            }
        }

        public void OnChange(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

        }


    }
}