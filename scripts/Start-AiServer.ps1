param()
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
Set-Location $root
Write-Host 'KI-Laben AI gateway - ADMIN WORKSTATION ONLY' -ForegroundColor Cyan
Write-Host 'Never run this setup on a shared participant computer.' -ForegroundColor Yellow
$secure = Read-Host 'OpenAI API key (server only; hidden)' -AsSecureString
$bstr = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($secure)
try { $env:OPENAI_API_KEY = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($bstr) }
finally { [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($bstr) }
$env:OPENAI_MODEL = Read-Host 'API model ID available to this OpenAI project'
$bytes = New-Object byte[] 32
$rng = [Security.Cryptography.RandomNumberGenerator]::Create()
try { $rng.GetBytes($bytes) } finally { $rng.Dispose() }
$env:KILABEN_ACCESS_CODE = [Convert]::ToBase64String($bytes)
$env:KILABEN_CODE_EXPIRES_UTC = [DateTimeOffset]::UtcNow.AddHours(8).ToString('o')
$env:ASPNETCORE_URLS = 'http://127.0.0.1:5088'
Write-Host ''
Write-Host 'Temporary participant code (expires in 8 hours):' -ForegroundColor Green
Write-Host $env:KILABEN_ACCESS_CODE -ForegroundColor White
Write-Host 'Local endpoint: http://127.0.0.1:5088/api/assist' -ForegroundColor Gray
Write-Host 'Remote participants require an HTTPS reverse proxy on the server. Read AI-DRIFT.md.' -ForegroundColor Yellow
try { dotnet run --project KiLabenAiGateway/KiLabenAiGateway.csproj -c Release }
finally {
    Remove-Item Env:OPENAI_API_KEY -ErrorAction SilentlyContinue
    Remove-Item Env:KILABEN_ACCESS_CODE -ErrorAction SilentlyContinue
    Remove-Item Env:KILABEN_CODE_EXPIRES_UTC -ErrorAction SilentlyContinue
}
