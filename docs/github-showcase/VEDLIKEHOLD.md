# Vedlikehold av prosjektsiden

## Hvor ligger hva?

- `README.md`: GitHub-repoets hovedpresentasjon.
- `README-before-showcase.md`: tidligere README, bevart i roten så relative lenker fortsatt peker samme sted.
- `github-site/index.html`: selve prosjektsiden og all norsk tekst.
- `github-site/assets/site.css`: layout, mobiloppsett, mørkt/lyst tema og animasjoner.
- `github-site/assets/site.js`: galleri, bildeforstørrelse, redusert bevegelse, tema og offentlig release-oppslag.
- `github-site/assets/screenshots/`: fire eksisterende designforhåndsvisninger.
- `.github/workflows/launchpad-pages.yml`: publiserer bare `github-site/`, aldri hele repoet.

## Bytte til ekte skjermbilder

Ta anonymiserte skjermbilder fra Windows-utgaven. Fjern navn, e-post, maskinnavn og private stier før opplasting. Erstatt PNG-filene med samme filnavn, og tilpass bildetekster/alt-tekst. Fjern ikke merknaden om UI-forhåndsvisning før bildene faktisk er byttet ut. Banneret i README er presentasjonsgrafikk, ikke et screenshot.

## Nedlasting og status

Standardknappene går til Releases-oversikten. JavaScript prøver anonymt å hente `releases/latest` fra GitHub. En direkte nedlasting aktiveres bare hvis responsen har en opplastet Windows x64 ZIP og lenken ligger i riktig repos `releases/download/`-område. En 404 eller nettfeil viser forklaring, ikke en falsk klar-status. Forhåndsutgaver blir ikke valgt av dette endepunktet.

At det finnes en fil er ikke det samme som at programmet er testet eller signert. Skriv faktisk teststatus i release-notatene. Pages-workflowen har ingen effekt på eksisterende build-/release-workflows.

## Personvern og tilgjengelighet

Siden har ingen kontoskjemaer, API-nøkler eller sporing. Den henter logo fra KI-Laben og kan kontakte GitHub for versjonsdata. Tema lagres lokalt når nettleseren tillater det. Brukerens systemvalg for redusert bevegelse respekteres; galleriet virker med tastatur og bilder kan åpnes i dialog med Escape for å lukke.

## Gå tilbake

Oppsett-BAT-en skriver commit-hash og lager en Git-bundle i sin separate arbeidsmappe før endringene. Bruk Git-historikken til å reversere presentasjonscommitten etter normal gjennomgang. Ikke bruk force-push. Eventuelle repo-metadata og Pages-innstillinger er egne endringer; tidligere innstillinger er lagret i arbeidsmappens logg. Et Git-revert gjenoppretter ikke disse innstillingene automatisk.

## Lokal prosjektmappe

BAT-en arbeider i en ny klone under `%LOCALAPPDATA%\KiLaben\GitHub-Showcase\`. Din vanlige prosjektmappe blir ikke redigert. Etter publisering: synkroniser den vanlige klonen via GitHub Desktop eller `git pull --ff-only` når arbeidsmappen er ren. Ved lokale endringer: lagre dem og bruk vanlig Git-flyt, ikke reset.
