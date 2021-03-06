// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RadzenDh5.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
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
#line 3 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Q100RowComp.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Q100RowComp.razor"
using Microsoft.Data.SqlClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Q100RowComp.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    public partial class Q100RowComp : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 126 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Q100RowComp.razor"
       
    [Parameter]
    public int ROW_NUM { get; set; }


    // ????????????????????? MLASRS ??????????????????,
    // ??? 05/28, Lane1 ????????????ROW:01,02,????????????
    public string Show_ROW_NUM { get; set; }

    public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> getLocMstsResult;

    public int colSelect;
    private int N_H, N_L, S, E, I, O, C, P, X, F = 0;

    protected override void OnInitialized()
    {
//        Show_ROW_NUM = "ROW:0" + (ROW_NUM - 1);
        Show_ROW_NUM = "ROW:0" + (ROW_NUM);



        for (int i = 12; i >= 1; i--)
        {
            foreach (var x in getRowLvl(ROW_NUM, i))
            {
                switch (x.LOC_STS)
                {
                    case "N": //????????? White and Black
                        if (x.LOC_SIZE == "H")
                            N_H = N_H + 1;
                        else if (x.LOC_SIZE == "L")
                            N_L = N_L + 1;
                        break;
                    case "S": //???????????? Lime and Black
                        S = S + 1;
                        break;
                    case "E": //????????? Blue and White
                        E = E + 1;
                        break;
                    case "I": //???????????? DeepSkyBlue and Red
                        I = I + 1;
                        break;
                    case "O": //???????????? Yellow and Red
                        O = O + 1;
                        break;
                    case "C": //???????????? Purple and White
                        C = C + 1;
                        break;
                    case "P": //??????????????? Brown and White
                        P = P + 1;
                        break;
                    case "X": //?????? Black and Yellow
                        X = X + 1;
                        break;
                    case "F": //???????????? Red and Yellow
                        F = F + 1;
                        break;
                    default:
                        break;
                }
            }
        }

    }

    IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> getRowLvl(int row, int lvl)
    {
        decimal decRow = Convert.ToDecimal(row);
        decimal decLvl = Convert.ToDecimal(lvl);

        var result = AppDb.LocMsts.Where(x => x.ROW_X == decRow && x.LVL_Z == decLvl).Take(100).ToList();
        return result;
    }

    void OnChange(int? value, string name)
    {
        //    console.Log($"{name} value changed to {value}");
    }

    private object SetRadzenLabel()
    {
        return N_L + "/" + N_H;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RadzenDh5.Data.Mark10Sqlexpress04Context AppDb { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<MainLayout> L { get; set; }
    }
}
#pragma warning restore 1591
