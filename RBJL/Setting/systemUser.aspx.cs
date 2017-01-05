using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Web.Security;

public partial class Admin_systemUser : CultureEnabledPage, IPageInterface
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(5);", true);
        if (!IsPostBack)
        {
            BindRolesToList();
        }

        if (Request.QueryString["module"] != null && Request.QueryString["module"] == "search")
        {
            ModalPopupExtenderSearch.Show();
        }
        else
        {
            bool check = Request.QueryString["user"] != null;

            if (check == true)
            {
                if (!IsPostBack)
                {
                    ModalPopupExtenderEdit.Show();
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

                    ButtonUnlockUser.Enabled = User.IsLockedOut;

                    UserInfo uI = new UserInfo(user);
                    var userDto = uI.getUserDto();
                    TextBoxEditUserNum.Text = userDto.userNum;
                    TextBoxEditFirstName.Text = userDto.firstName;
                    TextBoxEditLastName.Text = userDto.lastName;
                    TextBoxEditNickName.Text = userDto.nickName;
                    var getRole = Roles.GetRolesForUser(user);
                    if (getRole.Length > 0)
                    {
                        DropDownListEditUserRole.SelectedValue = getRole[0];
                    }
                }
            }
            else
            {
                //Response.Redirect("~/Setting/loginManagement.aspx");
            }
        }
    }

    private void BindRolesToList()
    {
        // Get all of the roles
        string[] roles = Roles.GetAllRoles();
        //string withoutTar = "user";
        //roles = roles.Where(val => val != withoutTar).ToArray();

        DropDownList RoleList = (DropDownList)this.CreateUserWizardStep1.ContentTemplateContainer.FindControl("RoleList");
        RoleList.DataSource = roles;
        RoleList.DataBind();

        DropDownListEditUserRole.DataSource = roles;
        DropDownListEditUserRole.DataBind();

    }

    protected void CreateUserWizardLinkReit_CreatedUser(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser(CreateUserWizardLinkReit.UserName);

        if (user != null)
        {
            DropDownList dllRoleList = (DropDownList)CreateUserWizardStep1.ContentTemplateContainer.FindControl("RoleList");
            TextBox txtUserName = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("UserName");
            TextBox txtUserNum = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("TextBoxUserNum");
            TextBox txtFirstName = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("TextBoxFirstName");
            TextBox txtLastName = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("TextLastName");
            TextBox txtNickName = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("TextBoxNickName");
            //TextBox txtUnitRate = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("TextBoxUnitRate");

            var role = dllRoleList.SelectedValue;
            var userName = txtUserName.Text;
            var userNum = txtUserNum.Text;
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var nickName = txtNickName.Text;
            //var unitRate = Convert.ToDouble(txtUnitRate.Text);

            AddUserDto addUser = new AddUserDto() { userRoles = role, userNum = userNum, firstName = firstName, lastName = lastName, nickName = nickName };
            UserInfo uI = new UserInfo(userName);
            uI.addUserInfo(addUser);

            Roles.AddUserToRole(userName, role);

            uI.addLog(String.Format(LogConst.createUser, userName));
        }
    }

    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Common/Welcome.aspx");
    }


    public void DoAction()
    {
        Control wc = (Control)this.Master.FindControl("WebUserControlTwoButton");
        Button btn = (Button)wc.FindControl("ButtonAction");
        //btn.Text = "123456";
        //btn.Click += new EventHandler(ContinueButton_Click);
        //Complete Your account has been successfully created.  

        MembershipUser newUser = Membership.CreateUser(
  CreateUserWizardLinkReit.UserName,
  CreateUserWizardLinkReit.Password,
  CreateUserWizardLinkReit.Email);

    }

    public void DoCancel()
    {

    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("All", ""));
        DropDownList1.SelectedIndex = 0;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string username = ((Label)GridView1.Rows[e.NewEditIndex].Cells[1].FindControl("Label1")).Text;
        //Response.Redirect("UserManagement.aspx?user=" + username);
        Response.Redirect("systemUser.aspx?user=" + username);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow commandRow = e.Row;

            DataControlFieldCell cell = (DataControlFieldCell)commandRow.Controls[0];
            foreach (Control ctl in cell.Controls)
            {
                LinkButton link = ctl as LinkButton;
                if (link != null)
                {
                    if (link.CommandName == "Delete")
                    {
                        link.OnClientClick = "return confirm('" + "del?" + "')";
                    }
                }
            }
        }
    }
    protected void LinkButtonLoginUser_OnClick(object sender, EventArgs e)
    {
        //ModalPopupExtenderSearch.Show();
        redirectPage("systemUser.aspx?module=search");
    }
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        //ModalPopupExtenderSearch.Show();
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
    protected void ButtonUnlockUser_Click(object sender, EventArgs e)
    {
        string userName = Request.QueryString["user"];
        MembershipUser usr = Membership.GetUser(userName);

        usr.UnlockUser();
        ButtonUnlockUser.Enabled = false;
        displayAlert("ok");

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

        var userName = Request.QueryString["user"];
        MembershipUser User = Membership.GetUser(userName);
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

        UserInfo uI = new UserInfo(userName);
        var userDto = new AddUserDto();
        userDto.userNum = TextBoxEditUserNum.Text;
        userDto.firstName = TextBoxEditFirstName.Text;
        userDto.lastName = TextBoxEditLastName.Text;
        userDto.nickName = TextBoxEditNickName.Text;
        uI.editUserInfo(userDto);

        var role = DropDownListEditUserRole.SelectedValue;

        var getRole = Roles.GetRolesForUser(userName);
        if (getRole.Length > 0)
        {
            Roles.RemoveUserFromRole(userName, getRole[0]); ;
        }
        Roles.AddUserToRole(userName, role);

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
            redirectPageAndDisplayAlert("OK", "systemUser.aspx");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string userName = e.Keys["UserName"].ToString();
        UserInfo uI = new UserInfo(userName);
        uI.disableUser();
        //e.Cancel = true;
    }
}