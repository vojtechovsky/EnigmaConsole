using System;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

namespace EnigmaConsole.ViewModel
{
	[XmlRoot(ElementName = "e2frontendstatus")]
	public class SignalStatusDto
	{
		[XmlElement(ElementName = "e2snrdb")]
		public string SnrDb { get; set; }

        [XmlElement(ElementName = "e2snr")]
		public string Snr { get; set; }

        [XmlElement(ElementName = "e2ber")]
		public string BitErrorRate { get; set; }

        [XmlElement(ElementName = "e2acg")]
		public string AutomaticGainControl { get; set; }

        public SignalStatus ToViewModel()
        {
            return new SignalStatus
            {

                SnrDb = Convert.ToDecimal(GetNumbers(this.SnrDb)),
                Snr = Convert.ToInt32(GetNumbers(this.Snr)),
                BitErrorRate = Convert.ToInt32(GetNumbers(this.BitErrorRate)),
                AutomaticGainControl = Convert.ToInt32(GetNumbers(this.AutomaticGainControl)),
            };
        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(x=> char.IsDigit(x) || NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0] == x).ToArray());
        }
    }
}
