# Run debug build to generate schema to folder Example
Set-Location $PSScriptRoot
./bin/Debug/net9.0/GenerateJsonSchema.exe /c=Fonlow.CodeDom.Web.CodeGenSettings /a "../DataModels/bin/Debug/net9.0/DataModels.dll" /op "Example/CodeGenSchema.json" /Title "CodeGen Meta of WebApiClientGen" /d "POST to CodeGen controller"
