using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class Q060CoreComponent
    {
        protected async Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PicMst args)
        {
            // 原有考慮傳一個 Vc010, 但由於還要多語翻譯, 因此先把翻譯好的欄位名和其值傳到 DialogViewC010
            await DialogService.OpenAsync<DialogViewPicMst>($"PIC_MST",
                       new Dictionary<string, object>() { { "h1", $"{ Lang("WHSE_NO")}" }, { "v1", $"{args.WHSE_NO}" }, { "h2", $"{ Lang("PIC_NO")}" }, { "v2", $"{args.PIC_NO}" }, { "h3", $"{ Lang("PIC_GROUP")}" }, { "v3", $"{args.PIC_GROUP}" }, { "h4", $"{ Lang("PIC_TYPE")}" }, { "v4", $"{args.PIC_TYPE}" }, { "h5", $"{ Lang("PLANT")}" }, { "v5", $"{args.PLANT}" }, { "h6", $"{ Lang("STGE_LOC")}" }, { "v6", $"{args.STGE_LOC}" }, { "h7", $"{ Lang("COUNT_USER")}" }, { "v7", $"{args.COUNT_USER}" }, { "h8", $"{ Lang("SHELF")}" }, { "v8", $"{args.SHELF}" }, { "h9", $"{ Lang("CREATEUSER")}" }, { "v9", $"{args.CREATEUSER}" }, { "h10", $"{ Lang("CREATEDATE")}" }, { "v10", $"{args.CREATEDATE}" }, { "h11", $"{ Lang("CREATETIME")}" }, { "v11", $"{args.CREATETIME}" }, { "h12", $"{ Lang("PIC_STS")}" }, { "v12", $"{args.PIC_STS}" }, { "h13", $"{ Lang("REMARK")}" }, { "v13", $"{args.REMARK}" }, { "h14", $"{ Lang("SOURCE")}" }, { "v14", $"{args.SOURCE}" }, { "h15", $"{ Lang("APPROVE_IND")}" }, { "v15", $"{args.APPROVE_IND}" }, { "h16", $"{ Lang("APPROVE_USER")}" }, { "v16", $"{args.APPROVE_USER}" }, { "h17", $"{ Lang("APPROVE_DATE")}" }, { "v17", $"{args.APPROVE_DATE}" }, { "h18", $"{ Lang("TRN_USER")}" }, { "v18", $"{args.TRN_USER}" }, { "h19", $"{ Lang("TRN_DATE")}" }, { "v19", $"{args.TRN_DATE}" }, { "h20", $"{ Lang("CRT_USER")}" }, { "v20", $"{args.CRT_USER}" }, { "h21", $"{ Lang("CRT_DATE")}" }, { "v21", $"{args.CRT_DATE}" } },  new DialogOptions() { });
        }
        protected async Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PicDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPicDtl>("PIC_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "PIC_LINE", args.PIC_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid2RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PicSno args)
        {
            //var dialogResult = await DialogService.OpenAsync<ViewPicSno>("PIC_SNO", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "IN_SNO", args.IN_SNO } });
            var dialogResult = await DialogService.OpenAsync<ViewPicSno>(" Pic Sno", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "PIC_LINE", args.PIC_LINE }, { "IN_SNO", args.IN_SNO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE } });

            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> grid0;
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> grid1;
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicSno> grid2;

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> getPicMstsResult;
        public IEnumerable<Models.Mark10Sqlexpress04.PicDtl> getPicDtlsResult { get; set; }


        public IEnumerable<Models.Mark10Sqlexpress04.PicSno> getPicSnosResult { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q060";
            await base.OnInitializedAsync();
        }
        public string GetSQL()
        {
            //DataTable dtMST = new DataTable("PIC_MST"); //盤點主檔
            //DataTable dtDTL = new DataTable("PIC_DTL"); //盤點明細檔
            //DataTable dtSNO = new DataTable("PIC_SNO"); //盤點序列號檔
            //string sSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.PIC_NO=b.PIC_NO) where 1=1", dtMST.TableName, dtDTL.TableName);
            //if (tbPIC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.PIC_NO like '%{0}%'", tbPIC_NO.Text.Trim().ToUpper());
            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());
            //if (tbCOUNT_USER.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.COUNT_USER like '%{0}%'", tbCOUNT_USER.Text.Trim().ToUpper());
            //if (tbPIC_TYPE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.PIC_TYPE like '%{0}%'", tbPIC_TYPE.Text.Trim().ToUpper());
            //sSQL = sSQL + " order by a.PIC_NO";
            var dtMST = "PIC_MST"; //盤點主檔
            var dtDTL = "PIC_DTL"; //盤點明細檔
            string strSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.PIC_NO=b.PIC_NO) where 1=1", dtMST, dtDTL);
            strSQL += GetContains("b.SKU_NO", ref txtSKU_NO);
            strSQL += GetContains("a.COUNT_USER", ref txtCOUNT_USER);
            strSQL += GetContains("a.PIC_NO", ref txtPIC_NO);
            strSQL += GetContains("a.PIC_TYPE", ref txtPIC_TYPE);
            //   GoodMsg = strSQL;
            return strSQL;
        }
       

        //}

        /// <summary>
        /// 這裡由於 grid0 宣告的限制, 必需在每個頁面做,
        /// 可以把 SwitchToTab0(); 納進來
        /// </summary>
        /// <returns></returns>
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
                getPicMstsResult = await AppDb.PicMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.PIC_NO).AsNoTracking().AsNoTracking().ToListAsync();

                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getPicMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getPicMstsResult.First();
                    await ReloadTab1();
                }
                else
                {
                    getPicDtlsResult = null;
                    getPicSnosResult = null;
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




        /// <summary>
        /// 參數的 type 是不定的
        /// 裡面的三行代碼是標準的, 可以直接抄
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task Grid0RowSelect(Models.Mark10Sqlexpress04.PicMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task ReloadTab1()
        {
            var args = ((PicMst)ObjTab0Selected);
            getPicDtlsResult = await AppDb.PicDtls.Where(a => a.PIC_NO == args.PIC_NO).AsNoTracking().ToListAsync();

            if (getPicDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPicDtlsResult.First();
                await ReloadTab2();
            }
            else
            {

            }
        }
        protected async Task ReloadTab2()
        {
            var args = ((PicDtl)ObjTab1Selected);

            var sSQL = string.Format(@"select * from {0} where PIC_NO='{1}' and PIC_LINE='{2}' ", "PIC_SNO", args.PIC_NO, args.PIC_LINE);
            //  order by PIC_NO,PIC_LINE,IN_SNO
            getPicSnosResult = await AppDb.PicSnos.FromSqlRaw(sSQL).OrderBy(a => a.IN_SNO).AsNoTracking().ToListAsync();
            if (getPicSnosResult.Count() > 0)
            {
                ObjTab2Selected = getPicSnosResult.First();
            }
        }


        protected async Task Grid1RowSelect(Models.Mark10Sqlexpress04.PicDtl args)
        {
            ObjTab1Selected = args;
            await ReloadTab2();
        }
        protected async Task Grid2RowSelect(Models.Mark10Sqlexpress04.PicSno args)
        {
            ObjTab2Selected = args;
        }
    }
}
