using System.Reflection;

namespace MsBot.Implementation.Template.Razor.Compilation;

public class LegacyFixAssemblyPathFormatter : IAssemblyPathFormatter
{
    public string GetAssemblyPath(Assembly assembly)
    {
        string codeBase = assembly.CodeBase;
        UriBuilder uriBuilder = new UriBuilder(codeBase);
        string assemblyDirectory = Uri.UnescapeDataString(uriBuilder.Path + uriBuilder.Fragment);
        return assemblyDirectory;
    }
}
