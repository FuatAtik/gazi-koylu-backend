#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "795a7d8f9d79c57f60a140dafeb197be3693de38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_GaziKoylu_Components_Main_FooterMenuList), @"mvc.1.0.view", @"/Views/Themes/GaziKoylu/Components/Main/FooterMenuList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"795a7d8f9d79c57f60a140dafeb197be3693de38", @"/Views/Themes/GaziKoylu/Components/Main/FooterMenuList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_GaziKoylu_Components_Main_FooterMenuList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taigate.Data.Data.Entities.Components.GaziKoylu.Header>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul class=\"footer-menu\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 111, "\"", 137, 1);
#nullable restore
#line 5 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml"
WriteAttributeValue("", 118, Model.MenuItem2Url, 118, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 5 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml"
                                 Write(Model.MenuItem2Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </li>\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 196, "\"", 222, 1);
#nullable restore
#line 8 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml"
WriteAttributeValue("", 203, Model.MenuItem3Url, 203, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 8 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml"
                                 Write(Model.MenuItem3Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </li>\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 281, "\"", 307, 1);
#nullable restore
#line 11 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml"
WriteAttributeValue("", 288, Model.MenuItem4Url, 288, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\FooterMenuList.cshtml"
                                 Write(Model.MenuItem4Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </li>\r\n</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taigate.Data.Data.Entities.Components.GaziKoylu.Header> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
