using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeEntryInfoDto
/// </summary>
public class TimeEntryInfoDto
{
    //public string matterNumIdList { get; set; }
    //public string matterNumId { get; set; }

    //public string debitNoteType { get; set; }
    //public string category { get; set; }
    //public string reportDate { get; set; }
    //public string price { get; set; }
    //public string isDiscount { get; set; }
    //public string depositAccount { get; set; }
    //public string butSay { get; set; }
    //public string CurrencySymbol { get; set; }
    //public string DebitNoteCreateDate { get; set; }
    //public string debitNoteId { get; set; }
    public string itemNum { get; set; }
    public string date { get; set; }
    public string description { get; set; }
    public string feeEarner { get; set; }
    public string timespan { get; set; }
    public string fixedCost { get; set; }
    public string writtenOff { get; set; }
    public string billable { get; set; }
    public string hourlyRateH { get; set; }
    public string fixedCostTimeSpan { get; set; }
    public string isCountTotal { get; set; }
    //public string matterDetailsId { get; set; }
    //public string matterId { get; set; }

    public bool isContent { get; set; }

    public string info { get; set; }

}