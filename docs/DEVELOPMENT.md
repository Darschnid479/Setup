# Utvikling

## Anbefalt miljø

- Windows 10/11 x64
- Visual Studio 2026
- .NET 10 SDK
- Workload: `.NET desktop development`
- Git

Kontroller SDK:

```bat
dotnet --list-sdks
```

Du skal ha en `10.x` SDK tilgjengelig.

## Bygg

Fra repo-roten:

```bat
BYGG.bat
```

Skriptet gjør ingen permanente endringer i PowerShell Execution Policy og trenger ikke administratorrettigheter for selve byggingen.

## Visual Studio

Åpne:

```text
KI-Laben-Setup-Launchpad.sln
```

Startprosjekt: `KiLabenSetup`.

## WinForms Designer

`MainForm.Designer.vb` inneholder de visuelle kontrollene. `MainForm.vb` inneholder logikken. Hold layoutendringer og forretningslogikk så separert som mulig.

## Debugging

Ved en uventet runtime-feil forsøker programmet å skrive `crash.log` ved siden av programmet. Ikke push loggen til GitHub uten å kontrollere innholdet.
