using Fonlow.Cli;
using Fonlow.JsonSchema;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace GenerateSchemaWithNewtonSoft
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

			JSchemaGenerator generator = new JSchemaGenerator();
			generator.DefaultRequired = Required.Default; //otherwise, most fields particularily string fields are required.
			JSchema schema = generator.Generate(type);
			schema.Title = options.Title;
			schema.Description = options.Description;
			//schema.SchemaVersion = SchemaVersion.Draft6.;
			using var fs = new FileStream(options.OutputPath, FileMode.Create);
			using var writer = new StreamWriter(fs);
			using var jsonTextWriter = new JsonTextWriter(writer){ Formatting= Formatting.Indented };
			schema.WriteTo(jsonTextWriter);

			return true;
		}
	}
}
