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
    public partial class EditEquMplcCmdHiComponent : ComponentBase
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
        public dynamic EquNo { get; set; }

        [Parameter]
        public dynamic D0 { get; set; }

        [Parameter]
        public dynamic D1 { get; set; }

        [Parameter]
        public dynamic D14 { get; set; }

        [Parameter]
        public dynamic LogDT { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi _equmplccmdhi;
        protected RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi equmplccmdhi
        {
            get
            {
                return _equmplccmdhi;
            }
            set
            {
                if (!object.Equals(_equmplccmdhi, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "equmplccmdhi", NewValue = value, OldValue = _equmplccmdhi };
                    _equmplccmdhi = value;
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
            var mark10Sqlexpress04GetEquMplcCmdHiByEquNoAndD0AndD1AndD14AndLogDtResult = await Mark10Sqlexpress04.GetEquMplcCmdHiByEquNoAndD0AndD1AndD14AndLogDt($"{EquNo}", $"{D0}", $"{D1}", $"{D14}", $"{LogDT}");
            equmplccmdhi = mark10Sqlexpress04GetEquMplcCmdHiByEquNoAndD0AndD1AndD14AndLogDtResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi args)
        {
            try
            {
                var mark10Sqlexpress04UpdateEquMplcCmdHiResult = await Mark10Sqlexpress04.UpdateEquMplcCmdHi($"{EquNo}", $"{D0}", $"{D1}", $"{D14}", $"{LogDT}", equmplccmdhi);
                DialogService.Close(equmplccmdhi);
            }
            catch (System.Exception mark10Sqlexpress04UpdateEquMplcCmdHiException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update EquMplcCmdHi" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
