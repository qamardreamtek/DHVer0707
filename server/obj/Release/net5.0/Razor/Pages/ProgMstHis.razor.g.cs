#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db603f0f30ed1c1dd1083086c7d8b29c4d84dc43"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/prog-mst-his")]
    public partial class ProgMstHis : RadzenDh5.Pages.ProgMstHisComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H3");
                __builder2.AddAttribute(5, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                    L["pageTitle.Text"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenSplitButton>(11);
                __builder2.AddAttribute(12, "Icon", "get_app");
                __builder2.AddAttribute(13, "style", "margin-left: 0px; margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                               L["splitbutton0.Text"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.Blazor.RadzenSplitButtonItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.Blazor.RadzenSplitButtonItem>(this, 
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                               Splitbutton0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(17);
                    __builder3.AddAttribute(18, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                          L["splitbutton0.excel.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(19, "Value", "xlsx");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(20, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(21);
                    __builder3.AddAttribute(22, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                          L["splitbutton0.csv.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(23, "Value", "csv");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(24, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(25);
                __builder2.AddAttribute(26, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                   FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(29, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                         true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                                      getProgMstHisResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(32);
                    __builder3.AddAttribute(33, "Property", "PROG_ID");
                    __builder3.AddAttribute(34, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                               L["grid0.PROG_ID.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(35, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(36);
                    __builder3.AddAttribute(37, "Property", "PROG_NAME");
                    __builder3.AddAttribute(38, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                 L["grid0.PROG_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(39, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(40);
                    __builder3.AddAttribute(41, "Property", "PROG_TYPE");
                    __builder3.AddAttribute(42, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                 L["grid0.PROG_TYPE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(43, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(44);
                    __builder3.AddAttribute(45, "Property", "PARENT_ID");
                    __builder3.AddAttribute(46, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 37 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                 L["grid0.PARENT_ID.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(47, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(48);
                    __builder3.AddAttribute(49, "Property", "PROG_NODE");
                    __builder3.AddAttribute(50, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                 L["grid0.PROG_NODE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(51, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(52);
                    __builder3.AddAttribute(53, "Property", "PROG_PATH");
                    __builder3.AddAttribute(54, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                 L["grid0.PROG_PATH.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(55, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(56);
                    __builder3.AddAttribute(57, "Property", "PROG_SNO");
                    __builder3.AddAttribute(58, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 43 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.PROG_SNO.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(59, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(60);
                    __builder3.AddAttribute(61, "Property", "ENABLE");
                    __builder3.AddAttribute(62, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                              L["grid0.ENABLE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(63, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(64);
                    __builder3.AddAttribute(65, "Property", "REMARK");
                    __builder3.AddAttribute(66, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 47 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                              L["grid0.REMARK.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(67, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(68);
                    __builder3.AddAttribute(69, "Property", "TRN_USER");
                    __builder3.AddAttribute(70, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 49 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.TRN_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(71, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(72);
                    __builder3.AddAttribute(73, "Property", "TRN_DATE");
                    __builder3.AddAttribute(74, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 51 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.TRN_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(75, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(76);
                    __builder3.AddAttribute(77, "Property", "CRT_USER");
                    __builder3.AddAttribute(78, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.CRT_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(79, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(80);
                    __builder3.AddAttribute(81, "Property", "CRT_DATE");
                    __builder3.AddAttribute(82, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.CRT_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(83, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(84);
                    __builder3.AddAttribute(85, "Property", "TW_NAME");
                    __builder3.AddAttribute(86, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 57 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                               L["grid0.TW_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(87, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(88);
                    __builder3.AddAttribute(89, "Property", "CN_NAME");
                    __builder3.AddAttribute(90, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 59 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                               L["grid0.CN_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(91, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(92);
                    __builder3.AddAttribute(93, "Property", "TH_NAME");
                    __builder3.AddAttribute(94, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 61 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                               L["grid0.TH_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(95, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(96);
                    __builder3.AddAttribute(97, "Property", "VN_NAME");
                    __builder3.AddAttribute(98, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 63 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                               L["grid0.VN_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(99, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(100);
                    __builder3.AddAttribute(101, "Property", "LOG_DATE");
                    __builder3.AddAttribute(102, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.LOG_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(103, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>>(104);
                    __builder3.AddAttribute(105, "Property", "LOG_USER");
                    __builder3.AddAttribute(106, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 67 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                                                                                                                L["grid0.LOG_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(107, (__value) => {
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstHis.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<ProgMstHis> L { get; set; }
    }
}
#pragma warning restore 1591
