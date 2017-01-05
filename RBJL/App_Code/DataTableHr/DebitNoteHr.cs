using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralUtilities;

/// <summary>
/// Summary description for DebitNoteHr
/// </summary>
public class DebitNoteHr
{
    public static string setHr()
    {
        string[] headerArr = new string[] { DataTableConst.id, DataTableConst.TemplateId, DataTableConst.TemplateValue, DataTableConst.Description, DataTableConst.Cost, DataTableConst.Order, DataTableConst.FeeEarner };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }
}