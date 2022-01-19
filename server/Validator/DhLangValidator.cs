using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace RadzenDh5.Validator
{
    public class DhLangValidator : ValidatorBase

    {
        [Parameter]
        public override string Text { get; set; } = "Language只能在EN,TW,CN,TH,VN";

        //[Parameter]
        //public int? Min { get; set; }

        //[Parameter]
        //public int? Max { get; set; }
        //Language只能在EN,TW,CN,TH,VN
        protected override bool Validate(IRadzenFormComponent component)
        {
            string value = component.GetValue() as string;
            if (value == "EN") return true;
            if (value == "TW") return true;
            if (value == "CN") return true;
            if (value == "TH") return true;
            if (value == "VN") return true;
            return false;
         
        }
    }
}
