# Hva oppsett-BAT-en gjør

1. Sjekker Git, GitHub CLI, Windows `tar` og `certutil`.
2. Ber om vanlig GitHub-innlogging ved behov. Ingen tokens skal limes inn i chatten.
3. Kontrollerer at `Darschnid479/Setup` er offentlig, ikke arkivert og at innlogget konto har skrivetilgang.
4. Kloner `main` i en ny mappe, uavhengig av lokale endringer og ukommitterte BAT-filer i din vanlige prosjektmappe.
5. Sikkerhetskopierer Git-historikken, README og repo-/Pages-metadata lokalt.
6. Pakker ut innebygd ZIP med nettsiden. Innholdets SHA256 må stemme før utpakking.
7. Stopper hvis en annen nettside-workflow eller en ukjent mappe med samme navn finnes. Eksisterende custom domain blir ikke endret.
8. Lager ny README, arkiverer den gamle og legger til egne nettside-/dokumentasjonsfiler.
9. Viser endringsoversikten og ber om bekreftelse før opplasting. Bare avtalte presentasjonsstier stages. Ingen `git add -A`.
10. Lager én vanlig commit og pusher til `main`, uten force eller automatisk rebase. Ved beskyttet branch eller en konkurrerende endring stopper skriptet.
11. Forsøker å konfigurere Pages for Actions, og oppdaterer repo-beskrivelse, nettsidelenke og topics. Det endrer ikke synlighet, lisenser, release-tags eller branch-beskyttelse.
12. Starter den nye Pages-workflowen og sjekker resultatet. Det rapporterer vellykket, ventende eller feilet publisering hver for seg.

## Forutsetninger

Git og GitHub CLI ble brukt i det tidligere opplastingsløpet. Ingen .NET SDK eller PowerShell trengs for dette nettsideoppsettet. Det installerer ikke verktøy eller krever Windows-administrator.

GitHub-kontoen må ha rettighetene til å pushe workflow-filer og administrere Pages. Dette er GitHub-rettigheter, ikke Windows-administrator. Mangler rettigheter, stopper/påpeker skriptet dette i stedet for å omgå dem. Ved manglende OAuth `workflow`-scope kan du godkjenne det via GitHub CLI selv; følg feilmeldingen.

## Lesbart innhold

Den nedlastbare BAT-filen inneholder en Base64-kodet ZIP med HTML, CSS, JavaScript, PNG-er og Markdown. Dette brukes for at én fil skal være nok; det skjuler ikke et installasjonsprogram. ZIP-versjonen av leveransen inneholder de samme filene ukodet, slik at du kan se gjennom dem før kjøring.

## Viktig

Nettstedet blir offentlig. Opplastingen her inneholder bare prosjektpresentasjon og allerede brukte designforhåndsvisninger, ikke medlemsregistre, app-innstillinger eller AI-nøkler. Dette er ikke en ny Windows-release. Dokumenter lokale kodeendringer før en senere Windows-release som vanlig.
