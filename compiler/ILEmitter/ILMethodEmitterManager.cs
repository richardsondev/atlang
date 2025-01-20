using System.Reflection;
using System.Reflection.Emit;

namespace AtLangCompiler.ILEmitter;

internal class ILMethodEmitterManager
{
    private readonly MethodEmitterFactory factory;
    private readonly ILGenerator il;

    public ILMethodEmitterManager(ILGenerator il, LocalBuilder dictLocal)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        _ = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));

        IServiceProvider serviceProvider = DIConfiguration.ConfigureServices(il, dictLocal, this);
        this.factory = new MethodEmitterFactory(serviceProvider);
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
