using CaotunSpring.DH.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components.Web;
using Radzen.Blazor;

namespace RadzenDh5.Pages
{

    public partial class RadzenComponent : ComponentBase
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
        /// </summary>
        public delegate Task DelegateUserLog(string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK, string USER_ID, string USER_NAME, string DEPT_NAME, string CLIENT_IP, string conn);

        /// <summary>
        /// 使用範例 P070
        /// await DoUserLog(DhGlobals.MLASRS_UserLog_Async, "01", PROG_ID, PROG_NAME_FOR_LOG, "SU_ID=" + sName, USER_ID, USER_NAME, DEPT_NAME, CLIENT_IP, ConnectionString);

        /// </summary>
        /// <param name="act"></param>
        /// <param name="sLOG_TYPE"></param>
        /// <param name="sPROG_ID"></param>
        /// <param name="sPROG_NAME"></param>
        /// <param name="sREMARK"></param>
        /// <param name="USER_ID"></param>
        /// <param name="USER_NAME"></param>
        /// <param name="DEPT_NAME"></param>
        /// <param name="CLIENT_IP"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        //        public async Task DoUserLog(DelegateUserLog act, string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK)
        public async Task DoUserLogAsync( string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK)

        {
            try
            {
                // 只限在頁面直接 UserLog 可以使用底層的 user, IP and connectionString
                // 如果是在 DhGlobal做 UserLog 需要在 parameter 給

                //string USER_ID, string USER_NAME, string DEPT_NAME, string CLIENT_IP, string conn
                //
                // var sREMARK = "TODO";
                // await act("01", PROG_ID, PROG_NAME_FOR_LOG, sREMARK, USER_ID, USER_NAME, DEPT_NAME, CLIENT_IP, ConnectionString);
                await DhGlobals.MLASRS_UserLog_Async(sLOG_TYPE, PROG_ID, sPROG_NAME, sREMARK, USER_ID, USER_NAME, DEPT_NAME, CLIENT_IP, ConnectionString);

                //await SimpleDialog("提示寫入完成, 如果失敗會另有提示");
            }
            catch (Exception ex)
            {
                //if (sPROG_ID == "P070")
                //{
                //    await SimpleDialog("這是刻意重現 MLASRS P070 的 USER_LOG 的報錯, 純粹是寫 log 的重覆在 1 秒之內有兩筆而造成的PK報錯, 和實現的操作是否成功無關。" + ex.Message);
                //    return;
                //}

                // Change of Design as per PM's advice, 2021-07-07, not to show USER_LOG known exception
                // await SimpleDialog(ex.Message);
            }

        }


        /// <summary>
        /// 這應該在 Query 更新 tab0 也就是 grid0 之前統一使用.
        /// 在頁面編輯可以用 DhFix 快速帶出
        /// 
        /// 1. 確定回到 tab0 
        ///    https://forum.radzen.com/t/switch-to-tab0-by-code/7987
        /// 2. 避開 RadzenGrid 的一個瑕疵 
        ///    https://forum.radzen.com/t/how-to-ensure-pager-to-be-the-first-page-before-we-hit-custom-filter/7790/3
        /// 
        /// 基本要求:
        /// 1. <RadzenTabs RenderMode="TabRenderMode.Client"  @bind-SelectedIndex=@selectedTabIndex 
        /// 2. <RadzenGrid  @ref="grid0"
        ///    同時 grid0 必需在代碼裡按使用的 entity 宣告
        /// 
        /// 注意: RenderMode="TabRenderMode.Client" 是 Radzen 修護另一個瑕疵 
        /// https://forum.radzen.com/t/radzengrid-on-tab-switching-lose-the-state-of-page-number/8063/10
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        public void DhFixRadzenTabsGridQueryNotBackToPage0<T>(ref RadzenGrid<T> grid)
        {
            //ObjTab0Selected = null;
            //ObjTab1Selected = null;
            //ObjTab2Selected = null;

            selectedTabIndex = 0;
            grid.GoToPage(0);
        }

        public int gridPageSize = 10;


        protected class Globals
        {
            public static string USER_NAME { get; set; }
        }




