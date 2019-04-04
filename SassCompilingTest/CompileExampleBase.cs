using LibSassHost;
using LibSassHost.Helpers;
using System;
using System.IO;

namespace SassCompilingTest
{
    public abstract class CompileExampleBase
    {
        static readonly string TestFilesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SassCompiled", "TestFiles");
        //For file compiling
        static readonly string ImportingPath = Path.Combine(TestFilesDirectory, "Importing.scss");
        static readonly string OutputhPath = Path.Combine(TestFilesDirectory, "Output.css");
        static readonly string OutputhmapPath = Path.Combine(TestFilesDirectory, "Output.css.map");
        // For string compiling
        static readonly string _importingContent = File.ReadAllText(ImportingPath);

        protected static void CompileContent()
        {
            try
            {
                var options = new CompilationOptions { SourceMap = true, OutputStyle = OutputStyle.Compressed, SourceMapFileUrls = true };
                CompilationResult compilationResult = SassCompiler.CompileFile(ImportingPath, OutputhPath, OutputhmapPath, options);
                Console.WriteLine("Compiled content:{1}{1}{0}{1}", compilationResult.CompiledContent,
                        Environment.NewLine);
                Console.WriteLine("Source map:{1}{1}{0}{1}", compilationResult.SourceMap, Environment.NewLine);
                Console.WriteLine("Included file paths: {0}",
                    string.Join(", ", compilationResult.IncludedFilePaths));
            }
            catch (SassСompilationException ex)
            {
                Console.WriteLine(SassErrorHelpers.Format(ex));
            }
        }

        protected static void CompileFile()
        {
            try
            {
                var options = new CompilationOptions { SourceMap = true, OutputStyle = OutputStyle.Compressed, SourceMapFileUrls = true };
                CompilationResult compilationResult = SassCompiler.Compile(_importingContent, OutputhPath, OutputhmapPath, options: options);
                Console.WriteLine("Compiled content:{1}{1}{0}{1}", compilationResult.CompiledContent,
                        Environment.NewLine);
                Console.WriteLine("Source map:{1}{1}{0}{1}", compilationResult.SourceMap, Environment.NewLine);
                Console.WriteLine("Included file paths: {0}",
                    string.Join(", ", compilationResult.IncludedFilePaths));
            }
            catch (SassСompilationException ex)
            {
                Console.WriteLine(SassErrorHelpers.Format(ex));
            }
        }
    }
}
