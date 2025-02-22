# Tools and Demo Based on Existing .NET JSON Schema Components

While there are variety of [JSON schema tools](https://json-schema.org/tools) since the introduction of [JSON schema](https://json-schema.org/), this project is focused on the following:

1. Existing .NET (Framework) components that can generate JSON schema from POCO classes or generate POCO classes from JSON Schema.
1. Introduce locally run tools.
1. Develop CLI tools.
1. Compare with different components of generating JSON schema.


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


### NJsonSchema

References:
* https://github.com/RicoSuter/NJsonSchema

### [NewtonSoft.Json](https://www.newtonsoft.com/jsonschema)

The vendor provides an online validator on: https://www.jsonschemavalidator.net/

### JSON Everything

References:
* https://json-everything.net/