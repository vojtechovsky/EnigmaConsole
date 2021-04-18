using CommandLine;

namespace EnigmaConsole.CommandLine
{
    [Verb("signal", HelpText = "It shows enigma box signal")]
    public class SignalCommand
    {
        /// <summary>
        ///     URL of the requested web service
        /// </summary>
        /// <example>
        /// --a=http:\\192.168.15.103
        /// </example>
        [Option('a', "address", Required = true, HelpText = "URL of the requested web service")]
        public string Url { get; set; }

        /// <summary>
        ///     It specifies how many times it request a signal from a web service
        /// </summary>
        /// <example>
        /// --repeat=10
        /// </example>
        [Option('r', "repeat", Required = false, Default = 1, HelpText = "Specify how many times it request a signal from a web service")]
        public int Repeat { get; set; }

        /// <summary>
        ///     time in second between request
        /// </summary>
        /// <example>
        /// --pooling-time=10
        /// </example>
        [Option('t', "pooling-time", Required = false, Default = 10, HelpText = "Specify time in seconds between requests")]
        public int PoolingTime { get; set; }
    }
}
