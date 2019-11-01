namespace P05
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DateModifier
    {
        public int CalculateDayDifference(string dateOne, string dateTwo)
        {
            DateTime datetimeOne = DateTime.Parse(dateOne);
            DateTime datetimeTwo = DateTime.Parse(dateTwo);

            int dateDiff = Math.Abs((datetimeOne - datetimeTwo).Days);

            return dateDiff;
        }
    }
}
