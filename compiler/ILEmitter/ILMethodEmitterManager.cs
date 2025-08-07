using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace AtLangCompiler.ILEmitter;

internal class ILMethodEmitterManager
{
    private readonly MethodEmitterFactory factory;
    private readonly ILGenerator il;
    private readonly Dictionary<string, LocalBuilder> locals = new();

    public ILMethodEmitterManager(ILGenerator il)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));

        IServiceProvider serviceProvider = DIConfiguration.ConfigureServices(il, this);
        this.factory = new MethodEmitterFactory(serviceProvider);
    }

    internal LocalBuilder GetOrDeclareLocal(string name, Type type)
    {
        if (!locals.TryGetValue(name, out LocalBuilder? local))
        {
            local = il.DeclareLocal(type);
            locals[name] = local;
        }

        return local;
    }

    internal LocalBuilder GetLocal(string name)
    {
        if (!locals.TryGetValue(name, out LocalBuilder? local))
        {
            throw new InvalidOperationException($"Variable '{name}' used before assignment.");
        }

        return local;
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
    }
}
