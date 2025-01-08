# AtLang VSCode Extension

A Visual Studio Code extension providing syntax highlighting and basic language support for **AtLang (@)**.

---

## Features

- **Syntax Highlighting**  
  Colors and styles for AtLang keywords, variables, strings, etc.

- **Basic Snippets (Coming Soon)**  
  Quick insertion of common AtLang constructs, like environment variable assignments and print statements.

- **Inline Diagnostics (Coming Soon)**  
  Planned support for catching simple syntax errors (e.g., missing braces or quotes).

- **IntelliSense (Coming Soon)**  
  Possible future expansion for auto-completions and symbol suggestions.

---

## Requirements

- **Visual Studio Code** (latest recommended).  

> **Note:** This extension is only for editing/authoring AtLang code, not for running it directly in VSCode.

---

## Extension Settings

No user-configurable settings yet. Future versions might include:

- Toggle advanced highlighting features.  
- Enable or disable code diagnostics.  

---

## Known Issues

- **Limited Grammar Coverage**  
  AtLang's full grammar is not yet implemented. This means some valid constructs might not be highlighted properly.  
- **No Real-Time Error Reporting**  
  While simple syntax checks will come, we currently don't have an integrated parser or language server.  

---

## Installation

1. **Install from VSIX**  
   - Download the `.vsix` file for the AtLang extension.  
   - In VSCode, open the Extensions view (Ctrl+Shift+X or Cmd+Shift+X), click the "⋮" menu, then "Install from VSIX..." and select the `.vsix`.

2. **Reload**  
   - After installation, reload or restart VSCode to activate the extension.

3. **Open an AtLang File**  
   - Create or open a file with the `.at` extension.  
   - Syntax highlighting should be automatically applied.

---

## Contributing

If you have suggestions for additional AtLang features or want to help extend grammar coverage:

1. Clone the repository.  
2. Add or modify grammar rules in the `syntaxes/syntax.json` file (or equivalent).  
3. Submit pull requests or issues on the repo.  

---

## Release Notes

### 0.0.1
- Initial release
  - Syntax highlighting for keywords: `@if`, `@else`, `@print`, `getEnv`.
  - Basic highlighting for variables (`@VAR`).
  - String literal and punctuation (`{}`, `()`, etc.) coloring.

---

**Enjoy coding with `@` symbols all over the place!**
