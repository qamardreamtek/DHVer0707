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
    public partial class M2Component
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

                UserName = httpContextAccessor.HttpContext.User.Identity.Name;
                Culture = "en-US";
                Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");

                var c2 = await JSRuntime.InvokeAsync<string>("Radzen.getCookie", ".AspNetCore.Culture");


                USER_ENABLE_YN = await DhGlobals.GetDhNameEnableAsync(UserName);// DEBUG by Mark, https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
                //USER_ENABLE_YN = "N"; // for DEBUG and TESTING only
                if (USER_ENABLE_YN != "Y")
                {
                    await SimpleDialog("This user has not been enabled");
                    UriHelper.NavigateTo("Login", true);
                    return;
                }
                else
                {
                    //await SimpleDialog("ENABLE ? YES");

                }

                await LoadMenu();
            }
            catch (Exception ex)
            {
                await Task.Delay(1000);
                navigationManager.NavigateTo("/", true);
            }
        }



        public string LANG { get { return Culture; } }

        async Task LoadMenu()
        {
            try
            {

                if (!(await DhGlobals.CheckIfViewExistAsync("V_RIGHT")))
                {
                    var text1 = await DhGlobals.CheckIfViewsAndProceduresExist();
                    var text2 = await DhGlobals.InitViewsAndProcedures();
                    var text3 = await DhGlobals.CheckIfViewsAndProceduresExist();

                    var text123 = text1 + "\n\n\n ####################\n\n\n";
                    text123 += text2 + "\n\n\n ####################\n\n\n ";
                    text123 += text3 + "\n\n\n ####################\n\n\n ";

                    await File.WriteAllTextAsync(DhGlobals.GetLogMenuName(), text123, System.Text.Encoding.UTF8);//NOTE by Mark, 05/03 10:40, to fix cloud VM not in utf8

                }


                vRightsCat = await AppDb.VRights.Where(a => a.user_id == UserName && a.PARENT_ID == "0").OrderBy(a => a.PROG_SNO).AsNoTracking().ToListAsync();


                vRightsCat1 = await AppDb.VRights.Where(a => a.user_id == UserName && a.PARENT_ID == "0").OrderBy(a => a.PROG_SNO).Skip(0).Take(2).AsNoTracking().ToListAsync();
                vRightsCat2 = await AppDb.VRights.Where(a => a.user_id == UserName && a.PARENT_ID == "0").OrderBy(a => a.PROG_SNO).Skip(2).Take(2).AsNoTracking().ToListAsync();
                vRightsCat3 = await AppDb.VRights.Where(a => a.user_id == UserName && a.PARENT_ID == "0").OrderBy(a => a.PROG_SNO).Skip(4).Take(2).AsNoTracking().ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
