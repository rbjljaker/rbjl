using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;

public partial class Report_DebitNote : CultureEnabledPage
{
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
        if (!IsPostBack)
        {
            LanguageHandler.SetLanguage(Context, Languages.English);
            initControl(false);
        }
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

    private void initControl(bool setting)
    {
        DropDownListFeeEarner.Enabled = setting;
        DropDownListMatterNo.Enabled = setting;
        DropDownListSubject.Enabled = setting;
        DropDownListState.Enabled = setting;

        if (!setting)
        {
            DropDownListFeeEarner.Items.Clear();
            DropDownListMatterNo.Items.Clear();
            DropDownListSubject.Items.Clear();
            DropDownListState.Items.Clear();
        }
    }

    //public void addItemByDate()
    //{
    //    addItemHr(DropDownListFeeEarner);
    //    var tarLsit = rI.getDebitNoteUser(getDateTime(), getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListFeeEarner, item.value, item.id);
    //    }
    //}

    //public void addItemByDateAndFeeEarner()
    //{
    //    addItemHr(DropDownListMatterNo);

    //    var tarLsit = rI.getDebitNoteMatterNum(getDateTime(), DropDownListFeeEarner.SelectedValue, getDateTimeTo());
    //    foreach (var item in tarLsit)
    //    {
    //        addItem(DropDownListMatterNo, item.value, item.id);
    //    }
    //}

    private void addItem(DropDownList ddl, string text, string value)
    {
        ddl.Items.Add(new ListItem(text, value));
    }

