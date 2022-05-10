#pragma checksum "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c922660f5e19b37742394bc5047c4e4b172166bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shelter_ShelterDetails), @"mvc.1.0.view", @"/Views/Shelter/ShelterDetails.cshtml")]
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
#nullable restore
#line 7 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
using Data_Access_Layer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
using MyShelter.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c922660f5e19b37742394bc5047c4e4b172166bc", @"/Views/Shelter/ShelterDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"277f71284e154e47232a2fd030ac35a674ee330f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shelter_ShelterDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShelterEditViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shelter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllShelters", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
  
    ViewData["Title"] = "Details Shelter";
    Layout = "_Layout";
    var photoPath = "/Images/"+Model.ExistingImage;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"





<div class=""manage course content align-content-center d-flex justify-content-center"">
   
   
<div class=""courseDetails flex-column justify-content-between "" style=""width:70%;border-width:3px;border-color:#0e6ccd;border-radius: 15px;padding-left:30px;padding-right:30px;"">
    <div class=""d-flex justify-content-center  align-content-center"">
        <h2 class=""ggg"" style=""text-align:center;color:#0071c2;""><b> ");
#nullable restore
#line 20 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                Write(Model.ShelterName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h2>\r\n</div>\r\n<div class=\"form-outline mb-2 margin:20px; border:3px;\">\r\n                            <img class=\"gjpke\"");
            BeginWriteAttribute("src", " src=\"", 793, "\"", 809, 1);
#nullable restore
#line 23 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
WriteAttributeValue("", 799, photoPath, 799, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" object-fit=\"cover\" aspect-ratio =\"1/1\" style=\" padding-top:10px;\">\r\n                            </div>\r\n\r\n                            <div class=\"form-outline mb-2\"");
            BeginWriteAttribute("style", " style=\"", 988, "\"", 996, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"DetailsText\" for=\"form3Example1cg\"");
            BeginWriteAttribute("style", " style=\"", 1076, "\"", 1084, 0);
            EndWriteAttribute();
            WriteLiteral("><strong>Category: </strong> ");
#nullable restore
#line 27 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                                                             Write(Model.Category.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"form-outline mb-2\"");
            BeginWriteAttribute("style", " style=\"", 1234, "\"", 1242, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"DetailsText\" for=\"form3Example1cg\"");
            BeginWriteAttribute("style", " style=\"", 1322, "\"", 1330, 0);
            EndWriteAttribute();
            WriteLiteral("><strong>Name of facility: </strong> ");
#nullable restore
#line 30 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                                                                     Write(Model.ShelterName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"form-outline mb-2\"");
            BeginWriteAttribute("style", " style=\"", 1486, "\"", 1494, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"DetailsText\" for=\"form3Example1cg\"");
            BeginWriteAttribute("style", " style=\"", 1574, "\"", 1582, 0);
            EndWriteAttribute();
            WriteLiteral("><strong>City: </strong> ");
#nullable restore
#line 33 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                                                         Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"form-outline mb-2\"");
            BeginWriteAttribute("style", " style=\"", 1719, "\"", 1727, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"DetailsText\" for=\"form3Example1cg\"");
            BeginWriteAttribute("style", " style=\"", 1807, "\"", 1815, 0);
            EndWriteAttribute();
            WriteLiteral("><strong>Street: </strong> ");
#nullable restore
#line 36 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                                                           Write(Model.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n");
#nullable restore
#line 38 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
         if (@Model.PeopleCount.ToString().Length > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-outline mb-2\"");
            BeginWriteAttribute("style", " style=\"", 2007, "\"", 2015, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"DetailsText\" for=\"form3Example1cg\"");
            BeginWriteAttribute("style", " style=\"", 2095, "\"", 2103, 0);
            EndWriteAttribute();
            WriteLiteral("><strong>The number of people it can accommodate: </strong> ");
#nullable restore
#line 41 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                                                                                            Write(Model.PeopleCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n");
#nullable restore
#line 43 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"form-outline mb-2\"");
            BeginWriteAttribute("style", " style=\"", 2295, "\"", 2303, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <p class=\"DetailsText\" for=\"form3Example1cg\"");
            BeginWriteAttribute("style", " style=\"", 2383, "\"", 2391, 0);
            EndWriteAttribute();
            WriteLiteral("><strong>Description: </strong> ");
#nullable restore
#line 46 "D:\My Visual Studio proj\MyShelter\MyShelter\Views\Shelter\ShelterDetails.cshtml"
                                                                                                                Write(Model.ShelterShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>



                            
                           
                             <!--The div element for the map -->
   <input
      id=""pac-input""
      class=""controls""
      type=""text""
      placeholder=""Search Box""
    />
    <div id=""map""></div>
    
    <script
      src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyC1gRfrbVI20cLW1Fc8u6rgoq2Yi5z_LJk&callback=initAutocomplete&libraries=places&v=weekly""
      defer
    ></script>

    <div class=""form-outline mb-2"" style=""padding-top:15px;"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c922660f5e19b37742394bc5047c4e4b172166bc12572", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShelterEditViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
