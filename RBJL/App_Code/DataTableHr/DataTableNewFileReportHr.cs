using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralUtilities;

/// <summary>
/// Summary description for DataTableNewFileReportHr
/// </summary>
public class DataTableNewFileReportHr
{
    public static string setHr()
    {
        string[] headerArr = new string[] { 
            DataTableNewFileReportConst.clientName, 
            DataTableNewFileReportConst.incomimgAgent,
            DataTableNewFileReportConst.outgoingAgent,
            DataTableNewFileReportConst.subject, 
            DataTableNewFileReportConst.address,
            DataTableNewFileReportConst.feeEarner, 
            DataTableNewFileReportConst.handingColleague,
            DataTableNewFileReportConst.introducer,
            DataTableNewFileReportConst.legalAid,
            DataTableNewFileReportConst.matterNumber, 
            DataTableNewFileReportConst.jobType,
            DataTableNewFileReportConst.contactPerson,
            DataTableNewFileReportConst.email,
            DataTableNewFileReportConst.telephoneNumber,
            DataTableNewFileReportConst.faxNumber, 
            DataTableNewFileReportConst.fileOpenDay, 
            DataTableNewFileReportConst.excelRecordNum };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }
}