public static class TimeCalculator
{

     
    public static void CalculateHours(
        ref double? hoursWorked,
        ref double? normalHours,
        ref double? overtimeHours,
        ref double? holidayHours,
        TimeSpan? timeIn,
        TimeSpan? timeOut,
        DateTime date)
    {
        if (timeIn.HasValue && timeOut.HasValue)
        {
            double totalHoursWorked = timeOut.Value.Subtract(timeIn.Value).TotalHours;

            // Deduct 1 hour for lunch if 8 or more hours worked
            if (totalHoursWorked >= 8)
            {
                totalHoursWorked -= 1;
            }

            normalHours = Math.Min(totalHoursWorked, 9);
            overtimeHours = Math.Max(totalHoursWorked - 9, 0);
            holidayHours = IsSunday(date) ? totalHoursWorked : 0;

            if (IsSunday(date))
            {
                overtimeHours = totalHoursWorked;
                normalHours = 0;
                holidayHours = 0;
            }

            hoursWorked = totalHoursWorked;
        }
    }

    public static (double hoursWorked, double normalHours, double overtimeHours, double holidayHours)  CalculateHours(DateTime date, TimeSpan? timeIn, TimeSpan? timeOut)
    {
        double hoursWorked = 0;
        double normalHours = 0;
        double overtimeHours = 0; double holidayHours = 0;
        if (timeIn.HasValue && timeOut.HasValue)
        {
            double totalHoursWorked = timeOut.Value.Subtract(timeIn.Value).TotalHours;

            // Deduct 1 hour for lunch if 8 or more hours worked
            if (totalHoursWorked >= 8)
            {
                totalHoursWorked -= 1;
            }

            normalHours = Math.Min(totalHoursWorked, 9);
            overtimeHours = Math.Max(totalHoursWorked - 9, 0);
            holidayHours = IsSunday(date) ? totalHoursWorked : 0;

            if (IsSunday(date))
            {
                overtimeHours = totalHoursWorked;
                normalHours = 0;
                holidayHours = 0;
            }

            hoursWorked = totalHoursWorked;
        }
        return new(hoursWorked, normalHours, overtimeHours, holidayHours);
    }

    private static bool IsSunday(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Sunday;
    }
}
