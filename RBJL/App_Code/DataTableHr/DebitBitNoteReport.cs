using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralUtilities;

/// <summary>
/// Summary description for DebitBitNoteReport
/// </summary>
public class DebitBitNoteReport
{

    public static string setHr()
    {
        string[] headerArr = new string[] { 
                DataTableDebitNoteReportConst.id,
                DataTableDebitNoteReportConst.dNNum,
                DataTableDebitNoteReportConst.date,
                DataTableDebitNoteReportConst.refValue,
                DataTableDebitNoteReportConst.address,
                DataTableDebitNoteReportConst.attnTo,
                DataTableDebitNoteReportConst.debitNoteContent,
                DataTableDebitNoteReportConst.bgValue, 
             };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }

}