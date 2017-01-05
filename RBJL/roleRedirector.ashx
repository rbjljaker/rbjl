<%@ WebHandler Language="C#" Class="roleRedirector" %>

using System;
using System.Web;
using System.Web.Security;

public class roleRedirector : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (HttpContext.Current.Request.QueryString["link"] != null)
        {
            try
            {
                LogEvent le = new LogEvent();
                le.addLog(LogConst.logout);
                if (context.Session != null)
                    context.Session.RemoveAll();
                FormsAuthentication.SignOut();
            }
            catch
            {

            }
            context.Response.Redirect("~/Login.aspx");
        }
        else
        {
            MembershipUser currentUser = Membership.GetUser();

            if (Membership.GetUser() != null)
            {
                context.Response.Redirect("~/Common/Welcome.aspx");
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            String serverProtocol = System.Web.HttpContext.Current.Request.ServerVariables.Get("SERVER_PORT_SECURE");
            serverProtocol = serverProtocol == "1" ? "https://" : "http://";
            String serverName = System.Web.HttpContext.Current.Request.ServerVariables.Get("SERVER_NAME");
            String serverPort = System.Web.HttpContext.Current.Request.ServerVariables.Get("SERVER_PORT");
            String serverApplicationPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            serverApplicationPath = serverApplicationPath == "/" ? serverApplicationPath : serverApplicationPath + "/";
            String serverPath = serverProtocol + serverName + ":" + serverPort + serverApplicationPath;
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}