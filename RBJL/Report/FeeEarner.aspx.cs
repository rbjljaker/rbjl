using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;

public partial class Report_FeeEarner : CultureEnabledPage
{
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(2);", true);
        if (!IsPostBack)
        {
            initControl(false);



            if (rI.userLevel == EnumUserLevel.GeneralUser)
            {
                PanelFeeEarnerChart.Visible = false;
            }

        }
    }

    private void initControl(bool setting)
    {
        DropDownListFeeEarner.Enabled = setting;
        DropDownListClient.Enabled = setting;
        DropDownListMatterNo.Enabled = setting;
        DropDownListRefer.Enabled = setting;
        DropDownListJobType.Enabled = setting;
        if (!setting)
        {
            DropDownListFeeEarner.Items.Clear();
            DropDownListClient.Items.Clear();
            DropDownListMatterNo.Items.Clear();
            DropDownListRefer.Items.Clear();
            DropDownListJobType.Items.Clear();
        }
    }

    private void clearDDL(DropDownList ddl)
    {
        ddl.Enabled = false;
        ddl.Items.Clear();
    }

    protected void TextBoxDate_TextChanged(object sender, EventArgs e)
    {
        dateFormTo();
    }

    protected void TextBoxDateTo_TextChanged(object sender, EventArgs e)
    {
        dateFormTo();
    }

    private void dateFormTo()
    {
        if (String.IsNullOrEmpty(TextBoxDate.Text) || String.IsNullOrEmpty(TextBoxDateTo.Text))
        {
            initControl(false);
        }
        else
        {
            initControl(true);
            bindDDL(null);
        }
    }

    protected void DropDownListFeeEarner_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportFeeEarner.feeEarner);
    }

    protected void DropDownListClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportFeeEarner.client);
    }

    protected void DropDownListMatterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportFeeEarner.matterNum);
    }

    protected void DropDownListRefer_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportFeeEarner.referer);
    }
    protected void DropDownListJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportFeeEarner.jobType);
    }


    //private void addItemByDate()
    //{
    //    addItemHr(DropDownListFeeEarner);
    //    var tarLsit = rI.getNewRecordUser(getDateTime(), getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListFeeEarner, item.value, item.id);
    //    }
    //}

    //private void addItemByDateAndFeeEarner()
    //{
    //    addItemHr(DropDownListClient);

    //    var tarLsit = rI.getMatterFeeEarnerClient(getDateTime(), DropDownListFeeEarner.SelectedValue, getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListClient, item.value, item.id);
    //    }
    //}

    //private void addItemByDateAndFeeEarnerAndClient()
    //{
    //    addItemHr(DropDownListMatterNo);

    //    var tarLsit = rI.getMatterFeeEarnerClientAndMatterNum(getDateTime(), DropDownListFeeEarner.SelectedValue, DropDownListClient.SelectedValue, getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListMatterNo, item.value, item.id);
    //    }
    //}


    public void addItemFeeEarner()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportFeeEarner.feeEarner);
        var tarLsit = rI.bindListNewRecordFeeEarner(findMatter);
        bindDDL(DropDownListFeeEarner, tarLsit);

    }

    public void addItemMatterNum()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportFeeEarner.matterNum);
        var tarLsit = rI.bindListNewRecordMatterNum(findMatter);
        bindDDL(DropDownListMatterNo, tarLsit);
    }

    public void addItemMatterClient()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportFeeEarner.client);
        var tarLsit = rI.bindListNewRecordMatterClient(findMatter);
        bindDDL(DropDownListClient, tarLsit);
    }

    public void addItemMatterReferer()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportFeeEarner.referer);
        var tarLsit = rI.bindListNewRecordMatterReferer(findMatter);
        bindDDL(DropDownListRefer, tarLsit);
    }

    public void addItemMatterJobType()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportFeeEarner.jobType);
        var tarLsit = rI.bindListNewRecordMatterJobType(findMatter);
        bindDDL(DropDownListJobType, tarLsit);
    }

    private void bindDDL(DropDownList ddl, List<DDLValueDto> tarLsit)
    {
        string tempValue = ddl.SelectedValue;
        ddl.Items.Clear();
        addItemHr(ddl);
        foreach (DDLValueDto item in tarLsit)
        {
            addItem(ddl, item.value, item.id);
        }

        if (!String.IsNullOrEmpty(tempValue) && ddl.Items.Count > 1)
        {
            ddl.SelectedValue = tempValue;
        }
    }

    private IQueryable<View_FindMatter> getData()
    {
        var findMatter = rI.findMatterReport();
        rI.findMatterReportByDate(ref findMatter, this.TextBoxDate.Text, this.TextBoxDateTo.Text);
        return findMatter;
    }

    private void filter(ref IQueryable<View_FindMatter> findMatter, EnumReportFeeEarner type)
    {
        if (type != EnumReportFeeEarner.feeEarner)
        {
            if (DropDownListFeeEarner.SelectedValue != "-1" && DropDownListFeeEarner.SelectedValue != "")
            {
                rI.findMatterReportByFeeEarner(ref findMatter, DropDownListFeeEarner.SelectedValue);
            }
        }
        if (type != EnumReportFeeEarner.matterNum)
        {
            if (DropDownListMatterNo.SelectedValue != "-1" && DropDownListMatterNo.SelectedValue != "")
            {
                rI.findMatterReportById(ref findMatter, DropDownListMatterNo.SelectedValue);
            }
        }
        if (type != EnumReportFeeEarner.client)
        {
            if (DropDownListClient.SelectedValue != "-1" && DropDownListClient.SelectedValue != "")
            {
                rI.findMatterReportByClinetId(ref findMatter, DropDownListClient.SelectedValue);
            }
        }
        if (type != EnumReportFeeEarner.referer)
        {
            if (DropDownListRefer.SelectedValue != "-1" && DropDownListRefer.SelectedValue != "")
            {
                rI.findMatterReportByRefererId(ref findMatter, DropDownListRefer.SelectedValue);
            }
        }
        if (type != EnumReportFeeEarner.jobType)
        {
            if (DropDownListJobType.SelectedValue != "-1" && DropDownListJobType.SelectedValue != "")
            {
                rI.findMatterReportByJobType(ref findMatter, DropDownListJobType.SelectedValue);
            }
        }
    }

    private void bindDDL(EnumReportFeeEarner? type)
    {
        if (type != EnumReportFeeEarner.feeEarner)
        {
            addItemFeeEarner();
        }
        if (type != EnumReportFeeEarner.matterNum)
        {
            addItemMatterNum();
        }
        if (type != EnumReportFeeEarner.client)
        {
            addItemMatterClient();
        }
        if (type != EnumReportFeeEarner.referer)
        {
            addItemMatterReferer();
        }
        if (type != EnumReportFeeEarner.jobType)
        {
            addItemMatterJobType();
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
    private DateTime getDateTime()
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(this.TextBoxDate.Text);
        return dt;
    }
    private DateTime getDateTimeTo()
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(this.TextBoxDateTo.Text);
        return dt;
    }

    protected void ButtonPrint_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (!String.IsNullOrEmpty(this.TextBoxDate.Text))
        {
            sb.Append(QueryStringConst.date);
            sb.Append("=");
            sb.Append(this.TextBoxDate.Text);

            sb.Append("&");
            sb.Append(QueryStringConst.dateTo);
            sb.Append("=");
            sb.Append(this.TextBoxDateTo.Text);

            var findMatter = rI.findMatterReport();
            rI.findMatterReportByDate(ref findMatter, TextBoxDate.Text, TextBoxDateTo.Text);
            int countResult = findMatter.Count();
            if (countResult == 0)
            {
                displayAlert(Resources.LanguagePack.ReporyNewMatterNoResult);
                return;
            }

        }
        if (DropDownListFeeEarner.SelectedValue != "-1" && DropDownListFeeEarner.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.feeEarner);
            sb.Append("=");
            sb.Append(this.DropDownListFeeEarner.SelectedValue);
        }

        if (DropDownListClient.SelectedValue != "-1" && DropDownListClient.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.client);
            sb.Append("=");
            sb.Append(this.DropDownListClient.SelectedValue);
        }

        if (DropDownListMatterNo.SelectedValue != "-1" && DropDownListMatterNo.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.matter);
            sb.Append("=");
            sb.Append(this.DropDownListMatterNo.SelectedValue);
        }

        if (DropDownListRefer.SelectedValue != "-1" && DropDownListRefer.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.referer);
            sb.Append("=");
            sb.Append(this.DropDownListRefer.SelectedValue);
        }

        if (DropDownListJobType.SelectedValue != "-1" && DropDownListJobType.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.jobType);
            sb.Append("=");
            sb.Append(this.DropDownListJobType.SelectedValue);
        }

        //if (CheckBoxDesciption.Checked)
        //{
        //    sb.Append("&");
        //    sb.Append(QueryStringConst.description);
        //    sb.Append("=");
        //    sb.Append("T");
        //}

        //if (CheckBoxBillable.Checked)
        //{
        //    sb.Append("&");
        //    sb.Append(QueryStringConst.billable);
        //    sb.Append("=");
        //    if (RadioButtonListBillable.Items[0].Selected)
        //    {
        //        sb.Append("true");
        //    }
        //    else
        //    {
        //        sb.Append("false");
        //    }
        //}

        //if (CheckBoxbill.Checked)
        //{
        //    sb.Append("&");
        //    sb.Append(QueryStringConst.billOrUnbill);
        //    sb.Append("=");
        //    if (RadioButtonListbill.Items[0].Selected)
        //    {
        //        sb.Append("true");
        //    }
        //    else
        //    {
        //        sb.Append("false");
        //    }
        //}

        if (RadioButtonBillable.Checked)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.billable);
            sb.Append("=");
            sb.Append("true");

            if (RadioButtonListBillable.Items[0].Selected)
            {
                sb.Append("&");
                sb.Append(QueryStringConst.billOrUnbill);
                sb.Append("=");
                sb.Append("false");
            }
            else if (RadioButtonListBillable.Items[1].Selected)
            {
                sb.Append("&");
                sb.Append(QueryStringConst.billOrUnbill);
                sb.Append("=");
                sb.Append("true");
            }


        }
        if (RadioButtonNonBillable.Checked)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.billable);
            sb.Append("=");
            sb.Append("false");
        }



        popup(String.Format("FeeEarnerView.aspx?{0}", sb.ToString()));
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
    protected void ButtonFeeEarnerChart_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (!String.IsNullOrEmpty(this.TextBoxAllMatterDate.Text))
        {
            sb.Append(QueryStringConst.date);
            sb.Append("=");
            sb.Append(this.TextBoxAllMatterDate.Text);

            sb.Append("&");
            sb.Append(QueryStringConst.dateTo);
            sb.Append("=");
            sb.Append(this.TextBoxAllMatterDateTo.Text);

            var findMatter = rI.findMatterReport();
            rI.findMatterReportByDate(ref findMatter, TextBoxAllMatterDate.Text, TextBoxAllMatterDateTo.Text);
            int countResult = findMatter.Count();
            if (countResult == 0)
            {
                displayAlert(Resources.LanguagePack.ReporyNewMatterNoResult);
                return;
            }
        }
        var tempList = MultiselectDropdownIntroducer.getSelectedId();
        if (tempList.Count != 0)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.feeEarner);
            sb.Append("=");
            sb.Append(String.Join(",", tempList.ToArray()));
        }

        popup(String.Format("chart.aspx?{0}", sb.ToString()));
    }


}