# AI-arkitektur

AI-funksjonen er delt i klient og gateway for å hindre at API-nøkler distribueres til alle Windows-maskiner.

## Klient

`KiLabenSetup/AiClient.vb`

Klienten kan sende:

- valgt onboarding-steg
- brukerens spørsmål
- midlertidig tilgangskode dersom gatewayen krever det

Klienten skal ikke sende passord, engangskoder eller annen unødvendig privat informasjon.

## Gateway

`KiLabenAiGateway/`

Gatewayen er stedet for server-side konfigurasjon og hemmeligheter. Den bør kjøres som en separat tjeneste i et kontrollert miljø.

Se også `Dokumentasjon/AI-DRIFT.md`.
