function Publish-Release {
  param (
    [Parameter(Mandatory = $true)] [string] $Tag,
    [PSDefaultValue(Help = "./publish")] [string] $Path = "./publish"
  )

  $PreRelease = $Tag -like 'v*-*' ? '-p' : ""
  $Version = $Tag.Substring(1)

  dotnet pack ./CPTemplate.csproj --configuration Release --output $Path -p:PackageVersion=$Version
  
  $Assets = @()
  Get-ChildItem -Path $Path |
  ForEach-Object {
    $Target = $_.Name
    $Assets += "./$Path/$Target"
  }

  gh release create $Tag $Assets $PreRelease
}