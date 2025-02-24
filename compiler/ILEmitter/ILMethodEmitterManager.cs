using System.Reflection;
using System.Reflection.Emit;

namespace AtLangCompiler.ILEmitter;

internal class ILMethodEmitterManager
{
    private readonly MethodEmitterFactory factory;
    private readonly ILGenerator il;
    private readonly HashSet<string> requiredAssemblies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public ILMethodEmitterManager(ILGenerator il, LocalBuilder dictLocal)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        _ = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));

        IServiceProvider serviceProvider = DIConfiguration.ConfigureServices(il, dictLocal, this);
        this.factory = new MethodEmitterFactory(serviceProvider);
    }

    public IReadOnlyCollection<string> GetRequiredAssemblies()
    {
        return this.requiredAssemblies;
    }

    internal void EmitStatement(ASTNode node)
    {
        object emitter = factory.CreateEmitter(node);
        Type nodeType = node.GetType();

        Type emitterType = typeof(IMethodEmitter<>).MakeGenericType(nodeType);

        if (typeof(IMethodEmitter<ASTNode>).IsAssignableFrom(emitter.GetType()))
        {
            emitterType = typeof(IMethodEmitter<ASTNode>);
        }

        MethodInfo emitMethod = emitterType.GetMethod(nameof(IMethodEmitter<ASTNode>.EmitIL))!;

        emitMethod.Invoke(emitter, [node]);

        // Capture required assemblies for the generated non-self-contained binary
        var emitterRequiredAssemblies = emitter.GetType()
            .GetCustomAttributes(typeof(RequiredAssemblyAttribute), inherit: true)
            .OfType<RequiredAssemblyAttribute>()
            .Select(attr => attr.RequiredAssembly)
            .ToList();
        requiredAssemblies.UnionWith(emitterRequiredAssemblies);
    }
}
