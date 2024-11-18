using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;

internal class Program
{
    private static void Main(string[] args)
    {
        // Path to the class file
        string classFilePath = @"C:\Users\sburman\Projects\CodeGenerate\CodeGenerationTarget\Customer.cs";
        string propertyName = "Age";
        string propertyType = "int";

        // Load the project
        var workspace = MSBuildWorkspace.Create();
        var project = workspace.OpenProjectAsync(@"C:\Users\sburman\Projects\CodeGenerate\CodeGenerationTarget\CodeGenerationTarget.csproj").Result;
        var document = project.Documents.First(d => d.FilePath == classFilePath);
        var syntaxRoot = document.GetSyntaxRootAsync().Result;

        // Find the class declaration
        var classDeclaration = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().First();

        // Create the new property
        var newProperty = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(propertyType), propertyName)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddAccessorListAccessors(
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));

        // Add the new property to the class
        var newClassDeclaration = classDeclaration.AddMembers(newProperty);
        var newSyntaxRoot = syntaxRoot.ReplaceNode(classDeclaration, newClassDeclaration);

        // Format the modified syntax tree
        var formattedRoot = Formatter.Format(newSyntaxRoot, workspace);

        // Write the modified class file
        File.WriteAllText(classFilePath, formattedRoot.ToFullString());

        Console.WriteLine($"Property '{propertyName}' added to the class file.");
    }
}