    private void addItemHr(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("------", "-1"));
    }

    public void addItemFeeEarner()
    {
        var findDebitNote = getData();
        filter(ref findDebitNote, EnumReportDebitNote.feeEarner);
        var tarLsit = rI.getDebitNoteFeeEarner(findDebitNote);
        bindDDL(DropDownListFeeEarner, tarLsit);

    }

    public void addItemMatterNum()
    {
        var findDebitNote = getData();
        filter(ref findDebitNote, EnumReportDebitNote.matterNum);
        var tarLsit = rI.getDebitNoteMatterNum(findDebitNote);
        bindDDL(DropDownListMatterNo, tarLsit);
    }

    public void addItemMatterSubject()
    {
        var findDebitNote = getData();
        filter(ref findDebitNote, EnumReportDebitNote.subject);
        var tarLsit = rI.getDebitNoteMatterSubject(findDebitNote);
        bindDDL(DropDownListSubject, tarLsit);
    }

    public void addItemMatterStatus()
    {
        var findDebitNote = getData();
        filter(ref findDebitNote, EnumReportDebitNote.status);
        var tarLsit = rI.getDebitNoteMatterStatus(findDebitNote);
        bindDDL(DropDownListState, tarLsit);
    }

    protected void DropDownListFeeEarner_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportDebitNote.feeEarner);
    }

    protected void DropDownListMatterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportDebitNote.matterNum);
    }

    protected void DropDownListSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportDebitNote.subject);
    }
    protected void DropDownListState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDL(EnumReportDebitNote.status);
    }

    private void filter(ref IQueryable<View_ReportDebitNote> findDebitNote, EnumReportDebitNote type)
    {
        if (type != EnumReportDebitNote.feeEarner)
        {
            if (DropDownListFeeEarner.SelectedValue != "-1" && DropDownListFeeEarner.SelectedValue != "")
            {
                rI.findDebitNoteReportByFeeEarner(ref findDebitNote, DropDownListFeeEarner.SelectedValue);
            }
        }
        if (type != EnumReportDebitNote.matterNum)
        {
            if (DropDownListMatterNo.SelectedValue != "-1" && DropDownListMatterNo.SelectedValue != "")
            {
                rI.findDebitNoteReportByMatterNumId(ref findDebitNote, DropDownListMatterNo.SelectedValue);
            }
        }
        if (type != EnumReportDebitNote.subject)
        {
            if (DropDownListSubject.SelectedValue != "-1" && DropDownListSubject.SelectedValue != "")
            {
                rI.findDebitNoteReportBySubject(ref findDebitNote, DropDownListSubject.SelectedValue);
            }
        }
        if (type != EnumReportDebitNote.status)
        {
            if (DropDownListState.SelectedValue != "-1" && DropDownListState.SelectedValue != "")
            {
                rI.findDebitNoteReportByStatus(ref findDebitNote, DropDownListState.SelectedValue);
            }
        }
    }

    private void bindDDL(EnumReportDebitNote? type)
    {
        if (type != EnumReportDebitNote.feeEarner)
        {
            addItemFeeEarner();
        }
        if (type != EnumReportDebitNote.matterNum)
        {
            addItemMatterNum();
        }
        if (type != EnumReportDebitNote.subject)
        {
            addItemMatterSubject();
        }
        if (type != EnumReportDebitNote.status)
        {
            addItemMatterStatus();
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

    private IQueryable<View_ReportDebitNote> getData()
    {
        var findDebitNote = rI.findDebitNoteReport();
        rI.findDebitNoteReportByDate(ref findDebitNote, this.TextBoxDate.Text, this.TextBoxDateTo.Text);
        return findDebitNote;
    }

    private string getListItemChecked()
    {
        List<string> tempList = new List<string>();
        for (int i = 0; i < CheckBoxListType.Items.Count; i++)
        {
            if (CheckBoxListType.Items[i].Selected)
            {
                switch (i)
                {
                    //case (int)EnumCheckBoxListType.Draft:
                    //    tempList.Add("Draft");
                    //    break;
                    //case (int)EnumCheckBoxListType.Language:
                    //    tempList.Add("Language");
                    //    break;
                    //case (int)EnumCheckBoxListType.CompletSet:
                    //tempList.Add("CompletSet");

                    //tempList.Add("Trademark");
                    //tempList.Add("General");
                    //tempList.Add("Patent");
                    //tempList.Add("NotanyPublic");
                    //break;

                    case (int)EnumCheckBoxListType.Trademark:
                        tempList.Add("Trademark");
                        break;
                    case (int)EnumCheckBoxListType.General:
                        tempList.Add("General");
                        break;
                    case (int)EnumCheckBoxListType.Patent:
                        tempList.Add("Patent");
                        break;
                    case (int)EnumCheckBoxListType.NotanyPublic:
                        tempList.Add("NotanyPublic");
                        break;

                }
            }
        }
        return tempList.Count > 0 ? String.Format("&{0}={1}", QueryStringConst.type, String.Join(",", tempList.ToArray())) : "";
    }

    protected void ButtonPrint_Click(object sender, EventArgs e)
    {


        System.Text.StringBuilder sb = new System.Text.StringBuilder();


        //var checking = getListItemChecked();
        //if (String.IsNullOrEmpty(checking))
        //{
        //    displayAlert(Resources.LanguagePack.ReportDebitNotePleaseSelectType);
        //    return;
        //}

        //sb.Append(checking);


        //sb.Append("&");
        sb.Append(QueryStringConst.dType);
        sb.Append("=");
        if (RadioButtonTypeDraft.Checked)
        {
            sb.Append("D");
        }
        else
        {
            sb.Append("C");
        }



        if (!String.IsNullOrEmpty(this.TextBoxDate.Text))
        {
            sb.Append("&");
            sb.Append(QueryStringConst.date);
            sb.Append("=");
            sb.Append(this.TextBoxDate.Text);

            sb.Append("&");
            sb.Append(QueryStringConst.dateTo);
            sb.Append("=");
            sb.Append(this.TextBoxDateTo.Text);

            var findMatter = rI.findDebitNoteReport();
            rI.findDebitNoteReportByDate(ref findMatter, getDateTime(), getDateTimeTo());
            int countResult = findMatter.Count();
            if (countResult == 0)
            {
                displayAlert(Resources.LanguagePack.ReportDebitNoteNoResult);
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

        if (DropDownListState.SelectedValue != "-1" && DropDownListState.Enabled)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.status);
            sb.Append("=");
            sb.Append(this.DropDownListState.SelectedValue);
        }

        popup(String.Format("DebitNoteReportNewView.aspx?{0}", sb.ToString()));
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
}