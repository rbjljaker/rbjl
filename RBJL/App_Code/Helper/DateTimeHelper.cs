using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Summary description for DateTimeHelper
/// </summary>
public class DateTimeHelper
{
    public DateTimeHelper()
    {

    }



    public static DateTime convertStringToDateTime(string date)
    {
        DateTime dt;
        try
        {
            CultureInfo provider = new CultureInfo("en-US");
            dt = DateTime.ParseExact(date, "dd-MMM-yyyy", provider);
        }
        catch
        {
            dt = DateTime.Now;
        }
        return dt;
    }

    public static string convertDateTimeToString(DateTime date)
    {
        CultureInfo provider = new CultureInfo("en-US");


        // string result = String.Format("{0:dd-MMM-yyyy}", date);

        string result = date.ToString("dd-MMM-yyyy", provider);
        return result;
    }

    public static string getNowTimeString()
    {
        return convertDateTimeToString(DateTime.Now);
    }
}