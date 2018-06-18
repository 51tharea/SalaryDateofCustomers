using System;
using Microsoft.AspNetCore.Mvc;
using PaymentDateCalculator.Enums;
using PaymentDateCalculator.Models;
using PaymentDateCalculator.Services;

namespace PaymentDateCalculator.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDateCalculatorController : Controller
    {
        private readonly ISalaryDateCalculation Calculator;

        // GET
        public PaymentDateCalculatorController(ISalaryDateCalculation calculator) { Calculator = calculator; }


      
        [HttpGet("/calculate/{frequencey:int}/{day:int}/{week:int}/{currentDate}")]
        public IActionResult CalculateNextSalaryDate(SalaryFrequency frequencey, int day, int week, DateTime currentDate)
        {
            Calculator.SetCurrentDateTime(currentDate);
            var Result = Calculator.CalculateNextSalaryDate(new SalaryDateCalculationDto {PaymentFrequency = frequencey, Day = day, Week = week});

            return Ok(new SalaryDateTestModel
                      {
                          CurrentDateTime    = currentDate,
                          Day                = day,
                          Frequency          = frequencey,
                          NextSalaryDateTime = Result,
                          Week               = week
                      });
        }
    }
}
