using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fonlow.JsonSchema
{
	public static class TypeHelper
	{
		static TypeHelper()
		{
			AppDomain appDomain = AppDomain.CurrentDomain;
			appDomain.AssemblyResolve += AppDomain_AssemblyResolve;
		}

		public static Type GetTypeFromAssembly(string assemblyFilePath, string className)
		{
			string absolutePath = System.IO.Path.GetFullPath(assemblyFilePath);
			Assembly assembly = LoadAssemblyFile(absolutePath);
			if (assembly == null)
				return null;

			try
			{
				return assembly.GetType(className);
			}
			catch (ReflectionTypeLoadException e)
			{
				foreach (Exception ex in e.LoaderExceptions)
				{
					Trace.TraceWarning(String.Format("When loading {0}, GetTypes errors occur: {1}", assembly.FullName, ex.Message));
				}

				return null;
			}
			catch (TargetInvocationException e)
			{
				Trace.TraceWarning(String.Format("When loading {0}, GetTypes errors occur: {1}", assembly.FullName, e.Message + "~~" + e.InnerException.Message));
				return null;
			}
		}

		static System.Reflection.Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			System.Reflection.Assembly assembly;
			try
			{
				if (args.RequestingAssembly == null)
					return null;

				assembly = System.Reflection.Assembly.Load(args.Name);
				Console.WriteLine("Load {0} that {1} depends on.", args.Name, args.RequestingAssembly.FullName);
				return assembly;
			}
			catch (System.IO.FileNotFoundException e)
			{
				Console.WriteLine(e.ToString());
				string dirOfRequestingAssembly = System.IO.Path.GetDirectoryName(args.RequestingAssembly.Location);
				string assemblyShortName = args.Name.Substring(0, args.Name.IndexOf(','));
				string assemblyFullPath = System.IO.Path.Combine(dirOfRequestingAssembly, assemblyShortName + ".dll");//hopefully nobody would use exe for the dependency.
				assembly = System.Reflection.Assembly.LoadFrom(assemblyFullPath);
				return assembly;
			}
		}

		static Assembly LoadAssemblyFile(string assemblyFilePath)
		{
			try
			{
				return Assembly.LoadFrom(assemblyFilePath);
			}
			catch (Exception ex) when (ex is System.IO.FileLoadException || ex is BadImageFormatException || ex is System.IO.FileNotFoundException || ex is ArgumentException)
			{
				string msg = String.Format("When loading {0}, errors occur: {1}", assemblyFilePath, ex.Message);
				Console.WriteLine(msg);
				Trace.TraceWarning(msg);
				return null;
			}
		}
	}
}
