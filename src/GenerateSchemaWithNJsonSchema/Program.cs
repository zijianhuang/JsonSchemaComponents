using Fonlow.JsonSchema;
using NJsonSchema;

namespace GenerateSchemaWithNJsonSchema
{
	internal class Program
	{
		static int Main(string[] args)
		{
			return ProgramCommon.Execute(CustomExtraction, args);
		}

		static bool CustomExtraction(Options options)
		{
			var type = TypeHelper.GetTypeFromAssembly(options.AssemblyFile, options.ClassName);
			if (type == null)
			{
				return false;
			}

			var schema = JsonSchema.FromType(type, new NJsonSchema.NewtonsoftJson.Generation.NewtonsoftJsonSchemaGeneratorSettings
			{
				SchemaType= SchemaType.OpenApi3,
				SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
				{
					ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
					Converters = new List<Newtonsoft.Json.JsonConverter>
					{
						new Newtonsoft.Json.Converters.StringEnumConverter()
					}
				}
			});
			schema.Title = options.Title;
			schema.Description = options.Description;
			var schemaData = schema.ToJson(Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(options.OutputPath, schemaData);
			return true;
		}
	}
}
