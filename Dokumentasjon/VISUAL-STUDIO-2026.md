# Visual Studio 2026

Denne utgaven er målrettet mot **Visual Studio 2026 (18.x)** og **.NET 10**.

## Krav
- Visual Studio 2026
- Workload: **.NET desktop development**
- .NET 10 SDK
- Windows 10/11

Prosjekter:
- `KiLabenSetup`: `net10.0-windows` + Windows Forms
- `KiLabenAiGateway`: `net10.0`
- `Tests/SelfTest`: `net10.0`

## Sjekk SDK
Kjor i Command Prompt:

```text
dotnet --list-sdks
```

Det skal finnes minst én linje som starter med `10.`.

## Bygg
Dobbeltklikk `BYGG.bat`. Byggeskriptet bruker `dotnet` direkte og endrer ingen PowerShell- eller Windows-sikkerhetsinnstillinger.

Etter en vellykket publish ligger Windows-utgaven i `utgivelse\`.
