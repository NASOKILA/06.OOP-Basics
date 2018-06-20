using System;
using System.Globalization;

namespace _05.Date_Modifier
{
    public class DateModifier
    {
        public double diffOfDays { get; set; }

        public void CalculateDays(string startDate, string endDate)
        {
            startDate = startDate.Replace(" ", "-");

            endDate = endDate.Replace(" ", "-");

            DateTime start = DateTime.Parse(startDate);

            DateTime end = DateTime.Parse(endDate);

            diffOfDays = Math.Abs((start - end).TotalDays);
            
        }
    }
}
