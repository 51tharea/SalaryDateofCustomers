using System;
using PaymentDateCalculator.Enums;
using PaymentDateCalculator.Extensions;
using PaymentDateCalculator.Interfaces;
using PaymentDateCalculator.Models;

namespace PaymentDateCalculator.Services
{
    public class SalaryDateCalculation : ISalaryDateCalculation
    {
        private DateTime CurrentTime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        public void SetCurrentDateTime(DateTime currentDate) { CurrentTime = currentDate; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime CalculateNextSalaryDate(SalaryDateCalculationDto date)
        {
            DateTime Result;

            switch (date.PaymentFrequency)
            {
                case SalaryFrequency.SpecificDayofMonth:
                    Result = CurrentTime.SpecificDayOfMonth(date.Day);
                    break;
                case SalaryFrequency.LastWorkingDayofMonth:
                    Result = CurrentTime.LastWorkingDayOfMonth();
                    break;
                case SalaryFrequency.DayBeforeLastWorkingDay:
                    Result = CurrentTime.DayBeforeLastWorkingDay();
                    break;
                case SalaryFrequency.FirstWorkingdayofMonth:
                    Result = CurrentTime.FirstWorkingDayOfMonth();
                    break;
                case SalaryFrequency.FirstXDay:
                    Result = CurrentTime.FirstXDay(date.Day, date.Week);
                    break;
                case SalaryFrequency.LastXDay:
                    Result = CurrentTime.LastXDay(date.Day, date.Week);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Result;
        }
    }

    public interface ISalaryDateCalculation : IPaymentDateCalculator
    {
        void SetCurrentDateTime(DateTime currentDate);
    }
}
