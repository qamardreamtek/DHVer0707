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
    public partial class LocMstsComponent : ComponentBase
    //public partial class M090Component : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> _getLocMstsResult;


        // NOTE by Mark,
        [Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList { get; set; }

        public IList<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> locMstsList { get; set; }
        //public IList<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> locMstsList
        //{
        //    get
        //    {
        //        //return new List<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>(getLocMstsResult.OrderBy(X => X.LOC_NO));
        //        return getLocMstsResult.OrderBy(X => X.LOC_NO).ToList();
        //    }
        //}

        protected override void OnInitialized()
        {
            //base.OnInitialized();
            locMstsList = AppDb.LocMsts.OrderBy(X => X.LOC_NO).ToList();



        }
        protected RadzenDh5.Models.Mark10Sqlexpress04.LocMst SelectedLocMst { get; set; }

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> getLocMstsResult
        {
            get
            {
                return _getLocMstsResult;
            }
            set
            {
                if (!object.Equals(_getLocMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getLocMstsResult", NewValue = value, OldValue = _getLocMstsResult };
                    _getLocMstsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetLocMstsResult = await Mark10Sqlexpress04.GetLocMsts();
            getLocMstsResult = mark10Sqlexpress04GetLocMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            //   var dialogResult = await DialogService.OpenAsync<AddLocMst>("Add Loc Mst", null);



            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }


        /*
        private void LocDisable(bool bFlag)
        {
            try
            {
                //must check user authourize
                string progID = this.Name.ToString();
                ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to change");

                string sLOC_NO = string.Empty;
                string sLOC_STS = string.Empty;
                int iRow = m_dgvExMst.CurrentRow.Index;
                if (iRow < 0) throw new Exception("no row selected");

                sLOC_NO = Convert.ToString(m_dgvExMst.Rows[iRow].Cells["LOC_NO"].Value);
                sLOC_STS = Convert.ToString(m_dgvExMst.Rows[iRow].Cells["LOC_STS"].Value);

                if (bFlag)  // NOTE by Mark, true TO DISABLE
                {
                    if (sLOC_STS != "N") throw new Exception("Location status not allow to disable");

                    string sSQL = string.Format(@"
                        update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='X',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                        where LOC_NO='{1}' and LOC_STS='N'
                    ", Globals.USER_NAME, sLOC_NO);
                    if (Globals.UpdateTable(sSQL) > 0) MessageBox.Show("Disable success");
                    else MessageBox.Show("Disable failed");
                }
                else        // NOTE by Mark, false TO ENABLE
                {
                    if (sLOC_STS != "X") throw new Exception("Location status not allow to enable");

                    string sSQL = string.Format(@"
                        update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='N',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                        where LOC_NO='{1}' and LOC_STS='X'
                    ", Globals.USER_NAME, sLOC_NO);
                    if (Globals.UpdateTable(sSQL) > 0) MessageBox.Show("Enable success");
                    else MessageBox.Show("Enable failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        */

        private void LocDisable(bool bFlag)
        {
            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];


                //clsData.cs
                //取得程序授權清單
                //sSQL = string.Format(@"select a.*,b.Remark as REM,b.QUERY_WRT,b.PRINT_WRT,b.IMPORT_WRT,b.EXPORT_WRT,b.UPDATE_WRT,b.DELETE_WRT,b.APPROVE_WRT
                //                       from PROG_MST a join PROG_WRT b on (a.PROG_ID=b.PROG_ID)
                //                       where b.USER_ID='{0}' and a.ENABLE='Y' and b.ENABLE='Y'", strUSER_ID);

                string brief = "";
                string msg = "";

                var p = AppDb.ProgWrts.Where(x => x.PROG_ID == "M090" && x.USER_ID == Security.User.UserName).FirstOrDefault();
                if (p == null)
                {
                    brief = "Authorization Issue (USER_ID =" + Security.User.UserName + ")";
                    msg = "no authorization to change";
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = brief, Detail = msg, Duration = 4000 });
                    return;

                }

                brief = "DEBUG ONLY";
                msg = p.USER_ID + " (APPROVE_WRT,UPDATE_WRT)= (" + p.APPROVE_WRT + "," + p.UPDATE_WRT + ")";
                //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = brief, Detail = msg, Duration = 4000 });




                //      NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "Authorization OK", Detail = "APPROVE_WRT and UPDATE_WRT are both Y", Duration = 4000 });


                //if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to change");
                if (p.APPROVE_WRT != "Y" && p.UPDATE_WRT != "Y")
                {
                    brief = "Authorization Issue (PROG_WRT)";
                    msg = "no authorization to change";
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = brief, Detail = msg, Duration = 4000 });
                    return;
                }
                //   NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "Authorization OK", Detail = "APPROVE_WRT and UPDATE_WRT are both Y", Duration = 4000 });


                //string sLOC_NO = string.Empty;
                //string sLOC_STS = string.Empty;
                //int iRow = m_dgvExMst.CurrentRow.Index;
                //if (iRow < 0) throw new Exception("no row selected");

                //sLOC_NO = Convert.ToString(m_dgvExMst.Rows[iRow].Cells["LOC_NO"].Value);
                //sLOC_STS = Convert.ToString(m_dgvExMst.Rows[iRow].Cells["LOC_STS"].Value);

                if (SelectedLocMst == null)
                {
                    brief = "Select Issue";
                    msg = "no row selected";
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = brief, Detail = msg, Duration = 4000 });
                    return;

                }


                if (bFlag)  // NOTE by Mark, true TO DISABLE
                {
                    //    if (sLOC_STS != "N") throw new Exception("Location status not allow to disable");

                    //    string sSQL = string.Format(@"
                    //        update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='X',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                    //        where LOC_NO='{1}' and LOC_STS='N'
                    //    ", Globals.USER_NAME, sLOC_NO);
                    //    if (Globals.UpdateTable(sSQL) > 0) MessageBox.Show("Disable success");
                    //    else MessageBox.Show("Disable failed");

                    if (SelectedLocMst.LOC_STS != "N")
                    {

                        brief = $"LOC_STS Issue ({SelectedLocMst.LOC_STS})";
                        msg = "Location status not allow to disable";
                        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = brief, Detail = msg, Duration = 4000 });
                        return;

                    }


                    string strSQL = String.Format(@"
                            update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='X',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                            where LOC_NO='{1}' and LOC_STS='N'
                        ", Security.User.UserName, SelectedLocMst.LOC_NO);


                    //int rowAffected = AppDb.Database.ExecuteSqlInterpolated($"update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='X',TRN_USER=N'{Security.User.UserName}', TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''  where LOC_NO= '{SelectedLocMst.LOC_NO}' and LOC_STS='N'");
                    //AppDb.SaveChanges();

                    var obj = AppDb.LocMsts.Where(x => x.LOC_NO == SelectedLocMst.LOC_NO && x.LOC_STS == "N").FirstOrDefault();
                    if (obj != null)
                    {
                        obj.LOC_OSTS = obj.LOC_STS;
                        obj.AVAIL = 100;
                        obj.LOC_STS = "X";
                        obj.TRN_USER = Security.User.UserName;
                        obj.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //	2006-12-30 00:38:54
                        obj.SU_ID = "";
                        AppDb.Update(obj);
                        int cnt = AppDb.SaveChanges();
                        //brief = "rowAffected Issue";
                        //msg = rowAffected + " record affected";
                        if (cnt > 0)
                        {
                            brief = "Enable success";
                            msg = cnt + " record affected!";

                            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = brief, Detail = msg, Duration = 4000 });

                        }
                        else
                        {
                            brief = "Enable failed";
                            msg = cnt + " record affected!";
                            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = brief, Detail = msg, Duration = 4000 });

                        }
                    }


                   

                }
                else        // NOTE by Mark, false TO ENABLE
                {
                    //    if (sLOC_STS != "X") throw new Exception("Location status not allow to enable");

                    //    string sSQL = string.Format(@"
                    //        update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='N',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                    //        where LOC_NO='{1}' and LOC_STS='X'
                    //    ", Globals.USER_NAME, sLOC_NO);
                    //    if (Globals.UpdateTable(sSQL) > 0) MessageBox.Show("Enable success");
                    //    else MessageBox.Show("Enable failed");


                    if (SelectedLocMst.LOC_STS != "X")
                    {
                        brief = $"LOC_STS Issue ({SelectedLocMst.LOC_STS})";
                        msg = "Location status not allow to disable";
                        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = brief, Detail = msg, Duration = 4000 });
                        return;

                    }

                    //  int rowAffected = AppDb.Database.ExecuteSqlInterpolated($" update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='N',TRN_USER=N'{Security.User.UserName}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID='' where LOC_NO='{SelectedLocMst.LOC_NO}' and LOC_STS='X'");

                    //where LOC_NO = '{SelectedLocMst.LOC_NO}' and LOC_STS = 'X'");
                    var obj = AppDb.LocMsts.Where(x => x.LOC_NO == SelectedLocMst.LOC_NO && x.LOC_STS == "X").FirstOrDefault();
                    if (obj != null)
                    {
                        obj.LOC_OSTS = obj.LOC_STS;
                        obj.AVAIL = 100;
                        obj.LOC_STS = "N";
                        obj.TRN_USER = Security.User.UserName;
                        obj.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //	2006-12-30 00:38:54
                        obj.SU_ID = "";
                        AppDb.Update(obj);
                        int cnt = AppDb.SaveChanges();
                        //brief = "rowAffected Issue";
                        //msg = rowAffected + " record affected";
                        if (cnt > 0)
                        {
                            brief = "Enable success";
                            msg = cnt + " record affected!";

                            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = brief, Detail = msg, Duration = 4000 });

                        }
                        else
                        {
                            brief = "Enable failed";
                            msg = cnt + " record affected!";
                            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = brief, Detail = msg, Duration = 4000 });

                        }
                    }



                }
                //NO Need to reload page
                //UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
            }
            catch (Exception ex)
            {
                //    MessageBox.Show(ex.Message);
            }
        }

        protected async System.Threading.Tasks.Task ButtonDisableClick(MouseEventArgs args)
        {
             LocDisable(true);

            //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = msg, Duration = 4000 });

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonEnableClick(MouseEventArgs args)
        {
             LocDisable(false);

            //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = msg, Duration = 4000 });

            await InvokeAsync(() => { StateHasChanged(); });
        }


        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportLocMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,LOC_NO,LOC_NAME,ZONE_NO,LANE_NO,EQU_NO,ROW_X,BAY_Y,LVL_Z,LOC_ASRS,LOC_STS,LOC_OSTS,AVAIL,DEPTH,LOC_SIZE,LOC_TYPE,LOC_ABC,LOC_SPECIAL,LOC_HOT,LOC_RCV,LOC_STOCK,LOC_QC,LOC_NG,LOC_RETURN,LOC_SORT,LOC_PICK,LOC_STAGE,LOC_DEL,SU_ID,COUNT_DATE,REMARK,TRN_USER,TRN_DATE" }, $"Loc Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportLocMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,LOC_NO,LOC_NAME,ZONE_NO,LANE_NO,EQU_NO,ROW_X,BAY_Y,LVL_Z,LOC_ASRS,LOC_STS,LOC_OSTS,AVAIL,DEPTH,LOC_SIZE,LOC_TYPE,LOC_ABC,LOC_SPECIAL,LOC_HOT,LOC_RCV,LOC_STOCK,LOC_QC,LOC_NG,LOC_RETURN,LOC_SORT,LOC_PICK,LOC_STAGE,LOC_DEL,SU_ID,COUNT_DATE,REMARK,TRN_USER,TRN_DATE" }, $"Loc Msts");

            }
        }

        protected void reloadGrid2()
        {

            //sSQL = string.Format(@"select * from {0} where SU_ID='{1}' order by SKU_NO,GR_DATE,IN_SNO", dtDTL.TableName, sSU_ID);
            pltDtlsList = AppDb.PltDtls.Where(x => x.SU_ID == SelectedLocMst.SU_ID).OrderBy(x => x.SKU_NO).ThenBy(x => x.GR_DATE).ThenBy(x => x.IN_SNO).ToList();
        }
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.LocMst args)
        {
            //  var dialogResult = await DialogService.OpenAsync<EditLocMst>("Edit Loc Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"LOC_NO", args.LOC_NO}, {"ZONE_NO", args.ZONE_NO} });

         
            SelectedLocMst = args;
            reloadGrid2();


            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = msg, Duration = 4000 });



            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteLocMstResult = await Mark10Sqlexpress04.DeleteLocMst($"{data.WHSE_NO}", $"{data.LOC_NO}", $"{data.ZONE_NO}");
                    if (mark10Sqlexpress04DeleteLocMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeleteLocMstException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete LocMst" });
            }
        }
    }
}
