#pragma checksum "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e374da461af61c5a1163c30635dd52fc49af03cd"
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
#line 6 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
using RadzenDh5.Models.Mark10Sqlexpress04;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
using RadzenDh5.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/welcome")]
    public partial class Welcome : RadzenDh5.Pages.WelcomeComponent
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
#line 18 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                        L["pageTitle.Text"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n        ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-3");
                __builder2.OpenComponent<Radzen.Blazor.RadzenLabel>(11);
                __builder2.AddAttribute(12, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 22 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                    L["label-user.Text"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "ReadOnly", "true");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(14, "\n                ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTextBox>(15);
                __builder2.AddAttribute(16, "ReadOnly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                         true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(17, "Name", "TextboxUser");
                __builder2.AddAttribute(18, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                                              Security.User.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Security.User.Name = __value, Security.User.Name))));
                __builder2.AddAttribute(20, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Security.User.Name));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\n            ");
                __builder2.OpenElement(22, "div");
                __builder2.AddAttribute(23, "class", "col-3");
                __builder2.AddMarkupContent(24, "\n                限開發測試使用\n                ");
                __Blazor.RadzenDh5.Pages.Welcome.TypeInference.CreateRadzenDropDown_0(__builder2, 25, 26, 
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                        new[] { new { Text="Chinese (Simplified)", Value="zh-CHS" },new { Text="Chinese (Traditional)", Value="zh-CHT" },new { Text="English - United States", Value="en-US" },new { Text="Thai - Thailand", Value="th-TH" }}

#line default
#line hidden
#nullable disable
                , 27, "margin-right: 8px; margin-top: 4px", 28, "Text", 29, "Value", 30, "Dropdown1", 31, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, 
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                                                                                                                                                                                                                                                                                                                                                                                      Dropdown1Change

#line default
#line hidden
#nullable disable
                ), 32, 
#nullable restore
#line 29 "D:\myprogram\core\temp\temp0707 - try debug\DHVer0707-main\RadzenDH6\server\Pages\Welcome.razor"
                                                                                                                                                                                                                                                                                                                                             Culture

