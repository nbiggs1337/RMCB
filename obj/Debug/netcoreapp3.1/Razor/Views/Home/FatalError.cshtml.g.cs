#pragma checksum "/Users/noahbiggs/Documents/CodingDojo/Project/RMCB/Views/Home/FatalError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c464e376c9730c84173ff659f27fafbe6dbd6ce7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FatalError), @"mvc.1.0.view", @"/Views/Home/FatalError.cshtml")]
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
#line 1 "/Users/noahbiggs/Documents/CodingDojo/Project/RMCB/Views/_ViewImports.cshtml"
using RMCB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/noahbiggs/Documents/CodingDojo/Project/RMCB/Views/_ViewImports.cshtml"
using RMCB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c464e376c9730c84173ff659f27fafbe6dbd6ce7", @"/Views/Home/FatalError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27da876db5162eafc27d95f215bd8f892a64348c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FatalError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/noahbiggs/Documents/CodingDojo/Project/RMCB/Views/Home/FatalError.cshtml"
  
    ViewData["Title"] = "Fatal Error";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""text-danger"">Fatal Error.</h1>
<h2 class=""text-danger"">Your request encountered a failure and was redirected here.</h2>
<h2 class=""text-danger"">Retry your request - then contact Admin ASAP - No changes were made to DB.  </h2>

<h3><a href=""/Admin"">Click here to reenter admin panel</a></h3>
<br><br><br>
<hr>
<h4>Likely causes: </h4>
<ul>
    <h4><li>Bad Modelstate</li></h4>
    <h4><li>Bad Acc Permissions</li></h4>
    
    
</ul>");
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