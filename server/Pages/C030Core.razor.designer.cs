using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;

namespace RadzenDh5.Pages
{
      public partial class C030CoreComponent : C000Component
    {
     
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

      

  

        //NOTE by Mark
        //DataTable dtMST = new DataTable("PIC_MST"); //盤點主檔
        //DataTable dtDTL = new DataTable("PIC_DTL"); //盤點明細檔
        //DataTable dtSNO = new DataTable("PIC_SNO"); //盤點序列號檔
        //[Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        public IList<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> picMstsLIst
        {
            get { return new List<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>(getPicMstsResult); }
        }


   
        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPicMst>("Add Pic Mst", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        
        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePicMstResult = await Mark10Sqlexpress04.DeletePicMst($"{data.WHSE_NO}", $"{data.PIC_NO}");
                    if (mark10Sqlexpress04DeletePicMstResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePicMstException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete PicMst" });
            }
        }
    }
}
