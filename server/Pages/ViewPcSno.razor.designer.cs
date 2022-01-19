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
    public partial class ViewPcSnoComponent : RadzenViewComponent
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
        public dynamic PC_NO { get; set; }

        [Parameter]
        public dynamic PC_LINE { get; set; }

        [Parameter]
        public dynamic IN_SNO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.PcSno _pcsno;
        protected RadzenDh5.Models.Mark10Sqlexpress04.PcSno pcsno
        {
            get
            {
                return _pcsno;
            }
            set
            {
                if (!object.Equals(_pcsno, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "pcsno", NewValue = value, OldValue = _pcsno };
                    _pcsno = value;
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
            var mark10Sqlexpress04GetPcSnoByWhseNoAndPcNoAndPcLineAndInSnoResult = await Mark10Sqlexpress04.GetPcSnoByWhseNoAndPcNoAndPcLineAndInSno($"{WHSE_NO}", $"{PC_NO}", $"{PC_LINE}", $"{IN_SNO}");
            pcsno = mark10Sqlexpress04GetPcSnoByWhseNoAndPcNoAndPcLineAndInSnoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.PcSno args)
        {
            try
            {
                var mark10Sqlexpress04UpdatePcSnoResult = await Mark10Sqlexpress04.UpdatePcSno($"{WHSE_NO}", $"{PC_NO}", $"{PC_LINE}", $"{IN_SNO}", pcsno);
                DialogService.Close(pcsno);
            }
            catch (System.Exception mark10Sqlexpress04UpdatePcSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update PcSno" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
