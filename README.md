# BitHelp.Core.Security

[![Licensed under the MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)
[![Integration Tests](https://github.com/RenatoPacheco/BitHelp.Core.Security/workflows/Integration%20Tests/badge.svg?branch=master)](https://github.com/RenatoPacheco/BitHelp.Core.Security/actions/workflows/integration-tests.yml)
[![NuGet](https://img.shields.io/nuget/v/BitHelp.Core.Security.svg)](https://nuget.org/packages/BitHelp.Core.Security)
[![Nuget](https://img.shields.io/nuget/dt/BitHelp.Core.Security.svg)](https://nuget.org/packages/BitHelp.Core.Security)

This project contains some classes that contain security features like encryptions.

# Getting Started

## Software dependencies

[.NET Standard 2.0](https://docs.microsoft.com/pt-br/dotnet/standard/net-standard)

## Installation process

This package is available through Nuget Packages: https://www.nuget.org/packages/BitHelp.Core.Security

**Nuget**
```
Install-Package BitHelp.Core.Security
```

**.NET CLI**
```
dotnet add package BitHelp.Core.Security
```

## Latest releases

#### Release 0.2.0

**Features:**

- Downgrade the version for netstandard compatibility

To read about others releases access [RELEASES.md](./RELEASES.md)

# Build and Test

Using Visual Studio Code, you can build and test the project from the terminal.

Build and restore the project:

```
dotnet restore
dotnet build --no-restore
```

Tests:

```
dotnet test --no-build --verbosity normal
```