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
    public partial class Q050CoreComponent : Q000Component
    {
     

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> grid0;

        //IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InMst> _getInMstsResult;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InDtl> getInDtlsResult;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InSno> getInSnosResult;


//        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.InMst> getInMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> getOutMstsResult;

    

        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q050";
            await base.OnInitializedAsync();

        }
    

    }
}
