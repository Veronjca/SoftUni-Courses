using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            FirstDate = firstDate;
            SecondDate = secondDate;
        }
        public string FirstDate { get; set; }
        public string SecondDate { get; set; }

        public double Difference(string firstDate, string secondDate)
        {
            double days = 0;
            DateTime startDate = Convert.ToDateTime(firstDate);
            DateTime endDate = Convert.ToDateTime(secondDate);

            return days = Math.Abs((endDate - startDate).TotalDays);


        }
        
    }
}
