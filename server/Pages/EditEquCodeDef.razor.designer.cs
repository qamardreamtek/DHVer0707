﻿using System;
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
    public partial class EditEquCodeDefComponent : ComponentBase
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
        public dynamic CodeType { get; set; }

        [Parameter]
        public dynamic Code { get; set; }

        RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef _equcodedef;
        protected RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef equcodedef
        {
            get
            {
                return _equcodedef;
            }
            set
            {
                if (!object.Equals(_equcodedef, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "equcodedef", NewValue = value, OldValue = _equcodedef };
                    _equcodedef = value;
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
            var mark10Sqlexpress04GetEquCodeDefByCodeTypeAndCodeResult = await Mark10Sqlexpress04.GetEquCodeDefByCodeTypeAndCode($"{CodeType}", $"{Code}");
            equcodedef = mark10Sqlexpress04GetEquCodeDefByCodeTypeAndCodeResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef args)
        {
            try
            {
                var mark10Sqlexpress04UpdateEquCodeDefResult = await Mark10Sqlexpress04.UpdateEquCodeDef($"{CodeType}", $"{Code}", equcodedef);
                DialogService.Close(equcodedef);
            }
            catch (System.Exception mark10Sqlexpress04UpdateEquCodeDefException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update EquCodeDef" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
