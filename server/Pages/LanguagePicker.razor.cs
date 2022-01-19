using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace RadzenDh5.Pages
{
  //  public partial class LoginComponent
    public partial class LanguagePickerComponent
    {
        //https://stackoverflow.com/questions/55600984/get-child-component-binded-values-in-parent-component-in-blazor
        [Parameter] public  EventCallback<string> OnUserNameChanged { get; set; }
        private string username;
        public string UserName
        {
            get => username;
            set
            {
                username = value;
                // Invoke the delegate passing it the changed value
                OnUserNameChanged.InvokeAsync(value);
            }
        }


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
                 //   InvokeAsync(() => { StateHasChanged(); });
                    OnUserNameChanged.InvokeAsync(value);
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
