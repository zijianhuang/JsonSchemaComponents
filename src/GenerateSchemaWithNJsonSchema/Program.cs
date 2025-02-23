using Fonlow.Cli;
using Fonlow.JsonSchema;
using NJsonSchema;

namespace GenerateSchemaWithNJsonSchema
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
				Console.WriteLine(parser.ErrorMessage);
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

			var schema = JsonSchema.FromType(type);
			schema.Title = options.Title;
			schema.Description = options.Description;
			var schemaData = schema.ToJson(Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(options.OutputPath, schemaData);
			return true;
		}
	}
}
