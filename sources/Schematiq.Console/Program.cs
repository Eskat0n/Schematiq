namespace Schematiq.Console
{
    using System;
    using System.IO;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options) == false)
                return;

            Assembly inputAssembly;
            Type rootElementType;

            if (LoadInputAssembly(options.AssemblyFileName, out inputAssembly) == false ||
                LoadRootElementType(inputAssembly, options.TypeName, out rootElementType) == false)
                return;

            var xsdGenerator = new XsdGenerator();
            var xsdSchema = xsdGenerator.Generate(rootElementType);

            File.WriteAllText(options.OutputFileName, xsdSchema);
        }

        private static bool LoadInputAssembly(string assemblyFileName, out Assembly inputAssembly)
        {
            inputAssembly = null;

            try
            {
                inputAssembly = Assembly.LoadFile(Path.GetFullPath(assemblyFileName));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR : File not found : {0}", assemblyFileName);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR : Unable to load assembly : {0}", assemblyFileName);
                return false;
            }

            return true;
        }

        private static bool LoadRootElementType(Assembly inputAssembly, string typeName, out Type rootElementType)
        {
            rootElementType = null;

            try
            {
                rootElementType = inputAssembly.GetType(typeName);
            }
            catch
            {
                Console.WriteLine("ERROR : Type not found : {0}", typeName);
                return false;
            }

            return true;
        }
    }
}
