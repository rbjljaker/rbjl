using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Web.UI.HtmlControls;
using GeneralUtilities;

public partial class Matter_NewFollowUp : CultureEnabledPage
{
    MaterItem masterInfo = new MaterItem();
    MatterInfo mI = new MatterInfo();
    TimeEntryInfo tE = new TimeEntryInfo();
    int i = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
        if (!IsPostBack)
        {
            resetTime();
            timeEntryDataBind();
            base.Master.Page.Header.Title = String.Format("Draft Time Entri(es) , Hong Kong Law Firm | Intellectual Property Lawyers | IP Lawyer - Robin Bridge& John Liu");
            initDDL();
            TextBoxDate.Text = String.Format("{0:dd-MMM-yyyy}", DateTime.Now);


        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewMatterDetails, e);
        }
    }
    protected void Page_SaveStateComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebControl_DDLFeeEarner feeEarnerDDL = this.Master.FindControl("ContentPlaceHolderMainContent").FindControl("ucDDLFeeEarner") as WebControl_DDLFeeEarner;
            feeEarnerDDL.DDLId = mI.userGuid.ToString();
        }
    }

    protected void EntityDataSourceMatterDetails_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        if (mI.userLevel == EnumUserLevel.administrator)
        {
            e.DataSource.Where = tE.findAdminDraftMatter();
        }
        else
        {
            e.DataSource.Where = tE.findDraftMatter();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatterDetails.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }

    private void timeEntryDataBind()
    {
        this.LabelBoxItemNoValue.Text = tE.countDraftItemNum().ToString();
    }

    protected void ImageButtonStart_Click(object sender, ImageClickEventArgs e)
    {
        if (String.IsNullOrEmpty(HiddenFieldTimeStart.Value))
        {
            HiddenFieldTimeStart.Value = DateTime.Now.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "Start", "timer.start(1000)", true);
        }
        else if (!String.IsNullOrEmpty(HiddenFieldTimeStart.Value) && !String.IsNullOrEmpty(HiddenFieldTimeEnd.Value))
        {
            int currTime = getTime();
            HiddenFieldTimeEnd.Value = null;
            HiddenFieldTimeStart.Value = DateTime.Now.AddSeconds(currTime * -1).ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "Reset", String.Format("timer.reset({0})", currTime), true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Start", "timer.start(1000)", true);
        }
        setImg(false);
        setStopImg(true);
    }
    protected void ImageButtonPause_Click(object sender, ImageClickEventArgs e)
    {
        if (!String.IsNullOrEmpty(HiddenFieldTimeStart.Value) && String.IsNullOrEmpty(HiddenFieldTimeEnd.Value))
        {
            HiddenFieldTimeEnd.Value = DateTime.Now.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "Stop", "timer.stop()", true);
            getTime();
        }
        else
        {

        }
        setImg(true);
    }
    protected void ImageButtonStop_Click(object sender, ImageClickEventArgs e)
    {
        if (!String.IsNullOrEmpty(HiddenFieldTimeStart.Value) && !String.IsNullOrEmpty(HiddenFieldTimeEnd.Value))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Stop", "timer.stop()", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Reset", "timer.reset(0)", true);
            setTimeSpan();
            resetTime();
        }
        else if (!String.IsNullOrEmpty(HiddenFieldTimeStart.Value) && String.IsNullOrEmpty(HiddenFieldTimeEnd.Value))
        {
            HiddenFieldTimeEnd.Value = DateTime.Now.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "Stop", "timer.stop()", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Reset", "timer.reset(0)", true);
            setTimeSpan();
            resetTime();
        }
    }

    private int getTime()
    {
        DateTime dateStop = DateTime.Parse(HiddenFieldTimeEnd.Value);
        DateTime dateStart = DateTime.Parse(HiddenFieldTimeStart.Value);
        var count = dateStop - dateStart;
        int time = Convert.ToInt16(count.TotalSeconds);
        setTime(time, this.timeId);
        return time;
    }

    private void setTime(int time, HtmlGenericControl htmlControl)
    {
        var second = time % 60;
        var minute = time / 60 % 60;
        var hour = time / 3600 % 60;

        string secondD = (second < 10) ? String.Format("0{0}", second) : String.Format("{0}", second);
        string minuteD = (minute < 10) ? String.Format("0{0}", minute) : String.Format("{0}", minute);
        string hourD = (hour < 10) ? String.Format("0{0}", hour) : String.Format("{0}", hour);

        var result = String.Format("{0}:{1}:{2}", hourD, minuteD, secondD);
        htmlControl.InnerText = result;
    }
    private void resetTime()
    {
        var result = String.Format("00:00:00");
        this.timeId.InnerText = result;
        HiddenFieldTimeStart.Value = null;
        HiddenFieldTimeEnd.Value = null;
        setImg(true);
        setStopImg(false);
    }

    private void setImg(bool setting)
    {
        this.ImageButtonStart.Enabled = setting;
        this.ImageButtonPause.Enabled = !setting;

        if (setting)
        {
            this.ImageButtonStart.ImageUrl = "~/images/__btn_play_hover.png";
            this.ImageButtonPause.ImageUrl = "~/images/__btn_pause.png";
        }
        else
        {
            this.ImageButtonStart.ImageUrl = "~/images/__btn_play.png";
            this.ImageButtonPause.ImageUrl = "~/images/__btn_pause_hover.png";
            var result = String.Format("00:00:00");
            this.timeStop.InnerText = result;
            this.TextBoxTimeSpent.Text = "";
        }
    }

    private void setStopImg(bool setting)
    {
        this.ImageButtonStop.Enabled = setting;
        if (setting)
        {
            this.ImageButtonStop.ImageUrl = "~/images/__btn_stop_hover.png";
        }
        else
        {
            this.ImageButtonStop.ImageUrl = "~/images/__btn_stop.png";
        }
    }

    private void setEditImg()
    {
        this.ImageButtonStart.Enabled = false;
        this.ImageButtonPause.Enabled = false;
        this.ImageButtonStart.ImageUrl = "~/images/__btn_play.png";
        this.ImageButtonPause.ImageUrl = "~/images/__btn_pause.png";
        setStopImg(false);
    }

    private void setTimeSpan()
    {
        int totalSec = getTime();
        double tempCount = totalSec / 180.0;
        tempCount = Math.Ceiling(tempCount);
        double result = tempCount * 0.05;
        this.TextBoxTimeSpent.Text = FormatHelper.CostFormat(result);
        setTime(totalSec, timeStop);
    }
    protected void ButtonRun_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            MatterDetailDto mDD = getMatterDetailDto();
            mI.addMatterDetailPendingList(mDD);
            redirectPageAndDisplayAlert("OK", "NewFollowUp.aspx?matter=EE28CD2C-D1C3-45A7-B315-42BAEBF6F830");
        }
        else
        {
            displayAlert(Resources.LanguagePack.RequiredTimeSpentAndFixedCost);
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        MatterDetailDto mDD = getMatterDetailDto();
        tE.editMatterDetailPendingList(mDD);
        redirectPageAndDisplayAlert("OK", "NewFollowUp.aspx?matter=EE28CD2C-D1C3-45A7-B315-42BAEBF6F830");
    }

    private void toolgeUpdateBtn(bool setting)
    {
        this.ButtonRun.Visible = !setting;
        this.ButtonUpdate.Visible = setting;
    }


    private MatterDetailDto getMatterDetailDto()
    {
        MatterDetailDto mDD = new MatterDetailDto();
        //mDD.itemNum = Convert.ToInt16(this.TextBoxItemNo.Text);
        mDD.date = DateTimeHelper.convertStringToDateTime(this.TextBoxDate.Text);
        if (!String.IsNullOrEmpty(this.TextBoxTimeSpent.Text))
        {
            mDD.timeSpan = VariableHelper.DoubleHelper.TryParse(this.TextBoxTimeSpent.Text);
        }
        if (!String.IsNullOrEmpty(this.TextBoxFixedCost.Text))
        {
            mDD.fixedCost = VariableHelper.DoubleHelper.TryParse(this.TextBoxFixedCost.Text);
        }
        //mDD.templateType = Convert.ToInt16(ucDllTemplate.DDLId);
        //mDD.templateDescription = ucDllTemplate.DDLText;

        mDD.templateType = Convert.ToInt16(this.DropDownListTemplateDetails.SelectedItem.Value);
        mDD.templateDescription = this.DropDownListTemplateDetails.SelectedItem.Text;

        mDD.description = this.TextBoxDescription.Text;
        mDD.matterId = mI.tempTimeEntryId;//Guid.Parse(SessionClass.MatterId);
        if (!String.IsNullOrEmpty(this.TextBoxBillable.Text))
        {
            mDD.billable = VariableHelper.DoubleHelper.TryParse(this.TextBoxBillable.Text);
        }

        var isBS = DropDownListIsBilled.SelectedValue;
        bool isBilled = isBS == "T" ? true : false;
        mDD.isBill = isBilled;

        WebControl_DDLFeeEarner feeEarnerDDL = this.Master.FindControl("ContentPlaceHolderMainContent").FindControl("ucDDLFeeEarner") as WebControl_DDLFeeEarner;
        mDD.feeEarner = new Guid(feeEarnerDDL.DDLId);

        mDD.fixedCostTimeSpan = VariableHelper.DoubleHelper.TryParse(this.TextBoxFixedCostTimeSpent.Text);

        return mDD;
    }
    protected void LinkButtonCopyFrom_onclick(object sender, EventArgs e)
    {
        Response.Redirect("NewMatterAdd.aspx?matterid=" + Request[QueryStringConst.matter]);


    }
    protected void LinkButtonCopyTo_OnClick(object sender, EventArgs e)
    {
        MatterDetailDto timeEntry = getMatterDetailDto();
        SessionClass.timeEntry = timeEntry;
        Response.Redirect("New.aspx?timeEntry=copyto");


    }
    protected void LinkButtonMoveTo_OnClick(object sender, EventArgs e)
    {
        MatterDetailDto timeEntry = getMatterDetailDto();

        SessionClass.timeEntry = timeEntry;
        Response.Redirect("New.aspx?timeEntry=moveto");
    }

    protected void GridViewMatterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditMatter")
        {
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //int tarId = Convert.ToInt16(GridViewMatterDetails.DataKeys[rowIndex].Value);

            int tarId = Convert.ToInt32(e.CommandArgument);
            SessionClass.MatterDetailId = tarId.ToString();

            var tempTar = tE.getMatterDetailsByDetailsId(tarId);
            tempTar.isBill = true;
            SessionClass.timeEntry = tempTar;
            Response.Redirect("New.aspx?timeEntry=movetoDTE");
        }
        else if (e.CommandName == "Select")
        {
            toolgeUpdateBtn(true);

            TimeEntryInfo tEI = new TimeEntryInfo();
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //int tarId = Convert.ToInt16(GridViewMatterDetails.DataKeys[rowIndex].Value);

            int tarId = Convert.ToInt32(e.CommandArgument);
            SessionClass.MatterDetailId = tarId.ToString();

            MatterDetailDto mDD = tEI.getMatterDetailsByDetailsId(tarId);

            //this.TextBoxItemNo.Text = mDD.itemNum.ToString();
            //this.LabelBoxItemNoValue.Text = mDD.itemNum.ToString();
            this.TextBoxDate.Text = DateTimeHelper.convertDateTimeToString(mDD.date);
            this.TextBoxTimeSpent.Text = mDD.timeSpan.ToString();
            this.TextBoxFixedCost.Text = mDD.fixedCost.ToString();
            this.TextBoxDescription.Text = mDD.description.ToString();
            //this.TextBoxBillable.Text = mDD.billable.ToString();
            //this.LabelFeeEarner.Text = tEI.getUserNameBySystemId(mDD.feeEarner);
            //HiddenFieldFeeEarnerId.Value = mDD.feeEarner.ToString();
            //HiddenFieldFeeEarnerHourlyRate.Value = mDD.hourlyRateH.ToString();
            if (mDD.fixedCostTimeSpan != 0)
            {
                this.TextBoxFixedCostTimeSpent.Text = mDD.fixedCostTimeSpan.ToString();
            }
            string checkingIsB = mDD.isBill ? "T" : "F";
            DropDownListIsBilled.SelectedValue = checkingIsB;
            WebControl_DDLFeeEarner wcFee = this.Master.FindControl("ContentPlaceHolderMainContent").FindControl("ucDDLFeeEarner") as WebControl_DDLFeeEarner;
            wcFee.DDLId = mDD.feeEarner.ToString();
            setEditImg();
        }
    }

    protected void CustomValidatorTimeSpentAndFixedCost_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = ((!String.IsNullOrEmpty(TextBoxTimeSpent.Text) && !String.IsNullOrEmpty(TextBoxFixedCost.Text)) || (String.IsNullOrEmpty(TextBoxTimeSpent.Text) && String.IsNullOrEmpty(TextBoxFixedCost.Text))) ? false : true;
    }
    protected void DropDownListTemplateDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListTemplateDetails.SelectedValue != "-1")
        {
            TextBoxDescription.Text = DropDownListTemplateDetails.SelectedItem.Text;
        }
    }
    protected void DropDownListTemplateCore_SelectedIndexChanged(object sender, EventArgs e)
    {
        initDDL();
    }

    private void initDDL()
    {
        addItemHr(DropDownListTemplateDetails);
        var getList = masterInfo.getTemplDDL(DropDownListTemplateCore.SelectedValue);
        foreach (var item in getList)
        {
            addItem(DropDownListTemplateDetails, item.value, item.id);
        }
    }


    private void addItem(DropDownList ddl, string text, string value)
    {
        ddl.Items.Add(new ListItem(text, value));
    }

    private void addItemHr(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("------", "-1"));
    }
    protected void TextBoxTimeSpent_TextChanged(object sender, EventArgs e)
    {
        TextBoxFixedCost.Enabled = String.IsNullOrEmpty(TextBoxTimeSpent.Text);
        TextBoxFixedCostTimeSpent.Enabled = String.IsNullOrEmpty(TextBoxTimeSpent.Text);
        cleanText();
    }
    protected void TextBoxFixedCost_TextChanged(object sender, EventArgs e)
    {
        TextBoxTimeSpent.Enabled = (String.IsNullOrEmpty(TextBoxFixedCost.Text) && String.IsNullOrEmpty(TextBoxFixedCostTimeSpent.Text));
        cleanText();
    }
    protected void TextBoxFixedCostTimeSpent_TextChanged(object sender, EventArgs e)
    {
        TextBoxTimeSpent.Enabled = (String.IsNullOrEmpty(TextBoxFixedCost.Text) && String.IsNullOrEmpty(TextBoxFixedCostTimeSpent.Text));
        cleanText();
    }



    private void cleanText()
    {
        if (!TextBoxFixedCost.Enabled)
        {
            TextBoxFixedCost.Text = "";
        }
        if (!TextBoxTimeSpent.Enabled)
        {
            TextBoxTimeSpent.Text = "";
        }
        if (!TextBoxFixedCostTimeSpent.Enabled)
        {
            TextBoxFixedCostTimeSpent.Text = "";
        }
    }

    protected void GridViewMatterDetails_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", "NewFollowUp.aspx?matter=EE28CD2C-D1C3-45A7-B315-42BAEBF6F830");
    }
    protected void GridViewMatterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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

            Label itemNum = e.Row.FindControl("LabelItemNum") as Label;
            if (itemNum != null)
            {

                itemNum.Text = (i + (GridViewMatterDetails.PageSize * GridViewMatterDetails.PageIndex)).ToString();
            }
            i++;
        }
    }
    protected void GridViewMatterDetails_DataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }


    public string showString(object tar)
    {
        return StringHelper.setSubSttring(tar);
    }

    protected void ButtonMultiMove_Click(object sender, EventArgs e)
    {
        var result = getCheckBoxSelectTar();
        if (!String.IsNullOrEmpty(result))
        {
            //displayAlert(result);
            var link = String.Format("New.aspx?{0}={1}&{2}={3}", QueryStringConst.mCType, "M", QueryStringConst.details, result);
            Response.Redirect(link);
        }
        else
        {
            displayAlert(Resources.LanguagePack.SelectTarMatterDetails);
        }
    }

    private string getCheckBoxSelectTar()
    {
        string result = String.Empty;
        int i;
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        List<string> tempList = new List<string>();

        for (i = 0; i < this.GridViewMatterDetails.Rows.Count; i++)
        {
            if (((CheckBox)GridViewMatterDetails.Rows[i].FindControl("CheckBoxCopyOrMove")).Checked)
            {
                int matterDetailsId = Convert.ToInt16(GridViewMatterDetails.DataKeys[i].Value);
                tempList.Add(matterDetailsId.ToString());
            }
        }

        if (tempList.Count > 0)
        {
            result = String.Join(",", tempList);
        }
        return result;
    }
}