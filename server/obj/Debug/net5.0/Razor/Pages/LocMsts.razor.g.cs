#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "987e32bc537457e148dd744c5fa692c7bdfccdcc"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class LocMsts : RadzenDh5.Pages.LocMstsComponent
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
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                        L["M090.Text"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n        ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Icon", "add_circle_outline");
                __builder2.AddAttribute(13, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", "Add");
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                       Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\n                ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(17);
                __builder2.AddAttribute(18, "ColumnWidth", "100px");
                __builder2.AddAttribute(19, "AllowColumnResize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                      true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                        FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                                                          true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                                                                              true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                                                                                           getLocMstsResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>(this, 
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                                                                                                                                                                            Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(26, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(27);
                    __builder3.AddAttribute(28, "Property", "WHSE_NO");
                    __builder3.AddAttribute(29, "Title", "WHSE_NO");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(30, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(31);
                    __builder3.AddAttribute(32, "Property", "LOC_NO");
                    __builder3.AddAttribute(33, "Title", "LOC_NO");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(34, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(35);
                    __builder3.AddAttribute(36, "Property", "LOC_NAME");
                    __builder3.AddAttribute(37, "Title", "LOC_NAME");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(38, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(39);
                    __builder3.AddAttribute(40, "Property", "ZONE_NO");
                    __builder3.AddAttribute(41, "Title", "ZONE_NO");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(42, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(43);
                    __builder3.AddAttribute(44, "Property", "LANE_NO");
                    __builder3.AddAttribute(45, "Title", "LANE_NO");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(46, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(47);
                    __builder3.AddAttribute(48, "Property", "EQU_NO");
                    __builder3.AddAttribute(49, "Title", "EQU_NO");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(50, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(51);
                    __builder3.AddAttribute(52, "Property", "ROW_X");
                    __builder3.AddAttribute(53, "Title", "ROW_X");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(54, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(55);
                    __builder3.AddAttribute(56, "Property", "BAY_Y");
                    __builder3.AddAttribute(57, "Title", "BAY_Y");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(58, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(59);
                    __builder3.AddAttribute(60, "Property", "LVL_Z");
                    __builder3.AddAttribute(61, "Title", "LVL_Z");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(62, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(63);
                    __builder3.AddAttribute(64, "Property", "LOC_ASRS");
                    __builder3.AddAttribute(65, "Title", "LOC_ASRS");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(66, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(67);
                    __builder3.AddAttribute(68, "Property", "LOC_STS");
                    __builder3.AddAttribute(69, "Title", "LOC_STS");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(70, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(71);
                    __builder3.AddAttribute(72, "Property", "LOC_OSTS");
                    __builder3.AddAttribute(73, "Title", "LOC_OSTS");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(74, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(75);
                    __builder3.AddAttribute(76, "Property", "AVAIL");
                    __builder3.AddAttribute(77, "Title", "AVAIL");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(78, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(79);
                    __builder3.AddAttribute(80, "Property", "DEPTH");
                    __builder3.AddAttribute(81, "Title", "DEPTH");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(82, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(83);
                    __builder3.AddAttribute(84, "Property", "LOC_SIZE");
                    __builder3.AddAttribute(85, "Title", "LOC_SIZE");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(86, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(87);
                    __builder3.AddAttribute(88, "Property", "LOC_TYPE");
                    __builder3.AddAttribute(89, "Title", "LOC_TYPE");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(90, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(91);
                    __builder3.AddAttribute(92, "Property", "LOC_ABC");
                    __builder3.AddAttribute(93, "Title", "LOC_ABC");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(94, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(95);
                    __builder3.AddAttribute(96, "Property", "LOC_SPECIAL");
                    __builder3.AddAttribute(97, "Title", "LOC_SPECIAL");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(98, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(99);
                    __builder3.AddAttribute(100, "Property", "LOC_HOT");
                    __builder3.AddAttribute(101, "Title", "LOC_HOT");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(102, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(103);
                    __builder3.AddAttribute(104, "Property", "LOC_RCV");
                    __builder3.AddAttribute(105, "Title", "LOC_RCV");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(106, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(107);
                    __builder3.AddAttribute(108, "Property", "LOC_STOCK");
                    __builder3.AddAttribute(109, "Title", "LOC_STOCK");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(110, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(111);
                    __builder3.AddAttribute(112, "Property", "LOC_QC");
                    __builder3.AddAttribute(113, "Title", "LOC_QC");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(114, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(115);
                    __builder3.AddAttribute(116, "Property", "LOC_NG");
                    __builder3.AddAttribute(117, "Title", "LOC_NG");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(118, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(119);
                    __builder3.AddAttribute(120, "Property", "LOC_RETURN");
                    __builder3.AddAttribute(121, "Title", "LOC_RETURN");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(122, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(123);
                    __builder3.AddAttribute(124, "Property", "LOC_SORT");
                    __builder3.AddAttribute(125, "Title", "LOC_SORT");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(126, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(127);
                    __builder3.AddAttribute(128, "Property", "LOC_PICK");
                    __builder3.AddAttribute(129, "Title", "LOC_PICK");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(130, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(131);
                    __builder3.AddAttribute(132, "Property", "LOC_STAGE");
                    __builder3.AddAttribute(133, "Title", "LOC_STAGE");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(134, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(135);
                    __builder3.AddAttribute(136, "Property", "LOC_DEL");
                    __builder3.AddAttribute(137, "Title", "LOC_DEL");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(138, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(139);
                    __builder3.AddAttribute(140, "Property", "SU_ID");
                    __builder3.AddAttribute(141, "Title", "SU_ID");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(142, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(143);
                    __builder3.AddAttribute(144, "Property", "COUNT_DATE");
                    __builder3.AddAttribute(145, "Title", "COUNT_DATE");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(146, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(147);
                    __builder3.AddAttribute(148, "Property", "REMARK");
                    __builder3.AddAttribute(149, "Title", "REMARK");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(150, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(151);
                    __builder3.AddAttribute(152, "Property", "TRN_USER");
                    __builder3.AddAttribute(153, "Title", "TRN_USER");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(154, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(155);
                    __builder3.AddAttribute(156, "Property", "TRN_DATE");
                    __builder3.AddAttribute(157, "Title", "TRN_DATE");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(158, "\n                        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>>(159);
                    __builder3.AddAttribute(160, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 99 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                         false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(161, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 99 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                          false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(162, "Width", "70px");
                    __builder3.AddAttribute(163, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 99 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                                                         TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(164, "Template", (Microsoft.AspNetCore.Components.RenderFragment<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>)((radzenDh5ModelsMark10Sqlexpress04LocMst) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(165);
                        __builder4.AddAttribute(166, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 101 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(167, "Icon", "close");
                        __builder4.AddAttribute(168, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 101 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(169, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 101 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                                                                                                             (args) =>GridDeleteButtonClick(args, radzenDh5ModelsMark10Sqlexpress04LocMst)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(170, "onclick", 
#nullable restore
#line 101 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
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
                __builder2.AddComponentReferenceCapture(171, (__value) => {
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\LocMsts.razor"
                                  grid0 = (Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>)__value;

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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591
