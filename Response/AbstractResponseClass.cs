////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response
{
    [DataContract]
    public abstract class AbstractResponseClass
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public ErrorResponseClass error { get; set; }

        protected static double GetDoubleValueFromString(string str_value)
        {
            if (string.IsNullOrEmpty(str_value))
                return 0;

            str_value = str_value.Trim();
            if (str_value.Length > 5 && str_value.Substring(str_value.Length - 3).ToUpper() == "BTC")
                str_value = str_value.Substring(0, str_value.Length-3).Trim();

            return GetDoubleFromString(str_value);
        }

        private static double GetDoubleFromString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            if (double.TryParse(value.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                return result;

            return 0;
        }
    }

    [DataContract]
    public class ErrorResponseClass
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public string message { get; set; }
    }
}
