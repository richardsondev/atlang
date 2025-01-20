# AtLang @

## Overview

**AtLang** is a work-in-progress (WIP) compiled, CIL-based language intended as a learning tool. It is **not recommended** for production scenarios.

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
   dotnet your_program.exe
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
