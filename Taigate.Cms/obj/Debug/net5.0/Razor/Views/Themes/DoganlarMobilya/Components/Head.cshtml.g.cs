#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\Head.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b054e702e4bb7b54852f79760165fa0a742787f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_Head), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/Head.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b054e702e4bb7b54852f79760165fa0a742787f7", @"/Views/Themes/DoganlarMobilya/Components/Head.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_Head : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taigate.Data.Data.Entities.UrlRecord>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\Head.cshtml"
 if (!string.IsNullOrEmpty(Model.SeoTitle))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <title>");
#nullable restore
#line 5 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\Head.cshtml"
        Write(Model.SeoTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</title>\r\n");
#nullable restore
#line 6 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\Head.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <title>Doğanlar Mobilya</title>\r\n");
#nullable restore
#line 10 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\Head.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<meta charset=""utf-8"" />
<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
<meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"" />

<script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
<script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
<script src=""//cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<!-- Favicons -->
<link rel=""apple-touch-icon"" sizes=""180x180"" href=""/themes/doganlarmobilya/assets/img/favicon/apple-touch-icon.png"" />
<link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/themes/doganlarmobilya/assets/img/favicon/favicon-32x32.png"" />
<link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/themes/doganlarmobilya/assets/img/favicon/favicon-16x16.png"" />
<link rel=""manifest"" href=""/themes/doganlarmobilya/assets/img/favicon/site.webmanifest"" />
<meta name=""msapplication-TileColor"" content=""#da532c"" />
<meta name=""theme-color"" content=""#ffffff"" />

<!--Framework-->
<lin");
            WriteLiteral(@"k rel=""stylesheet"" href=""/themes/doganlarmobilya/assets/css/framework/bootstrap.min.css"" />
<!--Fonts-->
<link rel=""stylesheet"" href=""/themes/doganlarmobilya/assets/fonts/Swansea/style.css"" />
<link rel=""stylesheet"" href=""/themes/doganlarmobilya/assets/fonts/Skape/style.css"" />
<link rel=""stylesheet"" href=""/themes/doganlarmobilya/assets/fonts/Socicons/socicon.css"" />
<!--Plugins-->
<link rel=""stylesheet"" href=""/themes/doganlarmobilya/assets/css/vlt-plugins.min.css"" />
<!--Style-->
<link rel=""stylesheet"" href=""/themes/doganlarmobilya/assets/css/style.css"" />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taigate.Data.Data.Entities.UrlRecord> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
