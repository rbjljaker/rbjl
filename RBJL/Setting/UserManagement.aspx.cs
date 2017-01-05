using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LanguageUtilities;

public partial class Setting_UserManagement : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool check = Request.QueryString["user"] != null;

        if (check == true)
        {
            if (!IsPostBack)
            {
                MembershipUser User = Membership.GetUser(Request.QueryString["user"]);

                string user = User.UserName;
                string userid = User.ProviderUserKey.ToString();
                string useremail = User.Email;

                TextBoxEmail.Text = useremail;
                lblShowUsername.Text = user;


                if (!User.IsApproved)
                {
                    CheckBoxLockUser.Checked = true;
                }
                else
                {
                    CheckBoxLockUser.Checked = false;
                }
            }
        }
        else
        {
            Response.Redirect("~/Setting/loginManagement.aspx");
        }
    }

    protected void CheckBoxLockUser_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkLock = (CheckBox)sender;
        if (chkLock.Checked == true)
        {
            CheckBoxChangePassword.Checked = false;
            PanelPasswordChange.Visible = false;
        }
    }
    protected void CheckBoxChangePassword_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBoxChangePassword.Checked == true)
        {
            PanelPasswordChange.Visible = true;
            CheckBoxLockUser.Checked = false;
        }
        else
        {
            PanelPasswordChange.Visible = false;
        }
    }

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        bool updateOK = true;

        //check error first
        if (CheckBoxChangePassword.Checked == true && NewPassword.Text.Length < Membership.MinRequiredPasswordLength)
        {
    //        lblUserPasswordWarning.Text = Resources.LanguagePack.wrnMinimumPassword + " " + Membership.MinRequiredPasswordLength + " "
    //+ Resources.LanguagePack.wrnPasswordNonalphanumericRequired + " " + Membership.MinRequiredNonAlphanumericCharacters;
            updateOK = false;
            return;
        }

        MembershipUser User = Membership.GetUser(Request.QueryString["user"]);
        User.Email = TextBoxEmail.Text;
        User.IsApproved = !CheckBoxLockUser.Checked;
        Membership.UpdateUser(User);

        if (CheckBoxChangePassword.Checked == true && NewPassword.Text != "")
        {
            if (NewPassword.Text.Length >= Membership.MinRequiredPasswordLength)
            {
                User.ResetPassword();
                string UserOldPassowrd = User.ResetPassword();
                User.ChangePassword(UserOldPassowrd, ConfirmNewPassword.Text);
            }
            else
            {
                updateOK = false;
            }
        }

        if (updateOK)
        {
            Label1.Text = "";//Resources.LanguagePack.wUpdateSuccessfulMesageLoginManagement;

            //        StringBuilder redirectionScript = new StringBuilder();
            //        redirectionScript.Append("<script language='javascript'>");
            //        redirectionScript.Append("function Delayer(){");
            //        redirectionScript.Append("setTimeout('Redirection()', 1000);");
            //        redirectionScript.Append("}");
            //        redirectionScript.Append("function Redirection(){");
            //        redirectionScript.Append("window.location = 'loginManagement.aspx';");
            //        redirectionScript.Append("}");
            //        redirectionScript.Append("Delayer()");
            //        redirectionScript.Append("</script>");
            //        ClientScript.RegisterStartupScript(this.GetType(), "Startup", redirectionScript.ToString());
            redirection(1000, "loginManagement.aspx");
        }
    }
}