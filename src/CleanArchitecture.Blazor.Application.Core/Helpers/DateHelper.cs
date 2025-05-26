
    public static class DateHelper
    {
        public static (DateTime StartDate, DateTime EndDate) GetMonthDateRange(int year, int month)
        {
            // Check if the provided month and year are valid
            if (month < 1 || month > 12 || year < 1)
                throw new ArgumentException("Invalid month or year.");

            // Calculate the start date (first day of the month)
            var startDate = new DateTime(year, month, 1);

            // Calculate the end date (last day of the month)
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return (startDate, endDate);
        }

        public static List<DateTime> GetAllDatesInRange(DateTime startDate, DateTime endDate)
        {
            // Ensure the start date is not after the end date
            if (startDate > endDate)
                throw new ArgumentException("Start date cannot be after end date.");

            // Create a list to hold the dates
            var dateList = new List<DateTime>();

            // Iterate from the start date to the end date
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dateList.Add(date);
            }

            return dateList;
        }
    }


