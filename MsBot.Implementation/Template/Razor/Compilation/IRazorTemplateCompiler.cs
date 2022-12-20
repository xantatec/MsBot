namespace MsBot.Implementation.Template.Razor.Compilation;

public interface IRazorTemplateCompiler
{
    ICompilationService CompilationService { get; }

    Task<CompiledTemplateDescriptor> CompileAsync(string templateKey);
}