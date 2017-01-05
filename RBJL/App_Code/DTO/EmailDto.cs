using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmailDto
/// </summary>
public class EmailDto
{
    public string subject { get; set; }
    public string content { get; set; }
    public string ccTo { get; set; }
    public string fromAddr { get; set; }
    public string ccTo2 { get; set; }
}