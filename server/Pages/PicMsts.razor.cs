using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using CaotunSpring.DH.Tools;

namespace RadzenDh5.Pages
{
    public partial class PicMstsComponent
    {
        //public int QueryOrEdit = 1;
        [Inject] protected DhGlobalsService DhGlobals { get; set; }
    }
}