        //https://forum.radzen.com/t/ref-grid0-is-working-but-grid1-failed/8024/2
        public void OnTabChange(int index)
        {
            // DEBUG, by Mark, 06/02, Q060 tab2 problem

        }

        protected async System.Threading.Tasks.Task ButtonExitClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo("/Account/Logout", forceLoad: true);
        }
        protected async System.Threading.Tasks.Task ButtonMenuClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo("/", forceLoad: true);
        }
        protected async System.Threading.Tasks.Task ButtonRefreshClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
        }




        //Design Note by Mark, 05/31
        // https://forum.radzen.com/t/select-radzentab-from-code/7370/5
        public int selectedTabIndex=0; // Note by Mark, 06/18, initial as 0 may avoid some bug

        // Design Note by Mark, 05/29
        public async Task SimpleDialog(string msg, int width = 360, int height = 200)
        {

            //await DialogService.OpenAsync<DialogBasicPage>($"",
            //       new Dictionary<string, object>() { { "Message", $"{msg}" } },
            //       new DialogOptions() { Width = "360px", Height = "160px" });
            //await DialogService.OpenAsync<DialogBasicPage>($"",
            //       new Dictionary<string, object>() { { "Message", $"{msg}" } },
            //       new DialogOptions() { Width = $"{width}px", Height = $"{height}px" });
            await DialogService.OpenAsync<DialogBasicPage>($"",
                         new Dictionary<string, object>() { { "Message", $"{msg}" } },
                         new DialogOptions() { });

        }

        public void ResetValue(ref string refArgument)
        {
            refArgument = null;


        }
        public void PurifyFilterValue(ref string refArgument)
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref

            refArgument = refArgument != null ? refArgument.Trim() : "";


        }

        //Note by Qamar 2021-06-06
        public string GetGreaterThanOrEqualTo(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);
            var strSQL = "";
            if (txt != "") strSQL = @$" and {field} >= {txt.ToUpper()}";
            return strSQL;
        }
        public string GetLessThanOrEqualTo(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);
            var strSQL = "";
            if (txt != "") strSQL = @$" and {field} <= {txt.ToUpper()}";
            return strSQL;
        }


        public string GetContains(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);

            var strSQL = "";

            if (txt != "") strSQL = @$" and {field} like '%{txt.ToUpper()}%'";


            return strSQL;
        }

        //http://gentle.compilertools.net/book/relations.html
        /// <summary>
        ///  and {field} >= {txt.ToUpper()
        /// </summary>
        /// <param name="field"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string GetGE(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);
            var strSQL = "";
            if (txt != "") strSQL = @$" and {field} >= '{txt.ToUpper()}'";
            return strSQL;
        }
        /// <summary>
        ///  and {field} <= {txt.ToUpper()}
        /// </summary>
        /// <param name="field"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string GetLE(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);
            var strSQL = "";
            if (txt != "") strSQL = @$" and {field} <= '{txt.ToUpper()}'";
            return strSQL;
        }
        /// <summary>
        ///  and {field} == {txt.ToUpper()}
        /// </summary>
        /// <param name="field"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string GetEQ(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);
            var strSQL = "";
            if (txt != "") strSQL = @$" and {field} = '{txt.ToUpper()}'";
            return strSQL;
        }

        // Auth NOTE by Mark, 05/20
        // 
        public bool IsShowAuth;

        public Object ObjTab0Selected;
        public Object ObjTab1Selected;
        public Object ObjTab2Selected;

        /// <summary>
        /// 有 2 個或 3 個 tab 的時候, 
        /// 例如在 tab2 時做 Query, 要切換到 tab0
        /// 同時要忘掉之前任意在 tab0,tab1,tab2 所選的
        /// grid 已有的內容, 由於 data 每頁定義不同, 暫時不能在這裡 reset
        /// IDEA Note by Mark, 是否可以仿 query textbox 變量分組放在 Q000,S000
        /// 那麼就可以在這裡直接將 data 設為 null 來保持每頁面的代碼 simple and clean?
        /// </summary>
        public void ResetGridBindAndSwitchToTab0()
        {
            ObjTab0Selected = null;
            ObjTab1Selected = null;
            ObjTab2Selected = null;

            selectedTabIndex = 0;

        }

        /// <summary>
        /// 1. 參考 https://forum.radzen.com/t/switch-to-tab0-by-code/7987
        /// 
        /// 用 code 切換到 tab0, 合理
        /// selectedTabIndex = 0;
        /// 
        /// 2 參考 https://forum.radzen.com/t/how-to-ensure-pager-to-be-the-first-page-before-we-hit-custom-filter/7790
        ///
        /// 查詢時, 要手工加 code 來避開這個 bug, 我認為是瑕疵
        /// await grid0.GoToPage(0);
        /// 
        /// 雖然有救急的方法,是不是應該可以集成到 RadzenGrid, 在目前機制, 只要有新查詢, 控件即能在內部加上  await grid0.GoToPage(0);
        /// 由於 grid0 是必需要有指定的 Entity 做宣告, 不然會有 ref 的問題 (https://forum.radzen.com/t/ref-grid0-is-working-but-grid1-failed/8024/2)
        ///     protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> grid0;
        /// 
        /// 能在底層先定義共用的 grid0 嗎? 
        /// </summary>
        public void SwitchToTab0()
        {
            // 1. 用 code 切換到 tab0
            selectedTabIndex = 0;

        }
        //public async Task FixGrid0GotoPage0Async()
        //{
        //    //await grid0.GoToPage(0);
        //    throw new Exception("必需在各自頁加上 FixGrid0GotoPage0Async => await grid0.GoToPage(0);");
        //}

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        // SOP,Configuration and httpContextAccessor , by Mark, 05/09
        [Inject] protected IConfiguration Configuration { get; set; }
        [Inject] protected Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor { get; set; }


        [Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        [Inject] protected DhGlobalsService DhGlobals { get; set; }



        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }


        [Inject]
        protected NavigationManager navigationManager { get; set; }


        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        // SOP ReasonDic, by Mark, 05/09, It can be for overall language translation
        public string Culture;

        // Lang Note by Mark, 05/19 
        public Dictionary<string, string> LangDic = new Dictionary<string, string>();
        public Dictionary<string, string> ReasonDic = new Dictionary<string, string>();

        // SOP progWrt, by Mark, 05/09
        public string DhUser;
        public string DhUsername;
        public string USER_ID = "USER_ID";
        public string USER_NAME = "USER_NAME";
        public string DEPT_NAME = "DEPT_NAME";


        public string PROG_ID = "PROG_ID"; // 以R系列整理, Architect Note by Mark, 05/10
        public string PROG_NAME; // For log, 05/14
        public string PROG_NAME_FOR_LOG; // For log, 05/28, R030-R030 入庫日報表
        public Models.Mark10Sqlexpress04.ProgWrt progWrt; // 配合 WES 授權檢查的變量
        public Models.Mark10Sqlexpress04.ProgMst progMst; // 配合 WES 授權檢查的變量
        public string PROG_NAME_BY_CULTURE = "YYYY";
        public string ConnectionString;

        //Server=MARK10\\SQLEXPRESS04;Initial Catalog = DHDB;
        public string ConnectionString_ServerOnly;
        public string ConnectionString_DBOnly;
        public string AuthMsg = "";
        public string ErrMsg = "";
        public string GoodMsg = "";

        public string REMOTE_IP;
        public string CLIENT_IP;





        public string ReportPath;
        public string ReportFile;
        public string ReportName;
        public bool IsExportDisable = false; //可以略過 Query 直接 Export

        // Note by Mark, 05/11
        // R 系列有基本共用的起止日期
        //https://docs.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-5.0
        public DateTime dateFrom = new(2021, 1, 1);
        public DateTime dateTo = new(2021, 6, 30);
        public string strFrom;
        public string strTo;


        //public string IP1Client;
        //public string IP2Server;


        public string Lang(string str)
        {

            return LangDic.GetValueOrDefault(str, str);


        }

        //public async Task<string> Lang(string str)
        //{
        //    var obj = await AppDb.Translates.Where(a => a.TEXT == str).FirstOrDefaultAsync();

        //    if (obj != null)
        //    {
        //        switch (Culture)
        //        {
        //            case "en-US":
        //                return obj.EN_TEXT;

        //            case "th-TH":
        //                return obj.TH_TEXT;

        //            case "zh-CHT":
        //                return obj.TW_TEXT;

        //            case "zh-CHS":
        //                return obj.CN_TEXT;

        //            default:
        //                return obj.TEXT;
        //        }

        //    }
        //    return str;

        //}

        private async Task FillReasonsDic()
        {
            var Reasons = await AppDb.VTranslates.AsNoTracking().ToListAsync();

            if (Reasons != null)
            {
                ReasonDic = new Dictionary<string, string>();
                foreach (var x in Reasons)
                {
                    switch (Culture)
                    {
                        case "en-US":
                            ReasonDic.Add(x.TEXT, x.EN_TEXT);
                            break;
                        case "th-TH":
                            ReasonDic.Add(x.TEXT, x.TH_TEXT);
                            break;
                        case "zh-CHT":
                            ReasonDic.Add(x.TEXT, x.TW_TEXT);
                            break;
                        case "zh-CHS":
                            ReasonDic.Add(x.TEXT, x.CN_TEXT);
                            break;

                        default:
                            ReasonDic.Add(x.TEXT, x.EN_TEXT);
                            break;
                    }


                }
            }
            else
            {
                // WHY?
            }

        }

        private async Task FillLangDic()
        {
            try
            {
                var Reasons = await AppDb.Translates.AsNoTracking().ToListAsync();

                if (Reasons != null)
                {
                    LangDic = new Dictionary<string, string>();
                    foreach (var x in Reasons)
                    {
                        switch (Culture)
                        {
                            case "en-US":
                                LangDic.Add(x.TEXT, x.EN_TEXT);
                                break;
                            case "th-TH":
                                LangDic.Add(x.TEXT, x.TH_TEXT);
                                break;
                            case "zh-CHT":
                                LangDic.Add(x.TEXT, x.TW_TEXT);
                                break;
                            case "zh-CHS":
                                LangDic.Add(x.TEXT, x.CN_TEXT);
                                break;

                            default:
                                LangDic.Add(x.TEXT, x.TEXT);
                                break;
                        }


                    }
                }
                else
                {
                    // WHY?
                }

            }
            catch (Exception ex)
            {
                throw;
            }


        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);

            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                try
                {
                    // FOR R ONLOY
                    //   ReportPath = DhGlobals.GetReportPath();

                    // SOP, Language Translation, by Mark, 05/09
                    Culture = "en-US";
                    Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");

                    // Culture NOTE by Mark, 2021-06-11
                    // MLASRS 並未實施 Culture, 所以年不受 TH 影響, 西元+543
                    // 為了和 MLASRS 一致, R 系列的年, 以西元呈現, 不受 TH 影響

                    var dt = DateTime.Now;
                    var yyyy = dt.Year;

                    // 多語 Note by Mark, 06/15, 
                    // 和 Startup 搭配
                    //if (Culture == "th-TH") yyyy -= 543;


                    var mm = dt.Month;
                    var dd = dt.Day;
                    //datePickerFrom = new DateTime(yyyy, mm, dd);
                    //datePickerTo = new DateTime(yyyy, mm, dd);
                    dateFrom = new DateTime(yyyy, mm, dd);
                    dateTo = new DateTime(yyyy, mm, dd);


                    // Lang Note by Mark, 05/19
                    await FillLangDic();



                    // SOP, by Mark 05/08
                    DhUser = Security.User.UserName;

                    // RecNum, BIG NOTE, by Mark, 05/15, 顯示 RecNum 造成這個問題
                    //DhUsername = await DhGlobals.GetDhUsernameV2Async(AppDb, DhUser);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                    DhUsername = await DhGlobals.GetDhUsernameAsync(DhUser);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                    DEPT_NAME = await DhGlobals.GetDhDeptNameAsync(DhUser);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                    var user = await DhGlobals.GetDhUserByIdAsync(USER_ID);

                    Globals.USER_NAME = DhUsername; //大量使用在 SQL

                    // Log Note by Mark, 05/28, 儘量和 MLASRS 使用習慣相同
                    USER_ID = DhUser;
                    USER_NAME = DhUsername;
                    //if (user != null)
                    //{
                    //    DEPT_NAME = user.DEPT_NAME;
                    //}



                    //progWrt = await AppDb.ProgWrts.Where(a => a.USER_ID == DhUser && a.PROG_ID == PROG_ID).FirstOrDefaultAsync();
                    //progMst = await AppDb.ProgMsts.Where(a => a.PROG_ID == PROG_ID).FirstOrDefaultAsync();

                    progWrt = await DhGlobals.GetProgWrt(DhUser, PROG_ID);
                    // Auth NOTE by Mark, 05/28
                    // for Info and UserLog, no progWrt, and progMst will null
                    //


                    progMst = await DhGlobals.GetProgMst(PROG_ID);
                    PROG_NAME = progMst != null ? progMst.PROG_NAME : "---";
                    PROG_NAME_BY_CULTURE = progMst != null ? await DhGlobals.GetProgNameByCulture(progMst, Culture) : "en-US";
                    PROG_NAME_FOR_LOG = $@"{PROG_ID}-{PROG_ID} {PROG_NAME_BY_CULTURE}";

                    //     progWrt = await AppDb.ProgWrts.Where(a => a.USER_ID == DhUser && a.PROG_ID == PROG_ID).FirstOrDefaultAsync();
                    ConnectionString = Configuration.GetConnectionString("Mark10Sqlexpress04Connection");
                    //ConnectionString_ServerOnly = ConnectionString.Split(";")[0] + "(略)";
                    //ConnectionString_ServerOnly = ConnectionString.Split(";")[0];
                    ConnectionString_ServerOnly = ConnectionString.Split(";")[0].Split("=")[1].Trim();

                    ConnectionString_DBOnly = ConnectionString.Split(";")[1].Split("=")[1].Trim();

                    IsShowAuth = true;
                    if (Configuration["DhConfig:IsShowAuth"] != null && Configuration["DhConfig:IsShowAuth"] == "N")
                        IsShowAuth = false;


                    //https://stackoverflow.com/questions/57982444/how-do-i-get-client-ip-and-browser-info-in-blazor
                    REMOTE_IP = httpContextAccessor.HttpContext.Connection?.RemoteIpAddress.ToString();
                    CLIENT_IP = REMOTE_IP;




                    //await DhGlobals.LogProgAsync(PROG_ID, "ConnectionString_ServerOnly:" + ConnectionString_ServerOnly);
                    //await DhGlobals.LogProgAsync(PROG_ID, "REMOTE_IP:" + REMOTE_IP);
                    //await DhGlobals.LogPageVisitAsync("PageVisit", "" + REMOTE_IP + " " + PROG_ID + " " + DhUser + " " + DhUsername + " " + Culture + " {" + PROG_NAME + "} {" + PROG_NAME_BY_CULTURE + "}");

                    var permission = "---";
                    if (progWrt != null)
                    {
                        permission = @$"{progWrt.QUERY_WRT}{progWrt.PRINT_WRT}{progWrt.IMPORT_WRT}{progWrt.EXPORT_WRT}{progWrt.UPDATE_WRT}{progWrt.DELETE_WRT}{progWrt.APPROVE_WRT}{progWrt.ENABLE}";

                    }

                    var txtIsShowAuth = $@" {{IsShowAuth:false,{permission}}}";
                    if (IsShowAuth)
                    {
                        txtIsShowAuth = $@" {{IsShowAuth:true,{permission}}}";
                    }



                    await DhGlobals.LogPageVisitAsync("PageVisit", "" + REMOTE_IP + " " + PROG_ID + " " + DhUser + " " + Culture + " {" + DhUsername + "}" + " {" + PROG_NAME + "}" + txtIsShowAuth);



                }
                catch (Exception ex)
                {
                    // NOTE by Mark, 06/08
                    REMOTE_IP = "---";
                    CLIENT_IP = REMOTE_IP;
                    //
                    //throw;
                }

            }
        }
    }
}
