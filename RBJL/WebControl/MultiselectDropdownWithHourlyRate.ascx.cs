using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeneralUtilities;

public partial class WebControl_MultiselectDropdownWithHourlyRate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }

    public Guid matterId { get; set; }
    public EnumFeeEarnerAndHandlingColleague type { get; set; }
    public List<HourlyRateDto> repList { get; set; }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "";
        repList = new List<HourlyRateDto>();
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                repList.Add(new HourlyRateDto() { userId = CheckBoxList1.Items[i].Value, userName = CheckBoxList1.Items[i].Text + ":" });
                name += CheckBoxList1.Items[i].Text + ",";
            }
        }
        TextBox1.Text = name;
        repeaterGetData();
        repeaterDataBind();
    }

    public List<HourlyRateDto> getSelectedId()
    {
        List<HourlyRateDto> result = new List<HourlyRateDto>();
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                foreach (RepeaterItem item in RepeaterHourlyRate.Items)
                {
                    HiddenField findUserId = (HiddenField)item.FindControl("HiddenField1");
                    if (findUserId.Value == CheckBoxList1.Items[i].Value)
                    {
                        TextBox hourlyRate = (TextBox)item.FindControl("TextBoxHourlyRate");
                        result.Add(new HourlyRateDto() { userId = findUserId.Value, hourRate = hourlyRate.Text });
                    }
                }
            }
        }
        return result;
    }

    public string setValue()
    {
        string name = "";
        if (matterId != null)
        {
            MatterInfo mI = new MatterInfo();
            var findMatter = mI.getMatterUserGuid(matterId, type);

            foreach (ListItem cbItem in CheckBoxList1.Items)
            {
                foreach (var item in findMatter)
                {
                    if (cbItem.Value == item.ToString())
                    {
                        cbItem.Selected = true;
                        name += cbItem.Text + ",";
                    }
                }
            }

            var tempResult = mI.db.MatterAndFeeEarners.Where(q => q.matterId == matterId);
            List<string> tempValue = new List<string>();
            foreach (var item in tempResult)
            {
                string hourlyRate = item.hourlyRate.HasValue ? item.hourlyRate.Value.ToString() : "";
                tempValue.Add(item.feeEarnerId + ":" + hourlyRate);
            }
            HiddenFieldSaveValue.Value = String.Join(",", tempValue.ToArray());


            CheckBoxList1_SelectedIndexChanged(new object(), new EventArgs());

        }
        return name;
    }

    protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        UserInfo uI = new UserInfo();
        e.DataSource.Where = uI.sqlUser(type);
    }


    private void repeaterDataBind()
    {
        RepeaterHourlyRate.DataSource = ListToDataTableHelper.ConvertToDataTable(repList);
        RepeaterHourlyRate.DataBind();
    }

    private void repeaterGetData()
    {
        var getValue = HiddenFieldSaveValue.Value;
        if (!String.IsNullOrEmpty(getValue))
        {
            var tempArr = getValue.Split(',');
            foreach (var getTempValue in tempArr)
            {
                //for (int i = 0; i < repList.Count; i++)
                //{
                //    if (repList[i].userId == getTempValue.Split(':')[0])
                //    {
                //        repList[i].hourRate = getTempValue.Split(':')[1];
                //    }
                //}
                foreach (var item in repList)
                {
                    if (item.userId == getTempValue.Split(':')[0])
                    {
                        item.hourRate = getTempValue.Split(':')[1];
                    }
                }
            }

        }
    }

    protected void TextBoxHourlyRate_TextChanged(object sender, EventArgs e)
    {
        saveTempData();
    }

    private void saveTempData()
    {
        List<string> tempValue = new List<string>();
        foreach (RepeaterItem item in RepeaterHourlyRate.Items)
        {
            HiddenField findUserId = (HiddenField)item.FindControl("HiddenField1");
            TextBox hourlyRate = (TextBox)item.FindControl("TextBoxHourlyRate");
            tempValue.Add(findUserId.Value + ":" + hourlyRate.Text);
        }
        if (tempValue != null)
        {
            HiddenFieldSaveValue.Value = String.Join(",", tempValue.ToArray());
        }
    }
}