#line default
#line hidden
#nullable disable
                , 33, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Culture = __value, Culture)), 34, () => Culture);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(35, "\n        <hr>\n        ");
                __builder2.AddMarkupContent(36, "<h2><a href=\"/topic1\">待確認主題一</a></h2>\n        登入頁面(不選擇語系), 左側菜單(可收), 用戶權限(含菜單和實際頁面), 多語效果(是否需要繁中)。<br>\n        同步後請以另一款流覽器登出登入驗証用戶權限。\n        <hr>\n        ");
                __builder2.AddMarkupContent(37, "<h2><a href=\"/topic2\">待確認主題二</a></h2>\n        決定本項目標準的增刪改查頁面風格。提示單獨特殊的頁面(程序)需求。\n        <hr>\n        ");
                __builder2.AddMarkupContent(38, "<h2>Recap of 04/07 onsite meeting</h2>\n        ");
                __builder2.AddMarkupContent(39, "<ol><li>Loin 畫面加語系選擇,登入後不再選, 登入後目錄即顯示應對語系文字。</li>\n            <li>Menu 同意使用 https://blazor.radzen.com/ 左側可以收起打開的 Nav Menu 來實現 WES 畫面左側欄框的 Tree Menu。</li>\n            <li>權限機制同意使用 ASP.NET Core Identity, https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio, 包括新增 AspNetUsers 等數據庫表單納入DHDB</li>\n            <li>\n                同步 WES [USER-GROUP-PROG] 到 Identity [User-Roles] 時, 只要 [PROG_WRT][GROUP_WRT]的 ENABLE 為Y 即屬有效, 用戶即可看到基本查詢頁面, 進一步要在各頁面處理\n                QUERY_WRT\tPRINT_WRT\tIMPORT_WRT\tEXPORT_WRT\tUPDATE_WRT\tDELETE_WRT\tAPPROVE_WRT 所應對顯示及有效權限運行的功能。\n\n\n\n            </li>\n            <li>一般性的查詢頁面,同意使用 https://blazor.radzen.com/tabs Customers 的風格, 分頁要提到整個顯示Table的上方。Table 裡的欄位顯示順序和方式,同WES。  </li>\n            <li>\n                04/14 版本, 先满足上述, 並先完成後述表列頁面的 layout\n                <ul><li><a href=\"/S030\">S030</a>:  程序清單, 基本的單表查詢, 分頁在上。完成。</li>\n                    <li><a href=\"/S040\">S040</a>:  群組用戶清單, 使用 Radzen DataGrid, 上方為群組, 下左為可加入的用戶,下右為已加入的用戶。TODO: 1.上方點選觸發下方更新 2.Add/Remove</li>\n                    <li><a href=\"vr-030-s\">R030</a> 做成VIEW, 生成Entity, 能導出EXCEL。 文檔裡有,代碼裡有, 在DHDB裡目前沒出現, 可以用WES操作顯示出來. DH5需要單獨加在 Nav</li>\n                    <li><span style=\"color:red\">R080 目前 WES 運行會報錯</span></li>\n                    <li><a href=\"/Q040\">\n                            Q040 Tab3[TR Header][TR Items][Serial Items]\n                        </a>\n                        <pre>\n DataTable dtMST = new DataTable(\"IN_MST\"); //TR主檔\n DataTable dtDTL = new DataTable(\"IN_DTL\"); //TR明細檔\n DataTable dtSNO = new DataTable(\"IN_SNO\"); //TR托盤序列號明細\n\n       string sSQL = string.Format(@\"select distinct a.* from {0} a join {1} b on (a.IN_NO=b.IN_NO) where 1=1\", dtMST.TableName,dtSNO.TableName);\n            if (tbSKU_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@\" and b.SKU_NO like \'%{0}%\'\", tbSKU_NO.Text.Trim().ToUpper());\n            if (tbGTIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@\" and b.GTIN_NO like \'%{0}%\'\", tbGTIN_NO.Text.Trim().ToUpper());\n            if (tbREQM_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@\" and b.REQM_NO like \'%{0}%\'\", tbREQM_NO.Text.Trim().ToUpper());\n            if (tbIN_NO.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@\" and b.IN_NO like \'%{0}%\'\", tbIN_NO.Text.Trim().ToUpper());\n            if (tbSU_ID.Text.Trim().Length > 0) sSQL = sSQL + string.Format(@\" and b.SU_ID like \'%{0}%\'\", tbSU_ID.Text.Trim().ToUpper());\n sSQL = string.Format(@\"select * from {0} where IN_NO=\'{1}\' order by IN_LINE\", dtDTL.TableName, sIN_NO);\n sSQL = string.Format(@\"select * from {0} where IN_NO=\'{1}\' and IN_LINE = \'{2}\' order by IN_NO,IN_LINE,IN_SNO\", dtSNO.TableName, sIN_NO, sIN_LINE);\n</pre></li>\n                    <li>\n                        Q100 所有儲位的狀況, 四個TAB 分別為 [Lane 1.][Lane 2.][Lane 3.][Lane 4.]\n                        <ul><li>每個Lane 有兩個ROW, 每個ROW 由左而右01->98, 由下而上, 01->12</li>\n                            <li><pre>\n string sSQL = \"select * from LOC_MST where EQU_NO in (\'01\',\'02\',\'03\',\'04\') order by EQU_NO,ROW_X,LVL_Z,BAY_Y\";\n                Globals.QueryTable(ref dtLocMst, sSQL);\n                if (dtLocMst.Rows.Count > 0)\n                {\n                    for (int i = 0; i &lt; dtLocMst.Rows.Count; i++)\n                    {\n\n                        int iRow = Convert.ToInt32(dtLocMst.Rows[i][\"ROW_X\"]) - 1;\n                        int iBay = Convert.ToInt32(dtLocMst.Rows[i][\"BAY_Y\"]) - 1;\n                        int iLvl = dgvLocSts[iRow].RowCount - Convert.ToInt32(dtLocMst.Rows[i][\"LVL_Z\"]);\n                        string sSTS = Convert.ToString(dtLocMst.Rows[i][\"LOC_STS\"]);\n\n                        dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Value = sSTS;\n               \n  switch (sSTS)\n                        {\n                            case \"N\": //空储位\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.White;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.Black;\n                                if (Convert.ToString(dtLocMst.Rows[i][\"LOC_SIZE\"])==\"H\") iSTS_N_H[iRow]++;\n                                else iSTS_N_L[iRow]++;\n                                break;\n                            case \"S\": //庫存储位\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Lime;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.Black;\n                                iSTS_S[iRow]++;\n                                break;\n                            case \"E\": //空托盤 \n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Blue;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.White;\n                                iSTS_E[iRow]++;\n                                break;\n                            case \"I\": //入庫預約\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.DeepSkyBlue;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.Red;\n                                iSTS_I[iRow]++;\n                                break;\n                            case \"O\": //出庫預約\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Yellow;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.Red;\n                                iSTS_O[iRow]++;\n                                break;\n                            case \"C\": //盤點預約\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Purple;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.White;\n                                iSTS_C[iRow]++;\n                                break;\n                            case \"P\": //盤點待調帳 \n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Brown;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.White;\n                                iSTS_P[iRow]++;\n                                break;\n                            case \"X\": //禁用 \n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Black;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.Yellow;\n                                iSTS_X[iRow]++;\n                                break;\n                            case \"F\": //異常储位 \n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.BackColor = Color.Red;\n                                dgvLocSts[iRow].Rows[iLvl].Cells[iBay].Style.ForeColor = Color.Yellow;\n                                iSTS_F[iRow]++;\n                                break;\n                            default: continue;\n                        }\n\n</pre></li></ul></li>\n                    <li>M070 ??? No data </li>\n                    <li>\n                        M090     以 LOC_MST 為主體, 要處理 update\n                        <pre>\nDataTable dtMST = new DataTable(\"LOC_MST\"); //儲位主檔\nDataTable dtDTL = new DataTable(\"PLT_DTL\"); //托盤明細\n</pre>\n                        9408筆\n                        <ul><li>可以使用的模板 https://blazor.radzen.com/master-detail</li></ul></li>\n                    <li>C010  Physical Inventory Count</li>\n                    <li>C030 Physical Inventory Record</li>\n                    <li>P030 ??? No data</li>\n                    <li>P070</li>\n                    <li>P090</li></ul></li>\n            <li>\n                項目內預計要完工的PROGRAM, 以文檔為基準。\n                <ul><li>http://yun4.dreamaitek.com:5002/doc</li>\n                    <li>\n                        目前第一版的DHDB的 admin 沒有顯示 R000\n                        <ul><li>R030 Daily Inbound Summary Report上架日报</li>\n                            <li> R040 Daily Outbound Summary Report下架日报</li>\n                            <li>\n\n                                R050 Stock Inquiry Report库存查询报表\n                            </li>\n                            <li>\n                                R060 Stock Movement Pallet库存异动托盘数\n                            </li>\n                            <li>\n                                R070 Stock Movement Transaction库存异动交易数\n                            </li>\n                            <li> R080 Stock Counting Difference盘点差异</li></ul></li>\n                    <li>\n                        在第一版的DHDB的基礎上, 準備SQL腳本\n                        <ul><li>ASP.NET Core Identity 相關 TABLES</li>\n                            <li>一些查詢使用的 VIEW</li>\n                            <li>讓admin用戶具有以述 報表的訪問權限</li></ul></li></ul></li>\n\n            <li>\n                提供現階段 WepApp 佈署在一般筆電的 Publish 檔案夾, 包括安裝步驟。\n                <ul><li>\n                        基本檔案\n                        <ul><li>DHDB 數據庫第一版</li>\n                            <li>數據腳本建立必要的TABLE/VIEW</li>\n                            <li>WebApp  (Ver. 04/14) Publish zip 檔</li></ul></li>\n\n                    <li>\n                        設置要點\n                        <ul><li>安裝 Runtime, 最新的.NET 5.0, https://dotnet.microsoft.com/download</li>\n                            <li>IIS 新站點</li></ul></li></ul></li></ol>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<Welcome> L { get; set; }
    }
}
namespace __Blazor.RadzenDh5.Pages.Welcome
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenDropDown_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.IEnumerable __arg0, int __seq1, System.Object __arg1, int __seq2, global::System.String __arg2, int __seq3, global::System.String __arg3, int __seq4, global::System.String __arg4, int __seq5, global::Microsoft.AspNetCore.Components.EventCallback<global::System.Object> __arg5, int __seq6, global::System.Object __arg6, int __seq7, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg7, int __seq8, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg8)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenDropDown<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "style", __arg1);
        __builder.AddAttribute(__seq2, "TextProperty", __arg2);
        __builder.AddAttribute(__seq3, "ValueProperty", __arg3);
        __builder.AddAttribute(__seq4, "Name", __arg4);
        __builder.AddAttribute(__seq5, "Change", __arg5);
        __builder.AddAttribute(__seq6, "Value", __arg6);
        __builder.AddAttribute(__seq7, "ValueChanged", __arg7);
        __builder.AddAttribute(__seq8, "ValueExpression", __arg8);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
