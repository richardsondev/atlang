# Agent Guide

## AtLang overview
- AtLang is a WIP, CIL-based learning language with a terse `@`-prefixed syntax. Single `.at` files can spin up HTTP servers, perform web requests, and manage string-based logic.
- Projects can now be authored as `.atproj` MSBuild files (see `samples/hello-world`) using the `AtLang.Sdk`. Builds emit IL assemblies runnable via `dotnet`.
- Manual workflows still allow invoking `dotnet AtLangCompiler.dll <source> <output> [selfContained]` to compile standalone scripts.

## Compiler details
- The compiler lives in `compiler/`, with `Compiler/Compiler.cs` handling lexing/parsing (via `Lexer`/`Parser`) and emitting IL through `PersistedAssemblyBuilder`.
- `Compiler.CompileToIL` writes the assembly to the requested path and (unless a self-contained build is requested) copies `AtLangCompiler.runtimeconfig.json` next to the output so `dotnet` can execute it.
- The CLI entry point (`compiler/Program.cs`) validates arguments, reads source, and forwards `selfContained` to the compiler so SDK and manual builds can toggle runtime config emission.

## SDK + tests
- `sdk/AtLang.Sdk` packages `Sdk.props/targets` plus the compiled compiler under `tools/net9.0/any/`. Projects opt in via `<Project Sdk="AtLang.Sdk">` and can set `<SelfContained>true</SelfContained>` if they plan to bundle their own runtime.
- `test/SdkTests.cs` executes `dotnet build` against `samples/hello-world/hello-world.atproj` (and a self-contained variation) to validate the SDK. Tests expect the repo root constant exposed via `AtLang.Build.BuildEnvironment.BASEDIR` (generated from `Directory.Build.targets`).
