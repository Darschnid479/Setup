# Bidra til KI-Laben Setup

Takk for at du forbedrer Launchpad. Målet er at onboarding skal være enkel nok for en førstegangsbruker, samtidig som kildekoden er trygg og forståelig.

## Brancher

- `main`: stabil kode.
- `dev`: integrasjon av neste versjon.
- `feature/<kort-navn>`: nye funksjoner.
- `fix/<kort-navn>`: feilrettinger.

## Før en pull request

1. Kjør `BYGG.bat` på Windows.
2. Kontroller at self-tests består.
3. Start den publiserte `utgivelse\KiLabenSetup.exe`.
4. Test minst steget du har endret og steget før/etter.
5. Kontroller at ingen hemmeligheter eller personopplysninger er lagt til.
6. Legg ved skjermbilde dersom UI er endret.

## Commit-meldinger

Hold dem korte og konkrete, for eksempel:

```text
feat: add browser detection status
fix: prevent animation overflow
ui: improve Discord download card
build: add .NET 10 GitHub workflow
```

## UI-prinsipper

- Mørk marineblå base.
- Turkis brukes som hovedaksent, ikke overalt.
- Viktigste handling skal være tydeligst.
- Ikke skjul logoen i animasjoner.
- Ingen blinkende eller aggressive animasjoner.
- Programmet må fortsatt kunne brukes med animasjoner deaktivert.
- Språket skal være enkelt norsk uten unødvendige fagord.

## Sikkerhet

Ikke legg API-nøkler, tokens, passord eller medlemmenes private informasjon i kildekoden, issues, commits eller screenshots.
