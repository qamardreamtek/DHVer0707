using Microsoft.EntityFrameworkCore;
using Radzen;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class P070CoreComponent
    {
        public bool isButtonToAddDisabled = false;
        public bool isButtonToRemoveDisabled = false;

        public string txtGTIN_QTY_NEW;
        public string txtGTIN_QTY1_NEW;
        public string txtGTIN_QTY2_NEW;
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P070";
            await base.OnInitializedAsync();

            bool bEnabled = true;
            if (progWrt.APPROVE_WRT != "Y") bEnabled = false;

            //btnADD.Enabled = bEnabled;
            //btnREMOVE.Enabled = bEnabled;

        }


        /// <summary>
        /// 查询托盤数据
        /// </summary>
        /// <returns></returns>
        private async Task QueryMst(string sName)
        {

            // 使用 Deletegate, 指定要使用的 Function 和 參數
            //   string sRet = Globals.UserLog("01", "P070", this.Text, "SU_ID=" + sName);
            await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "SU_ID=" + sName);
            try
            {
                //TextBox tbPLT = tbPLT1;

                DataTable dtPLT1 = new DataTable("PLT_DTL");
                DataTable dtPLT2 = new DataTable("PLT_DTL");

                var tbPLT = tbPLT1; // or tbPLT2
                DataTable dtTable = dtPLT1;
                //MyControls.DataGridViewEx m_dgv = m_dgvPLT1;
                if (sName == "tbPLT2")
                {
                    dtTable = dtPLT2;
                    //m_dgv = m_dgvPLT2; 
                    tbPLT = tbPLT2;
                }

                //sName = tbPLT1
                //sName = tbPLT2



                string sSQL = string.Format(@"
                    select a.*,b.STGE_TYPE,b.STGE_BIN,b.LOC_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.SKU_QTY as LOC_QTY
                    from {0} a join LOC_DTL b
                    on (a.SU_ID=b.SU_ID and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT )
                    where a.SU_ID ='{1}'
                ", dtTable, tbPLT.Trim());
                //Globals.QueryTable(ref dtTable, sSQL);
                //await SimpleDialog(sSQL);
                DhGlobals.QueryTable(ConnectionString, ref dtTable, sSQL);


                //只能是STGE_TYPE='999'才可以拆併托盤
                decimal dGrossWeight = 0;
                decimal dVolume = 0;
                if (dtTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtTable.Rows[i]["STGE_TYPE"]) != "999") throw new Exception("can't change storage unit number in storage type:" + Convert.ToString(dtTable.Rows[0]["STGE_TYPE"]));
                        dGrossWeight = dGrossWeight + Convert.ToDecimal(dtTable.Rows[i]["GROSS_WEIGHT"]) * Convert.ToDecimal(dtTable.Rows[i]["SKU_QTY"]) / Convert.ToDecimal(dtTable.Rows[i]["LOC_QTY"]);
                        dVolume = dVolume + Convert.ToDecimal(dtTable.Rows[i]["VOLUME"]) * Convert.ToDecimal(dtTable.Rows[i]["SKU_QTY"]) / Convert.ToDecimal(dtTable.Rows[i]["LOC_QTY"]);
                    }
                }

                //m_dgv.DataSource = dtTable;

                if (sName == "tbPLT1")
                {
                    // getVp070sResult1 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT1).AsNoTracking().ToListAsync();
                    getVp070sResult1 = await AppDb.Vp070s.FromSqlRaw(sSQL).AsNoTracking().ToListAsync();
                    if (getVp070sResult1.Count() > 0)
                    {
                        ObjTab1Selected = getVp070sResult1.FirstOrDefault();
                        var args1 = (Vp070)ObjTab1Selected;
                        txtGTIN_QTY1_NEW = args1.GTIN_QTY.ToString();
                    }
                    //dtPLT1.Clear();
                    //dtPLT1 = dtTable.Copy();
                    tbGW_S = Decimal.Round(dGrossWeight, 3).ToString();
                    tbV_S = Decimal.Round(dVolume, 3).ToString();
                }
                if (sName == "tbPLT2")
                {
                    getVp070sResult2 = await AppDb.Vp070s.Where(a => a.SU_ID == tbPLT2).AsNoTracking().ToListAsync();
                    if (getVp070sResult2.Count() > 0)
                    {
                        ObjTab2Selected = getVp070sResult2.FirstOrDefault();
                        var args2 = (Vp070)ObjTab2Selected;
                        txtGTIN_QTY2_NEW = args2.GTIN_QTY.ToString();
                    }
                    //dtPLT2.Clear();
                    //dtPLT2 = dtTable.Copy();
                    tbGW_T = Decimal.Round(dGrossWeight, 3).ToString();
                    tbV_T = Decimal.Round(dVolume, 3).ToString();
                }

                ////綁定後須重新設定
                //m_dgv.ReadOnly = false; //須先設可以編輯，再設不可編輯的欄位
                //m_dgv.MultiSelect = false;
                //m_dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

                //for (int i = 0; i < m_dgv.Columns.Count; i++)
                //{
                //    if (Convert.ToString(m_dgv.Columns[i].Name) != "GTIN_QTY")
                //    {
                //        m_dgv.Columns[i].ReadOnly = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                await SimpleDialog(ex.Message);
                //ErrMsg = ex.Message;
            }
        }



        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        //protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> grid0;




        //protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult;

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> getVp070sResult1 { get; set; } // as source
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> getVp070sResult2 { get; set; } // as target


        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList1 { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList2 { get; set; }

        public string tbPLT1; // same name as WES
        public string tbPLT2;
        //if (sName == "tbPLT1") { dtPLT1.Clear(); dtPLT1 = dtTable.Copy(); tbGW_S.Text = Decimal.Round(dGrossWeight, 3).ToString(); tbV_S.Text = Decimal.Round(dVolume, 3).ToString();

        //if (sName == "tbPLT2") { dtPLT2.Clear(); dtPLT2 = dtTable.Copy(); tbGW_T.Text = Decimal.Round(dGrossWeight, 3).ToString(); tbV_T.Text = Decimal.Round(dVolume, 3).ToString();
        public string tbGW_S;
        public string tbV_S;
        public string tbGW_T;
        public string tbV_T;

        //public decimal _tbGW_S;
        //public decimal _tbV_S;
        //public decimal _tbGW_T;
        //public decimal _tbV_T;


        public string GW_VOL = "GWt(KG)/Vol(M3)";




        /// <summary>
        /// 使用 MLASRS 命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async Task btnADD_Click()
        {
            DataTable dtSQL = new DataTable();

            tbPLT2 = tbPLT2 == null ? "" : tbPLT2.Trim();
            //     string sRet = Globals.UserLog("05", "P070", this.Text, tbPLT1.Text.Trim() + ">>" + tbPLT2.Text.Trim());
            await DoUserLogAsync("05", "P070", PROG_NAME_FOR_LOG, tbPLT1.Trim() + ">>" + tbPLT2.Trim());

            try
            {
                //must check user authourize
                // string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");

                string sSU_ID_TO = tbPLT2.Trim();

                if (string.IsNullOrEmpty(sSU_ID_TO)) throw new Exception("destination storage unit number must input");
                if (sSU_ID_TO.Length != 6) throw new Exception("destination storage unit number incorrect");

                //string sWHSE_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["WHSE_NO"].Value);
                //string sSKU_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SKU_NO"].Value);
                //string sLOC_NO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["LOC_NO"].Value);

                var args1 = getVp070sResult1.FirstOrDefault();
                string sWHSE_NO = Convert.ToString(args1.WHSE_NO);
                string sSKU_NO = Convert.ToString(args1.SKU_NO);
                string sLOC_NO = Convert.ToString(args1.LOC_NO);



                string sLOC_NO_TO = sLOC_NO;
                //if (dtPLT2.Rows.Count > 0) sLOC_NO_TO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["LOC_NO"].Value);
                if (getVp070sResult2.Count() > 0)
                {
                    var args2 = getVp070sResult2.FirstOrDefault();
                    sLOC_NO_TO = Convert.ToString(args2.LOC_NO);
                }



                //string sSU_TYPE = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SU_TYPE"].Value);
                string sSU_TYPE = Convert.ToString(args1.SU_TYPE);

                string sSU_TYPE_TO = sSU_TYPE;
                //if (dtPLT2.Rows.Count > 0) sSU_TYPE_TO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["SU_TYPE"].Value);
                if (getVp070sResult2.Count() > 0)
                {
                    var args2 = getVp070sResult2.FirstOrDefault();
                    sSU_TYPE_TO = Convert.ToString(args2.SU_TYPE);
                }


                //DataGridViewRow[] dgvRows = new DataGridViewRow[1];
                //dgvRows[0] = m_dgvPLT1.CurrentRow;

                decimal dGrossWeight = Convert.ToDecimal(tbGW_T);
                decimal dVolume = Convert.ToDecimal(tbV_T);

                List<Vp070> dgvRows = new List<Vp070> { (Vp070)ObjTab1Selected };

                // *** 加的時候, 一定是用 txtGTIN_QTY1_NEW
                // 如果設其值為 0, 雖然不大於原值, 但後續處理會報錯
                decimal sGTIN_QTY_NEW = txtGTIN_QTY1_NEW == null ? 0 : Convert.ToDecimal(txtGTIN_QTY1_NEW);
                //await SimpleDialog("sGTIN_QTY_NEW =" + sGTIN_QTY_NEW);

                //Globals.ChangePalletQty(dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);
                await DhGlobals.MLASRS_ChangePalletQty_Async(ConnectionString, DhUsername, sGTIN_QTY_NEW, dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);


                await QueryMst("tbPLT1");
                await QueryMst("tbPLT2");
                await InvokeAsync(() => { StateHasChanged(); });

                await SimpleDialog("add success");
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
            finally
            {
                if (dtSQL != null) { dtSQL.Dispose(); dtSQL = null; }
            }
        }
        public async Task btnREMOVE_Click()
        {
            DataTable dtSQL = new DataTable();

            //string sRet = Globals.UserLog("05", "P070", this.Text, tbPLT1.Text.Trim() + "<<" + tbPLT2.Text.Trim());
            await DoUserLogAsync("05", "P070", PROG_NAME_FOR_LOG, tbPLT1.Trim() + "<<" + tbPLT2.Trim());

            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");

                string sSU_ID_TO = tbPLT1.Trim();

                if (string.IsNullOrEmpty(sSU_ID_TO)) throw new Exception("destination storage unit number must input");
                if (sSU_ID_TO.Length != 6) throw new Exception("destination storage unit number incorrect");

                //string sWHSE_NO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["WHSE_NO"].Value);
                //string sSKU_NO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["SKU_NO"].Value);
                //string sLOC_NO = Convert.ToString(m_dgvPLT2.Rows[0].Cells["LOC_NO"].Value);

                var args2 = getVp070sResult2.FirstOrDefault();
                string sWHSE_NO = Convert.ToString(args2.WHSE_NO);
                string sSKU_NO = Convert.ToString(args2.SKU_NO);
                string sLOC_NO = Convert.ToString(args2.LOC_NO);



                string sLOC_NO_TO = sLOC_NO;
                //if (dtPLT1.Rows.Count > 0) sLOC_NO_TO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["LOC_NO"].Value);
                if (getVp070sResult1.Count() > 0)
                {
                    var args1 = getVp070sResult1.FirstOrDefault();
                    sLOC_NO_TO = Convert.ToString(args1.LOC_NO);
                }


                string sSU_TYPE = Convert.ToString(args2.SU_TYPE);
                string sSU_TYPE_TO = sSU_TYPE;
                //if (dtPLT1.Rows.Count > 0) sSU_TYPE_TO = Convert.ToString(m_dgvPLT1.Rows[0].Cells["SU_TYPE"].Value);
                if (getVp070sResult1.Count() > 0)
                {
                    var args1 = getVp070sResult1.FirstOrDefault();
                    sSU_TYPE_TO = Convert.ToString(args1.SU_TYPE);
                }


                //DataGridViewRow[] dgvRows = new DataGridViewRow[1];
                //dgvRows[0] = m_dgvPLT2.CurrentRow;

                List<Vp070> dgvRows = new List<Vp070> { (Vp070)ObjTab2Selected };

                decimal dGrossWeight = Convert.ToDecimal(tbGW_S);
                decimal dVolume = Convert.ToDecimal(tbV_S);


                // *** remove 的時候, 一定是用 txtGTIN_QTY2_NEW
                // 如果設其值為 0, 雖然不大於原值, 但後續處理會報錯
                decimal sGTIN_QTY_NEW = txtGTIN_QTY2_NEW == null ? 0 : Convert.ToDecimal(txtGTIN_QTY2_NEW);
                //await SimpleDialog("sGTIN_QTY_NEW =" + sGTIN_QTY_NEW);

                //Globals.ChangePalletQty(dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);
                await DhGlobals.MLASRS_ChangePalletQty_Async(ConnectionString, DhUsername, sGTIN_QTY_NEW, dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);


                //Globals.ChangePalletQty(dgvRows, sSU_ID_TO, sLOC_NO_TO, sSU_TYPE_TO, dGrossWeight, dVolume);

                await QueryMst("tbPLT1");
                await QueryMst("tbPLT2");
                await InvokeAsync(() => { StateHasChanged(); });

                await SimpleDialog("remove success");// 沒有更新? fixed, 要使用 string "tbPLT1" directly


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
            finally
            {
                if (dtSQL != null) { dtSQL.Dispose(); dtSQL = null; }
            }
        }




        protected async Task Grid1RowSelect(Vp070 args)
        {
            ObjTab1Selected = args;
            txtGTIN_QTY1_NEW = args.GTIN_QTY.ToString();
        }
        protected async Task Grid2RowSelect(Vp070 args)
        {
            ObjTab2Selected = args;
            txtGTIN_QTY2_NEW = args.GTIN_QTY.ToString();
        }

        //private void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) -------DataGridViewCellCancelEventArgs 看來type 用錯了
        //{
        //    MyControls.DataGridViewEx m_dgv = (MyControls.DataGridViewEx)sender;
        //    int iRow = e.RowIndex;
        //    int iCol = e.ColumnIndex;

        //    if (Convert.ToString(m_dgv.Rows[iRow].Cells["IN_SNO"].Value) != "**********")
        //    {
        //        MessageBox.Show("Serial data can't split quantity");
        //        e.Cancel = true;
        //    }
        //}
        protected async Task ButtonSubmit1Click()
        {
            var args1 = (Vp070)ObjTab1Selected;
            if (ObjTab1Selected == null)
            {
                //MessageBox.Show("Serial data can't split quantity");
                await SimpleDialog("no data to process");

                return;
            }


            //https://github.com/twoutlook/DH5Ver0414_PUBLISH/discussions/52
            //DataGridViewCellEventArgs
            //DataGridViewCellCancelEventArgs   --- 可能的錯誤
            //   ... 打斷點, 然後去修改GTIN_QTY, 真的只有雙擊時觸發耶
            //兩個長的太像了
            //if (Convert.ToString(args1.IN_SNO) != " **********")
            //{
            //    //MessageBox.Show("Serial data can't split quantity");
            //    await SimpleDialog("Serial data can't split quantity");

            //    return;
            //}


            decimal new1 = Convert.ToDecimal(txtGTIN_QTY1_NEW);
            if (new1 > Convert.ToDecimal(args1.GTIN_QTY))
            {
                await SimpleDialog("can't exceed " + Convert.ToDecimal(args1.GTIN_QTY));
                txtGTIN_QTY1_NEW = Convert.ToDecimal(args1.GTIN_QTY).ToString();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task ButtonSubmit2Click()
        {
            // https://github.com/twoutlook/DH5Ver0414_PUBLISH/discussions/52
            //
            // MLASRS 沒有針對 右側改值的觸發
            // 也就是 remove 永遠是一樣的值
            // 雙重保護, GTIN_QTY,不能編輯, 因為仍要用其值, 所以顯示, 也方便操作
            // 
            bool isToIgnore = true;
            if (isToIgnore) return;


            if (ObjTab2Selected == null)
            {
                //MessageBox.Show("Serial data can't split quantity");
                await SimpleDialog("no data to process");

                return;
            }
            var args2 = (Vp070)ObjTab2Selected;

            if (Convert.ToString(args2.IN_SNO) != " **********")
            {
                //MessageBox.Show("Serial data can't split quantity");
                await SimpleDialog("Serial data can't split quantity");

                return;
            }



            decimal new2 = Convert.ToDecimal(txtGTIN_QTY2_NEW);

            // LINE#296 P070.cs
            //if (m_dgv.Name == "m_dgvPLT2")
            //{
            //    if (Convert.ToDecimal(dtPLT2.Rows[iRow]["GTIN_QTY"]) < Convert.ToDecimal(m_dgv.Rows[iRow].Cells["GTIN_QTY"].Value))
            //    {
            //        MessageBox.Show("can't exceed " + Convert.ToDecimal(dtPLT1.Rows[iRow]["GTIN_QTY"]));
            //        m_dgv.Rows[iRow].Cells["GTIN_QTY"].Value = Convert.ToDecimal(dtPLT2.Rows[iRow]["GTIN_QTY"]);
            //    }
            //    else
            //    {
            //        m_dgv.Rows[iRow].Cells["GTIN_QTY"].Value = Convert.ToDecimal(m_dgv.Rows[iRow].Cells["GTIN_QTY"].Value).ToString("#####.000");
            //    }

            //    //記錄原始數據
            //    m_dgv.Rows[iRow].Cells["GTIN_QTY"].Tag = Convert.ToDecimal(dtPLT2.Rows[iRow]["GTIN_QTY"]);
            //}
            if (new2 > Convert.ToDecimal(args2.GTIN_QTY))
            {
                await SimpleDialog("can't exceed " + Convert.ToDecimal(args2.GTIN_QTY));
                txtGTIN_QTY2_NEW = Convert.ToDecimal(args2.GTIN_QTY).ToString();

            }
        }



        protected async Task KeyPressCheck(string tbPLT, string name)
        {
            //await SimpleDialog($@"val is {tbPLT},name is {name}   tbPLT1:{tbPLT1} tbPLT2:{tbPLT2} ");
            try
            {
                if (tbPLT.Trim().Length != 6) throw new Exception("incorect storage unit number");
                await QueryMst(name);

            }
            // QueryMst
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }

        }
    }
}
