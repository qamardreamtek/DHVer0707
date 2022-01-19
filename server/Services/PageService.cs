using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
namespace BlazorApp1.Data
{

    // NOTE by Mark, 2021-04-23
    // 這是自主開發的服務
    // 頁面上, 有重覆需求的, 要優先整理到這裡
    public class PageService
    {
        private IWebHostEnvironment _WebHostEnvironment;
        private string wwwroot;
        private string jsonString;
        private string jsonString2; // for login version reminder

        private List<IdName> pageList;
        private List<IdName> pageList2;
        private List<IdName> todoSList;
        private List<IdName> DhAppStatusResult;
        private List<IdName> DhAppStatusResult_ByDev;// NOTE by Mark, 05/03, for developer only



        private string connStr;

        private readonly IConfiguration _config;


        // NOTE by Mark, 04/24
        // 每頁基本都是放在 TAB, 如果不在用戶可以訪問的菜單裡, 要有統一的判斷和提示

        public bool IsOnUserMenu(string USER_ID, string PROG_ID)
        {
            var cnt = AppDb.VRights.Where(a => a.user_id == USER_ID && a.PROG_ID == PROG_ID).Count();
            if (cnt >= 1)
                return true;


            return false;
        }

        //System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: BlazorApp1.Data.PageService Lifetime: Singleton ImplementationType: BlazorApp1.Data.PageService': Cannot consume scoped service 'Blazored.LocalStorage.ILocalStorageService' from singleton 'BlazorApp1.Data.PageService'.)'
        //private Blazored.LocalStorage.ILocalStorageService localStorage;
        private RadzenDh5.Data.Mark10Sqlexpress04Context AppDb;

        //[Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        public PageService(IWebHostEnvironment WebEnvironment, IConfiguration iconfig, RadzenDh5.Data.Mark10Sqlexpress04Context AppDb)
        {
            _WebHostEnvironment = WebEnvironment;
            this._config = iconfig;
          //  this.localStorage = localStorage;
           
            wwwroot = _WebHostEnvironment.WebRootPath;
            this.AppDb = AppDb;


            var file = wwwroot + "/json/pagesList.json";

             jsonString = File.ReadAllText(file);
            pageList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdName>>(jsonString);

            var file2 = wwwroot + "/json/LoginVersionReminder.json";
            jsonString2 = File.ReadAllText(file2);
             pageList2 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdName>>(jsonString2);

            var fileTodoS = wwwroot + "/json/TodoS.json";
            todoSList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdName>>(File.ReadAllText(fileTodoS));

            var strDhAppStatus = wwwroot + "/json/DhAppStatus.json";
            DhAppStatusResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdName>>(File.ReadAllText(strDhAppStatus));


            var strDhAppStatus_ByDev = wwwroot + "/json/DhAppStatus_ByDev.json";
            DhAppStatusResult_ByDev = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdName>>(File.ReadAllText(strDhAppStatus_ByDev));


            connStr = _config.GetConnectionString("Mark10Sqlexpress04Connection");

        }


   //     public Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

     

        //public string  GetDH_USER_IDXXX()
        //{
        //    var localUser = await localStorage.GetItemAsync<string>("DH_USER_ID");
        //    return localUser;
        //}

        public string GetConnectionString()
        {
            var temp = connStr.Split(";");
          
            return temp[0];
        }
        public (string, string) GetLoginVersionReminder()
        {
            if (pageList2.Count >= 1)
            {
                return (pageList2[0].Id, pageList2[0].Name);
            }
            return ("版本不詳", "請在 /json/LoginVersionReminder.json 設置最少一筆");

        }

        public List<IdName> GetTodoS()
        {
          
            return todoSList;

        }

        public string GetLoginVersionReminderVer()
        {
            if (pageList2.Count >= 1)
            {
                return pageList2[0].Id;
            }
            return "版本不詳";

        }

       // List<IdName> DhAppStatusList;
        public IEnumerable<IdName> GetDhAppStatus(string PROD_ID)
        {

            var status = DhAppStatusResult.Where(a => a.Id == PROD_ID).OrderByDescending(a => a.Name);
            return status;

        }
        public string GetDhAppStatusLatest(string PROD_ID)
        {

            var latest = DhAppStatusResult.Where(a => a.Id == PROD_ID).OrderByDescending(a => a.Name).FirstOrDefault();
            if (latest != null)
            {
                return latest.Name;
            }
            return "(沒有review)";

        }
        public string GetDhAppStatusLatest_ByDev(string PROD_ID)
        {

            var latest = DhAppStatusResult_ByDev.Where(a => a.Id == PROD_ID).OrderByDescending(a => a.Name).FirstOrDefault();
            if (latest != null)
            {
                return latest.Name;
            }
            return "(沒有review)";

        }

        public IEnumerable<IdName> GetDhAppStatus()
        {

            var status = DhAppStatusResult;
            return status;

        }


        public string GetLoginVersionReminderVer(int rec)
        {
            if (pageList2.Count >= 1)
            {
                return pageList2[rec].Id;
            }
            return "版本不詳";

        }

        public string GetLoginVersionReminderDescription()
        {
            if (pageList2.Count >= 1)
            {
                return pageList2[0].Name;
            }
            return "請在 /json/LoginVersionReminder.json 設置最少一筆";

        }

        public string GetLoginVersionReminderDescription(int rec)
        {
            if (pageList2.Count >= 1)
            {
                return pageList2[rec].Name;
            }
            return "請在 /json/LoginVersionReminder.json 設置最少一筆";

        }



        public string GetPageTitle(string id)
        {
            string result = id;
            var pageList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdName>>(jsonString);
            var x2 = pageList.Where(o => o.Id == id).FirstOrDefault();
            if (x2 != null)
            {
                result = x2.Name;
            }
            return result;
        }


        public List<IdName> GetPageList(string cat)
        {
            return pageList.Where(o => o.Id.StartsWith(cat)).OrderBy(o => o.Id).ToList();
          
        }
        public List<IdName> GetPageList()
        {
            return  pageList.OrderBy(o => o.Id).ToList();
        
        }


        public IEnumerable<IdName> GetEntireList()
        {
            return pageList;
        }
       

       

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
