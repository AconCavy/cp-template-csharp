param (
  [Parameter(Mandatory = $true)]
  [string] $Tag
)

$OutputPath = Join-Path $(Split-Path $PSScriptRoot -Parent) "publish"
$Tag -match "(?<Version>\d+\.\d+\..*$)" | Out-Null
$Version = $Matches.Version;

dotnet pack ./CPTemplate.csproj --configuration Release --output $OutputPath -p:PackageVersion=$Version
