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
    public partial class ViewInSnoComponent : RadzenViewComponent
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

        [Parameter]
        public dynamic SU_ID { get; set; }

        [Parameter]
        public dynamic IN_SNO1 { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.InSno _insno;
        protected RadzenDh5.Models.Mark10Sqlexpress04.InSno insno
        {
            get
            {
                return _insno;
            }
            set
            {
                if (!object.Equals(_insno, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "insno", NewValue = value, OldValue = _insno };
                    _insno = value;
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
            var mark10Sqlexpress04GetInSnoByWhseNoAndInNoAndInLineAndSuIdAndInSno1Result = await Mark10Sqlexpress04.GetInSnoByWhseNoAndInNoAndInLineAndSuIdAndInSno1($"{WHSE_NO}", $"{IN_NO}", $"{IN_LINE}", $"{SU_ID}", $"{IN_SNO1}");
            insno = mark10Sqlexpress04GetInSnoByWhseNoAndInNoAndInLineAndSuIdAndInSno1Result;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.InSno args)
        {
            try
            {
                var mark10Sqlexpress04UpdateInSnoResult = await Mark10Sqlexpress04.UpdateInSno($"{WHSE_NO}", $"{IN_NO}", $"{IN_LINE}", $"{SU_ID}", $"{IN_SNO1}", insno);
                DialogService.Close(insno);
            }
            catch (System.Exception mark10Sqlexpress04UpdateInSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update InSno" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
