#pragma checksum "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2ee55837877715997fa438465e4a216a0477c28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cliente_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Cliente/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\_ViewImports.cshtml"
using MedicalPLE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\_ViewImports.cshtml"
using MedicalPLE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2ee55837877715997fa438465e4a216a0477c28", @"/Areas/Cliente/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"978ba0f258193915eb83ef3b7da47e406cca32d5", @"/Areas/Cliente/Views/_ViewImports.cshtml")]
    public class Areas_Cliente_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MedicalPLE.Models.ViewModels.HomeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius:2px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--SLIDER-->\r\n<!--SLIDER-->\r\n<header>\r\n    <div id=\"carouselExampleIndicators\" class=\"carousel slide\" data-ride=\"carousel\">\r\n        <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 11 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
               int cont = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
             foreach (var item in Model.Slider)
            {
                var itemDinamico = cont++ == 0 ? "item active" : "item";


#line default
#line hidden
#nullable disable
            WriteLiteral("                <!-- Slide One - Set the background image for this slide in the line below -->\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 543, "\"", 578, 2);
            WriteAttributeValue("", 551, "carousel-item", 551, 13, true);
#nullable restore
#line 17 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 564, itemDinamico, 565, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img style=\"width:600px;height:500px;float:left; margin: 15px; border-radius:20px\"");
            BeginWriteAttribute("src", " src=\"", 684, "\"", 718, 1);
#nullable restore
#line 18 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue("", 690, Url.Content(item.UrlImagen), 690, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <div class=\"container\">\r\n                        <h1 class=\"text-dark text-center\">");
#nullable restore
#line 20 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
                                                     Write(Html.Raw(@item.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                        <p class=\"text-dark text-center\">");
#nullable restore
#line 21 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
                                                    Write(Html.Raw(@item.Contenido));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 25 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
        <!-- Botones de Avance -->
        <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>
</header>
<!--Cierra slider-->
<!--
    <div class=""row fondoTitulo mt-5"">
    <div class=""col-sm-12 py-5"">
        <h1 class=""text-center text-white"">Últimos Productos</h1>
    </div>
</div>
-->
<!--ARTICULOS-->
");
#nullable restore
#line 48 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
 if (Model.ListaArticulos.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 52 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
         foreach (var articulo in Model.ListaArticulos.OrderBy(o => o.Id))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4\">\r\n                <div class=\"card\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 2068, "\"", 2093, 1);
#nullable restore
#line 56 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
WriteAttributeValue("", 2074, articulo.UrlImagen, 2074, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail\" style=\"width:300px;height:300px\" ; />\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"text-center\">");
#nullable restore
#line 58 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
                                           Write(articulo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p>");
#nullable restore
#line 59 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
                      Write(articulo.FechaCreacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2ee55837877715997fa438465e4a216a0477c289975", async() => {
                WriteLiteral("Más información");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
                                                                                                    WriteLiteral(articulo.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 64 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 66 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No existen articulos</p>\r\n");
#nullable restore
#line 70 "C:\Users\Victor\Desktop\MedicalPLE\MedicalPLE\MedicalPLE\Areas\Cliente\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MedicalPLE.Models.ViewModels.HomeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
