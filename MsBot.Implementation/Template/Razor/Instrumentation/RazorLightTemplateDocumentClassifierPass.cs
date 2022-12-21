using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace MsBot.Implementation.Template.Razor.Instrumentation;

public class RazorLightTemplateDocumentClassifierPass : DocumentClassifierPassBase
{
    public static readonly string RazorLightTemplateDocumentKind = "razorlight.2.0.template";

    protected override string DocumentKind => RazorLightTemplateDocumentKind;

    protected override bool IsMatch(RazorCodeDocument codeDocument, DocumentIntermediateNode documentNode) => true;

    protected override void OnDocumentStructureCreated(
        RazorCodeDocument codeDocument,
        NamespaceDeclarationIntermediateNode @namespace,
        ClassDeclarationIntermediateNode @class,
        MethodDeclarationIntermediateNode method)
    {
        string templateKey = codeDocument.Source.FilePath ?? codeDocument.Source.FilePath;

        base.OnDocumentStructureCreated(codeDocument, @namespace, @class, method);

        @namespace.Content = "MsBot.Implementation.Template.Razor.CompiledTemplates";

        @class.ClassName = "GeneratedTemplate"; //CSharpIdentifier.GetClassNameFromPath(templateKey);
        @class.BaseType = "global::MsBot.Implementation.Template.Razor.TemplatePage<TModel>";
        @class.Modifiers.Clear();
        @class.Modifiers.Add("public");

        method.MethodName = "ExecuteAsync";
        method.Modifiers.Clear();
        method.Modifiers.Add("public");
        method.Modifiers.Add("async");
        method.Modifiers.Add("override");
        method.ReturnType = $"global::{typeof(Task).FullName}";
    }
}
