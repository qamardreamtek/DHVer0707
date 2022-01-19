using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RadzenDh5.Models;

namespace RadzenDh5
{
    public partial class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment env;

        public AccountController(SecurityService Security, RadzenDh5.Data.Mark10Sqlexpress04Context AppDb, IWebHostEnvironment env, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;

            this.Security = Security;
            this.AppDb = AppDb;

        }




        // ������ԭ��ͬ���_�l�r����, ���������^�����{ԇ
        // [Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        // [Inject]
        //protected SecurityService Security { get; set; }
        protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb;

        protected SecurityService Security;


        public async Task<ApplicationUser>  DhCreateUser(string Name, string Password)
        {

            var old = await Security.GetUserByName(Name);
            if (old != null)
            {
                //   Toast(NotificationSeverity.Info, old.Name + " �Ѵ���");
                var old2 = await Security.DeleteUser(old.Id);
                //   Toast(NotificationSeverity.Info, old2.Name + " �фh��");
            }

            var obj = new ApplicationUser();
            obj.Email = Name;// "mark3";
            obj.Password = Password;// "Aa123@"; �ѽ��O������ 8 chars, like ASRS,123
                                    // ���@�e, �粻�M������������e, �������Ñ��ˈ��e, ʹ�� browser inspect to check
            var obj2 = await Security.CreateUser(obj);
            return obj2;
        }


        /// <summary>
        ///
        /// 
        /// Account Note by Mark, 06/17, ENABLE ����Y ��Ҫ��ʾ This user has net been enabled
        // ����� ASP.NET Core �ČӴ�, Ҫ���S����
        // �� menu �ęz��Ł�̎��, �ٷ��ص� login ���

        /// </summary>
        /// <returns></returns>
        public async Task<string> ButtonSubmitClick()
        {


            //var toCreateList = AppDb.UserMsts.OrderBy(a => a.USER_ID);

            //var toCreateList = AppDb.UserMsts.Where(a => a.ENABLE == "Y").OrderBy(a => a.USER_ID);

            var toCreateList = AppDb.UserMsts.OrderBy(a => a.USER_ID);

            int cnt = 0;
            foreach (var u in toCreateList)
            {
                var u2 = await DhCreateUser(u.USER_ID, GetPlainPass(u.USER_PSWD));
                cnt += 1;
                //   Toast(NotificationSeverity.Success, u2.Name + " created!");

            }
            return "cnt " + cnt;



        }
        //static string sKey = "22099478";
        //static string sIV = "35783280";
        static string sKey = RadzenDh5.Data.DhGlobalStatic.sKey;
        static string sIV = RadzenDh5.Data.DhGlobalStatic.sIV;


        public string GetPlainPass(string value)
        {
            return clsTool_2.DecryptDES(value, sKey, sIV);
        }
        protected void OnPassChange(string value, string name)
        {


            //      pass2 = clsTool_2.EncryptDES(value, sKey, sIV);
        }




        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (env.EnvironmentName == "Development" && userName == "superadmin" && password == "super@2021")
            {
                var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, "superadmin"),
                        new Claim(ClaimTypes.Email, "superadmin")
                };

                roleManager.Roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));
                await signInManager.SignInWithClaimsAsync(new ApplicationUser { UserName = userName, Email = userName }, isPersistent: false, claims);

                // ���Ҫ�� USER_LOG �����m requirements, 
                // �����Ȍ��F WebApp Login �rҪ��һ�P log
                // ���@�e���ò���, �Q���� login �ɹ����ȵ�  /LoginSuccess
                //
                //return Redirect("~/");
                return Redirect("/LoginSuccess");

            }

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                // NOTE by Mark, 04/25
                var cnt = await ButtonSubmitClick();

                var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

                if (result.Succeeded)
                {
                    // ���Ҫ�� USER_LOG �����m requirements, 
                    // �����Ȍ��F WebApp Login �rҪ��һ�P log
                    // ���@�e���ò���, �Q���� login �ɹ����ȵ�  /LoginSuccess
                    //
                    //return Redirect("~/");
                    return Redirect("/LoginSuccess");
                }
            }

            // NOTE by Mark, 04/27, �A�����΄��_��
            //if (password.Length < 8)
            //{
            //    return Redirect("~/Login?error=Password length must be at least 8 characters");

            //}
            return Redirect("~/Login?error=Invalid user or password");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Redirect("~/Login?error=Invalid user or password");
            }

            var user = new ApplicationUser { UserName = userName, Email = userName };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect("~/");
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect($"~/Login?error={message}");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == null || newPassword == null)
            {
                return Redirect($"~/Profile?error=Invalid old or new password");
            }

            var id = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);

                return Redirect("~/");
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect($"~/Profile?error={message}");
        }

        [HttpPost]
        [Authorize]
        // NOTE by Mark, 04/25, ֱ�Ӹĵ� USER_MST, ������ ASP.NET Identity
        public async Task<IActionResult> DhChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == null || newPassword == null)
            {

                //     return Redirect($"~/Profile?error=Invalid old or new password");
                return Redirect($"~/S080?error=Invalid old or new password");
            }
            return Redirect($"~/S080?error=doing...");

            //     var id = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //     var user = await userManager.FindByIdAsync(id);

            //     var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            //if (result.Succeeded)
            //{
            //    await signInManager.SignInAsync(user, isPersistent: true);

            //    return Redirect("~/");
            //}

            //       var message = string.Join(", ", result.Errors.Select(error => error.Description));

            // NOTE by Mark, 
            //      return Redirect($"~/Profile?error={message}");
            //     return Redirect($"~/S080?error={message}");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("~/");
        }
    }
}
