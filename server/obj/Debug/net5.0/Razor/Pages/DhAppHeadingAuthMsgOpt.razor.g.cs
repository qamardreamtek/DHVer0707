#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14abbeb53bee50c9fb6b62871e27cf42f32bfc98"
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
#line 2 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\_Imports.razor"
using Radzen.Blazor;

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
#line 1 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class DhAppHeadingAuthMsgOpt : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
            __builder.AddAttribute(2, "style", " margin-top: -4px;");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-md-12");
            __builder.AddAttribute(5, "style", "\n                margin-left: 0px;\n                margin-top: 0px;\n                margin-bottom: 0px;\n                font-family: monospace;\n                font-size: 90%;\n              ");
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
         if (progMst != null)
        {



#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
 if (IsShowAuth)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "span");
            __builder.AddMarkupContent(7, "\n    (");
            __builder.AddContent(8, 
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
      DhUser

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(9, ", ");
            __builder.AddContent(10, 
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
               progMst.PROG_ID

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(11, ") =>\n    (QUERY=");
            __builder.AddContent(12, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
            progWrt.QUERY_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(13, ", PRINT=");
            __builder.AddContent(14, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                      progWrt.PRINT_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(15, ", IMPORT=");
            __builder.AddContent(16, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                                                 progWrt.IMPORT_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(17, ", EXPORT=");
            __builder.AddContent(18, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                                                                             progWrt.EXPORT_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(19, ", UPDATE=");
            __builder.AddContent(20, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                                                                                                         progWrt.UPDATE_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(21, ", DELETE=");
            __builder.AddContent(22, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                                                                                                                                     progWrt.DELETE_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(23, ", APPROVE=");
            __builder.AddContent(24, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                                                                                                                                                                  progWrt.APPROVE_WRT

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(25, ", ENABLE=");
            __builder.AddContent(26, 
#nullable restore
#line 25 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                                                                                                                                                                                                               progWrt.ENABLE

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(27, ")\n");
            __builder.CloseElement();
#nullable restore
#line 28 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
                     if (AuthMsg != null && AuthMsg != "")
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(28, "span");
            __builder.AddContent(29, 
#nullable restore
#line 31 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
     AuthMsg

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 36 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
     if (GoodMsg != null && GoodMsg != "")
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "col-12 alert alert-info");
            __builder.AddAttribute(32, "role", "alert");
            __builder.AddAttribute(33, "style", "font-family:monospace;font-size: 95%;");
            __builder.AddContent(34, 
#nullable restore
#line 39 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
     GoodMsg

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 40 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
      }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
     if (ErrMsg != null && ErrMsg != "")
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "col-12 alert alert-danger");
            __builder.AddAttribute(37, "role", "alert");
            __builder.AddAttribute(38, "style", "font-family:monospace;font-size: 95%;");
            __builder.AddContent(39, 
#nullable restore
#line 44 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
     ErrMsg

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 45 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
      }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DhAppHeadingAuthMsgOpt.razor"
       [Parameter] public bool IsShowAuth { get; set; }
    [Parameter] public string DhUser { get; set; }
    [Parameter] public string DhUsername { get; set; }
    [Parameter] public string PROG_ID { get; set; }
    [Parameter] public string PROG_NAME_BY_CULTURE { get; set; }
    [Parameter] public string Culture { get; set; }
    [Parameter] public ProgWrt progWrt { get; set; }
    [Parameter] public ProgMst progMst { get; set; }


    [Parameter] public string ErrMsg { get; set; }
    [Parameter] public string GoodMsg { get; set; }
    [Parameter] public string AuthMsg { get; set; } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591