using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RadzenDh5.Models;

namespace RadzenDh5.Pages
{
    public partial class Q110CoreComponent : Q000Component
    {
       
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }



        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q110";
            await base.OnInitializedAsync();
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            //var mark10Sqlexpress04GetInMstsResult = await Mark10Sqlexpress04.GetInMsts();
            //getInMstsResult = mark10Sqlexpress04GetInMstsResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Mark10Sqlexpress04.ExportInMstsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,HEADER_STS,SHIP_TYPE,PRIORITY,HEADER_TEXT,REQM_NO,REQM_TYPE,MOVM_TYPE,STGE_TYPE_FROM,STGE_BIN_FROM,DYNAMIC_IND_FROM,STGE_TYPE_TO,STGE_BIN_TO,DYNAMIC_IND_TO,PLAN_DATE,TRN_NO,TRN_YEAR,ITEM_COUNT,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,IN_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"In Msts");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Mark10Sqlexpress04.ExportInMstsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "WHSE_NO,IN_NO,HEADER_STS,SHIP_TYPE,PRIORITY,HEADER_TEXT,REQM_NO,REQM_TYPE,MOVM_TYPE,STGE_TYPE_FROM,STGE_BIN_FROM,DYNAMIC_IND_FROM,STGE_TYPE_TO,STGE_BIN_TO,DYNAMIC_IND_TO,PLAN_DATE,TRN_NO,TRN_YEAR,ITEM_COUNT,GROSS_WEIGHT,NET_WEIGHT,WEIGHT_UNIT,VOLUME,VOLUME_UNIT,IN_STS,SOURCE,APPROVE_IND,REMARK,TRN_USER,TRN_DATE,CRT_USER,CRT_DATE" }, $"In Msts");

            }
        }
    }
}
