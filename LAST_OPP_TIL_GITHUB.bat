@echo off
setlocal EnableExtensions EnableDelayedExpansion
title KI-Laben Setup - GitHub Uploader
color 0B

rem ============================================================
rem  KI-LABEN SETUP - GITHUB UPLOADER
rem  Repo: https://github.com/Darschnid479/Setup
rem
rem  Legg denne BAT-filen i roten av prosjektmappen og dobbeltklikk.
rem  Scriptet:
rem    1. Sjekker Git
rem    2. Initialiserer repo ved behov
rem    3. Setter main som branch
rem    4. Setter riktig GitHub remote
rem    5. Logger inn via GitHub/Git Credential Manager ved behov
rem    6. Legger til filer
rem    7. Lager commit
rem    8. Henter remote-endringer trygt
rem    9. Pusher til GitHub
rem
rem  Scriptet bruker IKKE force-push og sletter ikke filer.
rem ============================================================

set "REPO_URL=https://github.com/Darschnid479/Setup.git"
set "REPO_WEB=https://github.com/Darschnid479/Setup"
set "BRANCH=main"
set "COMMIT_MSG=Update KI-Laben Setup"

cd /d "%~dp0"

cls
echo.
echo ============================================================
echo.
echo             KI-LABEN SETUP  /  GITHUB UPLOADER
echo.
echo ============================================================
echo.
echo   Project folder:
echo   %CD%
echo.
echo   Target:
echo   %REPO_WEB%
echo.
echo ------------------------------------------------------------
echo.

rem --- Check Git ------------------------------------------------
where git >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Git er ikke installert eller finnes ikke i PATH.
    echo.
    echo Apner Git for Windows...
    start "" "https://git-scm.com/download/win"
    echo.
    echo Installer Git, velg standardvalg, start PC/terminal pa nytt,
    echo og kjor denne filen igjen.
    echo.
    pause
    exit /b 1
)

for /f "delims=" %%G in ('git --version') do set "GIT_VERSION=%%G"
echo [ OK ] !GIT_VERSION!

rem --- Optional identity -----------------------------------------
for /f "delims=" %%N in ('git config --global user.name 2^>nul') do set "GIT_NAME=%%N"
for /f "delims=" %%E in ('git config --global user.email 2^>nul') do set "GIT_EMAIL=%%E"

if not defined GIT_NAME (
    echo.
    echo Git mangler navn for commits.
    set /p "GIT_NAME=Skriv navnet du vil vise pa GitHub commits: "
    if not defined GIT_NAME set "GIT_NAME=KI-Laben Setup"
    git config --global user.name "!GIT_NAME!"
)

if not defined GIT_EMAIL (
    echo.
    echo Git mangler e-post for commits.
    set /p "GIT_EMAIL=Skriv GitHub-e-posten din: "
    if not defined GIT_EMAIL (
        color 0C
        echo [STOP] E-post er nodvendig for commits.
        pause
        exit /b 1
    )
    git config --global user.email "!GIT_EMAIL!"
)

echo [ OK ] Git identity: !GIT_NAME! ^<!GIT_EMAIL!^>

rem --- Initialize repository ------------------------------------
if not exist ".git\" (
    echo.
    echo [ .. ] Initialiserer Git repository...
    git init
    if errorlevel 1 goto :git_error
) else (
    echo [ OK ] Git repository finnes allerede.
)

rem --- Ensure main branch ---------------------------------------
git rev-parse --verify HEAD >nul 2>&1
if errorlevel 1 (
    git symbolic-ref HEAD refs/heads/%BRANCH% >nul 2>&1
) else (
    for /f "delims=" %%B in ('git branch --show-current 2^>nul') do set "CURRENT_BRANCH=%%B"
    if /I not "!CURRENT_BRANCH!"=="%BRANCH%" (
        echo [ .. ] Bytter lokal branch til %BRANCH%...
        git branch -M %BRANCH%
        if errorlevel 1 goto :git_error
    )
)
echo [ OK ] Branch: %BRANCH%

rem --- Configure remote -----------------------------------------
git remote get-url origin >nul 2>&1
if errorlevel 1 (
    echo [ .. ] Legger til GitHub remote...
    git remote add origin "%REPO_URL%"
    if errorlevel 1 goto :git_error
) else (
    for /f "delims=" %%R in ('git remote get-url origin') do set "OLD_REMOTE=%%R"
    if /I not "!OLD_REMOTE!"=="%REPO_URL%" (
        echo [ .. ] Oppdaterer origin:
        echo        Fra: !OLD_REMOTE!
        echo        Til : %REPO_URL%
        git remote set-url origin "%REPO_URL%"
        if errorlevel 1 goto :git_error
    )
)
echo [ OK ] Origin: %REPO_URL%

