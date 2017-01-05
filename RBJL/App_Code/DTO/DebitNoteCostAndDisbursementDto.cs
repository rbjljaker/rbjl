using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebitNoteCostAndDisbursementDto
/// </summary>
public class DebitNoteCostAndDisbursementDto
{
    public string templateType { get; set; }
    public string templateDetails { get; set; }
    public string description { get; set; }
    public float cost { get; set; }
}