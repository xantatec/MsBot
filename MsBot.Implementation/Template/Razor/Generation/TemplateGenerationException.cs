using Microsoft.AspNetCore.Razor.Language;

namespace MsBot.Implementation.Template.Razor.Generation;

public class TemplateGenerationException : RazorLightException
{
    public TemplateGenerationException(string message, IReadOnlyList<RazorDiagnostic> diagnostic) : base(message)
    {
        Diagnostics = diagnostic;
    }

    public IReadOnlyList<RazorDiagnostic> Diagnostics { get; set; }
}
