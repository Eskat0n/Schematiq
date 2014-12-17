namespace Schematiq.Console
{
    using System.Reflection;
    using CommandLine;
    using CommandLine.Text;

    internal class Options
    {
        /// <summary>
        /// </summary>
        [Option('a', "assembly", Required = true, HelpText = "Input assembly file name")]
        public string AssemblyFileName { get; set; }

        /// <summary>
        /// </summary>
        [Option('t', "type", Required = true, HelpText = "Type used as root for producing XSD schema")]
        public string TypeName { get; set; }

        /// <summary>
        /// </summary>
        [Option('o', "output", Required = true, HelpText = "Output XSD schema file name")]
        public string OutputFileName { get; set; }

        [HelpOption]
        public string GetHelpText()
        {
            var helpText = new HelpText
            {
                Heading = new HeadingInfo("Schematiq", Assembly.GetExecutingAssembly().GetName().Version.ToString()),
                Copyright = new CopyrightInfo("Eskat0n", 2014),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            helpText.AddPreOptionsLine("Usage: Schematiq.exe -a <assembly_filename> -t <type_name> -o <xsd_filename>");
            helpText.AddOptions(this);

            return helpText;
        }
    }
}