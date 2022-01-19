using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RadzenDh5.Pages
{
    public partial class C010CoreComponent : C000Component
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

      
       
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "C010";
            await base.OnInitializedAsync();

            // btn Disable Note by Mark, 05/27
            boolBtnExecuteDisable = (progWrt.APPROVE_WRT != "Y") ? true : false;


        }

    }
}
