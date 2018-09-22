using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CommandLineParserExample
{
    [Verb("pack", HelpText = "Pack input files.")]
    public class PackOptions : Options, IVerb
    {
        public void Run()
        {
            Console.WriteLine($"Parsed {GetType().Name}:");
            Console.WriteLine(ToString());
        }
    }
}
