using System;
using System.Collections.Generic;
using System.Linq;
using PaymentDateCalculator.Enums;
using PaymentDateCalculator.Models;
using PaymentDateCalculator.Services;

namespace SalaryFindofEmployee
{
    class Program
    {
        public static IEnumerable<SalaryDateTestModel> TestData()
        {
            return new List<SalaryDateTestModel>
                   {
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.SpecificDayofMonth,
                           Day                = 12,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 7, 8),
                           NextSalaryDateTime = new DateTime(2017, 7, 12)
                       },

                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.SpecificDayofMonth,
                           Day                = 14,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 7, 20),
                           NextSalaryDateTime = new DateTime(2017, 8, 14)
                       },

                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.LastWorkingDayofMonth,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 6, 8),
                           NextSalaryDateTime = new DateTime(2017, 6, 30)
                       },

                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.LastWorkingDayofMonth,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 9, 20),
                           NextSalaryDateTime = new DateTime(2017, 9, 29)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.DayBeforeLastWorkingDay,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 6, 8),
                           NextSalaryDateTime = new DateTime(2017, 6, 29)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.DayBeforeLastWorkingDay,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 9, 20),
                           NextSalaryDateTime = new DateTime(2017, 9, 29)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.FirstWorkingdayofMonth,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 6, 8),
                           NextSalaryDateTime = new DateTime(2017, 7, 3)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.FirstWorkingdayofMonth,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 10, 1),
                           NextSalaryDateTime = new DateTime(2017, 10, 2)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.FirstWorkingdayofMonth,
                           Day                = 0,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 8, 1),
                           NextSalaryDateTime = new DateTime(2017, 9, 1)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.FirstXDay,
                           Day                = 2,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 7, 3),
                           NextSalaryDateTime = new DateTime(2017, 7, 4)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.FirstXDay,
                           Day                = 2,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 7, 6),
                           NextSalaryDateTime = new DateTime(2017, 8, 1)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.FirstXDay,
                           Day                = 4,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 7, 1),
                           NextSalaryDateTime = new DateTime(2017, 7, 6)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.LastXDay,
                           Day                = 3,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 7, 14),
                           NextSalaryDateTime = new DateTime(2017, 7, 26)
                       },
                       new SalaryDateTestModel
                       {
                           Frequency          = SalaryFrequency.LastXDay,
                           Day                = 1,
                           Week               = 0,
                           CurrentDateTime    = new DateTime(2017, 8, 18),
                           NextSalaryDateTime = new DateTime(2017, 8, 28)
                       },
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


        static void Main(string[] args)
        {
            Console.Write("SalaryFrequency" + "\t\t\t" + "Day" + "\t" + "Week" + "\t" + "Current Date" + "\t" + "Next Salary Date" + "\n");


            foreach (var SalaryDate in TestData())
            {
                var SalaryDateCalculation = new SalaryDateCalculation();

                SalaryDateCalculation.SetCurrentDateTime(SalaryDate.CurrentDateTime);

                var Actual = SalaryDateCalculation.CalculateNextSalaryDate(new SalaryDateCalculationDto
                                                                           {
                                                                               Day              = SalaryDate.Day,
                                                                               PaymentFrequency = SalaryDate.Frequency,
                                                                               Week             = SalaryDate.Week
                                                                           });
          
                var PaymentFrequency = Enum.GetName(typeof(SalaryFrequency), SalaryDate.Frequency);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{SalaryDate.Frequency}" + (PaymentFrequency.Length > 9
                                                            ? "\t\t"
                                                            : "\t\t\t")
                                                        + SalaryDate.Day + "\t"
                                                        + SalaryDate.Week + "\t"
                                                        + $"{SalaryDate.CurrentDateTime:dd.MM.yyyy}" + "\t"
                                                        + $"{Actual:dd.MM.yyyy}" + "\n");

                Console.WriteLine();
            }
        }
    }
}
