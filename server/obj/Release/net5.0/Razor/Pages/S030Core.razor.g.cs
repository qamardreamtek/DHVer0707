#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "183f841484feb66921174993cf4075265267ae1e"
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
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class S030Core : RadzenDh5.Pages.S030CoreComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<RadzenDh5.Pages.DhAppHeadingAuthMsgOpt>(0);
            __builder.AddAttribute(1, "IsShowAuth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                    IsShowAuth

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "AuthMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                         AuthMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "Culture", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                            Culture

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "DhUser", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                              DhUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "DhUsername", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                   DhUsername

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "PROG_ID", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                         PROG_ID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "PROG_NAME_BY_CULTURE", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                         PROG_NAME_BY_CULTURE

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "progWrt", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                                                         progWrt

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "progMst", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                                                                            progMst

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "GoodMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                                                                                               GoodMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "ErrMsg", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                                                                                                                 ErrMsg

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "row");
            __builder.AddAttribute(15, "style", "margin-top: 8px");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(16);
            __builder.AddAttribute(17, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(18, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                     Lang("Query")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                           ButtonQueryClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(20, "\r    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(21);
            __builder.AddAttribute(22, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(23, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 18 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                     Lang("Create")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                            ButtonCreateClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(25, "\r    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(26);
            __builder.AddAttribute(27, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(28, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                     Lang("Update")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                            ButtonUpdateClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(30, "\r    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(31);
            __builder.AddAttribute(32, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(33, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                     Lang("Delete")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                            ButtonDeleteClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(35, "\r    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(36);
            __builder.AddAttribute(37, "style", "margin-bottom: 10px;margin-left:12px");
            __builder.AddAttribute(38, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                     Lang("Refresh")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                             ButtonRefreshClick

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\r");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "id", "S030_filters_20210607_141847");
            __builder.AddAttribute(43, "class", "row");
            __builder.AddAttribute(44, "style", "margin-bottom:4px;");
            __builder.OpenComponent<RadzenDh5.Shared.DhTextBox>(45);
            __builder.AddAttribute(46, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                      Lang("PROG_ID")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(47, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                 20

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "style", "display: block; width:100% ");
            __builder.AddAttribute(49, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                       txtPROG_ID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(50, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => txtPROG_ID = __value, txtPROG_ID))));
            __builder.AddAttribute(51, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => txtPROG_ID));
            __builder.CloseComponent();
            __builder.AddMarkupContent(52, "\r    ");
            __builder.OpenComponent<RadzenDh5.Shared.DhTextBox>(53);
            __builder.AddAttribute(54, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                      Lang("PROG_NAME")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(55, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                   20

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(56, "style", "display: block; width:100% ");
            __builder.AddAttribute(57, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                         txtPROG_NAME

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(58, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => txtPROG_NAME = __value, txtPROG_NAME))));
            __builder.AddAttribute(59, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => txtPROG_NAME));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\r\r");
            __builder.OpenComponent<Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(61);
            __builder.AddAttribute(62, "ColumnWidth", "125px");
            __builder.AddAttribute(63, "PagerPosition", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.PagerPosition>(
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                            PagerPosition.Top

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(64, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                               false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(65, "AllowColumnResize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                         true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(66, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                        FilterMode.Advanced

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(67, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                          true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(68, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                              false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(69, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                            getProgMstsResult

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(70, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(this, 
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                               Grid0RowSelect

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(71, "RowDoubleClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>(this, 
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                                                                Grid0RowDoubleClick

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(72, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                                                                                                                                                                  ObjTab0Selected

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(73, "ValueChanged", new System.Action<System.Object>(__value => ObjTab0Selected = __value));
            __builder.AddAttribute(74, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<ProgMst>>(75);
                __builder2.AddAttribute(76, "Width", "50px");
                __builder2.AddAttribute(77, "Title", "");
                __builder2.AddAttribute(78, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 33 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                            false

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(79, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 33 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                             false

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(80, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 33 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                               TextAlign.Center

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(81, "Template", (Microsoft.AspNetCore.Components.RenderFragment<ProgMst>)((context) => (__builder3) => {
                    __builder3.AddContent(82, 
#nullable restore
#line 35 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                  getProgMstsResult.ToList().IndexOf(context)+1

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(83, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(84);
                __builder2.AddAttribute(85, "Property", "PROG_ID");
                __builder2.AddAttribute(86, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 38 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                        Lang("PROG_ID")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(87, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(88);
                __builder2.AddAttribute(89, "Property", "PROG_NAME");
                __builder2.AddAttribute(90, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                          Lang("PROG_NAME")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(91, "\r\r\r\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(92);
                __builder2.AddAttribute(93, "Property", "PARENT_ID");
                __builder2.AddAttribute(94, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 47 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                          Lang("PARENT")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(95, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(96);
                __builder2.AddAttribute(97, "Property", "PROG_NODE");
                __builder2.AddAttribute(98, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 49 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                          Lang("NODE")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(99, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(100);
                __builder2.AddAttribute(101, "Property", "PROG_SNO");
                __builder2.AddAttribute(102, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                         Lang("SNO")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(103, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(104);
                __builder2.AddAttribute(105, "Property", "ENABLE");
                __builder2.AddAttribute(106, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                       Lang("ENABLE")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(107, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(108);
                __builder2.AddAttribute(109, "Property", "REMARK");
                __builder2.AddAttribute(110, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 57 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                       Lang("REMARK")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(111, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(112);
                __builder2.AddAttribute(113, "Property", "TRN_USER");
                __builder2.AddAttribute(114, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 59 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                         Lang("TRN_USER")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(115, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(116);
                __builder2.AddAttribute(117, "Property", "TRN_DATE");
                __builder2.AddAttribute(118, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 61 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                         Lang("TRN_DATE")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(119, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(120);
                __builder2.AddAttribute(121, "Property", "CRT_USER");
                __builder2.AddAttribute(122, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 63 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                         Lang("CRT_USER")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(123, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(124);
                __builder2.AddAttribute(125, "Property", "CRT_DATE");
                __builder2.AddAttribute(126, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                         Lang("CRT_DATE")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(127, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(128);
                __builder2.AddAttribute(129, "Property", "TW_NAME");
                __builder2.AddAttribute(130, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 67 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                        Lang("TW_NAME")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(131, "\r\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(132);
                __builder2.AddAttribute(133, "Property", "CN_NAME");
                __builder2.AddAttribute(134, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 70 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                        Lang("CN_NAME")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(135, "\r        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGridColumn<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>>(136);
                __builder2.AddAttribute(137, "Property", "TH_NAME");
                __builder2.AddAttribute(138, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 72 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                                                                                                        Lang("TH_NAME")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddComponentReferenceCapture(139, (__value) => {
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\S030Core.razor"
                  grid0 = (Radzen.Blazor.RadzenGrid<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>)__value;

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
