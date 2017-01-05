using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeEntryBillableOrNonBillable
/// </summary>
public class TimeEntryBillableOrNonBillable
{
    public double billable { get; set; }
    public double nonBillable { get; set; }
    public double totalRecord { get; set; }

    public double billed { get; set; }
    public double unbilled { get; set; }
    public double writtenOff { get; set; }
}