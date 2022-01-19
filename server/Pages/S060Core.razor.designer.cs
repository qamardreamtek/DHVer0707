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
    public partial class S060CoreComponent : S000Component

    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }


        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> _getUserMstsResult;

        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> getUserMstsResult
        {
            get
            {
                return _getUserMstsResult;
            }
            set
            {
                if (!object.Equals(_getUserMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getUserMstsResult", NewValue = value, OldValue = _getUserMstsResult };
                    _getUserMstsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }


    }
}
