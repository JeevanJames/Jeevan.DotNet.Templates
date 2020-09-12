@echo off
setlocal

if "%1"=="" goto error
set version=%1
set packageId=Jeevan.Templates
set pushSource=https://www.myget.org/F/jeevanjames/api/v2/package
set pullSource=https://www.myget.org/F/jeevanjames/api/v3/index.json

echo %version%
del *.nupkg /s
dotnet restore ./templates.csproj
dotnet pack ./templates.csproj -c Release /p:Version=%version% --no-build
dotnet nuget push ./bin/Release/%packageId%.%version%.nupkg -s %pushSource%

goto restore_help

:error
echo Please specify version
echo Usage: install-package [version]

:restore_help
echo.
echo Restore command:
echo dotnet new -u %packageId%
echo dotnet new -i %packageId% --nuget-source %pullSource%
