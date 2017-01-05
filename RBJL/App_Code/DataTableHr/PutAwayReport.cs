using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralUtilities;

/// <summary>
/// Summary description for PutAwayReport
/// </summary>
public class PutAwayReport
{

    public static string setHr()
    {
        string[] headerArr = new string[] { DataTablePutAwayReport.hr.id, DataTablePutAwayReport.hr.putAwayNum, DataTablePutAwayReport.hr.reportTitle };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }

    public static string setContentHr()
    {
        string[] headerArr = new string[] { DataTablePutAwayReport.content.id, DataTablePutAwayReport.content.mattererNum, DataTablePutAwayReport.content.client, DataTablePutAwayReport.content.subjectMatter, DataTablePutAwayReport.content.files, DataTablePutAwayReport.content.putAwayNum };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }


}