# Nettlesere og Discord

## Flyt
Velg program -> last ned -> kontroller fil -> brukeren bekrefter installasjon ->
kontroller samme fil på nytt -> start Windows-installer. Appen er ikke administrator,
bruker ingen stille installasjon og skjuler ikke Windows-godkjenninger.

Katalogen inneholder bare Chrome, Firefox, Edge og Discord. Windows x64 bruker
direkte EXE-lenker. På ARM64 og andre arkitekturer stoppes direkte nedlasting,
og brukeren henvises til leverandørens offisielle side. Dette er et bevisst
avgrenset oppsett, ikke automatisk støtte for alle Windows-arkitekturer.

## Kontroller
HTTPS med normal sertifikatkontroll, kontroll av hver videresending mot tillatt
vertsliste, tidsgrense på 15 minutter per fil, maksimalt 512 MB, sjekk mot oppgitt
Content-Length og EXE-signaturen MZ. Filen skrives først som `.part`.

Windows' Get-AuthenticodeSignature må returnere Valid og en forventet utgiver.
Ved manglende kontroll, ny ukjent utgiver eller nettfeil blokkeres start fra appen.
Ikke fjern kontrollen for å få en fil til å kjøre. En godkjent signatur
bekrefter signering/tillit, ikke at all programoppførsel er risikofri. [1]

Mark of the Web beholdes som Zone.Identifier på nedlastede EXE-filer.
SHA-256 beregnes etter nedlasting. Hash og signatur kontrolleres igjen før start.
Filene ligger i `%LocalAppData%\KiLabenSetupLaunchpad\Downloads`.
Ufullstendige filer forsøkes slettet ved feil/avbrudd; antivirus eller rettigheter
kan hindre sletting. Start av installasjonsprosessen er aldri bevis på ferdig installasjon.

## Oppdagelse og nettleservalg
App Paths i Windows-registeret og vanlige installasjonsmapper brukes for å finne
nettleseren. Tilpassede/portable installasjoner kan bli oversett. Valgt nettleser
brukes for lenker hvis den finnes; ellers vises beskjed om at Windows-standard ble brukt.
Ingen filer, argumenter eller URL-er fra AI kan legges til i katalogen.

## Endring av leverandørlenker
Drifter redigerer `Catalog.vb`, kontrollerer offisiell kilde, vertslisten og utgiver,
kjører tester og bygger på nytt. Ikke bruk tredjeparts "download portals".
Direktelenkene er konfigurasjon i koden, ikke en påstand om evig stabile adresser.
Faktisk nedlasting/Windows-signatur er ikke live-testet i dette arbeidsmiljøet.

Offisielle sider:
- Discord: https://discord.com/download
- Installasjonsveiledning: https://support.discord.com/hc/en-us/articles/360034561191-Desktop-Installation-Guide
- Chrome: https://www.google.com/chrome/
- Firefox: https://www.firefox.com/en-US/download/all/desktop-release/win64/
- Edge: https://www.microsoft.com/en-us/edge/download
[1] Microsoft: https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.security/get-authenticodesignature
