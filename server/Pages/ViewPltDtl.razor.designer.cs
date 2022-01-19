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
    public partial class ViewPltDtlComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic SU_ID { get; set; }

        [Parameter]
        public dynamic IN_SNO { get; set; }

        [Parameter]
        public dynamic WHSE_NO { get; set; }

        [Parameter]
        public dynamic IN_NO { get; set; }

        [Parameter]
        public dynamic IN_LINE { get; set; }

        [Parameter]
        public dynamic STK_CAT { get; set; }

        [Parameter]
        public dynamic STK_SPECIAL_IND { get; set; }

        [Parameter]
        public dynamic STK_SPECIAL_NO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.PltDtl _pltdtl;
        protected RadzenDh5.Models.Mark10Sqlexpress04.PltDtl pltdtl
        {
            get
            {
                return _pltdtl;
            }
            set
            {
                if (!object.Equals(_pltdtl, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "pltdtl", NewValue = value, OldValue = _pltdtl };
                    _pltdtl = value;
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
            var mark10Sqlexpress04GetPltDtlBySuIdAndInSnoAndWhseNoAndInNoAndInLineAndStkCatAndStkSpecialIndAndStkSpecialNoResult = await Mark10Sqlexpress04.GetPltDtlBySuIdAndInSnoAndWhseNoAndInNoAndInLineAndStkCatAndStkSpecialIndAndStkSpecialNo($"{SU_ID}", $"{IN_SNO}", $"{WHSE_NO}", $"{IN_NO}", $"{IN_LINE}", $"{STK_CAT}", $"{STK_SPECIAL_IND}", $"{STK_SPECIAL_NO}");
            pltdtl = mark10Sqlexpress04GetPltDtlBySuIdAndInSnoAndWhseNoAndInNoAndInLineAndStkCatAndStkSpecialIndAndStkSpecialNoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.PltDtl args)
        {
            try
            {
                var mark10Sqlexpress04UpdatePltDtlResult = await Mark10Sqlexpress04.UpdatePltDtl($"{SU_ID}", $"{IN_SNO}", $"{WHSE_NO}", $"{IN_NO}", $"{IN_LINE}", $"{STK_CAT}", $"{STK_SPECIAL_IND}", $"{STK_SPECIAL_NO}", pltdtl);
                DialogService.Close(pltdtl);
            }
            catch (System.Exception mark10Sqlexpress04UpdatePltDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update PltDtl" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
