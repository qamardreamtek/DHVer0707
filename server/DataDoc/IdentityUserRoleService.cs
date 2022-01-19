using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class IdentityUserRoleService
    {
        private ApplicationDbContext Db;
        public IdentityUserRoleService(ApplicationDbContext _ApplicationDbContext)
        {
            Db = _ApplicationDbContext;
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




        public Task<int> AddUserRole(string UserId, string RoleId)
        {
            int cnt = 0;

            string strSQL = String.Format(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId] ,[RoleId]) VALUES('{0}','{1}')", UserId, RoleId);
            cnt = Db.Database.ExecuteSqlRaw(strSQL);

            return Task.FromResult(cnt);
        }

        public Task<int> DeleteUserRole(string UserId, string RoleId)
        {
            int cnt = 0;

            string strSQL = String.Format(@"DELETE FROM [dbo].[AspNetUserRoles] WHERE [UserId] = '{0}' AND [RoleId] = '{1}'", UserId, RoleId);
            cnt = Db.Database.ExecuteSqlRaw(strSQL);

            return Task.FromResult(cnt);
        }

    }
}
