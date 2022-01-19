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
using CaotunSpring.DH.Tools;

namespace RadzenDh5.Pages
{
    public partial class AddGroupMstComponent : RadzenViewComponent
    {
        [Parameter]
        public dynamic COPY_GROUP_ID { get; set; } // template to create new record

        //[Parameter]
        //public dynamic USER_NAME { get; set; } // Who create this record



        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }









        RadzenDh5.Models.Mark10Sqlexpress04.GroupMst _groupmst;
        protected RadzenDh5.Models.Mark10Sqlexpress04.GroupMst groupmst
        {
            get
            {
                return _groupmst;
            }
            set
            {
                if (!object.Equals(_groupmst, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "groupmst", NewValue = value, OldValue = _groupmst };
                    _groupmst = value;
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
            groupmst = new RadzenDh5.Models.Mark10Sqlexpress04.GroupMst() { };

            // 處理沒有使用模板
            var mark10Sqlexpress04GetGroupMstByGroupIdResult = await Mark10Sqlexpress04.GetGroupMstByGroupId($"{COPY_GROUP_ID}");
            if (mark10Sqlexpress04GetGroupMstByGroupIdResult != null)
            {

                var x = mark10Sqlexpress04GetGroupMstByGroupIdResult;

                groupmst.GROUP_ID = x.GROUP_ID;
                groupmst.GROUP_NAME = x.GROUP_NAME;
                groupmst.OWNER_ID = x.OWNER_ID;
                groupmst.OWNER_NAME = x.OWNER_NAME;
                groupmst.ENABLE = x.ENABLE;
                groupmst.REMARK = x.REMARK;
            }




        }

        protected async System.Threading.Tasks.Task Form0Submit(RadzenDh5.Models.Mark10Sqlexpress04.GroupMst args)
        {
            try
            {
                // Dev Note by Mark, 05/29
                // 檢查是否有同 USER_ID
                var checking = await Mark10Sqlexpress04.GetGroupMstByGroupId($"{args.GROUP_ID}");
                if (checking != null)
                {
                    await SimpleDialog("data had exist");
                    return;
                }

                // DEBUG 06/17, https://github.com/twoutlook/DH5Ver0414_PUBLISH/discussions/143
                var checking2 = await Mark10Sqlexpress04.GetUserMstByUserId($"{args.OWNER_ID}");
                if (checking2 == null)
                {
                    await SimpleDialog("not valid user id");
                    return;
                }


                args.TRN_USER = (string)USER_NAME;
                args.TRN_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                args.CRT_USER = (string)USER_NAME;
                args.CRT_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));

                var mark10Sqlexpress04CreateGroupMstResult = await Mark10Sqlexpress04.CreateGroupMst(args);
                DialogService.Close(groupmst);
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
