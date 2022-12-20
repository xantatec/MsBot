using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using MsBot.Implementation.Template.Razor.Generation;
using System.Reflection;

namespace MsBot.Implementation.Template.Razor.Compilation;

public interface ICompilationService
{
    CSharpCompilationOptions CSharpCompilationOptions { get; }
    EmitOptions EmitOptions { get; }
    CSharpParseOptions ParseOptions { get; }
    Assembly OperatingAssembly { get; }

    Assembly CompileAndEmit(IGeneratedRazorTemplate razorTemplate);
}