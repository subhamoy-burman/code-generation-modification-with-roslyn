# Code Generation and Modification with Roslyn

## Overview

**Code Generation and Modification with Roslyn** is a .NET Core console application that demonstrates how to use the Roslyn API to programmatically add properties to C# class files. This project showcases the power of Roslyn for code analysis, generation, and modification, providing a clean and maintainable way to manipulate C# code.

## Features

- **Dynamic Property Addition**: Add new properties to existing C# class files without manually editing the code.
- **Code Formatting**: Ensure the added properties are properly formatted and indented using Roslyn's `SyntaxFormatter`.
- **Project Integration**: Load and modify class files within a specified project, leveraging the Roslyn workspace.

## Getting Started

### Prerequisites

- .NET Core SDK
- Visual Studio with .NET Core development workload

### Usage

1. Clone the repository:
   ```sh
   git clone https://github.com/subhamoy-burman/code-generation-modification-with-roslyn.git
   cd code-generation-modification-with-Roslyn

2. In program.cs of ConsoleCodeGenerate change the propertyName and propertyType as per your need
3. You see in CodeGenerationTarget --> Customer.cs file that particular property is being added.