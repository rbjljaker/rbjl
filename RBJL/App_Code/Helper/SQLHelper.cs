using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SQLHelper
/// </summary>
public class SQLHelper
{
    public static string whereGuid(string columnName, Guid value)
    {
        return String.Format("it.{0} = GUID'{1}'", columnName, value);
    }

    public static string whereGuid(string columnName, string value)
    {
        return String.Format("it.{0} = GUID'{1}'", columnName, value);
    }

    public static string whereNotEqualGuid(string columnName, Guid value)
    {
        return String.Format("it.{0} != GUID'{1}'", columnName, value);
    }

    public static string whereNotEqualGuid(string columnName, string value)
    {
        return String.Format("it.{0} != GUID'{1}'", columnName, value);
    }

    public static string whereIsNotNull(string columnName)
    {
        return String.Format("it.{0} is not null", columnName);
    }

    public static string whereIsNull(string columnName)
    {
        return String.Format("it.{0}  is null", columnName);
    }



    public static string whereString(string columnName, string value)
    {
        return String.Format("it.{0} = '{1}'", columnName, value);
    }

    public static string whereNotEqualString(string columnName, string value)
    {
        return String.Format("it.{0} != '{1}'", columnName, value);
    }

    public static string whereYesNo(string columnName, bool value)
    {
        return String.Format("it.{0} = {1}", columnName, value);
    }

    public static string whereBoolNotEqual(string columnName, bool value)
    {
        return String.Format("it.{0} != {1}", columnName, value);
    }

    public static string whereStringLike(string columnName, string value)
    {
        return String.Format("it.{0} LIKE '%{1}%'", columnName, value);
    }

    public static string whereStringLikeStart(string columnName, string value)
    {
        return String.Format("it.{0} LIKE '{1}%'", columnName, value);
    }
}