# Teststatus for presentasjonspakken

Kontrollert 02.10.2026. Gjelder nettsiden og oppsettspakken, ikke selve Windows-programmet.

## Gjennomført

- HTML/CSS/JavaScript rendret i Chromium med innebygde bilder i en lokal testside i minnet.
- Ingen horisontal side-overflyt ved 320, 375, 390, 768, 1024 og 1440 piksler.
- Mørkt/lyst tema, galleri, tastaturnavigasjon og forstørrelsesdialog/Escape kontrollert.
- Endret systemvalg for redusert bevegelse respektert.
- Ingen JavaScript-kjøretidsfeil i de gjennomførte testene.
- Release-oppslag testet med simulerte API-svar: gyldig Windows ZIP, 404 og uventet nedlastingsdomene.
- Vanlig innhold fortsatt tilgjengelig uten JavaScript-forbedringene.
- YAML kontrollert; Pages-artifakten omfatter bare `github-site/`.
- BAT-fil kontrollert for ASCII uten BOM, CRLF, eksisterende goto-mål og avgrensede Git-stier.
- Base64-utpakking rekonstruert og SHA256 kontrollert mot nøyaktig innebygd ZIP.
- Tilsvarende Git-kommandoer prøvd i et isolert lokalt bare-repo: gammel README og app-kode bevart; andre staged/ukjente filer i brukerens arbeidsmappe urørt.
- Ny kjøring med uendret presentasjon ga ingen filendringer. Konkurrerende remote-commit avviste vanlig push uten overskriving.

## Ikke gjennomført

- BAT-kontrollflyten er ikke kjørt under Windows `cmd.exe` i dette miljøet.
- Ingen autentisert push, Pages-konfigurasjon eller ekte Pages-deploy er utført mot GitHub-kontoen.
- Containeren tillot ikke normal sidenavigasjon; UI-testen brukte HTML/ressurser i minnet. Faktisk varig nettleserlagring og live GitHub API ble ikke testet.
- WinForms-programmet er ikke bygget eller kjøringstestet av dette oppsettet.

BAT-en kontrollerer den faktiske Pages-workflowen når du kjører den. Bare en fullført workflow med `conclusion=success` rapporteres som vellykket publisering. Venting, avvist tilgang eller feil blir ikke presentert som ferdig nettsted.
