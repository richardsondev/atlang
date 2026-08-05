# AtLang @

## Overview

**AtLang** is a work-in-progress (WIP) compiled, CIL-based language intended as a learning tool. It is **not recommended** for production scenarios.

Despite its simple syntax, AtLang can perform significant operations with a single method. For example, spinning up a static file HTTP server requires only a single command: `@startServer(...)`.

The compiler is developed in C# using .NET 9's IL assembly writing capabilities. A Visual Studio Code extension providing syntax highlighting is also [available](https://marketplace.visualstudio.com/items?itemName=richardsondev.atlang).

---

## Getting Started

### Build with the AtLang .NET SDK

1. **Restore and build a project**
   ```bash
   dotnet build samples/hello-world/hello-world.atproj
   ```
   The `.atproj` file uses the local `AtLang.Sdk` (wired up through `global.json`) to automatically restore MSBuild targets and run the compiler.

2. **Run the compiled program**
   ```bash
   dotnet samples/hello-world/bin/Debug/HelloWorldSample.dll
   ```

3. **Author your own project**
   ```xml
  <Project Sdk="AtLang.Sdk">
    <PropertyGroup>
      <TargetFramework>net9.0</TargetFramework>
      <AssemblyName>MyApp</AssemblyName>
      <SelfContained>false</SelfContained>
    </PropertyGroup>
    <ItemGroup>
      <AtLangSource Include="Program.at" />
    </ItemGroup>
  </Project>
  ```
 Any `*.at` file included by `AtLangSource` is compiled to `bin/<Configuration>/<AssemblyName>.dll` and is runnable via `dotnet`. Set `<SelfContained>true</SelfContained>` to suppress the runtimeconfig file if you plan to bundle the runtime yourself.

#### Pin the .NET SDK with `global.json`

The repository's [`global.json`](./global.json) ensures `dotnet` commands consistently use the same SDK version and the in-tree `AtLang.Sdk`:

```json
{
  "sdk": {
    "version": "9.0.306",
    "rollForward": "latestFeature"
  },
  "msbuild-sdks": {
    "AtLang.Sdk": "sdk/AtLang.Sdk"
  }
}
```

- Adjust the `version` field if your environment requires a different .NET SDK.
- Keep `rollForward` at `latestFeature` (or a stricter setting) to avoid unexpected major-version jumps.
- When you eventually publish the SDK as a NuGet package, change the `AtLang.Sdk` entry to reference the package name instead of the relative path.

### Manual CLI usage

1. **Build the compiler once**
   ```bash
   cd compiler
   dotnet build AtLangCompiler.csproj
   ```
2. **Compile an AtLang file**
   ```bash
   dotnet bin/Debug/net9.0/AtLangCompiler.dll ../samples/hello-world/Program.at ../samples/hello-world/bin/Debug/ManualBuild.dll false
   ```
   The optional third argument specifies whether to emit the runtimeconfig file (`false` by default).

3. **Run the generated assembly**
   ```bash
   dotnet ../samples/hello-world/bin/Debug/ManualBuild.dll
   ```

---

## Features

1. **String Variable Assignment**  
   ```plaintext
   @GREETING = "Hello World"
   ```
   
2. **String Conditionals**  
   ```plaintext
   @if(@GREETING == "Hello World") {
       @print("Hi")
   } @else {
       @print("Bye")
   }
   ```
   
3. **String Concatenation**  
   ```plaintext
   @print(@GREETING + @GREETING)
   ```
   
4. **Environment Variable Reading**  
   ```plaintext
   @NAME = @getEnv(@USERNAME)
   ```

5. **Static Web Server**  
   ```plaintext
   @SERVER_ROOT_PATH = "./server_files"
   @SERVER_PORT = "8081"
   @startServer(@SERVER_ROOT_PATH, @SERVER_PORT)
   ```

6. **HTTP GET**  
   ```plaintext
   @IPURL = "https://ip.billywr.com/ip.txt"
   @IP = @getWeb(@IPURL)
   @IPTEXT = "Your IP is "
   @print(@IPTEXT + @IP)
   ```

7. **HTTP POST**  
   ```plaintext
   @IPURL = "https://ip.billywr.com/ip.txt"
   @POSTDATA = "[]"
   @IP = @postWeb(@IPURL, @POSTDATA)
   @IPTEXT = "POST response: "
   @print(@IPTEXT + @IP)
   ```

---

## Examples

Explore the `./samples` folder for complete sample programs ready to compile and run.

---

## Roadmap

1. **Self-Contained EXE Generation**  
2. **Asynchronous Operations**  
3. **Enhanced VS Code Extension Features**  

---

## License

This project is licensed under the [MIT License](./LICENSE), which grants permission for personal and commercial use, modification, distribution, and private use, with attribution. By using this software, you agree to the terms outlined in the license. For more details, please refer to the [LICENSE](./LICENSE) file.

---

## Contributing

Contributions are welcomed. Whether you're fixing a bug, adding a new feature, or improving documentation, your efforts make a difference. 

### How to Contribute:
1. **Report Issues:** If you encounter a bug or have suggestions for improvement, please create an issue in the [GitHub repository](https://github.com/richardsondev/atlang/issues).
2. **Submit Pull Requests:** Fork the repository, make your changes, and submit a pull request for review. Be sure to follow any contribution guidelines outlined in the repository.
3. **Join Discussions:** Engage with other contributors and maintainers by participating in discussions in issues or pull requests.

### Guidelines:
- Ensure your code follows the project's style and testing guidelines.
- Include clear and concise commit messages to help maintainers understand your changes.
- Be respectful and collaborative in your interactions with others.
