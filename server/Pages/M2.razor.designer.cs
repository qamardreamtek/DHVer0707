namespace RadzenDh5.Pages
{
    public partial class M2Component : RadzenViewComponent
    {


        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

    }
}
