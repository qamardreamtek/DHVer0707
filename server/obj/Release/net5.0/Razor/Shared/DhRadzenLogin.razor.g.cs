#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e27741d5b91ccf8afb720c0b1b335b1b6a509491"
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
#line 2 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
    public partial class DhRadzenLogin : DhRadzen.DhRadzenComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
 if (Visible)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddMultipleAttributes(1, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, object>>>(
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                  Attributes

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "class", 
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                      GetCssClass()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "style", 
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                             Style

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "id", 
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                                         GetId()

#line default
#line hidden
#nullable disable
            );
            __builder.AddElementReferenceCapture(5, (__value) => {
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 13 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 14 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 18 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 20 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 21 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                           ButtonStyle.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(56, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                            ButtonType.Submit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(57, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                                                     LoginText

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(58, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                                                                      OnLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 27 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                 if (AllowResetPassword)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(59, "a");
            __builder.AddAttribute(60, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
             OnReset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(61, 
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                      ResetPasswordText

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                           }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 33 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
     if (AllowRegister)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "class", "register");
            __builder.AddContent(64, 
#nullable restore
#line 36 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
     RegisterMessageText

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(65, "\n    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(66);
            __builder.AddAttribute(67, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 37 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                              ButtonType.Button

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(68, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 37 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                              ButtonStyle.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(69, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 37 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                                         RegisterText

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(70, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                                                                             OnRegister

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 38 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
      }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 39 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
      }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
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
            // 0.10.7
            // NOTE by Mark,
            // 要在這裡觸發同步
           // await ButtonSubmitClick(); // 不行, 要放到 Controller 


            //    await Task.Delay(5000); // 這是為觀察這個動作的 Toast, 在這裡無效, 因為外層的 form , 直接就跳轉到 account/login

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 130 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Shared\DhRadzenLogin.razor"
                                                       



        await Login.InvokeAsync(new Radzen.LoginArgs { Username = Username, Password = Password });
    }
}


// 以下是原在同步開發時做的, 先整個帶過來再調試

[Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
[Inject]
protected NotificationService NotificationService { get; set; }
[Inject]
protected SecurityService Security { get; set; }
protected void Toast(NotificationSeverity severity, string msg, double duration = 4000)
{
    NotificationService.Notify(new NotificationMessage() { Severity = severity, Summary = "", Detail = msg, Duration = duration });

}

public async Task<ApplicationUser>
    DhCreateUser(string Name, string Password)
{

    var old = await Security.GetUserByName(Name);
    if (old != null)
    {
        //   Toast(NotificationSeverity.Info, old.Name + " 已存在");
        var old2 = await Security.DeleteUser(old.Id);
        //   Toast(NotificationSeverity.Info, old2.Name + " 已刪除");
    }

    var obj = new ApplicationUser();
    obj.Email = Name;// "mark3";
    obj.Password = Password;// "Aa123@"; 已經設為最少 8 chars, like ASRS,123
                            // 到這裡, 如不滿足會導致頁面出錯, 但不在用戶端報錯, 使用 browser inspect to check
    var obj2 = await Security.CreateUser(obj);
    return obj2;
}

public async Task ButtonSubmitClick()
{

    //     var x = await DhCreateUser("mark4", "Aa123@");
    //var x = await DhCreateUser("mark4", "ASRS,123");

    //Toast(NotificationSeverity.Success, x.Name + " created!");

    var toCreateList = AppDb.UserMsts.OrderBy(a => a.USER_ID);
    int cnt = 0;
    foreach (var u in toCreateList)
    {
        var u2 = await DhCreateUser(u.USER_ID, GetPlainPass(u.USER_PSWD));
        cnt += 1;
        //   Toast(NotificationSeverity.Success, u2.Name + " created!");

    }
    Toast(NotificationSeverity.Success, cnt + " 用戶已同步!");



}
//static string sKey = "22099478";
//static string sIV = "35783280";
static string sKey = RadzenDh5.Data.DhGlobalStatic.sKey;
static string sIV = RadzenDh5.Data.DhGlobalStatic.sIV;


public string GetPlainPass(string value)
{
    return clsTool_2.DecryptDES(value, sKey, sIV);
}
protected void OnPassChange(string value, string name)
{


    //      pass2 = clsTool_2.EncryptDES(value, sKey, sIV);
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