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

namespace RadzenDh5.Pages
{
    public partial class PicSnosComponent : ComponentBase
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
        protected Mark10Sqlexpress04Service Mark10Sqlexpress04 { get; set; }
        protected RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicSno> grid0;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicSno> _getPicSnosResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicSno> getPicSnosResult
        {
            get
            {
                return _getPicSnosResult;
            }
            set
            {
                if (!object.Equals(_getPicSnosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPicSnosResult", NewValue = value, OldValue = _getPicSnosResult };
                    _getPicSnosResult = value;
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
            var mark10Sqlexpress04GetPicSnosResult = await Mark10Sqlexpress04.GetPicSnos();
            getPicSnosResult = mark10Sqlexpress04GetPicSnosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddPicSno>("Add Pic Sno", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RadzenDh5.Models.Mark10Sqlexpress04.PicSno args)
        {
            var dialogResult = await DialogService.OpenAsync<EditPicSno>("Edit Pic Sno", new Dictionary<string, object>() { {"WHSE_NO", args.WHSE_NO}, {"PIC_NO", args.PIC_NO}, {"PIC_LINE", args.PIC_LINE}, {"IN_SNO", args.IN_SNO}, {"IN_NO", args.IN_NO}, {"IN_LINE", args.IN_LINE} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var mark10Sqlexpress04DeletePicSnoResult = await Mark10Sqlexpress04.DeletePicSno($"{data.WHSE_NO}", $"{data.PIC_NO}", $"{data.PIC_LINE}", $"{data.IN_SNO}", $"{data.IN_NO}", $"{data.IN_LINE}");
                    if (mark10Sqlexpress04DeletePicSnoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception mark10Sqlexpress04DeletePicSnoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PicSno" });
            }
        }
    }
}
