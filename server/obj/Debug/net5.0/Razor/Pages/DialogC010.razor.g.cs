#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8f0e09bb31811e876d7b4f699860f6204492a83"
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
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class DialogC010 : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(4, "class", "row");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(7);
            __builder.AddAttribute(8, "Text", "WHSE_NO");
            __builder.AddAttribute(9, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n        ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(13);
            __builder.AddAttribute(14, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 12 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "style", "display: block; width: 100%");
            __builder.AddAttribute(17, "Name", "WHSE_NO");
            __builder.AddAttribute(18, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 12 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(20, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\n    ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(24, "class", "row");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(27);
            __builder.AddAttribute(28, "Text", "WHSE_NO");
            __builder.AddAttribute(29, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\n        ");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(33);
            __builder.AddAttribute(34, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(35, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(36, "style", "display: block; width: 100%");
            __builder.AddAttribute(37, "Name", "WHSE_NO");
            __builder.AddAttribute(38, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(40, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\n    ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(44, "class", "row");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(47);
            __builder.AddAttribute(48, "Text", "WHSE_NO");
            __builder.AddAttribute(49, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\n        ");
            __builder.OpenElement(51, "div");
            __builder.AddAttribute(52, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(53);
            __builder.AddAttribute(54, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(55, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(56, "style", "display: block; width: 100%");
            __builder.AddAttribute(57, "Name", "WHSE_NO");
            __builder.AddAttribute(58, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(59, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(60, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\n    ");
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(64, "class", "row");
            __builder.OpenElement(65, "div");
            __builder.AddAttribute(66, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(67);
            __builder.AddAttribute(68, "Text", "WHSE_NO");
            __builder.AddAttribute(69, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\n        ");
            __builder.OpenElement(71, "div");
            __builder.AddAttribute(72, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(73);
            __builder.AddAttribute(74, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 42 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(75, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 42 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(76, "style", "display: block; width: 100%");
            __builder.AddAttribute(77, "Name", "WHSE_NO");
            __builder.AddAttribute(78, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 42 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(79, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(80, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\n    ");
            __builder.OpenElement(82, "div");
            __builder.AddAttribute(83, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(84, "class", "row");
            __builder.OpenElement(85, "div");
            __builder.AddAttribute(86, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(87);
            __builder.AddAttribute(88, "Text", "WHSE_NO");
            __builder.AddAttribute(89, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\n        ");
            __builder.OpenElement(91, "div");
            __builder.AddAttribute(92, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(93);
            __builder.AddAttribute(94, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 52 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(95, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 52 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(96, "style", "display: block; width: 100%");
            __builder.AddAttribute(97, "Name", "WHSE_NO");
            __builder.AddAttribute(98, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 52 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(99, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(100, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\n    ");
            __builder.OpenElement(102, "div");
            __builder.AddAttribute(103, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(104, "class", "row");
            __builder.OpenElement(105, "div");
            __builder.AddAttribute(106, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(107);
            __builder.AddAttribute(108, "Text", "WHSE_NO");
            __builder.AddAttribute(109, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\n        ");
            __builder.OpenElement(111, "div");
            __builder.AddAttribute(112, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(113);
            __builder.AddAttribute(114, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(115, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(116, "style", "display: block; width: 100%");
            __builder.AddAttribute(117, "Name", "WHSE_NO");
            __builder.AddAttribute(118, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 62 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(119, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(120, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(121, "\n    ");
            __builder.OpenElement(122, "div");
            __builder.AddAttribute(123, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(124, "class", "row");
            __builder.OpenElement(125, "div");
            __builder.AddAttribute(126, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(127);
            __builder.AddAttribute(128, "Text", "WHSE_NO");
            __builder.AddAttribute(129, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(130, "\n        ");
            __builder.OpenElement(131, "div");
            __builder.AddAttribute(132, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(133);
            __builder.AddAttribute(134, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 72 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(135, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 72 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(136, "style", "display: block; width: 100%");
            __builder.AddAttribute(137, "Name", "WHSE_NO");
            __builder.AddAttribute(138, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 72 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(139, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(140, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\n    ");
            __builder.OpenElement(142, "div");
            __builder.AddAttribute(143, "style", "margin-bottom: 1rem");
            __builder.AddAttribute(144, "class", "row");
            __builder.OpenElement(145, "div");
            __builder.AddAttribute(146, "class", "col-md-3");
            __builder.OpenComponent<Radzen.Blazor.RadzenLabel>(147);
            __builder.AddAttribute(148, "Text", "WHSE_NO");
            __builder.AddAttribute(149, "style", "width: 100%");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(150, "\n        ");
            __builder.OpenElement(151, "div");
            __builder.AddAttribute(152, "class", "col-md-9");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(153);
            __builder.AddAttribute(154, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 82 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(155, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 82 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(156, "style", "display: block; width: 100%");
            __builder.AddAttribute(157, "Name", "WHSE_NO");
            __builder.AddAttribute(158, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 82 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                                                                                             args.WHSE_NO

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(159, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => args.WHSE_NO = __value, args.WHSE_NO))));
            __builder.AddAttribute(160, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => args.WHSE_NO));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(161, "\n\n\n    ");
            __builder.OpenElement(162, "div");
            __builder.AddAttribute(163, "class", "row");
            __builder.OpenElement(164, "div");
            __builder.AddAttribute(165, "class", "col-md-12");
            __builder.OpenElement(166, "h3");
            __builder.AddContent(167, 
#nullable restore
#line 91 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                  args.WHSE_NO

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(168, "\n        ");
            __builder.OpenElement(169, "div");
            __builder.AddAttribute(170, "class", "col-md-12");
            __builder.OpenElement(171, "h3");
            __builder.AddContent(172, 
#nullable restore
#line 94 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                  args.WHSE_NO

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(173, "\n    ");
            __builder.OpenElement(174, "div");
            __builder.AddAttribute(175, "class", "row");
            __builder.AddAttribute(176, "style", "margin-top:16px;");
            __builder.OpenElement(177, "div");
            __builder.AddAttribute(178, "class", "col-md-12");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(179);
            __builder.AddAttribute(180, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 100 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
                                   (args) => dialogService.Close(true)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(181, "Text", "OK");
            __builder.AddAttribute(182, "Style", " width: 150px");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 104 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\DialogC010.razor"
            [Parameter] public RadzenDh5.Models.Mark10Sqlexpress04.Vc010 args { get; set; } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Radzen.DialogService dialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591
