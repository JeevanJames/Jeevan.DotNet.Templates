namespace SymbolNamespace;

internal sealed class EntryPoint : ConsoleProgram
{
    public override ValueTask HandleCommandAsync(IParseResult parseResult)
    {
        MarkupLine("Use this method for async logic.");
        return ValueTask.CompletedTask;
    }

    protected override void HandleCommand(IParseResult parseResult)
    {
        MarkupLine("Use this method for sync logic with access to the parse result.");
    }

    protected override void HandleCommand()
    {
        MarkupLine("Use this method for sync logic.");
    }
}
