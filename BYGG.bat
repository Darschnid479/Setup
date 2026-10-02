@echo off
setlocal EnableExtensions EnableDelayedExpansion
cd /d "%~dp0"
title KI-LABEN // LAUNCHPAD 2026 BUILD
color 0B

call :banner

where dotnet >nul 2>nul
if errorlevel 1 goto :no_dotnet

set "HAS10="
for /f "tokens=1" %%V in ('dotnet --list-sdks 2^>nul') do (
  echo %%V | findstr /R /B "10\." >nul && set "HAS10=1"
)
if not defined HAS10 goto :wrong_sdk

for /f "delims=" %%V in ('dotnet --version') do set "SDK=%%V"
echo     [SDK] .NET !SDK!
echo     [IDE] Visual Studio 2026 / .NET 10 WinForms
echo     [SEC] No admin. No policy changes. No PowerShell scripts.
echo.

if not exist "build-logs" mkdir "build-logs"
if not exist "utgivelse" mkdir "utgivelse"

call :stage 1 "Logic self-tests"
dotnet run --project "Tests\SelfTest.vbproj" -c Release >"build-logs\01-selftest.log" 2>&1
if errorlevel 1 goto :fail1
call :ok "Logic self-tests"

call :stage 2 "Restore .NET 10 desktop project"
dotnet restore "KiLabenSetup\KiLabenSetup.vbproj" -r win-x64 >"build-logs\02-restore.log" 2>&1
if errorlevel 1 goto :fail2
call :ok "Restore"

call :stage 3 "Build Windows Forms app"
dotnet build "KiLabenSetup\KiLabenSetup.vbproj" -c Release --no-restore -r win-x64 >"build-logs\03-build.log" 2>&1
if errorlevel 1 goto :fail3
call :ok "Windows Forms build"

call :stage 4 "Build AI gateway"
dotnet build "KiLabenAiGateway\KiLabenAiGateway.csproj" -c Release >"build-logs\04-ai.log" 2>&1
if errorlevel 1 goto :fail4
call :ok "AI gateway"

call :stage 5 "Publish self-contained Windows release"
dotnet publish "KiLabenSetup\KiLabenSetup.vbproj" -c Release -r win-x64 --self-contained true -p:PublishSingleFile=false -o "utgivelse" >"build-logs\05-publish.log" 2>&1
if errorlevel 1 goto :fail5
call :ok "Publish"

color 0A
echo.
echo     ==============================================================
echo                    LAUNCHPAD 2026  //  READY
echo     ==============================================================
echo.
echo       [OK]  utgivelse\KiLabenSetup.exe
echo       [OK]  Self-contained Windows x64 release
echo       [OK]  .NET 10 / Visual Studio 2026 project
echo.
echo       Del HELE utgivelse-mappen hvis programmet skal flyttes.
echo.
goto :end_ok

:banner
cls
echo.
echo     ==============================================================
echo               K I - L A B E N   //   L A U N C H P A D
echo                         2 0 2 6   B U I L D
echo     ==============================================================
echo.
echo           SOURCE  ^>  CHECK  ^>  BUILD  ^>  AI  ^>  RELEASE
echo.
call :pulse
exit /b 0

:pulse
<nul set /p="     Booting build deck  "
for %%A in (. .. ... .... .....) do (
  <nul set /p="%%A"
  ping 127.0.0.1 -n 1 -w 120 >nul
)
echo.
echo.
exit /b 0

:stage
echo     --------------------------------------------------------------
echo       [%1/5] %~2
echo     --------------------------------------------------------------
<nul set /p="       "
for %%A in ([.] [::] [:::] [::::]) do (
  <nul set /p="%%A"
  ping 127.0.0.1 -n 1 -w 100 >nul
)
echo.
exit /b 0

:ok
echo       [OK] %~1
echo.
exit /b 0

:no_dotnet
color 0E
echo     [STOP] dotnet ble ikke funnet.
echo.
echo     Installer Visual Studio 2026 med:
echo       - .NET desktop development
echo       - .NET 10 SDK
goto :end_fail

:wrong_sdk
color 0E
echo     [STOP] .NET 10 SDK mangler.
echo.
echo     Denne utgaven er laget for Visual Studio 2026.
echo     Apne Visual Studio Installer ^> Modify og installer:
echo       - .NET desktop development
echo       - .NET 10 SDK
echo.
echo     Kontroller etterpa med: dotnet --list-sdks
goto :end_fail

:fail1
set "LOG=build-logs\01-selftest.log"
goto :build_fail
:fail2
set "LOG=build-logs\02-restore.log"
goto :build_fail
:fail3
set "LOG=build-logs\03-build.log"
goto :build_fail
:fail4
set "LOG=build-logs\04-ai.log"
goto :build_fail
:fail5
set "LOG=build-logs\05-publish.log"
goto :build_fail

:build_fail
color 0C
echo.
echo     [BUILD FAILED]
echo     Logg: %LOG%
echo.
echo     ---- siste linjer ----
type "%LOG%"
echo     ----------------------
goto :end_fail

:end_ok
echo.
pause
exit /b 0

:end_fail
echo.
echo     Ingen sikkerhetsinnstillinger ble endret.
echo     Se Dokumentasjon\VISUAL-STUDIO-2026.md og build-logs.
echo.
pause
exit /b 1
