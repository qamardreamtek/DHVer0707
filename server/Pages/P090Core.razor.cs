using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using CaotunSpring.DH.Tools;
using Microsoft.AspNetCore.Components.Web;
using RadzenDh5.Shared;

namespace RadzenDh5.Pages
{
    //public partial class XXP070PltDtlsComponent
    //public partial class P070PltDtlsComponent

    public class SimpleOneColumn
    {
        public string OneColumn { get; set; }
    }

    public partial class P090CoreComponent
    //public partial class P090Component
    {


        /// <summary>
        /// 执行数据
        /// </summary>
        /// <returns></returns>
        private async Task MLASRS_Execute()
        {
            try
            {
                //must check user authourize
                //string progID = this.Name.ToString();
                //ProgWrt progWrt = (ProgWrt)Globals.hPROG_WRT[progID];

                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");

                //tbSU_ID = [Child Pallet ID]

                //須6位數
                //if (tbSU_ID.Text.Length != 6)
                //{
                //    MessageBox.Show("pallet id must 6 digits");
                //    tbSU_ID.SelectAll();
                //    return;
                //}

                //不可重覆加入
                //string sItems = string.Empty;
                //if (m_dgvExMst.Rows.Count > 0)
                //{
                //    for (int i = 0; i < m_dgvExMst.Rows.Count; i++)
                //    {
                //        if (m_dgvExMst.Rows[i].Cells[0].Value.ToString() == tbSU_ID.Text)
                //        {
                //            MessageBox.Show("can't duplicate");
                //            tbSU_ID.SelectAll();
                //            return;
                //        }
                //        sItems = sItems + m_dgvExMst.Rows[i].Cells[0].Value.ToString() + ",";
                //    }

                //    sItems = sItems.Substring(0, sItems.Length - 1); //去掉","將子托盤ID放在LOC_MST的REMARK
                //}

                //不可有PLT_DTL
                //if (!Globals.EmptyCheck(tbSU_ID.Text))
                //{
                //    MessageBox.Show("this is not empty pallet");
                //    tbSU_ID.SelectAll();
                //    return;
                //}

                //產生入庫命令
                //string sRet = Globals.UserLog("08", "P090", this.Text, tbSU_ID.Text);
                //Globals.CreateEmptyCMD_IN(tbSU_ID.Text, sItems);

                //MessageBox.Show("Empty pallet store in command create Success");
                await SimpleDialog("Empty pallet store in command create Success");
                //m_dgvExMst.Rows.Clear();

                //Globals.funFormRefresh(this);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        public string tbSU_ID_DTL = "";
        public int tbChild;

        public string childMsg;
        public string parentMsg;
        public int totalPalletQty = 0;
        public async Task OnChildChange(string val, string name)
        {
            // GoodMsg = val;
            int x;
            try
            {
                x = int.Parse(val);
                //    show = keep = value;
                childMsg = "";
            }
            catch (Exception ex)
            {
                //  console.Log($"{ex.Message}");
                //   show = keep;
                //                childMsg = "must be 100000 to 999999";
                childMsg = "must be numeric (0, 1, 2, 3, 4, 5, 6, 7, 8, and 9)";

            }
        }

        public async Task OnParentChange(string val, string name)
        {
            // GoodMsg = val;
            int x;
            try
            {
                x = int.Parse(val);
                //    show = keep = value;
                parentMsg = "";
            }
            catch (Exception ex)
            {
                //  console.Log($"{ex.Message}");
                //   show = keep;
                //                childMsg = "must be 100000 to 999999";
                parentMsg = "must be numeric (0, 1, 2, 3, 4, 5, 6, 7, 8, and 9)";

            }
        }

        //public tbSU_ID_DTL="";
        public async Task KeyDownCheck(KeyboardEventArgs e)
        {
            // Design Note by Mark, to ensure KeyDown and Code
            // var tbSU_ID_DTL_Length = tbSU_ID_DTL == null ? 0 : tbSU_ID_DTL.Length;
            //await SimpleDialog(tbSU_ID_DTL + "<<<" +e.Code+"?"+ nameof(Keys.Enter)+ "<<< "+ cnt);
            //return;
            if (tbSU_ID_DTL == null)
            {
                await SimpleDialog("pallet id must 6 digits  " + "(empty)");
                return;

            }
            // if (e.KeyCode == Keys.Enter)
            if (true)

            {
                //須6位數
                //if (tbSU_ID_DTL.Text.Length != 6)
                //   await SimpleDialog(tbSU_ID_DTL + "<<<" + e.Code + "?" + nameof(Keys.Enter) + "<<< " + cnt);
                if (tbSU_ID_DTL.Length != 6)

                {
                    //    MessageBox.Show("pallet id must 6 digits");
                    //  tbSU_ID_DTL.SelectAll();
                    await SimpleDialog("pallet id must 6 digits " + tbSU_ID_DTL);
                    return;
                }
                await SimpleDialog("ok, pallet id  6 digits " + tbSU_ID_DTL);


                //int iRowCount = m_dgvExMst.Rows.Count;
                //if (iRowCount == 7)
                //{
                //    MessageBox.Show("can't stack over 7 empty child pallets");
                //    tbSU_ID_DTL.SelectAll();
                //    return;
                //}

                //不可與父托盤重覆
                //if (tbSU_ID.Text == tbSU_ID_DTL.Text)
                //{
                //    MessageBox.Show("can't duplicate with parent pallet ID");
                //    tbSU_ID_DTL.SelectAll();
                //    return;
                //}

                //不可重覆加入
                //for (int i = 0; i < m_dgvExMst.Rows.Count; i++)
                //{
                //    if (m_dgvExMst.Rows[i].Cells[0].Value.ToString() == tbSU_ID_DTL.Text)
                //    {
                //        MessageBox.Show("can't duplicate");
                //        tbSU_ID_DTL.SelectAll();
                //        return;
                //    }
                //}

                //不可有PLT_DTL
                //if (!Globals.EmptyCheck(tbSU_ID_DTL.Text))
                //{
                //    MessageBox.Show("this is not empty pallet");
                //    tbSU_ID_DTL.SelectAll();
                //    return;
                //}

                //m_dgvExMst.Rows.Add();
                //int iRow = m_dgvExMst.Rows.Count - 1;
                //m_dgvExMst.Rows[iRow].Cells[0].Value = tbSU_ID_DTL.Text;

                //tbPLT_CNT.Text = (m_dgvExMst.Rows.Count + 1).ToString();
            }
        }
        protected new async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        {
            await ExecuteAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "P090";
            await base.OnInitializedAsync();
        }
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }


        protected RadzenGrid<SimpleOneColumn> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> _getPltDtlsResult;

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult2 { get; set; }


        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> getPltDtlsResult
        {
            get
            {
                return _getPltDtlsResult;
            }
            set
            {
                if (!object.Equals(_getPltDtlsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPltDtlsResult", NewValue = value, OldValue = _getPltDtlsResult };
                    _getPltDtlsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected async System.Threading.Tasks.Task Load()
        {
            //var mark10Sqlexpress04GetPltDtlsResult = await Mark10Sqlexpress04.GetPltDtls();
            //getPltDtlsResult = mark10Sqlexpress04GetPltDtlsResult;
            var obj = new SimpleOneColumn();
            obj.OneColumn = "ABC123";
            GetSimpleOneColumnResult = new List<SimpleOneColumn>();
            GetSimpleOneColumnResult.Add(obj);

        }




        protected async Task Toast(NotificationSeverity severity, string msg, double duration = 4000)
        {
            NotificationService.Notify(new NotificationMessage() { Severity = severity, Summary = "", Detail = msg, Duration = 4000 });
            //   await SimpleDialog(msg);
        }
        protected async System.Threading.Tasks.Task GridDeleteButtonClick(string item)
        {

            try
            {
                var obj = GetSimpleOneColumnResult.Where(a => a.OneColumn == item).FirstOrDefault();
                GetSimpleOneColumnResult.Remove(obj);
                // GoodMsg = DhGlobals.getMsgWithTimestamp(item + " deleted");
                totalPalletQty = 1 + GetSimpleOneColumnResult.Count();
            }
            catch (System.Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }

        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList1 { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> pltDtlsList2 { get; set; }

        public IList<SimpleOneColumn> GetSimpleOneColumnResult { get; set; }

        public string ParentPalletID { get; set; }

        /// <summary>
        /// 执行数据
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {

            try
            {
                if (progWrt.APPROVE_WRT != "Y") throw new Exception("no authorization to execute");
                AuthMsg = "authorization to execute granted";

                string Summary = "Please input Parent Pallet ID";
                //string Detail = "[Execute]";
                //bool result;
                //string msg;

                if (ParentPalletID == null)
                {
                    Summary = "pallet id must 6 digits";
                    await SimpleDialog(Summary);
                    return;
                }

                //須6位數
                if (ParentPalletID.Length != 6)
                {
                    Summary = "pallet id must 6 digits";
                    await SimpleDialog(Summary);
                    return;
                }

                // NOTE by Mark, 06/08, MLASRS 是允許沒有  Child Pallet 就生成命令的
                //if (GetSimpleOneColumnResult == null || GetSimpleOneColumnResult.Count == 0)
                //{
                //    Summary = "Please input Child PalletID";
                //    await SimpleDialog(Summary);

                //    return;
                //}



                string strChildPallet = "";

                //不可重覆加入
                if (GetSimpleOneColumnResult != null && GetSimpleOneColumnResult.Count > 0)
                {
                    foreach (var x in GetSimpleOneColumnResult)
                    {
                        if (x.OneColumn == ParentPalletID) // NOTE by Mark, 2021-04-13, 父子不可任何相同
                        {
                            Summary = "can't duplicate";
                            await SimpleDialog(Summary);
                            return;
                        }
                        strChildPallet += x.OneColumn + ",";
                    }
                    strChildPallet = strChildPallet.Substring(0, strChildPallet.Length - 1); //去掉","將子托盤ID放在LOC_MST的REMARK

                }


                //不可有PLT_DTL
                if (!(await DhGlobals.MLASRS_EmptyCheckAsync(ParentPalletID)))
                {
                    Summary = "this is not empty pallet";
                    await SimpleDialog(Summary);
                    return;
                }

                //產生入庫命令
                //string sRet = Globals.UserLog("08", "P090", this.Text, tbSU_ID.Text);
                await DoUserLogAsync("08", "P090", PROG_NAME_BY_CULTURE, ParentPalletID);
                await DhGlobals.MLASRS_CreateEmptyCMD_IN_Async(ConnectionString, DhUsername, ParentPalletID, strChildPallet);
                await SimpleDialog("Empty pallet store in command create Success");
                UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }

        }

        private (bool, string) OnExecuteClickCore()
        {
            try
            {

                var Summary = "Debug...";
                var Detail = "[Execute]";
                //   NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });

                //  var obj = AppDb.ProgWrts.Where(a => a.PROG_ID == "P090").FirstOrDefault();
                // BUG 
                // var obj = AppDb.ProgWrts.Where(a => a.PROG_ID == "P090").ToList();
                var obj = AppDb.ProgWrts.Where(a => a.USER_ID == Security.User.UserName && a.PROG_ID == "P090").ToList();


                if (obj.Count() != 1)
                {
                    Summary = "PROG_MST Record no found";
                    //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });
                    return (false, "PROG_MST Record no found");

                }
                //must check user authourize
                if (obj[0].APPROVE_WRT != "Y")
                {
                    Summary = "no authorization to execute";
                    //      NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });
                    return (false, "no authorization to execute");

                }

                //須6位數
                if (ParentPalletID.Length != 6)
                {
                    Summary = "pallet id must 6 digits";
                    //      NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });
                    return (false, "no authorization to execute");
                }



                //不可有PLT_DTL
                //if (!Globals.EmptyCheck(tbSU_ID.Text))
                //{
                //    MessageBox.Show("this is not empty pallet");
                //    tbSU_ID.SelectAll();
                //    return;
                //}
                bool EmptyCheckResult = true;

                if (AppDb.PltDtls.Where(a => a.SU_ID == ParentPalletID).Count() > 0)
                {
                    EmptyCheckResult = false;
                }

                if (!EmptyCheckResult)
                {
                    Summary = "this is not empty pallet";
                    //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });
                    return (false, "this is not empty pallet"); ;
                }



                //不可有PLT_DTL
                //if (!Globals.EmptyCheck(tbSU_ID.Text))
                //{
                //    MessageBox.Show("this is not empty pallet");
                //    tbSU_ID.SelectAll();
                //    return;
                //}


                //產生入庫命令
                //  string sRet = Globals.UserLog("08", "P090", this.Text, tbSU_ID.Text);
                //  Globals.CreateEmptyCMD_IN(tbSU_ID.Text, sItems);

                //檢查母托盤是否已有命令
                //sSQL = string.Format(@"select * from CMD_MST where SU_ID='{0}' and CMD_STS in ('0','1','2','X')", sSU_ID);
                //WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);
                //if (dataTable.Rows.Count > 1) throw new Exception("duplicate CMD_MST:" + sSQL);
                string[] STAT_LIST = { "0", "1", "2", "X" };
                var check1 = AppDb.CmdMsts.Where(a => a.SU_ID == ParentPalletID && STAT_LIST.Contains(a.CMD_STS));
                if (check1.Count() > 1)
                {
                    Summary = "duplicate CMD_MST " + check1.ToQueryString();
                    //     NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });
                    return (false, Summary);
                }

                //取得CMD_SNO
                //string sCMD_DATE = GetCmdDate(); // DateTime.Now.ToString("yyMMdd");
                //string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
                //if (sCMD_SNO == "") throw new Exception("can't get CMD_SNO");

                // sSQL = "select convert(varchar(6),getdate(),12)"; //yyMMdd

                ////https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
                var sCMD_DATE = DateTime.Today.ToString("yyMMdd");
                //                var sCMD_DATE = DateTime.Today.ToString("yyMMdd");

                //GetCmdSno
                //    Summary = "Empty pallet store in command create Successt";
                //SELECT* FROM  SNO_CTL
                //SNO_TYPE SNO TRN_DATE
                //CmdSno  2   210412
                //PC  2   200619
                //PIC 1   200728
                //TX  6   200706


                Summary = "DOING 取得 CMD_SNO";
                Detail = "sCMD_DATE is " + sCMD_DATE;

                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = Summary, Detail = Detail, Duration = 4000 });

                return (true, "DOING...");

            }
            catch (Exception ex)
            {
                return (false, ex.ToString());
            }




        }



        protected async Task OnTxtChildChange(string value, string name)
        {
            var Summary = "TESTING";
            // var Detail = " by Child Pallet ID";


            //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = Summary, Detail = Detail, Duration = 4000 });
            //須6位數
            if (value.Length != 6)
            {
                Summary = "pallet id must 6 digits";
                await SimpleDialog(Summary);
                return;
            }
            if (GetSimpleOneColumnResult != null && GetSimpleOneColumnResult.Count == 7)
            {

                Summary = "can't stack over 7 empty child pallets";
                await SimpleDialog(Summary);
                return;
            }

            //不可與父托盤重覆
            if (ParentPalletID != null && value == ParentPalletID)
            {
                Summary = "can't duplicate with parent pallet ID";
                await SimpleDialog(Summary);
                return;
            }

            //不可重覆加入
            if (GetSimpleOneColumnResult != null)
            {
                foreach (var x in GetSimpleOneColumnResult)
                {
                    if (x.OneColumn == value)
                    {
                        Summary = "can't duplicate";
                        await SimpleDialog(Summary);

                        return;
                    }
                }
            }

            //不可有PLT_DTL

            if (!await DhGlobals.MLASRS_EmptyCheckAsync(value))
            {
                await SimpleDialog("this is not empty pallet");
                return;
            }


            // NOTE by Mark,06/08, (1)將 SU_IT_DTL 值寫入列表, 並更新 totalPalletQty
            var obj = new SimpleOneColumn();
            obj.OneColumn = value;
            if (GetSimpleOneColumnResult == null)
            {
                GetSimpleOneColumnResult = new List<SimpleOneColumn>();
            }
            GetSimpleOneColumnResult.Add(obj);

            totalPalletQty = 1 + GetSimpleOneColumnResult.Count();
        }

        protected void OnTxtParentChangeV2(int value, string name)
        {

        }
        protected void OnTxtParentChange(string value, string name)
        {
            //   console.Log($"{name} value changed to {value}");
            if (value.Length == 6)
            {
                pltDtlsList2 = AppDb.PltDtls.Where(a => a.SU_ID == value).ToList();

                //NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = "TODO", Detail = "...寫業務邏輯", Duration = 4000 });

            }
            else
            {
                var Summary = "incorect storage unit number";
                //                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = Summary, Detail = Detail, Duration = 4000 });
                Toast(NotificationSeverity.Info, Summary);

            }

        }


        public void ToAdd()
        {
            var Summary = "TODO";
            var Detail = "這部份業務邏輯比較多, 要另外花時間處理";
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = Summary, Detail = Detail, Duration = 4000 });

        }
        public void ToRemove()
        {
            var Summary = "TODO";
            var Detail = "這部份業務邏輯比較多, 要另外花時間處理";
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = Summary, Detail = Detail, Duration = 4000 });

        }

    }
}
