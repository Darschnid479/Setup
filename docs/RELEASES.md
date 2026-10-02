# Releases

## Automatisk

1. Merge testet kode til `main`.
2. Oppdater versjonen i prosjektfilen.
3. Lag og push en tag:

```bash
git tag v2026.2.0
git push origin v2026.2.0
```

4. `release.yml` bygger Windows x64-utgaven.
5. Workflowen pakker publiseringsmappen som ZIP og oppretter GitHub Release.

## Før en release

- Build workflow grønn.
- Kjør programmet på Windows.
- Test nettleser, e-post, Google, ChatGPT, Discord og Drive.
- Test med animasjoner både på og av.
- Kontroller at logoen vises.
- Kontroller at repoet ikke inneholder hemmeligheter.
- Oppdater screenshots ved store UI-endringer.
