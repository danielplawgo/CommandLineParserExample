using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json;

namespace CommandLineParserExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //OptionsTest(args);

            //VerbsTest(args);

            DynamicVerbsTest(args);
        }

        // examples:
        // -f result.json file1.txt file2.txt file3.txt
        // --help
        // --version
        private static void OptionsTest(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);

            result
                .WithParsed(r => Run(r));
        }

        // examples:
        // pack -f result.json file1.txt file2.txt file3.txt
        // test -f result.json file1.txt file2.txt file3.txt
        private static void VerbsTest(string[] args)
        {
            var result = Parser.Default.ParseArguments<PackOptions, TestOptions>(args);

            result
                .WithParsed<PackOptions>(r => Run(r))
                .WithParsed<TestOptions>(r => Run(r));
        }

        // examples:
        // pack -f result.json file1.txt file2.txt file3.txt
        // test -f result.json file1.txt file2.txt file3.txt
        private static void DynamicVerbsTest(string[] args)
        {
            var iverb = typeof(IVerb);

            var verbs = typeof(Program).Assembly.GetTypes().Where(t => iverb.IsAssignableFrom(t));

            var result = Parser.Default.ParseArguments(args, verbs.ToArray());

            result
                .WithParsed<IVerb>(r => r.Run());
        }

        private static void Run(Options options)
        {
            Console.WriteLine($"Parsed {options.GetType().Name}:");
            Console.WriteLine(options.ToString());
        }
    }
}
