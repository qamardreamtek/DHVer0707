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
    public partial class ViewCmdMstComponent : RadzenViewComponent
    {

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        [Parameter]
        public dynamic CMD_DATE { get; set; }

        [Parameter]
        public dynamic CMD_SNO { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.CmdMst _cmdmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.CmdMst cmdmst
        {
            get
            {
                return _cmdmst;
            }
            set
            {
                if (!object.Equals(_cmdmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "cmdmst", NewValue = value, OldValue = _cmdmst };
                    _cmdmst = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
{
await base.OnInitializedAsync();
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
            var mark10Sqlexpress04GetCmdMstByCmdDateAndCmdSnoResult = await Mark10Sqlexpress04.GetCmdMstByCmdDateAndCmdSno($"{CMD_DATE}", $"{CMD_SNO}");
            cmdmst = mark10Sqlexpress04GetCmdMstByCmdDateAndCmdSnoResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.CmdMst args)
        {
            try
            {
                var mark10Sqlexpress04UpdateCmdMstResult = await Mark10Sqlexpress04.UpdateCmdMst($"{CMD_DATE}", $"{CMD_SNO}", cmdmst);
                DialogService.Close(cmdmst);
            }
            catch (System.Exception mark10Sqlexpress04UpdateCmdMstException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update CmdMst" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
