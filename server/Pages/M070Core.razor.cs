using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using CaotunSpring.DH.Tools;

using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{

    public class DdlEntity
    {
        public string Val { get; set; }
        public string Txt { get; set; }
    }
    public partial class M070Component
    {

        public IEnumerable<DdlEntity> ddlNumber;
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "M070";
            await base.OnInitializedAsync();
            Globals.USER_NAME = DhUsername;

            //  ddlNumber.Add(new DdlNumber(){ "1", "1" });
            ddlNumber = new List<DdlEntity>
            {
                new DdlEntity{Val="1",Txt="1"},
                new DdlEntity{Val="2",Txt="2"},
                new DdlEntity{Val="3",Txt="3"},
                new DdlEntity{Val="4",Txt="4"},
                new DdlEntity{Val="5",Txt="5"},
                new DdlEntity{Val="6",Txt="6"},
                new DdlEntity{Val="7",Txt="7"},
                new DdlEntity{Val="8",Txt="8"},
                new DdlEntity{Val="9",Txt="9"},

            };

        }


        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }


        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> grid0;

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> getCmdMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult;

        // protected RadzenDh5.Models.Mark10Sqlexpress04.CmdMst Grid0RowSelected { get; set; }






        protected async Task ReloadTab1()
        {

            var args = ((CmdMst)ObjTab0Selected);
            getPltDtlsResult = await AppDb.PltDtls.Where(a => a.SU_ID == args.SU_ID).OrderBy(a => a.SKU_NO).ThenBy(a => a.GR_DATE).ThenBy(a => a.IN_SNO).AsNoTracking().ToListAsync();


            if (getPltDtlsResult.Count() > 0)
            {
                ObjTab1Selected = getPltDtlsResult.First();
            }
            else
            {
                ObjTab1Selected = null;
            }
        }




        protected async Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.CmdMst args)
        {
            ObjTab0Selected = args;
            var dialogResult = await DialogService.OpenAsync<ViewCmdMst>("CMD_MST", new Dictionary<string, object>() { { "CMD_DATE", args.CMD_DATE }, { "CMD_SNO", args.CMD_SNO } });
            //await InvokeAsync(() => { StateHasChanged(); });
        }
        protected async Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
        }
        protected async Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.CmdMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }


        //   public string reminder =  "NOTE: by Mark, 04/30, 看 WES 代碼關於 Change Priority , 只能改為 5, 請確認。如果是, UI 的 NEW PRTY. (可下拉選 1 到9), 是否不作用? 是否在 WebApp 不顯示?";
        //   NOTE by Mark, 05/01 10:00, 昨晚睡前看到了, 只是預設 5, 仍以下拉值來用
        public string class1234 = $@" col-12 col-sm-6 col-md-4  col-xl-3";// 1234 vs (12,6,4,3)
        public string style1234 = $@" text-align:right";// follow class1234


        // special case
        public string txtNEW_PRTY = "5";
        public int _txtNEW_PRTY = 5;
        //    public int txtNEW_PRTY;

        public int btnWidth = 200;

        public string valCMD_SNO;
        public string valSTN_NO;
        public string valEQU_NO;
        public string valSU_ID;
        public string valREQM_NO;
        public string valCMD_DATE;
        public string valLOC_NO;
        public string valREF_NO;
        public string valCRT_USER;
        public string valNEW_PRTY;


        public string GetSQL()
        {
            string dtMST = "CMD_MST"; //命令主檔
            string strSQL = string.Format(@"select * from {0}  where CMD_STS in ('0','1')", dtMST);

            strSQL += GetContains("CMD_SNO", ref txtCMD_SNO);
            strSQL += GetContains("STN_NO", ref txtSTN_NO);
            strSQL += GetContains("EQU_NO", ref txtEQU_NO);
            strSQL += GetContains("SU_ID", ref txtSU_ID);
            strSQL += GetContains("REQM_NO", ref txtREQM_NO);
            strSQL += GetContains("CMD_DATE", ref txtCMD_DATE);
            strSQL += GetContains("LOC_NO", ref txtLOC_NO);
            strSQL += GetContains("REF_NO", ref txtREF_NO);
            strSQL += GetContains("CRT_USER", ref txtCRT_USER);
            strSQL += " order by CMD_DATE desc, CMD_SNO desc";
            return strSQL;
        }
        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }
     
        protected async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                // 在 grid0 的 data 更新之前, 先調用 FixGrid0GotoPage0Async
                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                //getCmdMstsResult = await AppDb.CmdMsts.FromSqlRaw(GetSQL()).OrderByDescending(a => a.CMD_DATE).ThenByDescending(a => a.CMD_SNO).AsNoTracking().ToListAsync();
                getCmdMstsResult = await AppDb.CmdMsts.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();

                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getCmdMstsResult.Count() > 0)
                {
                    ObjTab0Selected = getCmdMstsResult.First();
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

        protected async Task ButtonChangePriorityClick()
        {
            await ChangePriorityPToolStripMenuItem_Click();
        }
        protected async Task ButtonChangeOutPortClick()
        {
            await ChangePortSToolStripMenuItem_Click();
        }
        protected async Task ButtonForceCancelClick()
        {
            await CreateCToolStripMenuItem_Click();
        }
        protected async Task ButtonForceEndClick()
        {
            await UpdateUToolStripMenuItem_Click();

        }




        private async Task ChangePriorityPToolStripMenuItem_Click()
        {
            try
            {


                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to change");

                //if (m_dgvExMst.RowCount < 1) return;
                if (getCmdMstsResult.Count() < 1) return;

                //DataGridViewRow dgvRow = m_dgvExMst.CurrentRow;
                var args = (CmdMst)ObjTab0Selected;


                //string sPRTY_TO = "5";
                //  if (cbPRTY.SelectedIndex > -1) sPRTY_TO = cbPRTY.SelectedText;
                string sPRTY_TO = txtNEW_PRTY;

                //string sCMD_STS = Convert.ToString(dgvRow.Cells["CMD_STS"].Value);
                //string sPRTY = Convert.ToString(dgvRow.Cells["PRTY"].Value);
                //string sCMD_DATE = Convert.ToString(dgvRow.Cells["CMD_DATE"].Value);
                //string sCMD_SNO = Convert.ToString(dgvRow.Cells["CMD_SNO"].Value);
                //string sCMD_MODE = Convert.ToString(dgvRow.Cells["CMD_MODE"].Value);

                string sCMD_STS = Convert.ToString(args.CMD_STS);
                string sPRTY = Convert.ToString(args.PRTY);
                string sCMD_DATE = Convert.ToString(args.CMD_DATE);
                string sCMD_SNO = Convert.ToString(args.CMD_SNO);
                string sCMD_MODE = Convert.ToString(args.CMD_MODE);

                if (sPRTY == sPRTY_TO) throw new Exception("same priority change");
                if (sCMD_STS != "0" && sCMD_STS != "X") throw new Exception("Executed CMD_STS=" + sCMD_STS + " can't change");
                if (sCMD_MODE != "2") throw new Exception("Not store out CMD can't change");

                string sREMARK = string.Format("Change Priority from {0} to {1}", sPRTY, sPRTY_TO);

                string sSQL = string.Format(@"
                update CMD_MST
                set PRTY='{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20),REMARK=REMARK+'{5}\r'
                where CMD_DATE='{2}' and CMD_SNO='{3}' and CMD_STS='{4}'
            ", sPRTY_TO, Globals.USER_NAME, sCMD_DATE, sCMD_SNO, sCMD_STS, sREMARK);

                //Globals.UpdateTable(sSQL);
                var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);

                await QueryMstAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
        }


        private async Task ChangePortSToolStripMenuItem_Click()
        {
            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to change");

                //if (m_dgvExMst.RowCount < 1) return;
                if (getCmdMstsResult.Count() < 1) return;

                //DataGridViewRow dgvRow = m_dgvExMst.CurrentRow;
                var args = (CmdMst)ObjTab0Selected;

                //string sCMD_STS = Convert.ToString(dgvRow.Cells["CMD_STS"].Value);
                //string sSTN_NO = Convert.ToString(dgvRow.Cells["STN_NO"].Value);
                //string sCMD_DATE = Convert.ToString(dgvRow.Cells["CMD_DATE"].Value);
                //string sCMD_SNO = Convert.ToString(dgvRow.Cells["CMD_SNO"].Value);
                //string sCMD_MODE = Convert.ToString(dgvRow.Cells["CMD_MODE"].Value);

                string sCMD_STS = Convert.ToString(args.CMD_STS);
                string sSTN_NO = Convert.ToString(args.STN_NO);
                string sCMD_DATE = Convert.ToString(args.CMD_DATE);
                string sCMD_SNO = Convert.ToString(args.CMD_SNO);
                string sCMD_MODE = Convert.ToString(args.CMD_MODE);


                if (sCMD_STS != "0") throw new Exception("Executed CMD can't change");
                if (sCMD_MODE != "2") throw new Exception("Not store out CMD can't change");

                string sSTN_NO_TO = "";
                switch (sSTN_NO)
                {
                    case "A04":
                        sSTN_NO_TO = "A06";
                        break;
                    case "A06":
                        sSTN_NO_TO = "A04";
                        break;
                    case "A10":
                        sSTN_NO_TO = "A12";
                        break;
                    case "A12":
                        sSTN_NO_TO = "A10";
                        break;
                    case "A16":
                        sSTN_NO_TO = "A18";
                        break;
                    case "A18":
                        sSTN_NO_TO = "A16";
                        break;
                    case "A22":
                        sSTN_NO_TO = "A24";
                        break;
                    case "A24":
                        sSTN_NO_TO = "A22";
                        break;
                    default: throw new Exception("Incorrect Out Port:" + sSTN_NO);
                }

                string sREMARK = string.Format("Change Out Port from {0} to {1}", sSTN_NO, sSTN_NO_TO);

                string sSQL = string.Format(@"
                    update CMD_MST
                    set STN_NO='{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20),REMARK=REMARK+'{5}\r'
                    where CMD_DATE='{2}' and CMD_SNO='{3}' and CMD_STS='{4}'
                ", sSTN_NO_TO, Globals.USER_NAME, sCMD_DATE, sCMD_SNO, sCMD_STS, sREMARK);
                //Globals.UpdateTable(sSQL);
                //QueryMst();
                var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                await QueryMstAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
        }

        /// <summary>
        /// Force Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task UpdateUToolStripMenuItem_Click()
        {
            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to force end");


                //if (m_dgvExMst.RowCount < 1) return;
                if (getCmdMstsResult.Count() < 1) return;

                //DataGridViewRow dgvRow = m_dgvExMst.CurrentRow;
                var args = (CmdMst)ObjTab0Selected;

                //string sCMD_STS = Convert.ToString(dgvRow.Cells["CMD_STS"].Value);
                //string sPRTY = Convert.ToString(dgvRow.Cells["PRTY"].Value);
                //string sCMD_DATE = Convert.ToString(dgvRow.Cells["CMD_DATE"].Value);
                //string sCMD_SNO = Convert.ToString(dgvRow.Cells["CMD_SNO"].Value);
                //string sCMD_MODE = Convert.ToString(dgvRow.Cells["CMD_MODE"].Value);
                string sCMD_STS = Convert.ToString(args.CMD_STS);
                string sPRTY = Convert.ToString(args.PRTY);
                string sCMD_DATE = Convert.ToString(args.CMD_DATE);
                string sCMD_SNO = Convert.ToString(args.CMD_SNO);
                string sCMD_MODE = Convert.ToString(args.CMD_MODE);
                string sCMD_STS_TO = "6";

                if (sCMD_STS != "0" && sCMD_STS != "1" && sCMD_STS != "2") throw new Exception("finished CMD can't force end.");

                string sREMARK = string.Format("Force End from {0} to {1}", sCMD_STS, sCMD_STS_TO);

                string sSQL = string.Format(@"
                update CMD_MST
                set CMD_STS='{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20),REMARK=REMARK+'{5}\r'
                where CMD_DATE='{2}' and CMD_SNO='{3}' and CMD_STS='{4}'
            ", sCMD_STS_TO, Globals.USER_NAME, sCMD_DATE, sCMD_SNO, sCMD_STS, sREMARK);

                //Globals.UpdateTable(sSQL);
                //QueryMst();
                var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                await QueryMstAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
        }

        /// <summary>
        /// Force End
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task CreateCToolStripMenuItem_Click()
        {
            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to force cancel");


                //if (m_dgvExMst.RowCount < 1) return;
                if (getCmdMstsResult.Count() < 1) return;

                //DataGridViewRow dgvRow = m_dgvExMst.CurrentRow;
                var args = (CmdMst)ObjTab0Selected;

                //string sCMD_STS = Convert.ToString(dgvRow.Cells["CMD_STS"].Value);
                //string sPRTY = Convert.ToString(dgvRow.Cells["PRTY"].Value);
                //string sCMD_DATE = Convert.ToString(dgvRow.Cells["CMD_DATE"].Value);
                //string sCMD_SNO = Convert.ToString(dgvRow.Cells["CMD_SNO"].Value);
                //string sCMD_MODE = Convert.ToString(dgvRow.Cells["CMD_MODE"].Value);
                string sCMD_STS = Convert.ToString(args.CMD_STS);
                string sPRTY = Convert.ToString(args.PRTY);
                string sCMD_DATE = Convert.ToString(args.CMD_DATE);
                string sCMD_SNO = Convert.ToString(args.CMD_SNO);
                string sCMD_MODE = Convert.ToString(args.CMD_MODE);


                string sCMD_STS_TO = "7";

                if (sCMD_STS != "0" && sCMD_STS != "1" && sCMD_STS != "2") throw new Exception("finished CMD can't force cancel.");

                string sREMARK = string.Format("Force End from {0} to {1}", sCMD_STS, sCMD_STS_TO);

                string sSQL = string.Format(@"
                update CMD_MST
                set CMD_STS='{0}',TRN_USER='{1}',TRN_DATE=convert(varchar(19),getdate(),20),REMARK=REMARK+'{5}\r'
                where CMD_DATE='{2}' and CMD_SNO='{3} and CMD_STS='{4}'
            ", sCMD_STS_TO, Globals.USER_NAME, sCMD_DATE, sCMD_SNO, sCMD_STS, sREMARK);
                //Globals.UpdateTable(sSQL);
                //QueryMst();
                var cnt = await AppDb.Database.ExecuteSqlRawAsync(sSQL);
                await QueryMstAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
        }


    }


}

