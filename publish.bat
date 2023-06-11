@echo off
setlocal

set packageId=Jeevan.Templates
set pushSource=https://www.myget.org/F/jeevanjames/api/v2/package
set pullSource=https://www.myget.org/F/jeevanjames/api/v3/index.json

if "%1"=="" goto error
set version=%1

echo %version%
del *.nupkg /s
dotnet restore ./templates.csproj
dotnet pack ./templates.csproj -c Release /p:Version=%version% --no-build
dotnet nuget push ./bin/Release/%packageId%.%version%.nupkg -s %pushSource%

goto restore_help

:error
echo Please specify version
echo Usage: %0 [version]
nuget search %packageId% -Source %pullSource%

:restore_help
echo.
echo Restore command:
echo dotnet new uninstall %packageId%
echo dotnet new install %packageId% --add-source %pullSource%
echo dotnet new install %packageId% --add-source %pullSource% | clip
