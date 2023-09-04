using SymbolNamespace;

DebugOutput.UseWriter(SpectreDebugOutputWriter.Default());

Runner runner = new(() => new EntryPoint()
    .UseSpectreConsole(builder => builder
        .SetLabels()
        .SetStyles()
        .DisplayPrefixWith(c => { /* Display any lines before the CLI output is displayed. */ })
        .DisplaySuffixWith(c => { /* Display any lines after the CLI output is displayed. */ }))
    .AddVersionOption()
    .DisplayHelpOnError()
    .ScanEntryAssembly());

//-:cnd:noEmit
#if DEBUG
return await runner.UseSpectreDebugRepl(useDefaultStyle: true).RunAsync();
#else
return await runner.RunAsync();
#endif
//+:cnd:noEmit
