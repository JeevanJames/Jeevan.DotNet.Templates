# Jeevan `dotnet new` templates

## General commands
Action | Command
------ | -------
Publish new templates | `.\publish.bat <version>`
Install templates | `dotnet new -i Jeevan.Templates --nuget-source https://www.myget.org/F/jeevanjames/api/v3/index.json`
Uninstall templates | `dotnet new -u Jeevan.Templates`

## Template reference

### .NET Core solution (`jeevan-sln`)
Creates a solution with supporting files such as `.editorconfig`, `Directory.Build.props`, `.gitignore`, Cake Build files, etc. Also creates two subdirectories - `src` and `test`.

```sh
dotnet new jeevan-sln --basens <base namespace>

# Examples
dotnet new jeevan-sln --basens Jeevan.MyNamespace
dotnet new jeevan-sln -n LibraryManager -o . -b Jeevan.LibraryManager
```

`--basens`, `-b` (Required): The base namespace for all projects in this solution. Set as a variable in the `Directory.Build.props` file, so that projects can use it as the base to define their root namespace.

### Console application (`jeevan-console`)
Creates a regular console project.

```sh
dotnet new jeevan-console --relativens <relative namespace>

# Examples
dotnet new jeevan-console --relativens Cli
dotnet new jeevan-console -o .\src\Cli -r Cli
```

### Console tool (`jeevan-console-tool`)
Creates a console application that doubles as a `dotnet` tool.

```sh
dotnet new jeevan-console-tool --relativens Cli --tool-name mycli
dotnet new jeevan-console-tool -o .\src\Cli -r Cli --tool-name mycli
```

`--tool-name` (Required): The name of the tool and assembly.
