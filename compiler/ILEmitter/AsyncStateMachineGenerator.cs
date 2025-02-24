using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AtLangCompiler.ILEmitter

/// <summary>
/// Generates an asynchronous state machine for handling async requests.
/// </summary>
public class AsyncStateMachineGenerator
{
    private readonly AssemblyBuilder assemblyBuilder;
    private readonly ModuleBuilder moduleBuilder;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncStateMachineGenerator"/> class.
    /// </summary>
    public AsyncStateMachineGenerator()
    {
        AssemblyName assemblyName = new AssemblyName("DynamicAsyncStateMachineAssembly");
        assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicAsyncStateMachineModule");
    }

    /// <summary>
    /// Generates a state machine type that implements <see cref="IAsyncStateMachine"/> for async requests.
    /// The generated state machine invokes a <see cref="Func{Task{int}}"/> delegate to perform the async work.
    /// </summary>
    /// <param name="stateMachineName">The name of the state machine type.</param>
    /// <returns>The generated state machine <see cref="Type"/>.</returns>
    public Type GenerateStateMachine(string stateMachineName)
    {
        if (string.IsNullOrEmpty(stateMachineName))
            throw new ArgumentNullException(nameof(stateMachineName));

        TypeBuilder typeBuilder = moduleBuilder.DefineType(
            stateMachineName,
            TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit,
            typeof(object),
            new Type[] { typeof(IAsyncStateMachine) });

        FieldBuilder stateField = typeBuilder.DefineField("<>1__state", typeof(int), FieldAttributes.Public);
        FieldBuilder builderField = typeBuilder.DefineField("<>t__builder", typeof(AsyncTaskMethodBuilder<int>), FieldAttributes.Public);
        FieldBuilder awaiterField = typeBuilder.DefineField("<>u__1", typeof(TaskAwaiter<int>), FieldAttributes.Private);
        FieldBuilder requestDelegateField = typeBuilder.DefineField("RequestDelegate", typeof(Func<Task<int>>), FieldAttributes.Public);

        MethodBuilder moveNextMethod = typeBuilder.DefineMethod(
            "MoveNext",
            MethodAttributes.Public | MethodAttributes.Virtual,
            typeof(void),
            Type.EmptyTypes);
        ILGenerator il = moveNextMethod.GetILGenerator();

        LocalBuilder resultLocal = il.DeclareLocal(typeof(int));
        LocalBuilder awaiterLocal = il.DeclareLocal(typeof(TaskAwaiter<int>));
        LocalBuilder exceptionLocal = il.DeclareLocal(typeof(Exception));

        Label resumeLabel = il.DefineLabel();
        Label afterLoadAwaiterLabel = il.DefineLabel();
        Label endOfTry = il.DefineLabel();

        il.BeginExceptionBlock();

        // if (this.<>1__state == 0) goto resumeLabel;
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, stateField);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Beq_S, resumeLabel);

        // Initial state: call RequestDelegate.Invoke() and get awaiter.
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, requestDelegateField);
        MethodInfo invokeMethod = typeof(Func<Task<int>>).GetMethod("Invoke")!;
        il.Emit(OpCodes.Callvirt, invokeMethod);
        MethodInfo getAwaiterMethod = typeof(Task<int>).GetMethod("GetAwaiter")!;
        il.Emit(OpCodes.Callvirt, getAwaiterMethod);
        il.Emit(OpCodes.Stloc, awaiterLocal);

        // if (!awaiter.IsCompleted) { schedule continuation }
        il.Emit(OpCodes.Ldloca_S, awaiterLocal);
        MethodInfo getIsCompletedMethod = typeof(TaskAwaiter<int>).GetProperty("IsCompleted")!.GetGetMethod()!;
        il.Emit(OpCodes.Call, getIsCompletedMethod);
        Label continueLabel = il.DefineLabel();
        il.Emit(OpCodes.Brtrue_S, continueLabel);

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Stfld, stateField);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldloc, awaiterLocal);
        il.Emit(OpCodes.Stfld, awaiterField);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, builderField);
        il.Emit(OpCodes.Ldloca_S, awaiterLocal);
        il.Emit(OpCodes.Ldarg_0);
        MethodInfo awaitUnsafeOnCompletedMethod = typeof(AsyncTaskMethodBuilder<int>)
            .GetMethod("AwaitUnsafeOnCompleted")!
            .MakeGenericMethod(typeof(TaskAwaiter<int>), typeBuilder);
        il.Emit(OpCodes.Call, awaitUnsafeOnCompletedMethod);
        il.Emit(OpCodes.Leave_S, resumeLabel);

        il.MarkLabel(continueLabel);
        il.MarkLabel(resumeLabel);

        // Resume state: if state == 0, load awaiter from field and reset state.
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, stateField);
        il.Emit(OpCodes.Brtrue_S, afterLoadAwaiterLabel);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, awaiterField);
        il.Emit(OpCodes.Stloc, awaiterLocal);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldc_I4_M1);
        il.Emit(OpCodes.Stfld, stateField);
        il.MarkLabel(afterLoadAwaiterLabel);

        // Get result from awaiter.
        il.Emit(OpCodes.Ldloca_S, awaiterLocal);
        MethodInfo getResultMethod = typeof(TaskAwaiter<int>).GetMethod("GetResult")!;
        il.Emit(OpCodes.Call, getResultMethod);
        il.Emit(OpCodes.Stloc, resultLocal);

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldc_I4_M1);
        il.Emit(OpCodes.Stfld, stateField);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, builderField);
        il.Emit(OpCodes.Ldloc, resultLocal);
        MethodInfo setResultMethod = typeof(AsyncTaskMethodBuilder<int>).GetMethod("SetResult")!;
        il.Emit(OpCodes.Call, setResultMethod);
        il.Emit(OpCodes.Leave_S, endOfTry);

        il.BeginCatchBlock(typeof(Exception));
        il.Emit(OpCodes.Stloc, exceptionLocal);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldc_I4_M1);
        il.Emit(OpCodes.Stfld, stateField);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, builderField);
        il.Emit(OpCodes.Ldloc, exceptionLocal);
        MethodInfo setExceptionMethod = typeof(AsyncTaskMethodBuilder<int>).GetMethod("SetException")!;
        il.Emit(OpCodes.Call, setExceptionMethod);
        il.Emit(OpCodes.Leave_S, endOfTry);
        il.EndExceptionBlock();

        il.MarkLabel(endOfTry);
        il.Emit(OpCodes.Ret);

        typeBuilder.DefineMethodOverride(moveNextMethod, typeof(IAsyncStateMachine).GetMethod("MoveNext")!);

        MethodBuilder setStateMachineMethod = typeBuilder.DefineMethod(
            "SetStateMachine",
            MethodAttributes.Public | MethodAttributes.Virtual,
            typeof(void),
            new Type[] { typeof(IAsyncStateMachine) });
        ILGenerator setStateIL = setStateMachineMethod.GetILGenerator();
        setStateIL.Emit(OpCodes.Ldarg_0);
        setStateIL.Emit(OpCodes.Ldarg_1);
        MethodInfo setStateMachineMI = typeof(AsyncTaskMethodBuilder<int>).GetMethod("SetStateMachine")!;
        setStateIL.Emit(OpCodes.Call, setStateMachineMI);
        setStateIL.Emit(OpCodes.Ret);
        typeBuilder.DefineMethodOverride(setStateMachineMethod, typeof(IAsyncStateMachine).GetMethod("SetStateMachine")!);

        return typeBuilder.CreateType()!;
    }
}
