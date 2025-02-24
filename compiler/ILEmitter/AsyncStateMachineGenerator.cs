using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AtLangCompiler.ILEmitter
{
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
        /// Generates a state machine type that implements <see cref="IAsyncStateMachine"/> for asynchronous requests.
        /// </summary>
        /// <param name="stateMachineName">The name of the state machine type to create.</param>
        /// <returns>A <see cref="Type"/> representing the generated state machine.</returns>
        public Type GenerateStateMachine(string stateMachineName)
        {
            if (string.IsNullOrEmpty(stateMachineName))
            {
                throw new ArgumentNullException(nameof(stateMachineName));
            }

            // Define a new public sealed type that implements IAsyncStateMachine.
            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                stateMachineName,
                TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit,
                typeof(object),
                new Type[] { typeof(IAsyncStateMachine) });

            // Define a public field to hold the state.
            FieldBuilder stateField = typeBuilder.DefineField("<>1__state", typeof(int), FieldAttributes.Public);

            // Define a public field for the AsyncTaskMethodBuilder.
            FieldBuilder builderField = typeBuilder.DefineField("<>t__builder", typeof(AsyncTaskMethodBuilder), FieldAttributes.Public);

            // Define a private field for a TaskAwaiter used in async operations.
            FieldBuilder awaiterField = typeBuilder.DefineField("<>u__1", typeof(TaskAwaiter), FieldAttributes.Private);

            // Define the MoveNext method required by IAsyncStateMachine.
            MethodBuilder moveNextMethod = typeBuilder.DefineMethod(
                "MoveNext",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(void),
                Type.EmptyTypes);
            ILGenerator il = moveNextMethod.GetILGenerator();

            // Begin state machine logic.
            // if (this.<>1__state != 0) goto resumeLabel;
            Label resumeLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, stateField);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Bne_Un_S, resumeLabel);

            // Initial state logic: simulate asynchronous work.
            // For demonstration purposes, load a dummy exit code value (e.g., 42).
            il.Emit(OpCodes.Ldc_I4, 42);
            LocalBuilder resultLocal = il.DeclareLocal(typeof(int));
            il.Emit(OpCodes.Stloc, resultLocal);

            // Set state to -1 to indicate completion.
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_M1);
            il.Emit(OpCodes.Stfld, stateField);

            // Signal completion by calling AsyncTaskMethodBuilder.SetResult.
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, builderField);
            MethodInfo setResultMethod = typeof(AsyncTaskMethodBuilder).GetMethod("SetResult")!;
            il.Emit(OpCodes.Call, setResultMethod);
            il.Emit(OpCodes.Br_S, resumeLabel);

            // Resume label for continuation (if any).
            il.MarkLabel(resumeLabel);
            il.Emit(OpCodes.Ret);

            // Implement IAsyncStateMachine.MoveNext.
            typeBuilder.DefineMethodOverride(moveNextMethod, typeof(IAsyncStateMachine).GetMethod("MoveNext")!);

            // Define the SetStateMachine method required by IAsyncStateMachine.
            MethodBuilder setStateMachineMethod = typeBuilder.DefineMethod(
                "SetStateMachine",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(void),
                new Type[] { typeof(IAsyncStateMachine) });
            ILGenerator setStateIL = setStateMachineMethod.GetILGenerator();
            // Call builder.SetStateMachine(this);
            setStateIL.Emit(OpCodes.Ldarg_0);
            setStateIL.Emit(OpCodes.Ldarg_1);
            MethodInfo setStateMachineMI = typeof(AsyncTaskMethodBuilder).GetMethod("SetStateMachine")!;
            setStateIL.Emit(OpCodes.Call, setStateMachineMI);
            setStateIL.Emit(OpCodes.Ret);

            // Implement IAsyncStateMachine.SetStateMachine.
            typeBuilder.DefineMethodOverride(setStateMachineMethod, typeof(IAsyncStateMachine).GetMethod("SetStateMachine")!);

            // Create and return the generated type.
            return typeBuilder.CreateType()!;
        }
    }
}
