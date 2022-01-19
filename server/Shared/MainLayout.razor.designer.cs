using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.AspNetCore.Identity;
using RadzenDh5.Models;
using Microsoft.JSInterop;
using RadzenDh5.Pages;

namespace RadzenDh5.Layouts
{
    public partial class MainLayoutComponent : LayoutComponentBase
    {
        [Inject]
        protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }

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
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }

        protected RadzenBody body0;
        protected RadzenSidebar sidebar0;

        public string localUser { get; set; }


        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0029?f1url=%3FappId%3Droslyn%26k%3Dk(CS0029)
        //public string DH_USER_ID {
        //    get
        //    { return GetAppUserAsync(); }
        //         set; }

        string _Culture;
        protected string Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                if(!object.Equals(_Culture, value))
                {
                    _Culture = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        private void Authenticated()
        {
             StateHasChanged();
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
      


            if (Security != null)
             {
                  Security.Authenticated += Authenticated;

                  await Security.InitializeAsync(AuthenticationStateProvider);
             }
             await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            Culture = "";

            Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
        }

        protected async System.Threading.Tasks.Task SidebarToggle0Click(dynamic args)
        {
            await InvokeAsync(() => { sidebar0.Toggle(); });

            await InvokeAsync(() => { body0.Toggle(); });
        }

        protected async System.Threading.Tasks.Task Dropdown1Change(dynamic args)
        {
            var redirect = new Uri(UriHelper.Uri).GetComponents(UriComponents.PathAndQuery | UriComponents.Fragment, UriFormat.UriEscaped);

            var query = $"?culture={Uri.EscapeDataString((string)args)}&redirectUri={redirect}";

            UriHelper.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
        }
    }
}
