# Kilder og bildeforklaring

## Prosjektgrunnlag

Tekst om funksjoner, kontoflyt og prosjektstruktur bygger på `KI-Laben-Setup-GitHub-Ready.zip` som ble laget tidligere i prosjektet. Den aktive GitHub-versjonen kunne ikke leses i denne arbeidsøkten. Oppsett-BAT-en kloner derfor fersk `main` før den legger til presentasjonsfilene. Den endrer ikke VB.NET- eller C#-kildekoden.

Bildene i `github-site/assets/screenshots/` og banneret er kopier av de eksisterende UI-forhåndsvisningene fra GitHub-pakken. De er ikke bevis på vellykket Windows-kjøring. Dette er opplyst både i README og på nettsiden.

Logoens nettadresse er den samme offisielle bildeadressen som tidligere ble oppgitt i prosjektet. Hvis bildet ikke kan lastes, vises tekst i stedet for et usynlig eller ødelagt bilde.

## Teknisk dokumentasjon kontrollert 02.10.2026

- GitHub Pages, egne workflows: https://docs.github.com/en/pages/getting-started-with-github-pages/using-custom-workflows-with-github-pages
- Pages REST API, `build_type=workflow`: https://docs.github.com/en/rest/pages/pages
- GitHub CLI, API-kall: https://cli.github.com/manual/gh_api
- GitHub CLI, repo-beskrivelse og topics: https://cli.github.com/manual/gh_repo_edit
- GitHub CLI, workflow-kjøring: https://cli.github.com/manual/gh_workflow_run
- GitHub CLI, kjøringsoversikt: https://cli.github.com/manual/gh_run_list
- Commit-e-post og GitHub noreply: https://docs.github.com/en/account-and-profile/how-tos/email-preferences/setting-your-commit-email-address

En plan eller organisasjonspolicy kan begrense Pages og Actions. Skriptet skal ikke endre repoets synlighet eller redusere beskyttelsen for å omgå slike begrensninger.
