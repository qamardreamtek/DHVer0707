namespace RadzenDh5.Pages
{
    public partial class DhLogoutComponent : RadzenViewComponent
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
