using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MsBot.Implementation.Template.Razor.Caching;
using MsBot.Implementation.Template.Razor.Compilation;
using MsBot.Implementation.Template.Razor.DependencyInjection;
using MsBot.Implementation.Template.Razor.Generation;
using RazorLight.Compilation;
using System.Reflection;

namespace MsBot.Implementation.Template.Razor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRazorLight(this IServiceCollection services, Func<IRazorLightEngine> engineFactoryProvider)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (engineFactoryProvider == null)
        {
            throw new ArgumentNullException(nameof(engineFactoryProvider));
        }

        services.AddSingleton<PropertyInjector>();
        services.TryAddSingleton<IEngineHandler>(p =>
            throw new InvalidOperationException($"This exception can only occur if you inject {nameof(IEngineHandler)} directly using {nameof(ServiceCollectionExtensions)}.{nameof(AddRazorLight)}"));
        services.TryAddSingleton(p =>
        {
            var engine = engineFactoryProvider();
            AddEngineRenderCallbacks(engine, p);

            return engine;
        });

        return services;
    }

    public static RazorLightDependencyBuilder AddRazorLight(this IServiceCollection services)
    {
        services = services ?? throw new ArgumentNullException(nameof(services));
        services.AddOptions().Configure<RazorLightOptions>(options =>
        {
            options.OperatingAssembly = options.OperatingAssembly ?? Assembly.GetEntryAssembly();
        });
        services.TryAddSingleton<PropertyInjector>();
        services.TryAddSingleton<ICachingProvider, MemoryCachingProvider>();
        services.TryAddSingleton(DefaultRazorEngine.Instance);
        services.TryAddSingleton<RazorSourceGenerator>();
        services.TryAddSingleton<IRazorTemplateCompiler, RazorTemplateCompiler>();
        services.TryAddSingleton<ITemplateFactoryProvider, TemplateFactoryProvider>();
        services.TryAddSingleton<IMetadataReferenceManager, DefaultMetadataReferenceManager>();
        services.TryAddSingleton<ICompilationService, RoslynCompilationService>();


        services.TryAddSingleton<IEngineHandler, EngineHandler>();
        services.TryAddSingleton<IRazorLightEngine, RazorLightEngine>();

        RazorLightDependencyBuilder builder = new RazorLightDependencyBuilder(services);

        return builder;
    }

    private static void AddEngineRenderCallbacks(IRazorLightEngine engine, IServiceProvider services)
    {
        var injector = services.GetRequiredService<PropertyInjector>();

        engine.Options.PreRenderCallbacks.Add(template => injector.Inject(template));
    }
}
