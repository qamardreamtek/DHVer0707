#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe5e2993b754adf097d0dcaa7e19675001df57cd"
// <auto-generated/>
#pragma warning disable 1591
namespace RadzenDh5.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using RadzenDh5.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
    public partial class DhTextBoxV2 : FormComponent<string>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
 if (Visible)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-12 col-md-3");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "style", "margin-bottom: 4px;");
            __builder.AddAttribute(4, "class", "row d-flex align-items-center");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "col-md-5  d-flex align-items-center");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(7);
            __builder.AddAttribute(8, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                Label

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "style", "width: 100%;text-align:left;margin-bottom:4px;");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n        ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col-md-7 d-flex align-items-center");
            __builder.OpenElement(13, "input");
            __builder.AddAttribute(14, "disabled", 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                              Disabled

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(15, "readonly", 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                   ReadOnly

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(16, "name", 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                    Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "style", 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                  Style

#line default
#line hidden
#nullable disable
            );
            __builder.AddMultipleAttributes(18, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, object>>>(
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                                      Attributes

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "class", 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                                                          GetCssClass()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(20, "tabindex", 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                                                                                    TabIndex

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(21, "placeholder", 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                 Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(22, "maxlength", 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                          MaxLength

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(23, "autocomplete", 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                     AutoComplete ? "on" : "off"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(24, "value", 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                                                           Value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(25, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                                                                              OnChange

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "id", 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
                                                                                                                                                             GetId()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhTextBoxV2.razor"
        [Parameter]
    public bool ReadOnly { get; set; }



    [Parameter]
    public string Label { get; set; }
    [Parameter]
    public bool AutoComplete { get; set; } = true;

    [Parameter]
    public long? MaxLength { get; set; }

    protected async System.Threading.Tasks.Task OnChange(ChangeEventArgs args)
    {
        Value = $"{args.Value}";

        await ValueChanged.InvokeAsync(Value);
        if (FieldIdentifier.FieldName != null) { EditContext?.NotifyFieldChanged(FieldIdentifier); }
        await Change.InvokeAsync(Value);
    }

    protected override string GetComponentCssClass()
    {
        var disabledCss = Disabled ? " rz-state-disabled" : "";
        var fieldCssClass = FieldIdentifier.FieldName != null ? EditContext?.FieldCssClass(FieldIdentifier) : "";
        return $"rz-textbox{disabledCss} {fieldCssClass}";
    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591
