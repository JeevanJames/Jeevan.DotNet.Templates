using System.Reflection;

namespace SymbolNamespace;

internal sealed class EntryPoint : ConsoleProgram
{
    protected override void HandleCommand()
    {
        if (Version)
        {
            Assembly asm = Assembly.GetEntryAssembly() ??
                throw new InvalidOperationException("Cannot load program assembly.");
            MarkupLineInterpolated($"Version: {asm.GetName().Version}");
        }
        else
            DisplayHelp();
    }

    [Flag("version", "v",
        HelpText = "Displays the version of the application.")]
    public bool Version { get; set; }
}
