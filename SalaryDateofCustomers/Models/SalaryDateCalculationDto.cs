using PaymentDateCalculator.Enums;

namespace PaymentDateCalculator.Models
{

    public class SalaryDateCalculationDto{
        public int             Day             { get; set; }
        public int             Week            { get; set; }
        public SalaryFrequency PaymentFrequency{ get; set; }
    }
}