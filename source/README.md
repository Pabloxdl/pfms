# PFMS recovered source

This repository contains source recovered from the published PFMS 1.3.0.0 .NET application found on the original PC. It includes the application logic, macro engine, fishing services, screen vision, configuration models, and Avalonia UI code.

## Build

Requires the .NET 10 SDK on Windows.

```powershell
dotnet restore PFMS.csproj
dotnet build PFMS.csproj
```

The project currently references dependency DLLs from a local `original-runtime` directory. That directory is intentionally excluded from Git because it is a large private binary backup. Keep it locally beside the project when building this recovered version, or replace those references with NuGet package references in a future cleanup pass.

## Important

This is decompiled recovery source, not the original source tree. Names, formatting, generated Avalonia code, project metadata, and comments may differ from the original. The preserved original runtime is kept separately on the recovery PC for behavior comparison.

See `RECOVERY_NOTES.md` for recovery details and limitations.
