using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddUserDto
/// </summary>
public class AddUserDto
{
    public string userNum { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string nickName { get; set; }
    //public double unitRate { get; set; }
    public string userRoles { get; set; }
}