#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3cb40978db916537121993bcee577e58d7cd1c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Themes_DoganlarMobilya_Components_SertifikalarSynesgyContent), @"mvc.1.0.view", @"/Views/Themes/DoganlarMobilya/Components/SertifikalarSynesgyContent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3cb40978db916537121993bcee577e58d7cd1c1", @"/Views/Themes/DoganlarMobilya/Components/SertifikalarSynesgyContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07219fb31d10a006c19dc538011cadcead83702", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Themes_DoganlarMobilya_Components_SertifikalarSynesgyContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taigate.Data.Data.Entities.Components.DoganlarMobilya.SertifikalarSynesgyContent>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section>
  <div class=""vlt-gap-120"">
  </div>
  <div class=""container"">
    <div class=""row"">
      <div class=""col-md-12 col-lg-8 offset-lg-2"">
        <article class=""vlt-single-post vlt-single-post--style-1"">
          <header class=""vlt-single-post__header"">
            <h2 class=""vlt-post-title"">");
#nullable restore
#line 11 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
                                  Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </h2>
          </header>
          <div class=""vlt-single-post__content"">
            <div class=""vlt-simple-image alignfull"">
              <div
                   class=""vlt-simple-image__mask""
                   data-aos=""image-mask-animation""
                   data-aos-delay=""0"">
                <div class=""inside"">
                </div>
              </div>
");
#nullable restore
#line 23 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
               if (!string.IsNullOrEmpty(Model.ImagePath))
              {
                if (!string.IsNullOrEmpty(Model.ImageAltText))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                  <img");
            BeginWriteAttribute("src", " src=\"", 989, "\"", 1011, 1);
#nullable restore
#line 27 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
WriteAttributeValue("", 995, Model.ImagePath, 995, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1012, "\"", 1037, 1);
#nullable restore
#line 27 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
WriteAttributeValue("", 1018, Model.ImageAltText, 1018, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"/>\r\n");
#nullable restore
#line 28 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
                }
                else
                {
                  string filePath = Model.ImagePath;
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
            WriteLiteral("                  <img");
            BeginWriteAttribute("src", " src=\"", 1520, "\"", 1542, 1);
#nullable restore
#line 39 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
WriteAttributeValue("", 1526, Model.ImagePath, 1526, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1543, "\"", 1559, 1);
#nullable restore
#line 39 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
WriteAttributeValue("", 1549, iamgeName, 1549, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"/>\r\n");
#nullable restore
#line 40 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Cms\Views\Themes\DoganlarMobilya\Components\SertifikalarSynesgyContent.cshtml"
                }
              }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"vlt-gap-40\">\r\n            </div>\r\n            Raw(Model.Content)\r\n          </div>\r\n          <div class=\"vlt-gap-70\">\r\n          </div>\r\n        </article>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taigate.Data.Data.Entities.Components.DoganlarMobilya.SertifikalarSynesgyContent> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591