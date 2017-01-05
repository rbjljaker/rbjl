using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MatterDetailDto
/// </summary>
public class MatterDetailDto
{
    public int id { get; set; }
    public int itemNum { get; set; }
    public DateTime date { get; set; }
    public Guid feeEarner { get; set; }
    public Guid otherFeeEarner { get; set; }
    public double? timeSpan { get; set; }
    public double? fixedCost { get; set; }
    public string description { get; set; }
    public int templateType { get; set; }
    public string templateDescription { get; set; }
    public double billable { get; set; }
    public Guid matterId { get; set; }
    public double hourlyRateH { get; set; }
    public bool isBill { get; set; }
    public double fixedCostTimeSpan { get; set; }

    public bool? isCountTotal { get; set; }
}