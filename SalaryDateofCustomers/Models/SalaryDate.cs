using System;
using Newtonsoft.Json;
using PaymentDateCalculator.Enums;
using PaymentDateCalculator.Formats;

namespace PaymentDateCalculator.Models
{
    public class SalaryDate
    {
        public int Day { get; set; }
        public int Week { get; set; }
        public SalaryFrequency Frequency { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public DateTime NextSalaryDateTime { get; set; }
    }

    public class SalaryDateTestModel
    {
        public int Day { get; set; }
        public int Week { get; set; }

        [JsonConverter(typeof(SalaryFrequencyConvert))]
        public SalaryFrequency Frequency { get; set; }

        [JsonConverter(typeof(SalaryDateTimeConvert), "dd.MM.yyyy")]
        public DateTime CurrentDateTime { get; set; }

        [JsonConverter(typeof(SalaryDateTimeConvert), "dd.MM.yyyy")]
        public DateTime NextSalaryDateTime { get; set; }
    }
}
