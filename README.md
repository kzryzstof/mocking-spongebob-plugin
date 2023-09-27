# MockingSpongebob for Rider and ReSharper

[![Version](https://img.shields.io/jetbrains/plugin/v/com.jetbrains.rider.plugins.mockingspongebob)](https://plugins.jetbrains.com/plugin/18355-mocking-spongebob)
[![ReSharper](https://img.shields.io/resharper/v/ca.nosuchcompany.mockingspongebobplugin)](https://plugins.jetbrains.com/plugin/18356-mocking-spongebob)

**How to run on Windows**

- Open the solution `NoSuchCompany.MockingSpongebobPlugin.sln` in Visual Studio;
- Make sure there is a valid NuGet feed configured (`https://api.nuget.org/v3/index.json`);
- Open a command prompt in Powershell;
- Run the command `./buildPlugin.ps1` (you might need to remove the Rider project if it causes the build to fail);
- Run the command `./runVisualStudio.ps1` (you might need to remove the Rider project if it causes the build to fail);

At this point, another instance of Visual Studio should have been started.
Go into ReSharper > Extension Manager and look for the Mocking Spongebob extension plugin. It should be installed and have the version `9999.0`.

**How to run on macOS**

- Run the command `./gradlew :runIde` in a terminal window



