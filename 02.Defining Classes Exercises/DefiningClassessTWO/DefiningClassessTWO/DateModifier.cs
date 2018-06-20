using System;
using System.Collections.Generic;
using System.Text;

class DateModifier
{


    public string FindDeference(string dateOne, string dateTwo) {

        DateTime parsedDateOne = Convert.ToDateTime(dateOne);
        DateTime parsedDateTwo = Convert.ToDateTime(dateTwo);

        return Math.Abs((parsedDateOne - parsedDateTwo).TotalDays).ToString();
    }
}

