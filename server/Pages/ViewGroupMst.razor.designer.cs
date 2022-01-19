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
    public partial class ViewGroupMstComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic GROUP_ID { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.GroupMst _groupmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.GroupMst groupmst
        {
            get
            {
                return _groupmst;
            }
            set
            {
                if (!object.Equals(_groupmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "groupmst", NewValue = value, OldValue = _groupmst };
                    _groupmst = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
{
await base.OnInitializedAsync();
await base.OnInitializedAsync();
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetGroupMstByGroupIdResult = await Mark10Sqlexpress04.GetGroupMstByGroupId($"{GROUP_ID}");
            groupmst = mark10Sqlexpress04GetGroupMstByGroupIdResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.GroupMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateGroupMstResult = await Mark10Sqlexpress04.UpdateGroupMst($"{GROUP_ID}", groupmst);
                DialogService.Close(groupmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateGroupMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update GroupMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
