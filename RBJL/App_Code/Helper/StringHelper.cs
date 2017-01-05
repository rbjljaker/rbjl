using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StringHelper
/// </summary>
public class StringHelper
{
    public static string setSubSttring(object tar)
    {
        string result = Convert.ToString(tar);
        int maxLength = 48;
        return result.Length < maxLength ? result : String.Format("{0}...", result.Substring(0, maxLength - 2));
    }
}