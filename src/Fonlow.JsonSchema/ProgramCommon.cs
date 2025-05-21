using Fonlow.Cli;

namespace Fonlow.JsonSchema
{
	public static class ProgramCommon
	{
		public static int Execute(Func<Options, bool> customExtraction, string[] args)
		{
			var options = new Options();
			var parser = new CommandLineParser(options);
			Console.WriteLine(parser.ApplicationDescription);

			parser.Parse();
			if (args.Length == 0 || options.Help)
			{
				Console.WriteLine(parser.UsageInfo.ToString());

				return 1;
			}

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
				var r = customExtraction(options);
				Console.WriteLine(r ? "Done." : "Failed.");
			}

			return 0;
		}
	}
}
