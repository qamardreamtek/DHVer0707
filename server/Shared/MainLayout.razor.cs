using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
namespace RadzenDh5.Layouts
{
    public partial class MainLayoutComponent
    {

     



        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                sidebar0.Toggle();
                body0.Toggle();


                //sidebarExpanded = true;
                //bodyExpanded = false;
            }
        }
    }
}
