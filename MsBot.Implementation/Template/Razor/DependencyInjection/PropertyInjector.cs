﻿using Microsoft.Extensions.DependencyInjection;
using MsBot.Implementation.Template.Razor.Internal;
using System.Collections.Concurrent;
using System.Reflection;

namespace MsBot.Implementation.Template.Razor.DependencyInjection;

public class PropertyInjector
{
    private readonly IServiceProvider services;
    private readonly ConcurrentDictionary<PropertyInfo, FastPropertySetter> _propertyCache;

    public PropertyInjector(IServiceProvider services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        this.services = services;
        _propertyCache = new ConcurrentDictionary<PropertyInfo, FastPropertySetter>();
    }

    public void Inject(ITemplatePage page)
    {
        if (page == null)
        {
            throw new ArgumentNullException(nameof(page));
        }

        PropertyInfo[] properties = page.GetType().GetRuntimeProperties()
           .Where(p =>
           {
               return
                   p.IsDefined(typeof(RazorInjectAttribute)) &&
                   p.GetIndexParameters().Length == 0 &&
                   !p.SetMethod.IsStatic;
           }).ToArray();

        var scopeFactory = services.GetRequiredService<IServiceScopeFactory>();

        using (IServiceScope scope = scopeFactory.CreateScope())
        {
            IServiceProvider scopeServices = scope.ServiceProvider;

            foreach (var property in properties)
            {
                Type memberType = property.PropertyType;
                object instance = scopeServices.GetRequiredService(memberType);

                FastPropertySetter setter = _propertyCache.GetOrAdd(property, new FastPropertySetter(property));
                setter.SetValue(page, instance);
            }
        }
    }
}
