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
    public partial class C030CoreComponent
    {
        // SOP, grid Data
        protected RadzenGrid<PicMst> grid0;
        protected RadzenGrid<PicDtl> grid2;
        protected IEnumerable<PicMst> getPicMstsResult { get; set; }
        public IEnumerable<PicDtl> getPicDtlsResult { get; set; }
        public IEnumerable<PicSno> getPicSnosResult { get; set; }


        /// <summary>
        /// 其它大部分的 tab0-tab1-tab2
        /// 都可以直接連動, 但是C030很可能多了要編輯的欄位而造成影響
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
            }
            if (index == 2)
            {
                await ReloadTab2();
            }

        }


        /// <summary>
        /// 在 QueryMstAsync 要更新 grid0 前使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>

        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");
                await Task.Delay(500);

                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getPicMstsResult = await AppDb.PicMsts.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

                if (getPicMstsResult.Any()) ObjTab0Selected = getPicMstsResult.First(); // 


                // if (getPicMstsResult.Count() < 1) //這裡是配合 MLASRS 的寫法
                //{
                //    // C030 Query 沒有任何結果並不提示
                //    // await SimpleDialog(@$"no data found");

                //    getPicDtlsResult = null; // 不管 Query 的結果如何, 任何 tab1 tab2 總是都要先清空
                //    getPicSnosResult = null; // 不管 Query 的結果如何, 任何 tab1 tab2 總是都要先清空

                //    return;
                //}
                //await ReloadTab1();

                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
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



        //tempInCelcius< 20.0 ? "Cold." : "Perfect!"
        public bool IsBtnConfirmVisible { get { return sAPPROVE == "Y" ? true : false; } }

        protected override async Task OnInitializedAsync()
        {
            /*  MLASRS 
                不顯示 tab2 的幾個欄位
                //dtSNO
                Globals.Ini_DataGridView(ref dtSNO, ref m_dgvExSno, ref dgvSnoData);
                foreach (DataGridViewColumn column in m_dgvExSno.Columns)
                {
                    if (column.Name == "GTIN_QTY" || column.Name == "SKU_QTY" || column.Name == "GTIN_UNIT" || column.Name == "SKU_GTIN") column.Visible = false;
                    column.HeaderText = Globals.funTranslate(column.Name);
                }

                如果沒有權限, 不顯示 btn Confirm, 同時設為 不是  Enabled
               if (progWrt.APPROVE_WRT != "Y") { m_menuItemConfirm.Enabled = false; m_menuItemConfirm.Visible = false; }
                else sAPPROVE = "Y";

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y")
                { dgvDtlData.ReadOnly = true; m_dgvExDtl.ReadOnly = true; dgvSnoData.ReadOnly = true; m_dgvExSno.ReadOnly = true; }
                else
                {
                    ...
                }
            
             */
            try
            {
                PROG_ID = "C030";
                await base.OnInitializedAsync();

            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }

        }
        public async Task ReloadMainTab()
        {
            getPicDtlsResult = null;
            getPicSnosResult = null;


            getPicMstsResult = await AppDb.PicMsts.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

            // Need to release sub tab 
            await grid0.GoToPage(0);

            ResetGridBindAndSwitchToTab0();

            //StateHasChanged();
        }

        public string GetSQL()
        {


            if (txtSU_ID != null) txtSU_ID = txtSU_ID.Trim();
            if (txtPIC_USER != null) txtPIC_USER = txtPIC_USER.Trim();
            if (txtPIC_NO != null) txtPIC_NO = txtPIC_NO.Trim();
            if (txtSU_ID != null) txtSU_ID = txtSU_ID.Trim();
            if (txtIN_SNO != null) txtIN_SNO = txtIN_SNO.Trim();

            string sSQL = string.Format(@"select distinct a.* from {0} a join {1} b on (a.PIC_NO=b.PIC_NO) where a.PIC_STS  in ('0','1','2','3') and a.PIC_TYPE !='01'", dtMST, dtDTL);
            if (txtPIC_NO != null && txtPIC_NO != "") sSQL = sSQL + string.Format(@" and a.PIC_NO like '%{0}%'", txtPIC_NO);
            if (txtSKU_NO != null && txtSKU_NO != "") sSQL = sSQL + string.Format(@" and b.SKU_NO like '%{0}%'", txtSKU_NO);
            if (txtSU_ID != null && txtSU_ID != "") sSQL = sSQL + string.Format(@" and b.SU_ID like '%{0}%'", txtSU_ID);
            if (txtPIC_USER != null && txtPIC_USER != "") sSQL = sSQL + string.Format(@" and a.COUNT_USER like '%{0}%'", txtPIC_USER);
            sSQL += " order by a.PIC_NO";

            return sSQL;
        }




        private async Task CellBeginEdit_Dtl()
        {

            //private void CellBeginEdit_Dtl(object sender, DataGridViewCellCancelEventArgs e)
            try
            {

                if (ObjTab1Selected == null)
                {
                    throw new Exception("no selected row to edit");
                }
                var args = (PicDtl)ObjTab1Selected;

                //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"ButtonSubmitTab1CountQtyClick", Detail = "args.SERIAL_IND.Trim() is " + args.SERIAL_IND.Trim() });




                //if (m_dgvExDtl.RowCount < 1) e.Cancel = true;

                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[this.Name.ToString()];
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization");

                //int iRow = e.RowIndex;
                //int iCol = e.ColumnIndex;

                //if (Convert.ToString(m_dgvExDtl.CurrentRow.Cells["SERIAL_IND"].Value).Trim() != "") //有序列號 
                //{
                //    dgv.Rows[iRow].Cells[0].ReadOnly = true;
                //    throw new Exception("choice Serial Items to enter count quantity");
                //}
                if (args.SERIAL_IND.Trim() != "") //有序列號 
                {
                    //  dgv.Rows[iRow].Cells[0].ReadOnly = true;
                    throw new Exception("choice Serial Items to enter count quantity");
                }


                else
                {

                    //if (m_dgvExSno.RowCount == 0) //無序列號且沒有明細，須新增
                    if (ObjTab2Selected == null) //無序列號且沒有明細，須新增
                    {
                        //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"ButtonSubmitTab1CountQtyClick", Detail = "無序列號且沒有明細，須新增" });

                        //string sWHSE_NO = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["WHSE_NO"].Value);
                        //string sPIC_NO = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["PIC_NO"].Value);
                        //string sPIC_LINE = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["PIC_LINE"].Value);
                        //string sSTGE_TYPE = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["STGE_TYPE"].Value);
                        //string sSTGE_BIN = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["STGE_BIN"].Value);
                        //string sSU_ID = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["SU_ID"].Value);
                        //string sPLANT = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["PLANT"].Value);
                        //string sSTGE_LOC = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["STGE_LOC"].Value);
                        //string sSKU_NO = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["SKU_NO"].Value);
                        //string sBATCH_NO = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["BATCH_NO"].Value);
                        //string sCOUNT_UNIT = Convert.ToString(m_dgvExDtl.CurrentRow.Cells["COUNT_UNIT"].Value);

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


                        //string sSQL = string.Format(@"
                        //    insert into PIC_SNO 
                        //    select '{0}' as WHSE_NO,'{1}' as PIC_NO,'{2}' as PIC_LINE,'{3}' as STGE_TYPE,'{4}' as STGE_BIN,'{5}' as SU_ID,'{6}' as PLANT,'{7}' as STGE_LOC,'{8}' as SKU_NO,'{9}' as BATCH_NO,IN_SNO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,'{10}' as COUNT_UNIT,0 as COUNT_QTY,'{11}' as COUNT_USER,convert(varchar(19),getdate(),20) as COUNT_DATE,'' as APPROVE_USER,'' as APPROVE_DATE,convert(varchar(19),getdate(),20) as START_DATE,convert(varchar(19),getdate(),20) as END_DATE,'0' as PIC_STS,'' as REMARK,'1' as SOURCE,'N' as APPROVE_IND,convert(varchar(19),getdate(),20) as TRN_DATE,'{11}' as TRN_USER,convert(varchar(19),getdate(),20) as CRT_DATE,'{11}' as CRT_USER,IN_NO,IN_LINE
                        //    from PLT_DTL
                        //    where WHSE_NO='{0}' and SU_ID='{5}' and PLANT='{6}' and STGE_LOC='{7}' and SKU_NO='{8}' and BATCH_NO='{9}' and GTIN_UNIT='{10}'
                        //    ", sWHSE_NO, sPIC_NO, sPIC_LINE, sSTGE_TYPE, sSTGE_BIN, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO.Trim(), sCOUNT_UNIT, Globals.USER_NAME);

                        string sSQL1 = string.Format(@"
                            insert into PIC_SNO 
                            select '{0}' as WHSE_NO,'{1}' as PIC_NO,'{2}' as PIC_LINE,'{3}' as STGE_TYPE,'{4}' as STGE_BIN,'{5}' as SU_ID,'{6}' as PLANT,'{7}' as STGE_LOC,'{8}' as SKU_NO,'{9}' as BATCH_NO,IN_SNO,GTIN_UNIT,GTIN_QTY,SKU_UNIT,SKU_QTY,'{10}' as COUNT_UNIT,0 as COUNT_QTY,'{11}' as COUNT_USER,convert(varchar(19),getdate(),20) as COUNT_DATE,'' as APPROVE_USER,'' as APPROVE_DATE,convert(varchar(19),getdate(),20) as START_DATE,convert(varchar(19),getdate(),20) as END_DATE,'0' as PIC_STS,'' as REMARK,'1' as SOURCE,'N' as APPROVE_IND,convert(varchar(19),getdate(),20) as TRN_DATE,'{11}' as TRN_USER,convert(varchar(19),getdate(),20) as CRT_DATE,'{11}' as CRT_USER,IN_NO,IN_LINE
                            from PLT_DTL
                            where WHSE_NO='{0}' and SU_ID='{5}' and PLANT='{6}' and STGE_LOC='{7}' and SKU_NO='{8}' and BATCH_NO='{9}' and GTIN_UNIT='{10}'
                            ", sWHSE_NO, sPIC_NO, sPIC_LINE, sSTGE_TYPE, sSTGE_BIN, sSU_ID, sPLANT, sSTGE_LOC, sSKU_NO, sBATCH_NO.Trim(), sCOUNT_UNIT, DhUsername);

                        //if (Globals.UpdateTable(sSQL) > 0)
                        //{
                        //    DataGridViewCellEventArgs ee = new DataGridViewCellEventArgs(0, m_dgvExDtl.CurrentRow.Index);
                        //    CellClick_Dtl(m_dgvExDtl, ee);

                        //    if (m_dgvExSno.RowCount > 1)
                        //    {
                        //        throw new Exception("choice Serial Items to enter count quantity");
                        //    }
                        //}
                        ////else throw new Exception("no data update:" + sSQL);


                        using var transaction = AppDb.Database.BeginTransaction();
                        try
                        {
                            var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                            transaction.Commit();

                            if (cnt1 > 0)
                            {
                                // **************************************** TODO
                                //     await ReloadTab1Async();
                                if (getPicSnosResult.Count() > 1)
                                {
                                    await SimpleDialog("choice Serial Items to enter count quantity");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"ButtonSubmitTab1CountQtyClick", Detail = "無序列號, 但有明細  CellBeginEdit_Dtl 正常完成" });

                    }
                }

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "COUNT_QTY" && Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "REMARK") e.Cancel = true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //dgv.CurrentRow.Cells[0].Value = Convert.ToString(dgv.CurrentRow.Cells[0].Tag);
                //e.Cancel = true;
                throw;
            }


            //private void CellEndEdit_Dtl(object sender, DataGridViewCellEventArgs e)
        }
        private async Task CellEndEdit_Dtl(string header)
        {
            //private void CellEndEdit_Dtl(object sender, DataGridViewCellEventArgs e)

            //更改PIC_DTL的COUNT_QTY & REMARK
            //DataGridView dgv = (DataGridView)sender;
            string sSQL = string.Empty;
            string sSQL1 = string.Empty;
            string sSQL2 = string.Empty;
            //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"ButtonSubmitTab1CountQtyClick", Detail = "CellEndEdit_DtlAsync" });

            try
            {
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[this.Name.ToString()];
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization");

                //int iRow = e.RowIndex;
                //int iCol = e.ColumnIndex;

                //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "COUNT_QTY" && Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) != "REMARK") return;
                //if (m_dgvExSno.RowCount > 1) throw new Exception("choice Serial Items to enter count quantity");
                if (getPicSnosResult.Count() > 1) throw new Exception("choice Serial Items to enter count quantity");


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

                    using var transaction = AppDb.Database.BeginTransaction();
                    try
                    {
                        var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                        var cnt2 = await AppDb.Database.ExecuteSqlRawAsync(sSQL2);
                        var cnt3 = await AppDb.Database.ExecuteSqlRawAsync(sSQL3);
                        transaction.Commit();


                    }
                    catch (Exception ex)
                    {
                        throw new Exception("no data update:" + sSQL);
                    }



                    //if (Convert.ToString(dgv.Rows[iRow].HeaderCell.Value) == "REMARK")
                    //{
                    //    string sREMARK = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
                    //    //備份PIC_DTL
                    //    sSQL = string.Format(@"
                    //        insert into PIC_DTL_HIS 
                    //        select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{0}' as LOG_USER from PIC_DTL 
                    //        where WHSE_NO='{1}' and PIC_NO='{2}' and PIC_LINE='{3}'
                    //    ", Globals.USER_NAME, sWHSE_NO, sPIC_NO, sPIC_LINE);

                    //    sSQL1 = string.Format(@"
                    //        update PIC_DTL set PIC_STS='3',REMARK=N'{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20)
                    //        where WHSE_NO='{2}' and PIC_NO='{3}' and PIC_LINE='{4}'
                    //    ", sREMARK, Globals.USER_NAME, sWHSE_NO, sPIC_NO, sPIC_LINE);
                    //    if (Globals.UpdateTable(new string[] { sSQL, sSQL1 }, new bool[] { true, true }))
                    //    {
                    //        m_dgvExDtl.CurrentRow.Cells["REMARK"].Value = sREMARK;
                    //        dgv.CurrentRow.Cells[0].Tag = sREMARK;
                    //    }
                    //    else throw new Exception("no data update:" + sSQL);
                    //}

                }

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

                    using var transaction = AppDb.Database.BeginTransaction();
                    try
                    {
                        var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                        var cnt1 = await AppDb.Database.ExecuteSqlRawAsync(sSQL1);
                        transaction.Commit();


                    }
                    catch (Exception ex)
                    {
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
                    // Globals.USER_NAME => DhUsername

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




        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }


        protected async Task ButtonConfirmClick(MouseEventArgs args)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no confirm authorization");
                AuthMsg = "confirm authorization granted";


                // DIFF ENVIR, by Mark, 05/09, 不同平台的不同調用, 延用原 throw new Exception 的風格

                //if (m_dgvExMst.Rows.Count < 1) throw new Exception("no data to execute.");
                //if (m_dgvExDtl.Rows.Count < 1) throw new Exception("no data to execute.");

                // Query 有篩選, 沒有任何合乎條件時,
                if (getPicMstsResult.Count() < 1) throw new Exception("no data to execute. (PIC header)");
                if (getPicDtlsResult.Count() < 1) throw new Exception("no data to execute. (PIC items)");


                //整單確認
                //string sWHSE_NO = Convert.ToString(m_dgvExMst.CurrentRow.Cells["WHSE_NO"].Value);
                //string sPIC_NO = Convert.ToString(m_dgvExMst.CurrentRow.Cells["PIC_NO"].Value);
                //string sPIC_TYPE = Convert.ToString(m_dgvExMst.CurrentRow.Cells["PIC_TYPE"].Value);
                var x = (PicMst)ObjTab0Selected;
                string sWHSE_NO = Convert.ToString(x.WHSE_NO);
                string sPIC_NO = Convert.ToString(x.PIC_NO);
                string sPIC_TYPE = Convert.ToString(x.PIC_TYPE);

                // Globals.CountConfirm(sWHSE_NO, sPIC_NO, sPIC_TYPE, "N");
                await DhGlobals.MLASRS_CountConfirm_Async(ConnectionString, DhUsername, sWHSE_NO, sPIC_NO, sPIC_TYPE, "N");

                //NotificationService.Notify(NotificationSeverity.Success, "Confirm success ");
                await SimpleDialog("Confirm success");

                //  string sRet = Globals.UserLog("08", "C030", "Physical Inventory Count Enter", sPIC_NO);
                await DoUserLogAsync("08", "C030", "Physical Inventory Count Enter", sPIC_NO);


                await QueryMstAsync();


            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }

        }


        protected async Task Grid0RowDoubleClick(PicMst args)
        {
            ObjTab0Selected = args;
            //    await InvokeAsync(() => { StateHasChanged(); });
            //    await Task.Delay(500); // NOTE by Mark, 06/25, 可以避免 https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
            //    await SimpleDialog(" debug ...Grid0RowDoubleClick ");
            var dialogResult = await DialogService.OpenAsync<ViewPicMst>("PIC_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid0RowSelect(PicMst args)
        {
            //  await SimpleDialog("...debug Grid0RowSelect  "); // 一旦加了這個, Grid0RowDoubleClick就不被觸發?
            //ObjTab0Selected = args;
            //await Task.Delay(500);
            //await ReloadTab1();
            //await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task ReloadTab1()
        {
            if (ObjTab0Selected == null)
            {
                ObjTab1Selected = null;
                getPicDtlsResult = null;
                return;
            }

            var args = (PicMst)ObjTab0Selected;
            //Dtl
            //if (dtDTL.Rows.Count > 0) dtDTL.Rows.Clear();
            sPIC_NO = args.PIC_NO;



            // 這是 MLASRS CellClick 的寫法
            //var sSQL = string.Format(@"
            //    select distinct a.* from {0} a 
            //    join LOC_DTL b on (a.SU_ID=b.SU_ID and a.SKU_NO=b.SKU_NO and a.BATCH_NO=b.BATCH_NO and a.COUNT_UNIT=b.GTIN_UNIT) 
            //    where a.PIC_NO='{1}' 
            //", dtDTL, sPIC_NO);

            // 除了本體少了 and a.PIC_STS  not in ('9','P') 
            // 也少了 對 SKU_NO SU_ID 的篩選

            // 因此會造成 Query 後和 row selected 兩者在 tab1 的不一致
            // TEST CASE 
            // SKU_NO=02 PIC_USER=?  --- 這是另外一個 DATA 本身的問題, 第二版的 DHDB 裡, COUNT_USER 存在很多 ??? ????? 
            // 第5筆
            // 會有 
            // 1 SU_ID= 102251 SKU_NO 10005485 --- 因為少了  對 SKU_NO SU_ID 的篩選, 不該出現而出現
            // 2 SU_ID= 101437 SKU_NO 10005802

            // 承上, 在原本的TEST CASE 基礎上, 多加一個條件
            // PIC_NO = 2010280002, 即可在 Query 後只取到一筆, 預設連動, 其 tab1 即應為單筆.


            // 這是 MLASRS QueryMst  的寫法
            var sSQL = string.Format(@"
                select distinct a.* 
                from {0} a 
                join LOC_DTL b on (a.SU_ID=b.SU_ID and a.SKU_NO=b.SKU_NO and a.BATCH_NO=b.BATCH_NO and a.COUNT_UNIT=b.GTIN_UNIT)
                where a.PIC_NO='{1}' and a.PIC_STS  not in ('9','P') 
                ", dtDTL, args.PIC_NO);
            if (txtSKU_NO != null && txtSKU_NO != "") sSQL = sSQL + string.Format(@" and a.SKU_NO like '%{0}%'", txtSKU_NO);
            if (txtSU_ID != null && txtSU_ID != "") sSQL = sSQL + string.Format(@" and a.SU_ID like '%{0}%'", txtSU_ID);

            getPicDtlsResult = await AppDb.PicDtls.FromSqlRaw(sSQL).OrderBy(a => a.PIC_LINE).AsNoTracking().ToListAsync();

            if (getPicDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPicDtlsResult.First();

                var args2 = (PicDtl)ObjTab1Selected;
                txtCOUNT_QTY_tab1 = args2.COUNT_QTY.ToString();
                txtREMARK_tab1 = args2.REMARK;

                await ReloadTab2();
            }
            await InvokeAsync(() => { StateHasChanged(); });

        }

        protected async Task Grid1RowDoubleClick(PicDtl args)
        {
            await Task.Delay(500); // NOTE by Mark, 06/25, 可以避免 https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
            var dialogResult = await DialogService.OpenAsync<ViewPicDtl>("PIC_DTL", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "PIC_LINE", args.PIC_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid1RowSelect(PicDtl args)
        {
            ObjTab1Selected = args;

            var args2 = args;
            txtCOUNT_QTY_tab1 = args2.COUNT_QTY.ToString();
            txtREMARK_tab1 = args2.REMARK;

            await ReloadTab2();
            await InvokeAsync(() => { StateHasChanged(); });

        }

        protected async Task ReloadTab2()
        {
            if (ObjTab1Selected == null)
            {
                getPicSnosResult = null;
                return;
            }
            var args = (PicDtl)ObjTab1Selected;


            sPIC_LINE = args.PIC_LINE;
            var sSQL = string.Format(@"select * from {0} where PIC_NO='{1}' and PIC_LINE='{2}' order by PIC_NO,PIC_LINE,IN_SNO"
                                    , dtSNO, sPIC_NO, sPIC_LINE);

            getPicSnosResult = await AppDb.PicSnos.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();
            if (getPicSnosResult.Count() > 0)
            {
                ObjTab2Selected = getPicSnosResult.First();

                var args2 = (PicSno)ObjTab2Selected;
                txtCOUNT_QTY_tab2 = args2.COUNT_QTY.ToString();
                txtREMARK_tab2 = args2.REMARK;

            }
            await InvokeAsync(() => { StateHasChanged(); });

        }

        protected async Task Grid2RowSelect(PicSno args)
        {
            ObjTab2Selected = args;

            var args2 = args;
            txtCOUNT_QTY_tab1 = args2.COUNT_QTY.ToString();
            txtREMARK_tab1 = args2.REMARK;

        }
        protected async Task Grid2RowDoubleClick(PicSno args)
        {

            var dialogResult = await DialogService.OpenAsync<ViewPicSno>("PIC_SNO", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "PIC_LINE", args.PIC_LINE }, { "IN_SNO", args.IN_SNO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE } });
            await InvokeAsync(() => { StateHasChanged(); });
        }
        //protected async Task Grid2RowSelect(PicSno args)
        //{

        //    //var brief = "C030 盤點序列號檔";
        //    //var msg = "Grid Serial Items RowSelect";
        //    SelectedPicSno = args;
        //    if (await DhGlobals.IsAuthApproveUpdateAsync(DhUser, PROG_ID))
        //    {
        //        var dialogResult = await DialogService.OpenAsync<EditPicSno>("Edit Pic Sno", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "PIC_NO", args.PIC_NO }, { "IN_SNO", args.IN_SNO } });

        //    }
        //    else
        //    {
        //        NotificationService.Notify(NotificationSeverity.Info, "no authoritiy to edit");
        //        // not auth to edit
        //    }


        //    await InvokeAsync(() => { StateHasChanged(); });
        //}

    }
}
