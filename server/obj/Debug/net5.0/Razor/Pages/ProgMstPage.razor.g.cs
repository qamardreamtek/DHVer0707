#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4e5db2323014e1f0b1d824aa4cca3b9d56646e6"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
           [Authorize(Roles="P030")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/prog-mst-page")]
    public partial class ProgMstPage : RadzenDh5.Pages.ProgMstPageComponent
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
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
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
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Icon", "add_circle_outline");
                __builder2.AddAttribute(13, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                   L["Create"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                        Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(17);
                __builder2.AddAttribute(18, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                   FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                                         true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                                                      getProgMstsResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(this, 
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(24, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(25);
                    __builder3.AddAttribute(26, "Property", "PROG_ID");
                    __builder3.AddAttribute(27, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                             L["grid0.PROG_ID.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(28, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(29);
                    __builder3.AddAttribute(30, "Property", "PROG_NAME");
                    __builder3.AddAttribute(31, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                               L["grid0.PROG_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(32, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(33);
                    __builder3.AddAttribute(34, "Property", "PROG_TYPE");
                    __builder3.AddAttribute(35, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                               L["grid0.PROG_TYPE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(36, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(37);
                    __builder3.AddAttribute(38, "Property", "PARENT_ID");
                    __builder3.AddAttribute(39, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                               L["grid0.PARENT_ID.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(40, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(41);
                    __builder3.AddAttribute(42, "Property", "PROG_NODE");
                    __builder3.AddAttribute(43, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 34 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                               L["grid0.PROG_NODE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(44, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(45);
                    __builder3.AddAttribute(46, "Property", "PROG_PATH");
                    __builder3.AddAttribute(47, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 36 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                               L["grid0.PROG_PATH.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(48, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(49);
                    __builder3.AddAttribute(50, "Property", "PROG_SNO");
                    __builder3.AddAttribute(51, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 38 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                              L["grid0.PROG_SNO.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(52, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(53);
                    __builder3.AddAttribute(54, "Property", "ENABLE");
                    __builder3.AddAttribute(55, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                            L["grid0.ENABLE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(56, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(57);
                    __builder3.AddAttribute(58, "Property", "REMARK");
                    __builder3.AddAttribute(59, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 42 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                            L["grid0.REMARK.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(60, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(61);
                    __builder3.AddAttribute(62, "Property", "TRN_USER");
                    __builder3.AddAttribute(63, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 44 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                              L["grid0.TRN_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(64, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(65);
                    __builder3.AddAttribute(66, "Property", "TRN_DATE");
                    __builder3.AddAttribute(67, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 46 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                              L["grid0.TRN_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(68, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(69);
                    __builder3.AddAttribute(70, "Property", "CRT_USER");
                    __builder3.AddAttribute(71, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 48 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                              L["grid0.CRT_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(72, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(73);
                    __builder3.AddAttribute(74, "Property", "CRT_DATE");
                    __builder3.AddAttribute(75, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 50 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                              L["grid0.CRT_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(76, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(77);
                    __builder3.AddAttribute(78, "Property", "TW_NAME");
                    __builder3.AddAttribute(79, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 52 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                             L["grid0.TW_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(80, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(81);
                    __builder3.AddAttribute(82, "Property", "CN_NAME");
                    __builder3.AddAttribute(83, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 54 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                             L["grid0.CN_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(84, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(85);
                    __builder3.AddAttribute(86, "Property", "TH_NAME");
                    __builder3.AddAttribute(87, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 56 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                             L["grid0.TH_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(88, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(89);
                    __builder3.AddAttribute(90, "Property", "VN_NAME");
                    __builder3.AddAttribute(91, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 58 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                             L["grid0.VN_NAME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(92, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(93);
                    __builder3.AddAttribute(94, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 60 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                              false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(95, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 60 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                               false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(96, "Width", "70px");
                    __builder3.AddAttribute(97, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 60 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                                                              TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(98, "Template", (Microsoft.AspNetCore.Components.RenderFragment<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>)((radzenDh5ModelsMark10Sqlexpress04ProgMst) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(99);
                        __builder4.AddAttribute(100, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(101, "Icon", "close");
                        __builder4.AddAttribute(102, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(103, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, radzenDh5ModelsMark10Sqlexpress04ProgMst)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(104, "onclick", 
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                                                                                                                                                                                                                        true

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(105, (__value) => {
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\ProgMstPage.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>)__value;

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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<ProgMstPage> L { get; set; }
    }
}
#pragma warning restore 1591