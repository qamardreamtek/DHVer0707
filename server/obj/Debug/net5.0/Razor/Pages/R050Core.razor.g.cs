#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "805b0f332f4eb769d9dd1bcc7e0495f47782d4d2"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class R050Core : RadzenDh5.Pages.R050CoreComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<RadzenDh5.Pages.DhAppHeadingAuthMsgOpt>(0);
            __builder.AddAttribute(1, "IsShowAuth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                    IsShowAuth

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "AuthMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                         AuthMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "Culture", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                            Culture

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "DhUser", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                              DhUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "DhUsername", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                   DhUsername

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "PROG_ID", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                         PROG_ID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "PROG_NAME_BY_CULTURE", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                         PROG_NAME_BY_CULTURE

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "progWrt", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                                         progWrt

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "progMst", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                                                            progMst

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "GoodMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                                                                               GoodMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "ErrMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                                                                                                 ErrMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "row");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(15);
            __builder.AddAttribute(16, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(17, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                     Lang("Query")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                           ButtonQueryClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(19, "\r    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(20);
            __builder.AddAttribute(21, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(22, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                     Lang("Refresh")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                             ButtonRefreshClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(24, "\r    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(25);
            __builder.AddAttribute(26, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(27, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                           ButtonType.Submit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                         IsExportDisable

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                Lang("Export")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                            ButtonStyle.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                         ButtonExportClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\r\r\r\r");
            __builder.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(33);
            __builder.AddAttribute(34, "ColumnWidth", "125px");
            __builder.AddAttribute(35, "AllowColumnResize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                   true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(36, "PagerPosition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.PagerPosition>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                        PagerPosition.Top

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                           false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(38, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                              FilterMode.Advanced

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(40, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                    false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(41, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                                  getVr050sResult

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                                                                                                                                                                                                  ObjTab0Selected

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "ValueChanged", new System.Action<System.Object>(__value => ObjTab0Selected = __value));
            __builder.AddAttribute(44, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<Vr050>>(45);
                __builder2.AddAttribute(46, "Width", "50px");
                __builder2.AddAttribute(47, "Title", "");
                __builder2.AddAttribute(48, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                          false

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(49, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                           false

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(50, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                                                                                                             TextAlign.Center

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(51, "Template", (Microsoft.AspNetCore.Components.RenderFragment<Vr050>)((context) => (__builder3) => {
                    __builder3.AddContent(52, 
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                  getVr050sResult.ToList().IndexOf(context)+1

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(54);
                __builder2.AddAttribute(55, "Property", "SKU_NO");
                __builder2.AddAttribute(56, "Title", "SKU NO");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(57, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(58);
                __builder2.AddAttribute(59, "Property", "SKU_DESC");
                __builder2.AddAttribute(60, "Title", "SKU DESC");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(61, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(62);
                __builder2.AddAttribute(63, "Property", "GTIN_UNIT");
                __builder2.AddAttribute(64, "Title", "GTIN UNIT");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(65, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(66);
                __builder2.AddAttribute(67, "Property", "BATCH_NO");
                __builder2.AddAttribute(68, "Title", "BATCH NO");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(69, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(70);
                __builder2.AddAttribute(71, "Property", "LOC_NO");
                __builder2.AddAttribute(72, "Title", "LOC NO");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(73, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(74);
                __builder2.AddAttribute(75, "Property", "SU_ID");
                __builder2.AddAttribute(76, "Title", "SU ID");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(77, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(78);
                __builder2.AddAttribute(79, "Property", "SU_TYPE");
                __builder2.AddAttribute(80, "Title", "SU TYPE");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(81, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(82);
                __builder2.AddAttribute(83, "Property", "GTIN_MAX_QTY");
                __builder2.AddAttribute(84, "Title", "GTIN MAX QTY");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(85, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(86);
                __builder2.AddAttribute(87, "Property", "GTIN_QTY");
                __builder2.AddAttribute(88, "Title", "GTIN QTY");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(89, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>>(90);
                __builder2.AddAttribute(91, "Property", "FULL_IND");
                __builder2.AddAttribute(92, "Title", "FULL IND");
                __builder2.CloseComponent();
            }
            ));
            __builder.AddComponentReferenceCapture(93, (__value) => {
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\R050Core.razor"
                   grid0 = (Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591