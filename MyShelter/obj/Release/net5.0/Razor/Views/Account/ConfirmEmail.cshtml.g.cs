#pragma checksum "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36f0d58e03fae16b6e6bf4d1d5536d4035512c33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
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
#line 1 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\_ViewImports.cshtml"
using MyShelter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36f0d58e03fae16b6e6bf4d1d5536d4035512c33", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"277f71284e154e47232a2fd030ac35a674ee330f", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "Підтвердьте пошту";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""mask d-flex align-items-center h-100 gradient-custom-3"">
    <div class=""container h-100"">
        <div class=""row d-flex justify-content-center align-items-center h-100"">
            <div class=""col-12 col-md-9 col-lg-7 col-xl-6"">
                <div class=""LogInForm card""  style=""border-radius: 15px; border-width:2px;border-color:#0e6ccd;"">
                    <div class=""card-body p-5"">
                        <h3 class=""text-center"">
                     Реєстрація успішна! Ми надіслали Вам посилання для підтвердження вам на пошту. Перед тим, як входити, будь ласка, підтвердьте Вашу пошту.
                       </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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