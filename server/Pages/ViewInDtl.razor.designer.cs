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
    public partial class ViewInDtlComponent : RadzenViewComponent
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
        public dynamic IN_NO { get; set; }

        [Parameter]
        public dynamic IN_LINE { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.InDtl _indtl;
        protected RadzenDh5.Models.Mark10Sqlexpress04.InDtl indtl
        {
            get
            {
                return _indtl;
            }
            set
            {
                if (!object.Equals(_indtl, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "indtl", NewValue = value, OldValue = _indtl };
                    _indtl = value;
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
            var mark10Sqlexpress04GetInDtlByWhseNoAndInNoAndInLineResult = await Mark10Sqlexpress04.GetInDtlByWhseNoAndInNoAndInLine($"{WHSE_NO}", $"{IN_NO}", $"{IN_LINE}");
            indtl = mark10Sqlexpress04GetInDtlByWhseNoAndInNoAndInLineResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.InDtl args)
        {
            try
            {
                var mark10Sqlexpress04UpdateInDtlResult = await Mark10Sqlexpress04.UpdateInDtl($"{WHSE_NO}", $"{IN_NO}", $"{IN_LINE}", indtl);
                DialogService.Close(indtl);
            }
            catch (System.Exception mark10Sqlexpress04UpdateInDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update InDtl" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
