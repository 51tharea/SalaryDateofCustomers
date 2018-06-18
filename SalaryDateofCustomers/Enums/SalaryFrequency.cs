namespace PaymentDateCalculator.Enums
{
    public enum SalaryFrequency
    {
        SpecificDayofMonth,      // nth day of month.
        LastWorkingDayofMonth,   // last working day of month
        DayBeforeLastWorkingDay, // day before last working day of month
        FirstWorkingdayofMonth,  // first working day of month
        FirstXDay,               // first x day of month. ie. if day is 2, it means first tuesday of month
        LastXDay,                // last x day of month. ie. if day is 1, it means last monday of month
    }
}
