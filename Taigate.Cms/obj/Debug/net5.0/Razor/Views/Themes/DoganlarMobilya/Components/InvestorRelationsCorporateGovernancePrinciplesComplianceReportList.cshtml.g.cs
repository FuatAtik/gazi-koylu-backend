#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56c99c6bac39f05e006c6435e433797eb96f98aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_InvestorRelationsCorporateGovernancePrinciplesComplianceReportList), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56c99c6bac39f05e006c6435e433797eb96f98aa", @"/Views/Themes/DoganlarMobilya/Components/InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_InvestorRelationsCorporateGovernancePrinciplesComplianceReportList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.CorporateGovernancePrinciplesComplianceReportList>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"invest-detail-first\">\r\n");
#nullable restore
#line 4 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 208, "\"", 423, 10);
            WriteAttributeValue("", 216, "pdf-showhide", 216, 12, true);
#nullable restore
#line 6 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
WriteAttributeValue(" ", 228, item.CorporateGovernancePrinciplesComplianceReportDates.Year, 229, 61, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 290, "row", 291, 4, true);
            WriteAttributeValue(" ", 294, "align-items-center", 295, 19, true);
            WriteAttributeValue(" ", 313, "awards-name", 314, 12, true);
            WriteAttributeValue(" ", 325, "wow", 326, 4, true);
            WriteAttributeValue(" ", 329, "fadeInRight", 330, 12, true);
            WriteAttributeValue(" ", 341, "pdf-block", 342, 10, true);
            WriteAttributeValue(" ", 351, "pdf-block-", 352, 11, true);
#nullable restore
#line 6 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
WriteAttributeValue("", 362, item.CorporateGovernancePrinciplesComplianceReportDates.Year, 362, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-wow-delay=\".2s\">\r\n            <div class=\"col-8\">\r\n                <div class=\"first-text\">");
#nullable restore
#line 8 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
                                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"second-text\">");
#nullable restore
#line 9 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
                                    Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n            <div class=\"col-4 social-media-button\">\r\n                <a class=\"pdf-block vlt-btn vlt-btn--secondary vlt-btn--md\"");
            BeginWriteAttribute("href", " href=\"", 754, "\"", 774, 1);
#nullable restore
#line 12 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
WriteAttributeValue("", 761, item.FileUrl, 761, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_self\">\r\n                    Localized(Yatirimci_Iliskileri_List_Incele_Text)<i class=\"icon-arrow-right\"></i>\r\n                </a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 17 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\InvestorRelationsCorporateGovernancePrinciplesComplianceReportList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Taigate.Data.Data.Entities.Components.DoganlarMobilya.CorporateGovernancePrinciplesComplianceReportList>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591