using Microsoft.EntityFrameworkCore;
using Radzen;
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RadzenDh5
{

    public partial class Mark10Sqlexpress04Service
    {
        partial void OnTranslateUpdated(Models.Mark10Sqlexpress04.Translate item);
        partial void OnAfterTranslateUpdated(Models.Mark10Sqlexpress04.Translate item);

        public async Task<Models.Mark10Sqlexpress04.Translate> UpdateTranslate(string text, Models.Mark10Sqlexpress04.Translate translate)
        {
            OnTranslateUpdated(translate);

            var itemToUpdate = Context.Translates
                              .Where(i => i.TEXT == text)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(translate);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterTranslateUpdated(translate);

            return translate;
        }
        partial void OnTranslateGet(Models.Mark10Sqlexpress04.Translate item);
        partial void OnTranslateDeleted(Models.Mark10Sqlexpress04.Translate item);
        partial void OnAfterTranslateDeleted(Models.Mark10Sqlexpress04.Translate item);
        public async Task<Models.Mark10Sqlexpress04.Translate> DeleteTranslate(string text)
        {
            var itemToDelete = Context.Translates
                              .Where(i => i.TEXT == text)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            OnTranslateDeleted(itemToDelete);

            Context.Translates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTranslateDeleted(itemToDelete);

            return itemToDelete;
        }

        public async Task<Models.Mark10Sqlexpress04.Translate> GetTranslateByText(string text)
        {
            var items = Context.Translates
                              .AsNoTracking()
                              .Where(i => i.TEXT == text);

            var itemToReturn = items.FirstOrDefault();

            OnTranslateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }


        //   join PLT_DTL b on(
        //   a.WHSE_NO= b.WHSE_NO
        //   and a.PLANT= b.PLANT
        //   and a.STGE_LOC= b.STGE_LOC
        //   and a.SKU_NO= b.SKU_NO
        //   and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'')
        //   and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'')
        //   and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'')
        //   and a.GTIN_UNIT=b.GTIN_UNIT
        //   and a.SU_ID= b.SU_ID)

        /// <summary>
        /// 這裡要重做, 一個SKU_NO 10317763,會有284筆, 要靠一些條件取出單筆
        /// 在 grid 獲得到的信息, 應該可以直接取用
        /// </summary>
        /// <param name="SKU_NO"></param>
        /// <returns></returns>
        public async Task<Models.Mark10Sqlexpress04.Vc010> GetVc010ByCustom(string SKU_NO)
        {
            var sSQL = @$"
            select a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,max(b.COUNT_DATE) as COUNT_DATE,sum(b.GTIN_QTY) as GTIN_QTY,sum(b.SKU_QTY) as SKU_QTY,a.GTIN_QTY as LOC_QTY,a.GTIN_UNIT,a.SKU_UNIT
                  from LOC_DTL a
                    join PLT_DTL b on(a.WHSE_NO= b.WHSE_NO and a.PLANT= b.PLANT and a.STGE_LOC= b.STGE_LOC and a.SKU_NO= b.SKU_NO and IsNull(a.BATCH_NO,'')= IsNull(a.BATCH_NO, '') and IsNull(a.STK_SPECIAL_IND,'')= IsNull(b.STK_SPECIAL_IND, '') and IsNull(a.STK_SPECIAL_NO,'')= IsNull(b.STK_SPECIAL_NO, '') and a.GTIN_UNIT = b.GTIN_UNIT and a.SU_ID = b.SU_ID)
                    join SKU_MST c on(a.SKU_NO= c.SKU_NO)
                    join LOC_MST d on(a.LOC_NO= d.LOC_NO and a.SU_ID= d.SU_ID)
                    join SKU_SUT e on(a.WHSE_NO= e.WHSE_NO and a.SU_TYPE= e.SU_TYPE and a.SKU_NO= e.SKU_NO and a.GTIN_UNIT= e.GTIN_UNIT)
                    where a.STGE_TYPE= 'ATR' and d.LOC_STS = 'S' and a.GTIN_ALO_QTY = 0

                    AND a.SKU_NO = '{SKU_NO}'
                    group by a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,a.GTIN_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    having a.TRN_DATE > max(b.COUNT_DATE) ";

            var items = Context.Vc010s.FromSqlRaw(sSQL).AsNoTracking();
            
            string str = items.ToQueryString();
            var itemToReturn = items.FirstOrDefault();

            //    OnTranslateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }



        public async Task<Models.Mark10Sqlexpress04.Translate> CancelTranslateChanges(Models.Mark10Sqlexpress04.Translate item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }
        public async Task<IQueryable<Models.Mark10Sqlexpress04.Translate>> XXXGetTranslates(Query query = null)
        {
            var items = Context.Translates.AsQueryable();

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

            OnTranslatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTranslateCreated(Models.Mark10Sqlexpress04.Translate item);
        partial void OnAfterTranslateCreated(Models.Mark10Sqlexpress04.Translate item);

        public async Task<Models.Mark10Sqlexpress04.Translate> CreateTranslate(Models.Mark10Sqlexpress04.Translate translate)
        {
            try
            {
                OnTranslateCreated(translate);

                Context.Translates.Add(translate);
                Context.SaveChanges();

                OnAfterTranslateCreated(translate);

                return translate;

            }
            catch (Exception ex)
            {

                var obj = Context.Translates.Find(translate.CN_TEXT);
                if (obj != null)
                {
                    //throw new Exception($"data had exist EN_TEXT({obj.TEXT})={obj.EN_TEXT}");
                    throw new Exception($"data had exist"); // LINE#195, S090.cs, MLASRS
                }

                throw new Exception(ex.Message);
            }
        }
        public async Task ExportVp100SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp100s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp100s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVp100SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp100s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp100s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVp100sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vp100> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vp100>> GetVp100S(Query query = null)
        {
            var items = Context.Vp100s.AsQueryable();
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

            OnVp100sRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportVTranslatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vtranslates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vtranslates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVTranslatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vtranslates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vtranslates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVTranslatesRead(ref IQueryable<Models.Mark10Sqlexpress04.VTranslate> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.VTranslate>> GetVTranslates(Query query = null)
        {
            var items = Context.VTranslates.AsQueryable();
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

            OnVTranslatesRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportVp030SubsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp030subs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp030subs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVp030SubsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp030subs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp030subs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVp030SubsRead(ref IQueryable<Models.Mark10Sqlexpress04.Vp030Sub> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vp030Sub>> GetVp030Subs(Query query = null)
        {
            var items = Context.Vp030Subs.AsQueryable();
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

            OnVp030SubsRead(ref items);

            return await Task.FromResult(items);
        }

        // NOTE by Mark, 05/03, P060
        public async Task ExportVLocDtlMstPltDtlInDtlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vlocdtlmstpltdtlindtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vlocdtlmstpltdtlindtls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVLocDtlMstPltDtlInDtlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vlocdtlmstpltdtlindtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vlocdtlmstpltdtlindtls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVLocDtlMstPltDtlInDtlsRead(ref IQueryable<Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>> GetVLocDtlMstPltDtlInDtls(Query query = null)
        {
            var items = Context.VLocDtlMstPltDtlInDtls.AsQueryable();
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

            OnVLocDtlMstPltDtlInDtlsRead(ref items);

            return await Task.FromResult(items);
        }



        // NOTE by Mark, 05/02

        public async Task ExportVp070SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp070s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp070s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVp070SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp070s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp070s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVp070sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vp070> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vp070>> GetVp070S(Query query = null)
        {
            var items = Context.Vp070s.AsQueryable();
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

            OnVp070sRead(ref items);

            return await Task.FromResult(items);
        }


        //
        public async Task ExportVp030SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp030s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp030s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVp030SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vp030s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vp030s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVp030sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vp030> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vp030>> GetVp030S(Query query = null)
        {
            var items = Context.Vp030s.AsQueryable();
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

            OnVp030sRead(ref items);

            return await Task.FromResult(items);
        }






        public async Task ExportVr080SToExcelV2(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo($"export/r080", true);
        }


        public async Task ExportVr080SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr080s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr080s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVr080SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr080s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr080s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVr080sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vr080> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr080>> GetVr080S(Query query = null)
        {
            var items = Context.Vr080s.AsQueryable();
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

            OnVr080sRead(ref items);

            return await Task.FromResult(items);
        }



        // R050
        public async Task ExportVr050SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr050s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr050s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVr050SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr050s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr050s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVr050sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vr050> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr050>> GetVr050S(Query query = null)
        {
            var items = Context.Vr050s.AsQueryable();
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

            OnVr050sRead(ref items);

            return await Task.FromResult(items);
        }


        public async Task ExportVr060SToExcelV2(string dt1, string dt2)
        {
            // NOTE by Mark, 04/29, 採用 V2 Controller
            navigationManager.NavigateTo("exportV2/mark10sqlexpress04/vr060s/excel?dt1=" + UrlEncoder.Default.Encode(dt1) + "&&dt2=" + UrlEncoder.Default.Encode(dt2), true); ;
        }
        public async Task ExportVr070SToExcelV2(string dt1, string dt2)
        {
            // NOTE by Mark, 04/29, 採用 V2 Controller
            navigationManager.NavigateTo("exportV2/mark10sqlexpress04/vr070s/excel?dt1=" + UrlEncoder.Default.Encode(dt1) + "&&dt2=" + UrlEncoder.Default.Encode(dt2), true); ;
        }



        //public async Task ExportVr060SToExcelV2(QueryV2 query = null, string fileName = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr060s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr060s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}

        //public async Task ExportVr060SToCSV(Query query = null, string fileName = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr060s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr060s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}

        //public async Task ExportVr060SToCSVV2(QueryV2 query = null, string fileName = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr060s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr060s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        //}

        partial void OnVr060sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vr060> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr060>> GetVr060S(Query query = null)
        {
            var items = Context.Vr060s.AsQueryable();
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

            OnVr060sRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr060>> GetVr060SV2(QueryV2 query = null)
        {
            var items = Context.Vr060s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                items = Context.Vr060s.FromSqlRaw(query.StrSQL);
            }

            OnVr060sRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr070>> GetVr070SV2(QueryV2 query = null)
        {
            var items = Context.Vr070s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                items = Context.Vr070s.FromSqlRaw(query.StrSQL);
            }

            OnVr070sRead(ref items);

            return await Task.FromResult(items);
        }



        public async Task ExportVr070SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr070s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr070s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVr070SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr070s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr070s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVr070sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vr070> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr070>> GetVr070S(Query query = null)
        {
            var items = Context.Vr070s.AsQueryable();
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

            OnVr070sRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportVr040SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr040s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr040s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVr040SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/mark10sqlexpress04/vr040s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/mark10sqlexpress04/vr040s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVr040sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vr040> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vr040>> GetVr040S(Query query = null)
        {
            var items = Context.Vr040s.AsQueryable();
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
            // NOTE by Mark, 2021/4/19
            items = items.OrderBy(a => a.DATE).ThenBy(a => a.SKU_NO);

            OnVr040sRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnVc010sRead(ref IQueryable<Models.Mark10Sqlexpress04.Vc010> items);

        public async Task<IQueryable<Models.Mark10Sqlexpress04.Vc010>> GetVc010S(Query query = null)
        {
            var items = Context.Vc010s.AsQueryable();
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

            OnVc010sRead(ref items);

            return await Task.FromResult(items);
        }
    }
}
