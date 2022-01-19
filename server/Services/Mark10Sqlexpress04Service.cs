using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Data;

namespace RadzenDh5
{
    public partial class Mark10Sqlexpress04Service
    {
        Mark10Sqlexpress04Context Context
        {
           get
           {
             return this.context;
           }
        }

        public async Task ExportVp060SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp060s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp060s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVp060SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp060s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp060s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVp060sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vp060> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vp060>> GetVp060S(Query query = null)
        {
            var items = Context.Vp060s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnVp060sRead(ref items);

            return await Task.FromResult(items);
        }

        private readonly Mark10Sqlexpress04Context context;
        private readonly NavigationManager navigationManager;

        public Mark10Sqlexpress04Service(Mark10Sqlexpress04Context context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportAlarmDefsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/alarmdefs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/alarmdefs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAlarmDefsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/alarmdefs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/alarmdefs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAlarmDefsRead(ref IQueryable<Models.Mark10Sqlexpress04.AlarmDef> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.AlarmDef>> GetAlarmDefs(Query query = null)
        {
            var items = Context.AlarmDefs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAlarmDefsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAlarmDefCreated(Models.Mark10Sqlexpress04.AlarmDef item);
        partial void OnAfterAlarmDefCreated(Models.Mark10Sqlexpress04.AlarmDef item);

        public async Task<Models.Mark10Sqlexpress04.AlarmDef> CreateAlarmDef(Models.Mark10Sqlexpress04.AlarmDef alarmDef)
        {
            OnAlarmDefCreated(alarmDef);

            Context.AlarmDefs.Add(alarmDef);
            Context.SaveChanges();

            OnAfterAlarmDefCreated(alarmDef);

            return alarmDef;
        }
        public async Task ExportAlarmLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/alarmlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/alarmlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAlarmLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/alarmlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/alarmlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAlarmLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.AlarmLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.AlarmLog>> GetAlarmLogs(Query query = null)
        {
            var items = Context.AlarmLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAlarmLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAlarmLogCreated(Models.Mark10Sqlexpress04.AlarmLog item);
        partial void OnAfterAlarmLogCreated(Models.Mark10Sqlexpress04.AlarmLog item);

        public async Task<Models.Mark10Sqlexpress04.AlarmLog> CreateAlarmLog(Models.Mark10Sqlexpress04.AlarmLog alarmLog)
        {
            OnAlarmLogCreated(alarmLog);

            Context.AlarmLogs.Add(alarmLog);
            Context.SaveChanges();

            OnAfterAlarmLogCreated(alarmLog);

            return alarmLog;
        }
        public async Task ExportCmdMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/cmdmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/cmdmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCmdMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/cmdmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/cmdmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCmdMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.CmdMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.CmdMst>> GetCmdMsts(Query query = null)
        {
            var items = Context.CmdMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCmdMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCmdMstCreated(Models.Mark10Sqlexpress04.CmdMst item);
        partial void OnAfterCmdMstCreated(Models.Mark10Sqlexpress04.CmdMst item);

        public async Task<Models.Mark10Sqlexpress04.CmdMst> CreateCmdMst(Models.Mark10Sqlexpress04.CmdMst cmdMst)
        {
            OnCmdMstCreated(cmdMst);

            Context.CmdMsts.Add(cmdMst);
            Context.SaveChanges();

            OnAfterCmdMstCreated(cmdMst);

            return cmdMst;
        }
        public async Task ExportCmdMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/cmdmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/cmdmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCmdMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/cmdmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/cmdmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCmdMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.CmdMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.CmdMstHi>> GetCmdMstHis(Query query = null)
        {
            var items = Context.CmdMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCmdMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportCtrlHsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/ctrlhs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/ctrlhs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCtrlHsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/ctrlhs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/ctrlhs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCtrlHsRead(ref IQueryable<Models.Mark10Sqlexpress04.CtrlH> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.CtrlH>> GetCtrlHs(Query query = null)
        {
            var items = Context.CtrlHs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCtrlHsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCtrlHCreated(Models.Mark10Sqlexpress04.CtrlH item);
        partial void OnAfterCtrlHCreated(Models.Mark10Sqlexpress04.CtrlH item);

        public async Task<Models.Mark10Sqlexpress04.CtrlH> CreateCtrlH(Models.Mark10Sqlexpress04.CtrlH ctrlH)
        {
            OnCtrlHCreated(ctrlH);

            Context.CtrlHs.Add(ctrlH);
            Context.SaveChanges();

            OnAfterCtrlHCreated(ctrlH);

            return ctrlH;
        }
        public async Task ExportEquCmdsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcmds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcmds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquCmdsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcmds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcmds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquCmdsRead(ref IQueryable<Models.Mark10Sqlexpress04.EquCmd> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquCmd>> GetEquCmds(Query query = null)
        {
            var items = Context.EquCmds.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquCmdsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquCmdCreated(Models.Mark10Sqlexpress04.EquCmd item);
        partial void OnAfterEquCmdCreated(Models.Mark10Sqlexpress04.EquCmd item);

        public async Task<Models.Mark10Sqlexpress04.EquCmd> CreateEquCmd(Models.Mark10Sqlexpress04.EquCmd equCmd)
        {
            OnEquCmdCreated(equCmd);

            Context.EquCmds.Add(equCmd);
            Context.SaveChanges();

            OnAfterEquCmdCreated(equCmd);

            return equCmd;
        }
        public async Task ExportEquCmdDetailLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcmddetaillogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcmddetaillogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquCmdDetailLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcmddetaillogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcmddetaillogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquCmdDetailLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.EquCmdDetailLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquCmdDetailLog>> GetEquCmdDetailLogs(Query query = null)
        {
            var items = Context.EquCmdDetailLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquCmdDetailLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquCmdDetailLogCreated(Models.Mark10Sqlexpress04.EquCmdDetailLog item);
        partial void OnAfterEquCmdDetailLogCreated(Models.Mark10Sqlexpress04.EquCmdDetailLog item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdDetailLog> CreateEquCmdDetailLog(Models.Mark10Sqlexpress04.EquCmdDetailLog equCmdDetailLog)
        {
            OnEquCmdDetailLogCreated(equCmdDetailLog);

            Context.EquCmdDetailLogs.Add(equCmdDetailLog);
            Context.SaveChanges();

            OnAfterEquCmdDetailLogCreated(equCmdDetailLog);

            return equCmdDetailLog;
        }
        public async Task ExportEquCmdHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcmdhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcmdhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquCmdHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcmdhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcmdhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquCmdHisRead(ref IQueryable<Models.Mark10Sqlexpress04.EquCmdHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquCmdHi>> GetEquCmdHis(Query query = null)
        {
            var items = Context.EquCmdHis.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquCmdHisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquCmdHiCreated(Models.Mark10Sqlexpress04.EquCmdHi item);
        partial void OnAfterEquCmdHiCreated(Models.Mark10Sqlexpress04.EquCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdHi> CreateEquCmdHi(Models.Mark10Sqlexpress04.EquCmdHi equCmdHi)
        {
            OnEquCmdHiCreated(equCmdHi);

            Context.EquCmdHis.Add(equCmdHi);
            Context.SaveChanges();

            OnAfterEquCmdHiCreated(equCmdHi);

            return equCmdHi;
        }
        public async Task ExportEquCodeDefsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcodedefs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcodedefs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquCodeDefsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equcodedefs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equcodedefs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquCodeDefsRead(ref IQueryable<Models.Mark10Sqlexpress04.EquCodeDef> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquCodeDef>> GetEquCodeDefs(Query query = null)
        {
            var items = Context.EquCodeDefs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquCodeDefsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquCodeDefCreated(Models.Mark10Sqlexpress04.EquCodeDef item);
        partial void OnAfterEquCodeDefCreated(Models.Mark10Sqlexpress04.EquCodeDef item);

        public async Task<Models.Mark10Sqlexpress04.EquCodeDef> CreateEquCodeDef(Models.Mark10Sqlexpress04.EquCodeDef equCodeDef)
        {
            OnEquCodeDefCreated(equCodeDef);

            Context.EquCodeDefs.Add(equCodeDef);
            Context.SaveChanges();

            OnAfterEquCodeDefCreated(equCodeDef);

            return equCodeDef;
        }
        public async Task ExportEquModeLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equmodelogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equmodelogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquModeLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equmodelogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equmodelogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquModeLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.EquModeLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquModeLog>> GetEquModeLogs(Query query = null)
        {
            var items = Context.EquModeLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquModeLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquModeLogCreated(Models.Mark10Sqlexpress04.EquModeLog item);
        partial void OnAfterEquModeLogCreated(Models.Mark10Sqlexpress04.EquModeLog item);

        public async Task<Models.Mark10Sqlexpress04.EquModeLog> CreateEquModeLog(Models.Mark10Sqlexpress04.EquModeLog equModeLog)
        {
            OnEquModeLogCreated(equModeLog);

            Context.EquModeLogs.Add(equModeLog);
            Context.SaveChanges();

            OnAfterEquModeLogCreated(equModeLog);

            return equModeLog;
        }
        public async Task ExportEquMplcCmdHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equmplccmdhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equmplccmdhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquMplcCmdHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equmplccmdhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equmplccmdhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquMplcCmdHisRead(ref IQueryable<Models.Mark10Sqlexpress04.EquMplcCmdHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquMplcCmdHi>> GetEquMplcCmdHis(Query query = null)
        {
            var items = Context.EquMplcCmdHis.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquMplcCmdHisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquMplcCmdHiCreated(Models.Mark10Sqlexpress04.EquMplcCmdHi item);
        partial void OnAfterEquMplcCmdHiCreated(Models.Mark10Sqlexpress04.EquMplcCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquMplcCmdHi> CreateEquMplcCmdHi(Models.Mark10Sqlexpress04.EquMplcCmdHi equMplcCmdHi)
        {
            OnEquMplcCmdHiCreated(equMplcCmdHi);

            Context.EquMplcCmdHis.Add(equMplcCmdHi);
            Context.SaveChanges();

            OnAfterEquMplcCmdHiCreated(equMplcCmdHi);

            return equMplcCmdHi;
        }
        public async Task ExportEquPlcDataToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equplcdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equplcdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquPlcDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equplcdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equplcdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquPlcDataRead(ref IQueryable<Models.Mark10Sqlexpress04.EquPlcDatum> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquPlcDatum>> GetEquPlcData(Query query = null)
        {
            var items = Context.EquPlcData.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquPlcDataRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquPlcDatumCreated(Models.Mark10Sqlexpress04.EquPlcDatum item);
        partial void OnAfterEquPlcDatumCreated(Models.Mark10Sqlexpress04.EquPlcDatum item);

        public async Task<Models.Mark10Sqlexpress04.EquPlcDatum> CreateEquPlcDatum(Models.Mark10Sqlexpress04.EquPlcDatum equPlcDatum)
        {
            OnEquPlcDatumCreated(equPlcDatum);

            Context.EquPlcData.Add(equPlcDatum);
            Context.SaveChanges();

            OnAfterEquPlcDatumCreated(equPlcDatum);

            return equPlcDatum;
        }
        public async Task ExportEquStsLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equstslogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equstslogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquStsLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equstslogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equstslogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquStsLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.EquStsLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquStsLog>> GetEquStsLogs(Query query = null)
        {
            var items = Context.EquStsLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquStsLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquStsLogCreated(Models.Mark10Sqlexpress04.EquStsLog item);
        partial void OnAfterEquStsLogCreated(Models.Mark10Sqlexpress04.EquStsLog item);

        public async Task<Models.Mark10Sqlexpress04.EquStsLog> CreateEquStsLog(Models.Mark10Sqlexpress04.EquStsLog equStsLog)
        {
            OnEquStsLogCreated(equStsLog);

            Context.EquStsLogs.Add(equStsLog);
            Context.SaveChanges();

            OnAfterEquStsLogCreated(equStsLog);

            return equStsLog;
        }
        public async Task ExportEquTrnLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equtrnlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equtrnlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEquTrnLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/equtrnlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/equtrnlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEquTrnLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.EquTrnLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.EquTrnLog>> GetEquTrnLogs(Query query = null)
        {
            var items = Context.EquTrnLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEquTrnLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEquTrnLogCreated(Models.Mark10Sqlexpress04.EquTrnLog item);
        partial void OnAfterEquTrnLogCreated(Models.Mark10Sqlexpress04.EquTrnLog item);

        public async Task<Models.Mark10Sqlexpress04.EquTrnLog> CreateEquTrnLog(Models.Mark10Sqlexpress04.EquTrnLog equTrnLog)
        {
            OnEquTrnLogCreated(equTrnLog);

            Context.EquTrnLogs.Add(equTrnLog);
            Context.SaveChanges();

            OnAfterEquTrnLogCreated(equTrnLog);

            return equTrnLog;
        }
        public async Task ExportGroupDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.GroupDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GroupDtl>> GetGroupDtls(Query query = null)
        {
            var items = Context.GroupDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGroupDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGroupDtlCreated(Models.Mark10Sqlexpress04.GroupDtl item);
        partial void OnAfterGroupDtlCreated(Models.Mark10Sqlexpress04.GroupDtl item);

        public async Task<Models.Mark10Sqlexpress04.GroupDtl> CreateGroupDtl(Models.Mark10Sqlexpress04.GroupDtl groupDtl)
        {
            OnGroupDtlCreated(groupDtl);

            Context.GroupDtls.Add(groupDtl);
            Context.SaveChanges();

            OnAfterGroupDtlCreated(groupDtl);

            return groupDtl;
        }
        public async Task ExportGroupDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.GroupDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GroupDtlHi>> GetGroupDtlHis(Query query = null)
        {
            var items = Context.GroupDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGroupDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportGroupMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.GroupMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GroupMst>> GetGroupMsts(Query query = null)
        {
            var items = Context.GroupMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGroupMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGroupMstCreated(Models.Mark10Sqlexpress04.GroupMst item);
        partial void OnAfterGroupMstCreated(Models.Mark10Sqlexpress04.GroupMst item);

        public async Task<Models.Mark10Sqlexpress04.GroupMst> CreateGroupMst(Models.Mark10Sqlexpress04.GroupMst groupMst)
        {
            OnGroupMstCreated(groupMst);

            Context.GroupMsts.Add(groupMst);
            Context.SaveChanges();

            OnAfterGroupMstCreated(groupMst);

            return groupMst;
        }
        public async Task ExportGroupMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.GroupMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GroupMstHi>> GetGroupMstHis(Query query = null)
        {
            var items = Context.GroupMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGroupMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportGroupWrtsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupwrts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupwrts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupWrtsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupwrts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupwrts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupWrtsRead(ref IQueryable<Models.Mark10Sqlexpress04.GroupWrt> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GroupWrt>> GetGroupWrts(Query query = null)
        {
            var items = Context.GroupWrts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGroupWrtsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGroupWrtCreated(Models.Mark10Sqlexpress04.GroupWrt item);
        partial void OnAfterGroupWrtCreated(Models.Mark10Sqlexpress04.GroupWrt item);

        public async Task<Models.Mark10Sqlexpress04.GroupWrt> CreateGroupWrt(Models.Mark10Sqlexpress04.GroupWrt groupWrt)
        {
            OnGroupWrtCreated(groupWrt);

            Context.GroupWrts.Add(groupWrt);
            Context.SaveChanges();

            OnAfterGroupWrtCreated(groupWrt);

            return groupWrt;
        }
        public async Task ExportGroupWrtHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupwrthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupwrthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupWrtHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/groupwrthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/groupwrthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupWrtHisRead(ref IQueryable<Models.Mark10Sqlexpress04.GroupWrtHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GroupWrtHi>> GetGroupWrtHis(Query query = null)
        {
            var items = Context.GroupWrtHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGroupWrtHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportGtinMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/gtinmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/gtinmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGtinMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/gtinmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/gtinmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGtinMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.GtinMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GtinMst>> GetGtinMsts(Query query = null)
        {
            var items = Context.GtinMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGtinMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGtinMstCreated(Models.Mark10Sqlexpress04.GtinMst item);
        partial void OnAfterGtinMstCreated(Models.Mark10Sqlexpress04.GtinMst item);

        public async Task<Models.Mark10Sqlexpress04.GtinMst> CreateGtinMst(Models.Mark10Sqlexpress04.GtinMst gtinMst)
        {
            OnGtinMstCreated(gtinMst);

            Context.GtinMsts.Add(gtinMst);
            Context.SaveChanges();

            OnAfterGtinMstCreated(gtinMst);

            return gtinMst;
        }
        public async Task ExportGtinMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/gtinmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/gtinmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGtinMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/gtinmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/gtinmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGtinMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.GtinMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.GtinMstHi>> GetGtinMstHis(Query query = null)
        {
            var items = Context.GtinMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGtinMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportInDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/indtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/indtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/indtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/indtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.InDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.InDtl>> GetInDtls(Query query = null)
        {
            var items = Context.InDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInDtlCreated(Models.Mark10Sqlexpress04.InDtl item);
        partial void OnAfterInDtlCreated(Models.Mark10Sqlexpress04.InDtl item);

        public async Task<Models.Mark10Sqlexpress04.InDtl> CreateInDtl(Models.Mark10Sqlexpress04.InDtl inDtl)
        {
            OnInDtlCreated(inDtl);

            Context.InDtls.Add(inDtl);
            Context.SaveChanges();

            OnAfterInDtlCreated(inDtl);

            return inDtl;
        }
        public async Task ExportInDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/indtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/indtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/indtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/indtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.InDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.InDtlHi>> GetInDtlHis(Query query = null)
        {
            var items = Context.InDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportInMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/inmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/inmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/inmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/inmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.InMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.InMst>> GetInMsts(Query query = null)
        {
            var items = Context.InMsts.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInMstsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportInMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/inmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/inmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/inmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/inmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.InMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.InMstHi>> GetInMstHis(Query query = null)
        {
            var items = Context.InMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportInSnosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/insnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/insnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInSnosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/insnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/insnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.InSno> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.InSno>> GetInSnos(Query query = null)
        {
            var items = Context.InSnos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInSnosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInSnoCreated(Models.Mark10Sqlexpress04.InSno item);
        partial void OnAfterInSnoCreated(Models.Mark10Sqlexpress04.InSno item);

        public async Task<Models.Mark10Sqlexpress04.InSno> CreateInSno(Models.Mark10Sqlexpress04.InSno inSno)
        {
            OnInSnoCreated(inSno);

            Context.InSnos.Add(inSno);
            Context.SaveChanges();

            OnAfterInSnoCreated(inSno);

            return inSno;
        }
        public async Task ExportInSnoHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/insnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/insnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInSnoHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/insnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/insnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInSnoHisRead(ref IQueryable<Models.Mark10Sqlexpress04.InSnoHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.InSnoHi>> GetInSnoHis(Query query = null)
        {
            var items = Context.InSnoHis.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInSnoHisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInSnoHiCreated(Models.Mark10Sqlexpress04.InSnoHi item);
        partial void OnAfterInSnoHiCreated(Models.Mark10Sqlexpress04.InSnoHi item);

        public async Task<Models.Mark10Sqlexpress04.InSnoHi> CreateInSnoHi(Models.Mark10Sqlexpress04.InSnoHi inSnoHi)
        {
            OnInSnoHiCreated(inSnoHi);

            Context.InSnoHis.Add(inSnoHi);
            Context.SaveChanges();

            OnAfterInSnoHiCreated(inSnoHi);

            return inSnoHi;
        }
        public async Task ExportLocDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLocDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLocDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.LocDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.LocDtl>> GetLocDtls(Query query = null)
        {
            var items = Context.LocDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLocDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLocDtlCreated(Models.Mark10Sqlexpress04.LocDtl item);
        partial void OnAfterLocDtlCreated(Models.Mark10Sqlexpress04.LocDtl item);

        public async Task<Models.Mark10Sqlexpress04.LocDtl> CreateLocDtl(Models.Mark10Sqlexpress04.LocDtl locDtl)
        {
            OnLocDtlCreated(locDtl);

            Context.LocDtls.Add(locDtl);
            Context.SaveChanges();

            OnAfterLocDtlCreated(locDtl);

            return locDtl;
        }
        public async Task ExportLocDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLocDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLocDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.LocDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.LocDtlHi>> GetLocDtlHis(Query query = null)
        {
            var items = Context.LocDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLocDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportLocMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLocMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLocMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.LocMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.LocMst>> GetLocMsts(Query query = null)
        {
            var items = Context.LocMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLocMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLocMstCreated(Models.Mark10Sqlexpress04.LocMst item);
        partial void OnAfterLocMstCreated(Models.Mark10Sqlexpress04.LocMst item);

        public async Task<Models.Mark10Sqlexpress04.LocMst> CreateLocMst(Models.Mark10Sqlexpress04.LocMst locMst)
        {
            OnLocMstCreated(locMst);

            Context.LocMsts.Add(locMst);
            Context.SaveChanges();

            OnAfterLocMstCreated(locMst);

            return locMst;
        }
        public async Task ExportLocMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLocMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/locmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/locmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLocMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.LocMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.LocMstHi>> GetLocMstHis(Query query = null)
        {
            var items = Context.LocMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLocMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportMsgLangsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/msglangs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/msglangs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMsgLangsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/msglangs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/msglangs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMsgLangsRead(ref IQueryable<Models.Mark10Sqlexpress04.MsgLang> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.MsgLang>> GetMsgLangs(Query query = null)
        {
            var items = Context.MsgLangs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMsgLangsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMsgLangCreated(Models.Mark10Sqlexpress04.MsgLang item);
        partial void OnAfterMsgLangCreated(Models.Mark10Sqlexpress04.MsgLang item);

        public async Task<Models.Mark10Sqlexpress04.MsgLang> CreateMsgLang(Models.Mark10Sqlexpress04.MsgLang msgLang)
        {
            OnMsgLangCreated(msgLang);

            Context.MsgLangs.Add(msgLang);
            Context.SaveChanges();

            OnAfterMsgLangCreated(msgLang);

            return msgLang;
        }
        public async Task ExportOutDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOutDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOutDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.OutDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.OutDtl>> GetOutDtls(Query query = null)
        {
            var items = Context.OutDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOutDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOutDtlCreated(Models.Mark10Sqlexpress04.OutDtl item);
        partial void OnAfterOutDtlCreated(Models.Mark10Sqlexpress04.OutDtl item);

        public async Task<Models.Mark10Sqlexpress04.OutDtl> CreateOutDtl(Models.Mark10Sqlexpress04.OutDtl outDtl)
        {
            OnOutDtlCreated(outDtl);

            Context.OutDtls.Add(outDtl);
            Context.SaveChanges();

            OnAfterOutDtlCreated(outDtl);

            return outDtl;
        }
        public async Task ExportOutDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOutDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOutDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.OutDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.OutDtlHi>> GetOutDtlHis(Query query = null)
        {
            var items = Context.OutDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOutDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOutMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOutMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOutMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.OutMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.OutMst>> GetOutMsts(Query query = null)
        {
            var items = Context.OutMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOutMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOutMstCreated(Models.Mark10Sqlexpress04.OutMst item);
        partial void OnAfterOutMstCreated(Models.Mark10Sqlexpress04.OutMst item);

        public async Task<Models.Mark10Sqlexpress04.OutMst> CreateOutMst(Models.Mark10Sqlexpress04.OutMst outMst)
        {
            OnOutMstCreated(outMst);

            Context.OutMsts.Add(outMst);
            Context.SaveChanges();

            OnAfterOutMstCreated(outMst);

            return outMst;
        }
        public async Task ExportOutMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOutMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOutMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.OutMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.OutMstHi>> GetOutMstHis(Query query = null)
        {
            var items = Context.OutMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOutMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOutSnosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOutSnosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOutSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.OutSno> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.OutSno>> GetOutSnos(Query query = null)
        {
            var items = Context.OutSnos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOutSnosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOutSnoCreated(Models.Mark10Sqlexpress04.OutSno item);
        partial void OnAfterOutSnoCreated(Models.Mark10Sqlexpress04.OutSno item);

        public async Task<Models.Mark10Sqlexpress04.OutSno> CreateOutSno(Models.Mark10Sqlexpress04.OutSno outSno)
        {
            OnOutSnoCreated(outSno);

            Context.OutSnos.Add(outSno);
            Context.SaveChanges();

            OnAfterOutSnoCreated(outSno);

            return outSno;
        }
        public async Task ExportOutSnoHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outsnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outsnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOutSnoHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/outsnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/outsnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOutSnoHisRead(ref IQueryable<Models.Mark10Sqlexpress04.OutSnoHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.OutSnoHi>> GetOutSnoHis(Query query = null)
        {
            var items = Context.OutSnoHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOutSnoHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPcLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pclogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pclogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPcLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pclogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pclogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPcLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.PcLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PcLog>> GetPcLogs(Query query = null)
        {
            var items = Context.PcLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPcLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPcLogCreated(Models.Mark10Sqlexpress04.PcLog item);
        partial void OnAfterPcLogCreated(Models.Mark10Sqlexpress04.PcLog item);

        public async Task<Models.Mark10Sqlexpress04.PcLog> CreatePcLog(Models.Mark10Sqlexpress04.PcLog pcLog)
        {
            OnPcLogCreated(pcLog);

            Context.PcLogs.Add(pcLog);
            Context.SaveChanges();

            OnAfterPcLogCreated(pcLog);

            return pcLog;
        }
        public async Task ExportPcSnosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pcsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pcsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPcSnosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pcsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pcsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPcSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.PcSno> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PcSno>> GetPcSnos(Query query = null)
        {
            var items = Context.PcSnos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPcSnosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPcSnoCreated(Models.Mark10Sqlexpress04.PcSno item);
        partial void OnAfterPcSnoCreated(Models.Mark10Sqlexpress04.PcSno item);

        public async Task<Models.Mark10Sqlexpress04.PcSno> CreatePcSno(Models.Mark10Sqlexpress04.PcSno pcSno)
        {
            OnPcSnoCreated(pcSno);

            Context.PcSnos.Add(pcSno);
            Context.SaveChanges();

            OnAfterPcSnoCreated(pcSno);

            return pcSno;
        }
        public async Task ExportPckDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPckDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPckDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.PckDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PckDtl>> GetPckDtls(Query query = null)
        {
            var items = Context.PckDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPckDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPckDtlCreated(Models.Mark10Sqlexpress04.PckDtl item);
        partial void OnAfterPckDtlCreated(Models.Mark10Sqlexpress04.PckDtl item);

        public async Task<Models.Mark10Sqlexpress04.PckDtl> CreatePckDtl(Models.Mark10Sqlexpress04.PckDtl pckDtl)
        {
            OnPckDtlCreated(pckDtl);

            Context.PckDtls.Add(pckDtl);
            Context.SaveChanges();

            OnAfterPckDtlCreated(pckDtl);

            return pckDtl;
        }
        public async Task ExportPckDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPckDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPckDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PckDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PckDtlHi>> GetPckDtlHis(Query query = null)
        {
            var items = Context.PckDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPckDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPckMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPckMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPckMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.PckMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PckMst>> GetPckMsts(Query query = null)
        {
            var items = Context.PckMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPckMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPckMstCreated(Models.Mark10Sqlexpress04.PckMst item);
        partial void OnAfterPckMstCreated(Models.Mark10Sqlexpress04.PckMst item);

        public async Task<Models.Mark10Sqlexpress04.PckMst> CreatePckMst(Models.Mark10Sqlexpress04.PckMst pckMst)
        {
            OnPckMstCreated(pckMst);

            Context.PckMsts.Add(pckMst);
            Context.SaveChanges();

            OnAfterPckMstCreated(pckMst);

            return pckMst;
        }
        public async Task ExportPckMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPckMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pckmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pckmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPckMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PckMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PckMstHi>> GetPckMstHis(Query query = null)
        {
            var items = Context.PckMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPckMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPckSnosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pcksnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pcksnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPckSnosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pcksnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pcksnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPckSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.PckSno> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PckSno>> GetPckSnos(Query query = null)
        {
            var items = Context.PckSnos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPckSnosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPckSnoCreated(Models.Mark10Sqlexpress04.PckSno item);
        partial void OnAfterPckSnoCreated(Models.Mark10Sqlexpress04.PckSno item);

        public async Task<Models.Mark10Sqlexpress04.PckSno> CreatePckSno(Models.Mark10Sqlexpress04.PckSno pckSno)
        {
            OnPckSnoCreated(pckSno);

            Context.PckSnos.Add(pckSno);
            Context.SaveChanges();

            OnAfterPckSnoCreated(pckSno);

            return pckSno;
        }
        public async Task ExportPckSnoHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pcksnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pcksnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPckSnoHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pcksnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pcksnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPckSnoHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PckSnoHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PckSnoHi>> GetPckSnoHis(Query query = null)
        {
            var items = Context.PckSnoHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPckSnoHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPicDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPicDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPicDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.PicDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PicDtl>> GetPicDtls(Query query = null)
        {
            var items = Context.PicDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPicDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPicDtlCreated(Models.Mark10Sqlexpress04.PicDtl item);
        partial void OnAfterPicDtlCreated(Models.Mark10Sqlexpress04.PicDtl item);

        public async Task<Models.Mark10Sqlexpress04.PicDtl> CreatePicDtl(Models.Mark10Sqlexpress04.PicDtl picDtl)
        {
            OnPicDtlCreated(picDtl);

            Context.PicDtls.Add(picDtl);
            Context.SaveChanges();

            OnAfterPicDtlCreated(picDtl);

            return picDtl;
        }
        public async Task ExportPicDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPicDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPicDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PicDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PicDtlHi>> GetPicDtlHis(Query query = null)
        {
            var items = Context.PicDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPicDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPicMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPicMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPicMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.PicMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PicMst>> GetPicMsts(Query query = null)
        {
            var items = Context.PicMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPicMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPicMstCreated(Models.Mark10Sqlexpress04.PicMst item);
        partial void OnAfterPicMstCreated(Models.Mark10Sqlexpress04.PicMst item);

        public async Task<Models.Mark10Sqlexpress04.PicMst> CreatePicMst(Models.Mark10Sqlexpress04.PicMst picMst)
        {
            OnPicMstCreated(picMst);

            Context.PicMsts.Add(picMst);
            Context.SaveChanges();

            OnAfterPicMstCreated(picMst);

            return picMst;
        }
        public async Task ExportPicMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPicMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPicMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PicMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PicMstHi>> GetPicMstHis(Query query = null)
        {
            var items = Context.PicMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPicMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        //public async Task ExportPicSnosToExcel(Query query = null, string fileName = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}

        //public async Task ExportPicSnosToCSV(Query query = null, string fileName = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}

        //partial void OnPicSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.PicSno> items);

        //public async Task<IQueryable<Models.Mark10Sqlexpress04.PicSno>> GetPicSnos(Query query = null)
        //{
        //    var items = Context.PicSnos.AsQueryable();

        //    if (query != null)
        //    {
        //        if (!string.IsNullOrEmpty(query.Expand))
        //        {
        //            var propertiesToExpand = query.Expand.Split(',');
        //            foreach(var p in propertiesToExpand)
        //            {
        //                items = items.Include(p);
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(query.Filter))
        //        {
        //            if (query.FilterParameters != null)
        //            {
        //                items = items.Where(query.Filter, query.FilterParameters);
        //            }
        //            else
        //            {
        //                items = items.Where(query.Filter);
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(query.OrderBy))
        //        {
        //            items = items.OrderBy(query.OrderBy);
        //        }

        //        if (query.Skip.HasValue)
        //        {
        //            items = items.Skip(query.Skip.Value);
        //        }

        //        if (query.Top.HasValue)
        //        {
        //            items = items.Take(query.Top.Value);
        //        }
        //    }

        //    OnPicSnosRead(ref items);

        //    return await Task.FromResult(items);
        //}

        //partial void OnPicSnoCreated(Models.Mark10Sqlexpress04.PicSno item);
        //partial void OnAfterPicSnoCreated(Models.Mark10Sqlexpress04.PicSno item);

        //public async Task<Models.Mark10Sqlexpress04.PicSno> CreatePicSno(Models.Mark10Sqlexpress04.PicSno picSno)
        //{
        //    OnPicSnoCreated(picSno);

        //    Context.PicSnos.Add(picSno);
        //    Context.SaveChanges();

        //    OnAfterPicSnoCreated(picSno);

        //    return picSno;
        //}
        public async Task ExportPicSnoHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picsnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picsnohis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPicSnoHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picsnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picsnohis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPicSnoHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PicSnoHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PicSnoHi>> GetPicSnoHis(Query query = null)
        {
            var items = Context.PicSnoHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPicSnoHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPltDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pltdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pltdtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPltDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pltdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pltdtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPltDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.PltDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PltDtl>> GetPltDtls(Query query = null)
        {
            var items = Context.PltDtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPltDtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPltDtlCreated(Models.Mark10Sqlexpress04.PltDtl item);
        partial void OnAfterPltDtlCreated(Models.Mark10Sqlexpress04.PltDtl item);

        public async Task<Models.Mark10Sqlexpress04.PltDtl> CreatePltDtl(Models.Mark10Sqlexpress04.PltDtl pltDtl)
        {
            OnPltDtlCreated(pltDtl);

            Context.PltDtls.Add(pltDtl);
            Context.SaveChanges();

            OnAfterPltDtlCreated(pltDtl);

            return pltDtl;
        }
        public async Task ExportPltDtlHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pltdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pltdtlhis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPltDtlHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/pltdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/pltdtlhis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPltDtlHisRead(ref IQueryable<Models.Mark10Sqlexpress04.PltDtlHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PltDtlHi>> GetPltDtlHis(Query query = null)
        {
            var items = Context.PltDtlHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPltDtlHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportProgMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.ProgMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.ProgMst>> GetProgMsts(Query query = null)
        {
            var items = Context.ProgMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProgMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProgMstCreated(Models.Mark10Sqlexpress04.ProgMst item);
        partial void OnAfterProgMstCreated(Models.Mark10Sqlexpress04.ProgMst item);

        public async Task<Models.Mark10Sqlexpress04.ProgMst> CreateProgMst(Models.Mark10Sqlexpress04.ProgMst progMst)
        {
            OnProgMstCreated(progMst);

            Context.ProgMsts.Add(progMst);
            Context.SaveChanges();

            OnAfterProgMstCreated(progMst);

            return progMst;
        }
        public async Task ExportProgMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progmsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progmsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.ProgMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.ProgMstHi>> GetProgMstHis(Query query = null)
        {
            var items = Context.ProgMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProgMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportProgWrtsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progwrts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progwrts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgWrtsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progwrts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progwrts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgWrtsRead(ref IQueryable<Models.Mark10Sqlexpress04.ProgWrt> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.ProgWrt>> GetProgWrts(Query query = null)
        {
            var items = Context.ProgWrts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProgWrtsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProgWrtCreated(Models.Mark10Sqlexpress04.ProgWrt item);
        partial void OnAfterProgWrtCreated(Models.Mark10Sqlexpress04.ProgWrt item);

        public async Task<Models.Mark10Sqlexpress04.ProgWrt> CreateProgWrt(Models.Mark10Sqlexpress04.ProgWrt progWrt)
        {
            OnProgWrtCreated(progWrt);

            Context.ProgWrts.Add(progWrt);
            Context.SaveChanges();

            OnAfterProgWrtCreated(progWrt);

            return progWrt;
        }
        public async Task ExportProgWrtHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progwrthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progwrthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgWrtHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/progwrthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/progwrthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgWrtHisRead(ref IQueryable<Models.Mark10Sqlexpress04.ProgWrtHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.ProgWrtHi>> GetProgWrtHis(Query query = null)
        {
            var items = Context.ProgWrtHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProgWrtHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportRptR030SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/rptr030s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/rptr030s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRptR030SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/rptr030s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/rptr030s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRptR030sRead(ref IQueryable<Models.Mark10Sqlexpress04.RptR030> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.RptR030>> GetRptR030S(Query query = null)
        {
            var items = Context.RptR030s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRptR030sRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportSkuMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skumsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skumsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSkuMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skumsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skumsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSkuMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.SkuMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.SkuMst>> GetSkuMsts(Query query = null)
        {
            var items = Context.SkuMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSkuMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSkuMstCreated(Models.Mark10Sqlexpress04.SkuMst item);
        partial void OnAfterSkuMstCreated(Models.Mark10Sqlexpress04.SkuMst item);

        public async Task<Models.Mark10Sqlexpress04.SkuMst> CreateSkuMst(Models.Mark10Sqlexpress04.SkuMst skuMst)
        {
            OnSkuMstCreated(skuMst);

            Context.SkuMsts.Add(skuMst);
            Context.SaveChanges();

            OnAfterSkuMstCreated(skuMst);

            return skuMst;
        }
        public async Task ExportSkuMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skumsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skumsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSkuMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skumsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skumsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSkuMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.SkuMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.SkuMstHi>> GetSkuMstHis(Query query = null)
        {
            var items = Context.SkuMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSkuMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportSkuSutsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skusuts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skusuts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSkuSutsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skusuts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skusuts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSkuSutsRead(ref IQueryable<Models.Mark10Sqlexpress04.SkuSut> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.SkuSut>> GetSkuSuts(Query query = null)
        {
            var items = Context.SkuSuts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSkuSutsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSkuSutCreated(Models.Mark10Sqlexpress04.SkuSut item);
        partial void OnAfterSkuSutCreated(Models.Mark10Sqlexpress04.SkuSut item);

        public async Task<Models.Mark10Sqlexpress04.SkuSut> CreateSkuSut(Models.Mark10Sqlexpress04.SkuSut skuSut)
        {
            OnSkuSutCreated(skuSut);

            Context.SkuSuts.Add(skuSut);
            Context.SaveChanges();

            OnAfterSkuSutCreated(skuSut);

            return skuSut;
        }
        public async Task ExportSkuSutHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skusuthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skusuthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSkuSutHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/skusuthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/skusuthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSkuSutHisRead(ref IQueryable<Models.Mark10Sqlexpress04.SkuSutHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.SkuSutHi>> GetSkuSutHis(Query query = null)
        {
            var items = Context.SkuSutHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSkuSutHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportSnoCtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/snoctls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/snoctls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSnoCtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/snoctls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/snoctls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSnoCtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.SnoCtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.SnoCtl>> GetSnoCtls(Query query = null)
        {
            var items = Context.SnoCtls.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSnoCtlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSnoCtlCreated(Models.Mark10Sqlexpress04.SnoCtl item);
        partial void OnAfterSnoCtlCreated(Models.Mark10Sqlexpress04.SnoCtl item);

        public async Task<Models.Mark10Sqlexpress04.SnoCtl> CreateSnoCtl(Models.Mark10Sqlexpress04.SnoCtl snoCtl)
        {
            OnSnoCtlCreated(snoCtl);

            Context.SnoCtls.Add(snoCtl);
            Context.SaveChanges();

            OnAfterSnoCtlCreated(snoCtl);

            return snoCtl;
        }
        public async Task ExportStnMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/stnmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/stnmsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportStnMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/stnmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/stnmsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnStnMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.StnMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.StnMst>> GetStnMsts(Query query = null)
        {
            var items = Context.StnMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnStnMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnStnMstCreated(Models.Mark10Sqlexpress04.StnMst item);
        partial void OnAfterStnMstCreated(Models.Mark10Sqlexpress04.StnMst item);

        public async Task<Models.Mark10Sqlexpress04.StnMst> CreateStnMst(Models.Mark10Sqlexpress04.StnMst stnMst)
        {
            OnStnMstCreated(stnMst);

            Context.StnMsts.Add(stnMst);
            Context.SaveChanges();

            OnAfterStnMstCreated(stnMst);

            return stnMst;
        }
        public async Task ExportTranslatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/translates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/translates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTranslatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/translates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/translates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTranslatesRead(ref IQueryable<Models.Mark10Sqlexpress04.Translate> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Translate>> GetTranslates(Query query = null)
        {
            var items = Context.Translates.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTranslatesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportTxLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/txlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/txlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTxLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/txlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/txlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTxLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.TxLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.TxLog>> GetTxLogs(Query query = null)
        {
            var items = Context.TxLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTxLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTxLogCreated(Models.Mark10Sqlexpress04.TxLog item);
        partial void OnAfterTxLogCreated(Models.Mark10Sqlexpress04.TxLog item);

        public async Task<Models.Mark10Sqlexpress04.TxLog> CreateTxLog(Models.Mark10Sqlexpress04.TxLog txLog)
        {
            OnTxLogCreated(txLog);

            Context.TxLogs.Add(txLog);
            Context.SaveChanges();

            OnAfterTxLogCreated(txLog);

            return txLog;
        }
        public async Task ExportTxSnosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/txsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/txsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTxSnosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/txsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/txsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTxSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.TxSno> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.TxSno>> GetTxSnos(Query query = null)
        {
            var items = Context.TxSnos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTxSnosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTxSnoCreated(Models.Mark10Sqlexpress04.TxSno item);
        partial void OnAfterTxSnoCreated(Models.Mark10Sqlexpress04.TxSno item);

        public async Task<Models.Mark10Sqlexpress04.TxSno> CreateTxSno(Models.Mark10Sqlexpress04.TxSno txSno)
        {
            OnTxSnoCreated(txSno);

            Context.TxSnos.Add(txSno);
            Context.SaveChanges();

            OnAfterTxSnoCreated(txSno);

            return txSno;
        }
        public async Task ExportUserLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/userlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/userlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/userlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/userlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserLogsRead(ref IQueryable<Models.Mark10Sqlexpress04.UserLog> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.UserLog>> GetUserLogs(Query query = null)
        {
            var items = Context.UserLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUserLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUserLogCreated(Models.Mark10Sqlexpress04.UserLog item);
        partial void OnAfterUserLogCreated(Models.Mark10Sqlexpress04.UserLog item);

        public async Task<Models.Mark10Sqlexpress04.UserLog> CreateUserLog(Models.Mark10Sqlexpress04.UserLog userLog)
        {
            OnUserLogCreated(userLog);

            Context.UserLogs.Add(userLog);
            Context.SaveChanges();

            OnAfterUserLogCreated(userLog);

            return userLog;
        }
        public async Task ExportUserMstsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/usermsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/usermsts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserMstsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/usermsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/usermsts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserMstsRead(ref IQueryable<Models.Mark10Sqlexpress04.UserMst> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.UserMst>> GetUserMsts(Query query = null)
        {
            var items = Context.UserMsts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUserMstsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUserMstCreated(Models.Mark10Sqlexpress04.UserMst item);
        partial void OnAfterUserMstCreated(Models.Mark10Sqlexpress04.UserMst item);

        public async Task<Models.Mark10Sqlexpress04.UserMst> CreateUserMst(Models.Mark10Sqlexpress04.UserMst userMst)
        {
            OnUserMstCreated(userMst);

            Context.UserMsts.Add(userMst);
            Context.SaveChanges();

            OnAfterUserMstCreated(userMst);

            return userMst;
        }
        public async Task ExportUserMstHisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/usermsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/usermsthis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserMstHisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/usermsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/usermsthis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserMstHisRead(ref IQueryable<Models.Mark10Sqlexpress04.UserMstHi> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.UserMstHi>> GetUserMstHis(Query query = null)
        {
            var items = Context.UserMstHis.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUserMstHisRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportVTableListsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vtablelists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vtablelists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVTableListsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vtablelists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vtablelists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVTableListsRead(ref IQueryable<Models.Mark10Sqlexpress04.VTableList> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.VTableList>> GetVTableLists(Query query = null)
        {
            var items = Context.VTableLists.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnVTableListsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportVUserProgByGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vuserprogbygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vuserprogbygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVUserProgByGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vuserprogbygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vuserprogbygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVUserProgByGroupsRead(ref IQueryable<Models.Mark10Sqlexpress04.VUserProgByGroup> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.VUserProgByGroup>> GetVUserProgByGroups(Query query = null)
        {
            var items = Context.VUserProgByGroups.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnVUserProgByGroupsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportVUserRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vuserroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vuserroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVUserRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vuserroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vuserroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVUserRolesRead(ref IQueryable<Models.Mark10Sqlexpress04.VUserRole> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.VUserRole>> GetVUserRoles(Query query = null)
        {
            var items = Context.VUserRoles.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnVUserRolesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportVr030SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr030s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr030s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVr030SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr030s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr030s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVr030sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vr030> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr030>> GetVr030S(Query query = null)
        {
            var items = Context.Vr030s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnVr030sRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportXxxesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/xxxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/xxxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportXxxesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/xxxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/xxxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnXxxesRead(ref IQueryable<Models.Mark10Sqlexpress04.Xxx> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Xxx>> GetXxxes(Query query = null)
        {
            var items = Context.Xxxes.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnXxxesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAlarmDefDeleted(Models.Mark10Sqlexpress04.AlarmDef item);
        partial void OnAfterAlarmDefDeleted(Models.Mark10Sqlexpress04.AlarmDef item);

        public async Task<Models.Mark10Sqlexpress04.AlarmDef> DeleteAlarmDef(string alarmCode)
        {
            var itemToDelete = Context.AlarmDefs
                              .Where(i => i.AlarmCode == alarmCode)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAlarmDefDeleted(itemToDelete);

            Context.AlarmDefs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAlarmDefDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAlarmDefGet(Models.Mark10Sqlexpress04.AlarmDef item);

        public async Task<Models.Mark10Sqlexpress04.AlarmDef> GetAlarmDefByAlarmCode(string alarmCode)
        {
            var items = Context.AlarmDefs
                              .AsNoTracking()
                              .Where(i => i.AlarmCode == alarmCode);

            var itemToReturn = items.FirstOrDefault();

            OnAlarmDefGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.AlarmDef> CancelAlarmDefChanges(Models.Mark10Sqlexpress04.AlarmDef item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnAlarmDefUpdated(Models.Mark10Sqlexpress04.AlarmDef item);
        partial void OnAfterAlarmDefUpdated(Models.Mark10Sqlexpress04.AlarmDef item);

        public async Task<Models.Mark10Sqlexpress04.AlarmDef> UpdateAlarmDef(string alarmCode, Models.Mark10Sqlexpress04.AlarmDef alarmDef)
        {
            OnAlarmDefUpdated(alarmDef);

            var itemToUpdate = Context.AlarmDefs
                              .Where(i => i.AlarmCode == alarmCode)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(alarmDef);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterAlarmDefUpdated(alarmDef);

            return alarmDef;
        }

        partial void OnAlarmLogDeleted(Models.Mark10Sqlexpress04.AlarmLog item);
        partial void OnAfterAlarmLogDeleted(Models.Mark10Sqlexpress04.AlarmLog item);

        public async Task<Models.Mark10Sqlexpress04.AlarmLog> DeleteAlarmLog(string equNo, string alarmCode, string strdt)
        {
            var itemToDelete = Context.AlarmLogs
                              .Where(i => i.EquNo == equNo && i.AlarmCode == alarmCode && i.STRDT == strdt)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAlarmLogDeleted(itemToDelete);

            Context.AlarmLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAlarmLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAlarmLogGet(Models.Mark10Sqlexpress04.AlarmLog item);

        public async Task<Models.Mark10Sqlexpress04.AlarmLog> GetAlarmLogByEquNoAndAlarmCodeAndStrdt(string equNo, string alarmCode, string strdt)
        {
            var items = Context.AlarmLogs
                              .AsNoTracking()
                              .Where(i => i.EquNo == equNo && i.AlarmCode == alarmCode && i.STRDT == strdt);

            var itemToReturn = items.FirstOrDefault();

            OnAlarmLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.AlarmLog> CancelAlarmLogChanges(Models.Mark10Sqlexpress04.AlarmLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnAlarmLogUpdated(Models.Mark10Sqlexpress04.AlarmLog item);
        partial void OnAfterAlarmLogUpdated(Models.Mark10Sqlexpress04.AlarmLog item);

        public async Task<Models.Mark10Sqlexpress04.AlarmLog> UpdateAlarmLog(string equNo, string alarmCode, string strdt, Models.Mark10Sqlexpress04.AlarmLog alarmLog)
        {
            OnAlarmLogUpdated(alarmLog);

            var itemToUpdate = Context.AlarmLogs
                              .Where(i => i.EquNo == equNo && i.AlarmCode == alarmCode && i.STRDT == strdt)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(alarmLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterAlarmLogUpdated(alarmLog);

            return alarmLog;
        }

        partial void OnCmdMstDeleted(Models.Mark10Sqlexpress04.CmdMst item);
        partial void OnAfterCmdMstDeleted(Models.Mark10Sqlexpress04.CmdMst item);

        public async Task<Models.Mark10Sqlexpress04.CmdMst> DeleteCmdMst(string cmdDate, string cmdSno)
        {
            var itemToDelete = Context.CmdMsts
                              .Where(i => i.CMD_DATE == cmdDate && i.CMD_SNO == cmdSno)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCmdMstDeleted(itemToDelete);

            Context.CmdMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCmdMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCmdMstGet(Models.Mark10Sqlexpress04.CmdMst item);

        public async Task<Models.Mark10Sqlexpress04.CmdMst> GetCmdMstByCmdDateAndCmdSno(string cmdDate, string cmdSno)
        {
            var items = Context.CmdMsts
                              .AsNoTracking()
                              .Where(i => i.CMD_DATE == cmdDate && i.CMD_SNO == cmdSno);

            var itemToReturn = items.FirstOrDefault();

            OnCmdMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.CmdMst> CancelCmdMstChanges(Models.Mark10Sqlexpress04.CmdMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCmdMstUpdated(Models.Mark10Sqlexpress04.CmdMst item);
        partial void OnAfterCmdMstUpdated(Models.Mark10Sqlexpress04.CmdMst item);

        public async Task<Models.Mark10Sqlexpress04.CmdMst> UpdateCmdMst(string cmdDate, string cmdSno, Models.Mark10Sqlexpress04.CmdMst cmdMst)
        {
            OnCmdMstUpdated(cmdMst);

            var itemToUpdate = Context.CmdMsts
                              .Where(i => i.CMD_DATE == cmdDate && i.CMD_SNO == cmdSno)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cmdMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterCmdMstUpdated(cmdMst);

            return cmdMst;
        }

        partial void OnCtrlHDeleted(Models.Mark10Sqlexpress04.CtrlH item);
        partial void OnAfterCtrlHDeleted(Models.Mark10Sqlexpress04.CtrlH item);

        public async Task<Models.Mark10Sqlexpress04.CtrlH> DeleteCtrlH(string equNo)
        {
            var itemToDelete = Context.CtrlHs
                              .Where(i => i.EquNo == equNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCtrlHDeleted(itemToDelete);

            Context.CtrlHs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCtrlHDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCtrlHGet(Models.Mark10Sqlexpress04.CtrlH item);

        public async Task<Models.Mark10Sqlexpress04.CtrlH> GetCtrlHByEquNo(string equNo)
        {
            var items = Context.CtrlHs
                              .AsNoTracking()
                              .Where(i => i.EquNo == equNo);

            var itemToReturn = items.FirstOrDefault();

            OnCtrlHGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.CtrlH> CancelCtrlHChanges(Models.Mark10Sqlexpress04.CtrlH item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCtrlHUpdated(Models.Mark10Sqlexpress04.CtrlH item);
        partial void OnAfterCtrlHUpdated(Models.Mark10Sqlexpress04.CtrlH item);

        public async Task<Models.Mark10Sqlexpress04.CtrlH> UpdateCtrlH(string equNo, Models.Mark10Sqlexpress04.CtrlH ctrlH)
        {
            OnCtrlHUpdated(ctrlH);

            var itemToUpdate = Context.CtrlHs
                              .Where(i => i.EquNo == equNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(ctrlH);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterCtrlHUpdated(ctrlH);

            return ctrlH;
        }

        partial void OnEquCmdDeleted(Models.Mark10Sqlexpress04.EquCmd item);
        partial void OnAfterEquCmdDeleted(Models.Mark10Sqlexpress04.EquCmd item);

        public async Task<Models.Mark10Sqlexpress04.EquCmd> DeleteEquCmd(string cmdSno, string equNo, string cmdMode, string source)
        {
            var itemToDelete = Context.EquCmds
                              .Where(i => i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode && i.Source == source)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquCmdDeleted(itemToDelete);

            Context.EquCmds.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquCmdDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquCmdGet(Models.Mark10Sqlexpress04.EquCmd item);

        public async Task<Models.Mark10Sqlexpress04.EquCmd> GetEquCmdByCmdSnoAndEquNoAndCmdModeAndSource(string cmdSno, string equNo, string cmdMode, string source)
        {
            var items = Context.EquCmds
                              .AsNoTracking()
                              .Where(i => i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode && i.Source == source);

            var itemToReturn = items.FirstOrDefault();

            OnEquCmdGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquCmd> CancelEquCmdChanges(Models.Mark10Sqlexpress04.EquCmd item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquCmdUpdated(Models.Mark10Sqlexpress04.EquCmd item);
        partial void OnAfterEquCmdUpdated(Models.Mark10Sqlexpress04.EquCmd item);

        public async Task<Models.Mark10Sqlexpress04.EquCmd> UpdateEquCmd(string cmdSno, string equNo, string cmdMode, string source, Models.Mark10Sqlexpress04.EquCmd equCmd)
        {
            OnEquCmdUpdated(equCmd);

            var itemToUpdate = Context.EquCmds
                              .Where(i => i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode && i.Source == source)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equCmd);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquCmdUpdated(equCmd);

            return equCmd;
        }

        partial void OnEquCmdDetailLogDeleted(Models.Mark10Sqlexpress04.EquCmdDetailLog item);
        partial void OnAfterEquCmdDetailLogDeleted(Models.Mark10Sqlexpress04.EquCmdDetailLog item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdDetailLog> DeleteEquCmdDetailLog(string logDt, string cmdSno, string equNo, string cmdMode)
        {
            var itemToDelete = Context.EquCmdDetailLogs
                              .Where(i => i.LogDT == logDt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquCmdDetailLogDeleted(itemToDelete);

            Context.EquCmdDetailLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquCmdDetailLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquCmdDetailLogGet(Models.Mark10Sqlexpress04.EquCmdDetailLog item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdDetailLog> GetEquCmdDetailLogByLogDtAndCmdSnoAndEquNoAndCmdMode(string logDt, string cmdSno, string equNo, string cmdMode)
        {
            var items = Context.EquCmdDetailLogs
                              .AsNoTracking()
                              .Where(i => i.LogDT == logDt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode);

            var itemToReturn = items.FirstOrDefault();

            OnEquCmdDetailLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquCmdDetailLog> CancelEquCmdDetailLogChanges(Models.Mark10Sqlexpress04.EquCmdDetailLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquCmdDetailLogUpdated(Models.Mark10Sqlexpress04.EquCmdDetailLog item);
        partial void OnAfterEquCmdDetailLogUpdated(Models.Mark10Sqlexpress04.EquCmdDetailLog item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdDetailLog> UpdateEquCmdDetailLog(string logDt, string cmdSno, string equNo, string cmdMode, Models.Mark10Sqlexpress04.EquCmdDetailLog equCmdDetailLog)
        {
            OnEquCmdDetailLogUpdated(equCmdDetailLog);

            var itemToUpdate = Context.EquCmdDetailLogs
                              .Where(i => i.LogDT == logDt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equCmdDetailLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquCmdDetailLogUpdated(equCmdDetailLog);

            return equCmdDetailLog;
        }

        partial void OnEquCmdHiDeleted(Models.Mark10Sqlexpress04.EquCmdHi item);
        partial void OnAfterEquCmdHiDeleted(Models.Mark10Sqlexpress04.EquCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdHi> DeleteEquCmdHi(string hisdt, string cmdSno, string equNo, string cmdMode, string source)
        {
            var itemToDelete = Context.EquCmdHis
                              .Where(i => i.HISDT == hisdt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode && i.Source == source)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquCmdHiDeleted(itemToDelete);

            Context.EquCmdHis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquCmdHiDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquCmdHiGet(Models.Mark10Sqlexpress04.EquCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdHi> GetEquCmdHiByHisdtAndCmdSnoAndEquNoAndCmdModeAndSource(string hisdt, string cmdSno, string equNo, string cmdMode, string source)
        {
            var items = Context.EquCmdHis
                              .AsNoTracking()
                              .Where(i => i.HISDT == hisdt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode && i.Source == source);

            var itemToReturn = items.FirstOrDefault();

            OnEquCmdHiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquCmdHi> CancelEquCmdHiChanges(Models.Mark10Sqlexpress04.EquCmdHi item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquCmdHiUpdated(Models.Mark10Sqlexpress04.EquCmdHi item);
        partial void OnAfterEquCmdHiUpdated(Models.Mark10Sqlexpress04.EquCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquCmdHi> UpdateEquCmdHi(string hisdt, string cmdSno, string equNo, string cmdMode, string source, Models.Mark10Sqlexpress04.EquCmdHi equCmdHi)
        {
            OnEquCmdHiUpdated(equCmdHi);

            var itemToUpdate = Context.EquCmdHis
                              .Where(i => i.HISDT == hisdt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode && i.Source == source)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equCmdHi);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquCmdHiUpdated(equCmdHi);

            return equCmdHi;
        }

        partial void OnEquCodeDefDeleted(Models.Mark10Sqlexpress04.EquCodeDef item);
        partial void OnAfterEquCodeDefDeleted(Models.Mark10Sqlexpress04.EquCodeDef item);

        public async Task<Models.Mark10Sqlexpress04.EquCodeDef> DeleteEquCodeDef(string codeType, string code)
        {
            var itemToDelete = Context.EquCodeDefs
                              .Where(i => i.CodeType == codeType && i.Code == code)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquCodeDefDeleted(itemToDelete);

            Context.EquCodeDefs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquCodeDefDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquCodeDefGet(Models.Mark10Sqlexpress04.EquCodeDef item);

        public async Task<Models.Mark10Sqlexpress04.EquCodeDef> GetEquCodeDefByCodeTypeAndCode(string codeType, string code)
        {
            var items = Context.EquCodeDefs
                              .AsNoTracking()
                              .Where(i => i.CodeType == codeType && i.Code == code);

            var itemToReturn = items.FirstOrDefault();

            OnEquCodeDefGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquCodeDef> CancelEquCodeDefChanges(Models.Mark10Sqlexpress04.EquCodeDef item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquCodeDefUpdated(Models.Mark10Sqlexpress04.EquCodeDef item);
        partial void OnAfterEquCodeDefUpdated(Models.Mark10Sqlexpress04.EquCodeDef item);

        public async Task<Models.Mark10Sqlexpress04.EquCodeDef> UpdateEquCodeDef(string codeType, string code, Models.Mark10Sqlexpress04.EquCodeDef equCodeDef)
        {
            OnEquCodeDefUpdated(equCodeDef);

            var itemToUpdate = Context.EquCodeDefs
                              .Where(i => i.CodeType == codeType && i.Code == code)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equCodeDef);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquCodeDefUpdated(equCodeDef);

            return equCodeDef;
        }

        partial void OnEquModeLogDeleted(Models.Mark10Sqlexpress04.EquModeLog item);
        partial void OnAfterEquModeLogDeleted(Models.Mark10Sqlexpress04.EquModeLog item);

        public async Task<Models.Mark10Sqlexpress04.EquModeLog> DeleteEquModeLog(string equNo, string carNo, string strDt, string equMode)
        {
            var itemToDelete = Context.EquModeLogs
                              .Where(i => i.EquNo == equNo && i.CarNo == carNo && i.StrDT == strDt && i.EquMode == equMode)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquModeLogDeleted(itemToDelete);

            Context.EquModeLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquModeLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquModeLogGet(Models.Mark10Sqlexpress04.EquModeLog item);

        public async Task<Models.Mark10Sqlexpress04.EquModeLog> GetEquModeLogByEquNoAndCarNoAndStrDtAndEquMode(string equNo, string carNo, string strDt, string equMode)
        {
            var items = Context.EquModeLogs
                              .AsNoTracking()
                              .Where(i => i.EquNo == equNo && i.CarNo == carNo && i.StrDT == strDt && i.EquMode == equMode);

            var itemToReturn = items.FirstOrDefault();

            OnEquModeLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquModeLog> CancelEquModeLogChanges(Models.Mark10Sqlexpress04.EquModeLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquModeLogUpdated(Models.Mark10Sqlexpress04.EquModeLog item);
        partial void OnAfterEquModeLogUpdated(Models.Mark10Sqlexpress04.EquModeLog item);

        public async Task<Models.Mark10Sqlexpress04.EquModeLog> UpdateEquModeLog(string equNo, string carNo, string strDt, string equMode, Models.Mark10Sqlexpress04.EquModeLog equModeLog)
        {
            OnEquModeLogUpdated(equModeLog);

            var itemToUpdate = Context.EquModeLogs
                              .Where(i => i.EquNo == equNo && i.CarNo == carNo && i.StrDT == strDt && i.EquMode == equMode)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equModeLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquModeLogUpdated(equModeLog);

            return equModeLog;
        }

        partial void OnEquMplcCmdHiDeleted(Models.Mark10Sqlexpress04.EquMplcCmdHi item);
        partial void OnAfterEquMplcCmdHiDeleted(Models.Mark10Sqlexpress04.EquMplcCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquMplcCmdHi> DeleteEquMplcCmdHi(string equNo, string d0, string d1, string d14, string logDt)
        {
            var itemToDelete = Context.EquMplcCmdHis
                              .Where(i => i.EquNo == equNo && i.D0 == d0 && i.D1 == d1 && i.D14 == d14 && i.LogDT == logDt)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquMplcCmdHiDeleted(itemToDelete);

            Context.EquMplcCmdHis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquMplcCmdHiDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquMplcCmdHiGet(Models.Mark10Sqlexpress04.EquMplcCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquMplcCmdHi> GetEquMplcCmdHiByEquNoAndD0AndD1AndD14AndLogDt(string equNo, string d0, string d1, string d14, string logDt)
        {
            var items = Context.EquMplcCmdHis
                              .AsNoTracking()
                              .Where(i => i.EquNo == equNo && i.D0 == d0 && i.D1 == d1 && i.D14 == d14 && i.LogDT == logDt);

            var itemToReturn = items.FirstOrDefault();

            OnEquMplcCmdHiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquMplcCmdHi> CancelEquMplcCmdHiChanges(Models.Mark10Sqlexpress04.EquMplcCmdHi item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquMplcCmdHiUpdated(Models.Mark10Sqlexpress04.EquMplcCmdHi item);
        partial void OnAfterEquMplcCmdHiUpdated(Models.Mark10Sqlexpress04.EquMplcCmdHi item);

        public async Task<Models.Mark10Sqlexpress04.EquMplcCmdHi> UpdateEquMplcCmdHi(string equNo, string d0, string d1, string d14, string logDt, Models.Mark10Sqlexpress04.EquMplcCmdHi equMplcCmdHi)
        {
            OnEquMplcCmdHiUpdated(equMplcCmdHi);

            var itemToUpdate = Context.EquMplcCmdHis
                              .Where(i => i.EquNo == equNo && i.D0 == d0 && i.D1 == d1 && i.D14 == d14 && i.LogDT == logDt)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equMplcCmdHi);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquMplcCmdHiUpdated(equMplcCmdHi);

            return equMplcCmdHi;
        }

        partial void OnEquPlcDatumDeleted(Models.Mark10Sqlexpress04.EquPlcDatum item);
        partial void OnAfterEquPlcDatumDeleted(Models.Mark10Sqlexpress04.EquPlcDatum item);

        public async Task<Models.Mark10Sqlexpress04.EquPlcDatum> DeleteEquPlcDatum(string equNo, string serialNo)
        {
            var itemToDelete = Context.EquPlcData
                              .Where(i => i.EquNo == equNo && i.SerialNo == serialNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquPlcDatumDeleted(itemToDelete);

            Context.EquPlcData.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquPlcDatumDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquPlcDatumGet(Models.Mark10Sqlexpress04.EquPlcDatum item);

        public async Task<Models.Mark10Sqlexpress04.EquPlcDatum> GetEquPlcDatumByEquNoAndSerialNo(string equNo, string serialNo)
        {
            var items = Context.EquPlcData
                              .AsNoTracking()
                              .Where(i => i.EquNo == equNo && i.SerialNo == serialNo);

            var itemToReturn = items.FirstOrDefault();

            OnEquPlcDatumGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquPlcDatum> CancelEquPlcDatumChanges(Models.Mark10Sqlexpress04.EquPlcDatum item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquPlcDatumUpdated(Models.Mark10Sqlexpress04.EquPlcDatum item);
        partial void OnAfterEquPlcDatumUpdated(Models.Mark10Sqlexpress04.EquPlcDatum item);

        public async Task<Models.Mark10Sqlexpress04.EquPlcDatum> UpdateEquPlcDatum(string equNo, string serialNo, Models.Mark10Sqlexpress04.EquPlcDatum equPlcDatum)
        {
            OnEquPlcDatumUpdated(equPlcDatum);

            var itemToUpdate = Context.EquPlcData
                              .Where(i => i.EquNo == equNo && i.SerialNo == serialNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equPlcDatum);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquPlcDatumUpdated(equPlcDatum);

            return equPlcDatum;
        }

        partial void OnEquStsLogDeleted(Models.Mark10Sqlexpress04.EquStsLog item);
        partial void OnAfterEquStsLogDeleted(Models.Mark10Sqlexpress04.EquStsLog item);

        public async Task<Models.Mark10Sqlexpress04.EquStsLog> DeleteEquStsLog(string equNo, string carNo, string strDt, string equSts)
        {
            var itemToDelete = Context.EquStsLogs
                              .Where(i => i.EquNo == equNo && i.CarNo == carNo && i.StrDT == strDt && i.EquSts == equSts)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquStsLogDeleted(itemToDelete);

            Context.EquStsLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquStsLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquStsLogGet(Models.Mark10Sqlexpress04.EquStsLog item);

        public async Task<Models.Mark10Sqlexpress04.EquStsLog> GetEquStsLogByEquNoAndCarNoAndStrDtAndEquSts(string equNo, string carNo, string strDt, string equSts)
        {
            var items = Context.EquStsLogs
                              .AsNoTracking()
                              .Where(i => i.EquNo == equNo && i.CarNo == carNo && i.StrDT == strDt && i.EquSts == equSts);

            var itemToReturn = items.FirstOrDefault();

            OnEquStsLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquStsLog> CancelEquStsLogChanges(Models.Mark10Sqlexpress04.EquStsLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquStsLogUpdated(Models.Mark10Sqlexpress04.EquStsLog item);
        partial void OnAfterEquStsLogUpdated(Models.Mark10Sqlexpress04.EquStsLog item);

        public async Task<Models.Mark10Sqlexpress04.EquStsLog> UpdateEquStsLog(string equNo, string carNo, string strDt, string equSts, Models.Mark10Sqlexpress04.EquStsLog equStsLog)
        {
            OnEquStsLogUpdated(equStsLog);

            var itemToUpdate = Context.EquStsLogs
                              .Where(i => i.EquNo == equNo && i.CarNo == carNo && i.StrDT == strDt && i.EquSts == equSts)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equStsLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquStsLogUpdated(equStsLog);

            return equStsLog;
        }

        partial void OnEquTrnLogDeleted(Models.Mark10Sqlexpress04.EquTrnLog item);
        partial void OnAfterEquTrnLogDeleted(Models.Mark10Sqlexpress04.EquTrnLog item);

        public async Task<Models.Mark10Sqlexpress04.EquTrnLog> DeleteEquTrnLog(string trnDt, string cmdSno, string equNo, string cmdMode)
        {
            var itemToDelete = Context.EquTrnLogs
                              .Where(i => i.TrnDT == trnDt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEquTrnLogDeleted(itemToDelete);

            Context.EquTrnLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEquTrnLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEquTrnLogGet(Models.Mark10Sqlexpress04.EquTrnLog item);

        public async Task<Models.Mark10Sqlexpress04.EquTrnLog> GetEquTrnLogByTrnDtAndCmdSnoAndEquNoAndCmdMode(string trnDt, string cmdSno, string equNo, string cmdMode)
        {
            var items = Context.EquTrnLogs
                              .AsNoTracking()
                              .Where(i => i.TrnDT == trnDt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode);

            var itemToReturn = items.FirstOrDefault();

            OnEquTrnLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.EquTrnLog> CancelEquTrnLogChanges(Models.Mark10Sqlexpress04.EquTrnLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEquTrnLogUpdated(Models.Mark10Sqlexpress04.EquTrnLog item);
        partial void OnAfterEquTrnLogUpdated(Models.Mark10Sqlexpress04.EquTrnLog item);

        public async Task<Models.Mark10Sqlexpress04.EquTrnLog> UpdateEquTrnLog(string trnDt, string cmdSno, string equNo, string cmdMode, Models.Mark10Sqlexpress04.EquTrnLog equTrnLog)
        {
            OnEquTrnLogUpdated(equTrnLog);

            var itemToUpdate = Context.EquTrnLogs
                              .Where(i => i.TrnDT == trnDt && i.CmdSno == cmdSno && i.EquNo == equNo && i.CmdMode == cmdMode)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(equTrnLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterEquTrnLogUpdated(equTrnLog);

            return equTrnLog;
        }

        partial void OnGroupDtlDeleted(Models.Mark10Sqlexpress04.GroupDtl item);
        partial void OnAfterGroupDtlDeleted(Models.Mark10Sqlexpress04.GroupDtl item);

        public async Task<Models.Mark10Sqlexpress04.GroupDtl> DeleteGroupDtl(string groupId, string userId)
        {
            var itemToDelete = Context.GroupDtls
                              .Where(i => i.GROUP_ID == groupId && i.USER_ID == userId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGroupDtlDeleted(itemToDelete);

            Context.GroupDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGroupDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnGroupDtlGet(Models.Mark10Sqlexpress04.GroupDtl item);

        public async Task<Models.Mark10Sqlexpress04.GroupDtl> GetGroupDtlByGroupIdAndUserId(string groupId, string userId)
        {
            var items = Context.GroupDtls
                              .AsNoTracking()
                              .Where(i => i.GROUP_ID == groupId && i.USER_ID == userId);

            var itemToReturn = items.FirstOrDefault();

            OnGroupDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.GroupDtl> CancelGroupDtlChanges(Models.Mark10Sqlexpress04.GroupDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnGroupDtlUpdated(Models.Mark10Sqlexpress04.GroupDtl item);
        partial void OnAfterGroupDtlUpdated(Models.Mark10Sqlexpress04.GroupDtl item);

        public async Task<Models.Mark10Sqlexpress04.GroupDtl> UpdateGroupDtl(string groupId, string userId, Models.Mark10Sqlexpress04.GroupDtl groupDtl)
        {
            OnGroupDtlUpdated(groupDtl);

            var itemToUpdate = Context.GroupDtls
                              .Where(i => i.GROUP_ID == groupId && i.USER_ID == userId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(groupDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterGroupDtlUpdated(groupDtl);

            return groupDtl;
        }

        partial void OnGroupMstDeleted(Models.Mark10Sqlexpress04.GroupMst item);
        partial void OnAfterGroupMstDeleted(Models.Mark10Sqlexpress04.GroupMst item);

        public async Task<Models.Mark10Sqlexpress04.GroupMst> DeleteGroupMst(string groupId)
        {
            var itemToDelete = Context.GroupMsts
                              .Where(i => i.GROUP_ID == groupId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGroupMstDeleted(itemToDelete);

            Context.GroupMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGroupMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnGroupMstGet(Models.Mark10Sqlexpress04.GroupMst item);

        public async Task<Models.Mark10Sqlexpress04.GroupMst> GetGroupMstByGroupId(string groupId)
        {
            var items = Context.GroupMsts
                              .AsNoTracking()
                              .Where(i => i.GROUP_ID == groupId);

            var itemToReturn = items.FirstOrDefault();

            OnGroupMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.GroupMst> CancelGroupMstChanges(Models.Mark10Sqlexpress04.GroupMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnGroupMstUpdated(Models.Mark10Sqlexpress04.GroupMst item);
        partial void OnAfterGroupMstUpdated(Models.Mark10Sqlexpress04.GroupMst item);

        public async Task<Models.Mark10Sqlexpress04.GroupMst> UpdateGroupMst(string groupId, Models.Mark10Sqlexpress04.GroupMst groupMst)
        {
            OnGroupMstUpdated(groupMst);




            var itemToUpdate = Context.GroupMsts
                              .Where(i => i.GROUP_ID == groupId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(groupMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterGroupMstUpdated(groupMst);

            return groupMst;
        }

        partial void OnGroupWrtDeleted(Models.Mark10Sqlexpress04.GroupWrt item);
        partial void OnAfterGroupWrtDeleted(Models.Mark10Sqlexpress04.GroupWrt item);

        public async Task<Models.Mark10Sqlexpress04.GroupWrt> DeleteGroupWrt(string groupId, string progId)
        {
            var itemToDelete = Context.GroupWrts
                              .Where(i => i.GROUP_ID == groupId && i.PROG_ID == progId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGroupWrtDeleted(itemToDelete);

            Context.GroupWrts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGroupWrtDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnGroupWrtGet(Models.Mark10Sqlexpress04.GroupWrt item);

        public async Task<Models.Mark10Sqlexpress04.GroupWrt> GetGroupWrtByGroupIdAndProgId(string groupId, string progId)
        {
            var items = Context.GroupWrts
                              .AsNoTracking()
                              .Where(i => i.GROUP_ID == groupId && i.PROG_ID == progId);

            var itemToReturn = items.FirstOrDefault();

            OnGroupWrtGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.GroupWrt> CancelGroupWrtChanges(Models.Mark10Sqlexpress04.GroupWrt item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnGroupWrtUpdated(Models.Mark10Sqlexpress04.GroupWrt item);
        partial void OnAfterGroupWrtUpdated(Models.Mark10Sqlexpress04.GroupWrt item);

        public async Task<Models.Mark10Sqlexpress04.GroupWrt> UpdateGroupWrt(string groupId, string progId, Models.Mark10Sqlexpress04.GroupWrt groupWrt)
        {
            OnGroupWrtUpdated(groupWrt);

            var itemToUpdate = Context.GroupWrts
                              .Where(i => i.GROUP_ID == groupId && i.PROG_ID == progId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(groupWrt);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterGroupWrtUpdated(groupWrt);

            return groupWrt;
        }

        partial void OnGtinMstDeleted(Models.Mark10Sqlexpress04.GtinMst item);
        partial void OnAfterGtinMstDeleted(Models.Mark10Sqlexpress04.GtinMst item);

        public async Task<Models.Mark10Sqlexpress04.GtinMst> DeleteGtinMst(string skuNo, string gtinUnit)
        {
            var itemToDelete = Context.GtinMsts
                              .Where(i => i.SKU_NO == skuNo && i.GTIN_UNIT == gtinUnit)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGtinMstDeleted(itemToDelete);

            Context.GtinMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGtinMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnGtinMstGet(Models.Mark10Sqlexpress04.GtinMst item);

        public async Task<Models.Mark10Sqlexpress04.GtinMst> GetGtinMstBySkuNoAndGtinUnit(string skuNo, string gtinUnit)
        {
            var items = Context.GtinMsts
                              .AsNoTracking()
                              .Where(i => i.SKU_NO == skuNo && i.GTIN_UNIT == gtinUnit);

            var itemToReturn = items.FirstOrDefault();

            OnGtinMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.GtinMst> CancelGtinMstChanges(Models.Mark10Sqlexpress04.GtinMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnGtinMstUpdated(Models.Mark10Sqlexpress04.GtinMst item);
        partial void OnAfterGtinMstUpdated(Models.Mark10Sqlexpress04.GtinMst item);

        public async Task<Models.Mark10Sqlexpress04.GtinMst> UpdateGtinMst(string skuNo, string gtinUnit, Models.Mark10Sqlexpress04.GtinMst gtinMst)
        {
            OnGtinMstUpdated(gtinMst);

            var itemToUpdate = Context.GtinMsts
                              .Where(i => i.SKU_NO == skuNo && i.GTIN_UNIT == gtinUnit)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(gtinMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterGtinMstUpdated(gtinMst);

            return gtinMst;
        }

        partial void OnInDtlDeleted(Models.Mark10Sqlexpress04.InDtl item);
        partial void OnAfterInDtlDeleted(Models.Mark10Sqlexpress04.InDtl item);

        public async Task<Models.Mark10Sqlexpress04.InDtl> DeleteInDtl(string whseNo, string inNo, string inLine)
        {
            var itemToDelete = Context.InDtls
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInDtlDeleted(itemToDelete);

            Context.InDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInDtlGet(Models.Mark10Sqlexpress04.InDtl item);

        public async Task<Models.Mark10Sqlexpress04.InDtl> GetInDtlByWhseNoAndInNoAndInLine(string whseNo, string inNo, string inLine)
        {
            var items = Context.InDtls
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine);

            var itemToReturn = items.FirstOrDefault();

            OnInDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.InDtl> CancelInDtlChanges(Models.Mark10Sqlexpress04.InDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnInDtlUpdated(Models.Mark10Sqlexpress04.InDtl item);
        partial void OnAfterInDtlUpdated(Models.Mark10Sqlexpress04.InDtl item);

        public async Task<Models.Mark10Sqlexpress04.InDtl> UpdateInDtl(string whseNo, string inNo, string inLine, Models.Mark10Sqlexpress04.InDtl inDtl)
        {
            OnInDtlUpdated(inDtl);

            var itemToUpdate = Context.InDtls
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(inDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterInDtlUpdated(inDtl);

            return inDtl;
        }

        partial void OnInSnoDeleted(Models.Mark10Sqlexpress04.InSno item);
        partial void OnAfterInSnoDeleted(Models.Mark10Sqlexpress04.InSno item);

        public async Task<Models.Mark10Sqlexpress04.InSno> DeleteInSno(string whseNo, string inNo, string inLine, string suId, string inSno1)
        {
            var itemToDelete = Context.InSnos
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine && i.SU_ID == suId && i.IN_SNO1 == inSno1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInSnoDeleted(itemToDelete);

            Context.InSnos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInSnoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInSnoGet(Models.Mark10Sqlexpress04.InSno item);

        public async Task<Models.Mark10Sqlexpress04.InSno> GetInSnoByWhseNoAndInNoAndInLineAndSuIdAndInSno1(string whseNo, string inNo, string inLine, string suId, string inSno1)
        {
            var items = Context.InSnos
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine && i.SU_ID == suId && i.IN_SNO1 == inSno1);

            var itemToReturn = items.FirstOrDefault();

            OnInSnoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.InSno> CancelInSnoChanges(Models.Mark10Sqlexpress04.InSno item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnInSnoUpdated(Models.Mark10Sqlexpress04.InSno item);
        partial void OnAfterInSnoUpdated(Models.Mark10Sqlexpress04.InSno item);

        public async Task<Models.Mark10Sqlexpress04.InSno> UpdateInSno(string whseNo, string inNo, string inLine, string suId, string inSno1, Models.Mark10Sqlexpress04.InSno inSno)
        {
            OnInSnoUpdated(inSno);

            var itemToUpdate = Context.InSnos
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine && i.SU_ID == suId && i.IN_SNO1 == inSno1)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(inSno);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterInSnoUpdated(inSno);

            return inSno;
        }

        partial void OnInSnoHiDeleted(Models.Mark10Sqlexpress04.InSnoHi item);
        partial void OnAfterInSnoHiDeleted(Models.Mark10Sqlexpress04.InSnoHi item);

        public async Task<Models.Mark10Sqlexpress04.InSnoHi> DeleteInSnoHi(string inSno, string logDate)
        {
            var itemToDelete = Context.InSnoHis
                              .Where(i => i.IN_SNO == inSno && i.LOG_DATE == logDate)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInSnoHiDeleted(itemToDelete);

            Context.InSnoHis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInSnoHiDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInSnoHiGet(Models.Mark10Sqlexpress04.InSnoHi item);

        public async Task<Models.Mark10Sqlexpress04.InSnoHi> GetInSnoHiByInSnoAndLogDate(string inSno, string logDate)
        {
            var items = Context.InSnoHis
                              .AsNoTracking()
                              .Where(i => i.IN_SNO == inSno && i.LOG_DATE == logDate);

            var itemToReturn = items.FirstOrDefault();

            OnInSnoHiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.InSnoHi> CancelInSnoHiChanges(Models.Mark10Sqlexpress04.InSnoHi item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnInSnoHiUpdated(Models.Mark10Sqlexpress04.InSnoHi item);
        partial void OnAfterInSnoHiUpdated(Models.Mark10Sqlexpress04.InSnoHi item);

        public async Task<Models.Mark10Sqlexpress04.InSnoHi> UpdateInSnoHi(string inSno, string logDate, Models.Mark10Sqlexpress04.InSnoHi inSnoHi)
        {
            OnInSnoHiUpdated(inSnoHi);

            var itemToUpdate = Context.InSnoHis
                              .Where(i => i.IN_SNO == inSno && i.LOG_DATE == logDate)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(inSnoHi);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterInSnoHiUpdated(inSnoHi);

            return inSnoHi;
        }

        partial void OnLocDtlDeleted(Models.Mark10Sqlexpress04.LocDtl item);
        partial void OnAfterLocDtlDeleted(Models.Mark10Sqlexpress04.LocDtl item);

        public async Task<Models.Mark10Sqlexpress04.LocDtl> DeleteLocDtl(string whseNo, string suId, string plant, string stgeLoc, string skuNo, string batchNo, string stkCat, string stkSpecialInd, string stkSpecialNo, string gtinUnit)
        {
            var itemToDelete = Context.LocDtls
                              .Where(i => i.WHSE_NO == whseNo && i.SU_ID == suId && i.PLANT == plant && i.STGE_LOC == stgeLoc && i.SKU_NO == skuNo && i.BATCH_NO == batchNo && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo && i.GTIN_UNIT == gtinUnit)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLocDtlDeleted(itemToDelete);

            Context.LocDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLocDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnLocDtlGet(Models.Mark10Sqlexpress04.LocDtl item);

        public async Task<Models.Mark10Sqlexpress04.LocDtl> GetLocDtlByWhseNoAndSuIdAndPlantAndStgeLocAndSkuNoAndBatchNoAndStkCatAndStkSpecialIndAndStkSpecialNoAndGtinUnit(string whseNo, string suId, string plant, string stgeLoc, string skuNo, string batchNo, string stkCat, string stkSpecialInd, string stkSpecialNo, string gtinUnit)
        {
            var items = Context.LocDtls
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.SU_ID == suId && i.PLANT == plant && i.STGE_LOC == stgeLoc && i.SKU_NO == skuNo && i.BATCH_NO == batchNo && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo && i.GTIN_UNIT == gtinUnit);

            var itemToReturn = items.FirstOrDefault();

            OnLocDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.LocDtl> CancelLocDtlChanges(Models.Mark10Sqlexpress04.LocDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnLocDtlUpdated(Models.Mark10Sqlexpress04.LocDtl item);
        partial void OnAfterLocDtlUpdated(Models.Mark10Sqlexpress04.LocDtl item);

        public async Task<Models.Mark10Sqlexpress04.LocDtl> UpdateLocDtl(string whseNo, string suId, string plant, string stgeLoc, string skuNo, string batchNo, string stkCat, string stkSpecialInd, string stkSpecialNo, string gtinUnit, Models.Mark10Sqlexpress04.LocDtl locDtl)
        {
            OnLocDtlUpdated(locDtl);

            var itemToUpdate = Context.LocDtls
                              .Where(i => i.WHSE_NO == whseNo && i.SU_ID == suId && i.PLANT == plant && i.STGE_LOC == stgeLoc && i.SKU_NO == skuNo && i.BATCH_NO == batchNo && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo && i.GTIN_UNIT == gtinUnit)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(locDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterLocDtlUpdated(locDtl);

            return locDtl;
        }

        //public async Task<Models.Mark10Sqlexpress04.LocDtl> UpdateLocDtl_P080( string stkCat, string remarks, Models.Mark10Sqlexpress04.LocDtl locDtl)
        //{
        //    OnLocDtlUpdated(locDtl);

        //    var itemToUpdate = Context.LocDtls
        //                      .Where(i => i.WHSE_NO == whseNo && i.SU_ID == suId && i.PLANT == plant && i.STGE_LOC == stgeLoc && i.SKU_NO == skuNo && i.BATCH_NO == batchNo && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo && i.GTIN_UNIT == gtinUnit)
        //                      .FirstOrDefault();
        //    if (itemToUpdate == null)
        //    {
        //        throw new Exception("Item no longer available");
        //    }
        //    var entryToUpdate = Context.Entry(itemToUpdate);
        //    entryToUpdate.CurrentValues.SetValues(locDtl);
        //    entryToUpdate.State = EntityState.Modified;
        //    Context.SaveChanges();

        //    OnAfterLocDtlUpdated(locDtl);

        //    return locDtl;
        //}


        partial void OnLocMstDeleted(Models.Mark10Sqlexpress04.LocMst item);
        partial void OnAfterLocMstDeleted(Models.Mark10Sqlexpress04.LocMst item);

        public async Task<Models.Mark10Sqlexpress04.LocMst> DeleteLocMst(string whseNo, string locNo, string zoneNo)
        {
            var itemToDelete = Context.LocMsts
                              .Where(i => i.WHSE_NO == whseNo && i.LOC_NO == locNo && i.ZONE_NO == zoneNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLocMstDeleted(itemToDelete);

            Context.LocMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLocMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnLocMstGet(Models.Mark10Sqlexpress04.LocMst item);

        public async Task<Models.Mark10Sqlexpress04.LocMst> GetLocMstByWhseNoAndLocNoAndZoneNo(string whseNo, string locNo, string zoneNo)
        {
            var items = Context.LocMsts
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.LOC_NO == locNo && i.ZONE_NO == zoneNo);

            var itemToReturn = items.FirstOrDefault();

            OnLocMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.LocMst> CancelLocMstChanges(Models.Mark10Sqlexpress04.LocMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnLocMstUpdated(Models.Mark10Sqlexpress04.LocMst item);
        partial void OnAfterLocMstUpdated(Models.Mark10Sqlexpress04.LocMst item);

        public async Task<Models.Mark10Sqlexpress04.LocMst> UpdateLocMst(string whseNo, string locNo, string zoneNo, Models.Mark10Sqlexpress04.LocMst locMst)
        {
            OnLocMstUpdated(locMst);

            var itemToUpdate = Context.LocMsts
                              .Where(i => i.WHSE_NO == whseNo && i.LOC_NO == locNo && i.ZONE_NO == zoneNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(locMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterLocMstUpdated(locMst);

            return locMst;
        }

        partial void OnMsgLangDeleted(Models.Mark10Sqlexpress04.MsgLang item);
        partial void OnAfterMsgLangDeleted(Models.Mark10Sqlexpress04.MsgLang item);

        public async Task<Models.Mark10Sqlexpress04.MsgLang> DeleteMsgLang(string msgId, string language)
        {
            var itemToDelete = Context.MsgLangs
                              .Where(i => i.MSG_ID == msgId && i.LANGUAGE == language)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMsgLangDeleted(itemToDelete);

            Context.MsgLangs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMsgLangDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnMsgLangGet(Models.Mark10Sqlexpress04.MsgLang item);

        public async Task<Models.Mark10Sqlexpress04.MsgLang> GetMsgLangByMsgIdAndLanguage(string msgId, string language)
        {
            var items = Context.MsgLangs
                              .AsNoTracking()
                              .Where(i => i.MSG_ID == msgId && i.LANGUAGE == language);

            var itemToReturn = items.FirstOrDefault();

            OnMsgLangGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.MsgLang> CancelMsgLangChanges(Models.Mark10Sqlexpress04.MsgLang item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnMsgLangUpdated(Models.Mark10Sqlexpress04.MsgLang item);
        partial void OnAfterMsgLangUpdated(Models.Mark10Sqlexpress04.MsgLang item);

        public async Task<Models.Mark10Sqlexpress04.MsgLang> UpdateMsgLang(string msgId, string language, Models.Mark10Sqlexpress04.MsgLang msgLang)
        {
            OnMsgLangUpdated(msgLang);

            var itemToUpdate = Context.MsgLangs
                              .Where(i => i.MSG_ID == msgId && i.LANGUAGE == language)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(msgLang);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterMsgLangUpdated(msgLang);

            return msgLang;
        }

        partial void OnOutDtlDeleted(Models.Mark10Sqlexpress04.OutDtl item);
        partial void OnAfterOutDtlDeleted(Models.Mark10Sqlexpress04.OutDtl item);

        public async Task<Models.Mark10Sqlexpress04.OutDtl> DeleteOutDtl(string whseNo, string outNo, string outLine)
        {
            var itemToDelete = Context.OutDtls
                              .Where(i => i.WHSE_NO == whseNo && i.OUT_NO == outNo && i.OUT_LINE == outLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOutDtlDeleted(itemToDelete);

            Context.OutDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOutDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnOutDtlGet(Models.Mark10Sqlexpress04.OutDtl item);

        public async Task<Models.Mark10Sqlexpress04.OutDtl> GetOutDtlByWhseNoAndOutNoAndOutLine(string whseNo, string outNo, string outLine)
        {
            var items = Context.OutDtls
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.OUT_NO == outNo && i.OUT_LINE == outLine);

            var itemToReturn = items.FirstOrDefault();

            OnOutDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.OutDtl> CancelOutDtlChanges(Models.Mark10Sqlexpress04.OutDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnOutDtlUpdated(Models.Mark10Sqlexpress04.OutDtl item);
        partial void OnAfterOutDtlUpdated(Models.Mark10Sqlexpress04.OutDtl item);

        public async Task<Models.Mark10Sqlexpress04.OutDtl> UpdateOutDtl(string whseNo, string outNo, string outLine, Models.Mark10Sqlexpress04.OutDtl outDtl)
        {
            OnOutDtlUpdated(outDtl);

            var itemToUpdate = Context.OutDtls
                              .Where(i => i.WHSE_NO == whseNo && i.OUT_NO == outNo && i.OUT_LINE == outLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(outDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterOutDtlUpdated(outDtl);

            return outDtl;
        }

        partial void OnOutMstDeleted(Models.Mark10Sqlexpress04.OutMst item);
        partial void OnAfterOutMstDeleted(Models.Mark10Sqlexpress04.OutMst item);

        public async Task<Models.Mark10Sqlexpress04.OutMst> DeleteOutMst(string whseNo, string outNo)
        {
            var itemToDelete = Context.OutMsts
                              .Where(i => i.WHSE_NO == whseNo && i.OUT_NO == outNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOutMstDeleted(itemToDelete);

            Context.OutMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOutMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnOutMstGet(Models.Mark10Sqlexpress04.OutMst item);

        public async Task<Models.Mark10Sqlexpress04.OutMst> GetOutMstByWhseNoAndOutNo(string whseNo, string outNo)
        {
            var items = Context.OutMsts
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.OUT_NO == outNo);

            var itemToReturn = items.FirstOrDefault();

            OnOutMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.OutMst> CancelOutMstChanges(Models.Mark10Sqlexpress04.OutMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnOutMstUpdated(Models.Mark10Sqlexpress04.OutMst item);
        partial void OnAfterOutMstUpdated(Models.Mark10Sqlexpress04.OutMst item);

        public async Task<Models.Mark10Sqlexpress04.OutMst> UpdateOutMst(string whseNo, string outNo, Models.Mark10Sqlexpress04.OutMst outMst)
        {
            OnOutMstUpdated(outMst);

            var itemToUpdate = Context.OutMsts
                              .Where(i => i.WHSE_NO == whseNo && i.OUT_NO == outNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(outMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterOutMstUpdated(outMst);

            return outMst;
        }

        partial void OnOutSnoDeleted(Models.Mark10Sqlexpress04.OutSno item);
        partial void OnAfterOutSnoDeleted(Models.Mark10Sqlexpress04.OutSno item);

        public async Task<Models.Mark10Sqlexpress04.OutSno> DeleteOutSno(string outSno1)
        {
            var itemToDelete = Context.OutSnos
                              .Where(i => i.OUT_SNO1 == outSno1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOutSnoDeleted(itemToDelete);

            Context.OutSnos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOutSnoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnOutSnoGet(Models.Mark10Sqlexpress04.OutSno item);

        public async Task<Models.Mark10Sqlexpress04.OutSno> GetOutSnoByOutSno1(string outSno1)
        {
            var items = Context.OutSnos
                              .AsNoTracking()
                              .Where(i => i.OUT_SNO1 == outSno1);

            var itemToReturn = items.FirstOrDefault();

            OnOutSnoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.OutSno> CancelOutSnoChanges(Models.Mark10Sqlexpress04.OutSno item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnOutSnoUpdated(Models.Mark10Sqlexpress04.OutSno item);
        partial void OnAfterOutSnoUpdated(Models.Mark10Sqlexpress04.OutSno item);

        public async Task<Models.Mark10Sqlexpress04.OutSno> UpdateOutSno(string outSno1, Models.Mark10Sqlexpress04.OutSno outSno)
        {
            OnOutSnoUpdated(outSno);

            var itemToUpdate = Context.OutSnos
                              .Where(i => i.OUT_SNO1 == outSno1)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(outSno);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterOutSnoUpdated(outSno);

            return outSno;
        }

        partial void OnPcLogDeleted(Models.Mark10Sqlexpress04.PcLog item);
        partial void OnAfterPcLogDeleted(Models.Mark10Sqlexpress04.PcLog item);

        public async Task<Models.Mark10Sqlexpress04.PcLog> DeletePcLog(string whseNo, string pcNo, string pcLine)
        {
            var itemToDelete = Context.PcLogs
                              .Where(i => i.WHSE_NO == whseNo && i.PC_NO == pcNo && i.PC_LINE == pcLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPcLogDeleted(itemToDelete);

            Context.PcLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPcLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPcLogGet(Models.Mark10Sqlexpress04.PcLog item);

        public async Task<Models.Mark10Sqlexpress04.PcLog> GetPcLogByWhseNoAndPcNoAndPcLine(string whseNo, string pcNo, string pcLine)
        {
            var items = Context.PcLogs
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PC_NO == pcNo && i.PC_LINE == pcLine);

            var itemToReturn = items.FirstOrDefault();

            OnPcLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PcLog> CancelPcLogChanges(Models.Mark10Sqlexpress04.PcLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPcLogUpdated(Models.Mark10Sqlexpress04.PcLog item);
        partial void OnAfterPcLogUpdated(Models.Mark10Sqlexpress04.PcLog item);

        public async Task<Models.Mark10Sqlexpress04.PcLog> UpdatePcLog(string whseNo, string pcNo, string pcLine, Models.Mark10Sqlexpress04.PcLog pcLog)
        {
            OnPcLogUpdated(pcLog);

            var itemToUpdate = Context.PcLogs
                              .Where(i => i.WHSE_NO == whseNo && i.PC_NO == pcNo && i.PC_LINE == pcLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pcLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPcLogUpdated(pcLog);

            return pcLog;
        }

        partial void OnPcSnoDeleted(Models.Mark10Sqlexpress04.PcSno item);
        partial void OnAfterPcSnoDeleted(Models.Mark10Sqlexpress04.PcSno item);

        public async Task<Models.Mark10Sqlexpress04.PcSno> DeletePcSno(string whseNo, string pcNo, string pcLine, string inSno)
        {
            var itemToDelete = Context.PcSnos
                              .Where(i => i.WHSE_NO == whseNo && i.PC_NO == pcNo && i.PC_LINE == pcLine && i.IN_SNO == inSno)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPcSnoDeleted(itemToDelete);

            Context.PcSnos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPcSnoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPcSnoGet(Models.Mark10Sqlexpress04.PcSno item);

        public async Task<Models.Mark10Sqlexpress04.PcSno> GetPcSnoByWhseNoAndPcNoAndPcLineAndInSno(string whseNo, string pcNo, string pcLine, string inSno)
        {
            var items = Context.PcSnos
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PC_NO == pcNo && i.PC_LINE == pcLine && i.IN_SNO == inSno);

            var itemToReturn = items.FirstOrDefault();

            OnPcSnoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PcSno> CancelPcSnoChanges(Models.Mark10Sqlexpress04.PcSno item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPcSnoUpdated(Models.Mark10Sqlexpress04.PcSno item);
        partial void OnAfterPcSnoUpdated(Models.Mark10Sqlexpress04.PcSno item);

        public async Task<Models.Mark10Sqlexpress04.PcSno> UpdatePcSno(string whseNo, string pcNo, string pcLine, string inSno, Models.Mark10Sqlexpress04.PcSno pcSno)
        {
            OnPcSnoUpdated(pcSno);

            var itemToUpdate = Context.PcSnos
                              .Where(i => i.WHSE_NO == whseNo && i.PC_NO == pcNo && i.PC_LINE == pcLine && i.IN_SNO == inSno)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pcSno);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPcSnoUpdated(pcSno);

            return pcSno;
        }

        partial void OnPckDtlDeleted(Models.Mark10Sqlexpress04.PckDtl item);
        partial void OnAfterPckDtlDeleted(Models.Mark10Sqlexpress04.PckDtl item);

        public async Task<Models.Mark10Sqlexpress04.PckDtl> DeletePckDtl(string whseNo, string pckNo, string pckLine)
        {
            var itemToDelete = Context.PckDtls
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo && i.PCK_LINE == pckLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPckDtlDeleted(itemToDelete);

            Context.PckDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPckDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPckDtlGet(Models.Mark10Sqlexpress04.PckDtl item);

        public async Task<Models.Mark10Sqlexpress04.PckDtl> GetPckDtlByWhseNoAndPckNoAndPckLine(string whseNo, string pckNo, string pckLine)
        {
            var items = Context.PckDtls
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo && i.PCK_LINE == pckLine);

            var itemToReturn = items.FirstOrDefault();

            OnPckDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PckDtl> CancelPckDtlChanges(Models.Mark10Sqlexpress04.PckDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPckDtlUpdated(Models.Mark10Sqlexpress04.PckDtl item);
        partial void OnAfterPckDtlUpdated(Models.Mark10Sqlexpress04.PckDtl item);

        public async Task<Models.Mark10Sqlexpress04.PckDtl> UpdatePckDtl(string whseNo, string pckNo, string pckLine, Models.Mark10Sqlexpress04.PckDtl pckDtl)
        {
            OnPckDtlUpdated(pckDtl);

            var itemToUpdate = Context.PckDtls
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo && i.PCK_LINE == pckLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pckDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPckDtlUpdated(pckDtl);

            return pckDtl;
        }

        partial void OnPckMstDeleted(Models.Mark10Sqlexpress04.PckMst item);
        partial void OnAfterPckMstDeleted(Models.Mark10Sqlexpress04.PckMst item);

        public async Task<Models.Mark10Sqlexpress04.PckMst> DeletePckMst(string whseNo, string pckNo)
        {
            var itemToDelete = Context.PckMsts
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPckMstDeleted(itemToDelete);

            Context.PckMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPckMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPckMstGet(Models.Mark10Sqlexpress04.PckMst item);

        public async Task<Models.Mark10Sqlexpress04.PckMst> GetPckMstByWhseNoAndPckNo(string whseNo, string pckNo)
        {
            var items = Context.PckMsts
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo);

            var itemToReturn = items.FirstOrDefault();

            OnPckMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PckMst> CancelPckMstChanges(Models.Mark10Sqlexpress04.PckMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPckMstUpdated(Models.Mark10Sqlexpress04.PckMst item);
        partial void OnAfterPckMstUpdated(Models.Mark10Sqlexpress04.PckMst item);

        public async Task<Models.Mark10Sqlexpress04.PckMst> UpdatePckMst(string whseNo, string pckNo, Models.Mark10Sqlexpress04.PckMst pckMst)
        {
            OnPckMstUpdated(pckMst);

            var itemToUpdate = Context.PckMsts
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pckMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPckMstUpdated(pckMst);

            return pckMst;
        }

        partial void OnPckSnoDeleted(Models.Mark10Sqlexpress04.PckSno item);
        partial void OnAfterPckSnoDeleted(Models.Mark10Sqlexpress04.PckSno item);

        public async Task<Models.Mark10Sqlexpress04.PckSno> DeletePckSno(string whseNo, string pckNo, string inSno)
        {
            var itemToDelete = Context.PckSnos
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo && i.IN_SNO == inSno)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPckSnoDeleted(itemToDelete);

            Context.PckSnos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPckSnoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPckSnoGet(Models.Mark10Sqlexpress04.PckSno item);

        public async Task<Models.Mark10Sqlexpress04.PckSno> GetPckSnoByWhseNoAndPckNoAndInSno(string whseNo, string pckNo, string inSno)
        {
            var items = Context.PckSnos
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo && i.IN_SNO == inSno);

            var itemToReturn = items.FirstOrDefault();

            OnPckSnoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PckSno> CancelPckSnoChanges(Models.Mark10Sqlexpress04.PckSno item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPckSnoUpdated(Models.Mark10Sqlexpress04.PckSno item);
        partial void OnAfterPckSnoUpdated(Models.Mark10Sqlexpress04.PckSno item);

        public async Task<Models.Mark10Sqlexpress04.PckSno> UpdatePckSno(string whseNo, string pckNo, string inSno, Models.Mark10Sqlexpress04.PckSno pckSno)
        {
            OnPckSnoUpdated(pckSno);

            var itemToUpdate = Context.PckSnos
                              .Where(i => i.WHSE_NO == whseNo && i.PCK_NO == pckNo && i.IN_SNO == inSno)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pckSno);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPckSnoUpdated(pckSno);

            return pckSno;
        }

        partial void OnPicDtlDeleted(Models.Mark10Sqlexpress04.PicDtl item);
        partial void OnAfterPicDtlDeleted(Models.Mark10Sqlexpress04.PicDtl item);

        public async Task<Models.Mark10Sqlexpress04.PicDtl> DeletePicDtl(string whseNo, string picNo, string picLine)
        {
            var itemToDelete = Context.PicDtls
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.PIC_LINE == picLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPicDtlDeleted(itemToDelete);

            Context.PicDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPicDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPicDtlGet(Models.Mark10Sqlexpress04.PicDtl item);

        public async Task<Models.Mark10Sqlexpress04.PicDtl> GetPicDtlByWhseNoAndPicNoAndPicLine(string whseNo, string picNo, string picLine)
        {
            var items = Context.PicDtls
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.PIC_LINE == picLine);

            var itemToReturn = items.FirstOrDefault();

            OnPicDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PicDtl> CancelPicDtlChanges(Models.Mark10Sqlexpress04.PicDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPicDtlUpdated(Models.Mark10Sqlexpress04.PicDtl item);
        partial void OnAfterPicDtlUpdated(Models.Mark10Sqlexpress04.PicDtl item);

        public async Task<Models.Mark10Sqlexpress04.PicDtl> UpdatePicDtl(string whseNo, string picNo, string picLine, Models.Mark10Sqlexpress04.PicDtl picDtl)
        {
            OnPicDtlUpdated(picDtl);

            var itemToUpdate = Context.PicDtls
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.PIC_LINE == picLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(picDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPicDtlUpdated(picDtl);

            return picDtl;
        }

        partial void OnPicMstDeleted(Models.Mark10Sqlexpress04.PicMst item);
        partial void OnAfterPicMstDeleted(Models.Mark10Sqlexpress04.PicMst item);

        public async Task<Models.Mark10Sqlexpress04.PicMst> DeletePicMst(string whseNo, string picNo)
        {
            var itemToDelete = Context.PicMsts
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPicMstDeleted(itemToDelete);

            Context.PicMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPicMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPicMstGet(Models.Mark10Sqlexpress04.PicMst item);

        public async Task<Models.Mark10Sqlexpress04.PicMst> GetPicMstByWhseNoAndPicNo(string whseNo, string picNo)
        {
            var items = Context.PicMsts
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo);

            var itemToReturn = items.FirstOrDefault();

            OnPicMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PicMst> CancelPicMstChanges(Models.Mark10Sqlexpress04.PicMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPicMstUpdated(Models.Mark10Sqlexpress04.PicMst item);
        partial void OnAfterPicMstUpdated(Models.Mark10Sqlexpress04.PicMst item);

        public async Task<Models.Mark10Sqlexpress04.PicMst> UpdatePicMst(string whseNo, string picNo, Models.Mark10Sqlexpress04.PicMst picMst)
        {
            OnPicMstUpdated(picMst);

            var itemToUpdate = Context.PicMsts
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(picMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPicMstUpdated(picMst);

            return picMst;
        }

        //partial void OnPicSnoDeleted(Models.Mark10Sqlexpress04.PicSno item);
        //partial void OnAfterPicSnoDeleted(Models.Mark10Sqlexpress04.PicSno item);

        //public async Task<Models.Mark10Sqlexpress04.PicSno> DeletePicSno(string whseNo, string picNo, string inSno)
        //{
        //    var itemToDelete = Context.PicSnos
        //                      .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.IN_SNO == inSno)
        //                      .FirstOrDefault();

        //    if (itemToDelete == null)
        //    {
        //       throw new Exception("Item no longer available");
        //    }

        //    OnPicSnoDeleted(itemToDelete);

        //    Context.PicSnos.Remove(itemToDelete);

        //    try
        //    {
        //        Context.SaveChanges();
        //    }
        //    catch
        //    {
        //        Context.Entry(itemToDelete).State = EntityState.Unchanged;
        //        throw;
        //    }

        //    OnAfterPicSnoDeleted(itemToDelete);

        //    return itemToDelete;
        //}

        //partial void OnPicSnoGet(Models.Mark10Sqlexpress04.PicSno item);

        //public async Task<Models.Mark10Sqlexpress04.PicSno> GetPicSnoByWhseNoAndPicNoAndInSno(string whseNo, string picNo, string inSno)
        //{
        //    var items = Context.PicSnos
        //                      .AsNoTracking()
        //                      .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.IN_SNO == inSno);

        //    var itemToReturn = items.FirstOrDefault();

        //    OnPicSnoGet(itemToReturn);

        //    return await Task.FromResult(itemToReturn);
        //}

        //public async Task<Models.Mark10Sqlexpress04.PicSno> CancelPicSnoChanges(Models.Mark10Sqlexpress04.PicSno item)
        //{
        //    var entityToCancel = Context.Entry(item);
        //    entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
        //    entityToCancel.State = EntityState.Unchanged;

        //    return item;
        //}

        //partial void OnPicSnoUpdated(Models.Mark10Sqlexpress04.PicSno item);
        //partial void OnAfterPicSnoUpdated(Models.Mark10Sqlexpress04.PicSno item);

        //public async Task<Models.Mark10Sqlexpress04.PicSno> UpdatePicSno(string whseNo, string picNo, string inSno, Models.Mark10Sqlexpress04.PicSno picSno)
        //{
        //    OnPicSnoUpdated(picSno);

        //    var itemToUpdate = Context.PicSnos
        //                      .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.IN_SNO == inSno)
        //                      .FirstOrDefault();
        //    if (itemToUpdate == null)
        //    {
        //       throw new Exception("Item no longer available");
        //    }
        //    var entryToUpdate = Context.Entry(itemToUpdate);
        //    entryToUpdate.CurrentValues.SetValues(picSno);
        //    entryToUpdate.State = EntityState.Modified;
        //    Context.SaveChanges();

        //    OnAfterPicSnoUpdated(picSno);

        //    return picSno;
        //}

        partial void OnPltDtlDeleted(Models.Mark10Sqlexpress04.PltDtl item);
        partial void OnAfterPltDtlDeleted(Models.Mark10Sqlexpress04.PltDtl item);

        public async Task<Models.Mark10Sqlexpress04.PltDtl> DeletePltDtl(string suId, string inSno, string whseNo, string inNo, string inLine, string stkCat, string stkSpecialInd, string stkSpecialNo)
        {
            var itemToDelete = Context.PltDtls
                              .Where(i => i.SU_ID == suId && i.IN_SNO == inSno && i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPltDtlDeleted(itemToDelete);

            Context.PltDtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPltDtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPltDtlGet(Models.Mark10Sqlexpress04.PltDtl item);

        public async Task<Models.Mark10Sqlexpress04.PltDtl> GetPltDtlBySuIdAndInSnoAndWhseNoAndInNoAndInLineAndStkCatAndStkSpecialIndAndStkSpecialNo(string suId, string inSno, string whseNo, string inNo, string inLine, string stkCat, string stkSpecialInd, string stkSpecialNo)
        {
            var items = Context.PltDtls
                              .AsNoTracking()
                              .Where(i => i.SU_ID == suId && i.IN_SNO == inSno && i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo);

            var itemToReturn = items.FirstOrDefault();

            OnPltDtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PltDtl> CancelPltDtlChanges(Models.Mark10Sqlexpress04.PltDtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPltDtlUpdated(Models.Mark10Sqlexpress04.PltDtl item);
        partial void OnAfterPltDtlUpdated(Models.Mark10Sqlexpress04.PltDtl item);

        public async Task<Models.Mark10Sqlexpress04.PltDtl> UpdatePltDtl(string suId, string inSno, string whseNo, string inNo, string inLine, string stkCat, string stkSpecialInd, string stkSpecialNo, Models.Mark10Sqlexpress04.PltDtl pltDtl)
        {
            OnPltDtlUpdated(pltDtl);

            var itemToUpdate = Context.PltDtls
                              .Where(i => i.SU_ID == suId && i.IN_SNO == inSno && i.WHSE_NO == whseNo && i.IN_NO == inNo && i.IN_LINE == inLine && i.STK_CAT == stkCat && i.STK_SPECIAL_IND == stkSpecialInd && i.STK_SPECIAL_NO == stkSpecialNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pltDtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPltDtlUpdated(pltDtl);

            return pltDtl;
        }

        partial void OnProgMstDeleted(Models.Mark10Sqlexpress04.ProgMst item);
        partial void OnAfterProgMstDeleted(Models.Mark10Sqlexpress04.ProgMst item);

        public async Task<Models.Mark10Sqlexpress04.ProgMst> DeleteProgMst(string progId)
        {
            var itemToDelete = Context.ProgMsts
                              .Where(i => i.PROG_ID == progId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProgMstDeleted(itemToDelete);

            Context.ProgMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProgMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProgMstGet(Models.Mark10Sqlexpress04.ProgMst item);

        public async Task<Models.Mark10Sqlexpress04.ProgMst> GetProgMstByProgId(string progId)
        {
            var items = Context.ProgMsts
                              .AsNoTracking()
                              .Where(i => i.PROG_ID == progId);

            var itemToReturn = items.FirstOrDefault();

            OnProgMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.ProgMst> CancelProgMstChanges(Models.Mark10Sqlexpress04.ProgMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnProgMstUpdated(Models.Mark10Sqlexpress04.ProgMst item);
        partial void OnAfterProgMstUpdated(Models.Mark10Sqlexpress04.ProgMst item);

        public async Task<Models.Mark10Sqlexpress04.ProgMst> UpdateProgMst(string progId, Models.Mark10Sqlexpress04.ProgMst progMst)
        {
            OnProgMstUpdated(progMst);

            var itemToUpdate = Context.ProgMsts
                              .Where(i => i.PROG_ID == progId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(progMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterProgMstUpdated(progMst);

            return progMst;
        }

        partial void OnProgWrtDeleted(Models.Mark10Sqlexpress04.ProgWrt item);
        partial void OnAfterProgWrtDeleted(Models.Mark10Sqlexpress04.ProgWrt item);

        public async Task<Models.Mark10Sqlexpress04.ProgWrt> DeleteProgWrt(string userId, string progId)
        {
            var itemToDelete = Context.ProgWrts
                              .Where(i => i.USER_ID == userId && i.PROG_ID == progId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProgWrtDeleted(itemToDelete);

            Context.ProgWrts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProgWrtDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProgWrtGet(Models.Mark10Sqlexpress04.ProgWrt item);

        public async Task<Models.Mark10Sqlexpress04.ProgWrt> GetProgWrtByUserIdAndProgId(string userId, string progId)
        {
            var items = Context.ProgWrts
                              .AsNoTracking()
                              .Where(i => i.USER_ID == userId && i.PROG_ID == progId);

            var itemToReturn = items.FirstOrDefault();

            OnProgWrtGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.ProgWrt> CancelProgWrtChanges(Models.Mark10Sqlexpress04.ProgWrt item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnProgWrtUpdated(Models.Mark10Sqlexpress04.ProgWrt item);
        partial void OnAfterProgWrtUpdated(Models.Mark10Sqlexpress04.ProgWrt item);

        public async Task<Models.Mark10Sqlexpress04.ProgWrt> UpdateProgWrt(string userId, string progId, Models.Mark10Sqlexpress04.ProgWrt progWrt)
        {
            OnProgWrtUpdated(progWrt);

            var itemToUpdate = Context.ProgWrts
                              .Where(i => i.USER_ID == userId && i.PROG_ID == progId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(progWrt);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterProgWrtUpdated(progWrt);

            return progWrt;
        }

        partial void OnSkuMstDeleted(Models.Mark10Sqlexpress04.SkuMst item);
        partial void OnAfterSkuMstDeleted(Models.Mark10Sqlexpress04.SkuMst item);

        public async Task<Models.Mark10Sqlexpress04.SkuMst> DeleteSkuMst(string skuNo)
        {
            var itemToDelete = Context.SkuMsts
                              .Where(i => i.SKU_NO == skuNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSkuMstDeleted(itemToDelete);

            Context.SkuMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSkuMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSkuMstGet(Models.Mark10Sqlexpress04.SkuMst item);

        public async Task<Models.Mark10Sqlexpress04.SkuMst> GetSkuMstBySkuNo(string skuNo)
        {
            var items = Context.SkuMsts
                              .AsNoTracking()
                              .Where(i => i.SKU_NO == skuNo);

            var itemToReturn = items.FirstOrDefault();

            OnSkuMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.SkuMst> CancelSkuMstChanges(Models.Mark10Sqlexpress04.SkuMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSkuMstUpdated(Models.Mark10Sqlexpress04.SkuMst item);
        partial void OnAfterSkuMstUpdated(Models.Mark10Sqlexpress04.SkuMst item);

        public async Task<Models.Mark10Sqlexpress04.SkuMst> UpdateSkuMst(string skuNo, Models.Mark10Sqlexpress04.SkuMst skuMst)
        {
            OnSkuMstUpdated(skuMst);

            var itemToUpdate = Context.SkuMsts
                              .Where(i => i.SKU_NO == skuNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(skuMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterSkuMstUpdated(skuMst);

            return skuMst;
        }

        partial void OnSkuSutDeleted(Models.Mark10Sqlexpress04.SkuSut item);
        partial void OnAfterSkuSutDeleted(Models.Mark10Sqlexpress04.SkuSut item);

        public async Task<Models.Mark10Sqlexpress04.SkuSut> DeleteSkuSut(string whseNo, string skuNo, string gtinUnit, string suType)
        {
            var itemToDelete = Context.SkuSuts
                              .Where(i => i.WHSE_NO == whseNo && i.SKU_NO == skuNo && i.GTIN_UNIT == gtinUnit && i.SU_TYPE == suType)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSkuSutDeleted(itemToDelete);

            Context.SkuSuts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSkuSutDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSkuSutGet(Models.Mark10Sqlexpress04.SkuSut item);

        public async Task<Models.Mark10Sqlexpress04.SkuSut> GetSkuSutByWhseNoAndSkuNoAndGtinUnitAndSuType(string whseNo, string skuNo, string gtinUnit, string suType)
        {
            var items = Context.SkuSuts
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.SKU_NO == skuNo && i.GTIN_UNIT == gtinUnit && i.SU_TYPE == suType);

            var itemToReturn = items.FirstOrDefault();

            OnSkuSutGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.SkuSut> CancelSkuSutChanges(Models.Mark10Sqlexpress04.SkuSut item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSkuSutUpdated(Models.Mark10Sqlexpress04.SkuSut item);
        partial void OnAfterSkuSutUpdated(Models.Mark10Sqlexpress04.SkuSut item);

        public async Task<Models.Mark10Sqlexpress04.SkuSut> UpdateSkuSut(string whseNo, string skuNo, string gtinUnit, string suType, Models.Mark10Sqlexpress04.SkuSut skuSut)
        {
            OnSkuSutUpdated(skuSut);

            var itemToUpdate = Context.SkuSuts
                              .Where(i => i.WHSE_NO == whseNo && i.SKU_NO == skuNo && i.GTIN_UNIT == gtinUnit && i.SU_TYPE == suType)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(skuSut);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterSkuSutUpdated(skuSut);

            return skuSut;
        }

        partial void OnSnoCtlDeleted(Models.Mark10Sqlexpress04.SnoCtl item);
        partial void OnAfterSnoCtlDeleted(Models.Mark10Sqlexpress04.SnoCtl item);

        public async Task<Models.Mark10Sqlexpress04.SnoCtl> DeleteSnoCtl(string snoType)
        {
            var itemToDelete = Context.SnoCtls
                              .Where(i => i.SNO_TYPE == snoType)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSnoCtlDeleted(itemToDelete);

            Context.SnoCtls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSnoCtlDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSnoCtlGet(Models.Mark10Sqlexpress04.SnoCtl item);

        public async Task<Models.Mark10Sqlexpress04.SnoCtl> GetSnoCtlBySnoType(string snoType)
        {
            var items = Context.SnoCtls
                              .AsNoTracking()
                              .Where(i => i.SNO_TYPE == snoType);

            var itemToReturn = items.FirstOrDefault();

            OnSnoCtlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.SnoCtl> CancelSnoCtlChanges(Models.Mark10Sqlexpress04.SnoCtl item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSnoCtlUpdated(Models.Mark10Sqlexpress04.SnoCtl item);
        partial void OnAfterSnoCtlUpdated(Models.Mark10Sqlexpress04.SnoCtl item);

        public async Task<Models.Mark10Sqlexpress04.SnoCtl> UpdateSnoCtl(string snoType, Models.Mark10Sqlexpress04.SnoCtl snoCtl)
        {
            OnSnoCtlUpdated(snoCtl);

            var itemToUpdate = Context.SnoCtls
                              .Where(i => i.SNO_TYPE == snoType)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(snoCtl);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterSnoCtlUpdated(snoCtl);

            return snoCtl;
        }

        partial void OnStnMstDeleted(Models.Mark10Sqlexpress04.StnMst item);
        partial void OnAfterStnMstDeleted(Models.Mark10Sqlexpress04.StnMst item);

        public async Task<Models.Mark10Sqlexpress04.StnMst> DeleteStnMst(string stnNo)
        {
            var itemToDelete = Context.StnMsts
                              .Where(i => i.STN_NO == stnNo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnStnMstDeleted(itemToDelete);

            Context.StnMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterStnMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnStnMstGet(Models.Mark10Sqlexpress04.StnMst item);

        public async Task<Models.Mark10Sqlexpress04.StnMst> GetStnMstByStnNo(string stnNo)
        {
            var items = Context.StnMsts
                              .AsNoTracking()
                              .Where(i => i.STN_NO == stnNo);

            var itemToReturn = items.FirstOrDefault();

            OnStnMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.StnMst> CancelStnMstChanges(Models.Mark10Sqlexpress04.StnMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnStnMstUpdated(Models.Mark10Sqlexpress04.StnMst item);
        partial void OnAfterStnMstUpdated(Models.Mark10Sqlexpress04.StnMst item);

        public async Task<Models.Mark10Sqlexpress04.StnMst> UpdateStnMst(string stnNo, Models.Mark10Sqlexpress04.StnMst stnMst)
        {
            OnStnMstUpdated(stnMst);

            var itemToUpdate = Context.StnMsts
                              .Where(i => i.STN_NO == stnNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(stnMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterStnMstUpdated(stnMst);

            return stnMst;
        }

        partial void OnTxLogDeleted(Models.Mark10Sqlexpress04.TxLog item);
        partial void OnAfterTxLogDeleted(Models.Mark10Sqlexpress04.TxLog item);

        public async Task<Models.Mark10Sqlexpress04.TxLog> DeleteTxLog(string whseNo, string txNo, string txLine)
        {
            var itemToDelete = Context.TxLogs
                              .Where(i => i.WHSE_NO == whseNo && i.TX_NO == txNo && i.TX_LINE == txLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTxLogDeleted(itemToDelete);

            Context.TxLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTxLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTxLogGet(Models.Mark10Sqlexpress04.TxLog item);

        public async Task<Models.Mark10Sqlexpress04.TxLog> GetTxLogByWhseNoAndTxNoAndTxLine(string whseNo, string txNo, string txLine)
        {
            var items = Context.TxLogs
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.TX_NO == txNo && i.TX_LINE == txLine);

            var itemToReturn = items.FirstOrDefault();

            OnTxLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.TxLog> CancelTxLogChanges(Models.Mark10Sqlexpress04.TxLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTxLogUpdated(Models.Mark10Sqlexpress04.TxLog item);
        partial void OnAfterTxLogUpdated(Models.Mark10Sqlexpress04.TxLog item);

        public async Task<Models.Mark10Sqlexpress04.TxLog> UpdateTxLog(string whseNo, string txNo, string txLine, Models.Mark10Sqlexpress04.TxLog txLog)
        {
            OnTxLogUpdated(txLog);

            var itemToUpdate = Context.TxLogs
                              .Where(i => i.WHSE_NO == whseNo && i.TX_NO == txNo && i.TX_LINE == txLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(txLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterTxLogUpdated(txLog);

            return txLog;
        }

        partial void OnTxSnoDeleted(Models.Mark10Sqlexpress04.TxSno item);
        partial void OnAfterTxSnoDeleted(Models.Mark10Sqlexpress04.TxSno item);

        public async Task<Models.Mark10Sqlexpress04.TxSno> DeleteTxSno(string txNo, string txLine, string inSno)
        {
            var itemToDelete = Context.TxSnos
                              .Where(i => i.TX_NO == txNo && i.TX_LINE == txLine && i.IN_SNO == inSno)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTxSnoDeleted(itemToDelete);

            Context.TxSnos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTxSnoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTxSnoGet(Models.Mark10Sqlexpress04.TxSno item);

        public async Task<Models.Mark10Sqlexpress04.TxSno> GetTxSnoByTxNoAndTxLineAndInSno(string txNo, string txLine, string inSno)
        {
            var items = Context.TxSnos
                              .AsNoTracking()
                              .Where(i => i.TX_NO == txNo && i.TX_LINE == txLine && i.IN_SNO == inSno);

            var itemToReturn = items.FirstOrDefault();

            OnTxSnoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.TxSno> CancelTxSnoChanges(Models.Mark10Sqlexpress04.TxSno item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTxSnoUpdated(Models.Mark10Sqlexpress04.TxSno item);
        partial void OnAfterTxSnoUpdated(Models.Mark10Sqlexpress04.TxSno item);

        public async Task<Models.Mark10Sqlexpress04.TxSno> UpdateTxSno(string txNo, string txLine, string inSno, Models.Mark10Sqlexpress04.TxSno txSno)
        {
            OnTxSnoUpdated(txSno);

            var itemToUpdate = Context.TxSnos
                              .Where(i => i.TX_NO == txNo && i.TX_LINE == txLine && i.IN_SNO == inSno)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(txSno);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterTxSnoUpdated(txSno);

            return txSno;
        }

        partial void OnUserLogDeleted(Models.Mark10Sqlexpress04.UserLog item);
        partial void OnAfterUserLogDeleted(Models.Mark10Sqlexpress04.UserLog item);

        public async Task<Models.Mark10Sqlexpress04.UserLog> DeleteUserLog(string logDate, string logType, string userId, string progId)
        {
            var itemToDelete = Context.UserLogs
                              .Where(i => i.LOG_DATE == logDate && i.LOG_TYPE == logType && i.USER_ID == userId && i.PROG_ID == progId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUserLogDeleted(itemToDelete);

            Context.UserLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUserLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnUserLogGet(Models.Mark10Sqlexpress04.UserLog item);

        public async Task<Models.Mark10Sqlexpress04.UserLog> GetUserLogByLogDateAndLogTypeAndUserIdAndProgId(string logDate, string logType, string userId, string progId)
        {
            var items = Context.UserLogs
                              .AsNoTracking()
                              .Where(i => i.LOG_DATE == logDate && i.LOG_TYPE == logType && i.USER_ID == userId && i.PROG_ID == progId);

            var itemToReturn = items.FirstOrDefault();

            OnUserLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.UserLog> CancelUserLogChanges(Models.Mark10Sqlexpress04.UserLog item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnUserLogUpdated(Models.Mark10Sqlexpress04.UserLog item);
        partial void OnAfterUserLogUpdated(Models.Mark10Sqlexpress04.UserLog item);

        public async Task<Models.Mark10Sqlexpress04.UserLog> UpdateUserLog(string logDate, string logType, string userId, string progId, Models.Mark10Sqlexpress04.UserLog userLog)
        {
            OnUserLogUpdated(userLog);

            var itemToUpdate = Context.UserLogs
                              .Where(i => i.LOG_DATE == logDate && i.LOG_TYPE == logType && i.USER_ID == userId && i.PROG_ID == progId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(userLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterUserLogUpdated(userLog);

            return userLog;
        }

        partial void OnUserMstDeleted(Models.Mark10Sqlexpress04.UserMst item);
        partial void OnAfterUserMstDeleted(Models.Mark10Sqlexpress04.UserMst item);

        public async Task<Models.Mark10Sqlexpress04.UserMst> DeleteUserMst(string userId)
        {
            var itemToDelete = Context.UserMsts
                              .Where(i => i.USER_ID == userId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUserMstDeleted(itemToDelete);

            Context.UserMsts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUserMstDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnUserMstGet(Models.Mark10Sqlexpress04.UserMst item);

        public async Task<Models.Mark10Sqlexpress04.UserMst> GetUserMstByUserId(string userId)
        {
            var items = Context.UserMsts
                              .AsNoTracking()
                              .Where(i => i.USER_ID == userId);

            var itemToReturn = items.FirstOrDefault();

            OnUserMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.UserMst> CancelUserMstChanges(Models.Mark10Sqlexpress04.UserMst item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnUserMstUpdated(Models.Mark10Sqlexpress04.UserMst item);
        partial void OnAfterUserMstUpdated(Models.Mark10Sqlexpress04.UserMst item);

        public async Task<Models.Mark10Sqlexpress04.UserMst> UpdateUserMst(string userId, Models.Mark10Sqlexpress04.UserMst userMst)
        {
            OnUserMstUpdated(userMst);

            var itemToUpdate = Context.UserMsts
                              .Where(i => i.USER_ID == userId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(userMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterUserMstUpdated(userMst);

            return userMst;
        }


        public async Task ExportPicSnosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picsnos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPicSnosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/picsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/picsnos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPicSnosRead(ref IQueryable<Models.Mark10Sqlexpress04.PicSno> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.PicSno>> GetPicSnos(Query query = null)
        {
            var items = Context.PicSnos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPicSnosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPicSnoCreated(Models.Mark10Sqlexpress04.PicSno item);
        partial void OnAfterPicSnoCreated(Models.Mark10Sqlexpress04.PicSno item);

        public async Task<Models.Mark10Sqlexpress04.PicSno> CreatePicSno(Models.Mark10Sqlexpress04.PicSno picSno)
        {
            OnPicSnoCreated(picSno);

            Context.PicSnos.Add(picSno);
            Context.SaveChanges();

            OnAfterPicSnoCreated(picSno);

            return picSno;
        }

        partial void OnPicSnoDeleted(Models.Mark10Sqlexpress04.PicSno item);
        partial void OnAfterPicSnoDeleted(Models.Mark10Sqlexpress04.PicSno item);

        public async Task<Models.Mark10Sqlexpress04.PicSno> DeletePicSno(string whseNo, string picNo, string picLine, string inSno, string inNo, string inLine)
        {
            var itemToDelete = Context.PicSnos
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.PIC_LINE == picLine && i.IN_SNO == inSno && i.IN_NO == inNo && i.IN_LINE == inLine)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnPicSnoDeleted(itemToDelete);

            Context.PicSnos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPicSnoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPicSnoGet(Models.Mark10Sqlexpress04.PicSno item);

        public async Task<Models.Mark10Sqlexpress04.PicSno> GetPicSnoByWhseNoAndPicNoAndPicLineAndInSnoAndInNoAndInLine(string whseNo, string picNo, string picLine, string inSno, string inNo, string inLine)
        {
            var items = Context.PicSnos
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.PIC_LINE == picLine && i.IN_SNO == inSno && i.IN_NO == inNo && i.IN_LINE == inLine);

            var itemToReturn = items.FirstOrDefault();

            OnPicSnoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Mark10Sqlexpress04.PicSno> CancelPicSnoChanges(Models.Mark10Sqlexpress04.PicSno item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnPicSnoUpdated(Models.Mark10Sqlexpress04.PicSno item);
        partial void OnAfterPicSnoUpdated(Models.Mark10Sqlexpress04.PicSno item);

        public async Task<Models.Mark10Sqlexpress04.PicSno> UpdatePicSno(string whseNo, string picNo, string picLine, string inSno, string inNo, string inLine, Models.Mark10Sqlexpress04.PicSno picSno)
        {
            OnPicSnoUpdated(picSno);

            var itemToUpdate = Context.PicSnos
                              .Where(i => i.WHSE_NO == whseNo && i.PIC_NO == picNo && i.PIC_LINE == picLine && i.IN_SNO == inSno && i.IN_NO == inNo && i.IN_LINE == inLine)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(picSno);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterPicSnoUpdated(picSno);

            return picSno;
        }


    }
}
