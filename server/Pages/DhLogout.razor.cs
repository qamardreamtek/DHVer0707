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
    public partial class DhLogoutComponent
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

                // UserLog for login
                await DhGlobals.MLASRS_UserLog_Async("09", "Logout", "Logout", "", USER_ID, USER_NAME, DEPT_NAME, CLIENT_IP, ConnectionString);

                // Desgin NOTE by Mark, 06/23, 準備在此加入 Login/Logout 用戶軌跡的相關功能

                /// Account / Logout
                UriHelper.NavigateTo("/Account/Logout", forceLoad: true);
            }
            catch (Exception ex)
            {
                await SimpleDialog(ex.Message);
            }
        }
    }
}
