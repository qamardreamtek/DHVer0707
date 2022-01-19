using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Models;

namespace RadzenDh5.Pages
{
    //public partial class XXP070PltDtlsComponent
    //public partial class P070PltDtlsComponent
    public partial class DhLoginComponent
    {
        [Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }

        protected void Toast(NotificationSeverity severity, string msg, double duration = 4000)
        {
            NotificationService.Notify(new NotificationMessage() { Severity = severity, Summary = "", Detail = msg, Duration = duration });

        }

        public string user;
        public string pass;
        public string pass2;
        public string localName;


        public string adminEncryptPass;
        public IEnumerable<Models.Mark10Sqlexpress04.UserMst> userMsts;

        public async Task<ApplicationUser> DhCreateUser(string Name, string Password)
        {

            var old = await Security.GetUserByName(Name);
            if (old != null)
            {
             //   Toast(NotificationSeverity.Info, old.Name + " 已存在");
                var old2 = await Security.DeleteUser(old.Id);
             //   Toast(NotificationSeverity.Info, old2.Name + " 已刪除");
            }

            var obj = new ApplicationUser();
            obj.Email = Name;// "mark3";
            obj.Password = Password;// "Aa123@"; 已經設為最少 8 chars, like ASRS,123
            // 到這裡, 如不滿足會導致頁面出錯, 但不在用戶端報錯, 使用 browser inspect to check
            var obj2 = await Security.CreateUser(obj);
            return obj2;
        }

        public async Task ButtonSubmitClick()
        {

       //     var x = await DhCreateUser("mark4", "Aa123@");
            //var x = await DhCreateUser("mark4", "ASRS,123");

            //Toast(NotificationSeverity.Success, x.Name + " created!");

            var toCreateList = AppDb.UserMsts.OrderBy(a => a.USER_ID);
            int cnt = 0;
            foreach(var u in toCreateList)
            {
                var u2 = await DhCreateUser(u.USER_ID, GetPlainPass(u.USER_PSWD));
                cnt += 1;
             //   Toast(NotificationSeverity.Success, u2.Name + " created!");

            }
            Toast(NotificationSeverity.Success, cnt + " 用戶已同步!");



        }
        static string sKey = "22099478";
        static string sIV = "35783280";

        public string GetPlainPass(string value)
        {
            return clsTool_2.DecryptDES(value, sKey, sIV);
        }
        protected void OnPassChange(string value, string name)
        {


            pass2 = clsTool_2.EncryptDES(value, sKey, sIV);
        }
        protected void OnUserChange(string value, string name)
        {

        }

        protected override void OnInitialized()
        {
        //    var admin = AppDb.UserMsts.Where(a => a.USER_ID == "admin").FirstOrDefault();
        //    adminEncryptPass = admin.USER_PSWD;

       //     userMsts = AppDb.UserMsts.OrderBy(a => a.USER_ID);
        }
    }
}
