using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Matter_NewMatterAdd : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
        CheckAutogen();


        if (mI.userLevel != EnumUserLevel.administrator)
        {
            CheckBox rb = Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__releaseToPublic$CheckBox1") as CheckBox;
            rb.Enabled = false;
        }

        if (!IsPostBack)
        {

        }
    }

    protected void Page_SaveStateComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setInitValue();
        }
    }

    private void CheckAutogen()
    {
        MiscellaneousSetting dbConnMiscellaneou = new MiscellaneousSetting();
        var result = dbConnMiscellaneou.getMiscellaneou("MatterNoStartFrom");

        if (result.isAutoGen)
        {
            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getMatterNoAll();


            Int64 startFrom = Convert.ToInt64(result.numberValue);

            while (rlt.Contains<string>((startFrom++).ToString()))
            {
            }
            startFrom--;

            //TextBox tb = DetailsViewMatter.FindControl("matterNum") as TextBox;
            TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__matterNum$TextBox1");
            tb.Text = startFrom.ToString();
            tb.ReadOnly = true;
        }
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatter.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void DetailsViewMatter_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        WebControl_MultiselectDropdownWithHourlyRate wc5 = DetailsViewMatter.FindControl("MultiselectDropdownFeeEarner") as WebControl_MultiselectDropdownWithHourlyRate;
        mI.addMatterAndFeeEarner(wc5.getSelectedId());
        WebControl_MultiselectDropdown wc6 = DetailsViewMatter.FindControl("MultiselectDropdownHandlingColleague") as WebControl_MultiselectDropdown;
        mI.addMatterAndHandlingColleague(wc6.getSelectedId());
        redirectPageAndDisplayAlert("OK", "New.aspx");
    }
    protected void DetailsViewMatter_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        string matterNum = Convert.ToString(e.Values[DatabaseConst.matterConst.matterNum]);
        var checkingPass = mI.checkMatternumPass(matterNum);
        if (checkingPass)
        {
            Guid id = genNewGuid();
            SessionClass.Identity = Convert.ToString(id);
            e.Values[DatabaseConst.matterConst.id] = id;

            //WebControl_DDLReferer wc1 = DetailsViewMatter.FindControl("DDLReferer") as WebControl_DDLReferer;
            //e.Values[DatabaseConst.matterConst.refererId] = wc1.DDLId;

            WebControl_DDLJobType wc2 = DetailsViewMatter.FindControl("DDLJobType") as WebControl_DDLJobType;

            e.Values[DatabaseConst.matterConst.jobTypeId] = wc2.DDLId;
            e.Values[DatabaseConst.matterConst.jobTypeName] = wc2.DDLText;

            WebControl_DDLKeywork wc3 = DetailsViewMatter.FindControl("DDLKeywork") as WebControl_DDLKeywork;

            e.Values[DatabaseConst.matterConst.masterKeywordId] = wc3.DDLId;
            e.Values[DatabaseConst.matterConst.masterKeywordName] = wc3.DDLText;

            WebControl_uploadLogo wc4 = DetailsViewMatter.FindControl("FUUploadLogo") as WebControl_uploadLogo;

            e.Values[DatabaseConst.matterConst.fileOpenDate] = DateTime.Now;

            string logoPath = null;
            bool uploadLogo = wc4.uploadLogo(ref logoPath);
            e.Values[DatabaseConst.matterConst.logo] = logoPath;
            e.Values[DatabaseConst.matterConst.status] = Convert.ToString((int)EnumStatus.Open);

            e.Values[DatabaseConst.createDate] = DateTime.Now;
            e.Values[DatabaseConst.createByUserId] = mI.userGuid;

            e.Values[DatabaseConst.updateDate] = DateTime.Now;
            e.Values[DatabaseConst.updateByUserId] = mI.userGuid;


            if (!String.IsNullOrEmpty(matterNum))
            {
                mI.addLog(String.Format(LogConst.createMatter, matterNum));
            }
            else
            {
                mI.addLog(LogConst.createMatterPendding);
            }

            e.Values[DatabaseConst.matterConst.masterKeywordName] = Convert.ToString(e.Values[DatabaseConst.matterConst.masterKeywordName]).ToUpper();
            e.Values[DatabaseConst.matterConst.customKeywordFirst] = Convert.ToString(e.Values[DatabaseConst.matterConst.customKeywordFirst]).ToUpper();
            e.Values[DatabaseConst.matterConst.customKeywordSecond] = Convert.ToString(e.Values[DatabaseConst.matterConst.customKeywordSecond]).ToUpper();
            e.Values[DatabaseConst.matterConst.customKeywordThird] = Convert.ToString(e.Values[DatabaseConst.matterConst.customKeywordThird]).ToUpper();


            WebControl_MultiselectDropdownIntroducer wc7 = DetailsViewMatter.FindControl("MultiselectDropdownIntroducer") as WebControl_MultiselectDropdownIntroducer;


            var findInList = wc7.getSelectedId();
            if (findInList != null)
            {
                e.Values[DatabaseConst.matterConst.introducer] = string.Join(",", findInList);
            }


            WebControl_MultiselectDropdownIntroducer wc8 = DetailsViewMatter.FindControl("MultiselectDropdownSP") as WebControl_MultiselectDropdownIntroducer;
            var findSPList = wc8.getSelectedId();
            if (findSPList != null)
            {
                e.Values[DatabaseConst.matterConst.SPList] = string.Join(",", findSPList);
            }
        }
        else
        {
            e.Cancel = true;
            displayAlert("Matter Number is already exists!");
        }
    }
    private void copyField(string des, string srcValue)
    {
        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__" + des + "$TextBox1");
        tb.Text = srcValue;
    }


    protected void DetailsViewMatter_PreRender(object sender, EventArgs e)
    {

    }

    private void setInitValue()
    {
        string id = Request.QueryString["matterid"];
        if (id != null)
        {
            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getMatterCore(id);

            copyField(DatabaseConst.matterConst.matterSubject, rlt.matterSubject);

            DropDownList ddClient = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__Client$DropDownList1");
            ddClient.SelectedValue = rlt.clientId.ToString();

            //var rltRefer = dbConn.getReferer(rlt.refererId.Value);
            //CheckBox cb = (CheckBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$DDLReferer$CheckBox1");
            //cb.Checked = rltRefer.islegalAid.HasValue ? rltRefer.islegalAid.Value : false;

            if (rlt.refererId.HasValue)
            {
                DropDownList ddRefer = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__Referer$DropDownList1");
                if (ddRefer != null)
                {
                    ddRefer.SelectedValue = rlt.refererId.Value.ToString();
                }
            }

            if (rlt.refererFee.HasValue)
            {
                copyField(DatabaseConst.matterConst.refererFee, rlt.refererFee.Value.ToString());
            }

            if (rlt.jobTypeId.HasValue)
            {
                var rltJobType = dbConn.getJobType(rlt.jobTypeId.Value);
                DropDownList ddJobType = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$DDLJobType$DropDownList1");
                ddJobType.SelectedValue = rlt.jobTypeId.Value.ToString();
            }

            //copyField(DatabaseConst.matterConst.discount, rlt.discount.HasValue ? rlt.discount.Value.ToString() : "");
            TextBox tbDiscount = DetailsViewMatter.FindControl("TextBoxDiscountEdit") as TextBox;
            tbDiscount.Text = rlt.discount.HasValue ? rlt.discount.Value.ToString() : "";

            //copyField(DatabaseConst.matterConst.introducer, rlt.introducer);
            //TextBox tbIntroducer = DetailsViewMatter.FindControl("TextBoxIntroducer") as TextBox;
            //tbIntroducer.Text = rlt.introducer;

            if (rlt.masterKeywordId.HasValue)
            {
                DropDownList ddmasterKeywordId = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$DDLKeywork$DropDownList1");
                ddmasterKeywordId.SelectedValue = rlt.masterKeywordId.Value.ToString();
            }
            copyField(DatabaseConst.matterConst.customKeywordFirst, rlt.customKeywordFirst);
            copyField(DatabaseConst.matterConst.customKeywordSecond, rlt.customKeywordSecond);
            copyField(DatabaseConst.matterConst.customKeywordThird, rlt.customKeywordThird);

            CheckBox cbreleaseToPublic = (CheckBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__releaseToPublic$CheckBox1");
            cbreleaseToPublic.Checked = rlt.releaseToPublic.HasValue ? rlt.releaseToPublic.Value : false;

            if (rlt.outgoingAgentId.HasValue)
            {
                DropDownList ddOutgoingAgent = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewMatter$__OutgoingAgent$DropDownList1");
                ddOutgoingAgent.SelectedValue = rlt.outgoingAgentId.Value.ToString();
            }
            copyField(DatabaseConst.matterConst.remarks, rlt.remarks);
        }
    }

    protected void DetailsViewMatter_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            redirectPage("NewMatterAdd.aspx");
        }
    }
}