using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class LoginSuccessComponent
    {

        public bool IS_USER_ENABLE = true;

        public string UserName;
        public string USER_ENABLE_YN;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VRight> vRights;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VRight> vRightsCat;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VRight> vRightsCat1;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VRight> vRightsCat2;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.VRight> vRightsCat3;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await base.OnInitializedAsync();
                // dev purpose, just in case need to add extra Cookie
                var c2 = await JSRuntime.InvokeAsync<string>("Radzen.getCookie", ".AspNetCore.Culture");

                //Note by Qamar 2021-11-23
                //Console.WriteLine("LoginSuccess1:" + ConnectionString);
                //System.Diagnostics.Debug.WriteLine("LoginSuccess2:" + ConnectionString);
                //ModelState.AddModelError("Error", "LoginSuccess3:" + ConnectionString);

                System.Threading.Thread.Sleep(5000);
                Task.Delay(5000).Wait();

                // UserLog for login
                await DhGlobals.MLASRS_UserLog_Async("00", "Login", "Login", "", USER_ID, USER_NAME, DEPT_NAME, CLIENT_IP, ConnectionString);

                //await SimpleDialog(@$" debug ... to make log for {USER_ID} {USER_NAME} and {Culture}");
                //await SimpleDialog(@$" debug... prompt to change password : 系統每 <3個月> 提醒使用者更換密碼。");

                var obj = await AppDb.UserLogs.Where(a => a.USER_ID == USER_ID && a.PROG_ID == "S080" && a.LOG_TYPE == "05").OrderByDescending(a => a.LOG_DATE).AsNoTracking().FirstOrDefaultAsync();
                if (obj == null)
                {
               //     await SimpleDialog($@"Please change your password");

                }
                else
                {
                    //https://stackoverflow.com/questions/1607336/calculate-difference-between-two-dates-number-of-days
                    //(EndDate - StartDate).TotalDays
                    var d1 = Convert.ToDateTime(obj.LOG_DATE);
                    var d2 = DateTime.Now;
                    double totalDays = (d2 - d1).TotalDays;
                    var DaysToPromptChangePassword = 90000;
                    if (Configuration["DhConfig:DaysToPromptChangePassword"] != null)
                    {
                        try
                        {
                            DaysToPromptChangePassword = Convert.ToInt32(Configuration["DhConfig:DaysToPromptChangePassword"]);

                        }
                        catch (Exception ex)
                        {
                            // 如果給的值無法合法轉為 int, 不予受理, 不報錯
                        }
                    }
                    int intTotalDays = (int)totalDays;
                    if (intTotalDays > DaysToPromptChangePassword)
                    {
                        //await SimpleDialog(@$" Last time changed password was, {obj.LOG_DATE}, {intTotalDays} days ago. Please change your password.");

                    }
                    else
                    {
                  //      await SimpleDialog(@$" Last time changed password was, {obj.LOG_DATE}, {intTotalDays} days ago. 設定要提醒的天數為 {DaysToPromptChangePassword}.");

                    }


                }


                UriHelper.NavigateTo("/", forceLoad: true);
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
    }
}
