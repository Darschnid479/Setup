# Launchpad 3.0 - endringslogg

## Grunnlag
Endret fra `KI-Laben-Setup-WinForms-Modern-UI.zip` i denne samtalen.
Det tidligere prosjektet hadde profilfeltene Device/Goal og en equipment-side.
Dette er endringer i Windows-prosjektet, ikke på den offentlige WordPress-siden.

## Fjernet
Profilfeltene Enhet og Mål for oppholdet, utstyrssiden og tilhørende
lagring/rapporter. Ingen privat e-post er lagt til. Ingen personlige eksempelnavn.
Ny tilstandsfil importerer ikke de gamle feltene.

## Nytt
Nettleservalg, lokal programoppdagelse, direkte EXE-nedlasting, kø for valgt
nettleser og Discord, avbryt, signatur- og hashkontroll, eksplisitt installasjonsstart,
AI-hjelp via en separat server, lokal veiledning uten AI, nye animerte kontroller,
BYGG.bat med et PowerShell-byggedashboard og vedlagte automatiske logikktester.

## Beholdt
Kun fornavn foran @ki-laben.no; domenet vises ved siden av navnedelen.
Offisiell hvit logo i mørkt felt. Domeneshop-webmail, Workspace Essentials,
ChatGPT-invitasjon via arbeids-e-post, Discord og Drive/Docs.
Fremdrift bekreftes av medlemmet. Lagring er valgfri og lokal. Eksport er manuell.
Native kontroller i MainForm.Designer.vb gjør videre visuell redigering mulig.

## Automatisering som faktisk er implementert
- Adresseutledning fra fornavn og oppdatering av visningen.
- Automatisk neste steg etter at medlemmet selv har bekreftet gjeldende steg.
- Valg av nedlastingspakke fra en begrenset leverandørkatalog.
- Søk etter nettleser i App Paths og vanlige installasjonsmapper.
- Strømming av installasjonsfiler med faktisk antall bytes og tidsavbrudd.
- Kontroll av kilde/videresending, EXE-format, Windows-signatur og SHA-256.
- Kø som hopper over programmer funnet lokalt.
- Åpning av tjenestelenker i valgt nettleser når den er tilgjengelig.
- Rapport som skiller manuelle kontobekreftelser fra nedlastingshendelser.

## Bevisste menneskelige kontrollpunkter
Installasjon, Windows-standardnettleser, Google-verifisering, innlogging,
ChatGPT-invitasjon og medlemskap på Discord. AI har ingen shell-verktøy,
installeringsrettigheter eller mulighet til å endre bekreftede steg.
