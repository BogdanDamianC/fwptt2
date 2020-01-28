using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace fwptt.TestProject
{
    internal class CSharpCodeCompiler
    {
        internal static MemoryStream CreateMemoryAssembly(string sourceCode, IEnumerable<string> referenceAssemblies)
        {
            var memAsmStream = new MemoryStream();
            var result = CompileCode(sourceCode, referenceAssemblies).Emit(memAsmStream);
            if (!result.Success)
            {
                var errors = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);
                var sb = new StringBuilder();
                foreach (var err in errors)
                {
                    sb.Append(err);
                    sb.Append(Environment.NewLine);
                }
                throw new ApplicationException("CompilationError => " + Environment.NewLine + sb.ToString());
            }
            memAsmStream.Seek(0, SeekOrigin.Begin);
            return memAsmStream;
        }

        private static CSharpCompilation CompileCode(string sourceCode, IEnumerable<string> referenceAssemblies)
        {
            var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp8);

            var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(sourceCode, options);

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(CSharpCodeCompiler).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly.Location),
            };

            return CSharpCompilation.Create("fwptt_generated_load_test.dll",
                new[] { parsedSyntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                    optimizationLevel: OptimizationLevel.Release,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
        }
    }
}
