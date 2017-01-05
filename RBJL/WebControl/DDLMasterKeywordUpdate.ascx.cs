using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_DDLMasterKeywordUpdate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (DropDownList1.Items.FindByText("[Not Set]") == null)
        {
            DropDownList1.Items.Insert(0, new ListItem("[Not Set]", "0"));
        }

    }



    public string initValue { get; set; }

    public string initId { get; set; }


    public string setTxtValue()
    {
        try { DDLId = initId; }
        catch { try { DDLText = initValue; } catch { } }

        return "";
    }

    public string TxtText
    {
        get
        {
            try { return TextBox1.Text; }
            catch { return null; }
        }
        set { TextBox1.Text = value; }
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TxtText = DropDownList1.SelectedItem.Text;

    }
}