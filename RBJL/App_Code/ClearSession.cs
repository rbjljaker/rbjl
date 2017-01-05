using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClearSession
/// </summary>
public class ClearSession
{
    public static void clearSearch()
    {

        HttpContext.Current.Session["SearchByMatterNum"] = null;
        HttpContext.Current.Session["SearchByKeywords"] = null;
        HttpContext.Current.Session["SearchByClientName"] = null;
        HttpContext.Current.Session["SearchByJobType"] = null;
        HttpContext.Current.Session["SearchByCountry"] = null;
        HttpContext.Current.Session["SearchByClass"] = null;
        HttpContext.Current.Session["SearchByReferer"] = null;
        HttpContext.Current.Session["SearchByApplicationNum"] = null;
        HttpContext.Current.Session["SearchByRegistrationNum"] = null;
        HttpContext.Current.Session["SearchByApplicationNum"] = null;
        HttpContext.Current.Session["SearchBySubject"] = null;
    }
}