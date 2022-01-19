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
    public partial class EditProgMstComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic PROG_ID { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.ProgMst _progmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.ProgMst progmst
        {
            get
            {
                return _progmst;
            }
            set
            {
                if (!object.Equals(_progmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "progmst", NewValue = value, OldValue = _progmst };
                    _progmst = value;
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
            var mark10Sqlexpress04GetProgMstByProgIdResult = await Mark10Sqlexpress04.GetProgMstByProgId($"{PROG_ID}");
            progmst = mark10Sqlexpress04GetProgMstByProgIdResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateProgMstResult = await Mark10Sqlexpress04.UpdateProgMst($"{PROG_ID}", progmst);
                DialogService.Close(progmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateProgMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update ProgMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
