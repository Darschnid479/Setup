@echo off
setlocal EnableExtensions EnableDelayedExpansion
title KI-Laben Setup - First GitHub Release
color 0B

rem ============================================================
rem  KI-LABEN SETUP - FIRST GITHUB RELEASE
rem
rem  Default release: v2026.2.0
rem  Repo: Darschnid479/Setup
rem
rem  Usage:
rem    FIRST_RELEASE_GITHUB.bat
rem    FIRST_RELEASE_GITHUB.bat v2026.3.0
rem
rem  This script:
rem    - checks Git, GitHub CLI and .NET 10
rem    - verifies main is clean and synced with GitHub
rem    - builds a self-contained Windows x64 release
rem    - creates a ZIP + SHA256 checksum + release notes
rem    - creates/pushes an annotated Git tag
rem    - creates the GitHub Release and uploads the files
rem
rem  It does NOT use PowerShell.
rem  It does NOT force-push.
rem  It does NOT change Windows security settings.
rem ============================================================

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

cd /d "%~dp0"
cls

echo.
echo ============================================================
echo.
echo        KI-LABEN SETUP  /  FIRST RELEASE LAUNCHER
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

rem ------------------------------------------------------------
rem 0. Confirm
rem ------------------------------------------------------------
choice /C YN /N /M "Create and publish %VERSION% now? [Y/N]: "
if errorlevel 2 (
    echo.
    echo Cancelled. Nothing was changed.
    pause
    exit /b 0
)

rem ------------------------------------------------------------
rem 1. Check required tools
rem ------------------------------------------------------------
echo.
echo [1/8] Checking tools...

where git >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Git is not installed or is not in PATH.
    start "" "https://git-scm.com/download/win"
    pause
    exit /b 10
)
for /f "delims=" %%G in ('git --version') do echo [ OK ] %%G

where gh >nul 2>&1
if errorlevel 1 (
    color 0E
    echo.
    echo [STOP] GitHub CLI ^(gh^) is required to create the Release.
    echo        Opening the official GitHub CLI page...
    start "" "https://cli.github.com/"
    echo.
    echo Install GitHub CLI, then run this BAT again.
    pause
    exit /b 11
)
for /f "tokens=1,2,3" %%A in ('gh --version ^| findstr /B /C:"gh version"') do echo [ OK ] GitHub CLI %%C

where dotnet >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] dotnet was not found.
    echo Install Visual Studio 2026 with .NET desktop development and .NET 10 SDK.
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
    echo Install .NET 10 SDK / Visual Studio 2026 .NET desktop development.
    pause
    exit /b 13
)
echo [ OK ] .NET 10 SDK found.

if not exist "%PROJECT%" (
    color 0C
    echo [STOP] Project not found:
    echo        %CD%\%PROJECT%
    echo.
    echo Put this BAT in the repository root next to KiLabenSetup.
    pause
    exit /b 14
)

where tar >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Windows tar.exe was not found. Cannot create release ZIP.
    pause
    exit /b 15
)
echo [ OK ] Packaging tools ready.

rem ------------------------------------------------------------
rem 2. Verify repository and origin
rem ------------------------------------------------------------
echo.
echo [2/8] Checking repository...

if not exist ".git\" (
    color 0C
    echo [STOP] This folder is not a Git repository.
    echo Run the GitHub uploader BAT first.
    pause
    exit /b 20
)

for /f "delims=" %%B in ('git branch --show-current 2^>nul') do set "CURRENT_BRANCH=%%B"
if /I not "!CURRENT_BRANCH!"=="%BRANCH%" (
    color 0E
    echo [STOP] Current branch is "!CURRENT_BRANCH!", not "%BRANCH%".
    echo Switch to main and run this BAT again.
    pause
    exit /b 21
)
echo [ OK ] Branch: %BRANCH%

git remote get-url origin >nul 2>&1
if errorlevel 1 (
    color 0C
    echo [STOP] Git remote "origin" is missing.
    pause
    exit /b 22
)

for /f "delims=" %%R in ('git remote get-url origin') do set "ORIGIN=%%R"
if /I not "!ORIGIN!"=="%REPO_URL%" (
    color 0E
    echo [STOP] origin points to:
    echo        !ORIGIN!
    echo.
    echo Expected:
    echo        %REPO_URL%
    pause
    exit /b 23
)
echo [ OK ] Origin: !ORIGIN!

