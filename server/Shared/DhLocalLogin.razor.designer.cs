using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Collections.Generic;
namespace RadzenDh5.Pages
{
    public partial class DhLocalLoginComponent : ComponentBase
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
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var error = System.Web.HttpUtility.ParseQueryString(new Uri(UriHelper.ToAbsoluteUri(UriHelper.Uri).ToString()).Query).Get("error");

            if (!string.IsNullOrEmpty(error))
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"{error}" });
            }

            // NOTE by Mark, for Language
            Culture = "";

            Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
        }

        protected async System.Threading.Tasks.Task DhLocalLogin0Register()
        {
            await DialogService.OpenAsync<RegisterApplicationUser>("Register Application User", null);
        }
    }
}
