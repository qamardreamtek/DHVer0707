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
    public partial class EditUserLogComponent : ComponentBase
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
        public dynamic LOG_DATE { get; set; }

        [Parameter]
        public dynamic LOG_TYPE { get; set; }

        [Parameter]
        public dynamic USER_ID { get; set; }

        [Parameter]
        public dynamic PROG_ID { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.UserLog _userlog;
        protected RadzenDh5.Models.Mark10Sqlexpress04.UserLog userlog
        {
            get
            {
                return _userlog;
            }
            set
            {
                if (!object.Equals(_userlog, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "userlog", NewValue = value, OldValue = _userlog };
                    _userlog = value;
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
            var mark10Sqlexpress04GetUserLogByLogDateAndLogTypeAndUserIdAndProgIdResult = await Mark10Sqlexpress04.GetUserLogByLogDateAndLogTypeAndUserIdAndProgId($"{LOG_DATE}", $"{LOG_TYPE}", $"{USER_ID}", $"{PROG_ID}");
            userlog = mark10Sqlexpress04GetUserLogByLogDateAndLogTypeAndUserIdAndProgIdResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.UserLog args)
        {
            try
            {
                var mark10Sqlexpress04UpdateUserLogResult = await Mark10Sqlexpress04.UpdateUserLog($"{LOG_DATE}", $"{LOG_TYPE}", $"{USER_ID}", $"{PROG_ID}", userlog);
                DialogService.Close(userlog);
            }
            catch (System.Exception mark10Sqlexpress04UpdateUserLogException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update UserLog" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
