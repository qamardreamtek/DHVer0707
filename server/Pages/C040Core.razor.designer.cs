using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;

namespace RadzenDh5.Pages
{
    //class TrueOrFalse

    //public partial class PicMstsComponent : ComponentBase
    public partial class C040CoreComponent : C000Component
    {
      
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }


     

      
  
    }
}
