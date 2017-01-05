using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Web.Security;

public partial class DebitNote_PendingList : CultureEnabledPage
{
    MaterItem mItem = new MaterItem();
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);


        if (mI.userLevel != EnumUserLevel.account && mI.userLevel != EnumUserLevel.administrator)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "setDisplay", "setDisplayNone();", true);
        }

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceDebitNote.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
        EntityDataSourceMatterEdit.ContextType = EntityDataSourceMatterEdit.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);

    }
    protected void EntityDataSourceDebitNote_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        //e.DataSource.Where = SQLHelper.whereIsNull(DatabaseConst.DebitNoteCore.debitNoteNum);

        //if (EnumUserLevel.administrator == mI.userLevel || EnumUserLevel.account == mI.userLevel)
        //{
        //    e.DataSource.Where = mI.findDebitNotePendingAdmin();
        //}
        //else
        //{
        //    e.DataSource.Where = mI.findDebitNotePending();
        //}
        e.DataSource.Where = mI.findDebitNotePendingAdmin();
    }

    protected void EntityDataSourceDebitNote_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
        if (EnumUserLevel.administrator == mI.userLevel || EnumUserLevel.account == mI.userLevel)
        {

        }
        else
        {
            //var tarList = mI.findMatterTarUserListStringList();
            var tarList = mI.findMatterTarUserList();
            IQueryable<DebitNoteCore> vF = e.Query.Cast<DebitNoteCore>() as IQueryable<DebitNoteCore>;
            if (tarList.Count != 0)
            {
                var result = from q in vF
                             where tarList.Contains(q.matterNumId)
                             //where tarList.Any(q.matterNumIdList.Contains)
                             select q;
                e.Query = result;
            }
            else
            {
                var result = from q in vF
                             where "1" == "2"
                             select q;
                e.Query = result;
            }

        }
    }

    protected void GridViewDebitNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //SessionClass.DebitNoteNo = Convert.ToString(GridViewDebitNote.DataKeys[rowIndex].Value);

            SessionClass.DebitNoteNo = Convert.ToString(e.CommandArgument);
            //DetailsViewMatter.DataSource = mI.findMatterBySeesionId();
            EntityDataSourceMatterEdit.DataBind();
            DetailsViewMatter.DataBind();



            AjaxControlToolkit.CalendarExtender txtC = DetailsViewMatter.FindControl("CalendarExtenderReportDate") as AjaxControlToolkit.CalendarExtender;

            if (txtC != null)
            {
                var debitNoteInfo = mI.getDebitNoteByDebitNoteId(SessionClass.DebitNoteNo);
                txtC.EndDate = debitNoteInfo.CreateDate.Value.AddMonths(1).AddDays(-1);
                txtC.StartDate = debitNoteInfo.CreateDate.Value.AddMonths(-1).AddDays(1);
            }

            ModalPopupExtenderEdit.Show();

        }

        else if (e.CommandName == "Edit")
        {
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //SessionClass.DebitNoteNo = Convert.ToString(GridViewDebitNote.DataKeys[rowIndex].Value);

            SessionClass.DebitNoteNo = Convert.ToString(e.CommandArgument);

            var debitNoteInfo = mI.getDebitNoteByDebitNoteId(SessionClass.DebitNoteNo);

            if (!String.IsNullOrEmpty(debitNoteInfo.matterNumIdList))
            {
                Response.Redirect(String.Format("NewDebitNote.aspx?matter={0}&debitNote={1}&matterList={2}", debitNoteInfo.matterNumId, SessionClass.DebitNoteNo, debitNoteInfo.matterNumIdList));
            }
            else
            {
                Response.Redirect(String.Format("NewDebitNote.aspx?matter={0}&debitNote={1}&matterList={2}", debitNoteInfo.matterNumId, SessionClass.DebitNoteNo, debitNoteInfo.matterNumId));
            }
        }


        else if (e.CommandName == "viewReport")
        {
            string debitNoteId = Convert.ToString(e.CommandArgument);
            var link = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/DebitNoteReportNewView.aspx?dType=D&debitNoteId=", debitNoteId);
            var link2 = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/exportDebitNote.aspx?debitNoteId=", debitNoteId);
            popup(link);
            popup(link2);
        }
        else if (e.CommandName == "viewReport2")
        {
            string debitNoteId = Convert.ToString(e.CommandArgument);
            var link = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/DebitNoteReportNewView.aspx?dType=D&debitNoteId=", debitNoteId);
            var link2 = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/exportDebitNote.aspx?debitNoteId=", debitNoteId);
            popup(link+"&mustShow=true");
            popup(link2);
        }


        else if (e.CommandName == "DeleteDebitNote")
        {
            var debitNoteId = Convert.ToString(e.CommandArgument);
            DebitNoteInfo dNI = new DebitNoteInfo();
            bool doWork = dNI.delAllDebitNoteRecords(debitNoteId);
            if (doWork)
            {
                redirectPageAndDisplayAlert("Delete Record OK!", Request.Url.AbsolutePath);
            }
            else
            {
                redirectPageAndDisplayAlert("Delete Record Error!!!", Request.Url.AbsolutePath);
            }
        }

        else if (e.CommandName == "DownloadAtt")
        {
            var debitNoteId = Convert.ToString(e.CommandArgument);
            setAttFile(debitNoteId);
        }
    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        //DetailsViewClientUpdate.Visible = true;
        //ModalPopupExtenderEdit.Show();
    }
    protected void DetailsViewMatter_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", String.Format("PendingList.aspx"));
        //redirectCurrentlyPage();
    }
    protected void DetailsViewMatter_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string debitNoteNum = Convert.ToString(e.NewValues[DatabaseConst.DebitNoteCore.debitNoteNum]);
        string reportDate = Convert.ToString(e.NewValues[DatabaseConst.DebitNoteCore.reportDate]);
        string category = Convert.ToString(e.NewValues[DatabaseConst.DebitNoteCore.category]);

        var checkingPass = mI.checkingCntDebitNoteNum(debitNoteNum, category);
        if (checkingPass)
        {

            if (!String.IsNullOrEmpty(debitNoteNum) && !String.IsNullOrEmpty(reportDate))
            {
                e.NewValues[DatabaseConst.DebitNoteCore.reportDate] = DateTimeHelper.convertStringToDateTime(reportDate);
                mI.addLog(String.Format(LogConst.createDebitNotePenddingUpdate, debitNoteNum));
                sendEmail(debitNoteNum);
            }
            else
            {

                e.Cancel = true;
                displayAlert("Please Enter Debit Note No. or date");
                ModalPopupExtenderEdit.Show();
            }
        }

        else
        {
            e.Cancel = true;
            displayAlert("Debit Note no. is already exists!");
            ModalPopupExtenderEdit.Show();
        }

    }
    protected void EntityDataSourceMatterEdit_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        if (IsPostBack)
        {
            e.DataSource.Where = "it.id = GUID'" + SessionClass.DebitNoteNo + "'";
            //e.DataSource.Where = "it.id = '" + SessionClass.DebitNoteNo + "'";
            //e.DataSource.Where = "it.clientId=1";
        }
        else
        {
            e.DataSource.Where = "1 = 2";
        }
    }
    protected void DetailsViewMatter_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Email")
        {
            sendEmail("");
        }

        if (e.CommandName == "Report")
        {
            string debitNoteId = SessionClass.DebitNoteNo;
            var link = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/DebitNoteReportNewView.aspx?dType=D&debitNoteId=", debitNoteId);
            var link2 = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/exportDebitNote.aspx?debitNoteId=", debitNoteId);
            popup(link);
            popup(link2);
        }
    }


    private void sendEmail(string debitnoteNum)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string debitNoteId = SessionClass.DebitNoteNo;
        Guid debitNoteIdG = new Guid(debitNoteId);
        var debitNoteInfo = mI.getDebitNoteByDebitNoteId(debitNoteId);

        sb.AppendLine(String.Format("Client: {0}", debitNoteInfo.clientName));
        sb.AppendLine("<br/>");
        sb.AppendLine(String.Format("Referer: {0}", debitNoteInfo.refererName));
        sb.AppendLine("<br/>");
        sb.AppendLine(String.Format("Ref: {0}", debitNoteInfo.@ref));
        sb.AppendLine("<br/>");
        sb.AppendLine(String.Format("Debit Note Type: {0}", debitNoteInfo.category));
        sb.AppendLine("<br/>");
        sb.AppendLine(String.Format("Subject: {0}", debitNoteInfo.subject));

        var link = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/DebitNoteReportNewView.aspx?dType=D&debitNoteId=", debitNoteId);

        sb.AppendLine("<br/>");
        sb.AppendLine("<br/>");
        sb.AppendLine(link);

        var link2 = String.Format("{0}{1}{2}{3}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Report/exportDebitNote.aspx?debitNoteId=", debitNoteId);

        sb.AppendLine("<br/>");
        sb.AppendLine("<br/>");
        sb.AppendLine(link2);

        EmailDto emailInfo = new EmailDto();

        string pendingSubject;
        if (!String.IsNullOrEmpty(debitnoteNum))
        {
            pendingSubject = String.Format("{0}, Debit Note: ({1}), Subject - {2}", "New Debit Note - Pending List", debitnoteNum, debitNoteInfo.subject);
            var tarEmail = Membership.GetUser(debitNoteInfo.UpdateByUserId.Value as object);
            if (tarEmail != null)
            {
                emailInfo.ccTo2 = tarEmail.Email;
            }
        }
        else
        {
            pendingSubject = String.Format("{0}, Subject - {1}", "New Debit Note - Pending List", debitNoteInfo.subject);
        }

        emailInfo.subject = pendingSubject;
        emailInfo.content = sb.ToString();
        emailInfo.fromAddr = mI.currentUser.Email;
        emailInfo.ccTo = mI.currentUser.Email;

        EmailHelper email = new EmailHelper(emailInfo);
        bool checking = email.sendEmail();
        ModalPopupExtenderEdit.Show();
        string mess = checking ? "Sent" : "False";
        displayAlert(mess);
    }
    protected void DetailsViewMatter_DataBound(object sender, EventArgs e)
    {
        if (mI.userLevel != EnumUserLevel.account && mI.userLevel != EnumUserLevel.administrator)
        {
            Button btn = DetailsViewMatter.FindControl("Button1") as Button;
            if (btn != null)
            {
                btn.Visible = false;
            }
        }
    }


    public string getMatterNum(object matterList, object matterTar)
    {
        string result = "";
        //  mI.findMatterNum(tarString)

        if (matterList != null)
        {
            List<string> matterNumList = new List<string>();
            var getMatterListId = matterList.ToString();
            var tempTar = getMatterListId.Split(',');
            foreach (var tarString in tempTar)
            {
                matterNumList.Add(mI.findMatterNum(tarString));
            }
            result = String.Join(",<br/>", matterNumList.ToArray());
        }
        else
        {
            result = mI.findMatterNum(matterTar.ToString());
        }

        return result;

    }


    private void setAttFile(string debitNoteId)
    {
        ModalPopupExtenderDownloadAtt.Show();
        resetHyperLinkAtt();
        var rlt = mItem.getAttachmentsAll(new Guid(debitNoteId));
        int cnt = rlt.Count<string>();
        int i = 1;
        foreach (string item in rlt)
        {
            HyperLink hl = Page.Master.FindControl("contentplaceholdermaincontent").FindControl("lnkPopupDownloadAtt").FindControl("PanelAttachmentview").FindControl(String.Format("HyperLinkAttachment{0}", i)) as HyperLink;
            hl.Text = Resources.LanguagePack.DebitNoteCoreDownload;
            hl.Target = "_blank";
            hl.NavigateUrl = item;
            i++;
        }
    }

    private void resetHyperLinkAtt()
    {
        for (int i = 1; i <= 5; i++)
        {
            HyperLink hl = Page.Master.FindControl("contentplaceholdermaincontent").FindControl("lnkPopupDownloadAtt").FindControl("PanelAttachmentview").FindControl(String.Format("HyperLinkAttachment{0}", i)) as HyperLink;
            hl.Text = "";
            //hl.Target = "_blank";
            hl.NavigateUrl = "";
            //hl.Visible = false;
        }
    }




    public string getMatterRef(object matterRef)
    {
        string result = "";

        if (matterRef != null)
        {
            var temp = matterRef.ToString();
            result = temp.Replace("/", "/<br />").Replace(",", ",<br />");
        }


        return result;

    }

}
