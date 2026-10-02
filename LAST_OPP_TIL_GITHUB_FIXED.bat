@echo off
setlocal EnableExtensions EnableDelayedExpansion
title KI-Laben Setup - GitHub Uploader FIX
color 0B

set "REPO_URL=https://github.com/Darschnid479/Setup.git"
set "REPO_WEB=https://github.com/Darschnid479/Setup"
set "BRANCH=main"
set "COMMIT_MSG=Update KI-Laben Setup"

cd /d "%~dp0"

cls
echo.
echo ============================================================
echo.
echo        KI-LABEN SETUP  /  GITHUB UPLOADER - FIXED
echo.
echo ============================================================
echo.
echo   Folder:
echo   %CD%
echo.
echo   GitHub:
echo   %REPO_WEB%
echo.
echo ============================================================
echo.

rem ------------------------------------------------------------
rem 1. Check Git
rem ------------------------------------------------------------
where git >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Git is not installed or is missing from PATH.
    echo.
    start "" "https://git-scm.com/download/win"
    echo Install Git for Windows, then run this file again.
    echo.
    pause
    exit /b 1
)

for /f "delims=" %%G in ('git --version') do set "GIT_VERSION=%%G"
echo [ OK ] !GIT_VERSION!

rem ------------------------------------------------------------
rem 2. Git identity
rem ------------------------------------------------------------
set "GIT_NAME="
set "GIT_EMAIL="

for /f "delims=" %%N in ('git config --global user.name 2^>nul') do set "GIT_NAME=%%N"
for /f "delims=" %%E in ('git config --global user.email 2^>nul') do set "GIT_EMAIL=%%E"

if not defined GIT_NAME (
    echo.
    set /p "GIT_NAME=Name to use for Git commits: "
    if not defined GIT_NAME set "GIT_NAME=KI-Laben Setup"
    git config --global user.name "!GIT_NAME!"
    if errorlevel 1 goto :git_error
)

if not defined GIT_EMAIL (
    echo.
    set /p "GIT_EMAIL=Email to use for Git commits: "
    if not defined GIT_EMAIL (
        color 0C
        echo [STOP] Git needs an email address for commits.
        pause
        exit /b 1
    )
    git config --global user.email "!GIT_EMAIL!"
    if errorlevel 1 goto :git_error
)

echo [ OK ] Git identity configured.

rem ------------------------------------------------------------
rem 3. Initialize repo
rem ------------------------------------------------------------
if not exist ".git\" (
    echo [ .. ] Initializing local Git repository...
    git init
    if errorlevel 1 goto :git_error
) else (
    echo [ OK ] Local Git repository found.
)

rem ------------------------------------------------------------
rem 4. Make sure branch is main
rem ------------------------------------------------------------
git rev-parse --verify HEAD >nul 2>&1
if errorlevel 1 (
    git symbolic-ref HEAD refs/heads/%BRANCH%
    if errorlevel 1 goto :git_error
) else (
    for /f "delims=" %%B in ('git branch --show-current 2^>nul') do set "CURRENT_BRANCH=%%B"
    if /I not "!CURRENT_BRANCH!"=="%BRANCH%" (
        echo [ .. ] Renaming branch to %BRANCH%...
        git branch -M %BRANCH%
        if errorlevel 1 goto :git_error
    )
)
echo [ OK ] Branch: %BRANCH%

rem ------------------------------------------------------------
rem 5. Configure origin
rem ------------------------------------------------------------
git remote get-url origin >nul 2>&1
if errorlevel 1 (
    echo [ .. ] Adding GitHub origin...
    git remote add origin "%REPO_URL%"
    if errorlevel 1 goto :git_error
) else (
    for /f "delims=" %%R in ('git remote get-url origin') do set "OLD_REMOTE=%%R"
    if /I not "!OLD_REMOTE!"=="%REPO_URL%" (
        echo [ .. ] Updating GitHub origin...
        git remote set-url origin "%REPO_URL%"
        if errorlevel 1 goto :git_error
    )
)
echo [ OK ] Origin: %REPO_URL%

rem ------------------------------------------------------------
rem 6. Stage files
rem ------------------------------------------------------------
echo.
echo [1/5] Staging project files...
git add -A
if errorlevel 1 goto :git_error

rem IMPORTANT:
rem git diff --cached --quiet returns:
rem   0 = no staged changes
rem   1 = staged changes exist
git diff --cached --quiet
if errorlevel 1 (
    echo [2/5] Creating commit...
    git commit -m "%COMMIT_MSG%"
    if errorlevel 1 goto :commit_error
) else (
    git rev-parse --verify HEAD >nul 2>&1
    if errorlevel 1 (
        color 0C
        echo.
        echo [STOP] No files were staged and this repository has no commit.
        echo.
        echo Make sure this BAT file is placed in the ROOT of the extracted
        echo GitHub-ready project, next to README.md and KiLabenSetup.
        echo.
        pause
        exit /b 5
    ) else (
        echo [2/5] No new local changes to commit.
    )
)

