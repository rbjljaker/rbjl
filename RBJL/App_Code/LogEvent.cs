using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBEntity
/// </summary>
public class LogEvent : DBEntity
{
    public LogEvent()
        : base()
    {
    }

    public LogEvent(string userName)
        : base(userName)
    {

    }


    //public IQueryable<UserInfo> getUserLog(object tar)
    //{
    //    IQueryable<UserInfo> findValue = tar as IQueryable<UserInfo>;

    //    if (findValue != null)
    //    {

    //    }

    //    return findValue;
    //}
}