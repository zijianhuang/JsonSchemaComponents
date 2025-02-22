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
				var r = CustomExtraction(options.OutputPath, options.AssemblyFile, options.ClassName);
				Console.WriteLine(r ? "Done." : "Failed.");
			}

			return 0;
		}

		static bool CustomExtraction(string outputPath, string assemblyFilePath, string className)
		{
			var type = TypeHelper.GetTypeFromAssembly(assemblyFilePath, className);
			if (type == null)
			{
				return false;
			}

			var schemaBuilder = new JsonSchemaBuilder();
			JsonSchema schema = schemaBuilder.FromType(type).Build();
			var converter = new SchemaJsonConverter();
			using var fs = new FileStream(outputPath, FileMode.Create);
			using var writer = new Utf8JsonWriter(fs, new JsonWriterOptions
			{
				Indented = true,
			});
			converter.Write(writer, schema, new JsonSerializerOptions{ WriteIndented=true});
			return true;
		}
	}
}
