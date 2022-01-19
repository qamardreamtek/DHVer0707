using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace RadzenDh5.Pages
{
    /// <summary>
    /// 原 WES 在處理 Exeute 時, 判斷當時是選在那個tab
    /// 然後分別運行  ExecuteLOC(), ExecutePLT()
    /// 這部分在做的時, 有刻意去處理 Execute 分別在 tab0, tab1 的情況,
    /// 才能看到, 才能觸發
    /// TODO by Mark, 轉回仿 WES 的寫法, 可讀性的吻合度會較高
    /// </summary>
    public partial class P080Component
    {

        //DataTable dtMST = new DataTable("LOC_DTL"); //庫存明細
        //DataTable dtDTL = new DataTable("PLT_DTL"); //托盤明細
        string dtMST = "LOC_DTL"; //庫存明細
        string dtDTL = "PLT_DTL"; //托盤明細



        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vp080> grid0;
        public IEnumerable<Models.Mark10Sqlexpress04.Vp080> getVp080sResult { get; set; }
        public IEnumerable<Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult { get; set; }


        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P080";
            await base.OnInitializedAsync();
        }







        //public async Task ReloadMainTab()
        //{
        //    getPltDtlsResult = await AppDb.Vp080s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

        //    int cnt = getPltDtlsResult.Count(); ;
        //    //  GoodMsg = DhGlobals.getMsgWithTimestamp($@"{cnt} record(s) to display");
        //    await grid0.GoToPage(0);


        //}
        void DhFixRadzenTabsGridQueryNotBackToPage0<T>(ref RadzenGrid<T> grid)
        {
            selectedTabIndex = 0;
            grid.GoToPage(0);
        }
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                //DhFixRadzenTabsGridQueryNotBackToPage0In3Tabs(ref grid0, ref getPicMstsResult, ref getPicDtlsResult, ref getPicSnosResult);
                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);


                // 在 grid0 的 data 更新之前, 先調用 FixGrid0GotoPage0Async
                // await FixGrid0GotoPage0Async();

                getVp080sResult = await AppDb.Vp080s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();
                getPltDtlsResult = null; // 不管 Query 的結果如何, 任何 tab1  總是都要先清空

                // tab0:grid0 如果經過 Query , 含條件, 返回沒有任何 row時
                if (getVp080sResult.Count() < 1)
                {
                    // C030 Query 沒有任何結果並不提示
                    await SimpleDialog(@$"no data found");
                    return;
                }
                ObjTab0Selected = getVp080sResult.First();

                var args2 = (Vp080)ObjTab0Selected;
                txtSTK_CAT_tab0 = args2.STK_CAT.ToString();
                txtREMARK_tab0 = args2.REMARK;

                await ReloadTab1();

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
        protected async Task ButtonExecuteClick()
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                // LINE#61, P080.cs
                // if (m_dgvExMst.Rows.Count < 1) throw new Exception("no data to execute.");
                if (getVp080sResult.Count() < 1) throw new Exception("no data to execute.");

                var args = (Vp080)ObjTab0Selected;

                //Posting change只能在立庫貨架時更改
                // if (Convert.ToString(dgvRow.Cells["STGE_TYPE"].Value) != "ATR") throw new Exception("can't change the inventory data that storage type is not ATR.");
                if (args.STGE_TYPE != "ATR") throw new Exception("can't change the inventory data that storage type is not ATR.");

                //decimal dGTIN_ALO_QTY = Convert.ToDecimal(dgvRow.Cells["GTIN_ALO_QTY"].Value);
                decimal dGTIN_ALO_QTY = Convert.ToDecimal(args.GTIN_ALO_QTY);
                if (dGTIN_ALO_QTY > 0) throw new Exception("allocated stock can't change stock category.");

                if (selectedTabIndex == 0) await ExecuteLOC();
                if (selectedTabIndex == 1) await ExecutePLTAsync(); // 06/22 15:20, tab1 成功後加上提示 Change success
                // 06/22 15:20
                // MLASRS 在這裡, 不論是 tab0 或是 tab1 的更新, 
                // 都沒有再按查詢條件自動更新, 操作上,使用者會有些錯覺
                // 整個MLASRS 有些有做如上述的更新後按查詢條件自動更新,
                // 有些則沒有, 可以隨盟立要求做調整
                // 在這裡, 刻意做成會自動更新頁面, 加上註解說明
                await QueryMstAsync();

            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }

        /// <summary>
        /// 执行数据(LOC_DTL change)
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteLOC()
        {
            //只能整筆變更，不能改數量
            try
            {
                //var x = SelectedVp080;
                var x = (Vp080)ObjTab0Selected;

                //DataGridViewRow drRow = m_dgvExMst.CurrentRow;
                //string sSTK_CAT = Convert.ToString(drRow.Cells["STK_CAT"].Value);
                //string sREMARK = Convert.ToString(drRow.Cells["REMARK"].Value);
                string sSTK_CAT = Convert.ToString(x.STK_CAT);
                string sREMARK = Convert.ToString(x.REMARK);


                string sSTK_CAT_TO = sSTK_CAT;
                string sREMARK_TO = sREMARK;

                //for (int i = 0; i < m_dgvExMst.Columns.Count; i++)
                //{
                //    if (m_dgvExMst.Columns[i].Name == "STK_CAT")
                //    {
                //        sSTK_CAT_TO = Convert.ToString(dgvMstData.Rows[i].Cells[0].Value).Trim();
                //        if (sSTK_CAT == sSTK_CAT_TO) throw new Exception("no storage category change.");
                //        if (sSTK_CAT_TO != "" && sSTK_CAT_TO != "Q" && sSTK_CAT_TO != "S") throw new Exception("incorrect storage category.");
                //    }

                //    if (m_dgvExMst.Columns[i].Name == "REMARK") sREMARK_TO = Convert.ToString(dgvMstData.Rows[i].Cells[0].Value);
                //}
                // 上面這段是取輸入的值, 是在右側直式
                // 在 Web 提供這兩欄位在 grid 上方填入 
                // txtSTK_CAT_tab0 txtREMARK_tab0
                sSTK_CAT_TO = txtSTK_CAT_tab0 == null ? "" : txtSTK_CAT_tab0.Trim();
                sREMARK_TO = txtREMARK_tab0 == null ? "" : txtREMARK_tab0.Trim();

                if (sSTK_CAT == sSTK_CAT_TO) throw new Exception("no storage category change.");
                if (sSTK_CAT_TO != "" && sSTK_CAT_TO != "Q" && sSTK_CAT_TO != "S") throw new Exception("incorrect storage category.");


                //string sRet = Globals.UserLog("08", "P080", this.Text, m_dgvExMst.CurrentRow.Cells["SU_ID"].Value.ToString() + "/" + m_dgvExMst.CurrentRow.Cells["SKU_NO"].Value.ToString() + "/" + m_dgvExMst.CurrentRow.Cells["STK_CAT"].Value.ToString() + "/" + sSTK_CAT_TO);
                var msg = x.SU_ID + "/" + x.SKU_NO + "/" + x.STK_CAT + "/" + sSTK_CAT_TO;
                await DoUserLogAsync("08", "P080", PROG_NAME_FOR_LOG, msg);

                //Globals.ChangeLocStockCat(drRow, sSTK_CAT_TO, sREMARK_TO);
                // Design Note by Mark, 06/01, 最大使用原 MLASRS Biz Logic
                await DhGlobals.ChangeLocStockCatAsync(ConnectionString, DhUsername, x, sSTK_CAT_TO, sREMARK_TO);
                //MessageBox.Show("Change success");
                await SimpleDialog("Change success");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
        }



        /// <summary>
        /// 执行数据(PLT_DTL Change)
        /// </summary>
        /// <returns></returns>
        /*
        private void ExecutePLT()
        {
            //可以改STK_CAT & GTIN_QTY(無序列號)
            try
            {
                DataGridViewRow dgvRowMst = m_dgvExMst.CurrentRow;
                DataGridViewRow dgvRowDtl = m_dgvExDtl.CurrentRow;
                string sIN_NO = Convert.ToString(dgvRowDtl.Cells["IN_NO"].Value);
                string sIN_LINE = Convert.ToString(dgvRowDtl.Cells["IN_LINE"].Value);
                string sSU_ID = Convert.ToString(dgvRowDtl.Cells["SU_ID"].Value);
                string sIN_SNO = Convert.ToString(dgvRowDtl.Cells["IN_SNO"].Value);
                string sSTK_CAT = Convert.ToString(dgvRowDtl.Cells["STK_CAT"].Value);
                decimal dGTIN_QTY = Convert.ToDecimal(dgvRowDtl.Cells["GTIN_QTY"].Value);

                string sSTK_CAT_TO = sSTK_CAT;
                decimal dGTIN_QTY_TO = dGTIN_QTY;

                for (int i = 0; i < m_dgvExDtl.Columns.Count; i++)
                {
                    if (m_dgvExDtl.Columns[i].Name == "STK_CAT") sSTK_CAT_TO = Convert.ToString(dgvDtlData.Rows[i].Cells[0].Value);
                    if (m_dgvExDtl.Columns[i].Name == "GTIN_QTY") dGTIN_QTY_TO = Convert.ToDecimal(dgvDtlData.Rows[i].Cells[0].Value);
                }

                if (sSTK_CAT == sSTK_CAT_TO) throw new Exception("No storage category change.");
                if (dGTIN_QTY_TO == 0) throw new Exception("No quantity change.");
                if (dGTIN_QTY_TO > dGTIN_QTY) throw new Exception("The change quantity cannot exceed:" + dGTIN_QTY);
                if (sIN_SNO != "**********")
                {
                    if (dGTIN_QTY_TO != dGTIN_QTY) throw new Exception("The Serial no. quantity cannot change:" + sIN_SNO);
                }

                string sRet = Globals.UserLog("08", "P080", this.Text, m_dgvExMst.CurrentRow.Cells["SU_ID"].Value.ToString() + "/" + m_dgvExMst.CurrentRow.Cells["SKU_NO"].Value.ToString() + "/" + m_dgvExDtl.CurrentRow.Cells["IN_SNO"].Value.ToString() + "/" + m_dgvExMst.CurrentRow.Cells["STK_CAT"].Value.ToString() + "/" + sSTK_CAT_TO);
                Globals.ChangePlcStockCat(dgvRowMst, dgvRowDtl, sSTK_CAT_TO, dGTIN_QTY_TO);

                MessageBox.Show("Change success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */



        protected async Task ReloadTab1()
        {
            // SelectedPicMst = args;
            var args = (Vp080)ObjTab0Selected;

            // https://github.com/twoutlook/DH5Ver0414_PUBLISH/discussions/143
            //getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).OrderBy(a => a.SKU_NO).ThenBy(a => a.GR_DATE).ThenBy(a => a.IN_SNO).AsNoTracking().ToListAsync();


            var sSU_ID = args.SU_ID;
            var sWHSE_NO = args.WHSE_NO;
            var sPLANT = args.PLANT;
            var sSTGE_LOC = args.STGE_LOC;
            var sSKU_NO = args.SKU_NO;
            var sBATCH_NO = args.BATCH_NO;
            var sSTK_CAT = args.STK_CAT;
            var sSTK_SPECIAL_IND = args.STK_SPECIAL_IND;
            var sSTK_SPECIAL_NO = args.STK_SPECIAL_NO;
            var sGTIN_UNIT = args.GTIN_UNIT;


            string sSQL = string.Format(@"select * from {0} 
                    where SU_ID='{1}' and WHSE_NO='{2}' and PLANT='{3}' and STGE_LOC='{4}' and SKU_NO='{5}' and BATCH_NO='{6}' and IsNull(STK_CAT,'')='{7}' and IsNull(STK_SPECIAL_IND,'')='{8}' and IsNull(STK_SPECIAL_NO,'')='{9}' and GTIN_UNIT='{10}'
                    order by SKU_NO,GR_DATE,IN_SNO
                ", dtDTL, sSU_ID, sWHSE_NO, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO, sSTK_CAT, sSTK_SPECIAL_IND, sSTK_SPECIAL_NO, sGTIN_UNIT);
            //Globals.QueryTable(ref dtDTL, sSQL);
            getPltDtlsResult = await AppDb.PltDtls.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();

            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();

                var args2 = (PltDtl)ObjTab1Selected;

                txtSTK_CAT_tab1 = args2.STK_CAT;
                txtGTIN_QTY_tab1 = args2.GTIN_QTY.ToString();

            }
        }

        private async Task ExecutePLTAsync()
        {
            try
            {
                //var item = SelectedPltDtl;
                var item = (PltDtl)ObjTab1Selected;

                //DataGridViewRow dgvRowMst = m_dgvExMst.CurrentRow;
                //DataGridViewRow dgvRowDtl = m_dgvExDtl.CurrentRow;
                string sIN_NO = Convert.ToString(item.IN_NO);
                string sIN_LINE = Convert.ToString(item.IN_LINE);
                string sSU_ID = Convert.ToString(item.SU_ID);
                string sIN_SNO = Convert.ToString(item.IN_SNO);
                string sSTK_CAT = Convert.ToString(item.STK_CAT.Trim()); //' ' == '' problem
                decimal dGTIN_QTY = Convert.ToDecimal(item.GTIN_QTY);

                string sSTK_CAT_TO = sSTK_CAT;
                //decimal dGTIN_QTY_TO = dGTIN_QTY;

                //for (int i = 0; i < m_dgvExDtl.Columns.Count; i++)
                //{
                //    if (m_dgvExDtl.Columns[i].Name == "STK_CAT") sSTK_CAT_TO = Convert.ToString(dgvDtlData.Rows[i].Cells[0].Value);
                //    if (m_dgvExDtl.Columns[i].Name == "GTIN_QTY") dGTIN_QTY_TO = Convert.ToDecimal(dgvDtlData.Rows[i].Cells[0].Value);
                //}

                decimal dGTIN_QTY_TO = 0;
                try
                {
                    dGTIN_QTY_TO = Decimal.Parse(txtGTIN_QTY_tab1);
                }
                catch
                {
                    // as 0
                }

                sSTK_CAT_TO = txtSTK_CAT_tab1 == null ? "" : txtSTK_CAT_tab1.Trim();
                //await SimpleDialog(@$"debug for sSTK_CAT == sSTK_CAT_TO =>'{sSTK_CAT}' == '{sSTK_CAT_TO}'");

                if (sSTK_CAT == sSTK_CAT_TO) throw new Exception("No storage category change.");
                if (dGTIN_QTY_TO == 0) throw new Exception("No quantity change.");
                if (dGTIN_QTY_TO > dGTIN_QTY) throw new Exception("The change quantity cannot exceed:" + dGTIN_QTY);
                if (sIN_SNO != "**********")
                {
                    if (dGTIN_QTY_TO != dGTIN_QTY) throw new Exception("The Serial no. quantity cannot change:" + sIN_SNO);
                }

                //    string sRet = Globals.UserLog("08", "P080", this.Text, m_dgvExMst.CurrentRow.Cells["SU_ID"].Value.ToString() + "/"
                //    + m_dgvExMst.CurrentRow.Cells["SKU_NO"].Value.ToString() + "/"
                //    + m_dgvExDtl.CurrentRow.Cells["IN_SNO"].Value.ToString() + "/"
                //    + m_dgvExMst.CurrentRow.Cells["STK_CAT"].Value.ToString() + "/"
                //    + sSTK_CAT_TO);
                var x = (Vp080)ObjTab0Selected;
                var y = (PltDtl)ObjTab1Selected; ;

                var msg = x.SU_ID + "/" + x.SKU_NO + "/" + y.IN_SNO + "/" + x.STK_CAT + "/" + sSTK_CAT_TO;
                await DoUserLogAsync("08", "P080", PROG_NAME_FOR_LOG, msg);

                //Globals.ChangePlcStockCat(dgvRowMst, dgvRowDtl, sSTK_CAT_TO, dGTIN_QTY_TO);
                await DhGlobals.MLASRS_ChangePlcStockCat_Async(ConnectionString, DhUsername, x, y, sSTK_CAT_TO, dGTIN_QTY_TO);


                //  MessageBox.Show("Change success");
                await SimpleDialog("Change success");
            }
            catch (Exception ex)
            {
                //ErrMsg = ex.Message;
                throw;

            }

        }


        protected string GetSQL()
        {
            // Philosophy: to ensure necessary pre processing


            txtSKU_NO = (txtSKU_NO == null) ? "" : txtSKU_NO.Trim();
            txtBATCH_NO = (txtBATCH_NO == null) ? "" : txtBATCH_NO.Trim();
            txtSTK_CAT = (txtSTK_CAT == null) ? "" : txtSTK_CAT.Trim();
            txtSTK_SPECIAL_IND = (txtSTK_SPECIAL_IND == null) ? "" : txtSTK_SPECIAL_IND.Trim();
            txtSTK_SPECIAL_NO = (txtSTK_SPECIAL_NO == null) ? "" : txtSTK_SPECIAL_NO.Trim();
            txtLOC_NO = (txtLOC_NO == null) ? "" : txtLOC_NO.Trim();
            txtSU_ID = (txtSU_ID == null) ? "" : txtSU_ID.Trim();
            txtIN_NO = (txtIN_NO == null) ? "" : txtIN_NO.Trim();
            txtGR_DATE = (txtGR_DATE == null) ? "" : txtGR_DATE.Trim();
            txtDATE_CODE = (txtDATE_CODE == null) ? "" : txtDATE_CODE.Trim();
            txtEXPIRE_DATE = (txtEXPIRE_DATE == null) ? "" : txtEXPIRE_DATE.Trim();
            txtINSP_LOT = (txtINSP_LOT == null) ? "" : txtINSP_LOT.Trim();
            txtGTIN_NO = (txtGTIN_NO == null) ? "" : txtGTIN_NO.Trim();
            txtREQM_NO = (txtREQM_NO == null) ? "" : txtREQM_NO.Trim();


            string sSQL = string.Format(@"select distinct a.*,d.SKU_SNO_IND from {0} a 
                    join {1} b
                    on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
                    join IN_DTL c 
                    on (b.WHSE_NO=c.WHSE_NO and b.IN_NO=c.IN_NO and b.IN_LINE=c.IN_LINE)
                    join SKU_MST d
                    on (a.SKU_NO=d.SKU_NO)
                    where a.STGE_TYPE='ATR'", dtMST, dtDTL);


            if (txtSKU_NO != "") sSQL += $@" and a.SKU_NO like '%{txtSKU_NO}%'"; // NOTE to check a. b. c. d.
            if (txtBATCH_NO != "") sSQL += $@" and IsNull(a.BATCH_NO,'') like '%{txtBATCH_NO}%'"; // NOTE to check a. b. c. d.
            if (txtSTK_CAT != "") sSQL += $@" and IsNull(a.STK_CAT,'') = '{txtSTK_CAT}'"; // NOTE to check a. b. c. d.
            if (txtSTK_SPECIAL_IND != "") sSQL += $@" and IsNull(a.STK_SPECIAL_IND,'') = '{txtSTK_SPECIAL_IND}'"; // NOTE to check a. b. c. d.
            if (txtSTK_SPECIAL_NO != "") sSQL += $@" and IsNull(a.STK_SPECIAL_NO,'') = '{txtSTK_SPECIAL_NO}'"; // NOTE to check a. b. c. d.
            if (txtLOC_NO != "") sSQL += $@" and a.LOC_NO like '%{txtLOC_NO}%'"; // NOTE to check a. b. c. d.
            if (txtSU_ID != "") sSQL += $@" and a.SU_ID like '%{txtSU_ID}%'"; // NOTE to check a. b. c. d.

            if (txtIN_NO != "") sSQL += $@" and b.IN_NO like '%{txtIN_NO}%'"; // NOTE to check a. b. c. d.
            if (txtGR_DATE != "") sSQL += $@" and b.GR_DATE like '%{txtGR_DATE}%'"; // NOTE to check a. b. c. d.
            if (txtDATE_CODE != "") sSQL += $@" and b.DATE_CODE like '%{txtDATE_CODE}%'"; // NOTE to check a. b. c. d.
            if (txtEXPIRE_DATE != "") sSQL += $@" and b.EXPIRE_DATE like '%{txtEXPIRE_DATE}%'"; // NOTE to check a. b. c. d.

            if (txtINSP_LOT != "") sSQL += $@" and c.INSP_LOT like '%{txtINSP_LOT}%'"; // NOTE to check a. b. c. d.
            if (txtGTIN_NO != "") sSQL += $@" and c.GTIN_NO like '%{txtGTIN_NO}%'"; // NOTE to check a. b. c. d.
            if (txtREQM_NO != "") sSQL += $@" and c.REQM_NO like '%{txtREQM_NO}%'"; // NOTE to check a. b. c. d.





            //if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SKU_NO like '%{0}%'", tbSKU_NO.Text.Trim().ToUpper());

            //if (tbBATCH_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.BATCH_NO,'') like '%{0}%'", tbBATCH_NO.Text.Trim().ToUpper());
            //if (tbSTK_CAT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.STK_CAT,'') = '{0}'", tbSTK_CAT.Text.Trim().ToUpper());
            //if (tbSTK_SPECIAL_IND.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.STK_SPECIAL_IND,'') = '{0}'", tbSTK_SPECIAL_IND.Text.Trim().ToUpper());
            //if (tbSTK_SPECIAL_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and IsNull(a.STK_SPECIAL_NO,'') = '{0}'", tbSTK_SPECIAL_NO.Text.Trim().ToUpper());

            //if (tbLOC_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.LOC_NO like '%{0}%'", tbLOC_NO.Text.Trim().ToUpper());
            //if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and a.SU_ID like '%{0}%'", tbSU_ID.Text.Trim().ToUpper());

            //if (tbIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.IN_NO like '%{0}%'", tbIN_NO.Text.Trim().ToUpper());
            //if (tbGR_DATE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.GR_DATE like '%{0}%'", tbGR_DATE.Text.Trim().ToUpper());
            //if (tbDATE_CODE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.DATE_CODE like '%{0}%'", tbDATE_CODE.Text.Trim().ToUpper());
            //if (tbEXPIRE_DATE.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and b.EXPIRE_DATE like '%{0}%'", tbEXPIRE_DATE.Text.Trim().ToUpper());

            //if (tbINSP_LOT.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and c.INSP_LOT like '%{0}%'", tbINSP_LOT.Text.Trim().ToUpper());
            //if (tbGTIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and c.GTIN_NO like '%{0}%'", tbGTIN_NO.Text.Trim().ToUpper());
            //if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@" and c.REQM_NO like '%{0}%'", tbREQM_NO.Text.Trim().ToUpper());

            sSQL = sSQL + " order by a.SKU_NO, a.SU_ID";
            return sSQL;
        }



        protected async Task Grid0RowSelect(Models.Mark10Sqlexpress04.Vp080 args)
        {
            ObjTab0Selected = args;


            txtSTK_CAT_tab0 = args.STK_CAT.ToString();
            txtREMARK_tab0 = args.REMARK;

            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task Grid1RowSelect(Models.Mark10Sqlexpress04.PltDtl args)
        {
            ObjTab1Selected = args;

            var args2 = (PltDtl)ObjTab1Selected;

            txtSTK_CAT_tab1 = args2.STK_CAT;
            txtGTIN_QTY_tab1 = args2.GTIN_QTY.ToString();

        }

        /// <summary>
        /// 由於 Vp080 tab0 的 grid0 不是標準的 entity, 無法使用標準模板
        /// 這是特例設什出來的 View, 這個反應速度會比標準的 Edit entity 改的 View entity 會快
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.Vp080 args)
        {
            // 原有考慮傳一個 Vc010, 但由於還要多語翻譯, 因此先把翻譯好的欄位名和其值傳到 DialogViewC010
            await DialogService.OpenAsync<DialogViewP080>($"LOC_DTL**",
                       new Dictionary<string, object>() { {"h1", $"{ Lang("WHSE_NO")}"},{ "v1", $"{args.WHSE_NO}"},{"h2", $"{ Lang("STGE_TYPE")}"},{ "v2", $"{args.STGE_TYPE}"},{"h3", $"{ Lang("STGE_BIN")}"},{ "v3", $"{args.STGE_BIN}"},{"h4", $"{ Lang("SU_ID")}"},{ "v4", $"{args.SU_ID}"},{"h5", $"{ Lang("SU_TYPE")}"},{ "v5", $"{args.SU_TYPE}"},{"h6", $"{ Lang("LOC_NO")}"},{ "v6", $"{args.LOC_NO}"},{"h7", $"{ Lang("PLANT")}"},{ "v7", $"{args.PLANT}"},{"h8", $"{ Lang("STGE_LOC")}"},{ "v8", $"{args.STGE_LOC}"},{"h9", $"{ Lang("SKU_NO")}"},{ "v9", $"{args.SKU_NO}"},{"h10", $"{ Lang("BATCH_NO")}"},{ "v10", $"{args.BATCH_NO}"},
                           {"h11", $"{ Lang("STK_CAT")}"},{ "v11", $"{args.STK_CAT}"},{"h12", $"{ Lang("STK_SPECIAL_IND")}"},{ "v12", $"{args.STK_SPECIAL_IND}"},{"h13", $"{ Lang("STK_SPECIAL_NO")}"},{ "v13", $"{args.STK_SPECIAL_NO}"},{"h14", $"{ Lang("GTIN_UNIT")}"},{ "v14", $"{args.GTIN_UNIT}"},{"h15", $"{ Lang("GTIN_QTY")}"},{ "v15", $"{args.GTIN_QTY}"},{"h16", $"{ Lang("SKU_UNIT")}"},{ "v16", $"{args.SKU_UNIT}"},{"h17", $"{ Lang("SKU_QTY")}"},{ "v17", $"{args.SKU_QTY}"},{"h18", $"{ Lang("GTIN_NUMERATOR")}"},{ "v18", $"{args.GTIN_NUMERATOR}"},{"h19", $"{ Lang("GTIN_DENOMINATOR")}"},{ "v19", $"{args.GTIN_DENOMINATOR}"},{"h20", $"{ Lang("GROSS_WEIGHT")}"},{ "v20", $"{args.GROSS_WEIGHT}"},
                           {"h21", $"{ Lang("NET_WEIGHT")}"},{ "v21", $"{args.NET_WEIGHT}"},{"h22", $"{ Lang("WEIGHT_UNIT")}"},{ "v22", $"{args.WEIGHT_UNIT}"},{"h23", $"{ Lang("VOLUME")}"},{ "v23", $"{args.VOLUME}"},{"h24", $"{ Lang("VOLUME_UNIT")}"},{ "v24", $"{args.VOLUME_UNIT}"},{"h25", $"{ Lang("GTIN_ALO_QTY")}"},{ "v25", $"{args.GTIN_ALO_QTY}"},{"h26", $"{ Lang("SKU_ALO_QTY")}"},{ "v26", $"{args.SKU_ALO_QTY}"},{"h27", $"{ Lang("REMARK")}"},{ "v27", $"{args.REMARK}"},{"h28", $"{ Lang("TRN_USER")}"},{ "v28", $"{args.TRN_USER}"},{"h29", $"{ Lang("TRN_DATE")}"},{ "v29", $"{args.TRN_DATE}"},{"h30", $"{ Lang("CRT_USER")}"},{ "v30", $"{args.CRT_USER}"},{"h31", $"{ Lang("CRT_DATE")}"},{ "v31", $"{args.CRT_DATE}"},{"h32", $"{ Lang("SKU_SNO_IND")}"},{ "v32", $"{args.SKU_SNO_IND}"},
                             },
                       new DialogOptions() { });
        }
        protected async System.Threading.Tasks.Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }


    }
}