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

			JSchemaGenerator generator = new JSchemaGenerator();
			JSchema schema = generator.Generate(type);
			using var fs = new FileStream(outputPath, FileMode.Create);
			using var writer = new StreamWriter(fs);
			using var jsonTextWriter = new JsonTextWriter(writer){ Formatting= Formatting.Indented };
			schema.WriteTo(jsonTextWriter);

			return true;
		}
	}
}
