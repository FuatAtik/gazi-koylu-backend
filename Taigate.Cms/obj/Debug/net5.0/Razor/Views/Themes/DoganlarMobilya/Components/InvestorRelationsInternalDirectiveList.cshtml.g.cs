#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c56c6d6d13a93519945dffeba34c5053a0abfc06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_InvestorRelationsInternalDirectiveList), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/InvestorRelationsInternalDirectiveList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c56c6d6d13a93519945dffeba34c5053a0abfc06", @"/Views/Themes/DoganlarMobilya/Components/InvestorRelationsInternalDirectiveList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_InvestorRelationsInternalDirectiveList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.InternalDirectiveList>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"invest-detail-first\">\r\n");
#nullable restore
#line 4 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 180, "\"", 339, 10);
            WriteAttributeValue("", 188, "pdf-showhide", 188, 12, true);
#nullable restore
#line 6 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
WriteAttributeValue(" ", 200, item.InternalDirectiveDates.Year, 201, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 234, "row", 235, 4, true);
            WriteAttributeValue(" ", 238, "align-items-center", 239, 19, true);
            WriteAttributeValue(" ", 257, "awards-name", 258, 12, true);
            WriteAttributeValue(" ", 269, "wow", 270, 4, true);
            WriteAttributeValue(" ", 273, "fadeInRight", 274, 12, true);
            WriteAttributeValue(" ", 285, "pdf-block", 286, 10, true);
            WriteAttributeValue(" ", 295, "pdf-block-", 296, 11, true);
#nullable restore
#line 6 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
WriteAttributeValue("", 306, item.InternalDirectiveDates.Year, 306, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-wow-delay=\".2s\">\r\n            <div class=\"col-8\">\r\n                <div class=\"first-text\">");
#nullable restore
#line 8 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
                                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"second-text\">");
#nullable restore
#line 9 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
                                    Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n            <div class=\"col-4 social-media-button\">\r\n                <a class=\"pdf-block vlt-btn vlt-btn--secondary vlt-btn--md\"");
            BeginWriteAttribute("href", " href=\"", 670, "\"", 690, 1);
#nullable restore
#line 12 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
WriteAttributeValue("", 677, item.FileUrl, 677, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_self\">\r\n                    Localized(Yatirimci_Iliskileri_List_Incele_Text)<i class=\"icon-arrow-right\"></i>\r\n                </a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 17 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsInternalDirectiveList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.InternalDirectiveList>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
