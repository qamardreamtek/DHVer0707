#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cea26dcf27a49b1d504b20488e45d3cf88faafd1"
// <auto-generated/>
#pragma warning disable 1591
namespace RadzenDh5.Shared
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
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    public partial class DhLocalLoginComponent : DhRadzen.DhComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddMultipleAttributes(1, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, object>>>(
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                  Attributes

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "class", 
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                      GetCssClass()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "style", 
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                             Style

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "id", 
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                                         GetId()

#line default
#line hidden
#nullable disable
            );
            __builder.AddElementReferenceCapture(5, (__value) => {
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
            Element = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "rz-form");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "row form-group");
            __builder.OpenElement(10, "label");
            __builder.AddAttribute(11, "class", "col-sm-3 col-form-label");
            __builder.AddAttribute(12, "for", "username");
            __builder.AddContent(13, 
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                   UserText

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\n            ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "col");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(17);
            __builder.AddAttribute(18, "style", "display: block");
            __builder.AddAttribute(19, "Name", "Username");
            __builder.AddAttribute(20, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                                   Username

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Username = __value, Username))));
            __builder.AddAttribute(22, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Username));
            __builder.CloseComponent();
            __builder.AddMarkupContent(23, "\n                ");
            __builder.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(24);
            __builder.AddAttribute(25, "Component", "Username");
            __builder.AddAttribute(26, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                    UserRequired

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(27, "style", "position: absolute");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n        ");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "row form-group");
            __builder.OpenElement(31, "label");
            __builder.AddAttribute(32, "class", "col-sm-3 col-form-label");
            __builder.AddAttribute(33, "for", "password");
            __builder.AddContent(34, 
#nullable restore
#line 15 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                   PasswordText

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\n            ");
            __builder.OpenElement(36, "div");
            __builder.AddAttribute(37, "class", "col");
            __builder.OpenComponent<Radzen.Blazor.RadzenPassword>(38);
            __builder.AddAttribute(39, "style", "display: block");
            __builder.AddAttribute(40, "Name", "Password");
            __builder.AddAttribute(41, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                                    Password

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Password = __value, Password))));
            __builder.AddAttribute(43, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Password));
            __builder.CloseComponent();
            __builder.AddMarkupContent(44, "\n                ");
            __builder.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(45);
            __builder.AddAttribute(46, "Component", "Password");
            __builder.AddAttribute(47, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 18 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                    PasswordRequired

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "style", "position: absolute");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\n        ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "row form-group");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "offset-sm-3 col login-buttons");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(54);
            __builder.AddAttribute(55, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                           ButtonStyle.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(56, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                            ButtonType.Submit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(57, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                                                     LoginText

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(58, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
                                                                                                                      OnLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhLocalLoginComponent.razor"
        

    protected override string GetComponentCssClass()
    {
        return "login";
    }

    string _username;
    [Parameter]
    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            if (_username != value)
            {
                _username = value;
            }
        }
    }

    string _password;
    [Parameter]
    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            if (_password != value)
            {
                _password = value;
            }
        }
    }

    [Parameter]
    public EventCallback<Radzen.LoginArgs> Login { get; set; }

    [Parameter]
    public EventCallback Register { get; set; }

    [Parameter]
    public EventCallback<string> ResetPassword { get; set; }

    [Parameter]
    public bool AllowRegister { get; set; } = true;

    [Parameter]
    public bool AllowResetPassword { get; set; } = true;

    [Parameter]
    public string LoginText { get; set; } = "Login";

    [Parameter]
    public string RegisterText { get; set; } = "Sign up";

    [Parameter]
    public string RegisterMessageText { get; set; } = "Don't have an account yet?";

    [Parameter]
    public string ResetPasswordText { get; set; } = "Forgot password";

    [Parameter]
    public string UserText { get; set; } = "Username";

    [Parameter]
    public string UserRequired { get; set; } = "Username is required";

    [Parameter]
    public string PasswordText { get; set; } = "Password";

    [Parameter]
    public string PasswordRequired { get; set; } = "Password is required";

    protected async Task OnLogin()
    {
        if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
        {
            await Login.InvokeAsync(new Radzen.LoginArgs { Username = Username, Password = Password });
        }
    }

    protected async Task OnReset(EventArgs args)
    {
        if (!string.IsNullOrEmpty(Username))
        {
            await ResetPassword.InvokeAsync(Username);
        }
    }

    protected async Task OnRegister()
    {
        await Register.InvokeAsync(EventArgs.Empty);
    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591