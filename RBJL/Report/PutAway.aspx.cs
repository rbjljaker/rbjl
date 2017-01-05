using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;

public partial class Report_PutAway : CultureEnabledPage
{
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(2);", true);
        if (!IsPostBack)
        {
            initControl(false);
        }
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

            var findMatter = rI.findPutAwayReport();
            rI.findPutAwayReportByDate(ref findMatter, TextBoxDate.Text, TextBoxDateTo.Text);
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
        if (DropDownListSubject.SelectedValue != "-1" && DropDownListSubject.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.subject);
            sb.Append("=");
            sb.Append(this.DropDownListSubject.SelectedValue);
        }
        if (DropDownListJobType.SelectedValue != "-1" && DropDownListJobType.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.jobType);
            sb.Append("=");
            sb.Append(this.DropDownListJobType.SelectedValue);
        }

        popup(String.Format("PutAwayView.aspx?{0}", sb.ToString()));
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }

    private void initControl(bool setting)
    {
        DropDownListFeeEarner.Enabled = setting;
        DropDownListMatterNo.Enabled = setting;
        DropDownListClient.Enabled = setting;
        DropDownListJobType.Enabled = setting;
        DropDownListSubject.Enabled = setting;

        if (!setting)
        {
            DropDownListFeeEarner.Items.Clear();
            DropDownListMatterNo.Items.Clear();
            DropDownListClient.Items.Clear();
            DropDownListJobType.Items.Clear();
            DropDownListSubject.Items.Clear();
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
        bindDDL(EnumReportPutAway.feeEarner);
    }

    protected void DropDownListClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportPutAway.client);
    }

    protected void DropDownListMatterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportPutAway.matterNum);
    }

    protected void DropDownListSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportPutAway.subject);
    }
    protected void DropDownListJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportPutAway.jobType);
    }


    //private void addItemByDate()
    //{
    //    addItemHr(DropDownListFeeEarner);
    //    var tarLsit = rI.getPutAwayUser(getDateTime(), getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListFeeEarner, item.value, item.id);
    //    }
    //}

    //private void addItemByDateAndFeeEarner()
    //{
    //    addItemHr(DropDownListClient);

    //    var tarLsit = rI.getPutAwayFeeEarnerClient(getDateTime(), DropDownListFeeEarner.SelectedValue, getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListClient, item.value, item.id);
    //    }
    //}

    //private void addItemByDateAndFeeEarnerAndClient()
    //{
    //    addItemHr(DropDownListMatterNo);

    //    var tarLsit = rI.getPutAwayFeeEarnerClientAndMatterNum(getDateTime(), DropDownListFeeEarner.SelectedValue, DropDownListClient.SelectedValue, getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListMatterNo, item.value, item.id);
    //    }
    //}

    public void addItemFeeEarner()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportPutAway.feeEarner);
        var tarLsit = rI.bindListNewRecordFeeEarner(findMatter);
        bindDDL(DropDownListFeeEarner, tarLsit);

    }

    public void addItemMatterNum()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportPutAway.matterNum);
        var tarLsit = rI.bindListNewRecordMatterNum(findMatter);
        bindDDL(DropDownListMatterNo, tarLsit);
    }

    public void addItemMatterClient()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportPutAway.client);
        var tarLsit = rI.bindListNewRecordMatterClient(findMatter);
        bindDDL(DropDownListClient, tarLsit);
    }

    public void addItemMatterSubject()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportPutAway.subject);
        var tarLsit = rI.bindListNewRecordMatterSubject(findMatter);
        bindDDL(DropDownListSubject, tarLsit);
    }

    public void addItemMatterJobType()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportPutAway.jobType);
        var tarLsit = rI.bindListNewRecordMatterJobType(findMatter);
        bindDDL(DropDownListJobType, tarLsit);
    }

    private IQueryable<View_FindMatter> getData()
    {
        var findMatter = rI.findPutAwayReport();
        rI.findPutAwayReportByDate(ref findMatter, this.TextBoxDate.Text, this.TextBoxDateTo.Text);
        return findMatter;
    }

    private void filter(ref IQueryable<View_FindMatter> findMatter, EnumReportPutAway type)
    {
        if (type != EnumReportPutAway.feeEarner)
        {
            if (DropDownListFeeEarner.SelectedValue != "-1" && DropDownListFeeEarner.SelectedValue != "")
            {
                rI.findMatterReportByFeeEarner(ref findMatter, DropDownListFeeEarner.SelectedValue);
            }
        }
        if (type != EnumReportPutAway.matterNum)
        {
            if (DropDownListMatterNo.SelectedValue != "-1" && DropDownListMatterNo.SelectedValue != "")
            {
                rI.findMatterReportById(ref findMatter, DropDownListMatterNo.SelectedValue);
            }
        }
        if (type != EnumReportPutAway.client)
        {
            if (DropDownListClient.SelectedValue != "-1" && DropDownListClient.SelectedValue != "")
            {
                rI.findMatterReportByClinetId(ref findMatter, DropDownListClient.SelectedValue);
            }
        }
        if (type != EnumReportPutAway.subject)
        {
            if (DropDownListSubject.SelectedValue != "-1" && DropDownListSubject.SelectedValue != "")
            {
                rI.findMatterReportBySubject(ref findMatter, DropDownListSubject.SelectedValue);
            }
        }
        if (type != EnumReportPutAway.jobType)
        {
            if (DropDownListJobType.SelectedValue != "-1" && DropDownListJobType.SelectedValue != "")
            {
                rI.findMatterReportByJobType(ref findMatter, DropDownListJobType.SelectedValue);
            }
        }
    }

    private void bindDDL(EnumReportPutAway? type)
    {
        if (type != EnumReportPutAway.feeEarner)
        {
            addItemFeeEarner();
        }
        if (type != EnumReportPutAway.matterNum)
        {
            addItemMatterNum();
        }
        if (type != EnumReportPutAway.client)
        {
            addItemMatterClient();
        }
        if (type != EnumReportPutAway.subject)
        {
            addItemMatterSubject();
        }
        if (type != EnumReportPutAway.jobType)
        {
            addItemMatterJobType();
        }
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
}