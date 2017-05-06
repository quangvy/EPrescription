using System;

namespace Data.Helper
{
    public static class DataUtils
    {   
        /// <summary>
        /// standard postal code format in TIPS
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string FormatPostalCode(string code)
        {
            if (code == null || code.Trim().Length == 0)
            {
                return "";
            }
            else if (code.Trim().Length == 7)
            {
                return code.Trim();
            }
            else if (code.Trim().Length == 6)
            {
                return code.Substring(0, 3) + " " + code.Substring(3, 3);
            }
            else
            {
                return code;
            }
        }

        /// <summary>
        /// standard phone number format in Tips
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string FormatPhoneNumber(string number)
        {
            if (number.Length == 10)
            {
                return number.Substring(0, 3) + "-" + number.Substring(3, 3) + "-" + number.Substring(6, 4);
            }
            else
            {
                return number;
            }
        }

        /// <summary>
        /// Provide cover days of a year for specific date
        /// </summary>
        /// <param name="effectiveDate"></param>
        /// <returns></returns>
        public static int DaysInYear(System.DateTime effectiveDate)
        {
            if (DateTime.IsLeapYear(effectiveDate.Year))
            {
                if ((effectiveDate.Month == 2 & effectiveDate.Day <= 28) | effectiveDate.Month < 2)
                {
                    return 366;
                }
                else
                {
                    return 365;
                }
            }
            else if (DateTime.IsLeapYear(effectiveDate.Year + 1))
            {
                if ((effectiveDate.Month == 2 & effectiveDate.Day > 28) | effectiveDate.Month > 2)
                {
                    return 366;
                }
                else
                {
                    return 365;
                }
            }
            else
            {
                return 365;
            }
        }

        /// <summary>
        /// Return the proper date format for TIPS
        /// Date format is senstive for TIPS. 
        /// </summary>
        /// <returns></returns>
        public static string DateFormat()
        {
            string currentFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string[] currentFormatElements = currentFormat.Split('/');

            currentFormat = "";

            //21C is having some trouble differentiating between M/d and MM/dd for data entry, so we're just going to fix that up here
            //so what's prompted for is consistent.
            for (int index = 0; index <= currentFormatElements.GetUpperBound(0); index++)
            {
                if (currentFormatElements[index] == "M")
                {
                    currentFormatElements[index] = "MM";
                }
                else if (currentFormatElements[index] == "d")
                {
                    currentFormatElements[index] = "dd";
                }

                if (index > 0)
                    currentFormat += "/";
                currentFormat += currentFormatElements[index];
            }
            return currentFormat;
        }

        /// <summary>
        /// This function returns a date format using a 3 character month, rather than 2 digit.
        /// </summary>
        /// <returns></returns>
        public static string LongDateFormat()
        {
            return DateFormat().Replace("MM", "MMM");
        }
        /// <summary>
        /// Extension format for Tips to return proper datetime presenation. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatDate(this System.DateTime value)
        {
            //Formats the supplied date according to the current server short date format.
            return value.ToString(DateFormat());
        }
    }
}
