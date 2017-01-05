using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;


public partial class Report_NewMatterRecord : CultureEnabledPage
{
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(2);", true);
        if (!IsPostBack)
        {
            initControl(false);

            if (rI.userLevel != EnumUserLevel.administrator)
            {
                ButtonAllMatter.Visible = false;
                PanelAllMatter.Visible = false;
            }
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
        if (DropDownListClient.SelectedValue != "-1" && DropDownListClient.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.client);
            sb.Append("=");
            sb.Append(this.DropDownListClient.SelectedValue);
        }


        popup(String.Format("NewMatterRecordReportView.aspx?{0}", sb.ToString()));
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


    //private DateTime getDateTime()
    //{
    //    DateTime dt = DateTimeHelper.convertStringToDateTime(this.TextBoxDate.Text);
    //    return dt;
    //}

    //private DateTime getDateTimeTo()
    //{
    //    DateTime dt = DateTimeHelper.convertStringToDateTime(this.TextBoxDateTo.Text);
    //    return dt;
    //}

    private void initControl(bool setting)
    {
        DropDownListFeeEarner.Enabled = setting;
        DropDownListMatterNo.Enabled = setting;
        DropDownListSubject.Enabled = setting;
        DropDownListClient.Enabled = setting;
        //TextBoxSubject.Enabled = false;
        //TextBoxClient.Enabled = false;
        if (!setting)
        {
            DropDownListFeeEarner.Items.Clear();
            DropDownListMatterNo.Items.Clear();
            DropDownListSubject.Items.Clear();
            DropDownListClient.Items.Clear();
            //this.TextBoxSubject.Text = "";
            //this.TextBoxClient.Text = "";
        }
    }


    public void addItemFeeEarner()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportMatter.feeEarner);
        var tarLsit = rI.bindListNewRecordFeeEarner(findMatter);
        bindDDL(DropDownListFeeEarner, tarLsit);

    }

    public void addItemMatterNum()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportMatter.MatterNum);
        var tarLsit = rI.bindListNewRecordMatterNum(findMatter);
        bindDDL(DropDownListMatterNo, tarLsit);
    }

    public void addItemMatterSubject()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportMatter.subject);
        var tarLsit = rI.bindListNewRecordMatterSubject(findMatter);
        bindDDL(DropDownListSubject, tarLsit);
    }

    public void addItemMatterClient()
    {
        var findMatter = getData();
        filter(ref findMatter, EnumReportMatter.client);
        var tarLsit = rI.bindListNewRecordMatterClient(findMatter);
        bindDDL(DropDownListClient, tarLsit);
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

    private void filter(ref IQueryable<View_FindMatter> findMatter, EnumReportMatter type)
    {
        if (type != EnumReportMatter.feeEarner)
        {
            if (DropDownListFeeEarner.SelectedValue != "-1" && DropDownListFeeEarner.SelectedValue != "")
            {
                rI.findMatterReportByFeeEarner(ref findMatter, DropDownListFeeEarner.SelectedValue);
            }
        }
        if (type != EnumReportMatter.MatterNum)
        {
            if (DropDownListMatterNo.SelectedValue != "-1" && DropDownListMatterNo.SelectedValue != "")
            {
                rI.findMatterReportById(ref findMatter, DropDownListMatterNo.SelectedValue);
            }
        }
        if (type != EnumReportMatter.subject)
        {
            if (DropDownListSubject.SelectedValue != "-1" && DropDownListSubject.SelectedValue != "")
            {
                rI.findMatterReportBySubject(ref findMatter, DropDownListSubject.SelectedValue);
            }
        }
        if (type != EnumReportMatter.client)
        {
            if (DropDownListClient.SelectedValue != "-1" && DropDownListClient.SelectedValue != "")
            {
                rI.findMatterReportByClinetId(ref findMatter, DropDownListClient.SelectedValue);
            }
        }
    }

    protected void DropDownListMatterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportMatter.MatterNum);
    }
    protected void DropDownListFeeEarner_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportMatter.feeEarner);
    }
    protected void DropDownListSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportMatter.subject);
    }
    protected void DropDownListClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportMatter.client);
    }

    private void bindDDL(EnumReportMatter? type)
    {
        if (type != EnumReportMatter.feeEarner)
        {
            addItemFeeEarner();
        }
        if (type != EnumReportMatter.MatterNum)
        {
            addItemMatterNum();
        }
        if (type != EnumReportMatter.subject)
        {
            addItemMatterSubject();
        }
        if (type != EnumReportMatter.client)
        {
            addItemMatterClient();
        }
    }



    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
    protected void ButtonAllMatter_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();


        bool txt1HasText = !String.IsNullOrEmpty(TextBoxAllMatterDate.Text);
        bool txt2HasText = !String.IsNullOrEmpty(TextBoxAllMatterDateTo.Text);

        sb.Append("exportMatter.aspx");
        if (txt1HasText && txt2HasText)
        {
            sb.Append("?");
            sb.Append(QueryStringConst.date);
            sb.Append("=");
            sb.Append(TextBoxAllMatterDate.Text);
            sb.Append("&");
            sb.Append(QueryStringConst.dateTo);
            sb.Append("=");
            sb.Append(TextBoxAllMatterDateTo.Text);
        }


        popup(Convert.ToString(sb));
    }

}