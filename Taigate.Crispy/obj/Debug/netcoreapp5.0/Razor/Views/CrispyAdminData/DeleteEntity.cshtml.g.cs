#pragma checksum "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a90f8430c0409199e4c497607559beb7ca414dda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CrispyAdminData_DeleteEntity), @"mvc.1.0.view", @"/Views/CrispyAdminData/DeleteEntity.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a90f8430c0409199e4c497607559beb7ca414dda", @"/Views/CrispyAdminData/DeleteEntity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_CrispyAdminData_DeleteEntity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taigate.Crispy.ViewModels.DataDeleteViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
  
    ViewData["Titlex"] = Model.DbSetName;
    Layout = "_CrispyAdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"display-4\">Are you sure you want to delete this?</h1>\r\n\r\n<div class=\"row my-3\">\r\n    <div class=\"col-lg-12\">\r\n        ");
#nullable restore
#line 12 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
   Write(Html.DisplayFor(m => m.Object));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 17 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
 using (Html.BeginForm("DeleteEntityPost", "CrispyAdminData", new {}, FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
Write(Html.HiddenFor(m => m.DbSetName));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Yes, delete it</button>\r\n");
#nullable restore
#line 24 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
Write(Html.ActionLink("No, go back", "Index", new {Id = Model.DbSetName}));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\_LoveProject\gazi-koylu-back-end\taigateonline\Taigate.Crispy\Views\CrispyAdminData\DeleteEntity.cshtml"
                                                                        
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taigate.Crispy.ViewModels.DataDeleteViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
