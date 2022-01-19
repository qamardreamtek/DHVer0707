using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RadzenDh5.Pages
{
    public partial class LocDtlsComponent
    {
        public int value = 1;
        public int? nullableValue = null;

     //   EventConsole console;

        public void OnChange(int? value, string name)
        {
          //  console.Log($"{name} value changed to {value}");
        }
    }
}
