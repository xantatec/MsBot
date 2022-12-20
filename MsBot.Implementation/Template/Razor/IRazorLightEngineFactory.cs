using System.Reflection;

namespace MsBot.Implementation.Template.Razor;

public interface IRazorLightEngineFactory
{
    IRazorLightEngine Create(Assembly operatingAssembly = null, string fileSystemProjectRoot = null);
}
