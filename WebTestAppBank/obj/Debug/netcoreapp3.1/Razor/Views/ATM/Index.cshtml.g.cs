#pragma checksum "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "793adf12fcf4f4fbd9768388a7c5a58e3afbf74f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ATM_Index), @"mvc.1.0.view", @"/Views/ATM/Index.cshtml")]
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
#line 1 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\_ViewImports.cshtml"
using WebTestAppBank;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\_ViewImports.cshtml"
using WebTestAppBank.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"793adf12fcf4f4fbd9768388a7c5a58e3afbf74f", @"/Views/ATM/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50317268e709af3a1449e805bb035d566d334d56", @"/Views/_ViewImports.cshtml")]
    public class Views_ATM_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div>\r\n        <div class=\"text-center\">\r\n            <h1 class=\"display-4\">Welcome To ATM</h1>\r\n        </div>\r\n        <div>\r\n");
#nullable restore
#line 10 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
             using (Html.BeginForm("Cassets", "ATM", FormMethod.Post))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\r\n                <p>Enter value of cassets.</p>\r\n                <select id=\"valCassets\" name=\"valCassets\">\r\n");
#nullable restore
#line 15 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
                     for (int i = 1; i <= 8; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "793adf12fcf4f4fbd9768388a7c5a58e3afbf74f4135", async() => {
#nullable restore
#line 17 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
                                  Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
                       WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n            </div>\r\n            <br />\r\n            <div>\r\n                <p>\r\n                    <input type=\"submit\" value=\"Create\" />\r\n                </p>\r\n            </div>\r\n");
#nullable restore
#line 27 "C:\Users\lenovo\source\repos\WebTestAppBank\WebTestAppBank\Views\ATM\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591