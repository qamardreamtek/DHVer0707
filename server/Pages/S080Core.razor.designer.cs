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
    public partial class S080CoreComponent : S000Component
    {
 
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        
        ApplicationUser _user;
        protected ApplicationUser user
        {
            get
            {
                return _user;
            }
            set
            {
                if (!object.Equals(_user, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "user", NewValue = value, OldValue = _user };
                    _user = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

    
        protected async System.Threading.Tasks.Task Load()
        {
            if (Security.User != null)
            {
                var securityGetUserByIdResult = await Security.GetUserById($"{Security.User.Id}");
                user = securityGetUserByIdResult;
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close();
            await JSRuntime.InvokeAsync<string>("window.history.back");
        }
    

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await Security.Logout();
        }


        //protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.AlarmDef args)
        //{
        //    //try
        //    //{
        //    //    var mark10Sqlexpress04UpdateAlarmDefResult = await Mark10Sqlexpress04.UpdateAlarmDef($"{AlarmCode}", alarmdef);
        //    //    DialogService.Close(alarmdef);
        //    //}
        //    //catch (System.Exception mark10Sqlexpress04UpdateAlarmDefException)
        //    //{
        //    //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update AlarmDef" });
        //    //}
        //}
    }
}
