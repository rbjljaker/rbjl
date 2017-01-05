using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using GeneralUtilities;
using System.Web.Security;


public partial class Matter_PendingList : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatter.ContextType = EntityDataSourceMatterEdit.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void GridViewMatter_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        Control ctl = e.CommandSource as Control;
        GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

        if (e.CommandName == "Select")
        {
            int rowIndex = CurrentRow.RowIndex;
            //SessionClass.MatterId = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            HiddenFieldMatterId.Value = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            //DetailsViewMatter.DataSource = mI.findMatterBySeesionId();
            EntityDataSourceMatterEdit.DataBind();
            DetailsViewMatter.DataBind();
            ModalPopupExtenderEdit.Show();
        }
        else if (e.CommandName == "Edit")
        {
            int rowIndex = CurrentRow.RowIndex;
            HiddenFieldMatterId.Value = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            var link = String.Format("MatterCore.aspx?type=0&edit=T&matter={0}", HiddenFieldMatterId.Value);
            Response.Redirect(link);
        }

        else if (e.CommandName == "DeleteMatter")
        {
            int rowIndex = CurrentRow.RowIndex;
            HiddenFieldMatterId.Value = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            Guid tarMatterId = new Guid(HiddenFieldMatterId.Value);
            mI.delMatterFee(tarMatterId);
            mI.delMatterHandlingColleagues(tarMatterId);
            mI.delMatterCore(tarMatterId);
            redirectPageAndDisplayAlert("ok", "PendingList.aspx");
        }
    }
    protected void EntityDataSourceMatterEdit_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        if (IsPostBack)
        {
            e.DataSource.Where = "it.id = GUID'" + HiddenFieldMatterId.Value + "'";
        }
        else
        {
            e.DataSource.Where = "1 = 2";
        }
    }
    protected void DetailsViewMatter_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", String.Format("MatterCore.aspx?matter={0}", HiddenFieldMatterId.Value));
    }
    protected void DetailsViewMatter_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string matterNum = Convert.ToString(e.NewValues[DatabaseConst.matterConst.matterNum]);
        var checkingPass = mI.checkMatternumPass(matterNum);
        if (checkingPass)
        {
            if (!String.IsNullOrEmpty(matterNum))
            {
                mI.addLog(String.Format(LogConst.createMatterPenddingUpdate, matterNum));
                sendEmail(matterNum);
            }
            else
            {

                e.Cancel = true;
                displayAlert("Please Enter Matter Number");
                ModalPopupExtenderEdit.Show();
            }
        }
        else
        {
            e.Cancel = true;
            displayAlert("Matter Number is already exists!");
            ModalPopupExtenderEdit.Show();
        }
    }

    protected void DetailsViewMatter_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Email")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "setMatterNum", "getMatterNum();", true);

            //string matterNum = hdnResultValue.Value;
            TextBox tbMatterNum = DetailsViewMatter.FindControl("TextBoxEditMatterNum") as TextBox;
            string matterNum = tbMatterNum.Text;

            sendEmail(matterNum);

        }
    }

    private void sendEmail(string matterNum)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string matterId = HiddenFieldMatterId.Value;
        Guid matterIdG = new Guid(HiddenFieldMatterId.Value);
        var matterInfo = mI.getMatterInfoByMatterId(matterId);
        //sb.AppendLine(String.Format("Client: {0}", matterInfo.clientName));
        //sb.AppendLine("<br/>");
        //sb.AppendLine(String.Format("Fee Earner: {0}", mI.getFeeEarnerAndHandlingColleagueByMatterId(matterIdG, EnumFeeEarnerAndHandlingColleague.FeeEarner)));
        //sb.AppendLine("<br/>");
        //sb.AppendLine(String.Format("Job Type: {0}", matterInfo.jobTypeName));
        //sb.AppendLine("<br/>");
        //sb.AppendLine(String.Format("File Open Date: {0:yyyy / MM / dd, hh mm ss}", matterInfo.fileOpenDate.Value));

        var link = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/NewMatterRecordReportView.aspx?matterId=", matterId);
        sb.AppendLine(link);



        EmailDto emailInfo = new EmailDto();


        string pendingSubject;
        if (!String.IsNullOrEmpty(matterNum))
        {
            pendingSubject = String.Format("{0}, Matter Number: ({1}), Subject - {2}", "New Matter - Pending List", matterNum, matterInfo.matterSubject);
            var tarEmail = Membership.GetUser(matterInfo.UpdateByUserId.Value as object);
            if (tarEmail != null)
            {
                emailInfo.ccTo2 = tarEmail.Email;
            }
        }
        else
        {
            pendingSubject = String.Format("{0}, Subject - {1}", "New Matter - Pending List", matterInfo.matterSubject);
        }

        emailInfo.subject = pendingSubject;
        emailInfo.content = sb.ToString();
        emailInfo.ccTo = mI.currentUser.Email;
        emailInfo.fromAddr = mI.currentUser.Email;

        EmailHelper email = new EmailHelper(emailInfo);
        bool checking = email.sendEmail();
        ModalPopupExtenderEdit.Show();
        string mess = checking ? "Sent" : "False";
        displayAlert(mess);
    }

    protected void GridViewMatter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (mI.userLevel != EnumUserLevel.administrator)
            {
                Button findDelBtn = e.Row.FindControl("LinkButtonDelete") as Button;
                if (findDelBtn != null)
                {
                    findDelBtn.Visible = false;
                }
            }
        }
    }
}