#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7532ee5281dc2d4bfe54e8f50db61a06d9de147"
// <auto-generated/>
#pragma warning disable 1591
namespace RadzenDh5.Pages
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
#line 2 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/add-sno-ctl")]
    public partial class AddSnoCtl : RadzenDh5.Pages.AddSnoCtlComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "row");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>>(7);
                __builder2.AddAttribute(8, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>(
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                   snoctl

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                      snoctl != null

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>(this, 
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                                                                   Form0Submit

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.OpenElement(12, "div");
                    __builder3.AddAttribute(13, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(14, "class", "row");
                    __builder3.OpenElement(15, "div");
                    __builder3.AddAttribute(16, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(17);
                    __builder3.AddAttribute(18, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                    L["SNO_TYPE"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(19, "Component", "SNO_TYPE");
                    __builder3.AddAttribute(20, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(21, "\n              ");
                    __builder3.OpenElement(22, "div");
                    __builder3.AddAttribute(23, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(24);
                    __builder3.AddAttribute(25, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 27 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                          10

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(26, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(27, "Name", "SNO_TYPE");
                    __builder3.AddAttribute(28, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 27 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                                 snoctl.SNO_TYPE

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => snoctl.SNO_TYPE = __value, snoctl.SNO_TYPE))));
                    __builder3.AddAttribute(30, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => snoctl.SNO_TYPE));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(31, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(32);
                    __builder3.AddAttribute(33, "Component", "SNO_TYPE");
                    __builder3.AddAttribute(34, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                     L["SNO_TYPERequiredValidator.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(35, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(36, "\n            ");
                    __builder3.OpenElement(37, "div");
                    __builder3.AddAttribute(38, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(39, "class", "row");
                    __builder3.OpenElement(40, "div");
                    __builder3.AddAttribute(41, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(42);
                    __builder3.AddAttribute(43, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                    L["SNO"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(44, "Component", "SNO");
                    __builder3.AddAttribute(45, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(46, "\n              ");
                    __builder3.OpenElement(47, "div");
                    __builder3.AddAttribute(48, "class", "col-md-9");
                    __Blazor.RadzenDh5.Pages.AddSnoCtl.TypeInference.CreateRadzenNumeric_0(__builder3, 49, 50, "width: 100%", 51, "SNO", 52, 
#nullable restore
#line 39 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                  snoctl.SNO

#line default
#line hidden
#nullable disable
                    , 53, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => snoctl.SNO = __value, snoctl.SNO)), 54, () => snoctl.SNO);
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(55, "\n            ");
                    __builder3.OpenElement(56, "div");
                    __builder3.AddAttribute(57, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(58, "class", "row");
                    __builder3.OpenElement(59, "div");
                    __builder3.AddAttribute(60, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(61);
                    __builder3.AddAttribute(62, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                    L["TRN_DATE"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(63, "Component", "TRN_DATE");
                    __builder3.AddAttribute(64, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(65, "\n              ");
                    __builder3.OpenElement(66, "div");
                    __builder3.AddAttribute(67, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(68);
                    __builder3.AddAttribute(69, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 49 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                          8

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(70, "style", "width: 100%");
                    __builder3.AddAttribute(71, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 49 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                                            true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(72, "Name", "TRN_DATE");
                    __builder3.AddAttribute(73, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 49 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                snoctl.TRN_DATE

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(74, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => snoctl.TRN_DATE = __value, snoctl.TRN_DATE))));
                    __builder3.AddAttribute(75, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => snoctl.TRN_DATE));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(76, "\n            ");
                    __builder3.OpenElement(77, "div");
                    __builder3.AddAttribute(78, "class", "row");
                    __builder3.OpenElement(79, "div");
                    __builder3.AddAttribute(80, "class", "col offset-sm-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(81);
                    __builder3.AddAttribute(82, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                          ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(83, "Icon", "save");
                    __builder3.AddAttribute(84, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                L["Save"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(85, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                                        ButtonStyle.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(86, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(87);
                    __builder3.AddAttribute(88, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 57 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                           ButtonStyle.Light

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(89, "style", "margin-left: 1rem");
                    __builder3.AddAttribute(90, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 57 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                               L["Cancel"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(91, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 57 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddSnoCtl.razor"
                                                                                                                    Button2Click

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<AddSnoCtl> L { get; set; }
    }
}
namespace __Blazor.RadzenDh5.Pages.AddSnoCtl
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenNumeric_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.String __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenNumeric<TValue>>(seq);
        __builder.AddAttribute(__seq0, "style", __arg0);
        __builder.AddAttribute(__seq1, "Name", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
