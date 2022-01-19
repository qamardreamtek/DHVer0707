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
    //class TrueOrFalse

    public partial class PicMstsComponent : ComponentBase
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

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> grid0;
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> grid2;

        //NOTE by Mark
        //DataTable dtMST = new DataTable("PIC_MST"); //盤點主檔
        //DataTable dtDTL = new DataTable("PIC_DTL"); //盤點明細檔
        //DataTable dtSNO = new DataTable("PIC_SNO"); //盤點序列號檔
        [Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> picMstsLIst
        {
            get { return new List<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>(getPicMstsResult); }
        }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> picDtlsList { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PicSno> picSnosList { get; set; }
        public RadzenDh5.Models.Mark10Sqlexpress04.PicMst SelectedPicMst { get; set; }
        public RadzenDh5.Models.Mark10Sqlexpress04.PicDtl SelectedPicDtl { get; set; }
        public RadzenDh5.Models.Mark10Sqlexpress04.PicSno SelectedPicSno { get; set; }


        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> _getPicMstsResult;

        void ReloadGrids()
        {
            try
            {
                var b = SelectedPicMst;
                var PIC_NO = SelectedPicMst.PIC_NO;

            if (SelectedPicMst != null)
            {
                    //                picDtlsList = AppDb.PicDtls.FromSqlRaw(@"
                    //                    select distinct a.* from  PIC_DTL a
                    //                    join LOC_DTL b on(a.SU_ID = b.SU_ID
                    //                                and a.SKU_NO = b.SKU_NO
                    //                                and a.BATCH_NO = b.BATCH_NO
                    //                                and a.COUNT_UNIT = b.GTIN_UNIT)
                    //                    where a.PIC_NO = '{0}' order by a.PIC_LINE
                    //",  PIC_NO).ToList();
                    /*
CREATE PROCEDURE sp_C030 @PIC_NO nvarchar(30)
AS
select distinct a.* from  PIC_DTL a
join LOC_DTL b on(a.SU_ID = b.SU_ID
and a.SKU_NO = b.SKU_NO
and a.BATCH_NO = b.BATCH_NO
and a.COUNT_UNIT = b.GTIN_UNIT)
where a.PIC_NO = @PIC_NO
order by a.PIC_LINE

EXEC sp_C030 @PIC_NO='2007280001'
                     * 
                     * 
                     */


            //        string query = String.Format(
            //@"select top 1 from sys.procedures " +
            //  "where [type_desc] = '{0}'", "sp_C030");

            //        AppDb.Database.FromSqlRaw(query).Any();

                    picDtlsList = AppDb.PicDtls.FromSqlRaw("EXEC sp_C030 {0}", SelectedPicMst.PIC_NO).ToList();
                    

                    if (picDtlsList.Count >0)
                    {
                        var PIC_LINE = picDtlsList[0].PIC_LINE;
                        picSnosList = AppDb.PicSnos.Where(a => a.PIC_NO == SelectedPicMst.PIC_NO && a.PIC_LINE == PIC_LINE).ToList();

                    }
                    else
                    {
                        picSnosList = null;
                    }
                    //select* from { 0}
                    //where PIC_NO = '{1}' and PIC_LINE = '{2}' order by PIC_NO,PIC_LINE,IN_SNO", dtSNO.TableName, sPIC_NO, sPIC_LINE)

                  //  var see = picDtlsList;
            }
            }catch (Exception ex)
            {
                var see = ex;
            }

        }

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> getPicMstsResult
        {
            get
            {
                return _getPicMstsResult;
            }
            set
            {
                if (!object.Equals(_getPicMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPicMstsResult", NewValue = value, OldValue = _getPicMstsResult };
                    _getPicMstsResult = value;
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

//            var mark10Sqlexpress04GetPicMstsResult = await Mark10Sqlexpress04.GetPicMsts();
         //   var mark10Sqlexpress04GetPicMstsResult = await Mark10Sqlexpress04.GetPicMsts();
            var mark10Sqlexpress04GetPicMstsResult= AppDb.PicMsts.FromSqlRaw(DhGlobals.GetC030Grid1SQL());
                                                                 

            getPicMstsResult = mark10Sqlexpress04GetPicMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPicMst>("Add Pic Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportPicMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PIC_NO,PIC_GROUP,PIC_TYPE,PLANT,STGE_LOC,COUNT_USER,SHELF,CREATEUSER,CREATEDATE,CREATETIME,PIC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pic Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportPicMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,PIC_NO,PIC_GROUP,PIC_TYPE,PLANT,STGE_LOC,COUNT_USER,SHELF,CREATEUSER,CREATEDATE,CREATETIME,PIC_STS,REMARK,SOURCE,APPROVE_IND,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"Pic Msts");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PicMst args)
        {

   
            SelectedPicMst = args;
            ReloadGrids();
       //     NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = brief, Detail = msg, Duration = 4000 });


            //     var dialogResult = await DialogService.OpenAsync<EditPicMst>("Edit Pic Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PIC_NO", args.PIC_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }


        protected async System.Threading.Tasks.Task Grid2RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PicDtl args)
        {

            SelectedPicDtl = args;

            ReloadGrids();
       //     NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = brief, Detail = msg, Duration = 4000 });


            //     var dialogResult = await DialogService.OpenAsync<EditPicMst>("Edit Pic Mst", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PIC_NO", args.PIC_NO} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid3RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PicSno args)
        {

            //var brief = "C030 盤點序列號檔";
            //var msg = "Grid Serial Items RowSelect";
            SelectedPicSno = args;

            var dialogResult = await DialogService.OpenAsync<EditPicSno>("Edit Pic Sno", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "IN_SNO", args.IN_SNO } });


            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePicMstResult = await Mark10Sqlexpress04.DeletePicMst($"{data.WHSE_NO}", $"{data.PIC_NO}");
                    if (mark10Sqlexpress04DeletePicMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePicMstException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete PicMst" });
            }
        }
    }
}
