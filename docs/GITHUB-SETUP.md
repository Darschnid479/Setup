# GitHub-oppsett

Repo: `Darschnid479/Setup`

## Anbefalte repository settings

### General

- Default branch: `main`
- Issues: på
- Discussions: valgfritt, fint for idéer
- Wiki: av dersom dokumentasjonen holdes i `/docs`

### Branch protection for `main`

Opprett en ruleset for `main`:

- Require a pull request before merging
- Require status checks to pass
- Krev build-jobben fra `Build Windows`
- Block force pushes
- Block deletions

### Actions

Tillat GitHub Actions. `release.yml` trenger `contents: write` bare når en release-tag kjøres.

### About-felt

Forslag:

> KI-Laben Setup Launchpad — moderne Windows-onboarding for nettleser, arbeidskontoer, Discord, Google Workspace, ChatGPT, Drive og AI-hjelp.

Topics:

`ki-laben`, `onboarding`, `windows`, `winforms`, `vbnet`, `dotnet`, `dotnet10`, `ai`, `discord`, `google-workspace`

### Social preview

Bruk `docs/assets/hero.png` som repository social preview.
