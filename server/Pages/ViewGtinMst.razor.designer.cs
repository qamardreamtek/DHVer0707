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
    public partial class ViewGtinMstComponent : RadzenViewComponent
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

        [Parameter]
        public dynamic GTIN_UNIT { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.GtinMst _gtinmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.GtinMst gtinmst
        {
            get
            {
                return _gtinmst;
            }
            set
            {
                if (!object.Equals(_gtinmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "gtinmst", NewValue = value, OldValue = _gtinmst };
                    _gtinmst = value;
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
            var mark10Sqlexpress04GetGtinMstBySkuNoAndGtinUnitResult = await Mark10Sqlexpress04.GetGtinMstBySkuNoAndGtinUnit($"{SKU_NO}", $"{GTIN_UNIT}");
            gtinmst = mark10Sqlexpress04GetGtinMstBySkuNoAndGtinUnitResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.GtinMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateGtinMstResult = await Mark10Sqlexpress04.UpdateGtinMst($"{SKU_NO}", $"{GTIN_UNIT}", gtinmst);
                DialogService.Close(gtinmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateGtinMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update GtinMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
