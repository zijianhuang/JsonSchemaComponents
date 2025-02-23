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

### [.NET 9 Extract SChema](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/extract-schema)


### [NJsonSchema](https://github.com/RicoSuter/NJsonSchema)

### [NewtonSoft.Json](https://www.newtonsoft.com/jsonschema)

Online validator on: https://www.jsonschemavalidator.net/ which can validate draft v3 to 2020-12.

### [JSON Everything](https://json-everything.net/)

Online validator on: https://json-everything.net/json-schema for Draft 6 to 2020-12

