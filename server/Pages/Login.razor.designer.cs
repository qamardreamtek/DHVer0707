using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RadzenDh5.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;

namespace RadzenDh5.Pages
{
    public partial class LoginComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

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
        protected SecurityService Security { get; set; }


        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }

        // NOTE by Mark, 05/02
        [Inject] IWebHostEnvironment WebEnvironment { get; set; }
        [Inject] CaotunSpring.DH.Tools.DhGlobalsService DhGlobals { get; set; }
        [Inject] BlazorApp1.Data.PageService DhPage { get; set; }


        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            // NOTE by Mark, 05/02, 準備在這裡仿PHP項目常用的 config 方法, 用來確保系統會使用最新的VIEW and SP
            // CONFIG 成功後, 會生成一個  CONFIG_LOG.json
            // 在這裡去讀 wwwroot/CONFIG_LOG.json 裡的內容
            // 如果讀不到檔案, 或是裡面有意外
            // 即自動進行 INIT 的動作
            var wwwroot = WebEnvironment.WebRootPath;
            //string curFile = @"c:\temp\test.txt";
            //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            string LogPath = $@"{wwwroot}/logs";
            if (!Directory.Exists(LogPath))
            {
                // 由於 gitignore 了 **/logs, 任何 logs 的 directory 都不會上傳
                // 需要直接在 客戶的環境新建

                DirectoryInfo di = Directory.CreateDirectory(LogPath);

            }

            (string ver, string verDesc) = DhPage.GetLoginVersionReminder();
            // Deploy NOTE by Mark, 05/19,
            // 原構想, 只要有 CONFIG_LOG 的最新版本, 就不會 DROP/CREATE VIEW
            // 之前版本在這裡是要人工維護, 改採用 LoginVersionReminder.json 的最新版本
            //var ver = "0.11.28";



            // VIEW|SP Note by Mark, 05/21
            string checkLogFile1 = $@"{wwwroot}/logs/log{ver}.txt"; //隨著升級, 可以設不同的檔案名, 搭配 update release
                                                                    //string checkLogFile2 = $@"{wwwroot}/logs/log{ver}___2.txt"; //隨著升級, 可以設不同的檔案名, 搭配 update release
                                                                    //string checkLogFile3 = $@"{wwwroot}/logs/log{ver}___3.txt"; //隨著升級, 可以設不同的檔案名, 搭配 update release

            //string configLogFile = $@"{wwwroot}/logs/CONFIG_LOG_{ver}.txt"; //隨著升級, 可以設不同的檔案名, 搭配 update release

            if (File.Exists(checkLogFile1))
            {
                //     NotificationService.Notify(NotificationSeverity.Info, "表示已同步" );

            }
            else
            {
                //     NotificationService.Notify(NotificationSeverity.Warning, "要處理所有 VIEW SP init");

                //var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 已同步";

                var text1 = await CheckViewAndSp();
                var text2 = await InitViewAndSp();
                var text3 = await CheckViewAndSp();

                var text123 = text1 + "\n\n\n ####################\n\n\n";
                text123 += text2 + "\n\n\n ####################\n\n\n ";
                text123 += text3 + "\n\n\n ####################\n\n\n ";


                File.WriteAllText(checkLogFile1, text123, Encoding.UTF8);//NOTE by Mark, 05/03 10:40, to fix cloud VM not in utf8
                //File.WriteAllText(checkLogFile2, text1, Encoding.UTF8);
                //File.WriteAllText(checkLogFile3, text3, Encoding.UTF8);

            }

            await Load();
        }
        private async Task<string> CheckViewAndSp()
        {
            var sb = new StringBuilder();
            sb.Append(await DhGlobals.CheckView("V_C010"));
            sb.Append(await DhGlobals.CheckView("V_LOC_DTL_MST"));
            sb.Append(await DhGlobals.CheckView("V_LOC_DTL_MST__PLT_DTL"));
            sb.Append(await DhGlobals.CheckView("V_LOC_DTL_MST__PLT_DTl__IN_DTL"));
            sb.Append(await DhGlobals.CheckView("V_P020_LocDtl"));
            sb.Append(await DhGlobals.CheckView("V_P020_MergeOutDtl"));
            sb.Append(await DhGlobals.CheckView("V_P020A"));
            sb.Append(await DhGlobals.CheckView("V_P020B"));
            sb.Append(await DhGlobals.CheckView("V_P030"));
            sb.Append(await DhGlobals.CheckView("V_P030SUB"));
            sb.Append(await DhGlobals.CheckView("V_P060"));
            sb.Append(await DhGlobals.CheckView("V_P070"));
            sb.Append(await DhGlobals.CheckView("V_P080"));
            sb.Append(await DhGlobals.CheckView("V_P100"));

            sb.Append(await DhGlobals.CheckView("V_R030"));
            sb.Append(await DhGlobals.CheckView("V_R040"));
            sb.Append(await DhGlobals.CheckView("V_R050"));
            sb.Append(await DhGlobals.CheckView("V_R060"));
            sb.Append(await DhGlobals.CheckView("V_R070"));
            sb.Append(await DhGlobals.CheckView("V_R080"));
            sb.Append(await DhGlobals.CheckView("V_RIGHT"));
            sb.Append(await DhGlobals.CheckView("v_table_list"));
            sb.Append(await DhGlobals.CheckView("V_TRANSLATE"));
            sb.Append(await DhGlobals.CheckView("V_USER_PROG_BY_GROUP"));
            sb.Append(await DhGlobals.CheckView("v_user_role"));
            sb.Append(await DhGlobals.CheckView("V_XXXP故意不存在"));

            sb.Append(await DhGlobals.CheckSP("SP_C030"));
            sb.Append(await DhGlobals.CheckSP("SP_R040"));
            sb.Append(await DhGlobals.CheckSP("SP_R050"));
            sb.Append(await DhGlobals.CheckSP("SP_R060"));
            sb.Append(await DhGlobals.CheckSP("SP_R070"));
            sb.Append(await DhGlobals.CheckSP("SP_XXX故意不存在"));

            return sb.ToString();
        }
        private async Task<string> InitViewAndSp()
        {
            var sb = new StringBuilder();

            sb.Append(await DhGlobals.UpdateView("V_C010"));

            sb.Append(await DhGlobals.UpdateView("V_LOC_DTL_MST"));
            sb.Append(await DhGlobals.UpdateView("V_LOC_DTL_MST__PLT_DTL"));
            sb.Append(await DhGlobals.UpdateView("V_LOC_DTL_MST__PLT_DTl__IN_DTL"));

            sb.Append(await DhGlobals.UpdateView("V_P020_LocDtl"));
            sb.Append(await DhGlobals.UpdateView("V_P020_MergeOutDtl"));
            sb.Append(await DhGlobals.UpdateView("V_P020A"));
            sb.Append(await DhGlobals.UpdateView("V_P020B"));
            sb.Append(await DhGlobals.UpdateView("V_P030"));
            sb.Append(await DhGlobals.UpdateView("V_P030SUB"));
            sb.Append(await DhGlobals.UpdateView("V_P060"));
            sb.Append(await DhGlobals.UpdateView("V_P070"));
            sb.Append(await DhGlobals.UpdateView("V_P080"));
            sb.Append(await DhGlobals.UpdateView("V_P100"));


            sb.Append(await DhGlobals.UpdateView("V_R030"));
            sb.Append(await DhGlobals.UpdateView("V_R040"));
            sb.Append(await DhGlobals.UpdateView("V_R050"));
            sb.Append(await DhGlobals.UpdateView("V_R060"));
            sb.Append(await DhGlobals.UpdateView("V_R070"));
            sb.Append(await DhGlobals.UpdateView("V_R080"));

            sb.Append(await DhGlobals.UpdateView("V_RIGHT"));
            sb.Append(await DhGlobals.UpdateView("v_table_list"));
            sb.Append(await DhGlobals.UpdateView("V_TRANSLATE"));
            sb.Append(await DhGlobals.UpdateView("V_USER_PROG_BY_GROUP"));
            sb.Append(await DhGlobals.UpdateView("v_user_role"));


            sb.Append(await DhGlobals.UpdateSP("SP_C030"));
            sb.Append(await DhGlobals.UpdateSP("SP_R040"));
            sb.Append(await DhGlobals.UpdateSP("SP_R050"));
            sb.Append(await DhGlobals.UpdateSP("SP_R060"));
            sb.Append(await DhGlobals.UpdateSP("SP_R070"));

            return sb.ToString();
        }

        protected async System.Threading.Tasks.Task Load()
        {
            var error = System.Web.HttpUtility.ParseQueryString(new Uri(UriHelper.ToAbsoluteUri(UriHelper.Uri).ToString()).Query).Get("error");

            if (!string.IsNullOrEmpty(error))
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"{error}" });
            }

            // NOTE by Mark, for Language
            Culture = "";

            Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
        }

        protected async System.Threading.Tasks.Task Login0Register()
        {
            await DialogService.OpenAsync<RegisterApplicationUser>("Register Application User", null);
        }
    }
}
