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

namespace RadzenDh5.Pages
{
    public partial class EditC030PicSnoComponent : ComponentBase
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

        [Parameter]
        public dynamic WHSE_NO { get; set; }

        [Parameter]
        public dynamic PIC_NO { get; set; }

        [Parameter]
        public dynamic PIC_LINE { get; set; }

        [Parameter]
        public dynamic IN_SNO { get; set; }

        [Parameter]
        public dynamic IN_NO { get; set; }

        [Parameter]
        public dynamic IN_LINE { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.PicSno _picsno;
        protected RadzenDh5.Models.Mark10Sqlexpress04.PicSno picsno
        {
            get
            {
                return _picsno;
            }
            set
            {
                if (!object.Equals(_picsno, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "picsno", NewValue = value, OldValue = _picsno };
                    _picsno = value;
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
            var mark10Sqlexpress04GetPicSnoByWhseNoAndPicNoAndPicLineAndInSnoAndInNoAndInLineResult = await Mark10Sqlexpress04.GetPicSnoByWhseNoAndPicNoAndPicLineAndInSnoAndInNoAndInLine($"{WHSE_NO}", $"{PIC_NO}", $"{PIC_LINE}", $"{IN_SNO}", $"{IN_NO}", $"{IN_LINE}");
            picsno = mark10Sqlexpress04GetPicSnoByWhseNoAndPicNoAndPicLineAndInSnoAndInNoAndInLineResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.PicSno args)
        {
            try
            {
                var mark10Sqlexpress04UpdatePicSnoResult = await Mark10Sqlexpress04.UpdatePicSno($"{WHSE_NO}", $"{PIC_NO}", $"{PIC_LINE}", $"{IN_SNO}", $"{IN_NO}", $"{IN_LINE}", picsno);
                DialogService.Close(picsno);
            }
            catch (System.Exception mark10Sqlexpress04UpdatePicSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update PicSno" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
