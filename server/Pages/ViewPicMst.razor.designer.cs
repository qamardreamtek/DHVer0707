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
    public partial class ViewPicMstComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic WHSE_NO { get; set; }

        [Parameter]
        public dynamic PIC_NO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.PicMst _picmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.PicMst picmst
        {
            get
            {
                return _picmst;
            }
            set
            {
                if (!object.Equals(_picmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "picmst", NewValue = value, OldValue = _picmst };
                    _picmst = value;
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
            var mark10Sqlexpress04GetPicMstByWhseNoAndPicNoResult = await Mark10Sqlexpress04.GetPicMstByWhseNoAndPicNo($"{WHSE_NO}", $"{PIC_NO}");
            picmst = mark10Sqlexpress04GetPicMstByWhseNoAndPicNoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.PicMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdatePicMstResult = await Mark10Sqlexpress04.UpdatePicMst($"{WHSE_NO}", $"{PIC_NO}", picmst);
                DialogService.Close(picmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdatePicMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update PicMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
