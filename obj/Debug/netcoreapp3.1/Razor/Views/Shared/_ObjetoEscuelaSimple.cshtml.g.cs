#pragma checksum "E:\Platzi\net Core\azure\sitioweb\Views\Shared\_ObjetoEscuelaSimple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b22ee9b477e9a1f16e12e3a15e62b0ddfc1366d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ObjetoEscuelaSimple), @"mvc.1.0.view", @"/Views/Shared/_ObjetoEscuelaSimple.cshtml")]
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
#line 1 "E:\Platzi\net Core\azure\sitioweb\Views\_ViewImports.cshtml"
using asp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Platzi\net Core\azure\sitioweb\Views\_ViewImports.cshtml"
using asp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b22ee9b477e9a1f16e12e3a15e62b0ddfc1366d", @"/Views/Shared/_ObjetoEscuelaSimple.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bebd56ce6d5789eeafe3e38405cba6e89b91ba6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ObjetoEscuelaSimple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ObjetoEscuelaBase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<p>\r\n    Nombre: ");
#nullable restore
#line 3 "E:\Platzi\net Core\azure\sitioweb\Views\Shared\_ObjetoEscuelaSimple.cshtml"
       Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    Id:     ");
#nullable restore
#line 4 "E:\Platzi\net Core\azure\sitioweb\Views\Shared\_ObjetoEscuelaSimple.cshtml"
       Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ObjetoEscuelaBase> Html { get; private set; }
    }
}
#pragma warning restore 1591
