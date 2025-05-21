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
			return ProgramCommon.Execute(CustomExtraction, args);
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
