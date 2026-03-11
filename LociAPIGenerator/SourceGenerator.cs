using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IPCGenerator;

[Generator]
internal class SourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var sp = context.SyntaxProvider.CreateSyntaxProvider(
            (node, _) => node is TypeDeclarationSyntax { AttributeLists.Count: > 0 },
            (ctx, _) =>
            {
                var node = (TypeDeclarationSyntax)ctx.Node;
                var symbol = (INamedTypeSymbol?)ctx.SemanticModel.GetDeclaredSymbol(node);
                if (symbol is null || symbol.TypeKind != TypeKind.Interface)
                    return null;

                Trace.WriteLine($"saw symbol: {symbol.ToDisplayString()}");

                var hasAttribute = symbol.GetAttributes().Any(s => s.AttributeClass?.Name == "LociApiGeneratorAttribute");
                return hasAttribute ? symbol : null;
            }
        ).Where(s => s is not null);

        context.RegisterSourceOutput(sp, GenerateIPCClass);

        context.RegisterPostInitializationOutput(ctx =>
        {
            ctx.AddSource("LociApiGenerator.g.cs", @"
namespace IPCGenerator
{
    /// <summary> Apply this attribute to the interface you want to generate IPC methods for </summary>
    [System.AttributeUsage(System.AttributeTargets.Interface)]
    public sealed class LociApiGeneratorAttribute : Attribute { }
}
");
        });
    }

    public static void GenerateIPCClass(SourceProductionContext context, INamedTypeSymbol? symbol)
    {
        if (symbol is null)
            return;

        var ns = symbol.ContainingNamespace.IsGlobalNamespace ? null : symbol.ContainingNamespace.ToDisplayString();
        var className = symbol.Name;
        var methods = symbol.GetMembers().OfType<IMethodSymbol>();

        var sb = new StringBuilder();

        sb.AppendLine("using Dalamud.Plugin;").AppendLine("using LociApi.Api;").AppendLine("using LociApi.Enums;").AppendLine("using LociApi.Helpers;")
            .AppendLine().AppendLine("#nullable enable");

        if (ns is not null)
            sb.AppendLine($"namespace {ns}.GeneratedIPC;\n");

        // need to check if it's actually a function maybe?
        foreach (var method in methods)
        {
            var returns = method.ReturnType.ToDisplayString();
            var args = string.Join(", ", method.Parameters.Select(p => $"{p.Type.ToDisplayString()} {p.Name}"));
            var argTypes = string.Join(", ", method.Parameters.Select(p => $"{p.Type.ToDisplayString()}"));
            var typelessArgs = string.Join(", ", method.Parameters.Select(p => $"{p.Name}"));

            sb.AppendLine($"/// <inheritdoc cref=\"{className}.{method.Name}\" />")
                .AppendLine($"public sealed class {method.Name}(IDalamudPluginInterface pi)")
                .AppendLine($"    : FuncSubscriber<{(method.Parameters.Length > 0 ? $"{argTypes}, {returns}" : $"{returns}")}>(pi, Label)")
                .AppendLine("{")
                .AppendLine("    /// <summary> The label for this object </summary>")
                .AppendLine($"    public const string Label = $\"Loci.{{nameof({method.Name})}}\";")
                .AppendLine()
                .AppendLine($"    /// <inheritdoc cref=\"{className}.{method.Name}\" />")
                .AppendLine($"    public new {returns} Invoke({args})")
                .AppendLine($"        => base.Invoke({typelessArgs});")
                .AppendLine()
                .AppendLine("    /// <summary> Create a provider </summary>")
                .AppendLine($"    public static FuncProvider<{(method.Parameters.Length > 0 ? $"{argTypes}, {returns}" : $"{returns}")}> Provider(IDalamudPluginInterface pi, {className} api)")
                .AppendLine($"        => new FuncProvider<{(method.Parameters.Length > 0 ? $"{argTypes}, {returns}" : $"{returns}")}>(pi, Label, api.{method.Name});")
                .AppendLine("}\n");
        }

        context.AddSource($"{className}.IPC.g.cs", sb.ToString());
    }
}
