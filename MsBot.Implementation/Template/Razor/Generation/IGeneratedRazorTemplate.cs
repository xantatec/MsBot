using MsBot.Implementation.Template.Razor.Razor;

namespace MsBot.Implementation.Template.Razor.Generation;

public interface IGeneratedRazorTemplate
{
    string TemplateKey { get; }

    string GeneratedCode { get; }

    RazorLightProjectItem ProjectItem { get; set; }
}