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
    public partial class ViewSkuSutComponent : RadzenViewComponent
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
        public dynamic SKU_NO { get; set; }

        [Parameter]
        public dynamic GTIN_UNIT { get; set; }

        [Parameter]
        public dynamic SU_TYPE { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.SkuSut _skusut;
        protected RadzenDh5.Models.Mark10Sqlexpress04.SkuSut skusut
        {
            get
            {
                return _skusut;
            }
            set
            {
                if (!object.Equals(_skusut, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "skusut", NewValue = value, OldValue = _skusut };
                    _skusut = value;
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
            var mark10Sqlexpress04GetSkuSutByWhseNoAndSkuNoAndGtinUnitAndSuTypeResult = await Mark10Sqlexpress04.GetSkuSutByWhseNoAndSkuNoAndGtinUnitAndSuType($"{WHSE_NO}", $"{SKU_NO}", $"{GTIN_UNIT}", $"{SU_TYPE}");
            skusut = mark10Sqlexpress04GetSkuSutByWhseNoAndSkuNoAndGtinUnitAndSuTypeResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.SkuSut args)
        {
            try
            {
                var mark10Sqlexpress04UpdateSkuSutResult = await Mark10Sqlexpress04.UpdateSkuSut($"{WHSE_NO}", $"{SKU_NO}", $"{GTIN_UNIT}", $"{SU_TYPE}", skusut);
                DialogService.Close(skusut);
            }
            catch (System.Exception mark10Sqlexpress04UpdateSkuSutException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update SkuSut" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
