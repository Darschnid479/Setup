@echo off
setlocal EnableExtensions EnableDelayedExpansion
title KI-Laben Setup - First GitHub Release FIXED
color 0B

set "REPO=Darschnid479/Setup"
set "REPO_URL=https://github.com/Darschnid479/Setup.git"
set "REPO_WEB=https://github.com/Darschnid479/Setup"
set "BRANCH=main"

if "%~1"=="" (
    set "VERSION=v2026.2.0"
) else (
    set "VERSION=%~1"
)

set "NUM_VERSION=%VERSION%"
if /I "!NUM_VERSION:~0,1!"=="v" set "NUM_VERSION=!NUM_VERSION:~1!"

set "PROJECT=KiLabenSetup\KiLabenSetup.vbproj"
set "OUT_ROOT=release"
set "PUBLISH_DIR=%OUT_ROOT%\publish-win-x64"
set "ASSET_DIR=%OUT_ROOT%\assets"
set "ZIP_NAME=KI-Laben-Setup-%VERSION%-win-x64.zip"
set "ZIP_PATH=%ASSET_DIR%\%ZIP_NAME%"
set "SHA_PATH=%ASSET_DIR%\%ZIP_NAME%.sha256.txt"
set "NOTES_PATH=%ASSET_DIR%\RELEASE_NOTES_%VERSION%.md"
set "THIS_FILE=%~nx0"

cd /d "%~dp0"
cls

echo.
echo ============================================================
echo.
echo      KI-LABEN SETUP / FIRST RELEASE LAUNCHER - FIXED
echo.
echo ============================================================
echo.
echo   Repository : %REPO_WEB%
echo   Branch     : %BRANCH%
echo   Release    : %VERSION%
echo   Target     : Windows x64 / self-contained
echo.
echo ------------------------------------------------------------
echo.

choice /C YN /N /M "Create and publish %VERSION% now? [Y/N]: "
if errorlevel 2 (
    echo.
    echo Cancelled. Nothing was changed.
    pause
    exit /b 0
)

echo.
echo [1/9] Checking tools...

where git >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Git is not installed or missing from PATH.
    start "" "https://git-scm.com/download/win"
    pause
    exit /b 10
)
for /f "delims=" %%G in ('git --version') do echo [ OK ] %%G

where gh >nul 2>&1
if errorlevel 1 (
    color 0E
    echo [STOP] GitHub CLI is required.
    start "" "https://cli.github.com/"
    pause
    exit /b 11
)
for /f "tokens=1,2,3" %%A in ('gh --version ^| findstr /B /C:"gh version"') do echo [ OK ] GitHub CLI %%C

where dotnet >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] dotnet was not found.
    pause
    exit /b 12
)

set "HAS_NET10="
for /f "tokens=1" %%S in ('dotnet --list-sdks') do (
    echo %%S | findstr /B /C:"10." >nul && set "HAS_NET10=1"
)
if not defined HAS_NET10 (
    color 0C
    echo [STOP] .NET 10 SDK was not found.
    pause
    exit /b 13
)
echo [ OK ] .NET 10 SDK found.

where tar >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Windows tar.exe was not found.
    pause
    exit /b 14
)
echo [ OK ] Packaging tools ready.

if not exist "%PROJECT%" (
    color 0C
    echo [STOP] Project not found: %PROJECT%
    echo Put this BAT in the repository root.
    pause
    exit /b 15
)

echo.
echo [2/9] Checking repository...

if not exist ".git\" (
    color 0C
    echo [STOP] This folder is not a Git repository.
    pause
    exit /b 20
)

for /f "delims=" %%B in ('git branch --show-current 2^>nul') do set "CURRENT_BRANCH=%%B"
if /I not "!CURRENT_BRANCH!"=="%BRANCH%" (
    color 0E
    echo [STOP] Current branch is "!CURRENT_BRANCH!", not "%BRANCH%".
    pause
    exit /b 21
)
echo [ OK ] Branch: %BRANCH%

git remote get-url origin >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Git remote origin is missing.
    pause
    exit /b 22
)

for /f "delims=" %%R in ('git remote get-url origin') do set "ORIGIN=%%R"
if /I not "!ORIGIN!"=="%REPO_URL%" (
    color 0E
    echo [STOP] Wrong origin:
    echo        !ORIGIN!
    echo Expected:
    echo        %REPO_URL%
    pause
    exit /b 23
)
echo [ OK ] Origin: !ORIGIN!

echo.
echo [3/9] Checking GitHub login and remote...

gh auth status -h github.com >nul 2>&1
if errorlevel 1 (
    echo [LOGIN] Opening GitHub browser login...
    gh auth login --hostname github.com --git-protocol https --web
    if errorlevel 1 (
        color 0C
        echo [STOP] GitHub login was not completed.
        pause
        exit /b 30
    )
)
gh auth setup-git >nul 2>&1

