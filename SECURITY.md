# Security Policy

## Rapporter sikkerhetsproblemer

Ikke legg hemmeligheter, innloggingsdata, private medlemsopplysninger eller utnyttbar sikkerhetsinformasjon i en offentlig GitHub issue.

For interne KI-Laben-funn: bruk organisasjonens avtalte interne kanal og del kun informasjon som er nødvendig for å gjenskape feilen.

## Prosjektregler

- API-nøkler skal ligge server-side, aldri i WinForms-klienten.
- Passord skal ikke lagres av Launchpad.
- Private e-postadresser skal ikke være en del av onboarding-flyten.
- Nedlastede Windows-filer skal komme fra forventet leverandør og kontrolleres før de startes.
- Lokale logger må behandles som potensielt sensitive og skal ikke pushes automatisk.

## GitHub Secrets

Dersom Actions senere trenger hemmeligheter, bruk GitHub Actions Secrets/Environments. Ikke hardkod dem i YAML, JSON eller kildekode.
