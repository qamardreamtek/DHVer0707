using System.Threading.Tasks;

namespace RadzenDh5.Pages
{
    public partial class Q120CoreComponent : Q000Component
    {
        protected override async Task OnInitializedAsync()
        {
            PROG_ID = "Q120";
            await base.OnInitializedAsync();

        }
    }
}
