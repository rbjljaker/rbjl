using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AmountChart
/// </summary>
public class AmountChart
{
    public string id { get; set; }
    public string feeEarnerName { get; set; }
    public double amount { get; set; }
    public double tempValue1 { get; set; }
    public double tempValue2 { get; set; }
    public double billed { get; set; }
    public double unbilled { get; set; }
    public double writtenOff { get; set; }
}