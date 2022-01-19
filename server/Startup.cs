using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RadzenDh5.Data;
using RadzenDh5.Models;
using RadzenDh5.Authentication;
using Radzen;
using CaotunSpring.DH.Tools;
using BlazorApp1.Data;
using CaotunSpring.Util;

namespace RadzenDh5
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        partial void OnConfigureServices(IServiceCollection services);

        partial void OnConfiguringServices(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            OnConfiguringServices(services);

            services.AddHttpContextAccessor();
            services.AddScoped<HttpClient>(serviceProvider =>
            {

                var uriHelper = serviceProvider.GetRequiredService<NavigationManager>();

                return new HttpClient
                {
                    BaseAddress = new Uri(uriHelper.BaseUri)
                };
            });

            services.AddHttpClient();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Mark10Sqlexpress04Connection"));
            }, ServiceLifetime.Transient);

            services.AddIdentity<ApplicationUser, IdentityRole>(
                options=>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 8;
                //    options.Password..RequiredLength = 6;

                    //   options.Password.RequiredUniqueChars = 1;
                })

                  .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                  ApplicationPrincipalFactory>();
            services.AddScoped<SecurityService>();
            services.AddScoped<Mark10Sqlexpress04Service>();

            services.AddDbContext<RadzenDh5.Data.Mark10Sqlexpress04Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Mark10Sqlexpress04Connection"));
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor().AddHubOptions(o =>
            {
                o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
            });

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<GlobalsService>();

            // NOTE by Mark, 仿 WES Globals
            // 由於在 Radzen 框架裡已有 上述的 GlobalsService
            // 因此加上前綴 Dh
            // P090 如果在同一個 Scoped 
            // 測試 29997-29998-00001 
            //  UPDATE SNO_CTL
            //  SET SNO = 29997
            //  WHERE SNO_TYPE = 'CmdSno'
            //  services.AddScoped<DhGlobalsService>();
            //  EF Core 不知道數據庫被改過
            //UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
            //services.AddTransient<DhGlobalsService>();
            services.AddScoped<DhGlobalsService>();

            // NOTE by Mark, 04/19
            services.AddScoped<DhReportService>();

            // NOTE by Mark, 04/20 for PDA 800X480
            services.AddScoped<BrowserService>(); // scoped service

            // from App1 project for doc, 是不是之前用singleton所以換了json 都需要重起?
            services.AddScoped<PageService>();

            services.AddLocalization();

            var supportedCultures = new[]
            {
                new System.Globalization.CultureInfo("zh-CHS"),
                new System.Globalization.CultureInfo("zh-CHT"),
                new System.Globalization.CultureInfo("en-US"),
                new System.Globalization.CultureInfo("th-TH"),
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });




            OnConfigureServices(services);
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationIdentityDbContext identityDbContext)
        {


            OnConfiguring(app, env);

       

            var supportedCultures = new[]
            {
                new System.Globalization.CultureInfo("zh-CHS"),
                new System.Globalization.CultureInfo("zh-CHT"),
                new System.Globalization.CultureInfo("en-US"),
                new System.Globalization.CultureInfo("th-TH"),
            };

            // 多語 Note by Mark, 06/15, 
            // NOTE by Mark, 想要停掉系統的 Culture, 只要其值, 不要真的轉到相對的 Culture, 因為 th-TH 有年的問題
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    return next();
                });
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            identityDbContext.Database.Migrate();

            OnConfigure(app, env);
        }
    }


}
