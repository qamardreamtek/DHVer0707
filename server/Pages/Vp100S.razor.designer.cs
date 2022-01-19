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

namespace RadzenDh5.Pages
{
    public partial class Vp100SComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

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
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vp100> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp100> _getVp100sResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vp100> getVp100sResult
        {
            get
            {
                return _getVp100sResult;
            }
            set
            {
                if (!object.Equals(_getVp100sResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVp100sResult", NewValue = value, OldValue = _getVp100sResult };
                    _getVp100sResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetVp100SResult = await Mark10Sqlexpress04.GetVp100S();
            getVp100sResult = mark10Sqlexpress04GetVp100SResult;
        }
    }
}
