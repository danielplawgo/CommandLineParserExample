using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CommandLineParserExample
{
    [Verb("test", HelpText = "Test packing input files.")]
    public class TestOptions : Options, IVerb
    {
        public void Run()
        {
            Console.WriteLine($"Parsed {GetType().Name}:");
            Console.WriteLine(ToString());
        }
    }
}
