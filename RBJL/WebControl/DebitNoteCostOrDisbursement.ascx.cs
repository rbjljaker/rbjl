using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GeneralUtilities;
using System.Web.Security;

public partial class WebControl_DebitNoteCostOrDisbursement : System.Web.UI.UserControl
{
    ReportInfo rI = new ReportInfo();
    MaterItem masterInfo = new MaterItem();
    Random rnd = new Random(123461518);

    protected void Page_Load(object sender, EventArgs e)
    {
        dataBindGv();
        if (!IsPostBack)
        {
            if (type == EnumDebitNoteCostOrDisbursement.Cost)
            {
                MatterInfo mI = new MatterInfo();
                LabelRemarkValue.Text = mI.findMatterRemark();
                setFeeEarnerDDL();
            }
            else if (type == EnumDebitNoteCostOrDisbursement.Misc)
            {
                isSetFeeEarner.Visible = false;
                isRemark.Visible = false;

                GridViewCost.Columns[3].Visible = false;
            }
            else
            {
                isSetFeeEarner.Visible = false;
                isRemark.Visible = false;

                GridViewCost.Columns[3].Visible = false;
            }
            setDDLIsEnable();
            setDDLIsEnableTemplate();
            initDDL();
            initDDLPring();
        }
    }

    public EnumDebitNoteCostOrDisbursement type { get; set; }

    public DataTable dTableSession
    {
        get
        {
            if (type == EnumDebitNoteCostOrDisbursement.Cost)
            {
                return SessionClass.DebitNoteCostDataTable;
            }
            else if (type == EnumDebitNoteCostOrDisbursement.Misc)
            {
                return SessionClass.DebitNoteMiscDataTable;
            }
            else
            {
                return SessionClass.DebitNoteDisbursementDataTable;
            }
        }
        set
        {
            if (type == EnumDebitNoteCostOrDisbursement.Cost)
            {
                SessionClass.DebitNoteCostDataTable = value;
            }
            else if (type == EnumDebitNoteCostOrDisbursement.Misc)
            {
                SessionClass.DebitNoteMiscDataTable = value;
            }
            else
            {
                SessionClass.DebitNoteDisbursementDataTable = value;
            }
        }
    }

    protected void ButtonCostSubmit_Click(object sender, EventArgs e)
    {
        if (dTableSession == null)
        {
            string header = DebitNoteHr.setHr();
            DataTable dt = DataTableHelper.CreateDataTable(header);
            setCostGv(dt);
        }
        else
        {
            DataTable dt = dTableSession;
            setCostGv(dt);
        }
    }

    private void setCostGv(DataTable dt)
    {
        string[] strList = new string[dt.Columns.Count];

        int card = rnd.Next(2147483647);
        strList[0] = card.ToString();
        //strList[0] = dt.Rows.Count.ToString();
        if (CheckBoxCost.Checked)
        {
            strList[1] = DropDownListCost.SelectedValue;
            strList[2] = DropDownListCost.SelectedItem.Text;
        }
        else if (CheckBoxTemplateCore.Checked)
        {
            //strList[1] = DropDownListCost.SelectedValue;
            //strList[2] = DropDownListCost.SelectedItem.Text;
            strList[1] = DropDownListTemplateCore.SelectedValue;
            strList[2] = DropDownListTemplateCore.SelectedItem.Text;
        }
        else
        {
            strList[1] = "";
            strList[2] = "";
        }

        strList[3] = TextBoxCostDescription.Text;
        strList[4] = TextBoxCost.Text;

        int tempIntValue = 0;
        bool checingInt = Int32.TryParse(TextBoxOrderBy.Text, out tempIntValue);
        strList[5] = checingInt ? tempIntValue.ToString() : "";

        strList[6] = DropDownListFeeEarner.SelectedValue != "-1" ? DropDownListFeeEarner.SelectedValue : "";

        string dTableValue = DataTableHelper.joinArrayToString(strList);

        DataTableHelper.CreateDataRow(ref dt, dTableValue);
        dTableSession = dt;
        dataBindGv();
    }

    private void dataBindGv()
    {
        DataTable dt = dTableSession;
        if (dt != null)
        {
            GridViewCost.DataSource = dt;
            GridViewCost.DataBind();
        }
    }


