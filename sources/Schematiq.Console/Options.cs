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
        [Option('t', "root-type", Required = true, HelpText = "Type used as root for producing XML schema")]
        public string RootElementTypeName { get; set; }

        /// <summary>
        /// </summary>
        [Option('r', "root-name", Required = true, HelpText = "Element name for root")]
        public string RootElementName { get; set; }

        /// <summary>
        /// </summary>
        [Option('o', "output", Required = true, HelpText = "Output XML schema file name (.xsd extension is recommended)")]
        public string OutputFileName { get; set; }

        /// <summary>
        /// </summary>
        [Option('f', "format", DefaultValue = false, HelpText = "Format produced XML schema")]
        public bool FormatOutput { get; set; }

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

            helpText.AddPreOptionsLine("Usage: Schematiq.exe -a <assembly_filename> -t <type_name> -r <root_element_name> -o <xsd_filename>");
            helpText.AddOptions(this);

            return helpText;
        }
    }
}