Set-Location $PSScriptRoot
$target="../Release/GenerateJsonSchema_win"

Remove-Item -Recurse $target

dotnet publish -r win-x64 --output $target --configuration release --self-contained false

