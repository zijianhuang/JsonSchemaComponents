using System;
using Fonlow.Cli;
using Plossum.CommandLine;

namespace Fonlow.JsonSchema
{
	[CommandLineManager(ApplicationName = "JSON Schema Generator", Description = "Generate JSON Schema from a POCO class.", OptionSeparator = "/", Assignment = ":", Copyright = "Fonlow (c) 2025", Version = "1.0")]
	[CommandLineOptionGroup("detail", Name = "Detail")]
	[CommandLineOptionGroup("other", Name = "Other")]
	public class Options
	{
		public Options()
		{
		}
		[CommandLineOption(Aliases = "C", Description = "Class name including namespace, e.g., /C=My.Namespace.MyClass")]
		public string ClassName { get; set; }

		[CommandLineOption(Aliases = "A", Description = "Assembly file name including file extension. e.g., /A=abc.dll")]
		public string AssemblyFile { get; set; }

		[CommandLineOption(Aliases = "OP", Description = "File path of the JSON schema output. e.g., /OP=c:/temp/MyJsonSchema.json")]
		public string OutputPath { get; set; }

		[CommandLineOption(Aliases = "h ?", Name = "Help", Description = "Shows this help text")]
		public bool Help
		{
			get;
			set;
		}


	}
}
