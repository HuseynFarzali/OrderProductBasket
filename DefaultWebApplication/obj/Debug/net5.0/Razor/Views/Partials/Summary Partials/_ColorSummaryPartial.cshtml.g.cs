#pragma checksum "C:\Users\99450\Desktop\BackEnd_Code_Academy\DefaultWebApplication\DefaultWebApplication\Views\Partials\Summary Partials\_ColorSummaryPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc48307f6caf134e407fc403ff6d0a6d350e77d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DefaultWebApplication.Pages.Partials.Summary_Partials.Views_Partials_Summary_Partials__ColorSummaryPartial), @"mvc.1.0.view", @"/Views/Partials/Summary Partials/_ColorSummaryPartial.cshtml")]
namespace DefaultWebApplication.Pages.Partials.Summary_Partials
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
#line 1 "C:\Users\99450\Desktop\BackEnd_Code_Academy\DefaultWebApplication\DefaultWebApplication\Views\_ViewImports.cshtml"
using DefaultWebApplication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48307f6caf134e407fc403ff6d0a6d350e77d8", @"/Views/Partials/Summary Partials/_ColorSummaryPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77a5d744219efd7fd5f1a09f87b4437a06cb7b7e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Partials_Summary_Partials__ColorSummaryPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.View_Models.Summary_Models.ColorSummaryViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""border border-black border-[2px] px-4 py-2"">
    <div id=""photo-section"" class=""flex justify-center items-center mr-[12px]"">
        <div class=""h-[40px] w-[40px] rounded-full border border-slate-400 bg-[rgb(34,193,195)] bg-[linear-gradient(0deg,_rgba(34,193,195,1)_0%,_rgba(253,187,45,1)_100%)]""></div>
    </div>
    <div id=""info-section"" class=""flex flex-col items-center gap-[10px]"">
        <div id=""upper-subsection"" class=""flex justify-center items-center gap-[12px]"">
            <div id=""product-tag-name"" class=""px-2 py-1 rounded-lg bg-orange-300 text-center"">
                ");
#nullable restore
#line 10 "C:\Users\99450\Desktop\BackEnd_Code_Academy\DefaultWebApplication\DefaultWebApplication\Views\Partials\Summary Partials\_ColorSummaryPartial.cshtml"
           Write(Model.ColorTagName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div id=""details-button"" class=""px-2 py-1 rounded-lg bg-green-300 text-center italic font-semibold"">
                Details
            </div>
        </div>
        <div id=""bottom-subsection"">
            <div class=""px-3 py-2 rounded-lg font-[20px] bg-gray-300 text-center"">
                ");
#nullable restore
#line 18 "C:\Users\99450\Desktop\BackEnd_Code_Academy\DefaultWebApplication\DefaultWebApplication\Views\Partials\Summary Partials\_ColorSummaryPartial.cshtml"
           Write(Model.ColorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"px-2 py-1 rounded-lg font-[14px] bg-sky-300 text-center\">\r\n                ");
#nullable restore
#line 21 "C:\Users\99450\Desktop\BackEnd_Code_Academy\DefaultWebApplication\DefaultWebApplication\Views\Partials\Summary Partials\_ColorSummaryPartial.cshtml"
           Write(Model.ColorRgbCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div id=\"price-section\"");
            BeginWriteAttribute("class", " class=\"", 1260, "\"", 1375, 12);
            WriteAttributeValue("", 1268, "h-full", 1268, 6, true);
            WriteAttributeValue(" ", 1274, "w-full", 1275, 7, true);
            WriteAttributeValue(" ", 1281, "m-2", 1282, 4, true);
            WriteAttributeValue(" ", 1285, "rounded-lg", 1286, 11, true);
            WriteAttributeValue(" ", 1296, "bg-[", 1297, 5, true);
#nullable restore
#line 25 "C:\Users\99450\Desktop\BackEnd_Code_Academy\DefaultWebApplication\DefaultWebApplication\Views\Partials\Summary Partials\_ColorSummaryPartial.cshtml"
WriteAttributeValue("", 1301, Model.ColorRgbCode, 1301, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1320, "]", 1320, 1, true);
            WriteAttributeValue(" ", 1321, "font-light", 1322, 11, true);
            WriteAttributeValue(" ", 1332, "italic", 1333, 7, true);
            WriteAttributeValue(" ", 1339, "text-center", 1340, 12, true);
            WriteAttributeValue(" ", 1351, "tracking-wide", 1352, 14, true);
            WriteAttributeValue(" ", 1365, "underline", 1366, 10, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        Color Visual\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.View_Models.Summary_Models.ColorSummaryViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591