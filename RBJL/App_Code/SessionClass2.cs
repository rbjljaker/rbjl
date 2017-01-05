using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;



/// <summary>
/// Summary description for Class1
/// </summary>
partial class SessionClass
{
    public static MatterDetailDto timeEntry
    {
        get
        {
            return (MatterDetailDto)HttpContext.Current.Session["timeEntry"];
        }
        set { HttpContext.Current.Session["timeEntry"] = value; }


    }

    public static string   DebitNoteNo
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["DebitNoteNo"]);
        }
        set { HttpContext.Current.Session["DebitNoteNo"] = value; }
    }
    public static GridviewHelper GridviewHelper
    {
        get
        {
            return (GridviewHelper)HttpContext.Current.Session["GridviewHelper"];
        }
        set { HttpContext.Current.Session["GridviewHelper"] = value; }
    }

    public static GridView GridviewPaging
    {
        get
        {
            return (GridView)HttpContext.Current.Session["GridviewPaging"];
        }
        set { HttpContext.Current.Session["GridviewPaging"] = value; }
    }
    public static string pop
    {
        get
        {
            return (string)HttpContext.Current.Session["pop"];
        }
        set { HttpContext.Current.Session["pop"] = value; }
    }

    public static string edit
    {
        get
        {
            return (string)HttpContext.Current.Session["edit"];
        }
        set { HttpContext.Current.Session["edit"] = value; }
    }

    public static string Debitnoteid
    {
        get
        {
            return (string)HttpContext.Current.Session["Debitnoteid"];
        }
        set { HttpContext.Current.Session["Debitnoteid"] = value; }
    }


    

}