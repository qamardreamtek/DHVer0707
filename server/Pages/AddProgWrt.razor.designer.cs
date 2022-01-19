using System.Collections.Generic;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using CaotunSpring.DH.Tools;
namespace RadzenDh5.Pages
{
    public partial class AddProgWrtComponent : ComponentBase
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

        [Inject]

        protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }

      
        RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt _progwrt;
        protected RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt progwrt
        {
            get
            {
                return _progwrt;
            }
            set
            {
                if (!object.Equals(_progwrt, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "progwrt", NewValue = value, OldValue = _progwrt };
                    _progwrt = value;
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
            progwrt = new RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt args)
        {
            try
            {
                var mark10Sqlexpress04CreateProgWrtResult = await Mark10Sqlexpress04.CreateProgWrt(progwrt);
                DialogService.Close(progwrt);
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Success", Detail = "新增成功" });

            }
            catch (System.Exception mark10Sqlexpress04CreateProgWrtException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = mark10Sqlexpress04CreateProgWrtException.InnerException.ToString() });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
