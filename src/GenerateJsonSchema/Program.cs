using System.Text.Json.Nodes;
using System.Text.Json;
using Fonlow.CodeDom.Web;
using System.Text.Json.Schema;
using Fonlow.JsonSchema;
using Fonlow.Cli;

namespace GenerateJsonSchema
{
	internal class Program
	{
		static int Main(string[] args)
		{
			var options = new Options();
			var parser = new CommandLineParser(options);
			Console.WriteLine(parser.ApplicationDescription);

			parser.Parse();
			if (parser.HasErrors)
			{
				System.Diagnostics.Trace.TraceWarning(parser.ErrorMessage);
				Console.WriteLine(parser.UsageInfo.GetOptionsAsString());
				return 1;
			}


			if (options.Help)
			{
				Console.WriteLine(parser.UsageInfo.ToString());
				// Console.ReadLine();
				return 0;
			}

			//Console.WriteLine("Generate JSON schema...");
			//Console.WriteLine("Accept parameter: filePath");
			if (!string.IsNullOrEmpty(options.OutputPath))
			{
				CustomExtraction(options.OutputPath);
				Console.WriteLine("Done.");
			}

			return 0;
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
