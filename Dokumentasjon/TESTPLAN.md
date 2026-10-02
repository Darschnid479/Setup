# Teststatus og sjekkliste
Dato: 02.10.2026

## Utført her
Gjennomlest eksisterende Modern-UI-kildepakke. Statisk kontroll av prosjekt-XML,
Designer-deklarasjoner, hendelseskontroller, fjernede profilfelter, forventede
sikkerhetskontroller, navn i filer og ZIP-struktur. Se STATISK-KONTROLL.json.
Dette er IKKE det samme som kompilering eller Windows-kjøring.

## Ikke utført her
.NET SDK, PowerShell og Windows er ikke tilgjengelige i arbeidsmiljøet.
Forsøk på å hente SDK mislyktes på nettverksoppslag. Ingen påstand om
build-suksess, Designer-suksess, faktisk installasjon, signaturvalidering eller
live AI-svar er derfor gitt. Logoen kunne heller ikke hentes her.

## Kjøres av BYGG.bat hos dere
1. Tests/SelfTest.vbproj: navn, fornavnsadresse, fjernede tilstandsfelt,
   nedlastings-URL-er, falske vertsnavn, HTTPS, Discord-lenke og arkitekturgrense.
2. Restore/build av VB.NET-appen.
3. Build av AI-serveren.
4. Selvstendig Windows-publisering til utgivelse.

## Manuell Windows-kontroll før deling
[ ] Logoen er ekte, tydelig, hvit og synlig uten internett etter bygging.
[ ] MainForm åpnes i Designer uten feil. Alle sider kan redigeres.
[ ] 100 %, 125 %, 150 % og 200 % Windows-skalering: ingen uoppnåelige kontroller.
[ ] Tastatur/Tab: knapper, sjekkbokser, rapport og meny kan brukes uten mus.
[ ] Animasjoner av/på, minimert vindu, hurtig sideskifte og avslutning.
[ ] Adresse bruker bare fornavnet. Endret adresse nullstiller gamle bekreftelser.
[ ] Ingen Enhet, Mål for oppholdet, privat e-post eller utstyrsfane.
[ ] Nedlasting fra hver leverandør, faktisk fremdrift, cancellation og nettbrudd.
[ ] Signatur fra forventet utgiver; ukjent, endret eller usignert fil avvises.
[ ] Start installasjon krever bekreftelse; UAC/SmartScreen forblir på.
[ ] Ingen konto blir markert ferdig bare fordi en lenke er åpnet.
[ ] ChatGPT-invitasjon fra webmail gir riktig arbeidsområde.
[ ] Discord-nedlasting og faktisk serverinvitasjon testes separat.
[ ] AI med/uten config, feil kode, utløpt kode, avbrudd og hastighetsgrense.
[ ] AI sender ikke profil automatisk; kode og samtale lagres ikke i fremdriftsfil.
[ ] Lokal lagring er av som standard og virker når den velges.
[ ] Nytt medlem tømmer appens data; nettleserutlogging gjøres separat.
[ ] Godkjenn kilde, installeropplevelse, personvern og AI-drift før bred utrulling.

## Viktig driftsoppfølging
.NET 10 brukes i Visual Studio 2026-utgaven. SDK og WinForms-miljø må
følges opp. Kontroller leverandørlenker/publishere ved release, og signer egen
Windows-utgivelse via organisasjonens vanlige prosess før bred distribusjon.
