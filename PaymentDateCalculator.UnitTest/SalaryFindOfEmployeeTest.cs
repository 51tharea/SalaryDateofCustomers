using System;
using System.Collections.Generic;
using PaymentDateCalculator.Enums;
using PaymentDateCalculator.Models;
using PaymentDateCalculator.Services;
using Xunit;

namespace PaymentDateCalculator.UnitTest
{
    public class SalaryFindOfEmployeeTest : BaseTest
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.SpecificDayofMonth,
                                 Day                = 12,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 7, 8),
                                 NextSalaryDateTime = new DateTime(2017, 7, 12)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.SpecificDayofMonth,
                                 Day                = 14,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 7, 20),
                                 NextSalaryDateTime = new DateTime(2017, 8, 14)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.LastWorkingDayofMonth,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 6, 8),
                                 NextSalaryDateTime = new DateTime(2017, 6, 30)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.LastWorkingDayofMonth,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 9, 20),
                                 NextSalaryDateTime = new DateTime(2017, 9, 29)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.DayBeforeLastWorkingDay,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 6, 8),
                                 NextSalaryDateTime = new DateTime(2017, 6, 29)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.DayBeforeLastWorkingDay,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 9, 20),
                                 NextSalaryDateTime = new DateTime(2017, 9, 28)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.FirstWorkingdayofMonth,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 6, 8),
                                 NextSalaryDateTime = new DateTime(2017, 7, 3)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.FirstWorkingdayofMonth,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 10, 1),
                                 NextSalaryDateTime = new DateTime(2017, 10, 2)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.FirstWorkingdayofMonth,
                                 Day                = 0,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 8, 1),
                                 NextSalaryDateTime = new DateTime(2017, 9, 1)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.FirstXDay,
                                 Day                = 2,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 7, 3),
                                 NextSalaryDateTime = new DateTime(2017, 7, 4)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.FirstXDay,
                                 Day                = 2,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 7, 6),
                                 NextSalaryDateTime = new DateTime(2017, 8, 1)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.FirstXDay,
                                 Day                = 4,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 7, 1),
                                 NextSalaryDateTime = new DateTime(2017, 7, 6)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.LastXDay,
                                 Day                = 3,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 7, 14),
                                 NextSalaryDateTime = new DateTime(2017, 7, 26)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.LastXDay,
                                 Day                = 1,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 8, 18),
                                 NextSalaryDateTime = new DateTime(2017, 8, 28)
                             }
                         };
            yield return new object[]
                         {
                             new SalaryDateTestModel
                             {
                                 Frequency          = SalaryFrequency.LastXDay,
                                 Day                = 5,
                                 Week               = 0,
                                 CurrentDateTime    = new DateTime(2017, 9, 21),
                                 NextSalaryDateTime = new DateTime(2017, 9, 29)
                             }
                         };
        }



        [Theory]
        [MemberData(nameof(Data))]
        public void TestData(SalaryDateTestModel salaryData) => Calculate(salaryData);
    }


    public abstract class BaseTest
    {
        protected void Calculate(SalaryDateTestModel salaryData)
        {
            var SalaryDateCalculation = new SalaryDateCalculation();

            SalaryDateCalculation.SetCurrentDateTime(salaryData.CurrentDateTime);

            var Actual = SalaryDateCalculation.CalculateNextSalaryDate(new SalaryDateCalculationDto
                                                                       {
                                                                           Day              = salaryData.Day,
                                                                           PaymentFrequency = salaryData.Frequency,
                                                                           Week             = salaryData.Week
                                                                       });
            var Expected = salaryData.NextSalaryDateTime;

            Assert.Equal(Expected, Actual);
        }
    }
}
