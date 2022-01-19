using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;

namespace RadzenDh5.Pages
{
    public partial class WelcomeComponent
    {
        [Inject]
        public Mark10Sqlexpress04Context Context { get; set; }

        public IEnumerable<Stats> UserStats { get; set; }
        
        
        string _Culture;
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

        protected async System.Threading.Tasks.Task Dropdown1Change(dynamic args)
        {
            var redirect = new Uri(UriHelper.Uri).GetComponents(UriComponents.PathAndQuery | UriComponents.Fragment, UriFormat.UriEscaped);

            var query = $"?culture={Uri.EscapeDataString((string)args)}&redirectUri={redirect}";

            UriHelper.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
        }


        protected override void OnInitialized()
        {
    
             UserStats = Context.VUserRoles
                .GroupBy(x => x.UserName)
                .Select(g => new Stats()
                { UserName = g.Key, RoleCnt = g.Count() }

            );
           
        }
    }

    public class Stats
    {
        public string UserName { get; set; }
        public int RoleCnt { get; set; }
    }
    
}
