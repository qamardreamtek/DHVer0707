using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;

namespace RadzenDh5.Pages
{
    public partial class ViewInMstComponent : RadzenViewComponent
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

        RadzenDh5.Models.Mark10Sqlexpress04.InMst _inmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.InMst inmst
        {
            get
            {
                return _inmst;
            }
            set
            {
                if (!object.Equals(_inmst, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "inmst", NewValue = value, OldValue = _inmst };
                    _inmst = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetInMstByWhseNoAndInNoResult = await Mark10Sqlexpress04.GetInMstByWhseNoAndInNo($"{WHSE_NO}", $"{IN_NO}");
            inmst = mark10Sqlexpress04GetInMstByWhseNoAndInNoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.InMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateInMstResult = await Mark10Sqlexpress04.UpdateInMst($"{WHSE_NO}", $"{IN_NO}", inmst);
                DialogService.Close(inmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateInMstException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update InMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
