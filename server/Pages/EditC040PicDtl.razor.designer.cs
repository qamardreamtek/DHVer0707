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
    public partial class EditC040PicDtlComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic WHSE_NO { get; set; }

        [Parameter]
        public dynamic PIC_NO { get; set; }

        [Parameter]
        public dynamic PIC_LINE { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.PicDtl _picdtl;
        protected RadzenDh5.Models.Mark10Sqlexpress04.PicDtl picdtl
        {
            get
            {
                return _picdtl;
            }
            set
            {
                if (!object.Equals(_picdtl, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "picdtl", NewValue = value, OldValue = _picdtl };
                    _picdtl = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
{
await base.OnInitializedAsync();
await base.OnInitializedAsync();
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var mark10Sqlexpress04GetPicDtlByWhseNoAndPicNoAndPicLineResult = await Mark10Sqlexpress04.GetPicDtlByWhseNoAndPicNoAndPicLine($"{WHSE_NO}", $"{PIC_NO}", $"{PIC_LINE}");
            picdtl = mark10Sqlexpress04GetPicDtlByWhseNoAndPicNoAndPicLineResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.PicDtl args)
        {
            try
            {
                var mark10Sqlexpress04UpdatePicDtlResult = await Mark10Sqlexpress04.UpdatePicDtl($"{WHSE_NO}", $"{PIC_NO}", $"{PIC_LINE}", picdtl);
                DialogService.Close(picdtl);
            }
            catch (System.Exception mark10Sqlexpress04UpdatePicDtlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update PicDtl" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
