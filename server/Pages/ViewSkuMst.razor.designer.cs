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
    public partial class ViewSkuMstComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic SKU_NO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.SkuMst _skumst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.SkuMst skumst
        {
            get
            {
                return _skumst;
            }
            set
            {
                if (!object.Equals(_skumst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "skumst", NewValue = value, OldValue = _skumst };
                    _skumst = value;
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
            var mark10Sqlexpress04GetSkuMstBySkuNoResult = await Mark10Sqlexpress04.GetSkuMstBySkuNo($"{SKU_NO}");
            skumst = mark10Sqlexpress04GetSkuMstBySkuNoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.SkuMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateSkuMstResult = await Mark10Sqlexpress04.UpdateSkuMst($"{SKU_NO}", skumst);
                DialogService.Close(skumst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateSkuMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update SkuMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
