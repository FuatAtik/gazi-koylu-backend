#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b88ad1a7f04956cd60161ed2fd2fbcfdbe8ebfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_DoganlarFurnitureFollowUsSection), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/DoganlarFurnitureFollowUsSection.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b88ad1a7f04956cd60161ed2fd2fbcfdbe8ebfd", @"/Views/Themes/DoganlarMobilya/Components/DoganlarFurnitureFollowUsSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_DoganlarFurnitureFollowUsSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.DoganlarFurnitureFollowUsSection>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section class=""social-media-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xl-11 offset-xl-1 col-lg-12"">
                <div class=""vlt-animated-block"" data-aos=""fade"" data-aos-delay=""0"">
                    <h2 class=""contact-page-title"">Localized(Bizi_Takip_Edin_Main_Title)</h2>
                </div>
                <div class=""vlt-gap-60""></div>
                <div class=""vlt-animated-block"" data-aos=""fade"" data-aos-delay=""100"">
                    <div class=""social-media-wrapper"">
");
#nullable restore
#line 13 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"item\">\r\n                                <div class=\"text-area\">\r\n                                    <span>");
#nullable restore
#line 17 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml"
                                     Write(item.SocialMediaName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <span>");
#nullable restore
#line 18 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml"
                                     Write(item.SocialMediaPath);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                                <a class=\"vlt-btn vlt-btn--primary vlt-btn--md\"");
            BeginWriteAttribute("href", " href=\"", 1099, "\"", 1123, 1);
#nullable restore
#line 20 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml"
WriteAttributeValue("", 1106, item.RedirectUrl, 1106, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_self\">\r\n                                    <i");
            BeginWriteAttribute("class", " class=\"", 1180, "\"", 1216, 2);
            WriteAttributeValue("", 1188, "socicon-", 1188, 8, true);
#nullable restore
#line 21 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml"
WriteAttributeValue("", 1196, item.SocialMediaTag, 1196, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                    <i class=\"icon-arrow-right\"></i>\r\n                                </a>\r\n                            </div>\r\n");
#nullable restore
#line 25 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\DoganlarFurnitureFollowUsSection.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.DoganlarFurnitureFollowUsSection>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591