#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c53eadecfe5080616ad7f320a6aaeee7d4a9b52f"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/pic-msts")]
    public partial class PicMsts : RadzenDh5.Pages.PicMstsComponent
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
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
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
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                   L["Create"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                        Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenSplitButton>(17);
                __builder2.AddAttribute(18, "Icon", "get_app");
                __builder2.AddAttribute(19, "style", "margin-left: 10px; margin-bottom: 10px");
                __builder2.AddAttribute(20, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                L["splitbutton0.Text"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.Blazor.RadzenSplitButtonItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.Blazor.RadzenSplitButtonItem>(this, 
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                                                Splitbutton0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(23);
                    __builder3.AddAttribute(24, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                          L["splitbutton0.excel.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(25, "Value", "xlsx");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(26, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(27);
                    __builder3.AddAttribute(28, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 27 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                          L["splitbutton0.csv.Text"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "Value", "csv");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(31);
                __builder2.AddAttribute(32, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(33, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                   FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(34, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                                         true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                                                      getPicMstsResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(37, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>(this, 
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                                                                                                                                       Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(38, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(39);
                    __builder3.AddAttribute(40, "Property", "WHSE_NO");
                    __builder3.AddAttribute(41, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                            L["grid0.WHSE_NO.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(42, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(43);
                    __builder3.AddAttribute(44, "Property", "PIC_NO");
                    __builder3.AddAttribute(45, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                           L["grid0.PIC_NO.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(46, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(47);
                    __builder3.AddAttribute(48, "Property", "PIC_GROUP");
                    __builder3.AddAttribute(49, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 37 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                              L["grid0.PIC_GROUP.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(50, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(51);
                    __builder3.AddAttribute(52, "Property", "PIC_TYPE");
                    __builder3.AddAttribute(53, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             L["grid0.PIC_TYPE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(54, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(55);
                    __builder3.AddAttribute(56, "Property", "PLANT");
                    __builder3.AddAttribute(57, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                          L["grid0.PLANT.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(58, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(59);
                    __builder3.AddAttribute(60, "Property", "STGE_LOC");
                    __builder3.AddAttribute(61, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 43 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             L["grid0.STGE_LOC.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(62, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(63);
                    __builder3.AddAttribute(64, "Property", "COUNT_USER");
                    __builder3.AddAttribute(65, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                               L["grid0.COUNT_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(66, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(67);
                    __builder3.AddAttribute(68, "Property", "SHELF");
                    __builder3.AddAttribute(69, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 47 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                          L["grid0.SHELF.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(70, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(71);
                    __builder3.AddAttribute(72, "Property", "CREATEUSER");
                    __builder3.AddAttribute(73, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 49 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                               L["grid0.CREATEUSER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(74, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(75);
                    __builder3.AddAttribute(76, "Property", "CREATEDATE");
                    __builder3.AddAttribute(77, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 51 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                               L["grid0.CREATEDATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(78, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(79);
                    __builder3.AddAttribute(80, "Property", "CREATETIME");
                    __builder3.AddAttribute(81, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                               L["grid0.CREATETIME.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(82, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(83);
                    __builder3.AddAttribute(84, "Property", "PIC_STS");
                    __builder3.AddAttribute(85, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                            L["grid0.PIC_STS.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(86, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(87);
                    __builder3.AddAttribute(88, "Property", "REMARK");
                    __builder3.AddAttribute(89, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 57 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                           L["grid0.REMARK.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(90, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(91);
                    __builder3.AddAttribute(92, "Property", "SOURCE");
                    __builder3.AddAttribute(93, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 59 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                           L["grid0.SOURCE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(94, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(95);
                    __builder3.AddAttribute(96, "Property", "APPROVE_IND");
                    __builder3.AddAttribute(97, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 61 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                                L["grid0.APPROVE_IND.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(98, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(99);
                    __builder3.AddAttribute(100, "Property", "TRN_USER");
                    __builder3.AddAttribute(101, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 63 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             L["grid0.TRN_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(102, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(103);
                    __builder3.AddAttribute(104, "Property", "TRN_DATE");
                    __builder3.AddAttribute(105, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             L["grid0.TRN_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(106, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(107);
                    __builder3.AddAttribute(108, "Property", "CRT_USER");
                    __builder3.AddAttribute(109, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 67 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             L["grid0.CRT_USER.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(110, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(111);
                    __builder3.AddAttribute(112, "Property", "CRT_DATE");
                    __builder3.AddAttribute(113, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 69 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             L["grid0.CRT_DATE.Title"]

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(114, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>>(115);
                    __builder3.AddAttribute(116, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 71 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                             false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(117, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 71 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                              false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(118, "Width", "70px");
                    __builder3.AddAttribute(119, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 71 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                                                             TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(120, "Template", (Microsoft.AspNetCore.Components.RenderFragment<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>)((radzenDh5ModelsMark10Sqlexpress04PicMst) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(121);
                        __builder4.AddAttribute(122, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 73 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(123, "Icon", "close");
                        __builder4.AddAttribute(124, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 73 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(125, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 73 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, radzenDh5ModelsMark10Sqlexpress04PicMst)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(126, "onclick", 
#nullable restore
#line 73 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
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
                __builder2.AddComponentReferenceCapture(127, (__value) => {
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\PicMsts.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>)__value;

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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<PicMsts> L { get; set; }
    }
}
#pragma warning restore 1591
