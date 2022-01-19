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
    public partial class ViewOutMstComponent : RadzenViewComponent
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
        public dynamic OUT_NO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.OutMst _outmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.OutMst outmst
        {
            get
            {
                return _outmst;
            }
            set
            {
                if (!object.Equals(_outmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "outmst", NewValue = value, OldValue = _outmst };
                    _outmst = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
{
await base.OnInitializedAsync();
            await Security.InitializeAsync(AuthenticationStateProvider);
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
            var mark10Sqlexpress04GetOutMstByWhseNoAndOutNoResult = await Mark10Sqlexpress04.GetOutMstByWhseNoAndOutNo($"{WHSE_NO}", $"{OUT_NO}");
            outmst = mark10Sqlexpress04GetOutMstByWhseNoAndOutNoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.OutMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateOutMstResult = await Mark10Sqlexpress04.UpdateOutMst($"{WHSE_NO}", $"{OUT_NO}", outmst);
                DialogService.Close(outmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateOutMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update OutMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
