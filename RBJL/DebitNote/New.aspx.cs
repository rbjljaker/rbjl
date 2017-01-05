using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class DebitNote_New : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        MatterInfo mi = new MatterInfo();

        string matterNumList = TextBoxMatterNum.Text;
        string matterId = "";
        string matterIdList = "";


        bool findResult = mi.getMatterIdByMatterNum(matterNumList, ref matterId, ref matterIdList);
        if (findResult)
        {
            //SessionClass.MatterId = findResult.Value.ToString();
            Response.Redirect(String.Format("NewDebitNote.aspx?matter={0}&matterList={1}", matterId, matterIdList));
        }
        else
        {
            displayAlert("Not Matter number.");
        }
    }
}