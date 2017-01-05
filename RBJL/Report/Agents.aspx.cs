using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Report_Agents : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(2);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "setInitText", " initTextClient();", true);
        }
    }
    protected void ButtonPrint_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        bool txt1HasText = !String.IsNullOrEmpty(TextBoxDate.Text);
        bool txt2HasText = !String.IsNullOrEmpty(TextBoxDateTo.Text);

        if ((txt1HasText && !txt2HasText) || (!txt1HasText && txt2HasText))
        {
            displayAlert("Please select correct date.");
            return;
        }

        if (RadioButtonClient.Checked)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "setInitText", " initTextClient();", true);
            sb.Append(QueryStringConst.dType);
            sb.Append("=C");
        }
        else if (RadioButtonRefer.Checked)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "setInitText", " initTextRefer();", true);
            sb.Append(QueryStringConst.dType);
            sb.Append("=R");
        }
        else if (RadioButtonOutgoingAgent.Checked)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "setInitText", " initTextOutgoingAgent();", true);
            sb.Append(QueryStringConst.dType);
            sb.Append("=O");
        }

        if (CheckBoxIsShow1.Checked)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.isShow1);
            sb.Append("=T");
        }


        if (CheckBoxIsShow2.Checked)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.isShow2);
            sb.Append("=T");
        }

        if (txt1HasText && txt2HasText)
        {
            sb.Append("&");
            sb.Append(QueryStringConst.date);
            sb.Append("=");
            sb.Append(TextBoxDate.Text);
            sb.Append("&");
            sb.Append(QueryStringConst.dateTo);
            sb.Append("=");
            sb.Append(TextBoxDateTo.Text);
        }

        popup(String.Format("ExportData.aspx?{0}", sb.ToString()));
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
}