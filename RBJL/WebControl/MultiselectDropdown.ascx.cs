using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_MultiselectDropdown : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Guid matterId { get; set; }
    public EnumFeeEarnerAndHandlingColleague type { get; set; }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                name += CheckBoxList1.Items[i].Text + ",";
            }
        }
        TextBox1.Text = name;
    }


    public List<string> getSelectedId()
    {
        List<string> result = new List<string>();
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                result.Add(CheckBoxList1.Items[i].Value);
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
        }
        return name;
    }

    protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        UserInfo uI = new UserInfo();
        e.DataSource.Where = uI.sqlUser(type);
    }
}