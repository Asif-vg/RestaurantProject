#pragma checksum "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "213c536c354092a20321bd70a5dc478f3971b648"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
#line 1 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\_ViewImports.cshtml"
using DirectList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\_ViewImports.cshtml"
using DirectList.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\_ViewImports.cshtml"
using DirectList.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"213c536c354092a20321bd70a5dc478f3971b648", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"964494dd9b622aaffd2ab11fc0f07dc13b7fb31a", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmAbout>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight-bold text-warning mt-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg btn-block btn-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"titlebar\" class=\"gradient\">\r\n    <div class=\"title-bar-inner\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <h2>");
#nullable restore
#line 12 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                   Write(Model.Banner.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <span>Explore your search places</span>
                    <!-- Breadcrumbs -->
                    <nav id=""breadcrumbs"">
                        <ul>
                            <li><a>Home</a></li>
                            <li>");
#nullable restore
#line 18 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                           Write(Model.Banner.Page);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
    </div>
    <div class=""title-overlay""></div>
</div>


<div class=""content pt-0"">
    <div class=""about-wrapper"">
        <div class=""block-space"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-lg-6 col-md-10 ml-auto mr-auto"">
                        <div class=""section-title text-center mb-5"">
                            <h2>Three Simple Step To Started Working Process</h2>
                        </div>
                    </div>
                </div>
                <div class=""row"">
");
#nullable restore
#line 41 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                        int i = 0;
                        foreach (var step in Model.Steps)
                        {
                            i++;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                         <div class=""col-lg-4 col-md-12 mb-4"">
                            <div class=""about-info"">
                                <div class=""about-num-box"">
                                    <div class=""about-icon"">
                                        <span><i");
            BeginWriteAttribute("class", " class=\"", 1755, "\"", 1773, 1);
#nullable restore
#line 49 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
WriteAttributeValue("", 1763, step.Icon, 1763, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i></span>\r\n                                    </div>\r\n                                    <div class=\"about-highlight\">0");
#nullable restore
#line 51 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                                                              Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                </div>\r\n                                <div class=\"about-desc\">\r\n                                    <h4>");
#nullable restore
#line 54 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                                   Write(step.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    <p class=\"mb-0\">  ");
#nullable restore
#line 55 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                                                 Write(step.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                                </div>\r\n                            </div>\r\n                         </div>\r\n");
#nullable restore
#line 59 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"

                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""block-space bg-secondary"">
            <div class=""container"">
                <div class=""row row-grid align-items-center"">
                    <div class=""col-md-6"">
                        <div class=""card bg-default shadow border-0"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "213c536c354092a20321bd70a5dc478f3971b64810544", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2664, "~/Uploads/", 2664, 10, true);
#nullable restore
#line 71 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 2674, Model.About.Image, 2674, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <blockquote class=""card-blockquote"">
                                <svg preserveAspectRatio=""none"" xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 583 95"" class=""svg-bg"">
                                    <polygon points=""0,52 583,95 0,95"" class=""fill-default""></polygon>
                                    <polygon points=""0,42 583,95 683,0 0,95"" opacity="".2"" class=""fill-default""></polygon>
                                </svg>
                                <h4 class=""display-3 font-weight-bold text-white"">
                                    ");
#nullable restore
#line 78 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                               Write(Model.About.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </h4>\r\n                                <p class=\"lead text-italic text-white\">\r\n                                    ");
#nullable restore
#line 81 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                               Write(Model.About.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </p>
                            </blockquote>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""pl-md-5"">
                            <div class=""icon icon-lg icon-shape icon-shape-warning shadow rounded-circle mb-5"">
                                <i class=""fa fa-info""></i>
                            </div>
                            <h3>About Us</h3>
                            <p class=""lead"">
                                ");
#nullable restore
#line 93 "C:\Users\CASPER\Desktop\BackEndProject\DirectList\DirectList\Views\About\Index.cshtml"
                           Write(Html.Raw(Model.About.Content2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "213c536c354092a20321bd70a5dc478f3971b64814401", async() => {
                WriteLiteral("Explore Your Places");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n        \r\n        <div");
            BeginWriteAttribute("class", " class=\"", 4426, "\"", 4434, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""container"">
                <div class=""card bg-gradient-warning shadow-lg border-0"">
                    <div class=""p-5"">
                        <div class=""row align-items-center"">
                            <div class=""col-lg-8"">
                                <h3 class=""text-white""> Lorem ipsum dolor sit amet consectetur</h3>
                                <p class=""lead text-white mt-3"">
                                    adipisicing elit. Quos, consectetur ex? Amet facere neque, eaque accusamus cumque, commodi fugit, provident
                                </p>
                            </div>
                            <div class=""col-lg-3 ml-lg-auto"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "213c536c354092a20321bd70a5dc478f3971b64816925", async() => {
                WriteLiteral("Start Now");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmAbout> Html { get; private set; }
    }
}
#pragma warning restore 1591
