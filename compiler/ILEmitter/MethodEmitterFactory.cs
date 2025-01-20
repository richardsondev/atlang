using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AtLangCompiler.ILEmitter;

internal class MethodEmitterFactory
{
    private readonly IServiceProvider serviceProvider;
    private readonly IDictionary<Type, Type> nodeEmitterMap;

    public MethodEmitterFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        this.nodeEmitterMap = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.CustomAttributes.Any(e => e.AttributeType == typeof(EmitterForAttribute)))
            .SelectMany(t => t.GetCustomAttributes<EmitterForAttribute>().Select(q => KeyValuePair.Create(q.NodeType, t)))
            .ToDictionary(t => t.Key, t => t.Value);
    }

    public object CreateEmitter(ASTNode node)
    {
        _ = node ?? throw new ArgumentNullException(nameof(node));

        // Find the emitter type based on the runtime type of the node
        if (!nodeEmitterMap.TryGetValue(node.GetType(), out Type? emitterType))
        {
            throw new InvalidOperationException($"No emitter found for node type {node.GetType().Name}");
        }

        // Resolve the emitter from the service provider
        object emitter = serviceProvider.GetRequiredService(emitterType);

        // Ensure the resolved emitter implements the correct generic interface
        Type methodEmitterType = typeof(IMethodEmitter<>).MakeGenericType(node.GetType());
        if (!methodEmitterType.IsAssignableFrom(emitter.GetType()) && !typeof(IMethodEmitter<ASTNode>).IsAssignableFrom(emitter.GetType()))
        {
            throw new InvalidOperationException($"Emitter of type {emitterType.Name} does not implement {methodEmitterType.Name} or {typeof(IMethodEmitter<ASTNode>).Name}");
        }

        return emitter;
    }
}
