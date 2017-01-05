using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_DDLKeywork : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            // Insert 'Select'
            DropDownList1.Items.Insert(0, new ListItem("[Not Set]", "0"));

            // Set selected index
            DropDownList1.SelectedIndex = 0;
        }
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
            try
            {
                if (DropDownList1.SelectedItem.Text == "[Not Set]") { return null; }
                return DropDownList1.SelectedItem.Text;
            }
            catch { return null; }
        }
        set { DropDownList1.SelectedItem.Text = value; }
    }
}