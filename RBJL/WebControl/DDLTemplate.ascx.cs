using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_DDLTemplate : System.Web.UI.UserControl
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
        set { DropDownList1.SelectedValue = value; }
    }

    public string DDLText
    {
        get
        {
            try { return DropDownList1.SelectedItem.Text; }
            catch { return null; }
        }
        set { DropDownList1.SelectedItem.Text = value; }
    }


    public void setDllValue(string id, string text)
    {
        ListItem checkList = new ListItem(text, id);
        if (this.DropDownList1.Items.Contains(checkList))
        {
            this.DropDownList1.SelectedValue = id;
        }
        //else
        //{
        //    this.DropDownList1.Items.Add(checkList);
        //    this.DropDownList1.SelectedItem.Text = id;
        //}
    }
}