#pragma checksum "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\Cart\DisplayCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1edc5d26ea4e52d0ceb769fb25ae88827feb2ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_DisplayCart), @"mvc.1.0.view", @"/Views/Cart/DisplayCart.cshtml")]
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
#line 1 "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\_ViewImports.cshtml"
using Loot_Lo_Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\_ViewImports.cshtml"
using Loot_Lo_Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\Cart\DisplayCart.cshtml"
using Loot_Lo_Client.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1edc5d26ea4e52d0ceb769fb25ae88827feb2ef", @"/Views/Cart/DisplayCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a889e2bd6a8c38af698050c7d9494fbdc545176", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_DisplayCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\Cart\DisplayCart.cshtml"
 foreach (var i in SessionHelper.GetObjectFromJson<List<int>>(Context.Session, "Cart"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h6>");
#nullable restore
#line 11 "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\Cart\DisplayCart.cshtml"
   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 12 "C:\Project\Group3.NETProject\Loot_Lo_Ecommerce\Loot_Lo_Client\Views\Cart\DisplayCart.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
