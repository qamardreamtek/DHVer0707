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

    public partial class P100Component
    {
        protected RadzenGrid<Vp100> grid0;
        protected IEnumerable<Vp100> getVp100sResult { get; set; }


        public IEnumerable<DdlEntity> ddlNumber;
        protected async Task ButtonQueryClick(MouseEventArgs args)
        {
            await QueryMstAsync();

        }
        protected async Task ButtonExecuteClick(MouseEventArgs args)
        {
            await ExecuteAsync();
        }

        private async Task QueryMstAsync()
        {
            try
            {
                await DoUserLogAsync("01", PROG_ID, PROG_NAME_FOR_LOG, "");

                DhFixRadzenTabsGridQueryNotBackToPage0(ref grid0);
                getVp100sResult = await AppDb.Vp100s.FromSqlRaw(GetSQL()).AsNoTracking().ToListAsync();



                // 預設的連動: 有顯示資料就以第一筆為選中, 並直接 reload tab1, 以此類推到 tab2
                if (getVp100sResult.Count() > 0)
                {
                    ObjTab0Selected = getVp100sResult.First();
                 
                }
             
                await InvokeAsync(() => { StateHasChanged(); });

            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }

        void DhFixRadzenTabsGridQueryNotBackToPage0<T>(ref RadzenGrid<T> grid)
        {
            selectedTabIndex = 0;
            grid.GoToPage(0);
        }

     



        public int intEQU_NO = 0; // It seems it must be int, not string
        public int intPORT = 4; // It seems it must be int, not string


        string dtMST = "LOC_MST";
        //string sAPPROVE = "N";
        //string sAPPROVE_UPDATE = "N";
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P100";
            await base.OnInitializedAsync();

            ddlNumber = new List<DdlEntity>
            {
                new DdlEntity{Val="01",Txt="#1 CRANE"},
                new DdlEntity{Val="02",Txt="#2 CRANE"},
                new DdlEntity{Val="03",Txt="#3 CRANE"},
                new DdlEntity{Val="04",Txt="#4 CRANE"},


            };
        }

        protected async Task Grid0RowSelect(Vp100 args)
        {
     
            ObjTab0Selected = args;

        }


        public string GetSQL()
        {

            txtLOC_NO = (txtLOC_NO == null) ? "" : txtLOC_NO.Trim();
            txtSU_ID = (txtSU_ID == null) ? "" : txtSU_ID.Trim();

            string sSQL = string.Format(@"select EQU_NO,LOC_NO,SU_ID,CEILING(LEN(REMARK)/7.0) as PLT_CNT,REMARK from {0}  where LOC_STS='E'", dtMST);
            if (txtLOC_NO != "") sSQL += string.Format(@" and LOC_NO like '%{0}%'", txtLOC_NO);
            if (txtSU_ID != "") sSQL += string.Format(@" and SU_ID like '%{0}%'", txtSU_ID);
            if (txtEQU_NO !=null)
            {

                sSQL += string.Format(@" and EQU_NO = '{0}'", txtEQU_NO);
            }

            sSQL += " order by EQU_NO,LOC_NO";
            return sSQL;
            //ErrMsg = sSQL;  // FOR DEBUG PURPOSE

        }
        public async Task ExecuteAsync()
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                var item = (Vp100)ObjTab0Selected;

                string sSU_IDs = "";
                //foreach (DataGridViewRow dgvRow in m_dgvExMst.SelectedRows)
                //{
                string sEQU_NO = item.EQU_NO;
                string sLOC_NO = item.LOC_NO;
                string sSU_ID = item.SU_ID;
                string sPLT_CNT = item.PLT_CNT.ToString();
                string sREMARK = item.REMARK;
                //   sSU_IDs = sSU_IDs + sSU_ID + "/";
                sSU_IDs = sSU_ID;

                // NOTE: 在原右下角有個 PORT. 下拉, FRONT, REAR
                //    按照這寫法, 第一感是, 

                //    string sPORT = "4";
                //    if (cbPORT.SelectedIndex == 0) sPORT = "2";
                //
                //    FRONT => "2"
                //    REAR  => "4"
                string sPORT = "" + intPORT;

                await DhGlobals.CreateEmptyCMD_OUT(ConnectionString, DhUsername, PROG_ID, sEQU_NO, sLOC_NO, sSU_ID, sREMARK, sPORT);
                //    Globals.CreateEmptyCMD_OUT(sEQU_NO, sLOC_NO, sSU_ID, sREMARK, sPORT);
                //}
                //sSU_IDs = sSU_IDs.Substring(0, sSU_IDs.Length - 1);

                //  string sRet = Globals.UserLog("08", "P100", this.Text, sSU_IDs);
                await DoUserLogAsync("08", PROG_ID, PROG_NAME, sSU_IDs);

                //   MessageBox.Show("Success count:" + m_dgvExMst.SelectedRows.Count.ToString());

                //    Globals.funFormRefresh(this);

               // NotificationService.Notify(NotificationSeverity.Success, "Execute success");
                await SimpleDialog("Execute success");
                await QueryMstAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //ErrMsg = ex.Message;
                await SimpleDialog(ex.Message);
            }
        }
     




    }
}
