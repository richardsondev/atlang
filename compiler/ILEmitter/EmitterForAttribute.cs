namespace AtLangCompiler.ILEmitter;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class EmitterForAttribute : Attribute
{
    public Type NodeType { get; }

    public EmitterForAttribute(Type nodeType)
    {
        this.NodeType = nodeType ?? throw new ArgumentNullException(nameof(nodeType));
    }
}
