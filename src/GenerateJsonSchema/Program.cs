using System.Text.Json.Nodes;
using System.Text.Json;
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

			if (!string.IsNullOrEmpty(options.OutputPath))
			{
				var r = CustomExtraction(options);
				Console.WriteLine(r ? "Done." : "Failed.");
			}

			return 0;
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
