using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_DDLFeeEarner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public string DDLId
    {
        get
        {
            try { return DropDownList1.SelectedValue; }
            catch { return null; }
        }
        set
        {
            try { DropDownList1.SelectedValue = value; }
            catch { }
        }
    }

    public string DDLText
    {
        get
        {
            try { return DropDownList1.SelectedItem.Text; }
            catch { return null; }
        }
        set
        {
            try { DropDownList1.SelectedItem.Text = value; }
            catch { }
        }
    }


    protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        if (e.DataSource.Where == null)
        {
            UserInfo uI = new UserInfo();
            e.DataSource.Where = uI.sqlUser(EnumFeeEarnerAndHandlingColleague.FeeEarner);
        }
    }
}