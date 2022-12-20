namespace MsBot.Implementation.Template.Razor.Compilation;

public interface ITemplateFactoryProvider
{
    Func<ITemplatePage> CreateFactory(CompiledTemplateDescriptor templateDescriptor);
}