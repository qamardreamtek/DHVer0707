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
    public partial class EditPckSnoComponent : ComponentBase
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
        public dynamic PCK_NO { get; set; }

        [Parameter]
        public dynamic IN_SNO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.PckSno _pcksno;
        protected RadzenDh5.Models.Mark10Sqlexpress04.PckSno pcksno
        {
            get
            {
                return _pcksno;
            }
            set
            {
                if (!object.Equals(_pcksno, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "pcksno", NewValue = value, OldValue = _pcksno };
                    _pcksno = value;
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
            var mark10Sqlexpress04GetPckSnoByWhseNoAndPckNoAndInSnoResult = await Mark10Sqlexpress04.GetPckSnoByWhseNoAndPckNoAndInSno($"{WHSE_NO}", $"{PCK_NO}", $"{IN_SNO}");
            pcksno = mark10Sqlexpress04GetPckSnoByWhseNoAndPckNoAndInSnoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.PckSno args)
        {
            try
            {
                var mark10Sqlexpress04UpdatePckSnoResult = await Mark10Sqlexpress04.UpdatePckSno($"{WHSE_NO}", $"{PCK_NO}", $"{IN_SNO}", pcksno);
                DialogService.Close(pcksno);
            }
            catch (System.Exception mark10Sqlexpress04UpdatePckSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update PckSno" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
