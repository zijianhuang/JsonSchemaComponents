using System.Text.Json.Nodes;
using System.Text.Json;
using Fonlow.CodeDom.Web;
using System.Text.Json.Serialization;
using System.Text.Json.Schema;

namespace GenerateJsonSchema
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Generate JSON schema...");
			Console.WriteLine("Accept parameter: filePath");
			if (args.Length > 0)
			{
				var filePath = args[0];
				CustomExtraction(filePath);
				Console.WriteLine("Done.");
			}
		}

		public static void CustomExtraction(string filePath)
		{
			JsonSerializerOptions options = new(JsonSerializerOptions.Default)
			{
				//PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
				//NumberHandling = JsonNumberHandling.WriteAsString,
				//UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
			};

			JsonNode schema = options.GetJsonSchemaAsNode(typeof(CodeGenSettings));
			using var fs = new FileStream(filePath, FileMode.Create);
			using var writer = new Utf8JsonWriter(fs, new JsonWriterOptions{
				Indented = true,
			});
			schema.WriteTo(writer);
			//Console.WriteLine(schema.ToString());
		}
	}
}
