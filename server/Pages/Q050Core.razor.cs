using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class Q050CoreComponent
    {
        protected async Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.OutMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewOutMst>("OUT_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "OUT_NO", args.OUT_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.OutDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewOutDtl>("OUT_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "OUT_NO", args.OUT_NO }, { "OUT_LINE", args.OUT_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task Grid2RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PckSno args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPckSno>("PCK_SNO", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PCK_NO", args.PCK_NO }, { "IN_SNO", args.IN_SNO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        public string GetSQL()
        {
            //string sSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.OUT_NO=b.OUT_NO) where 1=1", dtMST.TableName, dtDTL.TableName);
            //if (tbOUT_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.OUT_NO like '%{0}%'", tbOUT_NO.Text.Trim().ToUpper());
            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
            //if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.REQM_NO like '%{0}%'", tbREQM_NO.Text.Trim().ToUpper());
            //if (tbCAR_LIC.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.CAR_LIC like '%{0}%'", tbCAR_LIC.Text.Trim().ToUpper());
            //if (tbSHIP_TO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SHIP_TO like '%{0}%'", tbSHIP_TO.Text.Trim().ToUpper());
            //if (tbSHIP_TO_NAME.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SHIP_TO_NAME like '%{0}%'", tbSHIP_TO_NAME.Text.Trim().ToUpper());
            //if (tbCREATEUSER.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.CREATEUSER like '%{0}%'", tbCREATEUSER.Text.Trim().ToUpper());
            //if (tbWHSE_DOOR.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.WHSE_DOOR like '%{0}%'", tbWHSE_DOOR.Text.Trim().ToUpper());
            //sSQL = sSQL + " order by a.PICK_DATE,a.PICK_TIME";

            //DataTable dtMST = new DataTable("OUT_MST"); //交貨單主檔
            //DataTable dtDTL = new DataTable("OUT_DTL"); //交貨單明細檔
            //DataTable dtSNO = new DataTable("PCK_SNO"); //交貨單掃碼確認序列號明細

            var dtMST = "OUT_MST"; //交貨單主檔
            var dtDTL = "OUT_DTL"; //交貨單明細檔
            //DataTable dtSNO = new DataTable("PCK_SNO"); //交貨單掃碼確認序列號明細

            string strSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.OUT_NO=b.OUT_NO) where 1=1 ", dtMST, dtDTL);
            strSQL += GetContains("a.OUT_NO", ref txtOUT_NO);
            strSQL += GetContains("a.SHIP_TO", ref txtSHIP_TO);
            strSQL += GetContains("a.SHIP_TO_NAME", ref txtSHIP_TO_NAME);
            strSQL += GetContains("b.SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("b.REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("a.CREATEUSER", ref txtCREATEUSER);
            strSQL += GetContains("a.CAR_LIC", ref txtCAR_LIC);
            strSQL += GetContains("a.WHSE_DOOR", ref txtWHSE_DOOR);
            //   GoodMsg = strSQL;
            return strSQL;
        }

        protected async Task QueryMstAsync()
        {
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
            getOutMstsResult = await AppDb.OutMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.PICK_DATE).ThenBy(a => a.PICK_TIME).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);

            if (getOutMstsResult.Count() > 0)
            {
                ObjTab0Selected = getOutMstsResult.First();
                await ReloadTab1();
            }
            else
            {

                getOutDtlsResult = null;
                getPckSnosResult = null;
            }
            await InvokeAsync(() => { StateHasChanged(); });

            // ResetGridBindAndSwitchToTab0();
        }
        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();


        }


        public IList<Models.Mark10Sqlexpress04.OutDtl> getOutDtlsResult { get; set; }
        public IList<Models.Mark10Sqlexpress04.PckSno> getPckSnosResult { get; set; }


        async Task ReloadTab1()
        {
            var OUT_NO = ((OutMst)ObjTab0Selected).OUT_NO;
            getOutDtlsResult = await AppDb.OutDtls.Where(a => a.OUT_NO == OUT_NO).AsNoTracking().ToListAsync();

            if (getOutDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getOutDtlsResult.First();
                await ReloadTab2();
            }

        }
        async Task ReloadTab2()
        {
          
            var OUT_NO = ((OutDtl)ObjTab1Selected).OUT_NO;
            var OUT_LINE = ((OutDtl)ObjTab1Selected).OUT_LINE;

            //      sSQL = string.Format(@"select * from {0} where ALO_NO='{1}' and ALO_LINE = '{2}' order by ALO_NO,ALO_LINE,IN_SNO"
            //                                          , dtSNO.TableName, sOUT_NO, sOUT_LINE);

            getPckSnosResult = await AppDb.PckSnos.Where(a => a.ALO_NO == OUT_NO && a.ALO_LINE == OUT_LINE).AsNoTracking().ToListAsync();
            if (getPckSnosResult.Count() > 0)
            {
                ObjTab2Selected = getPckSnosResult.First();

            }
        }




        protected async Task Grid0RowSelect(Models.Mark10Sqlexpress04.OutMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task Grid1RowSelect(Models.Mark10Sqlexpress04.OutDtl args)
        {
            ObjTab1Selected = args;
            await ReloadTab2();
            await InvokeAsync(() => { StateHasChanged(); });
        }

    }
}
