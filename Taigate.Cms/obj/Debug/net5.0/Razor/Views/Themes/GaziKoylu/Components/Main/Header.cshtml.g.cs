#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55b1139d358549e6839a3e5f475db1b9312bcecf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_GaziKoylu_Components_Main_Header), @"mvc.1.0.view", @"/Views/Themes/GaziKoylu/Components/Main/Header.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55b1139d358549e6839a3e5f475db1b9312bcecf", @"/Views/Themes/GaziKoylu/Components/Main/Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_GaziKoylu_Components_Main_Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taigate.Data.Data.Entities.Components.GaziKoylu.Header>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<header class=""sticky-on"">
    <div id=""sticky-placeholder""></div>
    <div id=""navbar-wrap"" class=""navbar-wrap"">
        <div class=""navbar-layout1"">
            <div class=""container"">
                <div class=""row no-gutters d-flex align-items-center position-relative"">
                    <div class=""col-lg-2 d-flex justify-content-start"">
                        <div class=""temp-logo text-center"">
                            <a href=""/"" class=""default-logo"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 578, "\"", 600, 1);
#nullable restore
#line 11 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 584, Model.WhiteLogo, 584, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"logo\" class=\"img-fluid\">\r\n                            </a>\r\n                            <a href=\"/\" class=\"sticky-logo\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 765, "\"", 787, 1);
#nullable restore
#line 14 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 771, Model.BlackLogo, 771, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""logo"" class=""img-fluid"">
                            </a>
                        </div>
                    </div>
                    <div class=""col-lg-7 d-flex justify-content-end possition-static"">
                        <nav id=""dropdown"" class=""template-main-menu"">
                            <ul>
                                <li class=""position-static d-none d-lg-block"">
                                    <a");
            BeginWriteAttribute("href", " href=\"", 1226, "\"", 1252, 1);
#nullable restore
#line 22 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 1233, Model.MenuItem1Url, 1233, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
                                                             Write(Model.MenuItem1Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                                <li class=\"d-block d-lg-none\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1421, "\"", 1447, 1);
#nullable restore
#line 25 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 1428, Model.MenuItem1Url, 1428, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 25 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
                                                             Write(Model.MenuItem1Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                                <li>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1590, "\"", 1616, 1);
#nullable restore
#line 28 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 1597, Model.MenuItem2Url, 1597, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <span>");
#nullable restore
#line 29 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
                                         Write(Model.MenuItem2Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </a>\r\n                                </li>\r\n                                <li>\r\n                                    <a href=\"#\">");
#nullable restore
#line 33 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
                                           Write(Model.MenuItem3Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    Component(HeaderMenuServicesList)\r\n                                </li>\r\n                                <li>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2074, "\"", 2100, 1);
#nullable restore
#line 37 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 2081, Model.MenuItem4Url, 2081, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <span>");
#nullable restore
#line 38 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
                                         Write(Model.MenuItem4Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </a>
                                </li>
                            </ul>
                        </nav>
                    </div>

                    <div class=""col-lg-3 d-flex justify-content-end"">
                        <ul class=""header-action-items"">
                            <li class=""single-item"">
                                <a href=""#template-search"" title=""Search"" class=""header-search"">
                                    <i class=""flaticon-search""></i>
                                </a>
                            </li>
                            <li class=""single-item mr-2"">
                                <a");
            BeginWriteAttribute("href", " href=\"", 2873, "\"", 2899, 1);
#nullable restore
#line 53 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
WriteAttributeValue("", 2880, Model.MenuItem5Url, 2880, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"item-btn btn-ghost btn-light\">");
#nullable restore
#line 53 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\GaziKoylu\Components\Main\Header.cshtml"
                                                                                              Write(Model.MenuItem5Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                            </li>
                            <li class=""single-item"">
                                <button type=""button"" class=""offcanvas-menu-btn menu-status-open"">
                                    <span class=""menu-btn-icon"">
                                        <span></span>
                                        <span></span>
                                        <span></span>
                                    </span>
                                </button>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>");
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