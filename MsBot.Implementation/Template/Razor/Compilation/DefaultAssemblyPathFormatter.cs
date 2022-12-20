using System.Reflection;

namespace MsBot.Implementation.Template.Razor.Compilation;

public class DefaultAssemblyPathFormatter : IAssemblyPathFormatter
{
    public string GetAssemblyPath(Assembly assembly) => assembly.Location;
}
