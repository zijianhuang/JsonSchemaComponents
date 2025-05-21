using Fonlow.Cli;
using Fonlow.JsonSchema;
using Json.Schema;
using Json.Schema.Generation;
using System.Text.Json;

namespace GenerateSchemaWithJsonSchemaNet
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

			var schemaBuilder = new JsonSchemaBuilder()
				.Title(options.Title)
				.Description(options.Description);
			JsonSchema schema = schemaBuilder.FromType(type).Build();
			var converter = new SchemaJsonConverter();
			using var fs = new FileStream(options.OutputPath, FileMode.Create);
			using var writer = new Utf8JsonWriter(fs, new JsonWriterOptions
			{
				Indented = true,
			});
			converter.Write(writer, schema, new JsonSerializerOptions { WriteIndented = true });
			return true;
		}
	}
}
