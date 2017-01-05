using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FormatHelper
/// </summary>
public class FormatHelper
{
    public static string CostFormat(string input) 
    {
        string result = String.Format("{0:#,0.##}", input);
        return result;
    }

    public static string CostFormat(double input)
    {
        string result = String.Format("{0:#,0.##}", input);
        return result;
    }

    public static string CostFormatWithDollarSign(double input)
    {
        string result = String.Format("${0:#,0.##}", input);
        return result;
    }
}