rem ------------------------------------------------------------
rem 3. Require clean working tree and synced main
rem ------------------------------------------------------------
echo.
echo [3/8] Verifying source state...

for /f "delims=" %%S in ('git status --porcelain') do set "DIRTY=1"
if defined DIRTY (
    color 0E
    echo [STOP] There are uncommitted changes.
    echo.
    git status --short
    echo.
    echo Commit/push them first, then run this release BAT again.
    pause
    exit /b 30
)
echo [ OK ] Working tree is clean.

echo [ .. ] Checking GitHub login...
gh auth status -h github.com >nul 2>&1
if errorlevel 1 (
    echo [LOGIN] A browser login will open.
    gh auth login --hostname github.com --git-protocol https --web
    if errorlevel 1 (
        color 0C
        echo [STOP] GitHub login was not completed.
        pause
        exit /b 31
    )
)
gh auth setup-git >nul 2>&1
echo [ OK ] GitHub authentication ready.

echo [ .. ] Fetching origin...
git fetch origin
if errorlevel 1 (
    color 0C
    echo [STOP] Could not fetch from GitHub.
    pause
    exit /b 32
)

git show-ref --verify --quiet refs/remotes/origin/%BRANCH%
if errorlevel 1 (
    color 0C
    echo [STOP] origin/%BRANCH% does not exist yet.
    echo Push main to GitHub before making a release.
    pause
    exit /b 33
)

for /f "delims=" %%L in ('git rev-parse HEAD') do set "LOCAL_HEAD=%%L"
for /f "delims=" %%R in ('git rev-parse origin/%BRANCH%') do set "REMOTE_HEAD=%%R"

if /I not "!LOCAL_HEAD!"=="!REMOTE_HEAD!" (
    color 0E
    echo [STOP] Local main and GitHub main are not identical.
    echo.
    echo Local : !LOCAL_HEAD!
    echo Remote: !REMOTE_HEAD!
    echo.
    echo Sync/push main first. Release was NOT created.
    pause
    exit /b 34
)
for /f "delims=" %%H in ('git rev-parse --short HEAD') do set "SHORT_HEAD=%%H"
echo [ OK ] main is synced at !SHORT_HEAD!.

rem ------------------------------------------------------------
rem 4. Refuse to overwrite an existing GitHub release
rem ------------------------------------------------------------
echo.
echo [4/8] Checking release tag...

gh release view "%VERSION%" --repo "%REPO%" >nul 2>&1
if not errorlevel 1 (
    color 0E
    echo [STOP] GitHub Release %VERSION% already exists.
    start "" "%REPO_WEB%/releases/tag/%VERSION%"
    pause
    exit /b 40
)

set "REMOTE_TAG="
for /f "tokens=1" %%T in ('git ls-remote --tags origin "refs/tags/%VERSION%"') do set "REMOTE_TAG=%%T"

if defined REMOTE_TAG (
    rem Annotated tags can return the tag object hash. Resolve remote peeled hash when possible.
    set "PEELED_TAG="
    for /f "tokens=1" %%T in ('git ls-remote --tags origin "refs/tags/%VERSION%^^{}"') do set "PEELED_TAG=%%T"
    if defined PEELED_TAG set "REMOTE_TAG=!PEELED_TAG!"

    if /I not "!REMOTE_TAG!"=="!LOCAL_HEAD!" (
        color 0C
        echo [STOP] Tag %VERSION% already exists on GitHub but points elsewhere.
        echo Release was NOT created.
        pause
        exit /b 41
    )
    echo [ OK ] Existing tag %VERSION% points to current commit. It can be reused.
) else (
    echo [ OK ] Tag %VERSION% is available.
)

rem ------------------------------------------------------------
rem 5. Build release
rem ------------------------------------------------------------
echo.
echo [5/8] Building KI-Laben Setup...

if exist "%PUBLISH_DIR%\" rmdir /S /Q "%PUBLISH_DIR%"
if exist "%ASSET_DIR%\" rmdir /S /Q "%ASSET_DIR%"
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
    echo [STOP] Build reported success, but KiLabenSetup.exe was not found.
    pause
    exit /b 51
)
echo [ OK ] Windows executable built.

