#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b7676747c71b1a9b57ed19148f25f8cae57598a"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/add-prog-wrt")]
    public partial class AddProgWrt : RadzenDh5.Pages.AddProgWrtComponent
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
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>>(7);
                __builder2.AddAttribute(8, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>(
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                   progwrt

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                       progwrt != null

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>(this, 
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
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
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                    L["USER_ID"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(19, "Component", "USER_ID");
                    __builder3.AddAttribute(20, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(21, "\n              ");
                    __builder3.OpenElement(22, "div");
                    __builder3.AddAttribute(23, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDropDown<string>>(24);
                    __builder3.AddAttribute(25, "AllowClear", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                              true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(26, "Name", "USER_ID");
                    __builder3.AddAttribute(27, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.IEnumerable>(
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                          AppDb.UserMsts.Select(c => new { CustomerID = c.USER_ID, CompanyName = c.USER_ID })

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(28, "TextProperty", "CompanyName");
                    __builder3.AddAttribute(29, "ValueProperty", "CustomerID");
                    __builder3.AddAttribute(30, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                                                   progwrt.USER_ID

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(31, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => progwrt.USER_ID = __value, progwrt.USER_ID))));
                    __builder3.AddAttribute(32, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(() => progwrt.USER_ID));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(33, "\n\n\n\n                  ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(34);
                    __builder3.AddAttribute(35, "Component", "USER_ID");
                    __builder3.AddAttribute(36, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                                      L["USER_IDRequiredValidator.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(37, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(38, "\n            ");
                    __builder3.OpenElement(39, "div");
                    __builder3.AddAttribute(40, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(41, "class", "row");
                    __builder3.OpenElement(42, "div");
                    __builder3.AddAttribute(43, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(44);
                    __builder3.AddAttribute(45, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                    L["PROG_ID"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(46, "Component", "PROG_ID");
                    __builder3.AddAttribute(47, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(48, "\n              ");
                    __builder3.OpenElement(49, "div");
                    __builder3.AddAttribute(50, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDropDown<string>>(51);
                    __builder3.AddAttribute(52, "AllowClear", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 47 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                              true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(53, "Name", "PROG_ID");
                    __builder3.AddAttribute(54, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.IEnumerable>(
#nullable restore
#line 48 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                         AppDb.ProgMsts.Where( c=> !AppDb.ProgWrts.Where(u=>u.USER_ID == progwrt.USER_ID )
                                         .Select(z =>z.PROG_ID).Contains(c.PROG_ID))
                                  .Select(c=> new { CustomerID = c.PROG_ID, CompanyName = c.PROG_ID })

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(55, "TextProperty", "CompanyName");
                    __builder3.AddAttribute(56, "ValueProperty", "CustomerID");
                    __builder3.AddAttribute(57, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 47 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                                                   progwrt.PROG_ID

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(58, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => progwrt.PROG_ID = __value, progwrt.PROG_ID))));
                    __builder3.AddAttribute(59, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(() => progwrt.PROG_ID));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(60, "\n\n ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(61);
                    __builder3.AddAttribute(62, "Component", "PROG_ID");
                    __builder3.AddAttribute(63, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                     L["PROG_IDRequiredValidator.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(64, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(65, "\n\n\n                      ");
                    __builder3.OpenElement(66, "div");
                    __builder3.AddAttribute(67, "class", "row");
                    __builder3.OpenElement(68, "div");
                    __builder3.AddAttribute(69, "class", "col offset-sm-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(70);
                    __builder3.AddAttribute(71, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 211 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                        ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(72, "Icon", "save");
                    __builder3.AddAttribute(73, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 211 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                                                              L["Save"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(74, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 211 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                                                                                      ButtonStyle.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(75, "\n                              ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(76);
                    __builder3.AddAttribute(77, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 213 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                         ButtonStyle.Light

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(78, "style", "margin-left: 1rem");
                    __builder3.AddAttribute(79, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 213 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
                                                                                                             L["Cancel"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(80, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 213 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\AddProgWrt.razor"
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<AddProgWrt> L { get; set; }
    }
}
#pragma warning restore 1591
