using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Models.Mark10Sqlexpress04;

namespace RadzenDh5.Pages
{
    public partial class M090Component
    {
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> grid0;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> getLocMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult { get; set; }



        protected async Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.LocMst args)
        {
            await DialogService.OpenAsync<ViewLocMst>("LOC_MST", new Dictionary<string, object>() { { "WHSE_NO", args.WHSE_NO }, { "LOC_NO", args.LOC_NO }, { "ZONE_NO", args.ZONE_NO } });
        }
        protected async Task Grid1RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewPltDtl>("PLT_DTL", new Dictionary<string, object>() { { "SU_ID", args.SU_ID }, { "IN_SNO", args.IN_SNO }, { "WHSE_NO", args.WHSE_NO }, { "IN_NO", args.IN_NO }, { "IN_LINE", args.IN_LINE }, { "STK_CAT", args.STK_CAT }, { "STK_SPECIAL_IND", args.STK_SPECIAL_IND }, { "STK_SPECIAL_NO", args.STK_SPECIAL_NO } });
        }

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

            strSQL += GetEQ("LOC_SIZE", ref txtLOC_SIZE);

            strSQL += GetGE("AVAIL", ref txtAVAIL_MIN);
            strSQL += GetLE("AVAIL", ref txtAVAIL_MAX);

            strSQL += GetGE("ROW_X", ref txtROW_FROM);
            strSQL += GetGE("BAY_Y", ref txtBAY_FROM);
            strSQL += GetGE("LVL_Z", ref txtLVL_FROM);

            strSQL += GetLE("ROW_X", ref txtROW_TO);
            strSQL += GetLE("BAY_Y", ref txtBAY_TO);
            strSQL += GetLE("LVL_Z", ref txtLVL_TO);

            //GoodMsg = strSQL;
            return strSQL;
        }
        protected async Task ReloadMainTab()
        {
            getLocMstsResult = await AppDb.LocMsts.FromSqlRaw(GetSQL()).OrderBy(a => a.LOC_NO).AsNoTracking().ToListAsync();
            await grid0.GoToPage(0);
        }
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

                // 在 grid0 的 data 更新之前, 先調用 FixGrid0GotoPage0Async
                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
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


        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "M090";
            await base.OnInitializedAsync();

            //Globals.USER_NAME = DhUsername;
        }


        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }




        protected async Task Load()
        {
            var mark10Sqlexpress04GetLocMstsResult = await Mark10Sqlexpress04.GetLocMsts();
            getLocMstsResult = mark10Sqlexpress04GetLocMstsResult;

            await grid0.GoToPage(0);
            //GoodMsg = DhGlobals.getMsgWithTimestamp(getLocMstsResult.Count() + " record(s) to display");
        }



        private async Task MLASRS_LocDisable_Async(bool bFlag)
        {
            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to change");

                string sLOC_NO = string.Empty;
                string sLOC_STS = string.Empty;
                //int iRow = m_dgvExMst.CurrentRow.Index;
                //if (iRow < 0) throw new Exception("no row selected");
                var args = (LocMst)ObjTab0Selected;
                if (args == null) throw new Exception("no row selected");

                //sLOC_NO = Convert.ToString(m_dgvExMst.Rows[iRow].Cells["LOC_NO"].Value);
                //sLOC_STS = Convert.ToString(m_dgvExMst.Rows[iRow].Cells["LOC_STS"].Value);
                sLOC_NO = args.LOC_NO;
                sLOC_STS = args.LOC_STS;


                if (bFlag)
                {
                    if (sLOC_STS != "N") throw new Exception("Location status not allow to disable");

                    string sSQL = string.Format(@"
                        update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='X',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                        where LOC_NO='{1}' and LOC_STS='N'
                    ", Globals.USER_NAME, sLOC_NO);

                    //if (Globals.UpdateTable(sSQL) > 0) MessageBox.Show("Disable success");
                    //else MessageBox.Show("Disable failed");
                    if (DhGlobals.MLASRS_UpdateTable(ConnectionString, sSQL) > 0) await SimpleDialog("Disable success");
                    else await SimpleDialog("Disable failed");


                }
                else
                {
                    if (sLOC_STS != "X") throw new Exception("Location status not allow to enable");

                    string sSQL = string.Format(@"
                        update LOC_MST set LOC_OSTS=LOC_STS,AVAIL=100,LOC_STS='N',TRN_USER=N'{0}',TRN_DATE=convert(varchar(19),getdate(),20),SU_ID=''
                        where LOC_NO='{1}' and LOC_STS='X'
                    ", Globals.USER_NAME, sLOC_NO);


                    //if (Globals.UpdateTable(sSQL) > 0) MessageBox.Show("Enable success");
                    //else MessageBox.Show("Enable failed");

                    if (DhGlobals.MLASRS_UpdateTable(ConnectionString, sSQL) > 0) await SimpleDialog("Enable success");
                    else await SimpleDialog("Enable failed");
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                await SimpleDialog(ex.Message);
            }
        }

        protected async Task ButtonDisableClick(MouseEventArgs args)
        {
            await MLASRS_LocDisable_Async(true);
        }

        protected async Task ButtonEnableClick(MouseEventArgs args)
        {
            await MLASRS_LocDisable_Async(false);
        }

        protected async Task ReloadTab1()
        {
            var args = ((LocMst)ObjTab0Selected);
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
        protected async Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.LocMst args)
        {
            ObjTab0Selected = args;
            await ReloadTab1();
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
