using System;
using PaymentDateCalculator.Models;

namespace PaymentDateCalculator.Interfaces
{
    public interface IPaymentDateCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salaryDateCalculationDto"></param>
        /// <returns></returns>
        DateTime CalculateNextSalaryDate(SalaryDateCalculationDto salaryDateCalculationDto);
    }
}
