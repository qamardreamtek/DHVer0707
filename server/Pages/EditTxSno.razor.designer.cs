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
    public partial class EditTxSnoComponent : ComponentBase
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
        public dynamic TX_NO { get; set; }

        [Parameter]
        public dynamic TX_LINE { get; set; }

        [Parameter]
        public dynamic IN_SNO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.TxSno _txsno;
        protected RadzenDh5.Models.Mark10Sqlexpress04.TxSno txsno
        {
            get
            {
                return _txsno;
            }
            set
            {
                if (!object.Equals(_txsno, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "txsno", NewValue = value, OldValue = _txsno };
                    _txsno = value;
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
            var mark10Sqlexpress04GetTxSnoByTxNoAndTxLineAndInSnoResult = await Mark10Sqlexpress04.GetTxSnoByTxNoAndTxLineAndInSno($"{TX_NO}", $"{TX_LINE}", $"{IN_SNO}");
            txsno = mark10Sqlexpress04GetTxSnoByTxNoAndTxLineAndInSnoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.TxSno args)
        {
            try
            {
                var mark10Sqlexpress04UpdateTxSnoResult = await Mark10Sqlexpress04.UpdateTxSno($"{TX_NO}", $"{TX_LINE}", $"{IN_SNO}", txsno);
                DialogService.Close(txsno);
            }
            catch (System.Exception mark10Sqlexpress04UpdateTxSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update TxSno" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
