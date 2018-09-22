using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using Newtonsoft.Json;

namespace CommandLineParserExample
{
    public class Options
    {
        [Option('f', "file", HelpText = "The result file name.", Required = true)]
        public string ResultFile { get; set; }

        [Option('s', "serializer", HelpText = "The result file serializer.", Required = false, Default = "json")]
        public string Serializer { get; set; }

        [Value(0, HelpText = "Input files names.", Required = true)]
        public IEnumerable<string> InputFiles { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
