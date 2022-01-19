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
    public partial class EditGroupWrtComponent : ComponentBase
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
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }

        [Parameter]
        public dynamic GROUP_ID { get; set; }

        [Parameter]
        public dynamic PROG_ID { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt _groupwrt;
        protected RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt groupwrt
        {
            get
            {
                return _groupwrt;
            }
            set
            {
                if (!object.Equals(_groupwrt, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "groupwrt", NewValue = value, OldValue = _groupwrt };
                    _groupwrt = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
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
            var mark10Sqlexpress04GetGroupWrtByGroupIdAndProgIdResult = await Mark10Sqlexpress04.GetGroupWrtByGroupIdAndProgId($"{GROUP_ID}", $"{PROG_ID}");

            //Note by Mark, 根據 06/11 meeting, 如果沒有值, 或是沒有看得到的值, 在UI給-, 方便用戶去改
            if (mark10Sqlexpress04GetGroupWrtByGroupIdAndProgIdResult.ENABLE == null || mark10Sqlexpress04GetGroupWrtByGroupIdAndProgIdResult.ENABLE == "" || mark10Sqlexpress04GetGroupWrtByGroupIdAndProgIdResult.ENABLE == " ")
            {
                mark10Sqlexpress04GetGroupWrtByGroupIdAndProgIdResult.ENABLE = "-";
            }


            groupwrt = mark10Sqlexpress04GetGroupWrtByGroupIdAndProgIdResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt args)
        {
            try
            {
                var mark10Sqlexpress04UpdateGroupWrtResult = await Mark10Sqlexpress04.UpdateGroupWrt($"{GROUP_ID}", $"{PROG_ID}", groupwrt);
                DialogService.Close(groupwrt);
            }
            catch (System.Exception mark10Sqlexpress04UpdateGroupWrtException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update GroupWrt" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
