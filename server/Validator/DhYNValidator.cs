using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace RadzenDh5.Validator
{
    public class DhYNValidator : ValidatorBase

    {
        [Parameter]
        public override string Text { get; set; } = "only allow Y or N";

        //[Parameter]
        //public int? Min { get; set; }

        //[Parameter]
        //public int? Max { get; set; }

        protected override bool Validate(IRadzenFormComponent component)
        {
            string value = component.GetValue() as string;
            if (value == "Y") return true;
            if (value == "N") return true;

            return false;
            //if (Min.HasValue && ((value != null && value.Length < Min) || value == null))
            //{
            //    return false;
            //}

            //if (Max.HasValue && (value != null && value.Length > Max))
            //{
            //    return false;
            //}

            //return true;
        }
    }
}
