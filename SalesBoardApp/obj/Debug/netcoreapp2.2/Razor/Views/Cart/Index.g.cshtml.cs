#pragma checksum "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b61df3ab542c96996a37d5df28b1ff6441b7918f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Index.cshtml", typeof(AspNetCore.Views_Cart_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\_ViewImports.cshtml"
using SalesBoardApp;

#line default
#line hidden
#line 2 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\_ViewImports.cshtml"
using SalesBoardApp.Models;

#line default
#line hidden
#line 2 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b61df3ab542c96996a37d5df28b1ff6441b7918f", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d16c2af1301b6b68a2c0b8c7c5943528c2dbb1ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SalesBoardApp.Models.ShoppingCartViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Purchase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(73, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 4 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(158, 267, true);
            WriteLiteral(@"
<h1>Cart</h1>


<table class=""table"">
    <thead>
        <tr>
            <th></th>
            <th>Option</th>
            <th>Name</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Sub Total</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
         foreach (var item in Model.Items)
        {

#line default
#line hidden
            BeginContext(478, 88, true);
            WriteLiteral("            <tr>\n                <td>\n                    <img style=\"max-width: 100px;\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 566, "\"", 621, 1);
#line 28 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
WriteAttributeValue("", 572, Html.DisplayFor(modelItem => item.Product.Image), 572, 49, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(622, 67, true);
            WriteLiteral(" />\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(689, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61df3ab542c96996a37d5df28b1ff6441b7918f7196", async() => {
                BeginContext(773, 6, true);
                WriteLiteral("Remove");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 31 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
                                                                   WriteLiteral(item.Product.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(783, 64, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(848, 47, false);
#line 34 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Product.Name));

#line default
#line hidden
            EndContext();
            BeginContext(895, 64, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(960, 48, false);
#line 37 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Product.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 64, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(1073, 43, false);
#line 40 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(1116, 64, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(1182, 34, false);
#line 43 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
                Write(item.Product.Price * item.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1217, 41, true);
            WriteLiteral("\n                </td>\n            </tr>\n");
            EndContext();
#line 46 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1268, 122, true);
            WriteLiteral("        <tr>\n            <td align=\"right\" colspan=\"5\"><strong>Total Price</strong></td>\n            <td>\n                ");
            EndContext();
            BeginContext(1391, 16, false);
#line 50 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
           Write(Model.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1407, 55, true);
            WriteLiteral("\n            </td>\n        </tr>\n    </tbody>\n</table>\n");
            EndContext();
            BeginContext(1462, 295, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61df3ab542c96996a37d5df28b1ff6441b7918f12588", async() => {
                BeginContext(1512, 50, true);
                WriteLiteral("\n    <p>\n        <input type=\"hidden\" name=\"Items\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1562, "\"", 1611, 1);
#line 57 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1570, JsonConvert.SerializeObject(Model.Items), 1570, 41, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1612, 50, true);
                WriteLiteral(" />\n        <input type=\"hidden\" name=\"TotalPrice\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1662, "\"", 1687, 1);
#line 58 "C:\Users\sam_h\Study\Distributed_Development_HIT339\sam_hood_sales_board_application\SalesBoardApp\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1670, Model.TotalPrice, 1670, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1688, 62, true);
                WriteLiteral(" />\n        <input type=\"submit\" value=\"Purchase\" />\n    </p>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1757, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(1758, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61df3ab542c96996a37d5df28b1ff6441b7918f15570", async() => {
                BeginContext(1806, 17, true);
                WriteLiteral("Continue Shopping");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1827, 2, true);
            WriteLiteral("\n\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SalesBoardApp.Models.ShoppingCartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591