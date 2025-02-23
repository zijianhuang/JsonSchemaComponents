using Fonlow.JsonSchema;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;

namespace GenerateJsonSchema
{
	internal class Program
	{
		static int Main(string[] args)
		{
			return ProgramCommon.Execute(CustomExtraction);
		}

		static bool CustomExtraction(Options options)
		{
			var type = TypeHelper.GetTypeFromAssembly(options.AssemblyFile, options.ClassName);
			if (type == null)
			{
				return false;
			}

			JsonSerializerOptions serializaerOptions = new(JsonSerializerOptions.Default)
			{
				//PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
				//NumberHandling = JsonNumberHandling.WriteAsString,
				//UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
			};

			JsonNode schema = serializaerOptions.GetJsonSchemaAsNode(type);
			// no interface for title and description
			using var fs = new FileStream(options.OutputPath, FileMode.Create);
			using var writer = new Utf8JsonWriter(fs, new JsonWriterOptions
			{
				Indented = true,
			});
			schema.WriteTo(writer);
			//Console.WriteLine(schema.ToString());
			return true;
		}
	}
}