    protected void GridViewCost_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridViewCost_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = dTableSession;

        DataRow dr = dt.Rows[e.RowIndex];

        dt.Rows.Remove(dr);

        GridViewCost.EditIndex = -1;
        dataBindGv();
    }
    protected void GridViewCost_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GridViewCost_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //DataTable dt = dTableSession;

        //DataRow dr = dt.Rows[e.RowIndex];

        //dr[] = ucDllCostTemplate.DDLId;
        //strList[2] = ucDllCostTemplate.DDLText;
        //strList[3] = TextBoxCostDescription.Text;
        //strList[4] = TextBoxCost.Text;

        //dr.AcceptChanges();
        //(DataTable)SessionClass.DebitNoteCostDataTable = dt;

        //GridViewCost.EditIndex = -1;
        //dataBindGv();
    }
    protected void CheckBoxCost_CheckedChanged(object sender, EventArgs e)
    {
        setDDLIsEnable();
    }

    protected void CheckBoxTemplateCore_CheckedChanged(object sender, EventArgs e)
    {
        setDDLIsEnableTemplate();
    }

    private void setDDLIsEnable()
    {
        CheckBoxTemplateCore.Checked = false;
        DropDownListTemplateCore.Enabled = CheckBoxTemplateCore.Checked;
        DropDownListTemplateDetails.Enabled = CheckBoxTemplateCore.Checked;

        DropDownListCost.Enabled = CheckBoxCost.Checked;
        DropDownListPricingDetails.Enabled = CheckBoxCost.Checked;
        //if (CheckBoxCost.Checked)
        //{
        //    getDDLValueSetValue();
        //}
        //else
        //{
        //    TextBoxCost.Text = "";
        //    TextBoxCost.ReadOnly = false;
        //}
    }

    private void setDDLIsEnableTemplate()
    {
        CheckBoxCost.Checked = false;
        DropDownListCost.Enabled = CheckBoxCost.Checked;
        DropDownListPricingDetails.Enabled = CheckBoxCost.Checked;

        DropDownListTemplateCore.Enabled = CheckBoxTemplateCore.Checked;
        DropDownListTemplateDetails.Enabled = CheckBoxTemplateCore.Checked;
        //if (CheckBoxCost.Checked)
        //{
        //    getDDLValueSetValue();
        //}
        //else
        //{
        //    TextBoxCost.Text = "";
        //    TextBoxCost.ReadOnly = false;
        //}
    }



    protected void DropDownListCost_SelectedIndexChanged(object sender, EventArgs e)
    {
        // getDDLValueSetValue();
        initDDLPring();
    }

    protected void DropDownListTemplateDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListTemplateDetails.SelectedValue != "-1")
        {
            TextBoxCostDescription.Text = DropDownListTemplateDetails.SelectedItem.Text;
        }
    }

    protected void DropDownListPricingDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListPricingDetails.SelectedValue != "-1")
        {
            TextBoxCostDescription.Text = DropDownListPricingDetails.SelectedItem.Text;
            TextBoxCost.Text = DropDownListPricingDetails.SelectedValue;
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

    private void initDDLPring()
    {
        addItemHr(DropDownListPricingDetails);
        var getList = masterInfo.getPringDDL(DropDownListCost.SelectedValue);
        foreach (var item in getList)
        {
            addItem(DropDownListPricingDetails, item.value, item.id);
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

    private void addNotSetItemHr(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("[Not Set]", "-1"));
    }

    protected void GridViewCost_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Control ctl = e.CommandSource as Control;
        //GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

        //string tarId;
        //tarId = GridViewCost.DataKeys[CurrentRow.RowIndex].Value.ToString();
        //Response.Write(tarId);
    }
    //protected void ButtonEdit_Click(object sender, EventArgs e)
    //{
    //    setBtn(true);
    //}
    protected void ButtonCostUpdate_Click(object sender, EventArgs e)
    {
        DataTable tarDt = dTableSession;

        int findIndex = Convert.ToInt16(HiddenFieldTarId.Value);

        if (CheckBoxCost.Checked)
        {
            tarDt.Rows[findIndex][1] = DropDownListCost.SelectedValue;
            tarDt.Rows[findIndex][2] = DropDownListCost.SelectedItem.Text;
        }
        else if (CheckBoxTemplateCore.Checked)
        {
            tarDt.Rows[findIndex][1] = DropDownListCost.SelectedValue;
            tarDt.Rows[findIndex][2] = DropDownListCost.SelectedItem.Text;
        }
        else
        {
            tarDt.Rows[findIndex][1] = "";
            tarDt.Rows[findIndex][2] = "";
        }
        tarDt.Rows[findIndex][3] = TextBoxCostDescription.Text;
        tarDt.Rows[findIndex][4] = TextBoxCost.Text;

        int tempIntValue = 0;
        bool checingInt = Int32.TryParse(TextBoxOrderBy.Text, out tempIntValue);
        tarDt.Rows[findIndex][5] = checingInt ? tempIntValue.ToString() : "";

        tarDt.Rows[findIndex][6] = DropDownListFeeEarner.SelectedValue != "-1" ? DropDownListFeeEarner.SelectedValue : "";

        dTableSession = tarDt;
        setBtn(false);
        dataBindGv();
    }
    protected void ButtonCostCancel_Click(object sender, EventArgs e)
    {
        setBtn(false);
    }


    private void setBtn(bool isUpdate)
    {
        ButtonCostSubmit.Visible = !isUpdate;
        ButtonCostUpdate.Visible = isUpdate;
        ButtonCostCancel.Visible = isUpdate;
        if (!isUpdate)
        {
            TextBoxCostDescription.Text = "";
            TextBoxCost.Text = "";
            GridViewCost.SelectedIndex = -1;
        }
    }

    protected void GridViewCost_SelectedIndexChanged(object sender, EventArgs e)
    {
        int indexValue = GridViewCost.SelectedRow.DataItemIndex;
        HiddenField findId = GridViewCost.Rows[indexValue].FindControl("HiddenFieldId") as HiddenField;
        //Label lblDescription = GridViewCost.Rows[indexValue].FindControl("lblDescription") as Label;
        //Label lblCost = GridViewCost.Rows[indexValue].FindControl("lblCost") as Label;
        HiddenFieldTarId.Value = indexValue.ToString();

        var findTar = dTableSession.AsEnumerable().Where(q => q.Field<string>("id") == findId.Value).FirstOrDefault();

        TextBoxCostDescription.Text = findTar.Field<string>(3);
        TextBoxCost.Text = findTar.Field<string>(4);
        TextBoxOrderBy.Text = findTar.Field<string>(5);

        var findValue = findTar.Field<string>(6);
        if (DropDownListFeeEarner.Items.FindByValue(findValue) != null)
        {
            DropDownListFeeEarner.SelectedValue = findValue;
        }
        else
        {
            DropDownListFeeEarner.SelectedValue = "-1";
        }


        setBtn(true);
    }

    private void setFeeEarnerDDL()
    {
        var getQ = Request[QueryStringConst.matterList];
        var getMatterListData = rI.getMatterListData(getQ);
        var tarLsit = rI.bindListNewRecordFeeEarner(getMatterListData);
        bindDDL(DropDownListFeeEarner, tarLsit);
    }

    private void bindDDL(DropDownList ddl, List<DDLValueDto> tarLsit)
    {
        string tempValue = ddl.SelectedValue;
        ddl.Items.Clear();
        addNotSetItemHr(ddl);

        foreach (DDLValueDto item in tarLsit)
        {
            addItem(ddl, item.value, item.id);
        }

        //if (!String.IsNullOrEmpty(tempValue) && ddl.Items.Count > 1)
        //{
        //    ddl.SelectedValue = tempValue;
        //}
    }


    protected string findUserName(object tar)
    {
        string result = "";

        var tempString = Convert.ToString(tar);
        if (!String.IsNullOrEmpty(tempString))
        {

            MembershipUser curUser = Membership.GetUser(new Guid(tempString));
            if (curUser != null)
            {
                UserInfo uI = new UserInfo();
                result = uI.getIntroducer(tempString);
            }
        }
        return result;
    }

}
