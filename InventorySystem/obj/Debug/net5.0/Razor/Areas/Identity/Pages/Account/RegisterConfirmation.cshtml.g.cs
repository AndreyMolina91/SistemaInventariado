#pragma checksum "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36b2b1b4a537706a59c1e62b20420ca6c12f1404"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_RegisterConfirmation), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\_ViewImports.cshtml"
using InventorySystem.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\_ViewImports.cshtml"
using InventorySystem.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using InventorySystem.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36b2b1b4a537706a59c1e62b20420ca6c12f1404", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"898b42561ebeb8a6ce96f1dbf24d7fc2677e8b63", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"554831d94ec74ea4b9b3d47cd9c9eb34be123f4b", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_RegisterConfirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100 pt-4 m-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/imgs/folder-body/Almacen-minimal.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    ViewData["Title"] = "Usuario creado correctamente";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <br />\r\n    <h1 class=\"border-bottom text-primary\">");
#nullable restore
#line 8 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 9 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
      
        if (@Model.DisplayConfirmAccountLink)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>\r\n                Aún no hemos configurado nuestro envio de email <a href=\"https://aka.ms/aspaccountconf\">¿Cómo configurar?</a> Mientras configuramos nuestro\r\n                email Sender: <a id=\"confirm-link\"");
            BeginWriteAttribute("href", " href=\"", 500, "\"", 534, 1);
#nullable restore
#line 14 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
WriteAttributeValue("", 507, Model.EmailConfirmationUrl, 507, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Puede activar su cuenta dando click AQUÍ</a>\r\n            </p>\r\n");
#nullable restore
#line 16 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>\r\n                Próximamente, Checkee su email para confirmar su registro.\r\n            </p>\r\n");
#nullable restore
#line 22 "C:\Users\Lenovo\source\repos\SistemaInventariado\InventorySystem\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
        }


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-6\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "36b2b1b4a537706a59c1e62b20420ca6c12f14047838", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" 
            </div>
            <div class=""col-6"">
                <h1 class=""mt-4 pt-5"">Bienvenido a la compañia. </h1>
                
                <p class=""pt-4""> Para mayor información sobre nuestros servicios<br /> no dude en contactarnos o seguirnos en nuestras RS. </p> <br />
                <div class=""mb-0""><i class=""fab fa-facebook-square"" style=""font-size:18px""></i> <i class=""fab fa-linkedin "" style=""font-size:18px""></i></div>
                
            </div>
        </div>
");
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterConfirmationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel>)PageContext?.ViewData;
        public RegisterConfirmationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591