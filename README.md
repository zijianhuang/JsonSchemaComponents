# Tools and Demo Based on Existing .NET JSON Schema Components

While there are variety of [JSON schema tools](https://json-schema.org/tools) since the introduction of [JSON schema](https://json-schema.org/), this project is focused on the following:

1. Existing .NET (Framework) components that can generate JSON schema from POCO classes or generate POCO classes from JSON Schema.
1. Introduce locally run tools.
1. Develop CLI tools.
1. Compare with different components of generating JSON schema.

If a .NET developer who prefer code first approach, you would often create POCO classes first for various purposes, and generate meta data like XML schema, JSON schema, database schema, WSDL and Swagger/OpenAPI definition. The goal of these project is to find the "best" .NET component that can generate JSON schema from a complex POCO class, and the schema can make the hand-crafting of JSON data become convenient with a decent text editor like Visual Studio Code and alike, fully utilizing the data constraints defined in the data model.

## Validation Tools

### Visual Studio

References:
* https://visualstudiomagazine.com/articles/2018/01/24/json-messages-schema.aspx

### Visual Studio Code

References:
* https://code.visualstudio.com/docs/languages/json


## From Schema to C# Codes

### Visual Studio

Go "Main Menu -> Edit -> Paste Special -> Paste JSON as Classes".


## Generating Schema From C#

Plain Old Classes can provide enough info for XML schema and JSON schema. This open source project provides side by side comparisons of some popular components of generating schema from a POCO class.

### [GenerateJsonSchema.exe](GenerateJsonSchema) using [.NET 9 Extract SChema](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/extract-schema)

Usage:
```
GenerateJsonSchema.exe
Generate JSON Schema from a POCO class.
JSON Schema Generator  version 1.0
Fonlow (c) 2025


   /ClassName, /C      Class name including namespace, e.g., /C=My.Namespace.MyClass
   /ClassFile, /CF     Class file path in C# or VB.NET, e.g., /CF=c:/myCsharpClass.cs
   /AssemblyFile, /A   Assembly file name including file extension. e.g., /A=abc.dll
   /OutputPath, /OP    File path of the JSON schema output. e.g., /OP=c:/temp/MyJsonSchema.json
   /Title, /T          Title of schema. e.g., /t='CodeGen meta of WebApiClientGen'
   /Description, /D    Description of schema. e.g., /d 'Post to CodeGen controller of Web API'
   /Help, /h, /?       Shows this help text
```

Example:
```
GenerateJsonSchema.exe /op=c:/temp/demoSchema.json /c=Fonlow.CodeDom.Web.CodeGenSettings /a=DataModels.dll 
```

Hints:
* The other CLI apps has the same set of arguments.

### [GenerateSchemaWithNJsonSchema.exe](GenerateSchemaWithNJsonSchema) using [NJsonSchema](https://github.com/RicoSuter/NJsonSchema)

### [GenerateSchemaWithNewtonSoft.exe](GenerateSchemaWithNewtonSoft) using  [NewtonSoft.Json](https://www.newtonsoft.com/jsonschema)

Online validator on: https://www.jsonschemavalidator.net/ which can validate draft v3 to 2020-12.

### [GenerateSchemaWithJsonSchemaNet.exe](GenerateSchemaWithJsonSchemaNet) using [JSON Everything](https://json-everything.net/)

Online validator on: https://json-everything.net/json-schema for Draft 6 to 2020-12

