using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_CalenderTextBoxWithValidation_ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string textBoxValue
    {
        get
        {
            return TextBoxDate.Text;
        }
        set
        {
            TextBoxDate.Text = value;
        }
    }
}