git fetch origin
if errorlevel 1 (
    color 0C
    echo [STOP] Could not fetch from GitHub.
    pause
    exit /b 31
)
echo [ OK ] GitHub connection works.

echo.
echo [4/9] Handling release helper...

rem Stage ONLY the BAT files used for GitHub upload/release if present.
if exist "FIRST_RELEASE_GITHUB.bat" git add -- "FIRST_RELEASE_GITHUB.bat"
if exist "FIRST_RELEASE_GITHUB_FIXED.bat" git add -- "FIRST_RELEASE_GITHUB_FIXED.bat"
if exist "%THIS_FILE%" git add -- "%THIS_FILE%"

rem If those helper files created staged changes, commit only those staged files.
git diff --cached --quiet
if errorlevel 1 (
    echo [ .. ] Release helper changed. Creating helper commit...
    git commit -m "Add/update GitHub release helper"
    if errorlevel 1 (
        color 0C
        echo [STOP] Could not commit the release helper.
        pause
        exit /b 40
    )

    rem Sync before pushing helper commit.
    git show-ref --verify --quiet refs/remotes/origin/%BRANCH%
    if not errorlevel 1 (
        git pull --rebase origin %BRANCH%
        if errorlevel 1 (
            color 0E
            echo [STOP] Could not sync helper commit with origin/main.
            echo Run git status and resolve the conflict.
            pause
            exit /b 41
        )
    )

    git push origin %BRANCH%
    if errorlevel 1 (
        color 0C
        echo [STOP] Could not push the release helper commit.
        pause
        exit /b 42
    )

    git fetch origin >nul 2>&1
    echo [ OK ] Release helper committed and pushed automatically.
) else (
    echo [ OK ] Release helper is already committed.
)

echo.
echo [5/9] Verifying source state...

rem Ignore generated release directory, but do not ignore other project changes.
set "DIRTY="
for /f "delims=" %%S in ('git status --porcelain --untracked-files^=all') do (
    set "LINE=%%S"
    echo(!LINE!| findstr /I /B /C:"?? release/" /C:"?? release\" >nul
    if errorlevel 1 (
        set "DIRTY=1"
        echo   !LINE!
    )
)

if defined DIRTY (
    color 0E
    echo.
    echo [STOP] Other uncommitted project changes still exist.
    echo.
    echo Commit and push the files shown above, then run this BAT again.
    echo The release helper itself is no longer the blocker.
    echo.
    pause
    exit /b 50
)
echo [ OK ] No uncommitted project changes.

rem Clean any previous generated release output.
if exist "%OUT_ROOT%\" (
    echo [ .. ] Removing old generated release output...
    rmdir /S /Q "%OUT_ROOT%"
)

git fetch origin >nul 2>&1

for /f "delims=" %%L in ('git rev-parse HEAD') do set "LOCAL_HEAD=%%L"
for /f "delims=" %%R in ('git rev-parse origin/%BRANCH%') do set "REMOTE_HEAD=%%R"

if /I not "!LOCAL_HEAD!"=="!REMOTE_HEAD!" (
    color 0E
    echo [STOP] Local main and GitHub main are not identical.
    echo Local : !LOCAL_HEAD!
    echo Remote: !REMOTE_HEAD!
    pause
    exit /b 51
)

for /f "delims=" %%H in ('git rev-parse --short HEAD') do set "SHORT_HEAD=%%H"
echo [ OK ] main synced at !SHORT_HEAD!.

echo.
echo [6/9] Checking release tag...

gh release view "%VERSION%" --repo "%REPO%" >nul 2>&1
if not errorlevel 1 (
    color 0E
    echo [STOP] GitHub Release %VERSION% already exists.
    start "" "%REPO_WEB%/releases/tag/%VERSION%"
    pause
    exit /b 60
)

set "REMOTE_TAG="
for /f "tokens=1" %%T in ('git ls-remote --tags origin "refs/tags/%VERSION%"') do set "REMOTE_TAG=%%T"

if defined REMOTE_TAG (
    set "PEELED_TAG="
    for /f "tokens=1" %%T in ('git ls-remote --tags origin "refs/tags/%VERSION%^^{}"') do set "PEELED_TAG=%%T"
    if defined PEELED_TAG set "REMOTE_TAG=!PEELED_TAG!"

    if /I not "!REMOTE_TAG!"=="!LOCAL_HEAD!" (
        color 0C
        echo [STOP] Tag %VERSION% already exists on another commit.
        pause
        exit /b 61
    )
    echo [ OK ] Existing tag can be reused.
) else (
    echo [ OK ] Tag %VERSION% is available.
)

echo.
echo [7/9] Building Windows release...

mkdir "%PUBLISH_DIR%" >nul 2>&1
mkdir "%ASSET_DIR%" >nul 2>&1

dotnet restore "%PROJECT%"
if errorlevel 1 goto :build_failed

