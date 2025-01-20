using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Reflection.Emit;

namespace AtLangCompiler.ILEmitter;

internal static class DIConfiguration
{
    public static IServiceProvider ConfigureServices(ILGenerator il, LocalBuilder dictLocal, ILMethodEmitterManager emitter)
    {
        ServiceCollection serviceCollection = new ServiceCollection();

        // Register shared dependencies
        serviceCollection.AddSingleton(il);
        serviceCollection.AddSingleton(dictLocal);
        serviceCollection.AddSingleton(emitter);

        // Register all emitters dynamically
        IEnumerable<Type> emitterTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.CustomAttributes.Any(e => e.AttributeType == typeof(EmitterForAttribute)));

        foreach (Type? type in emitterTypes)
        {
            serviceCollection.AddTransient(type);
        }

        return serviceCollection.BuildServiceProvider();
    }
}
