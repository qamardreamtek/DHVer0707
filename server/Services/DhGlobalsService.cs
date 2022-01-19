using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;
using RadzenDh5.Models.Mark10Sqlexpress04;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaotunSpring.DH.Tools
{


    // 提供像 WES Globals 的功能



    //    using(YourDbEntities db = new YourDbEntities()) 
    //{
    //  bool IsExists = db.Database
    //   .SqlQuery<int?>(@"
    //    SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
    //    WHERE TABLE_NAME = '" + yourTableName + "'
    //    ")
    //    .FirstOrDefault() > 0;

    //    return IsExists;
    //}


    //https://docs.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations
    //db.Database.ExecuteSqlRaw(
    //@"CREATE VIEW View_BlogPostCounts AS
    //    SELECT b.Name, Count(p.PostId) as PostCount
    //    FROM Blogs b
    //    JOIN Posts p on p.BlogId = b.BlogId
    //    GROUP BY b.Name");
    public class UserInfo
    {
        public static string USER_ID;
        public static string USER_NAME;
        public static string USER_DEPT;

    }

    public partial class DhGlobalsService
    {

        /// <summary>
        /// UI 上綁定的值,在 SQL 使用之前, 將 null 轉成 "", 同時做 Trim
        /// </summary>
        /// <param name="refArgument"></param>
        public void PurifyFilterValue(ref string refArgument)
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref

            refArgument = refArgument != null ? refArgument.Trim() : "";


        }

        public void ResetValue(ref string refArgument)
        {
            refArgument = "";


        }

        //[Inject] IWebHostEnvironment WebEnvironment { get; set; }
        public static void Log(string logMessage, TextWriter w)
        {
            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            w.WriteLine($"{dt}");
            w.WriteLine($"{logMessage}");
        }

        public void LogProg(string PROG_ID, string msg)
        {
            string wwwroot = env.WebRootPath;
            string d = GetLogDate();
            string f1 = wwwroot + $@"/logs/{PROG_ID}_{d}.log";
            //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file

            using (StreamWriter w = File.AppendText(f1))
            {
                Log(msg, w);

            }
        }

        class UserInfo
        {
            public static string USER_ID;
            public static string DEPT_NAME;
            public static string USER_NAME;

        }


        public async Task LogProgAsync(string PROG_ID, string msg)
        {
            string wwwroot = env.WebRootPath;
            string d = GetLogDate();
            string f1 = wwwroot + $@"/logs/LOG_{PROG_ID}_{d}.log";
            //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file

            using StreamWriter w = File.AppendText(f1);
            //  Log(msg, w);
            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            await w.WriteLineAsync($"{dt} {PROG_ID}");
            await w.WriteLineAsync($"{msg}");


        }
        public async Task LogPageVisitAsync(string PROG_ID, string msg)
        {
            string wwwroot = env.WebRootPath;
            string d = GetLogDate();

            //  string f1 = wwwroot + $@"/logs/LOG_{PROG_ID}_{d}.log"; // NOT able to visit thru http
            string f1 = wwwroot + $@"/logs/log{d}.txt"; // Encoding is not as good as json, English only

            //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file

            using StreamWriter w = File.AppendText(f1);
            //  Log(msg, w);
            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            await w.WriteLineAsync($"{dt} {msg}");



        }

        public async Task LogPageExceptionAsync(string PROG_ID, string msg)
        {
            string wwwroot = env.WebRootPath;
            string d = GetLogDate();

            //  string f1 = wwwroot + $@"/logs/LOG_{PROG_ID}_{d}.log"; // NOT able to visit thru http
            string f1 = wwwroot + $@"/logs/logException{d}.txt"; // Encoding is not as good as json, English only

            //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file

            using StreamWriter w = File.AppendText(f1);
            //  Log(msg, w);
            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            w.WriteLine($"{dt} {msg}");



        }

        public void LogP020(string msg)
        {
            string wwwroot = env.WebRootPath;
            string d = GetLogDate();
            string f1 = wwwroot + $@"/logs/p020_{d}.log";
            //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file

            using (StreamWriter w = File.AppendText(f1))
            {
                Log(msg, w);

            }
        }
        public string GetDhTRN_DATE()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public string GetLogDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        // Culture Note by Mark, 05/19
        // 
        // 發現 LOG_PageVisit_2564-05-19.log
        // 強制不被 TH 的年影響
        public string GetLogDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
        public string GetDhUsername(string USER_ID)
        {
            var obj = context.UserMsts.Where(a => a.USER_ID == USER_ID).FirstOrDefault();
            if (obj != null)
            {
                return obj.USER_NAME;
            }
            return "";
        }

        public async Task<string> GetDhUsernameAsync(string USER_ID)
        {
            var obj = await context.UserMsts.Where(a => a.USER_ID == USER_ID).AsNoTracking().FirstOrDefaultAsync();
            if (obj != null)
            {
                return obj.USER_NAME;
            }
            return "";
        }

        public async Task<string> GetDhDeptNameAsync(string USER_ID)
        {
            var obj = await context.UserMsts.Where(a => a.USER_ID == USER_ID).AsNoTracking().FirstOrDefaultAsync();
            if (obj != null)
            {
                return obj.DEPT_NAME;
            }
            return "";
        }
        public async Task<string> GetDhNameEnableAsync(string USER_ID)
        {
            var obj = await context.UserMsts.Where(a => a.USER_ID == USER_ID).AsNoTracking().FirstOrDefaultAsync();
            if (obj != null)
            {
                // NOTE: 按照 方sir 口述, 除了N, 其餘視為 Y
                if (obj.ENABLE == "N")
                {
                    return "N";
                }
                else
                {
                    return "Y";
                }
               
            }
            return "N";
        }

        public async Task<UserMst> GetDhUserByIdAsync(string USER_ID)
        {
            var obj = await context.UserMsts.Where(a => a.USER_ID == USER_ID).AsNoTracking().FirstOrDefaultAsync();
            return obj;
            //if (obj != null)
            //{
            //    return obj.USER_NAME;
            //}
            //return "";
        }


        public string GetC030Grid1SQL()
        {
            string strSQL = $@"
            select distinct a.*
from PIC_MST a
join PIC_DTL b
on (a.PIC_NO = b.PIC_NO)
where a.PIC_STS
in ('0', '1', '2', '3') and a.PIC_TYPE != '01'
        
";
            return strSQL;
        }

        // NOTE by Mark, 04/29
        public string GetR070StrSQL(string strFrom, string strTo)
        {
            //var strFrom = dateFrom.ToString("yyyy-MM-dd");
            //var strTo = dateTo.ToString("yyyy-MM-dd");
            string strSQL = $@"
        select SKU_NO, SKU_DESC, sum(OUT_COUNT) as Outbound,sum(IN_COUNT) as Inbound,sum(TX_COUNT) as Relocation,sum(OUT_COUNT + IN_COUNT + TX_COUNT) as Total

  from
  (

  select a.SKU_NO, b.SKU_DESC,0 as OUT_COUNT, count(*) as IN_COUNT,0 as TX_COUNT from IN_SNO a
                            join SKU_MST b on (a.SKU_NO= b.SKU_NO)
                             where a.SKU_FIN_QTY>0 and a.TRN_DATE>'{strFrom}' and a.TRN_DATE< '{strTo}' 
                             group by a.SKU_NO, b.SKU_DESC
                             UNION ALL
                            select a.SKU_NO, b.SKU_DESC, count(*) as OUT_COUNT,0 as IN_COUNT,0 as TX_COUNT from PCK_SNO a
                            join SKU_MST b on(a.SKU_NO= b.SKU_NO)
                             where a.SKU_FIN_QTY>0 and a.TRN_DATE>'{strFrom}' and a.TRN_DATE< '{strTo}' 
                             group by a.SKU_NO, b.SKU_DESC
                             UNION ALL
                             select a.SKU_NO, b.SKU_DESC,0 as OUT_COUNT,0 as IN_COUNT, count(*) as TX_COUNT from TX_LOG a
                            join SKU_MST b on(a.SKU_NO= b.SKU_NO)
                             where a.TX_DATE>'{strFrom}' and a.TX_DATE< '{strTo}' 
                             group by a.SKU_NO, b.SKU_DESC

) T1
group by  SKU_DESC, SKU_NO



";
            return strSQL;

        }







        // NOTE by Mark, 04/29
        public string GetR060StrSQL(string strFrom, string strTo)
        {
            //var strFrom = dateFrom.ToString("yyyy-MM-dd");
            //var strTo = dateTo.ToString("yyyy-MM-dd");
            string strSQL = $@"
            select SKU_NO, SKU_DESC, sum(OUT_COUNT) as Outbound,sum(IN_COUNT) as Inbound,sum(TX_COUNT) as Relocation,sum(OUT_COUNT + IN_COUNT + TX_COUNT) as Total

  from
  (

  select a.SKU_NO, b.SKU_DESC, 0 as OUT_COUNT, count(distinct a.SU_ID) as IN_COUNT, 0 as TX_COUNT from IN_SNO a
                            join SKU_MST b on (a.SKU_NO = b.SKU_NO)
                             where a.SKU_FIN_QTY > 0 and a.TRN_DATE > '{strFrom}' and a.TRN_DATE < '{strTo}'
                             group by a.SKU_NO, b.SKU_DESC


                              UNION ALL
                            select a.SKU_NO, b.SKU_DESC, count(distinct a.SU_ID) as OUT_COUNT, 0 as IN_COUNT, 0 as TX_COUNT from PCK_SNO a
                            join SKU_MST b on (a.SKU_NO = b.SKU_NO)
                             where a.SKU_FIN_QTY > 0 and a.TRN_DATE > '{strFrom}' and a.TRN_DATE < '{strTo}'
                             group by a.SKU_NO, b.SKU_DESC


                              UNION ALL
                             select a.SKU_NO, b.SKU_DESC, 0 as OUT_COUNT, 0 as IN_COUNT, count(distinct TX_NO) as TX_COUNT from TX_LOG a
                            join SKU_MST b on (a.SKU_NO = b.SKU_NO)
                             where a.TX_DATE > '{strFrom}' and a.TX_DATE < '{strTo}'
                             group by a.SKU_NO, b.SKU_DESC

) T1
group by SKU_NO, SKU_DESC



";
            return strSQL;

        }



        private readonly IWebHostEnvironment env;
        public bool IsSPExists(string name)
        {
            var strSQL = $@"
       select COUNT(*) Cnt from sys.objects where type = 'p' and name ='{name}'";

            var cntObj = Db.CntResult.FromSqlRaw(strSQL).FirstOrDefault();
            if (cntObj != null && cntObj.Cnt == 1)
                return true;
            return false;
        }

        public int MLASRS_UpdateTable(string conn, string sSQL)
        {
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;
            int iResult = 0;
            try
            {
                // 测试数据库连接是否成功
                dbConnection = WMSDB.funCreateConnection();
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Database connection failed");

                iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;
            }
            return iResult;
        }




        //https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/delete-a-stored-procedure?view=sql-server-ver15
        //DROP PROCEDURE<stored procedure name>;
        public async Task<string> UpdateSP(string name)
        {
            var sb = new StringBuilder();
            if (IsSPExists(name))
            {
                try
                {
                    var strSQL = $@"DROP PROCEDURE {name}";
                    //sb.Append(getLogLine("準備執行 " + strSQL));
                    await Db.Database.ExecuteSqlRawAsync(strSQL);
                    //sb.Append(getLogLine("執行成功 " + strSQL));
                    sb.Append(getLogLine("done,   " + strSQL));


                }
                catch (Exception ex)
                {
                    sb.Append(getLogLine("要刪掉SP失敗?"));
                    sb.Append(getLogLine(ex.ToString()));

                }
            }

            // to create, 避免SQL版本或補丁問題
            try
            {
                var strSQL = await GetSQLAsync(name);
                //sb.Append(getLogLine("準備執行 " + strSQL));
                await Db.Database.ExecuteSqlRawAsync(strSQL);
                //sb.Append(getLogLine($@"新建 SP {name} 成功"));
                sb.Append(getLogLine($@"done, CREATE PROCEDURE {name} "));


            }
            catch (Exception ex)
            {
                sb.Append(getLogLine($@"新建 SP  {name} 失敗"));
                sb.Append(getLogLine(ex.ToString()));

            }

            return sb.ToString();
        }


        public async Task<string> UpdateView(string name)
        {
            var sb = new StringBuilder();
            if (await IsTableExistsAsync(name))
            {
                try
                {
                    var strSQL = $@"DROP VIEW {name}";
                    //sb.Append(getLogLine("準備執行 " + strSQL));
                    await Db.Database.ExecuteSqlRawAsync(strSQL);
                    //sb.Append(getLogLine("執行成功 " + strSQL));
                    sb.Append(getLogLine("done,   " + strSQL));


                }
                catch (Exception ex)
                {
                    sb.Append(getLogLine("要刪掉 VIEW 失敗?"));
                    sb.Append(getLogLine(ex.ToString()));

                }
            }

            // to create VIEW, 避免SQL版本或補丁問題
            try
            {
                var strSQL = await GetSQLAsync(name);
                //sb.Append(getLogLine("準備執行 " + strSQL));
                await Db.Database.ExecuteSqlRawAsync(strSQL);
                //sb.Append(getLogLine($@"新建 VIEW {name} 成功"));
                sb.Append(getLogLine($@"done, CREATE VIEW {name} "));


            }
            catch (Exception ex)
            {
                sb.Append(getLogLine($@"新建 VIEW  {name} 失敗"));
                sb.Append(getLogLine(ex.ToString()));

            }

            return sb.ToString();
        }

        public async Task<string> CheckSP(string name)
        {
            var sb = new StringBuilder();
            if (IsSPExists(name))
            {
                try
                {
                    //https://stackoverflow.com/questions/4765323/is-there-a-way-to-retrieve-the-view-definition-from-a-sql-server-using-plain-ado/4765478JECT_ID('V_C010');
                    // NOTE by Mark, 透過 Raw 運行的, 最後的;不能有, bad=> WHERE object_id = OBJECT_ID('{name}');
                    var strSQL = $@"
                    SELECT '{name}' AS id, definition name
                    FROM sys.sql_modules
                    WHERE object_id = OBJECT_ID('{name}')
                    ";

                    var obj = Db.IdNames.FromSqlRaw(strSQL).FirstOrDefault();
                    if (obj == null)
                    {
                        sb.Append(getLogLine($@"{name} 不存在 ---不應該入到這裡 "));
                    }
                    else
                    {
                        sb.Append(getLogLine($@"Stored Procedure【{obj.Id}】存在, 定義如後:"));
                        sb.Append(getLogLine($@"{obj.Name}"));
                    }
                }
                catch (Exception ex)
                {
                    sb.Append(getLogLine("CheckSP failed???"));
                    sb.Append(getLogLine(ex.ToString()));
                }
            }
            else
            {
                sb.Append(getLogLine($@"Stored Procedure【{name}】不存在 "));
            }
            return sb.ToString();
        }



        //private async Task<string> CheckViewAndSp()
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(await DhGlobals.CheckView("V_C010"));
        //    sb.Append(await DhGlobals.CheckView("V_LOC_DTL_MST"));
        //    sb.Append(await DhGlobals.CheckView("V_LOC_DTL_MST__PLT_DTL"));
        //    sb.Append(await DhGlobals.CheckView("V_LOC_DTL_MST__PLT_DTl__IN_DTL"));
        //    sb.Append(await DhGlobals.CheckView("V_P020_LocDtl"));
        //    sb.Append(await DhGlobals.CheckView("V_P020_MergeOutDtl"));
        //    sb.Append(await DhGlobals.CheckView("V_P020A"));
        //    sb.Append(await DhGlobals.CheckView("V_P020B"));
        //    sb.Append(await DhGlobals.CheckView("V_P030"));
        //    sb.Append(await DhGlobals.CheckView("V_P030SUB"));
        //    sb.Append(await DhGlobals.CheckView("V_P060"));
        //    sb.Append(await DhGlobals.CheckView("V_P070"));
        //    sb.Append(await DhGlobals.CheckView("V_P080"));
        //    sb.Append(await DhGlobals.CheckView("V_P100"));

        //    sb.Append(await DhGlobals.CheckView("V_R030"));
        //    sb.Append(await DhGlobals.CheckView("V_R040"));
        //    sb.Append(await DhGlobals.CheckView("V_R050"));
        //    sb.Append(await DhGlobals.CheckView("V_R060"));
        //    sb.Append(await DhGlobals.CheckView("V_R070"));
        //    sb.Append(await DhGlobals.CheckView("V_R080"));
        //    sb.Append(await DhGlobals.CheckView("V_RIGHT"));
        //    sb.Append(await DhGlobals.CheckView("v_table_list"));
        //    sb.Append(await DhGlobals.CheckView("V_TRANSLATE"));
        //    sb.Append(await DhGlobals.CheckView("V_USER_PROG_BY_GROUP"));
        //    sb.Append(await DhGlobals.CheckView("v_user_role"));
        //    sb.Append(await DhGlobals.CheckView("V_XXXP故意不存在"));

        //    sb.Append(await DhGlobals.CheckSP("SP_C030"));
        //    sb.Append(await DhGlobals.CheckSP("SP_R040"));
        //    sb.Append(await DhGlobals.CheckSP("SP_R050"));
        //    sb.Append(await DhGlobals.CheckSP("SP_R060"));
        //    sb.Append(await DhGlobals.CheckSP("SP_R070"));
        //    sb.Append(await DhGlobals.CheckSP("SP_XXX故意不存在"));

        //    return sb.ToString();
        //}
        public async Task<string> CheckIfViewsAndProceduresExist()
        {
            // Tools Note by Mark, 05/26,  以下這兩組是用工具獲得
            string[] views = { "P030", "V_C010", "V_LOC_DTL_MST", "V_LOC_DTL_MST__PLT_DTL", "V_LOC_DTL_MST__PLT_DTL__IN_DTL", "V_P020_LocDtl", "V_P020_MergeOutDtl", "V_P020A", "V_P020B", "V_P030", "V_P030SUB", "V_P060", "V_P070", "V_P080", "V_P100", "V_R030", "V_R040", "V_R050", "V_R060", "V_R070", "V_R080", "V_RIGHT", "v_table_list", "V_TRANSLATE", "V_USER_PROG_BY_GROUP", "v_user_role" };
            string[] sps = { "SP_C030", "SP_R040", "SP_R050", "SP_R060", "SP_R070" };


            var sb = new StringBuilder();
            //    sb.Append(await DhGlobals.CheckView("V_C010"));
            foreach (var x in views)
            {
                sb.Append(await CheckView(x));
            }
            foreach (var x in sps)
            {
                sb.Append(await CheckSP(x));
            }
            return sb.ToString();

        }

        //private async Task<string> InitViewAndSp()
        //{
        //    var sb = new StringBuilder();

        //    sb.Append(await DhGlobals.UpdateView("V_C010"));

        //    sb.Append(await DhGlobals.UpdateView("V_LOC_DTL_MST"));

        public async Task<string> InitViewsAndProcedures()
        {
            // Tools Note by Mark, 05/26,  以下這兩組是用工具獲得
            string[] views = { "P030", "V_C010", "V_LOC_DTL_MST", "V_LOC_DTL_MST__PLT_DTL", "V_LOC_DTL_MST__PLT_DTL__IN_DTL", "V_P020_LocDtl", "V_P020_MergeOutDtl", "V_P020A", "V_P020B", "V_P030", "V_P030SUB", "V_P060", "V_P070", "V_P080", "V_P100", "V_R030", "V_R040", "V_R050", "V_R060", "V_R070", "V_R080", "V_RIGHT", "v_table_list", "V_TRANSLATE", "V_USER_PROG_BY_GROUP", "v_user_role" };
            string[] sps = { "SP_C030", "SP_R040", "SP_R050", "SP_R060", "SP_R070" };


            var sb = new StringBuilder();
            //    sb.Append(await DhGlobals.CheckView("V_C010"));
            foreach (var x in views)
            {
                sb.Append(await UpdateView(x));
            }
            foreach (var x in sps)
            {
                sb.Append(await UpdateSP(x));
            }
            return sb.ToString();

        }


        public async Task<string> CheckView(string name)
        {
            var sb = new StringBuilder();
            if (await IsTableExistsAsync(name)) // 在 SQL 的環境裡, View 在某些程度是視同為 Table
            {
                try
                {
                    //https://stackoverflow.com/questions/4765323/is-there-a-way-to-retrieve-the-view-definition-from-a-sql-server-using-plain-ado/4765478JECT_ID('V_C010');
                    // NOTE by Mark, 透過 Raw 運行的, 最後的;不能有, bad=> WHERE object_id = OBJECT_ID('{name}');
                    var strSQL = $@"
                    SELECT '{name}' AS id, definition name
                    FROM sys.sql_modules
                    WHERE object_id = OBJECT_ID('{name}')
                    ";

                    var obj = Db.IdNames.FromSqlRaw(strSQL).FirstOrDefault();
                    if (obj == null)
                    {
                        sb.Append(getLogLine($@"{name} 不存在 ---不應該入到這裡 "));
                    }
                    else
                    {
                        sb.Append(getLogLine($@"View 【{obj.Id}】 存在, 定義如後:"));
                        sb.Append(getLogLine($@"{obj.Name}"));
                    }
                }
                catch (Exception ex)
                {
                    sb.Append(getLogLine("CheckSP failed???"));
                    sb.Append(getLogLine(ex.ToString()));
                }
            }
            else
            {
                sb.Append(getLogLine($@"View【{name}】 不存在 "));
            }
            return sb.ToString();
        }



        public string GetLogsPath()
        {
            var wwwroot = env.WebRootPath;
            //string curFile = @"c:\temp\test.txt";
            //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            string LogPath = $@"{wwwroot}/logs";
            if (!Directory.Exists(LogPath))
            {
                // 由於 gitignore 了 **/logs, 任何 logs 的 directory 都不會上傳
                // 需要直接在 客戶的環境新建

                DirectoryInfo di = Directory.CreateDirectory(LogPath);

            }
            return LogPath;
        }


        /// <summary>
        /// 在原由 login 觸發升級後更新  View SP 的基礎上, 加做到 M2
        /// </summary>
        /// <returns></returns>
        public string GetLogMenuName()
        {
            return @$"{GetLogsPath()}/logM2.txt";
        }

        /// <summary>
        /// 目前只檢查是否有該 View, 可以拓展成是否和某個 View definition 一樣
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfViewExistAsync(string name)

        {
            if (await IsTableExistsAsync(name)) // 在 SQL 的環境裡, View 在某些程度是視同為 Table
                return true;
            return false;
        }

        public async Task MakeSureSPExists(string name)
        {
            if (!IsSPExists(name))
            {
                string strSQL = GetSQL(name);
                //   var todo = "to create view";
                try
                {
                    Db.Database.ExecuteSqlRaw(GetSQL(name));

                }
                catch (Exception ex)
                {

                    var wwwroot = env.WebRootPath;
                    var f1 = wwwroot + @$"/err_screate_sp_{name}.txt";
                    //  await WriteThrow(f1, message);
                    await File.WriteAllTextAsync(f1, "Db.Database.ExecuteSqlRaw failed \n\n" + GetSQL(name) + "\n\n" + ex.ToString());
                    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
                }

            }
        }


        public string GetSQLContains(string field, ref string txt)
        {
            PurifyFilterValue(ref txt);

            var strSQL = "";

            if (txt != "") strSQL = @$" and {field} like '%{txt.ToUpper()}%'";


            return strSQL;
        }


        public string GetSQL(string name)
        {

            if (name == "V_C010")
            {
                return DhGlobalStatic.V_C010;
            }
            if (name == "V_P060")
            {
                return DhGlobalStatic.V_P060;
            }
            if (name == "V_P070")
            {
                return DhGlobalStatic.V_P070;
            }
            if (name == "V_R030")
            {
                return DhGlobalStatic.V_R030;
            }
            if (name == "V_R040")
            {
                return DhGlobalStatic.V_R040;
            }
            if (name == "V_R050")
            {
                return DhGlobalStatic.V_R050;
            }
            if (name == "V_R060")
            {
                return DhGlobalStatic.V_R060;
            }
            if (name == "V_R070")
            {
                return DhGlobalStatic.V_R070;
            }
            if (name == "V_R080")
            {
                return DhGlobalStatic.V_R080;
            }
            if (name == "V_RIGHT")
            {
                return DhGlobalStatic.V_RIGHT;
            }
            if (name == "v_table_list")
            {
                return DhGlobalStatic.v_table_list;
            }
            if (name == "V_USER_PROG_BY_GROUP")
            {
                return DhGlobalStatic.V_USER_PROG_BY_GROUP;
            }
            if (name == "v_user_role")
            {
                return DhGlobalStatic.v_user_role;
            }
            if (name == "V_P020_LocDtl")
            {
                return DhGlobalStatic.V_P020_LocDtl;
            }
            if (name == "V_P020_MergeOutDtl")
            {
                return DhGlobalStatic.V_P020_MergeOutDtl;
            }
            if (name == "V_P020A")
            {
                return DhGlobalStatic.V_P020A;
            }
            if (name == "V_P020B")
            {
                return DhGlobalStatic.V_P020B;
            }
            if (name == "V_P030")
            {
                return DhGlobalStatic.V_P030;
            }
            if (name == "V_P030SUB")
            {
                return DhGlobalStatic.V_P030SUB;
            }
            if (name == "V_P080")
            {
                return DhGlobalStatic.V_P080;
            }
            if (name == "V_P100")
            {
                return DhGlobalStatic.V_P100;
            }
            if (name == "V_TRANSLATE")
            {
                return DhGlobalStatic.V_TRANSLATE;
            }
            if (name == "SP_C030")
            {
                return DhGlobalStatic.SP_C030;
            }
            if (name == "SP_R040")
            {
                return DhGlobalStatic.SP_R040;
            }
            if (name == "SP_R050")
            {
                return DhGlobalStatic.SP_R050;
            }
            if (name == "SP_R060")
            {
                return DhGlobalStatic.SP_R060;
            }
            if (name == "SP_R070")
            {
                return DhGlobalStatic.SP_R070;
            }
            return "";
        }

        public async Task<string> GetSQLAsync(string name)
        {

            if (name == "V_LOC_DTL_MST")
            {
                return DhGlobalStatic.V_LOC_DTL_MST;
            }
            if (name == "V_LOC_DTL_MST__PLT_DTL")
            {
                return DhGlobalStatic.V_LOC_DTL_MST__PLT_DTL;
            }
            if (name == "V_LOC_DTL_MST__PLT_DTl__IN_DTL")
            {
                return DhGlobalStatic.V_LOC_DTL_MST__PLT_DTl__IN_DTL;
            }
            if (name == "V_C010")
            {
                return DhGlobalStatic.V_C010;
            }
            if (name == "V_P060")
            {
                return DhGlobalStatic.V_P060;
            }
            if (name == "V_P070")
            {
                return DhGlobalStatic.V_P070;
            }
            if (name == "V_R030")
            {
                return DhGlobalStatic.V_R030;
            }
            if (name == "V_R040")
            {
                return DhGlobalStatic.V_R040;
            }
            if (name == "V_R050")
            {
                return DhGlobalStatic.V_R050;
            }
            if (name == "V_R060")
            {
                return DhGlobalStatic.V_R060;
            }
            if (name == "V_R070")
            {
                return DhGlobalStatic.V_R070;
            }
            if (name == "V_R080")
            {
                return DhGlobalStatic.V_R080;
            }
            if (name == "V_RIGHT")
            {
                return DhGlobalStatic.V_RIGHT;
            }
            if (name == "v_table_list")
            {
                return DhGlobalStatic.v_table_list;
            }
            if (name == "V_USER_PROG_BY_GROUP")
            {
                return DhGlobalStatic.V_USER_PROG_BY_GROUP;
            }
            if (name == "v_user_role")
            {
                return DhGlobalStatic.v_user_role;
            }
            if (name == "V_P020_LocDtl")
            {
                return DhGlobalStatic.V_P020_LocDtl;
            }
            if (name == "V_P020_MergeOutDtl")
            {
                return DhGlobalStatic.V_P020_MergeOutDtl;
            }
            if (name == "V_P020A")
            {
                return DhGlobalStatic.V_P020A;
            }
            if (name == "V_P020B")
            {
                return DhGlobalStatic.V_P020B;
            }
            if (name == "V_P030")
            {
                return DhGlobalStatic.V_P030;
            }
            if (name == "V_P030SUB")
            {
                return DhGlobalStatic.V_P030SUB;
            }
            if (name == "V_P080")
            {
                return DhGlobalStatic.V_P080;
            }
            if (name == "V_P100")
            {
                return DhGlobalStatic.V_P100;
            }
            if (name == "V_TRANSLATE")
            {
                return DhGlobalStatic.V_TRANSLATE;
            }
            if (name == "SP_C030")
            {
                return DhGlobalStatic.SP_C030;
            }
            if (name == "SP_R040")
            {
                return DhGlobalStatic.SP_R040;
            }
            if (name == "SP_R050")
            {
                return DhGlobalStatic.SP_R050;
            }
            if (name == "SP_R060")
            {
                return DhGlobalStatic.SP_R060;
            }
            if (name == "SP_R070")
            {
                return DhGlobalStatic.SP_R070;
            }
            return "";
        }



        //public void MakeSureViewExists(string name)
        //{
        //    if (!await IsTableExistsAsync(name))
        //    {
        //        //   var todo = "to create view";
        //        Db.Database.ExecuteSqlRaw(GetSQL(name));
        //    }

        //}


        //public bool IsTableExists(string name)
        //{
        //    var strSQL = $@"
        //SELECT COUNT(*) Cnt FROM INFORMATION_SCHEMA.TABLES 
        //WHERE TABLE_NAME = '{name}'";

        //    var cntObj = Db.CntResult.FromSqlRaw(strSQL).FirstOrDefault();
        //    if (cntObj != null && cntObj.Cnt == 1)
        //        return true;
        //    return false;
        //}

        public async Task<bool> IsTableExistsAsync(string name)
        {
            var strSQL = $@"
        SELECT COUNT(*) Cnt FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_NAME = '{name}'";

            var cntObj =await  Db.CntResult.FromSqlRaw(strSQL).AsNoTracking().FirstOrDefaultAsync();
            if (cntObj != null && cntObj.Cnt == 1)
                return true;
            return false;
        }


        public string getLogLine(string msg)
        {
            var x = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg + Environment.NewLine;
            return x;
        }
        public string GetDteFrmCtl(DateTime dt)
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-US"));

            //return dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00");
            //hxy0915_GetDteFrmCtl
            //return dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Millisecond.ToString("00");

        }




        // NOTE by Mark, 04/26
        // 由 WES 代碼來看, 創建和更新的授權條件是相件的
        //public bool IsAuthToUpdate(string USER_ID, string PROG_ID)
        //{
        //    return IsAuthToCreate(USER_ID, PROG_ID);
        //}


        /// <summary>
        /// Auth NOTE by Mark, 05/28
        /// 為了方便在頁面可以查看 USER_LOG
        /// 查回授權機制, 雖然在用戶menu 已採用更新版本的 V_RIGHT
        /// 這裡仍用之前還沒看到 MLASRS 的做法, 
        /// 在此修正,
        /// 由於已明確掌握 MLASRS 的授權是展開到 PROG_WRT,
        /// 因此這裡直接使用 PROG_WRT
        /// 至於 GROUP_DTL 有個 BUG 沒能展開, 不影響此處的做法
        /// </summary>
        /// <param name="USER_ID"></param>
        /// <param name="PROG_ID"></param>
        /// <returns></returns>
        public async Task<bool> IsAuthToQueryAsync(string USER_ID, string PROG_ID)
        {
            var obj = await Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID).AsNoTracking().CountAsync();
            return obj == 1; // Code NOTE by Mark, 05/28, One and The Only One 為 true, 其餘皆為 false
        }

        //public async Task<string> GetProgName(string USER_ID, string PROG_ID)
        //{
        //    var obj = await Db.ProgMsts.Where(a => a.PROG_ID == PROG_ID).FirstOrDefaultAsync();
        //    //   return obj == 1; // Code NOTE by Mark, 05/28, One and The Only One 為 true, 其餘皆為 false
        //    return obj != null ? obj.PROG_NAME : "---";

        //}

        //public async Task<string> GetProgNameWithLang(string PROG_ID, string LANG)
        //{
        //    var obj = await Db.ProgMsts.Where(a => a.PROG_ID == PROG_ID).AsNoTracking().FirstOrDefaultAsync();
        //    if (obj == null) return PROG_ID;
        //    //   return obj == 1; // Code NOTE by Mark, 05/28, One and The Only One 為 true, 其餘皆為 false
        //    //  return obj != null ? obj.PROG_NAME : "---";
        //    if (LANG == "th-TH")
        //    {
        //        return obj.TH_NAME;
        //    }
        //    if (LANG == "zh-CHT")
        //    {
        //        return obj.TW_NAME;
        //    }
        //    if (LANG == "zh-CHS")
        //    {
        //        return obj.CN_NAME;
        //    }
        //    return obj.PROG_NAME;

        //}



        /// <summary>
        /// 這是最原本只看到DHDB, 沒有看到MLASRS, 所做的, 條件比較嚴格,
        /// 由於已有多處使用, 將 IsAuthToQuery 改命名為 IsAuthToQueryV0
        /// 留做備註, 也保留如要啟用嚴格做法, 可以方便使用
        /// </summary>
        /// <param name="USER_ID"></param>
        /// <param name="PROG_ID"></param>
        /// <returns></returns>
        public bool IsAuthToQueryV0(string USER_ID, string PROG_ID)
        {
            // NOTE by Mark, 04/27, 用戶 ENABLE 可能被取消掉, 要立即偵測

            var chkUserEnable = Db.UserMsts.Where(a => a.USER_ID == USER_ID && a.ENABLE == "Y").Count();
            if (chkUserEnable != 1)
                return false;


            // S010 必需要有 S000 才能最基本訪問, 同時兩者的 ENABLE 都必需為Y
            var prog = Db.ProgMsts.Where(a => a.ENABLE == "Y" && a.PROG_ID == PROG_ID).FirstOrDefault();
            if (prog == null)
                return false;
            var PARENT_ID = prog.PARENT_ID;
            var cat = Db.ProgMsts.Where(a => a.ENABLE == "Y" && a.PROG_ID == PARENT_ID).FirstOrDefault();
            if (cat == null)
                return false;
            return true;
        }



        /// <summary>
        /// 這是早期的寫法, rename IsAuthToQueryAsync to IsAuthToQueryAsyncOld
        /// also change public to private, 
        /// only for reference
        /// to clean up laster on
        /// </summary>
        /// <param name="USER_ID"></param>
        /// <param name="PROG_ID"></param>
        /// <returns></returns>
        //private async Task<bool> IsAuthToQueryAsyncOld(string USER_ID, string PROG_ID)
        //{
        //    // NOTE by Mark, 04/27, 用戶 ENABLE 可能被取消掉, 要立即偵測

        //    var chkUserEnable = await Db.UserMsts.Where(a => a.USER_ID == USER_ID && a.ENABLE == "Y").CountAsync();
        //    if (chkUserEnable != 1)
        //        return false;


        //    // S010 必需要有 S000 才能最基本訪問, 同時兩者的 ENABLE 都必需為Y
        //    var prog = await Db.ProgMsts.Where(a => a.ENABLE == "Y" && a.PROG_ID == PROG_ID).FirstOrDefaultAsync();
        //    if (prog == null)
        //        return false;
        //    var PARENT_ID = prog.PARENT_ID;
        //    var cat = await Db.ProgMsts.Where(a => a.ENABLE == "Y" && a.PROG_ID == PARENT_ID).FirstOrDefaultAsync();
        //    if (cat == null)
        //        return false;
        //    return true;
        //}


        //public bool IsAuthToCreate(string USER_ID, string PROG_ID)
        //{
        //    if (! (await IsAuthToQueryAsync(USER_ID, PROG_ID)))
        //        return false;


        //    var au = Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID)
        //                        .Where(a => a.APPROVE_WRT == "Y" && a.UPDATE_WRT == "Y")
        //                        .Count();
        //    if (au == 1)
        //        return true;
        //    return false;
        //}


        //public bool IsAuthApprove(string USER_ID, string PROG_ID)
        //{
        //    if (!IsAuthToQueryAsync(USER_ID, PROG_ID))
        //        return false;


        //    var au = Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID)
        //                        .Where(a => a.APPROVE_WRT == "Y")
        //                        .Count();
        //    if (au == 1)
        //        return true;
        //    return false;
        //}

        public async Task<bool> IsAuthApproveAsync(string USER_ID, string PROG_ID)
        {
            if (!(await IsAuthToQueryAsync(USER_ID, PROG_ID)))
                return false;


            var au = await Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID)
                                .Where(a => a.APPROVE_WRT == "Y")
                                .CountAsync();
            if (au == 1)
                return true;
            return false;
        }
        public async Task<bool> IsAuthApproveUpdateAsync(string USER_ID, string PROG_ID)
        {
            if (!(await IsAuthToQueryAsync(USER_ID, PROG_ID)))
                return false;


            var au = await Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID)
                                .Where(a => a.APPROVE_WRT == "Y")
                                .Where(a => a.UPDATE_WRT == "Y")
                                .CountAsync();
            if (au == 1)
                return true;
            return false;
        }





        //public async Task<bool> IsAuthApproveAsync(string USER_ID, string PROG_ID)
        //{
        //    if (!(await IsAuthToQueryAsync(USER_ID, PROG_ID)))
        //        return false;


        //    var au = await Db.ProgWrts.Where(a => a.USER_ID == USER_ID && a.PROG_ID == PROG_ID)
        //                        .Where(a => a.APPROVE_WRT == "Y")
        //                        .CountAsync();
        //    if (au == 1)
        //        return true;
        //    return false;
        //}



        public async Task MLASRS_UserLog_Async(string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK, string USER_ID, string USER_NAME, string DEPT_NAME, string CLIENT_IP,string conn)


        //public static string UserLog(string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK)
        {
            string DbProviderType = "System.Data.SqlClient";
            WMSDB = new WESDB(DbProviderType, conn);
            UserInfo.USER_ID = USER_ID;
            UserInfo.USER_NAME = USER_NAME;
            UserInfo.DEPT_NAME = DEPT_NAME;

            DbConnection dbConnection = WMSDB.funCreateConnection();
            DbTransaction dbTransaction = null;

            DataTable dataTable = new DataTable();
            try
            {
                var CLIENT_NAME = System.Net.Dns.GetHostName();

                //建立Connection
                if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Open database failure!");

                //計錄用戶操作
                string strREMARK = "*CLIENT=" + CLIENT_NAME + "(" + CLIENT_IP + ")";
                strREMARK = strREMARK + ";" + sREMARK;
                string sSQL = string.Format(@"insert into USER_LOG(LOG_DATE,LOG_TYPE,USER_ID,PROG_ID,DEPT_NAME,USER_NAME,PROG_NAME,REMARK) values(
                       convert(varchar(19),getdate(),20),'{0}','{1}','{2}',N'{3}',N'{4}',N'{5}',N'{6}')", sLOG_TYPE, UserInfo.USER_ID, sPROG_ID, UserInfo.DEPT_NAME, UserInfo.USER_NAME, sPROG_NAME, strREMARK);
                if (WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction) < 1)
                {
                    //SetErrInfo(new StackTrace(new StackFrame(true)), StrTables.MSG_DISP_FAILED);
                    throw new Exception("Insert USER_LOG failed");
                }

                //return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
                dbConnection.Dispose(); dbConnection = null;

                if (dataTable != null) { dataTable.Dispose(); dataTable = null; }
            }
        }


        /// <summary>
        /// 直接使用 EF Core 機制, 在 WES 給的參數, 的基礎上,加上 USER_ID 和 remoteIP
        /// 
        /// TODO: to conver all to MLASRS_UserLog_Async
        /// </summary>
        public async Task UserLogAsync(string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK, string USER_ID, string remoteIP)
        {
            try
            {

                var CLIENT_NAME = System.Net.Dns.GetHostName();

                // Note by Mark, 06/03, 再強化一次 async
                (string USER_NAME, string DEPT_NAME) = await getLocalUserNameDeptNameAsync(USER_ID);

                var log = new UserLog();

                // Global Note by Mark, 05/28, 這是避免用戶以th-TH登入後造成年的問題
                log.LOG_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                //https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-display-milliseconds-in-date-and-time-values
                //log.LOG_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", new System.Globalization.CultureInfo("en-US"));


                log.LOG_TYPE = sLOG_TYPE;
                log.USER_ID = USER_ID;
                log.PROG_ID = sPROG_ID;
                log.DEPT_NAME = DEPT_NAME;
                log.USER_NAME = USER_NAME;
                log.PROG_NAME = sPROG_NAME;

                // 這是故意有區別於是由 WebWES 所做的 ＬＯＧ, 加上一個小寫 w
                string strREMARK = @$"wCLIENT= {CLIENT_NAME}({remoteIP})";

                log.REMARK = strREMARK + ";" + sREMARK;
                Db.Add(log);
           
                await Db.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                // 這部份純粹是為了寫 Log 而產品的錯誤
                // 只要用戶在 Query 快速, 同一秒鐘內有兩次, 就會出現 PK 錯誤
                //
                // 目前做法: 直接忽略
                // 如果真要顯示  await Db.SaveChangesAsync(); 造成的錯誤,
                // 使用 throw 並在 caller try-catch 處理
                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw

                //throw;



            }


        }

        public async Task UserLogAsyncWithThrow(string sLOG_TYPE, string sPROG_ID, string sPROG_NAME, string sREMARK, string USER_ID, string remoteIP)
        {
            try
            {

                var CLIENT_NAME = System.Net.Dns.GetHostName();

                // Note by Mark, 06/03, 再強化一次 async
                (string USER_NAME, string DEPT_NAME) = await getLocalUserNameDeptNameAsync(USER_ID);

                var log = new UserLog();

                // Global Note by Mark, 05/28, 這是避免用戶以th-TH登入後造成年的問題
                log.LOG_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                //https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-display-milliseconds-in-date-and-time-values
                //log.LOG_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", new System.Globalization.CultureInfo("en-US"));


                log.LOG_TYPE = sLOG_TYPE;
                log.USER_ID = USER_ID;
                log.PROG_ID = sPROG_ID;
                log.DEPT_NAME = DEPT_NAME;
                log.USER_NAME = USER_NAME;
                log.PROG_NAME = sPROG_NAME;

                // 這是故意有區別於是由 WebWES 所做的 ＬＯＧ, 加上一個小寫 w
                string strREMARK = @$"wCLIENT= {CLIENT_NAME}({remoteIP})";

                log.REMARK = strREMARK + ";" + sREMARK;
                Db.Add(log);

                await Db.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                // 這部份純粹是為了寫 Log 而產品的錯誤
                // 只要用戶在 Query 快速, 同一秒鐘內有兩次, 就會出現 PK 錯誤
                //
                // 目前做法: 直接忽略
                // 如果真要顯示  await Db.SaveChangesAsync(); 造成的錯誤,
                // 使用 throw 並在 caller try-catch 處理
                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw

                throw;



            }


        }

        //public int UserLog(string sLOG_TYPE, string USER_ID, string sPROG_ID, string sREMARK, string remoteIP)
        //{
        //    int cnt = 0;
        //    //string strREMARK = "CLIENT=" + CLIENT_NAME + "(" + CLIENT_IP + ")";
        //    //strREMARK = strREMARK + ";" + sREMARK;
        //    var user = getLocalUser(USER_ID);
        //    var prog = getProg(sPROG_ID);

        //    var log = new UserLog();
        //    log.LOG_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
        //    log.LOG_TYPE = sLOG_TYPE;
        //    log.USER_ID = user.USER_ID;
        //    log.PROG_ID = sPROG_ID;
        //    log.DEPT_NAME = user.DEPT_NAME;
        //    log.USER_NAME = user.USER_NAME;
        //    log.PROG_NAME = prog.PROG_NAME;

        //    //            string strREMARK = "CLIENT=" + CLIENT_NAME + "(" + CLIENT_IP + ")";
        //    string strREMARK = "CLIENT= (" + remoteIP + ")";

        //    strREMARK = strREMARK + ";" + sREMARK;

        //    log.REMARK = strREMARK;
        //    Db.Add(log);
        //    cnt = Db.SaveChanges();


        //    return cnt;

        //}


        public RadzenDh5.Models.Mark10Sqlexpress04.UserMst getLocalUser(string USER_ID)
        {
            var user = Db.UserMsts.Where(a => a.USER_ID == USER_ID).FirstOrDefault();
            return user;
        }
        public async Task<(string, string)> getLocalUserNameDeptNameAsync(string USER_ID)
        {
            var user = await Db.UserMsts.Where(a => a.USER_ID == USER_ID).AsNoTracking().FirstOrDefaultAsync();
            if (user == null)
            {
                return (USER_ID, "DEPT_NAME");
            }
            return (user.USER_NAME, user.DEPT_NAME);
        }



        public string getDhUsername(string USER_ID)
        {
            var user = Db.UserMsts.Where(a => a.USER_ID == USER_ID).FirstOrDefault();
            return (user != null) ? user.USER_NAME : "---";

        }

        public string getMsgWithTimestamp(string msg)
        {

            return $@" [{GetLogDateTime()}] {msg}";
        }


        public RadzenDh5.Models.Mark10Sqlexpress04.ProgMst getProg(string PROG_ID)
        {
            var user = Db.ProgMsts.Where(a => a.PROG_ID == PROG_ID).FirstOrDefault();
            return user;
        }


        //public  bool UpdateUserPassword(string strUSER_ID, string strUSER_PSWD, string strNEW_PSWD)
        //{
        //    var obj = AppDb.UserMsts.Where(a => a.USER_ID == Security.User.UserName).FirstOrDefault();
        //    if (obj == null)
        //    {
        //        Toast(NotificationSeverity.Info, "User " + Security.User.UserName + " record not found, Password update failed");
        //        return;
        //    }

        //    return true;
        //}
        //public static bool UpdateUserPassword(string strUSER_ID, string strUSER_PSWD, string strNEW_PSWD)
        //{
        //    //建立數據庫連接實例
        //    var dbConnection = WMSDB.funCreateConnection();
        //    DbTransaction dbTransaction = null;
        //    DataTable dataTable = new DataTable();
        //    try
        //    {
        //        //建立Connection
        //        if (!WMSDB.funOpenDB(ref dbConnection)) throw new Exception("Failed to open database!"); //开启数据库失败

        //        string sSQL = string.Format(@"select * from USER_MST where USER_ID='{0}'", strUSER_ID);
        //        if (!WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction))
        //        {
        //            throw new Exception("User ID or password is incorrect!"); //用户ID或密码不正确
        //        }

        //        strUSER_PSWD = clsTool_2.EncryptDES(strUSER_PSWD, KEYS, IVS);
        //        strNEW_PSWD = clsTool_2.EncryptDES(strNEW_PSWD, KEYS, IVS);

        //        string strREMARK = Convert.ToString(dataTable.Rows[0]["REMARK"]);
        //        strREMARK = strREMARK + string.Format(@"{0}::{1}::Change password of user {2} from {3} to::{4} ||", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")), USER_ID, strUSER_ID, strUSER_PSWD, strNEW_PSWD);

        //        string strSql = string.Format("update USER_MST set USER_PSWD = '{0}',PSWD_DATE=convert(varchar(19),getdate(),20),REMARK='{1}',TRN_DATE=convert(varchar(19),getdate(),20),TRN_USER=N'{2}' where USER_ID= '{3}' and USER_PSWD='{4}'", strNEW_PSWD, strREMARK, USER_ID, strUSER_ID, strUSER_PSWD);
        //        if (WMSDB.funExecSQL(strSql, dbConnection, dbTransaction) < 1)
        //        {
        //            throw new Exception("Password update failed:\r" + strSql); //Password update failed
        //        }
        //        return true;
        //    }


        //[Inject] RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        //[Inject] RadzenDh5.SecurityService Security { get; set; }

        Mark10Sqlexpress04Context Db
        {
            get
            {
                return this.context;
            }
        }

        private readonly Mark10Sqlexpress04Context context;

        public DhGlobalsService(Mark10Sqlexpress04Context context, IWebHostEnvironment env


            )
        {
            this.context = context;
            this.env = env;
        }

        //public bool IsPltDtlsEmpty(string SU_ID)// 是不是空棧板
        //{
        //    bool Result = true;// 先預定為 是

        //    if (Db.PltDtls.Where(a => a.SU_ID == SU_ID).Count() > 0)
        //    {
        //        Result = false; // 只要有任何記錄 否
        //    }

        //    return Result;

        //}


        // 原  P090.cs 這部份代碼
        //檢查母托盤是否已有命令
        //sSQL = string.Format(@"select * from CMD_MST where SU_ID='{0}' and CMD_STS in ('0','1','2','X')", sSU_ID);
        //WMSDB.funGetDT(sSQL, ref dataTable, dbConnection, dbTransaction);
        //        if (dataTable.Rows.Count > 1) throw new Exception("duplicate CMD_MST:" + sSQL);

        public (bool, string) IsCMD_MST(string SU_ID)// 檢查母托盤是否已有命令
        {
            bool Result = false;// 先預定為 否

            //string[] STAT_LIST = { "0", "1", "2", "X" };
            var check1 = Db.CmdMsts.Where(a => a.SU_ID == SU_ID && "012X".Contains(a.CMD_STS));
            var strSQL = check1.ToQueryString();
            if (check1.Count() > 0) // 如有任何筆數
            {
                Result = true;  // 表示 CMD_MST 上有相關於 SU_ID 的命令
                                // NOTE by Mark, 要瞭解  CMD_STS in ('0','1','2','X')            
            }
            return (Result, strSQL);

        }

        /// <summary>
        /// 確保不會受到TH的年影響
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCmdDate()
        {
            //var result = DateTime.Today.ToString("yyMMdd");
            //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));

            // Culture Note by Mark, 要避免 TH 的年的問題
            var result = DateTime.Now.ToString("yyMMdd", new System.Globalization.CultureInfo("en-US"));

            return result;

        }

        /// <summary>
        /// 這是直接由 WES 代碼直接帶過來。沒有做任何更動。
        /// </summary>
        /// <param name="dbConnection"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="sType"></param>
        /// <param name="sDate"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public static string GetCmdSno(ref DbConnection dbConnection, ref DbTransaction dbTransaction, string sType, string sDate, int iLen)
        {
            string sSQL = "";
            string sCmdSno = "";
            int iValue = 0;

            int iRet = 0;

            DataTable dt = new DataTable();

            try
            {
                sSQL = string.Format(@"update SNO_CTL set SNO=SNO+1,TRN_DATE='{1}' where SNO_TYPE='{0}' and TRN_DATE='{1}'", sType, sDate);
                iRet = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                if (iRet < 1)
                {
                    iValue = 1;
                    sSQL = string.Format(@"delete SNO_CTL where SNO_TYPE='{0}'", sType);
                    iRet = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                    sSQL = "insert into SNO_CTL(SNO_TYPE,TRN_DATE,SNO) Values('" + sType + "','" + sDate + "',1)";
                    iRet = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                    if (iRet < 1)
                    {
                        throw new Exception("no SNO_CTL data：" + sSQL);
                    }
                    else
                    {
                        return iValue.ToString().PadLeft(iLen, '0');
                    }
                }

                sSQL = "select * from SNO_CTL where SNO_TYPE='" + sType + "'";
                dt = new DataTable();
                WMSDB.funGetDT(sSQL, ref dt, dbConnection, dbTransaction);

                if (dt.Rows.Count > 0)
                {
                    iValue = int.Parse(Convert.ToString(dt.Rows[0]["SNO"]));
                    int iMax = Convert.ToInt32(Math.Pow(10, iLen) - 1);
                    if (sType == "CmdSno") iMax = 29998;
                    if (iValue > iMax)
                    {
                        iValue = 1;
                        sSQL = "update SNO_CTL set SNO=1,TRN_DATE='" + sDate + "' where SNO_TYPE='" + sType + "'";
                        iRet = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
                        if (iRet < 1)
                        {
                            throw new Exception("no SNO_CTL data：" + sSQL);
                        }
                        else
                        {
                            return iValue.ToString().PadLeft(iLen, '0');
                        }
                    }
                    else
                    {
                        sCmdSno = iValue.ToString().PadLeft(iLen, '0');
                        return sCmdSno;
                    }
                }
                else throw new Exception("no SNO_CTL data：" + sSQL);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dt != null) { dt.Dispose(); dt = null; }
            }
        }




        public RadzenDh5.Models.Mark10Sqlexpress04.CmdMst GetCmdSno_AddCMD_MST_Entity(string sCMD_DATE, string sCMD_SNO, string sSU_ID, string USER_NAME, string REMARK)
        {


            var obj = new RadzenDh5.Models.Mark10Sqlexpress04.CmdMst();



            //生成CMD_MST(先不給值，等掃碼時才給LOC_NO,EQU_NO,STN_NO
            string sCMD_STS = "X";
            string sLOC_NO = "";
            string sEQU_NO = "";
            string sSTN_NO = "";
            string sPRTY = "5";
            string sCMD_MODE = "1";
            string sIO_TYPE = "10"; //Empty pallet in
            string sTRACE = "00";

            string sPROG_ID = "P090";

            //CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,
            //    LOC_NO,TRACE,
            //    SU_ID,PROG_ID,REQM_NO,REQM_LINE,REF_NO,REF_LINE,
            //    TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,REMARK
            //sSQL = string.Format(@"
            //insert into CMD_MST(CMD_DATE,CMD_SNO,CMD_STS,EQU_NO,PRTY,STN_NO,CMD_MODE,IO_TYPE,LOC_NO,TRACE,SU_ID,
            //PROG_ID,
            //REQM_NO,REQM_LINE,REF_NO,REF_LINE,
            //TRN_USER,TRN_DATE,CRT_USER,CRT_DATE,REMARK)
            //values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',N'{16}',convert(varchar(19),getdate(),20),N'{16}',convert(varchar(19),getdate(),20),N'{17}')
            //", sCMD_DATE,
            //sCMD_SNO,
            //sCMD_STS,
            //sEQU_NO,
            //sPRTY,
            //sSTN_NO,
            //sCMD_MODE,
            //sIO_TYPE,
            //sLOC_NO,
            //sTRACE,
            //sSU_ID,
            //sPROG_ID,
            //"", "", "", "", Globals.USER_NAME, sREMARK);
            //iResult = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);
            //if (iResult < 1) throw new Exception("no data create:" + sSQL);


            // select convert(varchar, getdate(), 20)	2006-12-30 00:38:54
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings

            var strDt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            obj.CMD_DATE = sCMD_DATE; //0
            obj.CMD_SNO = sCMD_SNO;   //1
            obj.CMD_STS = sCMD_STS; //2
            obj.EQU_NO = sEQU_NO; //3
            obj.PRTY = sPRTY; //4
            obj.STN_NO = sSTN_NO; //5
            obj.CMD_MODE = sCMD_MODE; //6
            obj.IO_TYPE = sIO_TYPE; //7
            obj.LOC_NO = sLOC_NO; //8
            obj.TRACE = sTRACE; //9
            obj.SU_ID = sSU_ID; //10
            obj.PROG_ID = sPROG_ID; //11
            obj.REQM_NO = ""; //12
            obj.REQM_LINE = ""; //13
            obj.REF_NO = ""; //14
            obj.REF_LINE = ""; //15

            obj.TRN_USER = USER_NAME;
            obj.TRN_DATE = strDt;
            obj.CRT_USER = USER_NAME;
            obj.CRT_DATE = strDt;

            obj.REMARK = REMARK;

            return obj;

            //return (result, msg);
        }


        //https://docs.microsoft.com/en-us/ef/core/saving/transactions
        //string sCMD_SNO = GetCmdSno(ref dbConnection, ref dbTransaction, "CmdSno", sCMD_DATE, 5);
        //SNO_TYPE SNO TRN_DATE
        //CmdSno	2	210412
        //PC	    2	200619
        //PIC	    1	200728
        //TX	    6	200706

        public (bool, string) GetCmdSno(string sType, string sDate, int iLen, string sSU_ID, string USER_NAME, string REMARK)// iLen 5 是指CMD_SNO是5碼,前置補0, 如 00001,00002
        {
            string sCMD_DATE = sDate;

            string strSQL = "";
            int GoingToReturnSNO = 0;
            strSQL = string.Format(@"update SNO_CTL set SNO=SNO+1,TRN_DATE='{1}' where SNO_TYPE='{0}' and TRN_DATE='{1}'", sType, sDate);
            //https://stackoverflow.com/questions/46657813/how-to-update-record-using-entity-framework-core
            try
            {


                var obj = Db.SnoCtls.Where(a => a.SNO_TYPE == sType && a.TRN_DATE == sDate).FirstOrDefault();
                if (obj == null)
                {
                    // 如果無法找到這筆,CmdSno	2	210412
                    // 例如這是當天的第一筆, 
                    //sSQL = string.Format(@"delete SNO_CTL where SNO_TYPE='{0}'", sType);
                    //iRet = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                    //sSQL = "insert into SNO_CTL(SNO_TYPE,TRN_DATE,SNO) Values('" + sType + "','" + sDate + "',1)";
                    //iRet = WMSDB.funExecSQL(sSQL, dbConnection, dbTransaction);

                    // 那麼就刪掉 CmdSno 的 記錄
                    // 然後按 DATECODE 新建 一筆開始是 1
                    //    萬一這個也沒有成功, 那是系統異常,報錯, 給 SQL
                    // 預期就是給出 00001
                    // NOTE by Mark,2021-04-13 10:50
                    // 結論: 以 DATECODE 由 00001 起計數

                    // 如果 CmdSno 計數 > 29998
                    // 也就是當計數為 29999 時, 要歸到 00001
                    // 結論:29997-29998-00001
                    int ONE = 1;
                    var objToDel = Db.SnoCtls.Where(a => a.SNO_TYPE == sType).ToList();
                    Db.RemoveRange(objToDel);
                    var objToAdd = new RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl { SNO_TYPE = sType, TRN_DATE = sDate, SNO = ONE };
                    Db.Add(objToAdd);

                    GoingToReturnSNO = ONE;
                    //Db.SaveChanges();

                    ////https://stackoverflow.com/questions/8462641/convert-int-number-to-string-with-leading-zeros-4-digits
                    //return (true, ONE.ToString().PadLeft(iLen, '0'));
                }
                else
                {

                    obj.SNO = 1 + obj.SNO; //計數加1
                    obj.TRN_DATE = sDate;//yyMMdd , 210412 is 2014-04-12
                    int iMax = 29998;
                    if (sType == "CmdSno") //NOTE by Mark, 要注意其它類型調用時這部分的 歸零 是否影響???
                    {
                        iMax = 29998;
                    }
                    if (obj.SNO > iMax) // NOTE by Mark, 實際只會出現 29999
                    {
                        obj.SNO = 1;
                    }

                    var step1 = Db.Update(obj);
                    //Db.SaveChanges();
                    //NOTE by Mark,
                    //SNO 是 decimal 6
                    GoingToReturnSNO = Decimal.ToInt32(obj.SNO);


                    // return (true, obj.SNO.ToString().PadLeft(iLen, '0'));
                }
                // 不管是新建的 DATECODE 初值1 或是在原有的 DATECODE 加1
                // 都在這裡, 一個地方, 新建 一筆 CMD_MST

                string sCMD_SNO = GoingToReturnSNO.ToString().PadLeft(iLen, '0');

                //  (bool resultAddCMD_MST, string msgAddCMD_MST) =
                var NewCMD_MST = GetCmdSno_AddCMD_MST_Entity(sCMD_DATE, sCMD_SNO, sSU_ID, USER_NAME, REMARK);
                Db.Add(NewCMD_MST);
                //if (!resultAddCMD_MST)
                //{
                //    return (false, "no data create: " + msgAddCMD_MST);
                //}
                Db.SaveChanges();
                //  Empty pallet store in command create Success

                return (true, "Empty pallet store in command create Success");
            }
            catch (Exception ex)
            {
                return (false, "no data create: " + ex.ToString());
            }



        }



    }
}
