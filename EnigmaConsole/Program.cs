using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Serialization;
using CommandLine;
using EnigmaConsole.CommandLine;
using EnigmaConsole.ViewModel;

namespace EnigmaConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<SignalCommand>(args)
                .WithParsed<SignalCommand>(SignalExecute)
                .WithNotParsed(HandleParseError);

        }

        private static void SignalExecute(SignalCommand opts)
        {
            var baseAddress = new Uri(opts.Url);

            foreach (var loop in Enumerable.Range(1,opts.Repeat))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = baseAddress;

                    var response = client.GetAsync("web/signal").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var serializer = new XmlSerializer(typeof(SignalStatusDto));

                        SignalStatus status;
                        using (var stream = response.Content.ReadAsStreamAsync().Result)
                        {
                            status = (serializer.Deserialize(stream) as SignalStatusDto)?.ToViewModel();
                        }

                        Console.WriteLine(status?.ToCsv());
                        
                        if (opts.Repeat > 1)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(opts.PoolingTime));
                        }
                    }
                }
            }
        }

        private static void HandleParseError(IEnumerable errs)
        {
            Console.WriteLine("Command Line parameters provided were not valid!");
        }
    }
}
