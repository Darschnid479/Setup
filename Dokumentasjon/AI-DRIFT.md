# AI-server: oppsett for driftsansvarlig

## Arkitektur
Deltakerprogram -> HTTPS /api/assist -> KI-Labens .NET-server -> OpenAI Responses API.
Windows-appen er VB.NET. Den lille webserveren er ASP.NET Core/C# og er separat
fordi API-nøkler ikke skal distribueres med deltakerprogrammet. [1]

Dette er en avgrenset pilotintegrasjon, ikke en ferdig bedriftsløsning for
identitetsstyring. Den må driftssettes, sikres med HTTPS og godkjennes før bruk.

## Forberedelser
Opprett eller velg et KI-Laben-kontrollert OpenAI API-prosjekt med budsjett og
en servernøkkel. Ikke be deltakere bruke private kontoer/API-nøkler.
Tilgang til ChatGPT-arbeidsområdet er ikke i seg selv API-tilgang; API-bruk må
avklares og finansieres separat. [1, 2]

Bruk .NET 10 SDK på utviklingsmaskinen. På serveren trengs tilsvarende
ASP.NET Core runtime eller en selvstendig publisering. Planlegg overgang til
Visual Studio 2026 / .NET 10-oppsett for denne utgaven. [3]

## Lokal test på administratorens maskin
Etter å ha kontrollert og godkjent kildefilene:

```powershell
powershell.exe -NoProfile -File .\scripts\Start-AiServer.ps1
```

Skriptet ber om servernøkkel skjult og modell-ID som deres API-prosjekt har
tilgang til. Det genererer en tilfeldig tilgangskode som varer i åtte timer,
viser koden og starter serveren på 127.0.0.1:5088. Ingen nøkkel lagres i
prosjektfilene. Prosessmiljøet inneholder nøkkelen mens serveren kjører.
Bruk aldri dette adminskriptet på en delt deltaker-PC.

For testklienten på SAMME maskin:

```json
{
  "AiEndpoint": "http://127.0.0.1:5088/api/assist",
  "DiscordInvite": "",
  "DefaultBrowser": "chrome"
}
```

Skriv den midlertidige tilgangskoden i AI-fanen. Den holdes bare i minnet.
Velg steg, skriv et ufølsomt testspørsmål og bekreft sending. Kontroller
at svaret kommer fra serveren. Lokal reserveveiledning merkes eksplisitt som ikke-AI.

## Deltakere på andre maskiner
Publiser serveren på en KI-Laben-kontrollert vert. Bruk HTTPS med gyldig sertifikat.
Enten kjører Kestrel selv HTTPS, eller en reverse proxy tar imot HTTPS og videresender
til serverens loopback-binding. Ikke eksponer en ren HTTP-binding på lokalnettet.
`127.0.0.1` i deltakerens config ville peke til deltaker-PC-en, ikke serveren.

Sett miljøvariablene via driftsmiljøets hemmelighetshåndtering:

- `OPENAI_API_KEY`: servernøkkel.
- `OPENAI_MODEL`: en modell dere har testet og har tilgang til.
- `KILABEN_ACCESS_CODE`: tilfeldig midlertidig kode, minst 32 tegn.
- `KILABEN_CODE_EXPIRES_UTC`: ISO-tidspunkt i fremtiden, høyst 24 timer frem.
- `ASPNETCORE_URLS`: serverens lytteadresse, normalt loopback bak proxy.

Sett klientens `AiEndpoint` til den faktiske HTTPS-adressen. Distribuer riktig
`setup.settings.json` sammen med appen. Gi tilgangskoden separat via veileder.
Ikke legg den eller API-nøkkelen i ZIP, kildekode eller Drive-mapper.

## Innebygde begrensninger
12 forespørsler/minutt totalt, tre samtidige forespørsler, maksimalt 300 forsøk
per serverprosess og en tilgangskode som utløper. Dette er globale pilotgrenser,
ikke en garanti mot misbruk. Ved større utrulling: innfør per-bruker autentisering,
kvoter, administrert nøkkelrotasjon, overvåking og normal driftsberedskap.

AI mottar bare valgt steg og spørsmålet brukeren bekrefter. Profilen legges ikke
ved automatisk. Appen lagrer ikke AI-samtalen på disk. Serveren logger ikke
spørsmål/svar og bruker `store: false`. Dette er IKKE en garanti om ingen
lagring hos leverandøren; gjeldende API-datavilkår og eventuell sikkerhetslogging
må fortsatt vurderes. [4]

AI-svar er vanlig tekst i en tekstboks. Ingen HTML, kommandoer, automatisk
lenkeåpning, filinstallasjon eller verktøykall utføres fra svaret.

## Kontroll før bruk
Test ugyldig kode, utløpt kode, stor forespørsel, 429-grense, nettbrudd og
svar uten tekst. Verifiser at nøkler ikke havner i logger. Test at AI ikke hevder
å ha opprettet kontoer eller lest e-post. La veileder kvalitetssikre rådene.

## Kilder
[1] OpenAI, API key safety: https://help.openai.com/en/articles/5112595-best-practices-for-api-key-safety
[2] OpenAI, ChatGPT/API separation: https://help.openai.com/en/articles/6950777-what-is-chatgpt-plus
[3] Microsoft, .NET support: https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core
[4] OpenAI, Responses storage: https://developers.openai.com/api/docs/guides/migrate-to-responses
