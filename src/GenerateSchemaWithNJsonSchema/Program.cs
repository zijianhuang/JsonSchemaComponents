﻿using Fonlow.Cli;
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

			var schema = JsonSchema.FromType(type);
			var schemaData = schema.ToJson(Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(outputPath, schemaData);
			return true;
		}
	}
}
