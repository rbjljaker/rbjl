using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportFeeEarner
/// </summary>
public class ReportFeeEarner
{
    public string matterIdContent { get; set; }
    public string item { get; set; }
    public string date { get; set; }
    public string description { get; set; }
    public string feeEarner { get; set; }
    public string timeSpent { get; set; }
    public string bill { get; set; }
    public string unbill { get; set; }
    public string nonBillable { get; set; }
    public bool isBilled { get; set; }
}