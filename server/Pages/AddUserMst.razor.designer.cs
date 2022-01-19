using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;

namespace RadzenDh5.Pages
{
    public partial class AddUserMstComponent : RadzenViewComponent
    {
        //[Parameter] public RadzenDh5.Models.Mark10Sqlexpress04.UserMst Data { get; set; }
        [Parameter]
        public dynamic COPY_USER_ID { get; set; } // template to create new record




        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }








        RadzenDh5.Models.Mark10Sqlexpress04.UserMst _usermst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.UserMst usermst
        {
            get
            {
                return _usermst;
            }
            set
            {
                if (!object.Equals(_usermst, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "usermst", NewValue = value, OldValue = _usermst };
                    _usermst = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            usermst = new RadzenDh5.Models.Mark10Sqlexpress04.UserMst() { };

            var mark10Sqlexpress04GetUserMstByUserIdResult = await Mark10Sqlexpress04.GetUserMstByUserId($"{COPY_USER_ID}");
            if (mark10Sqlexpress04GetUserMstByUserIdResult != null)
            {
                var x = mark10Sqlexpress04GetUserMstByUserIdResult;


                usermst.USER_ID = x.USER_ID;
                usermst.DEPT_NAME = x.DEPT_NAME;

                usermst.USER_NAME = x.USER_NAME;

                // USER_PSWD NOTE by Mark, 
                //usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);

                usermst.USER_PSWD = x.USER_PSWD;
                usermst.USER_PSWD = clsTool_2.DecryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);

                usermst.TELPHONE = x.TELPHONE;
                usermst.MOBILE = x.MOBILE;
                usermst.EMAIL = x.EMAIL;
                usermst.LANGUAGE = x.LANGUAGE;
                usermst.ENABLE = x.ENABLE;
                usermst.REMARK = x.REMARK;

                // 應該要確認 Note by Mark, 05/29
                usermst.PSWD_DATE = x.PSWD_DATE;
                usermst.LAST_DATE = x.LAST_DATE;
            }

        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            // Dev Note by Mark, 05/29
            // 檢查是否有同 USER_ID
            var checking = await Mark10Sqlexpress04.GetUserMstByUserId($"{args.USER_ID}");
            if (checking != null)
            {
               // NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"", Detail = $"data had exist", Duration = 8000 });
                await SimpleDialog("data had exist");
                return;
            }

            //if (sColumnName == "TRN_USER") sColumnValue = string.Format(@"{0}", Globals.USER_NAME);
            //if (sColumnName == "TRN_DATE") sColumnValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            //if (sColumnName == "CRT_USER") sColumnValue = string.Format(@"N'{0}'", Globals.USER_NAME);
            //if (sColumnName == "CRT_DATE") sColumnValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            args.TRN_USER = (string)USER_NAME;
            args.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            args.CRT_USER = (string)USER_NAME;
            args.CRT_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);

            try
            {
                var mark10Sqlexpress04CreateUserMstResult = await Mark10Sqlexpress04.CreateUserMst(usermst);
                DialogService.Close(usermst);

            }
            catch (System.Exception ex)
            {
                //   new Exception(ex.InnerException.ToString());
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"{ex.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
