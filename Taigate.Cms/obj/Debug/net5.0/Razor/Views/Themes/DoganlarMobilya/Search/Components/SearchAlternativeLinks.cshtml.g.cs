#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4243d304be14d5c16808afcd2dfaf41fa9e8d14c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Search_Components_SearchAlternativeLinks), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Search/Components/SearchAlternativeLinks.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4243d304be14d5c16808afcd2dfaf41fa9e8d14c", @"/Views/Themes/DoganlarMobilya/Search/Components/SearchAlternativeLinks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Search_Components_SearchAlternativeLinks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.SearchAlternativeLinks>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
  
    var counter = 0;
    var delimeterCount = Model.Count -1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Localized(SearchResults_Sonuc_Bulunamadi_Text)</h2>
<div class=""featured-search-terms"">
    <ul class=""featured-search-terms-list"">
        <li class=""featured-search-terms-title search-head-text"">
            <span class=""title"">Localized(SearchResults_EnCokAranan_Text) : </span>
        </li>
");
#nullable restore
#line 13 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"featured-search-terms-item\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 590, "\"", 606, 1);
#nullable restore
#line 16 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
WriteAttributeValue("", 597, item.Url, 597, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"term\">");
#nullable restore
#line 16 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
                                            Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 17 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
                 if (delimeterCount > counter)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"delimeter\">,</span>\r\n");
#nullable restore
#line 20 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
                    counter++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </li>\r\n");
#nullable restore
#line 23 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Search\Components\SearchAlternativeLinks.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n      \r\n    </ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.SearchAlternativeLinks>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
