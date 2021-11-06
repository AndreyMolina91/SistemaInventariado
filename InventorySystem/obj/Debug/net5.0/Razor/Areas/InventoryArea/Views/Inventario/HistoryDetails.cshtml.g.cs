#pragma checksum "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65fd6ce877a7ebf985236ae784d7163ddbdd2280"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_InventoryArea_Views_Inventario_HistoryDetails), @"mvc.1.0.view", @"/Areas/InventoryArea/Views/Inventario/HistoryDetails.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\_ViewImports.cshtml"
using InventorySystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\_ViewImports.cshtml"
using InventorySystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65fd6ce877a7ebf985236ae784d7163ddbdd2280", @"/Areas/InventoryArea/Views/Inventario/HistoryDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68c13ad3ce3bccfd7943c7e902e597710626709e", @"/Areas/InventoryArea/Views/_ViewImports.cshtml")]
    public class Areas_InventoryArea_Views_Inventario_HistoryDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DetalleInventario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "History", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
  
    ViewData["Title"] = "HistoryDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""pt-5 container"">
    <div class=""row"">
        <div class=""col-12 mb-2"">
            <h2 class=""text-primary border-bottom"">Detalles</h2>
        </div>
    </div>

    <div>
        <table class=""table"">
            <thead>
                <tr class=""table-secondary"">
                    <th class=""text-dark"">
                        Producto
                    </th>
                    <th class=""text-dark"">
                        Marca
                    </th>
                    <th class=""text-dark text-end"">
                        Costo
                    </th>
                    <th class=""text-dark text-end"">
                        Stock Anterior
                    </th>
                    <th class=""text-dark text-end"">
                        Cantidad
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 37 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
                   Write(Html.DisplayFor(i => item.Producto.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
                   Write(Html.DisplayFor(i => item.Producto.Marca.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-end\">\r\n                        ");
#nullable restore
#line 47 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
                   Write(Html.DisplayFor(i => item.Producto.Costo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-end\">\r\n                        ");
#nullable restore
#line 50 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
                   Write(Html.DisplayFor(i => item.StockAnterior));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-primary text-end\">      \r\n                        ");
#nullable restore
#line 53 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
                   Write(Html.DisplayFor(i => item.Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 56 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\InventoryArea\Views\Inventario\HistoryDetails.cshtml"
	             }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table> \r\n    </div>\r\n\r\n    <div class=\"col-12 pt-2 text-end\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65fd6ce877a7ebf985236ae784d7163ddbdd22808003", async() => {
                WriteLiteral("<i class=\"fa fa-chevron-circle-left\"></i>  Volver");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DetalleInventario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
