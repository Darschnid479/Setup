# Last opp pakken til GitHub

Målrepo: `https://github.com/Darschnid479/Setup`

Den tryggeste metoden er å klone repoet først. Da bevares eventuell historikk som allerede finnes på GitHub.

## Metode A — GitHub Desktop

1. Åpne GitHub Desktop og logg inn.
2. Velg **File → Clone repository**.
3. Velg `Darschnid479/Setup`.
4. Åpne den utpakkede `KI-Laben-Setup-GitHub-Ready`-mappen i Filutforsker.
5. Kopier innholdet i mappen inn i den lokale `Setup`-mappen som GitHub Desktop klonet.
6. Ikke slett `.git`-mappen i det klonede repoet.
7. Gå tilbake til GitHub Desktop.
8. Kontroller endringslisten.
9. Commit-forslag:

   `docs: build complete GitHub home for Launchpad`

10. Trykk **Push origin**.

## Metode B — Git i terminal

Eksempel fra en mappe der du vil ha repoet:

```bat
git clone https://github.com/Darschnid479/Setup.git
```

Kopier deretter filene fra `KI-Laben-Setup-GitHub-Ready` inn i den klonede `Setup`-mappen. Kjør:

```bat
cd Setup
git status
git add .
git status
git commit -m "docs: build complete GitHub home for Launchpad"
git push origin main
```

Se alltid på `git status` før commit og push.

## Etter første push

1. Åpne **Actions** og sjekk at `Build Windows` starter.
2. Åpne repoets hovedside og kontroller at README og bildene vises.
3. Under **Settings → General / About**, legg inn beskrivelsen og topics fra `docs/GITHUB-SETUP.md`.
4. Sett `docs/assets/hero.png` som social preview.
5. Opprett `dev`-branch når `main` er grønn.
6. Sett branch protection/ruleset på `main`.

## Første release

Når `main` er grønn og programmet er testet lokalt:

```bat
git tag v2026.2.0
git push origin v2026.2.0
```

`Release Windows`-workflowen forsøker da å bygge en Windows x64-pakke og opprette GitHub Release automatisk.
