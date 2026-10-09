[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string] $MelonLoaderRoot,

    [string] $DotNet = "dotnet",

    [string] $ExpectedAssemblySha256 = "CEC1F3D02B38CEBB59A977FB8C23400094203C63FF7AAA5094143925475BB2CC",

    [string] $TargetGameVersion = "0.4.7f12"
)

$ErrorActionPreference = "Stop"
$repositoryRoot = Split-Path -Parent $PSScriptRoot

& (Join-Path $PSScriptRoot "verify-game-api.ps1") `
    -MelonLoaderRoot $MelonLoaderRoot `
    -ExpectedAssemblySha256 $ExpectedAssemblySha256 `
    -TargetGameVersion $TargetGameVersion
if ($LASTEXITCODE) {
    exit $LASTEXITCODE
}

& $DotNet build (Join-Path $repositoryRoot "ImprovedPackagers.Il2Cpp.csproj") `
    --configuration Release `
    --property:MelonLoaderRoot="$MelonLoaderRoot" `
    --nologo

if ($LASTEXITCODE) {
    exit $LASTEXITCODE
}

$outputPath = Join-Path $repositoryRoot "bin\Il2Cpp\ImprovedPackagersPORTED.dll"
if (-not (Test-Path -LiteralPath $outputPath -PathType Leaf)) {
    throw "Build completed without the expected output: $outputPath"
}

Write-Output "Built $outputPath"
