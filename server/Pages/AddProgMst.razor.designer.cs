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
    public partial class AddProgMstComponent : RadzenViewComponent
    {
        [Parameter]
        public dynamic COPY_PROG_ID { get; set; } // template to create new record

        [Parameter]
        public dynamic USER_NAME { get; set; } // Who create this record


        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }










        RadzenDh5.Models.Mark10Sqlexpress04.ProgMst _progmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.ProgMst progmst
        {
            get
            {
                return _progmst;
            }
            set
            {
                if (!object.Equals(_progmst, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "progmst", NewValue = value, OldValue = _progmst };
                    _progmst = value;
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
            progmst = new RadzenDh5.Models.Mark10Sqlexpress04.ProgMst(){};

            // 處理沒有使用模板
            var mark10Sqlexpress04GetProgMstByProgIdResult = await Mark10Sqlexpress04.GetProgMstByProgId($"{COPY_PROG_ID}");
            if (mark10Sqlexpress04GetProgMstByProgIdResult != null)
            {

                var x = mark10Sqlexpress04GetProgMstByProgIdResult;

                progmst.PROG_ID = x.PROG_ID;
                progmst.PROG_NAME = x.PROG_NAME;
                progmst.PROG_TYPE = x.PROG_TYPE;
                progmst.PROG_NODE = x.PROG_NODE;
                progmst.PROG_PATH = x.PROG_PATH;
                progmst.PROG_SNO = x.PROG_SNO;

                progmst.PARENT_ID = x.PARENT_ID;

                progmst.ENABLE = x.ENABLE;
                progmst.REMARK = x.REMARK;

                progmst.TW_NAME = x.TW_NAME;
                progmst.CN_NAME = x.CN_NAME;
                progmst.TH_NAME = x.TH_NAME;
                progmst.VN_NAME = x.VN_NAME;

            }
        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.ProgMst args)
        {
            try
            {
                // Dev Note by Mark, 05/29
                // 檢查是否有同 USER_ID
                var checking = await Mark10Sqlexpress04.GetProgMstByProgId($"{args.PROG_ID}");
                if (checking != null)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"", Detail = $"data had exist", Duration = 8000 });
                    return;
                }

                args.TRN_USER = (string)USER_NAME;
                args.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                args.CRT_USER = (string)USER_NAME;
                args.CRT_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));


                var mark10Sqlexpress04CreateProgMstResult = await Mark10Sqlexpress04.CreateProgMst(progmst);
                DialogService.Close(progmst);
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"{ex.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
