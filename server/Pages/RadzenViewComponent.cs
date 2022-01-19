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

namespace RadzenDh5.Pages
{
    /// <summary>
    /// 這是用來給 VIEW 做 Base 的
    /// 不在乎用戶, 但是要 culture dictionary
    /// </summary>
    public partial class RadzenViewComponent : ComponentBase
    {

        public int grid0PageNumber = 0;
        public int grid1PageNumber = 0;
        public int grid2PageNumber = 0;



        public int gridPageSize = 10;

        //  Globals.CreateEmptyCMD_IN(tbSU_ID.Text, sItems);


        // in order to run 
        //MessageBox.Show(ex.Message)
        // like MLASRS style
        public async Task MessageBoxAsync(string msg, int width = 360, int height = 200)
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
        public class Globals
        {
            public static async Task CreateEmptyCMD_IN(string a, string b)
            {
                var x = a + "------" + b;
                throw new Exception("CreateEmptyCMD_IN");
            }

            public static async Task TODO(string msg)
            {
                //  var x = a + "------" + b;
                throw new Exception(msg);
            }

            //public  async Task UserLog(string p1,string p2, string p3, string p4)
            //{
            //   await DoUserLogAsync(p1,p2,p3,p4);
            //}


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


        protected async System.Threading.Tasks.Task ButtonExecuteClick(MouseEventArgs args)
        {
            try
            {
                await Globals.TODO("ButtonExecuteClick");
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }

        }


        //Design Note by Mark, 05/31
        // https://forum.radzen.com/t/select-radzentab-from-code/7370/5
        public int selectedTabIndex;

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
     //   public Dictionary<string, string> ReasonDic = new Dictionary<string, string>();

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
            //return "XXX";
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
            try
            {
                REMOTE_IP = httpContextAccessor.HttpContext.Connection?.RemoteIpAddress.ToString();
                CLIENT_IP = REMOTE_IP;

                Culture = "en-US";
                Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");

                // Lang Note by Mark, 05/19
                //await FillLangDic();

                DhUser = Security.User.UserName;

                // RecNum, BIG NOTE, by Mark, 05/15, 顯示 RecNum 造成這個問題
                //DhUsername = await DhGlobals.GetDhUsernameV2Async(AppDb, DhUser);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                DhUsername = await DhGlobals.GetDhUsernameAsync(DhUser);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                DEPT_NAME = await DhGlobals.GetDhDeptNameAsync(DhUser);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                var user = await DhGlobals.GetDhUserByIdAsync(USER_ID);

                //Globals.USER_NAME = DhUsername; //大量使用在 SQL

                // Log Note by Mark, 05/28, 儘量和 MLASRS 使用習慣相同
                USER_ID = DhUser;
                USER_NAME = DhUsername;
                ConnectionString = Configuration.GetConnectionString("Mark10Sqlexpress04Connection");


            }
            catch (Exception ex)
            {
            
            }


        }
    }
}
