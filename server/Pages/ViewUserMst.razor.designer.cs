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
using RadzenDh5.Data;

namespace RadzenDh5.Pages
{
    public partial class ViewUserMstComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic COPY_USER_ID { get; set; }

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
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetUserMstByUserIdResult = await Mark10Sqlexpress04.GetUserMstByUserId($"{COPY_USER_ID}");

            // BUG: 0.15.52
            // 例如S010, Create用戶, 再Update該用戶時, 由於密碼有加密, 會超過12碼無法Save

            mark10Sqlexpress04GetUserMstByUserIdResult.USER_PSWD = clsTool_2.DecryptDES(mark10Sqlexpress04GetUserMstByUserIdResult.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);
            usermst = mark10Sqlexpress04GetUserMstByUserIdResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            try
            {
                //NOTE by Mark, 這裡的密碼要加密


              //  usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);
                //if (sColumnName == "TRN_USER") sDataValue[i] = string.Format(@"N'{0}'", Globals.USER_NAME);
                //if (sColumnName == "TRN_DATE") sDataValue[i] = "convert(varchar(19),getdate(),20)";
                //if (sColumnName == "CRT_USER") sDataValue[i] = ""; //不用update
                //if (sColumnName == "CRT_DATE") sDataValue[i] = ""; //不用update
                //if (sColumnName == "LAST_DATE") sDataValue[i] = ""; //不用update
                //if (sColumnName == "PSWD_DATE" && bPSWD_DATE) sDataValue[i] = "convert(varchar(19),getdate(),20)";
                usermst.TRN_USER = Security.User.UserName;
                usermst.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
                usermst.PSWD_DATE = usermst.TRN_DATE;

                //string sSQL1 = string.Format(@"insert into {0}_HIS select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{3}' as LOG_USER from {0} where {1} = '{2}'", dtMST.TableName, sKey[0], sKeyValue[0], Globals.USER_NAME);
                //DhGlobalsService
                // public int UserLog(string sLOG_TYPE, string USER_ID, string sPROG_ID, string sREMARK, string remoteIP)


                //NOTE by Mark, 在編輯還沒有完成之前, 這筆記錄被刪除了
                //check是否存在數據，是否是ERP下傳
                //dt = new DataTable();
                //Globals.GetDataTable(string.Format("select * from {0} where {1}='{2}'", dtMST.TableName, sKey[0], sKeyValue[0]), ref dt);
                //if (dt.Rows.Count < 1) throw new Exception("no data found");

                // NOTE by Mark, 04/27, 目前只有改密碼可以, 其它會報錯
                // 因為密碼加密的問題, 也就是說, 已經加密的就不應該再加密
                //if (usermst.USER_PSWD.Length >=8 && usermst.USER_PSWD.Length <= 12)
                //{
                //    usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);

                //}



                usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);


                var mark10Sqlexpress04UpdateUserMstResult = await Mark10Sqlexpress04.UpdateUserMst($"{COPY_USER_ID}", usermst);
                DialogService.Close(usermst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateUserMstException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update UserMst" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonCreateClick(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        {
            try
            {
                //NOTE by Mark, 這裡的密碼要加密


                //  usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);
                //if (sColumnName == "TRN_USER") sDataValue[i] = string.Format(@"N'{0}'", Globals.USER_NAME);
                //if (sColumnName == "TRN_DATE") sDataValue[i] = "convert(varchar(19),getdate(),20)";
                //if (sColumnName == "CRT_USER") sDataValue[i] = ""; //不用update
                //if (sColumnName == "CRT_DATE") sDataValue[i] = ""; //不用update
                //if (sColumnName == "LAST_DATE") sDataValue[i] = ""; //不用update
                //if (sColumnName == "PSWD_DATE" && bPSWD_DATE) sDataValue[i] = "convert(varchar(19),getdate(),20)";
                usermst.TRN_USER = Security.User.UserName;
                usermst.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
                usermst.PSWD_DATE = usermst.TRN_DATE;

                //string sSQL1 = string.Format(@"insert into {0}_HIS select *,convert(varchar(19),getdate(),20) as LOG_DATE,'{3}' as LOG_USER from {0} where {1} = '{2}'", dtMST.TableName, sKey[0], sKeyValue[0], Globals.USER_NAME);
                //DhGlobalsService
                // public int UserLog(string sLOG_TYPE, string USER_ID, string sPROG_ID, string sREMARK, string remoteIP)


                //NOTE by Mark, 在編輯還沒有完成之前, 這筆記錄被刪除了
                //check是否存在數據，是否是ERP下傳
                //dt = new DataTable();
                //Globals.GetDataTable(string.Format("select * from {0} where {1}='{2}'", dtMST.TableName, sKey[0], sKeyValue[0]), ref dt);
                //if (dt.Rows.Count < 1) throw new Exception("no data found");

                // NOTE by Mark, 04/27, 目前只有改密碼可以, 其它會報錯
                // 因為密碼加密的問題, 也就是說, 已經加密的就不應該再加密
                if (usermst.USER_PSWD.Length >= 8 && usermst.USER_PSWD.Length <= 12)
                {
                    usermst.USER_PSWD = clsTool_2.EncryptDES(usermst.USER_PSWD, DhGlobalStatic.sKey, DhGlobalStatic.sIV);

                }


           //     var mark10Sqlexpress04UpdateUserMstResult = await Mark10Sqlexpress04.UpdateUserMst($"{USER_ID}", usermst);
                DialogService.Close(usermst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateUserMstException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update UserMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
