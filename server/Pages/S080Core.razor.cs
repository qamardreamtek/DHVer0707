using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace RadzenDh5.Pages
{
    // public partial class ProfileComponent
   // public partial class S080Component
    public partial class S080CoreComponent
    {

  
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "S080";
            await base.OnInitializedAsync();
            await Load();
            // FOR DEV USAGE
            //GoodMsg = $@"USER_ID={DhUser}, USER_NAME={DhUsername}, PROG_ID={PROG_ID}, PROG_WRT(APPROVE,UPDATE) = ({progWrt.APPROVE_WRT},{progWrt.UPDATE_WRT}) ";
            //ErrMsg = $@"USER_ID={DhUser}, USER_NAME={DhUsername}, PROG_ID={PROG_ID}, PROG_WRT(APPROVE,UPDATE) = ({progWrt.APPROVE_WRT},{progWrt.UPDATE_WRT}) ";
        }

        public string OldPassword;
        public string NewPassword;
        public string NewPassword2;


        protected async System.Threading.Tasks.Task ButtonSubmitClick()
        {
            string info = $@"({OldPassword},{NewPassword},{NewPassword2})";
            info = "";  // NOTE by Mark, 要 DEBUG 時, comment this line will do



            if (OldPassword == null || OldPassword == "")
            {
                await SimpleDialog("Please input old password");
                return;
            }
            if (NewPassword == null || NewPassword == "")
            {
                await SimpleDialog("Please input old password");
                return;
            }
            if (NewPassword2 == null || NewPassword2 == "")
            {
                await SimpleDialog("Please input repeat new password ");
                return;
            }

            if (NewPassword.Length < 8)
            //     if (NewPassword.Length < 8 || NewPassword.Length > 12)
            {
                await SimpleDialog("New password with at least 8 alphanumeric characters");

                return;
            }
            if (NewPassword.Length > 12)
            //     if (NewPassword.Length < 8 || NewPassword.Length > 12)
            {
                await SimpleDialog("New password with not more than 12 alphanumeric characters");

                return;
            }
            if (NewPassword == OldPassword)
            {
                await SimpleDialog("The new password cannot be the same as the old password");
                return;
            }
            if (NewPassword != NewPassword2)
            {
                await SimpleDialog("Two new passwords do not match");
                return;
            }


            var obj = await AppDb.UserMsts.Where(a => a.USER_ID == Security.User.UserName).AsNoTracking().FirstOrDefaultAsync();
            if (obj == null)
            {
                //Toast(NotificationSeverity.Info, "User " + Security.User.UserName + " record not found, Password update failed");
                await SimpleDialog("User " + Security.User.UserName + " record not found, Password update failed");
                return;
            }
            var strUSER_PSWD = clsTool_2.EncryptDES(OldPassword, DhGlobalStatic.sKey, DhGlobalStatic.sIV);

            if (strUSER_PSWD != obj.USER_PSWD)
            {
                //Toast(NotificationSeverity.Info, "Old pssword is not correct");// //NOTE by Mark, 【新增判斷】,原本寫法是直接在寫入數據庫含舊密碼的篩選
                await SimpleDialog("Old pssword is not correct");
                return;

            }

            var strNEW_PSWD = clsTool_2.EncryptDES(NewPassword, DhGlobalStatic.sKey, DhGlobalStatic.sIV);
            //   string strREMARK = Convert.ToString(dataTable.Rows[0]["REMARK"]);
            var strREMARK = string.Format(@"{0}::{1}::Change password of user {2} from {3} to::{4} ||", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")), Security.User.UserName, Security.User.UserName, strUSER_PSWD, strNEW_PSWD);

            //       string strSql = string.Format("update USER_MST
            //       set
            //       USER_PSWD = '{0}',
            //       PSWD_DATE=convert(varchar(19),getdate(),20),
            //       REMARK='{1}',
            //       TRN_DATE=convert(varchar(19),getdate(),20),
            //       TRN_USER=N'{2}'
            //       where USER_ID= '{3}' and USER_PSWD='{4}'"
            //       , strNEW_PSWD, strREMARK, USER_ID, strUSER_ID, strUSER_PSWD);

            obj.USER_PSWD = strNEW_PSWD;
            //https://www.mssqltips.com/sqlservertip/1145/date-and-time-conversions-using-sql-server/
            // select convert(varchar, getdate(), 20)	yyyy-mm-dd hh:mm:ss 2006-12-30 00:38:54
            obj.PSWD_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
            obj.REMARK = strREMARK;
            obj.TRN_DATE = obj.PSWD_DATE;
            obj.TRN_USER = Security.User.UserName;
            var obj2 = AppDb.Update(obj);
            int cnt = await AppDb.SaveChangesAsync();


            //  (Globals.UpdateUserPassword(textUserID.Text, textOldPassword.Text, textNewPassword.Text))
            //TodoS log
            //string sRet = Globals.UserLog("05", "S080", this.Text, "Password updated successfully");

            if (cnt == 1)
            {
                await SimpleDialog("Password updated successfully");
                //   string sRet = Globals.UserLog("05", "S080", this.Text, "Password updated successfully");
              
                await DoUserLogAsync("05",  "S080",PROG_NAME_FOR_LOG ,"Password updated successfully");

            

            }
            else
            {
                //MessageBox.Show("Password update failed"); //密码更新失败
                await SimpleDialog("Password update failed");

            }
        }
    }
}
