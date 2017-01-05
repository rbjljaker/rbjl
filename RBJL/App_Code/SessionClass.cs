using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SessionClass
/// </summary>
///

public partial class SessionClass
{
    public static string CurrentCaptcha
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["CAPTCHA"]);
        }
        set { HttpContext.Current.Session["CAPTCHA"] = value; }
    }

    public static string Identity
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["Identity"]);
        }
        set { HttpContext.Current.Session["Identity"] = value; }
    }

    //public static string MatterId
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["MatterId"]);
    //    }
    //    set { HttpContext.Current.Session["MatterId"] = value; }
    //}

    public static string MatterNum
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["MatterNum"]);
        }
        set { HttpContext.Current.Session["MatterNum"] = value; }
    }

    public static string MatterDetailId
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["MatterDetailId"]);
        }
        set { HttpContext.Current.Session["MatterDetailId"] = value; }
    }

    //public static string TimeStart
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["TimeStart"]);
    //    }
    //    set { HttpContext.Current.Session["TimeStart"] = value; }
    //}
    //public static string TimeStop
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["TimeStop"]);
    //    }
    //    set { HttpContext.Current.Session["TimeStop"] = value; }
    //}

    public static string SearchByMatterNum
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["SearchByMatterNum"]);
        }
        set { HttpContext.Current.Session["SearchByMatterNum"] = value; }
    }

    public static string SearchByKeywords
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["SearchByKeywords"]);
        }
        set { HttpContext.Current.Session["SearchByKeywords"] = value; }
    }

    public static string SearchByClientName
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["SearchByClientName"]);
        }
        set { HttpContext.Current.Session["SearchByClientName"] = value; }
    }

    public static string SearchByJobType
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["SearchByJobType"]);
        }
        set { HttpContext.Current.Session["SearchByJobType"] = value; }
    }

    //public static string SearchByCountry
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["SearchByCountry"]);
    //    }
    //    set { HttpContext.Current.Session["SearchByCountry"] = value; }
    //}

    //public static string SearchByClass
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["SearchByClass"]);
    //    }
    //    set { HttpContext.Current.Session["SearchByClass"] = value; }
    //}

    public static string SearchByReferer
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["SearchByReferer"]);
        }
        set { HttpContext.Current.Session["SearchByReferer"] = value; }
    }

    //public static string SearchByApplicationNum
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["SearchByApplicationNum"]);
    //    }
    //    set { HttpContext.Current.Session["SearchByApplicationNum"] = value; }
    //}

    //public static string SearchByRegistrationNum
    //{
    //    get
    //    {
    //        return Convert.ToString(HttpContext.Current.Session["SearchByRegistrationNum"]);
    //    }
    //    set { HttpContext.Current.Session["SearchByRegistrationNum"] = value; }
    //}

    public static string SearchBySubject
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["SearchBySubject"]);
        }
        set { HttpContext.Current.Session["SearchBySubject"] = value; }
    }


    public static DataTable DebitNoteCostDataTable
    {
        get
        {
            return HttpContext.Current.Session["DebitNoteCostDatabase"] as DataTable;
        }
        set { HttpContext.Current.Session["DebitNoteCostDatabase"] = value; }
    }

    public static DataTable DebitNoteDisbursementDataTable
    {
        get
        {
            return HttpContext.Current.Session["DebitNoteDisbursementDataTable"] as DataTable;
        }
        set { HttpContext.Current.Session["DebitNoteDisbursementDataTable"] = value; }
    }

    public static DataTable DebitNoteMiscDataTable
    {
        get
        {
            return HttpContext.Current.Session["DebitNoteMiscDataTable"] as DataTable;
        }
        set { HttpContext.Current.Session["DebitNoteMiscDataTable"] = value; }
    }



    public static string checkIsChangeStatus
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["checkIsChangeStatus"]);
        }
        set { HttpContext.Current.Session["checkIsChangeStatus"] = value; }
    }


    //public static EnumUserLevel userLevel
    //{
    //    get
    //    {
    //        return (EnumUserLevel)HttpContext.Current.Session["userLevel"];
    //    }
    //    set { HttpContext.Current.Session["userLevel"] = value; }
    //}

    public static int? autoCompleteColumn
    {
        get
        {
            int tmpvalue;
            string value = Convert.ToString(HttpContext.Current.Session["autoCompleteColumn"]);
            int? result = int.TryParse(value, out tmpvalue) ? tmpvalue : (int?)null;
            return result;
        }
        set { HttpContext.Current.Session["autoCompleteColumn"] = value; }
    }



    public static byte[] uploadFileTemp1
    {
        get
        {
            return HttpContext.Current.Session["uploadFileTemp1"] as byte[];
        }
        set { HttpContext.Current.Session["uploadFileTemp1"] = value; }
    }


    public static string uploadFileFileNameTemp1
    {
        get
        {
            return HttpContext.Current.Session["uploadFileFileNameTemp1"] as string;
        }
        set { HttpContext.Current.Session["uploadFileFileNameTemp1"] = value; }
    }



    public static byte[] uploadFileTemp2
    {
        get
        {
            return HttpContext.Current.Session["uploadFileTemp2"] as byte[];
        }
        set { HttpContext.Current.Session["uploadFileTemp2"] = value; }
    }


    public static string uploadFileFileNameTemp2
    {
        get
        {
            return HttpContext.Current.Session["uploadFileFileNameTemp2"] as string;
        }
        set { HttpContext.Current.Session["uploadFileFileNameTemp2"] = value; }
    }

    public static byte[] uploadFileTemp3
    {
        get
        {
            return HttpContext.Current.Session["uploadFileTemp3"] as byte[];
        }
        set { HttpContext.Current.Session["uploadFileTemp3"] = value; }
    }


    public static string uploadFileFileNameTemp3
    {
        get
        {
            return HttpContext.Current.Session["uploadFileFileNameTemp3"] as string;
        }
        set { HttpContext.Current.Session["uploadFileFileNameTemp3"] = value; }
    }

    public static byte[] uploadFileTemp4
    {
        get
        {
            return HttpContext.Current.Session["uploadFileTemp4"] as byte[];
        }
        set { HttpContext.Current.Session["uploadFileTemp4"] = value; }
    }


    public static string uploadFileFileNameTemp4
    {
        get
        {
            return HttpContext.Current.Session["uploadFileFileNameTemp4"] as string;
        }
        set { HttpContext.Current.Session["uploadFileFileNameTemp4"] = value; }
    }

    public static byte[] uploadFileTemp5
    {
        get
        {
            return HttpContext.Current.Session["uploadFileTemp5"] as byte[];
        }
        set { HttpContext.Current.Session["uploadFileTemp5"] = value; }
    }


    public static string uploadFileFileNameTemp5
    {
        get
        {
            return HttpContext.Current.Session["uploadFileFileNameTemp5"] as string;
        }
        set { HttpContext.Current.Session["uploadFileFileNameTemp5"] = value; }
    }
}
