# Run debug build to generate schema to folder Example
Set-Location $PSScriptRoot
./bin/Debug/net9.0/GenerateSchemaWithJsonSchemaNet.exe /op=Example/CodeGenSchema.json /c=Fonlow.CodeDom.Web.CodeGenSettings /a=../DataModels/bin/Debug/net9.0/DataModels.dll
