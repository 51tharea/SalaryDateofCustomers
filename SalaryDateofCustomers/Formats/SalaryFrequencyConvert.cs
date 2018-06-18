using System;
using Newtonsoft.Json;
using PaymentDateCalculator.Enums;

namespace PaymentDateCalculator.Formats
{
    public class SalaryFrequencyConvert : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            SalaryFrequency Frequency = (SalaryFrequency) value;

            switch (Frequency)
            {
                case SalaryFrequency.DayBeforeLastWorkingDay:
                    writer.WriteValue("DayBeforeLastWorkingDay");
                    break;
                case SalaryFrequency.FirstWorkingdayofMonth:
                    writer.WriteValue("FirstWorkingdayofMonth");
                    break;
                case SalaryFrequency.FirstXDay:
                    writer.WriteValue("FirstXDay");
                    break;
                case SalaryFrequency.LastWorkingDayofMonth:
                    writer.WriteValue("LastWorkingDayofMonth");
                    break;
                case SalaryFrequency.LastXDay:
                    writer.WriteValue("LastXDay");
                    break;
                case SalaryFrequency.SpecificDayofMonth:
                    writer.WriteValue("SpecificDayofMonth");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var SalaryFrequencyString = (string) reader.Value;

            return Enum.Parse(typeof(SalaryFrequency), SalaryFrequencyString, true);
        }

        public override bool CanConvert(Type objectType) { return objectType == typeof(string); }
    }
}
