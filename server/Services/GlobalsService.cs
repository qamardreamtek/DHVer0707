using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RadzenDh5.Models;
using RadzenDh5.Models.Mark10Sqlexpress04;
using Radzen;

namespace RadzenDh5
{
    public partial class GlobalsService
    {

    }

    public class PropertyChangedEventArgs
    {
        public string Name { get; set; }
        public object NewValue { get; set; }
        public object OldValue { get; set; }
        public bool IsGlobal { get; set; }
    }
}