rem ------------------------------------------------------------
rem 6. Package ZIP + checksum + notes
rem ------------------------------------------------------------
echo.
echo [6/8] Creating release package...

if exist "%ZIP_PATH%" del /Q "%ZIP_PATH%" >nul 2>&1

pushd "%PUBLISH_DIR%"
tar -a -c -f "..\assets\%ZIP_NAME%" *
set "TAR_RESULT=!ERRORLEVEL!"
popd

if not "!TAR_RESULT!"=="0" (
    color 0C
    echo [STOP] Failed to create ZIP.
    pause
    exit /b 60
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
    exit /b 61
)

> "%SHA_PATH%" echo !HASH!  %ZIP_NAME%

> "%NOTES_PATH%" (
echo # KI-Laben Setup %VERSION%
echo.
echo First GitHub release of KI-Laben Setup Launchpad.
echo.
echo ## Highlights
echo.
echo - Modern Windows onboarding experience for KI-Laben
echo - Guided work-email setup using the KI-Laben account
echo - Browser selection and guided browser download
echo - Discord download and setup flow
echo - Google Workspace and ChatGPT onboarding
echo - Built-in AI help architecture with a separate server-side gateway
echo - Local progress saving
echo - Modern dark Launchpad interface and animations
echo.
echo ## Windows package
echo.
echo The attached Windows x64 ZIP is self-contained. End users do not need the .NET runtime installed to run the published application.
echo.
echo Extract the ZIP and start `KiLabenSetup.exe`.
echo.
echo ## Integrity
echo.
echo A SHA256 checksum file is attached next to the Windows package.
echo.
echo ## Build
echo.
echo Source commit: !SHORT_HEAD!
echo Target: Windows x64
echo Framework: .NET 10 / Windows Forms
echo.
echo ## Notes
echo.
echo The AI gateway is intentionally separate from the desktop client so API credentials are not embedded in the distributed application.
)

echo [ OK ] %ZIP_NAME%
echo [ OK ] SHA256: !HASH!
echo [ OK ] Release notes created.

rem ------------------------------------------------------------
rem 7. Create/push tag if needed
rem ------------------------------------------------------------
echo.
echo [7/8] Creating release tag...

if not defined REMOTE_TAG (
    git tag -l "%VERSION%" | findstr /X /C:"%VERSION%" >nul
    if not errorlevel 1 (
        for /f "delims=" %%T in ('git rev-list -n 1 "%VERSION%"') do set "LOCAL_TAG_HEAD=%%T"
        if /I not "!LOCAL_TAG_HEAD!"=="!LOCAL_HEAD!" (
            color 0C
            echo [STOP] Local tag %VERSION% already exists on another commit.
            pause
            exit /b 70
        )
    ) else (
        git tag -a "%VERSION%" -m "KI-Laben Setup %VERSION% - First Release"
        if errorlevel 1 (
            color 0C
            echo [STOP] Could not create Git tag.
            pause
            exit /b 71
        )
    )

    git push origin "%VERSION%"
    if errorlevel 1 (
        color 0C
        echo [STOP] Could not push release tag.
        pause
        exit /b 72
    )
)
echo [ OK ] Tag %VERSION% is on GitHub.

rem ------------------------------------------------------------
rem 8. Create GitHub release
rem ------------------------------------------------------------
echo.
echo [8/8] Publishing GitHub Release...

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
    echo [STOP] Tag/build succeeded, but GitHub Release creation failed.
    echo.
    echo The tag is already safe on GitHub. Fix the GitHub CLI issue and
    echo run this BAT again; it will reuse the existing tag.
    pause
    exit /b 80
)

color 0A
echo.
echo ============================================================
echo.
echo                   FIRST RELEASE IS LIVE
echo.
echo ============================================================
echo.
echo   Release : %VERSION%
echo   Commit  : !SHORT_HEAD!
echo   Asset   : %ZIP_NAME%
echo.
echo   %REPO_WEB%/releases/tag/%VERSION%
echo.
echo Opening the release page...
start "" "%REPO_WEB%/releases/tag/%VERSION%"
echo.
pause
exit /b 0

:build_failed
color 0C
echo.
echo ============================================================
echo                       BUILD FAILED
echo ============================================================
echo.
echo No tag or GitHub Release was created.
echo Fix the build error first and run this BAT again.
echo.
pause
exit /b 50
