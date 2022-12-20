using Microsoft.AspNetCore.Razor.Language;
using MsBot.Implementation.Template.Razor.Razor;

namespace MsBot.Implementation.Template.Razor.Generation;

public class GeneratedRazorTemplate : IGeneratedRazorTemplate
{
    public GeneratedRazorTemplate(RazorLightProjectItem projectItem, RazorCSharpDocument cSharpDocument)
    {
        if (projectItem == null)
        {
            throw new ArgumentNullException(nameof(projectItem));
        }

        if (cSharpDocument == null)
        {
            throw new ArgumentNullException(nameof(cSharpDocument));
        }

        ProjectItem = projectItem;
        CSharpDocument = cSharpDocument;
    }

    public RazorLightProjectItem ProjectItem { get; set; }

    public string TemplateKey => ProjectItem.Key;

    public RazorCSharpDocument CSharpDocument { get; set; }

    public string GeneratedCode => CSharpDocument.GeneratedCode;
}
