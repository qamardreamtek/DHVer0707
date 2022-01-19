using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class Q090CoreComponent
    {

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.LocMst args)
        {
            await DialogService.OpenAsync<ViewLocMst>("LOC_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "LOC_NO", args.LOC_NO }, { "ZONE_NO", args.ZONE_NO } });
        }
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
        }




        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> grid0;
        public IEnumerable<Models.Mark10Sqlexpress04.LocMst> getLocMstsResult { get; set; }
        public IEnumerable<Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult { get; set; }
       

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
                 getLocMstsResult = await AppDb.LocMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.LOC_NO).AsNoTracking().ToListAsync();


                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getLocMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getLocMstsResult.First();
                    await ReloadTab1();
                }
                else
                {
                    getPltDtlsResult = null;

                }
                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        async Task ReloadTab1()
        {
            //IN_SNO由SAP下傳，如果沒有序列號則只有托盤號，序列號為'X' 
            //sSQL = string.Format(@"select * from {0} where SU_ID='{1}' order by SKU_NO,GR_DATE,IN_SNO", dtDTL.TableName, sSU_ID);


            var args = ((LocMst)ObjTab0Selected);
            getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).OrderBy(a => a.SKU_NO).ThenBy(a => a.GR_DATE).ThenBy(a => a.IN_SNO).AsNoTracking().ToListAsync();

         
            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();
                //   await ReloadTab2(); // 採用沒有就沒有
            }
            else
            {
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Models.Mark10Sqlexpress04.LocMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        //DataTable dtMST = new DataTable("LOC_MST"); //儲位主檔
        //DataTable dtDTL = new DataTable("PLT_DTL"); //托盤明細
        readonly string dtMST = "LOC_MST"; //儲位主檔
        readonly string dtDTL = "PLT_DTL"; //托盤明細
        public string GetSQL()
        {
            //string sSQL = string.Format(@"select * from {0}  where 1=1", dtMST.TableName);
            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());
            //if (tbEQU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and EQU_NO like '%{0}%'", tbEQU_NO.Text.Trim().ToUpper());
            //if (tbLOC_SIZE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LOC_SIZE = '{0}'", tbLOC_SIZE.Text.Trim().ToUpper());
            //if (tbAVAIL_MIN.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and AVAIL >= {0}", tbAVAIL_MIN.Text.Trim().ToUpper());
            //if (tbAVAIL_MAX.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and AVAIL <= {0}", tbAVAIL_MAX.Text.Trim().ToUpper());
            //if (tbROW_FROM.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and ROW_X >= {0}", tbROW_FROM.Text.Trim().ToUpper());
            //if (tbBAY_FROM.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and BAY_Y >= {0}", tbBAY_FROM.Text.Trim().ToUpper());
            //if (tbLVL_FROM.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LVL_Z >= {0}", tbLVL_FROM.Text.Trim().ToUpper());
            //if (tbROW_TO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and ROW_X <= {0}", tbROW_TO.Text.Trim().ToUpper());
            //if (tbBAY_TO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and BAY_Y <= {0}", tbBAY_TO.Text.Trim().ToUpper());
            //if (tbLVL_TO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and LVL_Z <= {0}", tbLVL_TO.Text.Trim().ToUpper());

            //sSQL = sSQL + " order by LOC_NO";
            string strSQL = string.Format(@"select * from {0}  where 1=1 ", dtMST);



            strSQL += GetContains("LOC_NO", ref txtLOC_NO);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("EQU_NO", ref txtEQU_NO);
            strSQL += GetGreaterThanOrEqualTo("ROW_X", ref txtROW_FROM);
            strSQL += GetLessThanOrEqualTo("ROW_X", ref txtROW_TO);
            strSQL += GetContains("LOC_SIZE", ref txtLOC_SIZE);
            strSQL += GetGreaterThanOrEqualTo("BAY_Y", ref txtBAY_FROM);
            strSQL += GetLessThanOrEqualTo("BAY_Y", ref txtBAY_TO);
            strSQL += GetGreaterThanOrEqualTo("AVAIL", ref txtAVAIL_MIN);
            strSQL += GetGreaterThanOrEqualTo("LVL_Z", ref txtLVL_FROM);
            strSQL += GetLessThanOrEqualTo("LVL_Z", ref txtLVL_TO);
            strSQL += GetLessThanOrEqualTo("AVAIL", ref txtAVAIL_MAX);
            //   GoodMsg = strSQL;
            return strSQL;
        }
        protected async System.Threading.Tasks.Task ReloadMainTab()
        {
            getLocMstsResult = await AppDb.LocMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.LOC_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);
        }
        protected async System.Threading.Tasks.Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }

        protected async System.Threading.Tasks.Task ResetMainTab()
        {



            ResetValue(ref txtLOC_NO);
            ResetValue(ref txtSU_ID);
            ResetValue(ref txtEQU_NO);
            ResetValue(ref txtROW_FROM);
            ResetValue(ref txtROW_TO);
            ResetValue(ref txtLOC_SIZE);
            ResetValue(ref txtBAY_FROM);
            ResetValue(ref txtBAY_TO);
            ResetValue(ref txtAVAIL_MIN);
            ResetValue(ref txtLVL_FROM);
            ResetValue(ref txtLVL_TO);
            ResetValue(ref txtAVAIL_MAX);


            getLocMstsResult = null;
        }

    


    }
}
