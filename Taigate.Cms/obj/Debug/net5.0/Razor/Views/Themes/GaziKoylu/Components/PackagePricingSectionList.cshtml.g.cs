#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37591068b42042f9ac9131c598a28c396be85fba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_GaziKoylu_Components_PackagePricingSectionList), @"mvc.1.0.view", @"/Views/Themes/GaziKoylu/Components/PackagePricingSectionList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37591068b42042f9ac9131c598a28c396be85fba", @"/Views/Themes/GaziKoylu/Components/PackagePricingSectionList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_GaziKoylu_Components_PackagePricingSectionList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.GaziKoylu.PackagePricingSectionList>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-lg-3 col-sm-6 col-12\">\r\n        <div class=\"pricing-box-layout2\">\r\n");
#nullable restore
#line 7 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
             if (item.IsPopular)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"status-shape\">\r\n                    <span class=\"status-text\">Popüler</span>\r\n                </div>\r\n");
#nullable restore
#line 12 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"item-price\"><span class=\"currency\">₺</span>");
#nullable restore
#line 13 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
                                                              Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <h3 class=\"item-title\">");
#nullable restore
#line 14 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <ul class=\"block-list\">\r\n               Raw(item.Description)\r\n            </ul>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 651, "\"", 675, 1);
#nullable restore
#line 18 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
WriteAttributeValue("", 658, item.RedirectUrl, 658, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"item-btn btn-ghost\">Teklif Al</a>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 21 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\PackagePricingSectionList.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.GaziKoylu.PackagePricingSectionList>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591