rem --- Try GitHub CLI login when available ----------------------
where gh >nul 2>&1
if not errorlevel 1 (
    gh auth status -h github.com >nul 2>&1
    if errorlevel 1 (
        echo.
        echo [LOGIN] GitHub trenger innlogging.
        echo         Nettleseren vil apnes.
        echo.
        gh auth login --hostname github.com --git-protocol https --web
        if errorlevel 1 (
            echo.
            echo [WARN] GitHub CLI-innlogging ble ikke fullfort.
            echo        Git vil prove vanlig nettleserinnlogging ved push.
        ) else (
            gh auth setup-git >nul 2>&1
            echo [ OK ] GitHub-innlogging fullfort.
        )
    ) else (
        echo [ OK ] GitHub CLI er allerede innlogget.
        gh auth setup-git >nul 2>&1
    )
) else (
    echo [INFO] GitHub CLI er ikke installert.
    echo        Git Credential Manager kan fortsatt vise nettleserinnlogging.
)

rem --- Stage everything -----------------------------------------
echo.
echo [1/4] Legger til prosjektfiler...
git add -A
if errorlevel 1 goto :git_error

git diff --cached --quiet
if not errorlevel 1 (
    echo [2/4] Lager commit...
    set "STAMP=%DATE% %TIME:~0,8%"
    git commit -m "%COMMIT_MSG% - !STAMP!"
    if errorlevel 1 goto :git_error
) else (
    echo [2/4] Ingen nye lokale endringer a committe.
)

rem --- Fetch remote safely --------------------------------------
echo [3/4] Henter status fra GitHub...
git fetch origin
if errorlevel 1 (
    echo.
    echo [AUTH] GitHub avviste tilgangen eller innlogging mangler.
    echo.
    echo Prover a starte nettleserinnlogging via Git Credential Manager...
    git credential-manager github login >nul 2>&1
    if not errorlevel 1 (
        git fetch origin
    )
)

if errorlevel 1 goto :permission_error

rem --- Sync if remote main exists -------------------------------
git show-ref --verify --quiet refs/remotes/origin/%BRANCH%
if not errorlevel 1 (
    echo [ .. ] Remote main finnes. Synkroniserer uten force-push...

    git merge-base HEAD origin/%BRANCH% >nul 2>&1
    if not errorlevel 1 (
        git pull --rebase origin %BRANCH%
        if errorlevel 1 goto :sync_error
    ) else (
        echo.
        echo [INFO] Lokal og remote historikk er separate.
        echo        Prover trygg merge med --allow-unrelated-histories.
        git pull origin %BRANCH% --allow-unrelated-histories --no-rebase --no-edit
        if errorlevel 1 goto :sync_error
    )
) else (
    echo [ OK ] Ingen eksisterende remote main - klar for forste push.
)

rem --- Push ------------------------------------------------------
echo [4/4] Pusher til GitHub...
git push -u origin %BRANCH%
if errorlevel 1 goto :permission_error

color 0A
echo.
echo ============================================================
echo.
echo                   UPLOAD COMPLETE
echo.
echo ============================================================
echo.
echo [ OK ] Prosjektet er pushet til:
echo        %REPO_WEB%
echo.
echo [ .. ] Apner GitHub...
start "" "%REPO_WEB%"
echo.
pause
exit /b 0

:permission_error
color 0C
echo.
echo ============================================================
echo                    GITHUB ACCESS FAILED
echo ============================================================
echo.
echo GitHub godtok ikke push/fetch.
echo.
echo Scriptet har IKKE endret Windows-sikkerhet og har IKKE brukt force.
echo.
echo Vanlige arsaker:
echo   - Feil GitHub-konto er innlogget
echo   - Kontoen har ikke skrivetilgang til Darschnid479/Setup
echo   - Gammel GitHub-legitimasjon ligger lagret i Windows
echo.
echo Prover a apne GitHub slik at du kan kontrollere kontoen...
start "" "%REPO_WEB%"
echo.
echo Hvis Git Credential Manager viser innlogging, velg kontoen som eier repoet.
echo.
pause
exit /b 2

:sync_error
color 0E
echo.
echo ============================================================
echo                     SYNC STOPPED SAFELY
echo ============================================================
echo.
echo GitHub har filer som kolliderer med lokale filer.
echo Scriptet stoppet i stedet for a overskrive noe.
echo.
echo Kjor:
echo     git status
echo.
echo og los eventuelle merge-konflikter. Deretter kan du kjor BAT-filen igjen.
echo.
pause
exit /b 3

:git_error
color 0C
echo.
echo ============================================================
echo                       GIT ERROR
echo ============================================================
echo.
echo En lokal Git-kommando feilet.
echo Kjor denne kommandoen for mer informasjon:
echo.
echo     git status
echo.
pause
exit /b 4
