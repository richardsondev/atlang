# AtLang @

## Overview

**AtLang** is a work-in-progress (WIP) compiled, CIL-based language intended as a learning tool. It is **not recommended** for production scenarios at this stage.

Despite its simple syntax, AtLang can perform significant operations with a single method. For example, spinning up a static file HTTP server requires only a single command: `@startServer(...)`.

The compiler is developed in C# using .NET 9's IL assembly writing capabilities. A Visual Studio Code extension providing syntax highlighting is also [available](https://marketplace.visualstudio.com/items?itemName=richardsondev.atlang).

---

## Getting Started

1. **Build the Compiler**  
   Navigate to the `compiler/` directory and build the project:
   ```bash
   dotnet build AtLangCompiler.csproj
   ```
2. **Move to the Output Directory**  
   After building, switch to the folder containing the compiled artifacts.

3. **Compile Your AtLang Program**  
   ```bash
   dotnet AtLangCompiler.dll your_program.at
   ```
4. **Run the Generated Program**  
   ```bash
   dotnet AtLangGenerated.exe
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
   @NAME = getEnv(@USERNAME)
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
   @IP = getWeb(@IPURL)
   @IPTEXT = "Your IP is "
   @print(@IPTEXT + @IP)
   ```

7. **HTTP POST**  
   ```plaintext
   @IPURL = "https://ip.billywr.com/ip.txt"
   @POSTDATA = "[]"
   @IP = postWeb(@IPURL, @POSTDATA)
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
