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
    public partial class EditLocDtlComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }

        [Parameter]
        public dynamic WHSE_NO { get; set; }

        [Parameter]
        public dynamic SU_ID { get; set; }

        [Parameter]
        public dynamic PLANT { get; set; }

        [Parameter]
        public dynamic STGE_LOC { get; set; }

        [Parameter]
        public dynamic SKU_NO { get; set; }

        [Parameter]
        public dynamic BATCH_NO { get; set; }

        [Parameter]
        public dynamic STK_CAT { get; set; }

        [Parameter]
        public dynamic STK_SPECIAL_IND { get; set; }

        [Parameter]
        public dynamic STK_SPECIAL_NO { get; set; }

        [Parameter]
        public dynamic GTIN_UNIT { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.LocDtl _locdtl;
        protected RadzenDh5.Models.Mark10Sqlexpress04.LocDtl locdtl
        {
            get
            {
                return _locdtl;
            }
            set
            {
                if (!object.Equals(_locdtl, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "locdtl", NewValue = value, OldValue = _locdtl };
                    _locdtl = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
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
            var mark10Sqlexpress04GetLocDtlByWhseNoAndSuIdAndPlantAndStgeLocAndSkuNoAndBatchNoAndStkCatAndStkSpecialIndAndStkSpecialNoAndGtinUnitResult = await Mark10Sqlexpress04.GetLocDtlByWhseNoAndSuIdAndPlantAndStgeLocAndSkuNoAndBatchNoAndStkCatAndStkSpecialIndAndStkSpecialNoAndGtinUnit($"{WHSE_NO}", $"{SU_ID}", $"{PLANT}", $"{STGE_LOC}", $"{SKU_NO}", $"{BATCH_NO}", $"{STK_CAT}", $"{STK_SPECIAL_IND}", $"{STK_SPECIAL_NO}", $"{GTIN_UNIT}");
            locdtl = mark10Sqlexpress04GetLocDtlByWhseNoAndSuIdAndPlantAndStgeLocAndSkuNoAndBatchNoAndStkCatAndStkSpecialIndAndStkSpecialNoAndGtinUnitResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.LocDtl args)
        {
            try
            {
                var mark10Sqlexpress04UpdateLocDtlResult = await Mark10Sqlexpress04.UpdateLocDtl($"{WHSE_NO}", $"{SU_ID}", $"{PLANT}", $"{STGE_LOC}", $"{SKU_NO}", $"{BATCH_NO}", $"{STK_CAT}", $"{STK_SPECIAL_IND}", $"{STK_SPECIAL_NO}", $"{GTIN_UNIT}", locdtl);
                DialogService.Close(locdtl);
            }
            catch (System.Exception mark10Sqlexpress04UpdateLocDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update LocDtl" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
