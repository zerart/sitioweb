#pragma checksum "E:\Platzi\net Core\asp\Views\Shared\_ListaObjetoEscuela.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "376b465b55199edd6c023c45c23dc4b500c63a0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ListaObjetoEscuela), @"mvc.1.0.view", @"/Views/Shared/_ListaObjetoEscuela.cshtml")]
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
#line 1 "E:\Platzi\net Core\asp\Views\_ViewImports.cshtml"
using asp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Platzi\net Core\asp\Views\_ViewImports.cshtml"
using asp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"376b465b55199edd6c023c45c23dc4b500c63a0f", @"/Views/Shared/_ListaObjetoEscuela.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bebd56ce6d5789eeafe3e38405cba6e89b91ba6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ListaObjetoEscuela : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<table class=\"table table-dark table-hover\">\r\n    <thead>\r\n        <tr>\r\n        <th scope=\"col\">Nombre</th>\r\n        <th scope=\"col\">Id</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 12 "E:\Platzi\net Core\asp\Views\Shared\_ListaObjetoEscuela.cshtml"
         foreach (var obj in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 16 "E:\Platzi\net Core\asp\Views\Shared\_ListaObjetoEscuela.cshtml"
               Write(obj.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                \r\n                <td>\r\n                    ");
#nullable restore
#line 20 "E:\Platzi\net Core\asp\Views\Shared\_ListaObjetoEscuela.cshtml"
               Write(obj.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 23 "E:\Platzi\net Core\asp\Views\Shared\_ListaObjetoEscuela.cshtml"
        }    

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591