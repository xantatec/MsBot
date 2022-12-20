using System.Reflection;

namespace MsBot.Implementation.Template.Razor.Compilation;

public interface IAssemblyPathFormatter
{
    string GetAssemblyPath(Assembly assembly);
}