rem ------------------------------------------------------------
rem 7. Verify HEAD exists BEFORE any push
rem ------------------------------------------------------------
git rev-parse --verify HEAD >nul 2>&1
if errorlevel 1 (
    color 0C
    echo.
    echo [STOP] Git still has no local commit.
    echo This uploader will not try to push an empty branch.
    echo.
    pause
    exit /b 6
)

for /f "delims=" %%H in ('git rev-parse --short HEAD') do set "HEAD_SHORT=%%H"
echo [ OK ] Local commit exists: !HEAD_SHORT!

rem ------------------------------------------------------------
rem 8. Optional GitHub login helper
rem ------------------------------------------------------------
where gh >nul 2>&1
if not errorlevel 1 (
    gh auth status -h github.com >nul 2>&1
    if errorlevel 1 (
        echo.
        echo [LOGIN] Opening GitHub browser login...
        gh auth login --hostname github.com --git-protocol https --web
        if not errorlevel 1 gh auth setup-git >nul 2>&1
    ) else (
        gh auth setup-git >nul 2>&1
        echo [ OK ] GitHub CLI login detected.
    )
) else (
    echo [INFO] GitHub CLI not installed. Git Credential Manager can handle login.
)

rem ------------------------------------------------------------
rem 9. Fetch
rem ------------------------------------------------------------
echo [3/5] Contacting GitHub...
git fetch origin
if errorlevel 1 (
    echo.
    echo [ .. ] Trying Git Credential Manager login...
    git credential-manager github login >nul 2>&1
    git fetch origin
)
if errorlevel 1 goto :auth_error

rem ------------------------------------------------------------
rem 10. Sync remote main if it exists
rem ------------------------------------------------------------
echo [4/5] Checking remote branch...
git show-ref --verify --quiet refs/remotes/origin/%BRANCH%
if errorlevel 1 (
    echo [ OK ] Remote main does not exist yet. First push is ready.
) else (
    echo [ .. ] Remote main exists. Synchronizing safely...

    git merge-base HEAD origin/%BRANCH% >nul 2>&1
    if errorlevel 1 (
        echo [INFO] Local and remote histories are separate.
        echo        Trying a safe merge without force-push...
        git pull origin %BRANCH% --allow-unrelated-histories --no-rebase --no-edit
        if errorlevel 1 goto :sync_error
    ) else (
        git pull --rebase origin %BRANCH%
        if errorlevel 1 goto :sync_error
    )
)

rem ------------------------------------------------------------
rem 11. Push
rem ------------------------------------------------------------
echo [5/5] Uploading to GitHub...
git push -u origin HEAD:%BRANCH%
if errorlevel 1 goto :push_error

color 0A
echo.
echo ============================================================
echo.
echo                  UPLOAD COMPLETE
echo.
echo ============================================================
echo.
echo [ OK ] Project uploaded successfully.
echo [ OK ] Branch: %BRANCH%
echo [ OK ] Commit: !HEAD_SHORT!
echo.
echo Opening GitHub...
start "" "%REPO_WEB%"
echo.
pause
exit /b 0


:commit_error
color 0C
echo.
echo ============================================================
echo                    COMMIT FAILED
echo ============================================================
echo.
echo Git could not create the local commit.
echo.
echo Run these commands to inspect the problem:
echo.
echo   git status
echo   git config user.name
echo   git config user.email
echo.
pause
exit /b 10


:auth_error
color 0C
echo.
echo ============================================================
echo                 GITHUB LOGIN FAILED
echo ============================================================
echo.
echo The local commit is OK, but GitHub authentication failed.
echo.
echo Open this repository and make sure you are signed in with
echo the account that owns it:
echo.
echo   %REPO_WEB%
echo.
start "" "%REPO_WEB%"
pause
exit /b 11


:sync_error
color 0E
echo.
echo ============================================================
echo                   SYNC STOPPED SAFELY
echo ============================================================
echo.
echo GitHub already has files that conflict with local files.
echo Nothing was force-pushed.
echo.
echo Run:
echo.
echo   git status
echo.
echo Resolve any conflict, commit it, then run this BAT again.
echo.
pause
exit /b 12


:push_error
color 0C
echo.
echo ============================================================
echo                    PUSH FAILED
echo ============================================================
echo.
echo A LOCAL COMMIT EXISTS, so this is not the old refspec error.
echo.
echo Current status:
git status --short --branch
echo.
echo Remote:
git remote -v
echo.
echo If GitHub asks for login, use the account that owns:
echo   Darschnid479/Setup
echo.
pause
exit /b 13


:git_error
color 0C
echo.
echo ============================================================
echo                     LOCAL GIT ERROR
echo ============================================================
echo.
git status
echo.
pause
exit /b 14
