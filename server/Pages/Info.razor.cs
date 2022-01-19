using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RadzenDh5.Pages
{

    public partial class InfoComponent
    {

        // Tech Note by Mark,05/13, grid0 需要用來 ensure goto first page after every query
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> grid0;

        //DataTable dtMST = new DataTable("OUT_MST"); //交貨單主檔
        //DataTable dtDTL = new DataTable("OUT_DTL"); //交貨單明細檔
   
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> getOutMstsResult { get; set; }
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl> getOutDtlsResult { get; set; }
        public RadzenDh5.Models.Mark10Sqlexpress04.OutMst SelectedOutMst { get; set; }
        public RadzenDh5.Models.Mark10Sqlexpress04.OutDtl SelectedOutDtl { get; set; }


        public object objSelectedOutMst { get; set; }
        public object objSelectedOutDtl { get; set; }

        public string IP1Client;
        public string IP2Server;



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                IP1Client = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                IP2Server = httpContextAccessor.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString();
                StateHasChanged();

            }
        }
        
      

        
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Info";
            await base.OnInitializedAsync();

            //https://www.reddit.com/r/Blazor/comments/fxg6jt/blazor_server_local_vs_remote_ip_addresses/
            //IP1Client = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            //IP2Server = httpContextAccessor.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString();


         

            // FOR DEV USAGE
            //GoodMsg = $@"USER_ID={DhUser}, USER_NAME={DhUsername}, PROG_ID={PROG_ID}, PROG_WRT(APPROVE,UPDATE) = ({progWrt.APPROVE_WRT},{progWrt.UPDATE_WRT}) ";
            //ErrMsg = $@"USER_ID={DhUser}, USER_NAME={DhUsername}, PROG_ID={PROG_ID}, PROG_WRT(APPROVE,UPDATE) = ({progWrt.APPROVE_WRT},{progWrt.UPDATE_WRT}) ";
        }



    }
}