dotnet publish "%PROJECT%" ^
  -c Release ^
  -r win-x64 ^
  --self-contained true ^
  -p:PublishSingleFile=true ^
  -p:IncludeNativeLibrariesForSelfExtract=true ^
  -p:DebugType=None ^
  -p:DebugSymbols=false ^
  -p:Version="%NUM_VERSION%" ^
  -p:FileVersion="%NUM_VERSION%.0" ^
  -p:AssemblyVersion="%NUM_VERSION%.0" ^
  -o "%PUBLISH_DIR%"

if errorlevel 1 goto :build_failed

if not exist "%PUBLISH_DIR%\KiLabenSetup.exe" (
    color 0C
    echo [STOP] Publish completed but KiLabenSetup.exe was not found.
    pause
    exit /b 71
)
echo [ OK ] KiLabenSetup.exe built.

echo.
echo [8/9] Packaging release...

pushd "%PUBLISH_DIR%"
tar -a -c -f "..\assets\%ZIP_NAME%" *
set "TAR_RESULT=!ERRORLEVEL!"
popd

if not "!TAR_RESULT!"=="0" (
    color 0C
    echo [STOP] Failed to create ZIP.
    pause
    exit /b 80
)

set "HASH="
for /f "usebackq skip=1 tokens=*" %%H in (`certutil -hashfile "%ZIP_PATH%" SHA256 ^| findstr /V /C:"CertUtil:"`) do (
    if not defined HASH (
        set "HASH=%%H"
        set "HASH=!HASH: =!"
    )
)
if not defined HASH (
    color 0C
    echo [STOP] Could not calculate SHA256.
    pause
    exit /b 81
)

> "%SHA_PATH%" echo !HASH!  %ZIP_NAME%

> "%NOTES_PATH%" (
echo # KI-Laben Setup %VERSION%
echo.
echo First public GitHub release of KI-Laben Setup Launchpad.
echo.
echo ## Highlights
echo.
echo - Modern Windows onboarding experience for KI-Laben
echo - KI-Laben work-email onboarding
echo - Browser selection and guided browser download
echo - Discord download and setup
echo - Google Workspace and ChatGPT onboarding
echo - Built-in AI help architecture with a separate server-side gateway
echo - Local setup progress
echo - Dark Launchpad UI with animations
echo.
echo ## Windows
echo.
echo Download `%ZIP_NAME%`, extract it, and start `KiLabenSetup.exe`.
echo.
echo The Windows x64 package is self-contained, so end users do not need to install the .NET runtime separately.
echo.
echo ## Integrity
echo.
echo SHA256: `!HASH!`
echo.
echo ## Build
echo.
echo Source commit: `!SHORT_HEAD!`
echo Framework: .NET 10 / Windows Forms
echo Runtime: Windows x64
echo.
echo ## Security
echo.
echo AI credentials are not embedded in the desktop client. The AI integration uses a separate gateway.
)

echo [ OK ] ZIP: %ZIP_NAME%
echo [ OK ] SHA256: !HASH!

echo.
echo [9/9] Publishing GitHub Release...

if not defined REMOTE_TAG (
    git tag -l "%VERSION%" | findstr /X /C:"%VERSION%" >nul
    if errorlevel 1 (
        git tag -a "%VERSION%" -m "KI-Laben Setup %VERSION% - First Release"
        if errorlevel 1 (
            color 0C
            echo [STOP] Could not create Git tag.
            pause
            exit /b 90
        )
    )

    git push origin "%VERSION%"
    if errorlevel 1 (
        color 0C
        echo [STOP] Could not push release tag.
        pause
        exit /b 91
    )
)

gh release create "%VERSION%" ^
  "%ZIP_PATH%" ^
  "%SHA_PATH%" ^
  --repo "%REPO%" ^
  --verify-tag ^
  --title "KI-Laben Setup %VERSION% - First Release" ^
  --notes-file "%NOTES_PATH%"

if errorlevel 1 (
    color 0C
    echo.
    echo [STOP] Build and tag succeeded, but GitHub Release creation failed.
    echo Run this BAT again after fixing GitHub CLI access.
    pause
    exit /b 92
)

color 0A
echo.
echo ============================================================
echo.
echo                  FIRST RELEASE IS LIVE
echo.
echo ============================================================
echo.
echo   Version : %VERSION%
echo   Commit  : !SHORT_HEAD!
echo   Package : %ZIP_NAME%
echo.
echo   %REPO_WEB%/releases/tag/%VERSION%
echo.
start "" "%REPO_WEB%/releases/tag/%VERSION%"
pause
exit /b 0

:build_failed
color 0C
echo.
echo ============================================================
echo                       BUILD FAILED
echo ============================================================
echo.
echo No release tag was created.
echo Fix the build error and run this BAT again.
echo.
pause
exit /b 70
