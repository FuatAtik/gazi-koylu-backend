#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afecd50afe40d7a35dbd472bfcd045912fa26920"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_InvestorRelationsHero), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/InvestorRelationsHero.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afecd50afe40d7a35dbd472bfcd045912fa26920", @"/Views/Themes/DoganlarMobilya/Components/InvestorRelationsHero.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_InvestorRelationsHero : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taigate.Data.Data.Entities.Components.DoganlarMobilya.InvestorRelationsHero>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"common-hero-area\">\r\n    <div class=\"vlt-gap-80\"></div>\r\n    <div class=\"vlt-page-title vlt-page-title--style-2 jarallax\">\r\n        \r\n");
#nullable restore
#line 7 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
          if (!string.IsNullOrEmpty(Model.HeroImageAltText))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"jarallax-img\"");
            BeginWriteAttribute("src", " src=\"", 357, "\"", 379, 1);
#nullable restore
#line 9 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
WriteAttributeValue("", 363, Model.HeroImage, 363, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 380, "\"", 409, 1);
#nullable restore
#line 9 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
WriteAttributeValue("", 386, Model.HeroImageAltText, 386, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"/>\r\n");
#nullable restore
#line 10 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
                }
                else
                {
                    string filePath = Model.HeroImage;
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
            WriteLiteral("                    <img class=\"jarallax-img\"");
            BeginWriteAttribute("src", " src=\"", 933, "\"", 955, 1);
#nullable restore
#line 21 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
WriteAttributeValue("", 939, Model.HeroImage, 939, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 956, "\"", 972, 1);
#nullable restore
#line 21 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
WriteAttributeValue("", 962, iamgeName, 962, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"/>\r\n");
#nullable restore
#line 22 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"         <div class=""vlt-page-title__overlay""></div>
        <div class=""container"">
            <h1
                class=""vlt-page-title__title lax""
                data-lax-translate-y=""0 0, vh (vw*0.25)""
                data-lax-opacity=""1 1, (vh*0.5) 0""
                data-lax-anchor="".vlt-page-title"">
                ");
#nullable restore
#line 30 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsHero.cshtml"
           Write(Model.HeroTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h1>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taigate.Data.Data.Entities.Components.DoganlarMobilya.InvestorRelationsHero> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
