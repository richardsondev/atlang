namespace AtLangCompiler.ILEmitter;

internal interface IMethodEmitter<T> where T : ASTNode
{
    void EmitIL(T node);
}
