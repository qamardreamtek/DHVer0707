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
    public partial class GroupMstsComponent : S000Component
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }


        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> _getGroupMstsResult;

        UserMst SelectedUserMst { get; set; }
        GroupMst SelectedGroupMst { get; set; }
        GroupDtl SelectedGroupDtl { get; set; }



        public IList<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> getGroupMstsList
        {
            get
            {
                return new List<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst>(getGroupMstsResult);
            }
        }

        //IQueryable<object> q = ...;
        //List<object> l = new List<object>(q);

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> getGroupMstsResult
        {
            get
            {
                return _getGroupMstsResult;
            }
            set
            {
                if (!object.Equals(_getGroupMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getGroupMstsResult", NewValue = value, OldValue = _getGroupMstsResult };
                    _getGroupMstsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            PROG_ID = "S020";
            await base.OnInitializedAsync();
       //     await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetGroupMstsResult = await Mark10Sqlexpress04.GetGroupMsts();
            getGroupMstsResult = mark10Sqlexpress04GetGroupMstsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            try
            {

                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to create");
                AuthMsg = "authorization to create granted";


                var dialogResult = await DialogService.OpenAsync<AddGroupMst>("Add Group Mst", null);
                await grid0.Reload();

                await InvokeAsync(() => { StateHasChanged(); });
            }
            catch (Exception ex)
            {
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }

        //public RadzenDh5.Models.Mark10Sqlexpress04.UserMst selectedUserMst;
        //protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.UserMst args)
        //{
        //    //  grid0BindEntity = (RadzenDh5.Models.Mark10Sqlexpress04.UserMst)grid0Bind;
        //    selectedUserMst = args;
        public RadzenDh5.Models.Mark10Sqlexpress04.GroupMst selectedGroupMst;
        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.GroupMst args)
        {
            selectedGroupMst = args;
           // return;
      
        }
        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(RadzenDh5.Models.Mark10Sqlexpress04.GroupMst args)
        {
            var dialogResult = await DialogService.OpenAsync<ViewGroupMst>("GROUP_MST", new Dictionary<string, object>() { { "GROUP_ID", selectedGroupMst.GROUP_ID } });

        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (progWrt.APPROVE_WRT != "Y" && progWrt.UPDATE_WRT != "Y") throw new Exception("no authorization to delete");
                AuthMsg = "authorization to delete granted";

                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeleteGroupMstResult = await Mark10Sqlexpress04.DeleteGroupMst($"{data.GROUP_ID}");
                    if (mark10Sqlexpress04DeleteGroupMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete GroupMst" });
                ErrMsg = DhGlobals.getMsgWithTimestamp(ex.Message);
            }
        }
    }
}
