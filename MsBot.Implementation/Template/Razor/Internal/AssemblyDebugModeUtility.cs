using System.Diagnostics;
using System.Reflection;

namespace MsBot.Implementation.Template.Razor.Internal;

internal class AssemblyDebugModeUtility
{
    internal static bool IsAssemblyDebugBuild(Assembly assembly)
    {
        return assembly.GetCustomAttributes(false).OfType<DebuggableAttribute>().Any(da => da.IsJITTrackingEnabled);
    }
}
