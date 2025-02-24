namespace AtLangCompiler;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public sealed class RequiredAssemblyAttribute : Attribute
{
    public string RequiredAssembly { get; }

    public RequiredAssemblyAttribute(string requiredAssembly)
    {
        this.RequiredAssembly = requiredAssembly ?? throw new ArgumentNullException(nameof(requiredAssembly));
    }
}
