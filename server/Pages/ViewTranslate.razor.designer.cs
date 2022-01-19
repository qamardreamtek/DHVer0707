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
    public partial class ViewTranslateComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }








        [Parameter]
        public dynamic TEXT { get; set; }

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
await base.OnInitializedAsync();
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetTranslateByTextResult = await Mark10Sqlexpress04.GetTranslateByText($"{TEXT}");
            translate = mark10Sqlexpress04GetTranslateByTextResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.Translate args)
        {
            try
            {
                var mark10Sqlexpress04UpdateTranslateResult = await Mark10Sqlexpress04.UpdateTranslate($"{TEXT}", translate);
                DialogService.Close(translate);
            }
            catch (System.Exception mark10Sqlexpress04UpdateTranslateException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Translate" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
