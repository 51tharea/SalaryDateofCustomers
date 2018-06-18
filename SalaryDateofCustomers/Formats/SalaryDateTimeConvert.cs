using Newtonsoft.Json.Converters;

namespace PaymentDateCalculator.Formats
{
    public class SalaryDateTimeConvert:IsoDateTimeConverter
    {
        public SalaryDateTimeConvert(string format)
        {
            DateTimeFormat = format;
        }
    }
}
