using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeneralUtilities;

/// <summary>
/// Summary description for FeeEarnerReport
/// </summary>
public class FeeEarnerReport
{
    public static string setHr()
    {
        string[] headerArr = new string[] { DataTableFeeEarnerConst.hr.id, DataTableFeeEarnerConst.hr.matterId, DataTableFeeEarnerConst.hr.reportTitle, DataTableFeeEarnerConst.hr.logo, DataTableFeeEarnerConst.hr.logoVisable };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }

    public static string setContentHr()
    {
        string[] headerArr = new string[] {
            DataTableFeeEarnerConst.content.matterIdContent,
            DataTableFeeEarnerConst.content.item,
            DataTableFeeEarnerConst.content.date,
            DataTableFeeEarnerConst.content.description, 
            DataTableFeeEarnerConst.content.feeEarner, 
            DataTableFeeEarnerConst.content.timeSpent };
        string result = DataTableHelper.joinArrayToString(headerArr);
        return result;
    }

}