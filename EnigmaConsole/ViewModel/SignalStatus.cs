namespace EnigmaConsole.ViewModel
{
    /// <summary>
    /// ViewModel for the signal status 
    /// </summary>
    public class SignalStatus
    {
        /// <summary>
        /// SignalNoiseRatioDecibels
        /// </summary>
        public decimal SnrDb { get; set; }

        /// <summary>
        /// SignalNoiseRatio
        /// </summary>
        public int Snr { get; set; }

        
        public int BitErrorRate { get; set; }

        
        public int AutomaticGainControl { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>Returns a string that represents the current object.</returns>
        public override string ToString() => $"SnrDb:{SnrDb}, Snr:{Snr}, Ber:{BitErrorRate}, Agc:{AutomaticGainControl}";

        /// <summary>
        /// Returns a string that represents comma-separated-value of the current object.
        /// </summary>
        /// <returns>Returns a string that represents comma-separated-value of the current object.</returns>
        public string ToCsv() => $"{SnrDb},{Snr},{BitErrorRate},{AutomaticGainControl}";
    }
}