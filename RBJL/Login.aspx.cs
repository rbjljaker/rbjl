using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LanguageUtilities;

public partial class Login : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LanguageHandler.SetLanguage(Context, Languages.English);
        if (!IsPostBack && Membership.GetUser() != null)
        {
            Response.Redirect("~/roleRedirector.ashx");
        }
        //else if (!IsPostBack)
        //{
        //    Image captcha = (Image)LoginMyLogin.FindControl("ImageCaptcha");
        //    captcha.ImageUrl = "~/CaptchaCreator.ashx";
        //}
    }

    protected void LoginMyLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        LogEvent le = new LogEvent(LoginMyLogin.UserName);
        if (Membership.ValidateUser(LoginMyLogin.UserName, LoginMyLogin.Password))
        {
            le.addLog(LogConst.loginSuccess);
            //SessionClass.userLevel = le.userLevel;
            FormsAuthentication.RedirectFromLoginPage(LoginMyLogin.UserName, LoginMyLogin.RememberMeSet);
        }
        else
        {
            le.addLog(LogConst.loginFail);
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
    }

    protected void LoginMyLogin_LoginError(object sender, EventArgs e)
    {
        //  Response.Redirect("http://www.google.com.hk");
    }

    protected void LoginMyLogin_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        TextBox captcha = (TextBox)LoginMyLogin.FindControl("Captcha");
        if (SessionClass.CurrentCaptcha != captcha.Text)
        {
            Literal ll = (Literal)LoginMyLogin.FindControl("FailureText");
            ll.Text = Resources.LanguagePack.loginCaptchaError;
            e.Cancel = true;
        }
    }
}