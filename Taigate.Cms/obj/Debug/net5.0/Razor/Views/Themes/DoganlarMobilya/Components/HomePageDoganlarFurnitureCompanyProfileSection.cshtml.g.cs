#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae748444d680246d5dc3b6c050cdab2de3c3df01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_HomePageDoganlarFurnitureCompanyProfileSection), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/HomePageDoganlarFurnitureCompanyProfileSection.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae748444d680246d5dc3b6c050cdab2de3c3df01", @"/Views/Themes/DoganlarMobilya/Components/HomePageDoganlarFurnitureCompanyProfileSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_HomePageDoganlarFurnitureCompanyProfileSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.HomePageDoganlarFurnitureCompanyProfileSection>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section class=""homepage-fifth"">
  <div class=""vlt-gap-120""></div>
  <div class=""container"">
    <div
      class=""vlt-isotope-grid""
      data-columns=""4""
      data-layout=""masonry""
      data-x-gap=""30|30""
      data-y-gap=""30|30""
      data-controls=""#vlt-filter-portfolio-05""
      data-load-more-selector=""#vlt-load-more-portfolio-05"">
      <div class=""grid-sizer""></div>
");
#nullable restore
#line 15 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
       foreach (var item in Model)
      {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"grid-item filter-design\">\r\n          <article class=\"vlt-work vlt-work--style-2\">\r\n            <div class=\"vlt-work__media\">\r\n              <a class=\"vlt-work__link has-cursor\"");
            BeginWriteAttribute("href", " href=\"", 749, "\"", 780, 1);
#nullable restore
#line 20 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
WriteAttributeValue("", 756, item.SectionRedirectUrl, 756, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></a>\r\n              \r\n");
#nullable restore
#line 22 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
                if (!string.IsNullOrEmpty(item.SectionImageAltText))
                      {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 927, "\"", 951, 1);
#nullable restore
#line 24 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
WriteAttributeValue("", 933, item.SectionImage, 933, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 952, "\"", 983, 1);
#nullable restore
#line 24 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
WriteAttributeValue("", 958, item.SectionImageAltText, 958, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"/>\r\n");
#nullable restore
#line 25 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
                      }
                      else
                      {
                          string filePath = item.SectionImage;
                          string[] fileName = filePath.Split('/');
                          string iamgeName = fileName[^1];
                          int fileExtPos = iamgeName.LastIndexOf(".");
                          if (fileExtPos >= 0)
                          {
                              iamgeName = iamgeName.Substring(0, fileExtPos);
                          }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 1558, "\"", 1582, 1);
#nullable restore
#line 36 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
WriteAttributeValue("", 1564, item.SectionImage, 1564, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1583, "\"", 1599, 1);
#nullable restore
#line 36 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
WriteAttributeValue("", 1589, iamgeName, 1589, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"/>\r\n");
#nullable restore
#line 37 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"vlt-work__meta\">\r\n              <h5 class=\"vlt-work__title\">");
#nullable restore
#line 40 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
                                     Write(item.SectionText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            </div>\r\n          </article>\r\n        </div>\r\n");
#nullable restore
#line 44 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\HomePageDoganlarFurnitureCompanyProfileSection.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n  </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.HomePageDoganlarFurnitureCompanyProfileSection>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
