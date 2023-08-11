param (
  [Parameter(Mandatory = $true)]
  [string] $Tag
)

$ProjectRootPath = (Split-Path $PSScriptRoot -Parent);
$AssetsPath = Join-Path $ProjectRootPath "publish"
$PreRelease = $Tag -like 'v*-*' ? '-p' : ""

$Assets = @()
Get-ChildItem -Path $AssetsPath |
ForEach-Object {
  $Assets += "$ProjectRootPath/$($_.Name)"
}

gh release create $Tag $Assets $PreRelease
