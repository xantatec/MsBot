using MsBot.Implementation.Template.Razor.Generation;

namespace MsBot.Implementation.Template.Razor.Compilation;

public interface IPrecompileCallback
{
    void Invoke(IGeneratedRazorTemplate generatedRazorTemplate, byte[] rawAssembly, byte[] rawSymbolStore);
}
