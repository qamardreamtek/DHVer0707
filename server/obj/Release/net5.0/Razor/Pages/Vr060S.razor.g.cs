#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d1bc028d08db50fcf66c70d1bfe86160034171d"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class Vr060S : RadzenDh5.Pages.Vr060SComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<RadzenDh5.Pages.DhAppHeadingAuthMsgOpt>(0);
            __builder.AddAttribute(1, "IsShowAuth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                    IsShowAuth

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "AuthMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                         AuthMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "Culture", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                            Culture

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "DhUser", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                              DhUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "DhUsername", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                                   DhUsername

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "PROG_ID", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 12 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                  PROG_ID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "PROG_NAME_BY_CULTURE", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 12 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                  PROG_NAME_BY_CULTURE

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "progWrt", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>(
#nullable restore
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                  progWrt

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "progMst", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(
#nullable restore
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                     progMst

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "GoodMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                        GoodMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "ErrMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                          ErrMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "row");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(15);
            __builder.AddAttribute(16, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(17, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                     Lang("Query")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                           ButtonQueryClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(19, "\r\n    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(20);
            __builder.AddAttribute(21, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(22, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                     Lang("Refresh")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                             ButtonRefreshClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(24, "\r\n    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(25);
            __builder.AddAttribute(26, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(27, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                           ButtonType.Submit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                         IsExportDisable

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                                                Lang("Export")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                                                                            ButtonStyle.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                                                                                                         ButtonExportClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\r\n");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "row");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "col-md-4");
            __builder.OpenElement(37, "span");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(38);
            __builder.AddAttribute(39, "Text", "DATE FROM. ");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.OpenElement(41, "span");
            __builder.AddAttribute(42, "style", "margin-left:8px");
            __builder.OpenElement(43, "input");
            __builder.AddAttribute(44, "Name", "txtDateFrom");
            __builder.AddAttribute(45, "size", "10");
            __builder.AddAttribute(46, "maxlength", "10");
            __builder.AddAttribute(47, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                           dateFrom

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd"));
            __builder.AddAttribute(48, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => dateFrom = __value, dateFrom, format: "yyyy-MM-dd"));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n    ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "col-md-4");
            __builder.OpenElement(52, "span");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(53);
            __builder.AddAttribute(54, "Text", "DATE TO. ");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n        ");
            __builder.OpenElement(56, "span");
            __builder.AddAttribute(57, "style", "margin-left:8px");
            __builder.OpenElement(58, "input");
            __builder.AddAttribute(59, "Name", "txtDateTo");
            __builder.AddAttribute(60, "size", "10");
            __builder.AddAttribute(61, "maxlength", "10");
            __builder.AddAttribute(62, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                           dateTo

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd"));
            __builder.AddAttribute(63, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => dateTo = __value, dateTo, format: "yyyy-MM-dd"));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n\r\n\r\n");
            __builder.OpenElement(65, "div");
            __builder.AddAttribute(66, "class", "row");
            __builder.OpenElement(67, "div");
            __builder.AddAttribute(68, "class", "col-md-12");
#nullable restore
#line 47 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
         if (ErrMsg != null && ErrMsg != "")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(69, "div");
            __builder.AddAttribute(70, "class", "alert alert-danger");
            __builder.AddAttribute(71, "role", "alert");
            __builder.AddContent(72, 
#nullable restore
#line 50 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
     ErrMsg

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 51 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
      }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n");
            __builder.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(74);
            __builder.AddAttribute(75, "ColumnWidth", "125px");
            __builder.AddAttribute(76, "AllowColumnResize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 54 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                   true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(77, "PagerPosition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.PagerPosition>(
#nullable restore
#line 54 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                        PagerPosition.Top

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(78, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                            false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(79, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                               FilterMode.Advanced

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(80, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                 true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(81, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                     false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(82, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(
#nullable restore
#line 56 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                   getVr060sResult

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(83, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(84);
                __builder2.AddAttribute(85, "Property", "SKU_NO");
                __builder2.AddAttribute(86, "Title", "SKU NO");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(87, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(88);
                __builder2.AddAttribute(89, "Property", "SKU_DESC");
                __builder2.AddAttribute(90, "Title", "SKU DESC");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(91, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(92);
                __builder2.AddAttribute(93, "Property", "Outbound");
                __builder2.AddAttribute(94, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                       Lang("Outbound")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(95, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(96);
                __builder2.AddAttribute(97, "Property", "Inbound");
                __builder2.AddAttribute(98, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 64 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                      Lang("Inbound")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(99, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(100);
                __builder2.AddAttribute(101, "Property", "Relocation");
                __builder2.AddAttribute(102, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 66 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                         Lang("Relocation")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(103, "\r\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>>(104);
                __builder2.AddAttribute(105, "Property", "Total");
                __builder2.AddAttribute(106, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 68 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Vr060S.razor"
                                                                                                    Lang("Total")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591
