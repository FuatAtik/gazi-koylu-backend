#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d7bed7580b2c83cbd08a686ea2ba5c44f832243"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_OurNewsAndSocialResponsibilityContent), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/OurNewsAndSocialResponsibilityContent.cshtml")]
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
#line 1 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\_ViewImports.cshtml"
using Taigate.Cms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\_ViewImports.cshtml"
using Taigate.Cms.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d7bed7580b2c83cbd08a686ea2ba5c44f832243", @"/Views/Themes/DoganlarMobilya/Components/OurNewsAndSocialResponsibilityContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_OurNewsAndSocialResponsibilityContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.OurNewsAndSocialResponsibilityContent>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
  
    var tempdate = "";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""text-center"">
                    <div class=""vlt-animated-block"" data-aos=""fade"" data-aos-delay=""0"">
                    </div>
                </div>
                <div class=""vlt-gap-60"">
                </div>
                <div class=""price-accordion"" id=""accordion"">
");
#nullable restore
#line 17 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                     foreach (var item in Model)
                    {
                        var year = item.OurNewsAndSocialResponsibilityContentDates.Year;
                        if (!tempdate.Contains(year))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3 class=\"accordion-title\">");
#nullable restore
#line 22 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                                   Write(year);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </h3>\r\n                            <div class=\"vlt-animated-block\" data-aos=\"fade\" data-aos-delay=\"100\">\r\n");
#nullable restore
#line 25 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                 foreach (var contentItem in Model)
                                {
                                    if (contentItem.OurNewsAndSocialResponsibilityContentDates.Year == year)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <!--Award item-->\r\n                                        <div class=\"vlt-award-item\">\r\n                                            <a class=\"vlt-award-item__link\"");
            BeginWriteAttribute("href", " href=\"", 1454, "\"", 1485, 1);
#nullable restore
#line 31 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
WriteAttributeValue("", 1461, contentItem.RedirectUrl, 1461, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                                            <div class=\"vlt-award-item__name\">\r\n");
#nullable restore
#line 33 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                                 if (contentItem.Title.Length > 120)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <p>");
#nullable restore
#line 35 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                                  Write(contentItem.Title.Substring(0, 120));

#line default
#line hidden
#nullable disable
            WriteLiteral("...\r\n                                                    </p>\r\n");
#nullable restore
#line 37 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                                }
                                                else
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                               Write(contentItem.Title);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                                                      
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </div>\r\n                                            <a class=\"vlt-award-item__category\"");
            BeginWriteAttribute("href", " href=\"", 2274, "\"", 2305, 1);
#nullable restore
#line 43 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
WriteAttributeValue("", 2281, contentItem.RedirectUrl, 2281, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Localized(Bizden_Haberler_Incele_Text)</a>
                                            <div class=""vlt-award-item__icon"">
                                                <i class=""icon-arrow-top-right"">
                                                </i>
                                            </div>
                                        </div>
");
#nullable restore
#line 49 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
#nullable restore
#line 52 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\OurNewsAndSocialResponsibilityContent.cshtml"
                        }
                        else
                        {
                            continue;
                        }
                        tempdate+=year+",";
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<div class=\"vlt-gap-90\">\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.OurNewsAndSocialResponsibilityContent>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
