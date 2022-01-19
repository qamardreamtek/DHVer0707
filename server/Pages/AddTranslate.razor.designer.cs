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
    public partial class AddTranslateComponent : ComponentBase
    {
        [Parameter]
        public dynamic COPY_TEXT { get; set; } // template to create new record

        [Parameter]
        public dynamic USER_NAME { get; set; } // Who create this record
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

        RadzenDh5.Models.Mark10Sqlexpress04.Translate _translate;
        protected RadzenDh5.Models.Mark10Sqlexpress04.Translate translate
        {
            get
            {
                return _translate;
            }
            set
            {
                if (!object.Equals(_translate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "translate", NewValue = value, OldValue = _translate };
                    _translate = value;
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
            translate = new RadzenDh5.Models.Mark10Sqlexpress04.Translate() { };

            var x = await Mark10Sqlexpress04.GetTranslateByText($"{COPY_TEXT}");
            if (x == null) return; // 沒有或是不用模板

            translate.EN_TEXT = x.EN_TEXT;
            translate.TW_TEXT = x.TW_TEXT;
            translate.CN_TEXT = x.CN_TEXT;
            translate.TH_TEXT = x.TH_TEXT;
            translate.VN_TEXT = x.VN_TEXT;
            translate.TEXT = x.TEXT;

        }
        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.Translate args)
        {
            try
            {
                // Dev Note by Mark, 05/30
                // 檢查是否有同 PK
                var checking = await Mark10Sqlexpress04.GetTranslateByText($"{args.TEXT}");
                if (checking != null)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"", Detail = $"data had exist", Duration = 8000 });
                    return;
                }


                var mark10Sqlexpress04CreateTranslateResult = await Mark10Sqlexpress04.CreateTranslate(translate);
                DialogService.Close(translate);
            }
            catch (System.Exception ex)
            {
           //     throw new Exception(mark10Sqlexpress04CreateTranslateException.Message);
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Info,Summary = $"{ex.Message}",Duration=9000});
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
