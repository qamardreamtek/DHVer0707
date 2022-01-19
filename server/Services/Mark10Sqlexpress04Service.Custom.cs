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

        partial void OnUserMstCreated(Models.Mark10Sqlexpress04.UserMst item)
        {
            if (item.USER_PSWD.Length < 8)
            {
                throw new Exception("length of user password not less than 8");
            }

        }


        // Radzen Note by Mark, not sure why it didn't generate at fist place, 有沒有可能第一版DB少了PK?
        partial void OnInMstGet(Models.Mark10Sqlexpress04.InMst item);
        public async Task<Models.Mark10Sqlexpress04.InMst> GetInMstByWhseNoAndInNo(string whseNo, string inNo)
        {
            var items = Context.InMsts
                              .AsNoTracking()
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo);

            var itemToReturn = items.FirstOrDefault();
            //var itemToReturn = await items.FirstOrDefaultAsync(); // Q040, tab0 any row doubleclick,tab1 any row doubleclick,tab1 any row doubleclick,tab0 doubleclick on the same row BUG


            OnInMstGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }
        partial void OnInMstUpdated(Models.Mark10Sqlexpress04.InMst item);
        partial void OnAfterInMstUpdated(Models.Mark10Sqlexpress04.InMst item);
        public async Task<Models.Mark10Sqlexpress04.InMst> UpdateInMst(string whseNo, string inNo, Models.Mark10Sqlexpress04.InMst inMst)
        {
            OnInMstUpdated(inMst);

            var itemToUpdate = Context.InMsts
                              .Where(i => i.WHSE_NO == whseNo && i.IN_NO == inNo)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(inMst);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterInMstUpdated(inMst);

            return inMst;
        }


    }
}