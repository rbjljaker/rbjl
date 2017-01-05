using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Web.UI.HtmlControls;
using GeneralUtilities;

public partial class Matter_MatterCore : CultureEnabledPage
{
    double totalTime = 0;
    double totalFixedCost = 0;
    double totalWittenOff = 0;
    double totalBillable = 0;
    double totalSum = 0;
    double hourlyRate = 1000;
    public MatterInfo mI = new MatterInfo();
    TimeEntryInfo tE = new TimeEntryInfo();
    EnumFeeEarnerAndHandlingColleague checkRole;
    MaterItem masterInfo = new MaterItem();


    protected void Page_Load(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
        if (!IsPostBack)
        {
            DetailsViewMatter.Fields[7].Visible = false;
            DetailsViewMatter.Fields[6].Visible = false;
            resetTime();
            timeEntryDataBind();
            checkRole = tE.getTimeEntryUserRole();
            initTab();
            base.Master.Page.Header.Title = String.Format("Master No.:{0}, Hong Kong Law Firm | Intellectual Property Lawyers | IP Lawyer - Robin Bridge& John Liu", mI.findMatterNum());
            initDDL();
            TextBoxDate.Text = String.Format("{0:dd-MMM-yyyy}", DateTime.Now);

            if (!String.IsNullOrEmpty(Request["edit"]))
            {
                DetailsViewMatter.ChangeMode(DetailsViewMode.Edit);
                TabContainerMatterCore.Tabs[1].Enabled = false;
                TabContainerMatterCore.Tabs[2].Enabled = false;
                TabContainerMatterCore.Tabs[3].Enabled = false;
                this.ButtonSendEmail.Enabled = false;
                this.LinkButtonCopyFrom.Enabled = false;
                this.ButtonSendEmail.Visible = false;
                this.LinkButtonCopyFrom.Visible = false;

                DetailsViewMatter.Fields[7].Visible = true;
                DetailsViewMatter.Fields[6].Visible = true;

                TabContainerMatterCore.Tabs[1].Visible = false;
                TabContainerMatterCore.Tabs[2].Visible = false;
                TabContainerMatterCore.Tabs[3].Visible = false;

                TabContainerMatterCore.Tabs[0].HeaderText = "Pending Matter";
            }

            RepeaterOldTimeEntry.DataSource = tE.getOldTimeEntry();
            RepeaterOldTimeEntry.DataBind();
        }

        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewMatterDetails, e);
        }

        if (checkRole == EnumFeeEarnerAndHandlingColleague.GeneralUser && EnumUserLevel.administrator != mI.userLevel && EnumUserLevel.account != mI.userLevel)
        {
            GridViewMatterDetails.Columns[11].Visible = false;
            PanelTimeEntryInsert.Visible = false;
            Button editBtn = DetailsViewMatter.FindControl("ButtonEdit") as Button;
            if (editBtn != null)
            {
                editBtn.Visible = false;
            }
        }

        if (EnumUserLevel.account == mI.userLevel)
        {
            LinkButtonCopyFrom.Visible = false;
        }


    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (DetailsViewMatter.CurrentMode == DetailsViewMode.Edit)
        {
            if (mI.userLevel == EnumUserLevel.account || mI.userLevel == EnumUserLevel.administrator || mI.userLevel == EnumUserLevel.Partner)
            {
                DetailsViewMatter.Fields[7].Visible = true;
                DetailsViewMatter.Fields[6].Visible = true;
            }
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatter.ContextType = EntityDataSourceMatterClient.ContextType = EntityDataSourceMatterRefer.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
        EntityDataSourceMatterDetailsOld.ContextType = EntityDataSourceMatterDetails.ContextType = EntityDataSourceMatter.ContextType;
    }

    protected void EntityDataSourceMatter_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = "it.id = GUID'" + Request[QueryStringConst.matter] + "'";
    }
    protected void DetailsViewMatter_DataBound(object sender, EventArgs e)
    {
        //WebControl_LBLFeeEarner wf = this.DetailsViewMatter.FindControl("uc1FeeEarner") as WebControl_LBLFeeEarner;
        //wf.findMatterUserBySeesion();
    }
    protected void EntityDataSourceMatterClient_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = "it.id = " + mI.findMatterClientId();
    }
    protected void EntityDataSourceMatterRefer_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        var checking = mI.findMatterReferId();
        if (checking.HasValue)
        {
            e.DataSource.Where = "it.id = " + checking.Value;
        }
        else
        {
            e.DataSource.Where = "it.id = 9999999999999";
        }
    }
    protected void EntityDataSourceMatterDetails_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = "it.matterId = GUID'" + Request[QueryStringConst.matter] + "'" + " and it.isEnable = true";
    }
    protected void EntityDataSourceMatterDetailsOld_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = "it.matterId = GUID'" + Request[QueryStringConst.matter] + "'" + " and it.isEnable = false";
    }

    private void initTab()
    {
        short index;
        bool check = short.TryParse(Request["type"], out index);
        if (check)
        {
            tabAction(index);
        }
    }
    private void tabAction(short tabIndex)
    {
        TabContainerMatterCore.ActiveTabIndex = tabIndex;
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
            MatterDetailDto mDD = getMatterDetailDto(true);
            mI.addMatterDetail(mDD);
            Response.Redirect(String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.TimeEntry, Request[QueryStringConst.matter]));
        }
        else
        {
            displayAlert(Resources.LanguagePack.RequiredTimeSpentAndFixedCost);
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.TimeEntry, Request[QueryStringConst.matter]));
    }

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            MatterDetailDto mDD = getMatterDetailDto(false);
            tE.editMatterDetail(mDD);
            Response.Redirect(String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.TimeEntry, Request[QueryStringConst.matter]));
        }
        else
        {
            displayAlert(Resources.LanguagePack.RequiredTimeSpentAndFixedCost);
        }
    }

    protected void GridViewMatterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double? timespan = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.timespan) as double?;
            double? fixedCost = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.fixedCost) as double?;
            double? wittenOff = null;
            double? billable = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.billable) as double?;
            double? houlyRateH = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.hourlyRateH) as double?;
            double? sum = null;
            double DHR = houlyRateH.HasValue ? houlyRateH.Value : hourlyRate;

            if (timespan.HasValue && billable.HasValue)
            {
                Label lblWittenOff = e.Row.FindControl("LabelWittenOff") as Label;
                wittenOff = timespan - billable;
                lblWittenOff.Text = String.Format("{0}", wittenOff);
            }

            if (timespan.HasValue)
            {
                Label lbl = e.Row.FindControl("LabelCountTotal") as Label;
                sum = timespan.Value * DHR;
                lbl.Text = FormatHelper.CostFormatWithDollarSign(sum.Value);
            }

            else if (fixedCost.HasValue)
            {
                Label lbl = e.Row.FindControl("LabelCountTotal") as Label;
                sum = fixedCost.Value;
                lbl.Text = FormatHelper.CostFormatWithDollarSign(fixedCost.Value);
            }

            totalTime = timespan.HasValue ? totalTime + timespan.Value : totalTime;
            totalFixedCost = fixedCost.HasValue ? totalFixedCost + fixedCost.Value : totalFixedCost;
            totalWittenOff = wittenOff.HasValue ? totalWittenOff + wittenOff.Value : totalWittenOff;
            totalBillable = billable.HasValue ? totalBillable + billable.Value : totalBillable;
            totalSum = sum.HasValue ? totalSum + sum.Value : totalSum;


            if (mI.userLevel == EnumUserLevel.administrator)
            {
                Button findDelBtn = e.Row.FindControl("LinkButtonDelete") as Button;
                if (findDelBtn != null)
                {
                    findDelBtn.Visible = true;
                }
            }

            //if (checkRole == EnumFeeEarnerAndHandlingColleague.HandlingColleague && EnumUserLevel.administrator != mI.userLevel)
            //{
            //    Guid? createUser = DataBinder.Eval(e.Row.DataItem, DatabaseConst.createByUserId) as Guid?;
            //    if (createUser.Value != tE.userGuid)
            //    {
            //        Button lb = e.Row.FindControl("LinkButtonSelect") as Button;
            //        lb.Visible = false;
            //    }
            //}
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "Total:";
            e.Row.Cells[5].Text = FormatHelper.CostFormat(totalTime);
            e.Row.Cells[6].Text = FormatHelper.CostFormat(totalFixedCost);
            e.Row.Cells[7].Text = FormatHelper.CostFormat(totalWittenOff);
            e.Row.Cells[8].Text = FormatHelper.CostFormat(totalBillable);
            e.Row.Cells[9].Text = FormatHelper.CostFormatWithDollarSign(totalSum);
        }
    }

    private void timeEntryDataBind()
    {
        this.LabelMatterNum.Text = mI.findMatterNum();
        //this.LabelFeeEarner.Text = mI.currentUser.UserName;
        this.LabelFeeEarner.Visible = false;
        ucGetStatus1.setLblValue(mI.findMatterStatus());
        this.LabelBoxItemNoValue.Text = (mI.findTimeEntryCount() + 1).ToString();

        bindFeeEarerDDL();
    }
    protected void GridViewMatterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            toolgeUpdateBtn(true);

            TimeEntryInfo tEI = new TimeEntryInfo();
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //int tarId = Convert.ToInt16(GridViewMatterDetails.DataKeys[rowIndex].Value);

            int tarId = Convert.ToInt32(e.CommandArgument);
            SessionClass.MatterDetailId = tarId.ToString();

            MatterDetailDto mDD = tEI.getMatterDetailsByDetailsId(tarId);

            //this.TextBoxItemNo.Text = mDD.itemNum.ToString();
            this.LabelBoxItemNoValue.Text = mDD.itemNum.ToString();
            this.TextBoxDate.Text = DateTimeHelper.convertDateTimeToString(mDD.date);
            this.TextBoxTimeSpent.Text = mDD.timeSpan.ToString();
            this.TextBoxFixedCost.Text = mDD.fixedCost.ToString();
            this.TextBoxDescription.Text = mDD.description.ToString();
            this.TextBoxBillable.Text = mDD.billable.ToString();
            this.LabelFeeEarner.Text = tEI.getUserNameBySystemId(mDD.feeEarner);
            HiddenFieldFeeEarnerId.Value = mDD.feeEarner.ToString();
            HiddenFieldFeeEarnerHourlyRate.Value = mDD.hourlyRateH.ToString();
            //ucDllTemplate.setDllValue(mDD.templateType.ToString(), mDD.templateDescription.ToString());

            if (mDD.fixedCostTimeSpan != 0)
            {
                this.TextBoxFixedCostTimeSpent.Text = mDD.fixedCostTimeSpan.ToString();
            }

            setEditImg();
            initDDL();
            if (tEI.userLevel == EnumUserLevel.administrator || tEI.userLevel == EnumUserLevel.Partner)
            {
                setBillable.Attributes.Clear();
            }
            LinkButtonCopyTo.Visible = true;
            LinkButtonMoveTo.Visible = true;

            TextBoxTimeSpent.ReadOnly = false;
            //DropDownListFeeEarner.Visible = false; //fee dropdownlist
            //LabelFeeEarner.Visible = true;

            bindFeeEarerDDL();
            setFeeEarnerDDLUpdate(HiddenFieldFeeEarnerId.Value);
        }
    }

    private void toolgeUpdateBtn(bool setting)
    {
        this.ButtonRun.Visible = !setting;
        this.ButtonUpdate.Visible = setting;
    }


    private MatterDetailDto getMatterDetailDto(bool isAddMode)
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
        mDD.matterId = Guid.Parse(Request[QueryStringConst.matter]);
        if (!String.IsNullOrEmpty(this.TextBoxBillable.Text))
        {
            mDD.billable = VariableHelper.DoubleHelper.TryParse(this.TextBoxBillable.Text);
        }

        mDD.fixedCostTimeSpan = VariableHelper.DoubleHelper.TryParse(this.TextBoxFixedCostTimeSpent.Text);


        if (isAddMode)
        {
            string DDLSV = DropDownListFeeEarner.SelectedValue;
            double deV;
            mDD.feeEarner = new Guid(DDLSV.Split(',')[0]);
            bool checking = Double.TryParse(DDLSV.Split(',')[1], out deV);
            mDD.hourlyRateH = checking ? deV : 1;
        }

        else
        {
            if (DropDownListFeeEarner.Items.Count > 0)
            {
                string DDLSV = DropDownListFeeEarner.SelectedValue;
                double deV;
                mDD.feeEarner = new Guid(DDLSV.Split(',')[0]);
                bool checking = Double.TryParse(DDLSV.Split(',')[1], out deV);
                mDD.hourlyRateH = checking ? deV : 1;

            }
            else
            {
                mDD.feeEarner = new Guid(HiddenFieldFeeEarnerId.Value);
                var isChangeHourlyRate = mI.getCurrMatterFeeEarnerHourlyRate(mDD.feeEarner);
                if (isChangeHourlyRate != -1)
                {
                    mDD.hourlyRateH = isChangeHourlyRate;
                }
                else
                {
                    mDD.hourlyRateH = Convert.ToDouble(HiddenFieldFeeEarnerHourlyRate.Value);
                }
            }
        }
        return mDD;
    }
    protected void LinkButtonCopyFrom_onclick(object sender, EventArgs e)
    {
        //GridViewMatter.Columns[1].Visible = true;
        //GridViewMatter.Columns[6].Visible = false;
        Response.Redirect("NewMatterAdd.aspx?matterid=" + Request[QueryStringConst.matter]);
    }
    protected void LinkButtonCopyTo_OnClick(object sender, EventArgs e)
    {
        //MatterDetailDto timeEntry = new MatterDetailDto();
        //timeEntry.itemNum=1;
        //timeEntry.description="q";

        MatterDetailDto timeEntry = getMatterDetailDto(false);



        SessionClass.timeEntry = timeEntry;
        Response.Redirect("New.aspx?timeEntry=copyto");


    }
    protected void LinkButtonMoveTo_OnClick(object sender, EventArgs e)
    {
        MatterDetailDto timeEntry = getMatterDetailDto(false);

        SessionClass.timeEntry = timeEntry;
        Response.Redirect("New.aspx?timeEntry=moveto");

    }


    protected void DetailsViewMatter_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {

        if (!String.IsNullOrEmpty(Request["edit"]))
        {
            redirectPageAndDisplayAlert("OK", String.Format("PendingList.aspx"));
        }

        else if (String.IsNullOrEmpty(SessionClass.checkIsChangeStatus))
        {
            bindFeeEarerDDL();
            redirectPageAndDisplayAlert("OK", String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.General, Request[QueryStringConst.matter]));
        }


        else
        {
            SessionClass.checkIsChangeStatus = null;
            redirectPageAndDisplayAlert("OK", String.Format("../PutAway/MatterCore.aspx?matter={0}", Request[QueryStringConst.matter]));
        }
    }

    protected void DetailsViewMatter_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

        if (mI.userLevel == EnumUserLevel.administrator)
        {
            string matterNum = Convert.ToString(e.NewValues[DatabaseConst.matterConst.matterNum]);
            string matterNumOld = Convert.ToString(e.OldValues[DatabaseConst.matterConst.matterNum]);

            if (matterNum != matterNumOld)
            {

                var checkingPass = mI.checkMatternumPass(matterNum);
                if (checkingPass)
                {
                    if (!String.IsNullOrEmpty(matterNum))
                    {
                        //mI.addLog(String.Format(LogConst.createMatterPenddingUpdate, matterNum));
                    }
                    else
                    {

                        e.Cancel = true;
                        displayAlert("Please Enter Matter Number");
                        return;
                    }
                }
                else
                {
                    e.Cancel = true;
                    displayAlert("Matter Number is already exists!");
                    return;
                }
            }
        }


        //e.NewValues[DatabaseConst.matterConst.masterKeywordName] = Convert.ToString(e.NewValues[DatabaseConst.matterConst.masterKeywordName]).ToUpper();
        e.NewValues[DatabaseConst.matterConst.customKeywordFirst] = Convert.ToString(e.NewValues[DatabaseConst.matterConst.customKeywordFirst]).ToUpper();
        e.NewValues[DatabaseConst.matterConst.customKeywordSecond] = Convert.ToString(e.NewValues[DatabaseConst.matterConst.customKeywordSecond]).ToUpper();
        e.NewValues[DatabaseConst.matterConst.customKeywordThird] = Convert.ToString(e.NewValues[DatabaseConst.matterConst.customKeywordThird]).ToUpper();

        WebControl_uploadLogo wc4 = DetailsViewMatter.FindControl("FUUploadLogo") as WebControl_uploadLogo;

        string logoPath = null;
        bool uploadLogo = wc4.uploadLogo(ref logoPath);
        if (uploadLogo)
        {
            e.NewValues[DatabaseConst.matterConst.logo] = logoPath;
        }


        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;

        WebControl_DDLMasterKeywordUpdate wcMKU = DetailsViewMatter.FindControl("uc1MKW") as WebControl_DDLMasterKeywordUpdate;
        e.NewValues[DatabaseConst.matterConst.masterKeywordId] = wcMKU.DDLId;
        e.NewValues[DatabaseConst.matterConst.masterKeywordName] = wcMKU.DDLText;

        e.NewValues[DatabaseConst.matterConst.masterKeywordName] = Convert.ToString(e.NewValues[DatabaseConst.matterConst.masterKeywordName]).ToUpper();

        WebControl_DDLJobTypeUpdate wc2 = DetailsViewMatter.FindControl("ucJTUpdate") as WebControl_DDLJobTypeUpdate;

        e.NewValues[DatabaseConst.matterConst.jobTypeId] = wc2.DDLId;
        e.NewValues[DatabaseConst.matterConst.jobTypeName] = wc2.DDLText;


        DropDownList DropDownListMatterstatus = DetailsViewMatter.FindControl("DropDownListMatterstatus") as DropDownList;
        string status = DropDownListMatterstatus.SelectedValue;

        if (mI.userLevel != EnumUserLevel.administrator)
        {
            e.NewValues[DatabaseConst.matterConst.matterNum] = e.OldValues[DatabaseConst.matterConst.matterNum];
            e.NewValues[DatabaseConst.matterConst.matterSubject] = e.OldValues[DatabaseConst.matterConst.matterSubject];
            e.NewValues[DatabaseConst.matterConst.discount] = e.OldValues[DatabaseConst.matterConst.discount];
            //e.NewValues[DatabaseConst.matterConst.hourlyRate] = e.OldValues[DatabaseConst.matterConst.hourlyRate];
            //e.NewValues[DatabaseConst.matterConst.jobTypeName] = e.OldValues[DatabaseConst.matterConst.jobTypeName];
            e.NewValues[DatabaseConst.matterConst.releaseToPublic] = e.OldValues[DatabaseConst.matterConst.releaseToPublic];
        }

        if (checkRole == EnumFeeEarnerAndHandlingColleague.FeeEarner)
        {
            TimeEntryInfo timeEntryInfo = new TimeEntryInfo();
            timeEntryInfo.editMattercore(Guid.Parse(Request[QueryStringConst.matter]), status);

            if (status == "3")
            {
                //MatterInfo mI = new MatterInfo();

                e.NewValues[DatabaseConst.putAwayDate] = DateTime.Now;
                //e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
                SessionClass.checkIsChangeStatus = "3";
            }
        }
        WebControl_MultiselectDropdownWithHourlyRate wcMuFeeEarner = DetailsViewMatter.FindControl("ucWebUserControlMultiselectDropdownFeeEarner") as WebControl_MultiselectDropdownWithHourlyRate;
        WebControl_MultiselectDropdown wcMuHandlingColleague = DetailsViewMatter.FindControl("ucWebUserControlMultiselectDropdownHandlingColleague") as WebControl_MultiselectDropdown;
        doMatterUserManagementWithHourlyRate(wcMuFeeEarner, EnumFeeEarnerAndHandlingColleague.FeeEarner);
        doMatterUserManagement(wcMuHandlingColleague, EnumFeeEarnerAndHandlingColleague.HandlingColleague);



        WebControl_MultiselectDropdownIntroducer wc8 = DetailsViewMatter.FindControl("ucWebUserControlSP") as WebControl_MultiselectDropdownIntroducer;
        var findSPList = wc8.getSelectedId();
        if (findSPList != null)
        {
            e.NewValues[DatabaseConst.matterConst.SPList] = string.Join(",", findSPList);
        }
        else
        {
            e.NewValues[DatabaseConst.matterConst.SPList] = "";
        }
    }

    private void doMatterUserManagement(WebControl_MultiselectDropdown wcMu, EnumFeeEarnerAndHandlingColleague type)
    {
        if (wcMu != null)
        {
            List<string> getValue = wcMu.getSelectedId();
            mI.updateMatterUser(getValue, type);
        }
    }

    private void doMatterUserManagementWithHourlyRate(WebControl_MultiselectDropdownWithHourlyRate wcMu, EnumFeeEarnerAndHandlingColleague type)
    {
        if (wcMu != null)
        {
            List<HourlyRateDto> getValue = wcMu.getSelectedId();
            mI.updateMatterUser(getValue, type);
        }
    }

    protected void DetailsViewMatter_ModeChanged(object sender, EventArgs e)
    {
        if (DetailsViewMatter.CurrentMode != DetailsViewMode.Edit)
            return;

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
        if (tE.userLevel == EnumUserLevel.administrator || tE.userLevel == EnumUserLevel.Partner)
        {
            setBillable.Attributes.Clear();
        }
    }

    private void bindFeeEarerDDL()
    {
        DropDownListFeeEarner.Items.Clear();
        var getList = tE.getFeeEarnerDDLList();
        foreach (var item in getList)
        {
            addItem(DropDownListFeeEarner, item.value, item.id);
        }
        try
        {
            if (mI.userLevel == EnumUserLevel.FeeEarner || mI.userLevel == EnumUserLevel.Partner)
                foreach (ListItem item in DropDownListFeeEarner.Items)
                {
                    if (item.Value.Contains(mI.userGuid.ToString()))
                    {
                        DropDownListFeeEarner.SelectedValue = item.Value;
                    }

                }
        }
        catch { }
    }
    protected void ButtonSendEmail_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string matterId = Request["matter"];
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
        emailInfo.subject = String.Format("Matter Info, Matter Num:{0}, Subject:{1}", matterInfo.matterNum, matterInfo.matterSubject);
        emailInfo.content = sb.ToString();
        emailInfo.ccTo = mI.currentUser.Email;
        emailInfo.fromAddr = mI.currentUser.Email;

        EmailHelper email = new EmailHelper(emailInfo);
        bool checking = email.sendEmail();
        string mess = checking ? "Sent" : "False";
        displayAlert(mess);
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


    protected void RepeaterOldTimeEntry_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            if (((TimeEntryInfoDto)e.Item.DataItem).isContent)
            {
                //  ((System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("repSubTotal")).Visible = false;
                ((System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("repSubTotal")).Attributes.Add("style", "display:none");
            }
            else
            {
                //((System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("repContect")).Visible = false;
                ((System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("repContect")).Attributes.Add("style", "display:none");
            }
        }
    }

    private void setFeeEarnerDDLUpdate(string userGuidString)
    {
        try
        {
            foreach (ListItem item in DropDownListFeeEarner.Items)
            {
                if (item.Value.Contains(userGuidString))
                {
                    DropDownListFeeEarner.SelectedValue = item.Value;
                }
            }
        }
        catch
        {

        }
    }

    protected void ButtonMultiCopy_Click(object sender, EventArgs e)
    {
        doCopyAndMove("C");
    }

    protected void ButtonMultiMove_Click(object sender, EventArgs e)
    {
        doCopyAndMove("M");
    }

    private void doCopyAndMove(string type)
    {
        var result = getCheckBoxSelectTar();
        if (!String.IsNullOrEmpty(result))
        {
            //displayAlert(result);
            var link = String.Format("New.aspx?{0}={1}&{2}={3}", QueryStringConst.mCType, type, QueryStringConst.details, result);
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
                int matterDetailsId = Convert.ToInt32(GridViewMatterDetails.DataKeys[i].Value);
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
