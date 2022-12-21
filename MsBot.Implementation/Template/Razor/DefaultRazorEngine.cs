using Microsoft.AspNetCore.Mvc.Razor.Extensions;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using MsBot.Implementation.Template.Razor.Instrumentation;

namespace MsBot.Implementation.Template.Razor;

internal sealed class DefaultRazorEngine
{
    public static RazorEngine Instance
    {
        get
        {
            var configuration = RazorConfiguration.Default;
            var razorProjectEngine = RazorProjectEngine.Create(configuration, new NullRazorProjectFileSystem(), builder =>
           {
               Instrumentation.InjectDirective.Register(builder);
               Instrumentation.ModelDirective.Register(builder);

               //In RazorLanguageVersion > 3.0 (at least netcore 3.0) the directives are registered out of the box.
               if (!RazorLanguageVersion.TryParse("3.0", out var razorLanguageVersion)
                   || configuration.LanguageVersion.CompareTo(razorLanguageVersion) < 0)
               {
                   NamespaceDirective.Register(builder);
                   FunctionsDirective.Register(builder);
                   InheritsDirective.Register(builder);
               }
               SectionDirective.Register(builder);

               builder.Features.Add(new ModelExpressionPass());
               builder.Features.Add(new RazorLightTemplateDocumentClassifierPass());
               builder.Features.Add(new RazorLightAssemblyAttributeInjectionPass());
               //builder.Features.Add(new InstrumentationPass());
               //builder.Features.Add(new ViewComponentTagHelperPass());

               builder.AddTargetExtension(new TemplateTargetExtension
               {
                   TemplateTypeName = "global::MsBot.Implementation.Template.Razor.Razor.RazorLightHelperResult",
               });

               OverrideRuntimeNodeWriterTemplateTypeNamePhase.Register(builder);
           });

            return razorProjectEngine.Engine;
        }
    }

    private class NullRazorProjectFileSystem : RazorProjectFileSystem
    {
        public override IEnumerable<RazorProjectItem> EnumerateItems(string basePath)
        {
            throw new NotImplementedException();
        }


#if (NETCOREAPP3_0 || NETCOREAPP3_1 || NET5_0)
			[System.Obsolete]
#endif
        public override RazorProjectItem GetItem(string path)
        {
            throw new NotImplementedException();
        }

#if (NETCOREAPP3_0_OR_GREATER)
        public override RazorProjectItem GetItem(string path, string fileKind)
        {
            throw new NotImplementedException();
        }
#endif
    }
}