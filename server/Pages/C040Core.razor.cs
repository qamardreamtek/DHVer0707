using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class C040CoreComponent
    {
        public string txtCOUNT_QTY_Input;
        public string txtREMARK_Input;

        protected RadzenGrid<PicMst> grid0;

        // SOP, grid Data
        protected IEnumerable<PicMst> getPicMstsResult { get; set; }
        public IEnumerable<PicDtl> getPicDtlsResult { get; set; }
        public IEnumerable<PicSno> getPicSnosResult { get; set; }



        /// <summary>
        /// 其它大部分的 tab0-tab1-tab2
        /// 都可以直接連動, 但是C030,C040很可能多了要編輯的欄位而造成影響
        /// 先改寫為 
        /// 看不到時不連動,
        /// 切換 tab時才即時更新
        /// 
        /// </summary>
        /// <param name="index"></param>
        public new async Task OnTabChange(int index)
        {
            // DEBUG, by Mark, 06/02, Q060 tab2 problem
            if (index == 1)
            {
                await ReloadTab1();
                await InvokeAsync(() => { StateHasChanged(); });
            }
            if (index == 2)
            {
                await ReloadTab2();
                await InvokeAsync(() => { StateHasChanged(); });
            }

        }

        public string txtSKU_NO;
        public string txtPIC_USER;
        public string txtPIC_NO;
        public string txtSU_ID;
        public string txtIN_SNO;

        //DataTable dtMST = new DataTable("PIC_MST"); //盤點主檔
        //DataTable dtDTL = new DataTable("PIC_DTL"); //盤點明細檔
        //DataTable dtSNO = new DataTable("PIC_SNO"); //盤點序列號檔

        string dtMST = "PIC_MST"; //盤點主檔
        string dtDTL = "PIC_DTL"; //盤點明細檔
        string dtSNO = "PIC_SNO"; //盤點序列號檔
        string sAPPROVE = "N";
        //string sAPPROVE_UPDATE = "N";

        public string sPIC_NO; // by selecting row of PID Header 
        public string sPIC_LINE; // by selecting row of PIC Items
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "C040";
            await base.OnInitializedAsync();

            // 實現這段
            //if (progWrt.APPROVE_WRT != "Y") { m_menuItemConfirm.Enabled = false; m_menuItemConfirm.Visible = false; m_menuItemExport.Enabled = false; m_menuItemExport.Visible = false; }
            //else sAPPROVE = "Y";
            if (progWrt.APPROVE_WRT != "Y")
            {
                //m_menuItemConfirm.Enabled = false; 
                //m_menuItemConfirm.Visible = false; 
                //m_menuItemExport.Enabled = false; 
                //m_menuItemExport.Visible = false; 

                // 如果沒有 APPROVE_WRT, 不顯示 Confirm
            }
            else
            {
                sAPPROVE = "Y";
            }





            // NOTE tab1 and tab2 都可以編輯
            //for (int i = 0; i < m_dgvExDtl.Columns.Count; i++)
            //{
            //    if (Convert.ToString(m_dgvExDtl.Columns[i].Name) != "COUNT_QTY" && Convert.ToString(m_dgvExDtl.Columns[i].Name) != "REMARK")
            //    {
            //        dgvDtlData.Rows[i].Cells[0].ReadOnly = true;
            //    }
            //}

            //for (int i = 0; i < m_dgvExSno.Columns.Count; i++)
            //{

            //    if (Convert.ToString(m_dgvExSno.Columns[i].Name) != "COUNT_QTY" && Convert.ToString(m_dgvExSno.Columns[i].Name) != "REMARK")
            //    {
            //        dgvSnoData.Rows[i].Cells[0].ReadOnly = true;
            //    }
            //}
        }
        public string GetSQL()

        {
            // Friendly to trim, SOP by Mark, 05/05
            if (txtSU_ID != null) txtSU_ID = txtSU_ID.Trim();
            if (txtPIC_USER != null) txtPIC_USER = txtPIC_USER.Trim();
            if (txtPIC_NO != null) txtPIC_NO = txtPIC_NO.Trim();
            if (txtSU_ID != null) txtSU_ID = txtSU_ID.Trim();
            if (txtIN_SNO != null) txtIN_SNO = txtIN_SNO.Trim();

            //  The only difference, PIC_STS 多了為 9 的狀態
            //  string sSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.PIC_NO=b.PIC_NO) where a.PIC_STS  in ('0','1','2','3') and a.PIC_TYPE !='01'", dtMST, dtDTL);

            string sSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.PIC_NO=b.PIC_NO) where a.PIC_STS in ('0','1','2','3','9') and a.PIC_TYPE !='01' and a.APPROVE_IND='N'", dtMST, dtDTL);

            if (txtPIC_NO != null && txtPIC_NO != "") sSQL = sSQL + string.Format(@" and a.PIC_NO like '%{0}%'", txtPIC_NO);
            if (txtSKU_NO != null && txtSKU_NO != "") sSQL = sSQL + string.Format(@" and b.SKU_NO like '%{0}%'", txtSKU_NO);
            if (txtSU_ID != null && txtSU_ID != "") sSQL = sSQL + string.Format(@" and b.SU_ID like '%{0}%'", txtSU_ID);
            if (txtPIC_USER != null && txtPIC_USER != "") sSQL = sSQL + string.Format(@" and a.COUNT_USER like '%{0}%'", txtPIC_USER);
            sSQL += " order by a.PIC_NO";
            return sSQL;


        }

        protected async Task QueryMstAsync()
        {
            ResetGridBindAndSwitchToTab0();
            getPicDtlsResult = null;
            getPicSnosResult = null;

            //string sRet = Globals.UserLog("01", "C040", this.Text, "");
            await DoUserLogAsync("01", "C040", PROG_NAME_FOR_LOG, "");

            DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
            getPicMstsResult = await AppDb.PicMsts.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

            if (getPicMstsResult.Count() >= 1)
            {
                ObjTab0Selected = getPicMstsResult.FirstOrDefault();
                await ReloadTab1();// 也連動 Tab2
            }
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }


        private async Task CellBeginEdit_Dtl()
        {
            //DataGridView dgv = (DataGridView)sender;
            try
            {
                if (ObjTab1Selected == null)
                {
                    throw new Exception("no selected row to edit");
                }
                var args = (PicDtl)ObjTab1Selected;

                //if (m_dgvExDtl.RowCount < 1) e.Cancel = true;

                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[this.Name.ToString()];
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization");

                //int iRow = e.RowIndex;
                //int iCol = e.ColumnIndex;

                //if (Convert.ToString(m_dgvExDtl.CurrentRow.Cells["SERIAL_IND"].Value).Trim() != "") //有序列號 

                if (args.SERIAL_IND.Trim() != "") //有序列號 
                {
                    //dgv.Rows[iRow].Cells[0].ReadOnly = true;
                    //e.Cancel = true;
                }
                else
                {
                    //if (m_dgvExSno.RowCount == 0) //無序列號且沒有明細，須新增
                    if (getPicSnosResult.Count() == 0) //無序列號且沒有明細，須新增
                    {
                        //string sWHSE_NO = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["WHSE_NO"].Value);
                        //string sPIC_NO = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["PIC_NO"].Value);
                        //string sPIC_LINE = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["PIC_LINE"].Value);
                        //string sSTGE_TYPE = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["STGE_TYPE"].Value);
                        //string sSTGE_BIN = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["STGE_BIN"].Value);
                        //string sSU_ID = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["SU_ID"].Value);
                        //string sPLANT = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["PLANT"].Value);
                        //string sSTGE_LOC = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["STGE_LOC"].Value);
                        //string sSKU_NO = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["SKU_NO"].Value);
                        //string sBATCH_NO = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["BATCH_NO"].Value);
                        //string sCOUNT_UNIT = Convert.ToString(m_dgvExDtl.Rows[iRow].Cells["COUNT_UNIT"].Value);


                        string sWHSE_NO = Convert.ToString(args.WHSE_NO);
                        string sPIC_NO = Convert.ToString(args.PIC_NO);
                        string sPIC_LINE = Convert.ToString(args.PIC_LINE);
                        string sSTGE_TYPE = Convert.ToString(args.STGE_TYPE);
                        string sSTGE_BIN = Convert.ToString(args.STGE_BIN);
                        string sSU_ID = Convert.ToString(args.SU_ID);
                        string sPLANT = Convert.ToString(args.PLANT);
                        string sSTGE_LOC = Convert.ToString(args.STGE_LOC);
                        string sSKU_NO = Convert.ToString(args.SKU_NO);
                        string sBATCH_NO = Convert.ToString(args.BATCH_NO);
                        string sCOUNT_UNIT = Convert.ToString(args.COUNT_UNIT);

                        string sSQL = string.Format(@"
                            insert into PIC_SNO 
                            select '{0}' as WHSE_NO,'{1}' as PIC_NO,'{2}' as PIC_LINE,'{3}' as STGE_TYPE,'{4}' as STGE_BIN,'{5}' as SU_ID,'{6}' as PLANT,'{7}' as STGE_LOC,'{8}' as SKU_NO,'{9}' as BATCH_NO,IN_SNO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,'{10}' as COUNT_UNIT,0 as COUNT_QTY,'{11}' as COUNT_USER,convert(varchar(19),getdate(),20) as COUNT_DATE,'' as APPROVE_USER,'' as APPROVE_DATE,convert(varchar(19),getdate(),20) as START_DATE,convert(varchar(19),getdate(),20) as END_DATE,'0' as PIC_STS,'' as REMARK,'1' as SOURCE,'N' as APPROVE_IND,convert(varchar(19),getdate(),20) as TRN_DATE,'{11}' as TRN_USER,convert(varchar(19),getdate(),20) as CRT_DATE,'{11}' as CRT_USER,IN_NO,IN_LINE
                            from PLT_DTL 
                            where WHSE_NO='{0}' and SU_ID='{5}' and PLANT='{6}' and STGE_LOC='{7}' and SKU_NO='{8}' and BATCH_NO='{9}' and GTIN_UNIT='{10}'
                            ", sWHSE_NO, sPIC_NO, sPIC_LINE, sSTGE_TYPE, sSTGE_BIN, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO.Trim(), sCOUNT_UNIT, DhUsername);
                        //if (Globals.UpdateTable(sSQL) > 0)
                        //{
                        //    DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, m_dgvExDtl.CurrentRow.Index);
                        //    CellClick_Dtl(m_dgvExDtl, ee);
                        //}
                        //else throw new Exception("no data update:" + sSQL);
                        using var dbTransaction = AppDb.Database.BeginTransaction();
                        try
                        {
                            var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                            if (cnt > 0)
                            {
                                dbTransaction.Commit();
                            }
                            else throw new Exception("no data update:" + sSQL);

                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            throw;
                        }
                    }
                }

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "COUNT_QTY" && Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "REMARK") e.Cancel = true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //dgv.CurrentRow.Cells[0].Value = Convert.ToString(dgv.CurrentRow.Cells[0].Tag);
                throw;
            }
        }

        private async Task CellEndEdit_Dtl(string header)
        {
            //更改PIC_DTL的COUNT_QTY & REMARK
            //DataGridView dgv = (DataGridView)sender;
            string sSQL = string.Empty;
            string sSQL1 = string.Empty;
            string sSQL2 = string.Empty;

            try
            {
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[this.Name.ToString()];
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization");

                //int iRow = e.RowIndex;
                //int iCol = e.ColumnIndex;

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "COUNT_QTY" && Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "REMARK") return;

                //string sWHSE_NO = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["WHSE_NO"].Value);
                //string sPIC_NO = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["PIC_NO"].Value);
                //string sPIC_LINE = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["PIC_LINE"].Value);
                //string sCOUNT_UNIT = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["COUNT_UNIT"].Value);

                var args = (PicDtl)ObjTab1Selected;
                string sWHSE_NO = Convert.ToString(args.WHSE_NO);
                string sPIC_NO = Convert.ToString(args.PIC_NO);
                string sPIC_LINE = Convert.ToString(args.PIC_LINE);
                string sCOUNT_UNIT = Convert.ToString(args.COUNT_UNIT);

                ////string sGTIN_UNIT = Convert.ToString(m_dgvExSno.CurrentRow.Cells["GTIN_UNIT"].Value);
                ////string sSKU_UNIT = Convert.ToString(m_dgvExSno.CurrentRow.Cells["SKU_UNIT"].Value);
                ////string sIN_SNO = Convert.ToString(m_dgvExSno.CurrentRow.Cells["IN_SNO"].Value);
                ////decimal dGTIN_QTY = Convert.ToDecimal(m_dgvExSno.CurrentRow.Cells["GTIN_QTY"].Value);
                ////decimal dSKU_QTY = Convert.ToDecimal(m_dgvExSno.CurrentRow.Cells["SKU_QTY"].Value);


                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) == "COUNT_QTY")
                if (header == "COUNT_QTY")
                {
                    //decimal dCOUNT_QTY = Convert.ToDecimal(dgv.CurrentRow.Cells[0].Value); //op輸入COUNT_QTY
                    decimal dCOUNT_QTY = Convert.ToDecimal(txtCOUNT_QTY_tab1); //op輸入COUNT_QTY
                    //if (sCOUNT_UNIT == sSKU_UNIT)
                    //{
                    //    if (dCOUNT_QTY > dSKU_QTY) throw new Exception("can't over stock quantity:" + dSKU_QTY.ToString());
                    //}
                    //if (sCOUNT_UNIT == sGTIN_UNIT)
                    //{
                    //    if (dCOUNT_QTY > dGTIN_QTY) throw new Exception("can't over stock quantity:" + dGTIN_QTY.ToString());
                    //}

                    //if (sIN_SNO != "**********") //為序列號不可分割,可為0
                    //{
                    //    if (sCOUNT_UNIT == sSKU_UNIT)
                    //    {
                    //        if (dCOUNT_QTY < dSKU_QTY && dCOUNT_QTY > 0) throw new Exception("Serial number can't split");
                    //    }
                    //    if (sCOUNT_UNIT == sGTIN_UNIT)
                    //    {
                    //        if (dCOUNT_QTY < dGTIN_QTY && dCOUNT_QTY > 0) throw new Exception("Serial number can't split");
                    //    }
                    //}

                    //備份PIC_SNO
                    sSQL = string.Format(@"
                        insert into PIC_SNO_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{0}' as LOG_USER from PIC_SNO 
                        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'
                    ", DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);

                    //更新PIC_SNO
                    sSQL1 = string.Format(@"
                        update PIC_SNO set PIC_STS='3',COUNT_QTY={0},TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20),COUNT_USER='{1}',COUNT_DATE=convert(varchar(19),getdate(),20),END_DATE=convert(varchar(19),getdate(),20) 
                        where WHSE_NO='{2}' and PIC_NO='{3}' and PIC_LINE='{4}' 
                    ", dCOUNT_QTY, DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);

                    //備份PIC_DTL
                    sSQL2 = string.Format(@"
                        insert into PIC_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{0}' as LOG_USER from PIC_DTL 
                        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'
                    ", DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);

                    //更新PIC_DTL
                    string sSQL3 = string.Format(@"
                        update PIC_DTL set PIC_STS='3',COUNT_QTY=(select sum(COUNT_QTY) from PIC_SNO where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'), 
                            TRN_USER='{0}',TRN_DATE=convert(varchar(19),getdate(),20),COUNT_USER='{0}',END_DATE=convert(varchar(19),getdate(),20) 
                        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'
                    ", DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);


                    //if (Globals.UpdateTable(new string[] { sSQL, sSQL1, sSQL2, sSQL3 }, new bool[] { false, false, true, true }))
                    //{
                    //    m_dgvExDtl.CurrentRow.Cells["COUNT_QTY"].Value = Decimal.Round(dCOUNT_QTY, 3);

                    //    DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, m_dgvExDtl.CurrentRow.Index);
                    //    CellClick_Dtl(m_dgvExDtl, ee);
                    //}
                    //else throw new Exception("no data update:" + sSQL);

                    using var dbTransaction = AppDb.Database.BeginTransaction();
                    try
                    {
                        var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                        var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                        var cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL3);
                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        throw new Exception("no data update:" + sSQL);
                    }
                }

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) == "REMARK")
                if (header == "REMARK")
                {
                    //string sREMARK = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
                    string sREMARK = Convert.ToString(txtREMARK_tab1);

                    //備份PIC_DTL
                    sSQL = string.Format(@"
                        insert into PIC_DTL_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{0}' as LOG_USER from PIC_DTL 
                        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'
                    ", DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);

                    sSQL1 = string.Format(@"
                        update PIC_DTL set PIC_STS='3',REMARK=N'{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20) 
                        where WHSE_NO='{2}' and PIC_NO='{3}' and PIC_LINE='{4}'
                    ", sREMARK, DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);

                    //if (Globals.UpdateTable(new string[] { sSQL, sSQL1 }, new bool[] { true, true }))
                    //{
                    //    m_dgvExDtl.CurrentRow.Cells["REMARK"].Value = sREMARK;
                    //    dgv.CurrentRow.Cells[0].Tag = sREMARK;
                    //}
                    //else throw new Exception("no data update:" + sSQL);
                    using var dbTransaction = AppDb.Database.BeginTransaction();
                    try
                    {
                        var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        throw new Exception("no data update:" + sSQL);
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //dgv.CurrentRow.Cells[0].Value = Convert.ToString(dgv.CurrentRow.Cells[0].Tag);
                throw;
            }
        }
        private async Task CellBeginEdit_Sno()
        {
            //DataGridView dgv = (DataGridView)sender;
            try
            {
                //if (m_dgvExSno.RowCount < 1) e.Cancel = true;

                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[this.Name.ToString()];
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization");

                //int iRow = e.RowIndex;
                //int iCol = e.ColumnIndex;

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "COUNT_QTY" && Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "REMARK") e.Cancel = true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //dgv.CurrentRow.Cells[0].Value = Convert.ToString(dgv.CurrentRow.Cells[0].Tag);
                throw;
            }
        }
        //private void CellEndEdit_Sno(object sender, DataGridViewCellEventArgs e)
        private async Task CellEndEdit_Sno(string header)
        {
            //更改PIC_SNO的SKU_QTY & REMARK
            //DataGridView dgv = (DataGridView)sender;
            string sSQL = string.Empty;
            string sSQL1 = string.Empty;
            string sSQL2 = string.Empty;

            try
            {
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[this.Name.ToString()];
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization");

                //int iRow = e.RowIndex;
                //int iCol = e.ColumnIndex;

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "COUNT_QTY" && Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "REMARK") return;

                //string sWHSE_NO = Convert.ToString(m_dgvExSno.CurrentRow.Cells["WHSE_NO"].Value);
                //string sPIC_NO = Convert.ToString(m_dgvExSno.CurrentRow.Cells["PIC_NO"].Value);
                //string sPIC_LINE = Convert.ToString(m_dgvExSno.CurrentRow.Cells["PIC_LINE"].Value);
                //string sGTIN_UNIT = Convert.ToString(m_dgvExSno.CurrentRow.Cells["GTIN_UNIT"].Value);
                //string sSKU_UNIT = Convert.ToString(m_dgvExSno.CurrentRow.Cells["SKU_UNIT"].Value);
                //string sIN_SNO = Convert.ToString(m_dgvExSno.CurrentRow.Cells["IN_SNO"].Value);
                //string sIN_NO = Convert.ToString(m_dgvExSno.CurrentRow.Cells["IN_NO"].Value);
                //string sIN_LINE = Convert.ToString(m_dgvExSno.CurrentRow.Cells["IN_LINE"].Value);
                //string sCOUNT_UNIT = Convert.ToString(m_dgvExSno.CurrentRow.Cells["COUNT_UNIT"].Value);
                //decimal dGTIN_QTY = Convert.ToDecimal(m_dgvExSno.CurrentRow.Cells["GTIN_QTY"].Value);
                //decimal dSKU_QTY = Convert.ToDecimal(m_dgvExSno.CurrentRow.Cells["SKU_QTY"].Value);


                var args = (PicSno)ObjTab2Selected;

                string sWHSE_NO = Convert.ToString(args.WHSE_NO);
                string sPIC_NO = Convert.ToString(args.PIC_NO);
                string sPIC_LINE = Convert.ToString(args.PIC_LINE);
                string sGTIN_UNIT = Convert.ToString(args.GTIN_UNIT);
                string sSKU_UNIT = Convert.ToString(args.SKU_UNIT);
                string sIN_SNO = Convert.ToString(args.IN_SNO);
                string sIN_NO = Convert.ToString(args.IN_NO);
                string sIN_LINE = Convert.ToString(args.IN_LINE);
                string sCOUNT_UNIT = Convert.ToString(args.COUNT_UNIT);
                decimal dGTIN_QTY = Convert.ToDecimal(args.GTIN_QTY);
                decimal dSKU_QTY = Convert.ToDecimal(args.SKU_QTY);

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) == "COUNT_QTY")

                if (header == "COUNT_QTY")
                {
                    //decimal dCOUNT_QTY = Convert.ToDecimal(dgv.CurrentRow.Cells[0].Value); //op輸入COUNT_QTY
                    decimal dCOUNT_QTY = Convert.ToDecimal(txtCOUNT_QTY_tab2); //op輸入COUNT_QTY
                    if (sCOUNT_UNIT == sSKU_UNIT)
                    {
                        if (dCOUNT_QTY > dSKU_QTY) throw new Exception("can't over stock quantity:" + dSKU_QTY.ToString());
                    }
                    if (sCOUNT_UNIT == sGTIN_UNIT)
                    {
                        if (dCOUNT_QTY > dGTIN_QTY) throw new Exception("can't over stock quantity:" + dGTIN_QTY.ToString());
                    }

                    if (sIN_SNO != "**********") //為序列號不可分割,可為0
                    {
                        if (sCOUNT_UNIT == sSKU_UNIT)
                        {
                            if (dCOUNT_QTY < dSKU_QTY && dCOUNT_QTY > 0) throw new Exception("Serial number can't split");
                        }
                        if (sCOUNT_UNIT == sGTIN_UNIT)
                        {
                            if (dCOUNT_QTY < dGTIN_QTY && dCOUNT_QTY > 0) throw new Exception("Serial number can't split");
                        }
                    }

                    //備份PIC_SNO
                    sSQL = string.Format(@"
                        insert into PIC_SNO_HIS 
                        select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{0}' as LOG_USER from PIC_SNO 
                        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}' and IN_SNO='{4}' and IN_NO='{5}' and IN_LINE='{6}'
                    ", DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE, sIN_SNO, sIN_NO, sIN_LINE);

                    //更新PIC_SNO
                    sSQL1 = string.Format(@"
                        update PIC_SNO set PIC_STS='3',COUNT_QTY={0},TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20),COUNT_USER='{1}',COUNT_DATE=convert(varchar(19),getdate(),20),END_DATE=convert(varchar(19),getdate(),20) 
                        where WHSE_NO='{2}' and PIC_NO='{3}' and PIC_LINE='{4}' and IN_SNO='{5}' and IN_NO='{6}' and IN_LINE='{7}'
                    ", dCOUNT_QTY, DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE, sIN_SNO, sIN_NO, sIN_LINE);

                    //更新PIC_DTL
                    sSQL2 = string.Format(@"
                        update PIC_DTL set PIC_STS='3',COUNT_QTY=(select sum(COUNT_QTY) from PIC_SNO where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'),
                            TRN_USER='{0}',TRN_DATE=convert(varchar(19),getdate(),20),COUNT_USER='{0}',END_DATE=convert(varchar(19),getdate(),20) 
                        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'
                    ", DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE);


                    //if (Globals.UpdateTable(new string[] { sSQL, sSQL1, sSQL2 }, new bool[] { true, true, true }))
                    //{
                    //    m_dgvExSno.CurrentRow.Cells["COUNT_QTY"].Value = Decimal.Round(dCOUNT_QTY, 3);

                    //    DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, m_dgvExSno.CurrentRow.Index);
                    //    CellClick_Sno(m_dgvExSno, ee);
                    //}
                    //else throw new Exception("no data update:" + sSQL);
                    using var dbTransaction = AppDb.Database.BeginTransaction();
                    try
                    {
                        var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                        var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        throw new Exception("no data update:" + sSQL);
                    }

                }

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) == "REMARK")
                if (header == "REMARK")
                {
                    //string sREMARK = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
                    string sREMARK = txtREMARK_tab2;
                    sSQL = string.Format(@"
                        update PIC_SNO set PIC_STS='3',REMARK=N'{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20) 
                        where WHSE_NO='{2}' and PIC_NO='{3}' and PIC_LINE='{4}' and IN_SNO='{5}' and IN_NO='{6}' and IN_LINE='{7}'
                    ", sREMARK, DhUsername, sWHSE_NO, sPIC_NO, sPIC_LINE, sIN_SNO, sIN_NO, sIN_LINE);
                    //if (Globals.UpdateTable(sSQL) > 0)
                    //{
                    //    m_dgvExSno.CurrentRow.Cells["REMARK"].Value = sREMARK;
                    //    dgv.CurrentRow.Cells[0].Tag = sREMARK;
                    //}
                    //else throw new Exception("no data update:" + sSQL);

                    using var dbTransaction = AppDb.Database.BeginTransaction();
                    try
                    {
                        var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        if (cnt > 0)
                        {
                            dbTransaction.Commit();
                        }
                        else throw new Exception("no data update:" + sSQL);

                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //dgv.CurrentRow.Cells[0].Value = Convert.ToString(dgv.CurrentRow.Cells[0].Tag);
                throw;
            }
        }
        protected async Task ButtonSubmitTab1CountQtyClick()
        {
            try
            {
                await CellBeginEdit_Dtl();
                await CellEndEdit_Dtl("COUNT_QTY");
                await SimpleDialog("update success");
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected async Task ButtonSubmitTab1RemarkClick()
        {
            try
            {
                await CellBeginEdit_Dtl();
                await CellEndEdit_Dtl("REMARK");
                await SimpleDialog("update success");
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }


        protected async Task ButtonSubmitTab2CountQtyClick()
        {
            try
            {
                await CellBeginEdit_Sno();
                await CellEndEdit_Sno("COUNT_QTY");
                await SimpleDialog("update success");
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
        protected async Task ButtonSubmitTab2RemarkClick()
        {
            try
            {
                await CellBeginEdit_Sno();
                await CellEndEdit_Sno("REMARK");
                await SimpleDialog("update success");
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }



        protected async Task ButtonConfirmClick(MouseEventArgs args)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no confirm authorization");
                AuthMsg = "confirm authorization granted";

                //if (m_dgvExMst.Rows.Count < 1) throw new Exception("no data to execute.");
                //if (m_dgvExDtl.Rows.Count < 1) throw new Exception("no data to execute.");
                if (getPicMstsResult.Count() < 1) throw new Exception("no data to execute.");
                if (getPicDtlsResult.Count() < 1) throw new Exception("no data to execute.");

                //整單確認 

                var x = (PicMst)ObjTab0Selected;
                string sWHSE_NO = Convert.ToString(x.WHSE_NO);
                string sPIC_NO = Convert.ToString(x.PIC_NO);
                string sPIC_TYPE = Convert.ToString(x.PIC_TYPE);

                await DhGlobals.MLASRS_CountConfirm_Async(ConnectionString, DhUsername, sWHSE_NO, sPIC_NO, sPIC_TYPE, sAPPROVE);

                await SimpleDialog("Confirm success ");

                //  string sRet = Globals.UserLog("08", "C030", "Physical Inventory Count Enter", sPIC_NO);
                await DoUserLogAsync("08", "C040", "Physical Inventory Count Approve", sPIC_NO);

                await QueryMstAsync();

            }
            catch (Exception ex)
            {

                await SimpleDialog(ex.Message);
            }

        }
        protected async Task Grid0RowDoubleClick(PicMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPicMst>("PIC_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid1RowDoubleClick(PicDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPicDtl>("PIC_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "PIC_LINE", args.PIC_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task ReloadTab1()
        {
            txtCOUNT_QTY_tab1 = null;
            txtREMARK_tab1 = null;

            if (ObjTab0Selected == null)
            {
                ObjTab1Selected = null;
                getPicDtlsResult = null;
                return;
            }
            sPIC_NO = ((PicMst)ObjTab0Selected).PIC_NO;

            var sSQL = string.Format(@"
              select distinct a.* 
                from {0} a 
                join LOC_DTL b on (a.SU_ID=b.SU_ID and a.SKU_NO=b.SKU_NO and a.BATCH_NO=b.BATCH_NO and a.COUNT_UNIT=b.GTIN_UNIT) 
                where a.PIC_NO='{1}' and a.PIC_STS  in ('0','1','2','3','9') and a.APPROVE_IND='N'
                ", dtDTL, sPIC_NO);
            if (txtSKU_NO != null && txtSKU_NO != "") sSQL = sSQL + string.Format(@" and a.SKU_NO like '%{0}%'", txtSKU_NO);
            if (txtSU_ID != null && txtSU_ID != "") sSQL = sSQL + string.Format(@" and a.SU_ID like '%{0}%'", txtSU_ID);

            sSQL = sSQL + " order by a.PIC_LINE";

            getPicDtlsResult = await AppDb.PicDtls.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();

            if (getPicDtlsResult.Any())
            {
                ObjTab1Selected = getPicDtlsResult.FirstOrDefault();
                var args2 = (PicDtl)ObjTab1Selected;
                txtCOUNT_QTY_tab1 = args2.COUNT_QTY.ToString();
                txtREMARK_tab1 = args2.REMARK;

                await ReloadTab2();

            }

        }

        protected async Task ReloadTab2()
        {
            txtCOUNT_QTY_tab2 = null;
            txtREMARK_tab2 = null;

            //Dtl
            //if (dtDTL.Rows.Count > 0) dtDTL.Rows.Clear();
            //sPIC_NO = SelectedPicMst.PIC_NO;
            if (ObjTab1Selected == null)
            {
                ObjTab2Selected = null;
                getPicSnosResult = null;

                return;
            }
            var args = (PicDtl)ObjTab1Selected;

            sPIC_NO = args.PIC_NO;
            sPIC_LINE = args.PIC_LINE;

            //  sPIC_LINE = args.PIC_LINE;

            var sSQL = string.Format(@"select * from {0} where PIC_NO='{1}' and PIC_LINE='{2}' order by PIC_NO,PIC_LINE,IN_SNO"
            , dtSNO, sPIC_NO, sPIC_LINE);

            getPicSnosResult = await AppDb.PicSnos.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();
            if (getPicSnosResult.Any())
            {
                ObjTab2Selected = getPicSnosResult.First();
                var args2 = (PicSno)ObjTab2Selected;
                txtCOUNT_QTY_tab2 = args2.COUNT_QTY.ToString();
                txtREMARK_tab2 = args2.REMARK;
            }
        }
        protected async Task Grid0RowSelect(PicMst args)
        {
           
            ObjTab0Selected = args;
            ObjTab1Selected = null;
            ObjTab2Selected = null;

            //  await ReloadTab1();
            //  await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid1RowSelect(PicDtl args)
        {
            ObjTab1Selected = args;
            ObjTab2Selected = null;

            //var args2 = args;
            //txtCOUNT_QTY_tab1 = args2.COUNT_QTY.ToString();
            //txtREMARK_tab1 = args2.REMARK;

            //await ReloadTab2();
            //await InvokeAsync(() => { StateHasChanged(); });

        }
        protected async Task Grid2RowSelect(PicSno args)
        {
            ObjTab2Selected = args;

            //var args2 = args;
            //txtCOUNT_QTY_tab2 = args2.COUNT_QTY.ToString();
            //txtREMARK_tab2 = args2.REMARK;

        }

        protected async Task Grid2RowDoubleClick(PicSno args)
        {

            var dialogResult = await DialogService.OpenAsync<ViewPicSno>("PIC_SNO", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "PIC_LINE", args.PIC_LINE }, { "IN_SNO", args.IN_SNO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

       

    }
}
