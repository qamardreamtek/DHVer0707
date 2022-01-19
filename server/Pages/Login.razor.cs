using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;

namespace RadzenDh5.Pages
{
    public partial class LoginComponent
    {

        string _Culture= "en-US";
        public string Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                if (!object.Equals(_Culture, value))
                {
                    _Culture = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        protected async System.Threading.Tasks.Task LoadLanguage() // change it from Load
        {
            Culture = "";

            Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
        }

       

        protected async System.Threading.Tasks.Task Dropdown1Change(dynamic args)
        {
            var redirect = new Uri(UriHelper.Uri).GetComponents(UriComponents.PathAndQuery | UriComponents.Fragment, UriFormat.UriEscaped);

            var query = $"?culture={Uri.EscapeDataString((string)args)}&redirectUri={redirect}";

            UriHelper.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
        }

    }
}
